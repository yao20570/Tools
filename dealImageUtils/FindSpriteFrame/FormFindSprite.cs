using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dealImage.utils;
using System.IO;
using dealImage.CommonEnum;
using System.Xml;
using dealImage.CommonObj;
using Newtonsoft.Json;

namespace FindSpriteFrame
{
    public partial class FormFindSprite : Form
    {
        public delegate void delegateAddLog(string str);
        public List<FindInfo> resultlist = new List<FindInfo>();
        public string strFindRootPath = "";
        public FormFindSprite()
        {
            InitializeComponent();

            setDefaultDir();

            LogUtils.onWriteLog += onWriteLog;
        }

        public void onWriteLog(string strLog)
        {
            string str = strLog + "\r\n";
            //this.BeginInvoke(new AddLog(this.txtLog.AppendText), str);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new delegateAddLog(this.txtLog.AppendText), str);
            }
            else
            {
                this.txtLog.AppendText(str);
            }
        }

        public void setDefaultDir()
        {
            string curPath = System.IO.Directory.GetCurrentDirectory();
            JObject jsonObj = JsonUtils.getJsonObjFromJsonFile(Path.Combine(curPath, "config.json"));
            string imageRelativePath = jsonObj["ImageRelativePath"].ToString();
            strFindRootPath = Path.Combine(curPath, imageRelativePath);
            this.txtRootPath.Text = strFindRootPath;
        }

        public void resetFind()
        {
            txtLog.Clear();
            this.resultlist.Clear();
        }
                
        private void btnFindImage_Click(object sender, EventArgs e)
        {
            resetFind();
            
            FileUtils.TraverseFolders(strFindRootPath, new delegateDealFile(findFrame));

            foreach (var item in this.resultlist)
            {
                string log = string.Format("图片:{0} ====> 精灵帧:{1}", item.imageName, item.frameName);
                LogUtils.WriteLine(log);
            }
        }
        private void findFrame(FileInfo file)
        {
            if (file.Extension == EnumFileType.plist)
            {
                try
                {
                    XmlDocument doc = XmlUtils.getXmlFromFile(file.FullName);

                    XmlNode node1 = doc.ChildNodes[2]; //plist
                    XmlNode node2 = node1.ChildNodes[0];//dict

                    XmlNode nodeImageName = node2.ChildNodes[3].ChildNodes[3];

                    XmlNode node3 = node2.ChildNodes[1];//dict
                    foreach (XmlNode node in node3.ChildNodes)
                    {
                        if (node.Name == "key")
                        {
                            if (node.InnerText.IndexOf(this.txtFrameName.Text) > 0)
                            {
                                FindInfo reslut = new FindInfo();
                                reslut.frameName = node.InnerText;
                                reslut.imageName = Path.Combine(file.Directory.FullName, nodeImageName.InnerText);
                                resultlist.Add(reslut);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //存储失败
                    //LogUtils.WriteLine(@"读取plist文件失败===>{0}", file.FullName);
                }
            }
        }
    }

    public class FindInfo
    {
        public string imageName;
        public string frameName;
    }

}
