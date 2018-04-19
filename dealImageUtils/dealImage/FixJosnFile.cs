using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using dealImage.utils;
using System.IO;
using Newtonsoft.Json.Linq;
using dealImage.Deal;

namespace dealImage
{

    public partial class FixJosnFile : Form
    {
        public delegate void AddLog(string str);


        private FindRepeatedNodeNameInUiJson findRepeatUtils = new FindRepeatedNodeNameInUiJson();

        private DealUtils deal = new DealUtils();

        bool textboxHasText = false;//判断输入框是否有文本 

        public FixJosnFile()
        {
            InitializeComponent();

            LogUtils.onWriteLog += this.onWriteLog;

            setDefaultDir();

            setTxtProjectNameTip();
        }

        private void btnOneKey_Click(object sender, EventArgs e)
        {
            MessageBox.Show("屏蔽了");
            return;

            setBtnEnable(false);

            this.txtLog.Text = "";

            //遍历资源，记录图片信息
            //deal.traverseImgSetInfo(@"D:\dev\pro\lua_code\lua__main\res");
            deal.traverseImgSetInfo(txtImgDir.Text);

            //遍历json文件，根据图片信息修复，并拷贝解析lua目录
            //deal.traverseUiJsonToFix(@"D:\dev\pro\uiproject\cn\beta_cur", @"D:\dev\pro\JsonToLuaUtil", txtProjectUIDir.Text);
            deal.traverseUiJsonToFix(txtUIDir.Text, txtParseToolDir.Text, txtProjectUIDir.Text);

            //调用java解析工具，将json解析为lua
            //deal.callParseTool(@"D:\dev\pro\JsonToLuaUtil");
            deal.callParseTool(txtParseToolDir.Text);

            //将lua文件拷贝到项目工程
            //deal.copyLuaFile2ProjectResFloder(@"D:\dev\pro\JsonToLuaUtil", @"D:\dev\pro\lua_code\lua__main\src\app\jsontolua");
            deal.copyLuaFile2ProjectResFloder(txtParseToolDir.Text, txtProjectUIDir.Text);

            setBtnEnable(true);
        }

        public void onWriteLog(string strLog)
        {
            string str = strLog + "\r\n";
            //this.BeginInvoke(new AddLog(this.txtLog.AppendText), str);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new AddLog(this.txtLog.AppendText), str);
            }
            else
            {
                this.txtLog.AppendText(str);
            }
        }

        public void setDefaultDir()
        {
            string curPath = System.IO.Directory.GetCurrentDirectory();

            JObject jsonObj= JsonUtils.getJsonObjFromJsonFile(Path.Combine(curPath, "config.json"));
            string imageRelativePath = jsonObj["ImageRelativePath"].ToString();
            string UiJsonRelativePath = jsonObj["UiJsonRelativePath"].ToString();
            string ParseToolRelativePath = jsonObj["ParseToolRelativePath"].ToString();
            string ProjectUiLuaFileRelativePath = jsonObj["ProjectUiLuaFileRelativePath"].ToString();

            //string strImgDir = Path.Combine(curPath, imageRelativePath);
            //string strUIDir = Path.Combine(curPath, UiJsonRelativePath);
            //string strParseToolDir = Path.Combine(curPath, ParseToolRelativePath);
            //string strProjectUIDir = Path.Combine(curPath, ProjectUiLuaFileRelativePath);

            //Dictionary<string, TextBox> dictDir = new Dictionary<string, TextBox>();
            //dictDir[Path.Combine(curPath, imageRelativePath)] = txtImgDir;
            //dictDir[Path.Combine(curPath, UiJsonRelativePath)] = txtUIDir;
            //dictDir[Path.Combine(curPath, ParseToolRelativePath)] = txtParseToolDir;
            //dictDir[Path.Combine(curPath, ProjectUiLuaFileRelativePath)] = txtProjectUIDir;


            //foreach(var item in dictDir)
            //{
            //    DirectoryInfo folder = new DirectoryInfo(item.Key);
            //    if (folder.Exists)
            //    {
            //        item.Value.Text = folder.FullName;
            //    }
            //}
            txtImgDir.Text = imageRelativePath;
            txtUIDir.Text = UiJsonRelativePath;
            txtParseToolDir.Text = ParseToolRelativePath;
            txtProjectUIDir.Text = ProjectUiLuaFileRelativePath;
        }

        private void btnCheckImg_Click(object sender, EventArgs e)
        {
            setBtnEnable(false);
            deal.traverseImgSetInfo(txtImgDir.Text);
            setBtnEnable(true);
        }

        private void btnFixJson_Click(object sender, EventArgs e)
        {
            string uiUIDir = Path.Combine(txtUIDir.Text, txtProjectName.Text); 

            if (textboxHasText == false || txtProjectName.Text.Trim() == "")
            {
                DialogResult dr = MessageBox.Show("确定修复所有的UI工程?\n最好将所有的UI工程备份或提交到svn\n(注:输入UI工程名可以只修改一个)", "修改json提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    uiUIDir = txtUIDir.Text;
                }
            }

            fixJson(uiUIDir);            
        }

        private void fixJson(string uiUIDir)
        {
            
            if (Directory.Exists(uiUIDir) == false)
            {
                MessageBox.Show("ui工程不存在");
                return;
            }

            setBtnEnable(false);
            deal.traverseUiJsonToFix(uiUIDir, txtParseToolDir.Text, txtProjectUIDir.Text);
            setBtnEnable(true);
        }


        private void btnParseJson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("屏蔽了");
            return;

            setBtnEnable(false);
            deal.callParseTool(txtParseToolDir.Text);
            setBtnEnable(true);
        }

        private void btnCopy2Project_Click(object sender, EventArgs e)
        {
            MessageBox.Show("屏蔽了");
            return;

            setBtnEnable(false);
            deal.copyLuaFile2ProjectResFloder(txtParseToolDir.Text, txtProjectUIDir.Text);
            setBtnEnable(true);
        }

        private void setBtnEnable(bool isEnable)
        {
            btnCheckImg.Enabled = isEnable;
            btnFixJson.Enabled = isEnable;
            btnParseJson.Enabled = isEnable;
            btnCopy2Project.Enabled = isEnable;
            btnOneKey.Enabled = isEnable;
        }


        private void txtProjectName_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
            {
                txtProjectName.Text = "";
            }

            txtProjectName.ForeColor = Color.Black;
        }

        private void txtProjectName_Leave(object sender, EventArgs e)
        {
            if (txtProjectName.Text == "")
            {
                setTxtProjectNameTip();
            }
            else
            {
                textboxHasText = true;
            }                
        }

        private void setTxtProjectNameTip()
        {
            
                txtProjectName.Text = "输入UI工程名称";
                txtProjectName.ForeColor = Color.LightGray;
                textboxHasText = false;
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string findPath = txtUIDir.Text.Trim();
            findRepeatUtils.traverseUiJsonToFindRepeatedName(findPath);
        }
    }

}
