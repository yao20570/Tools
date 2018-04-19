using dealImage.CommonEnum;
using dealImage.CommonObj;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace dealImage.utils
{



    public class DealUtils
    {

        //图片和plist的对应表（key:图片名，value:plist相对路径+名称）
        public Dictionary<string, string> dictImgMapPlist = new Dictionary<string, string>();

        //图片信息表
        public Dictionary<string, ImgInfo> dictImgInfo = new Dictionary<string, ImgInfo>();

        //lua文件
        public HashSet<string> setNeedFixJsonFileName = new HashSet<string>();

        //处理图片的根目录
        private string dealImagePath = "";

        //处理ui的json的根目录
        private string dealUiJsonPath = "";

        //json解析成lua的工具路径
        private string parseToolPath = "";

        /// <summary>
        /// 遍历记录图片信息
        /// </summary>
        /// <param name="path">遍历的根目录</param>
        public void traverseImgSetInfo(string path)
        {
            this.dealImagePath = path;
            dictImgMapPlist.Clear();
            dictImgInfo.Clear();

            //剔除不需要遍历的文件夹
            FileUtils.addNoTraverseFolder("tx");
            FileUtils.addNoTraverseFolder("Backup");
            
            //遍历文件夹，记录imgInfo
            LogUtils.WriteLine("\n\n遍历文件夹，记录imgInfo");
            FileUtils.TraverseFolders(path, new delegateDealFile(dealImgFile));

            //遍历文件夹，处理plist文件,将碎图和plist文件对应起来
            LogUtils.WriteLine("\n\n遍历文件夹，处理plist文件,将碎图和plist文件对应起来");
            FileUtils.TraverseFolders(path, new delegateDealFile(dealPlistFile));

            LogUtils.WriteLine("\n\n检测图片完毕!!!!!!!!!!!!!\n\n");
        }

        /// <summary>
        /// 遍历ui的json文件修复并拷贝到解析工具转换目录
        /// </summary>
        /// <param name="path">遍历的根目录</param>
        /// <param name="parseToLuaPath">jsonToLua的解析工具路径</param>
        public void traverseUiJsonToFix(string path, string parseToolPath, string projectResPath)
        {
            this.dealUiJsonPath = path;
            this.parseToolPath = parseToolPath;

            LogUtils.WriteLine("\n\n遍历文件夹，修正json文件里的图片信息");

            //遍历文件夹，获取要处理json文件名列表
            FileUtils.TraverseFolders(projectResPath, new delegateDealFile(dealLuaFile));

            //遍历文件夹，处理ui的json文件
            FileUtils.TraverseFolders(path, new delegateDealFile(dealUiJsonFile));

            LogUtils.WriteLine("\n\njson文件图片信息修正完成\n\n");
        }

        public void callParseTool(string parseToolPath)
        {
            LogUtils.WriteLine("\n\njson文件转换成lua文件 ====> start");
            LogUtils.WriteLine("耐心等待\n\n");

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.StartInfo.UseShellExecute = false;   // 是否使用外壳程序 
            process.StartInfo.CreateNoWindow = true;   //是否在新窗口中启动该进程的值 
            process.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
            process.StartInfo.RedirectStandardOutput = true;  //重定向输出流 
            //process.StartInfo.RedirectStandardError = true;  //重定向错误流 
            //process.OutputDataReceived += (s, _e) => LogUtils.WriteLine(_e.Data);
            //process.ErrorDataReceived += (s, _e) => LogUtils.WriteLine(_e.Data);
            process.Exited += (s, _e) =>
            {
                //LogUtils.WriteLine("jsontolua.jar complete");
            };
            process.EnableRaisingEvents = true;//当EnableRaisingEvents为true，进程退出时Process才会调用process.Exited

            process.Start();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();

            string strCmd = string.Format(@"java -jar {0}/tools/jsontolua.jar {0}/json {0}/lua", parseToolPath);
            //string strCmd = "ping www.163.com";
            process.StandardInput.WriteLine(strCmd);
            process.StandardInput.WriteLine("exit");

            LogUtils.WriteLine(process.StandardOutput.ReadToEnd());

            process.WaitForExit();
            //int n = process.ExitCode;  // n 为进程执行返回值 
            process.Close();

            LogUtils.WriteLine("json文件转换成lua文件 ====> end\n\n");
        }

        /// <summary>
        /// 将转化后的lua文件拷贝到项目res目录下
        /// </summary>
        /// <param name="parseToolPath">json解析后的lua保存目录</param>
        /// <param name="projectResPath">项目res目录</param>
        public void copyLuaFile2ProjectResFloder(string parseToolPath, string projectResPath)
        {
            LogUtils.WriteLine("将lua文件拷贝到项目的res目录===>start");

            string luaPath = Path.Combine(parseToolPath, "lua");
            FileUtils.TraverseFolders(luaPath, (fileInfo) =>
            {
                FileUtils.copyFile(fileInfo.FullName, Path.Combine(projectResPath, fileInfo.Name), true);
            });

            LogUtils.WriteLine("将lua文件拷贝到项目的res目录===>end");
        }

        private void dealPlistFile(FileInfo file)
        {
            if (file.Extension == EnumFileType.plist)
            {
                try
                {
                    //相对路径
                    string plistRelativePath = file.FullName.Replace(this.dealImagePath + @"\", "");

                    XmlDocument doc = XmlUtils.getXmlFromFile(file.FullName);
                    XmlNode node1 = doc.ChildNodes[2]; //plist
                    XmlNode node2 = node1.ChildNodes[0];//dict
                    XmlNode node3 = node2.ChildNodes[1];//dict
                    foreach (XmlNode node in node3.ChildNodes)
                    {
                        if (node.Name == "key")
                        {
                            ImgInfo imgInfo = new ImgInfo();
                            imgInfo.name = node.InnerText;
                            imgInfo.path = "";
                            imgInfo.plist = plistRelativePath;

                            try
                            {
                                dictImgInfo.Add(imgInfo.name, imgInfo);
                            }
                            catch
                            {
                                LogUtils.WriteLine("有相同的图片===>{0}",dictImgInfo[imgInfo.name].name);
                                if (dictImgInfo[imgInfo.name].plist != null)
                                {
                                    LogUtils.WriteLine(@"已有图片的plist===>{0}", dictImgInfo[imgInfo.name].plist.Replace(@"/",@"\"));
                                }
                                else
                                {
                                    LogUtils.WriteLine(@"已有图片的单图===>{0}\{1}\{2}", this.dealImagePath, dictImgInfo[imgInfo.name].path, dictImgInfo[imgInfo.name].name);
                                }                                
                                LogUtils.WriteLine(@"当前图片的plist===>{0}", file.FullName);
                                LogUtils.WriteLine("");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //存储失败
                    LogUtils.WriteLine(@"读取plist文件失败===>{0}", file.FullName);
                }
            }
        }

        private void dealImgFile(FileInfo file)
        {
            if (file.Extension == EnumFileType.jpg ||
                file.Extension == EnumFileType.png)
            {
                ImgInfo imgInfo = new ImgInfo();
                imgInfo.name = file.Name;
                imgInfo.path = file.DirectoryName.Replace(this.dealImagePath + @"\", "").TrimEnd(@"\".ToCharArray());

                try
                {
                    dictImgInfo.Add(imgInfo.name, imgInfo);
                }
                catch
                {
                    LogUtils.WriteLine("有相同的图片===>");
                    LogUtils.WriteLine(@"已有图片路径===>{0}\{1}\{2}", this.dealImagePath, dictImgInfo[imgInfo.name].path.Replace(@"/",@"\"), dictImgInfo[imgInfo.name].name);
                    LogUtils.WriteLine("当前图片路径===>{0}\n", file.FullName);
                }
            }
        }

        private void dealLuaFile(FileInfo file)
        {
            if (file.Extension == EnumFileType.lua)
            {
                setNeedFixJsonFileName.Add(file.Name.Replace(file.Extension, ".json"));
            }
        }

        private void dealUiJsonFile(FileInfo file)
        {
            if (file.Extension == EnumFileType.json)
            {
                //if (file.Name == "layout_login.json")
                //{
                //    Console.WriteLine("=================");
                //}

                //if (setNeedFixJsonFileName.Contains(file.Name) == false)
                //{
                //    return;
                //}

                JsonResetInfo resetInfo = new JsonResetInfo();
                JObject jsonObj = JsonUtils.getJsonObjFromJsonFile(file.FullName);

                //递归遍历cocos2d的节点树,修改图片路径
                JToken ccNodeRoot = jsonObj.GetValue(EnumAttriType.widgetTree);
                checkCCNodeChildren(ccNodeRoot, resetInfo);

                #region 似乎不需要改textures, texturesPng
                ////修改texturesPng属性 
                //JArray imgs = (JArray)jsonObj.GetValue(enumAttriType.texturesPng);
                //foreach (var item in resetInfo.dictSingleImage)
                //{
                //    bool isAdd = true;
                //    foreach (JToken jt in imgs)
                //    {
                //        if (jt.ToString() == item)
                //        {
                //            isAdd = false;
                //            break;
                //        }
                //    }
                //    if (isAdd)
                //    {
                //        imgs.Add(item);
                //    }
                //}

                ////修改textures属性  , 
                ////JArray plists = (JArray)jsonObj.GetValue(enumAttriType.textures);
                ////plists.Clear();
                //foreach (var item in resetInfo.dictPlists)
                //{
                //    //plists.Add(item);
                //    bool isAdd = true;
                //    foreach (JToken jt in imgs)
                //    {
                //        if (jt.ToString() == item)
                //        {
                //            isAdd = false;
                //            break;
                //        }
                //    }
                //    if (isAdd)
                //    {
                //        imgs.Add(item);
                //    }
                //}
                #endregion

                //拷贝图片(做了链接，不需要拷贝了)
                //string strUIProjectResPath = Path.Combine(file.DirectoryName, "../Resources");
                //foreach (var item in resetInfo.dictSingleImage)
                //{
                //    string srcSingleImgFullName = Path.Combine(this.dealImagePath, item);

                //    string destSingleImgFullName = Path.Combine(strUIProjectResPath, item);

                //    FileUtils.copyFile(srcSingleImgFullName, destSingleImgFullName, true);
                //}
                //foreach(var item in resetInfo.dictPlists)
                //{
                //    string srcPlistFullName = Path.Combine(this.dealImagePath, item);
                //    string srcImageFullName = srcPlistFullName.Replace(EnumFileType.plist, EnumFileType.png);
                //    if (File.Exists(srcImageFullName) == false)
                //    {
                //        srcImageFullName = srcPlistFullName.Replace(EnumFileType.plist, EnumFileType.jpg);
                //    }                    

                //    string destPlistFullName = srcPlistFullName.Replace(this.dealImagePath, strUIProjectResPath);
                //    string destImageFullName = srcImageFullName.Replace(this.dealImagePath, strUIProjectResPath);

                //    FileUtils.copyFile(srcPlistFullName, destPlistFullName, true);
                //    FileUtils.copyFile(srcImageFullName, destImageFullName, true);
                //}

                //保存到文件
                JsonUtils.writeJsonStrToFile(jsonObj, file.FullName);
                //LogUtils.WriteLine("json文件修改=====>{0}\n", file.FullName);

                //将json文件拷贝到转换成lua的路径
                FileUtils.copyFile(file.FullName, Path.Combine(this.parseToolPath + @"\json", file.Name), true);
            }
        }

        private void checkCCNodeChildren(JToken ccNodeParent, JsonResetInfo resetInfo)
        {
            JToken options = ccNodeParent[EnumAttriType.options];
            //JToken fileData = options[enumAttriType.fileNameData];
            //if (fileData == null)
            //{
            //    fileData = options[enumAttriType.backGroundImageData];
            //}

            //修复数据
            List<string> keyList = EnumAttriType.getImageKeyList();
            foreach (var str in keyList)
            {
                JToken fileData = options[str];
                fixData(fileData, resetInfo);
            }


            foreach (JToken ccNode in ccNodeParent[EnumAttriType.children])
            {
                checkCCNodeChildren(ccNode, resetInfo);
            }
        }

        private void fixData(JToken data, JsonResetInfo resetInfo)
        {
            if (data != null && data.HasValues == true)
            {
                if (data[EnumAttriType.path].ToString() == "")
                {
                    return;
                }

                //图片路径(单图是相对fullName,碎图是name)
                string path = data[EnumAttriType.path].ToString();

                //获取图片name
                int lastIndex = path.LastIndexOf(@"/");
                string name = path.Substring(lastIndex + 1);

                //有真实图片
                if (dictImgInfo.ContainsKey(name) == true)
                {
                    ImgInfo imgInfo = dictImgInfo[name];

                    //单图
                    if (imgInfo.plist == null)
                    {
                        data[EnumAttriType.path] = (imgInfo.path + "/" + imgInfo.name).Replace(this.dealImagePath + "/", "");
                        data[EnumAttriType.plistFile] = "";

                        //记录到单图列表
                        resetInfo.addSingleImage(data[EnumAttriType.path].ToString());
                    }
                    //碎图
                    else
                    {
                        data[EnumAttriType.path] = imgInfo.name;
                        data[EnumAttriType.plistFile] = imgInfo.plist.Replace(this.dealImagePath + "/", "");

                        

                        //记录到plist列表
                        resetInfo.addPlist(data[EnumAttriType.plistFile].ToString());
                    }
                }
                //没真实图片
                else
                {
                    data[EnumAttriType.path] = "ui/daitu.png";//图片设置为daitu.png
                    data[EnumAttriType.plistFile] = "";//plistFile设置为""

                    //记录到单图列表
                    resetInfo.addSingleImage(data[EnumAttriType.path].ToString());
                }
            }
        }
    }

    
    
    
    
}
