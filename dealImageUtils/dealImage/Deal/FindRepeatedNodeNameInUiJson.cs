using dealImage.CommonEnum;
using dealImage.utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dealImage.Deal
{
    class FindRepeatedNodeNameInUiJson
    {
        private string dealUiJsonPath = "";



        public void traverseUiJsonToFindRepeatedName(string path)
        {
            this.dealUiJsonPath = path;

            LogUtils.WriteLine("\n\n遍历文件夹，查找json文件里的同名节点");
            

            //遍历文件夹，处理ui的json文件
            FileUtils.TraverseFolders(path, new delegateDealFile(findRepeatedNodeName));

            LogUtils.WriteLine("\n\njson文件节点查找完毕\n\n");
        }

        private void findRepeatedNodeName(FileInfo file)
        {
            if (file.Extension != EnumFileType.json)
            {
                return;
            }


            HashSet<string> nameSet = new HashSet<string>();

            List<string> repeatNameList = new List<string>();

            JObject jsonObj = JsonUtils.getJsonObjFromJsonFile(file.FullName);
            
            //递归遍历cocos2d的节点树
            JToken ccNodeRoot = jsonObj.GetValue(EnumAttriType.widgetTree);
            checkCCNodeChildren(ccNodeRoot, nameSet, repeatNameList);

            if (repeatNameList.Count > 0)
            {
                foreach (string name in repeatNameList) 
                {
                    string strLog = file.Name + "====>" + name;
                    LogUtils.onWriteLog(strLog);
                }
            }
        }

        private void checkCCNodeChildren(JToken ccNodeParent, HashSet<string> nameSet, List<string> repeatNameList)
        {
            JToken options = ccNodeParent[EnumAttriType.options];
            string name = options["name"].ToString();

            if (nameSet.Contains(name))
            {
                repeatNameList.Add(name);
            }
            else
            {
                nameSet.Add(name);
            }

            foreach (JToken ccNode in ccNodeParent[EnumAttriType.children])
            {
                checkCCNodeChildren(ccNode, nameSet, repeatNameList);
            }
        }
    }


    

    
}
