namespace dealImage
{
    partial class FixJosnFile
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOneKey = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtImgDir = new System.Windows.Forms.TextBox();
            this.txtUIDir = new System.Windows.Forms.TextBox();
            this.txtParseToolDir = new System.Windows.Forms.TextBox();
            this.txtProjectUIDir = new System.Windows.Forms.TextBox();
            this.btnCheckImg = new System.Windows.Forms.Button();
            this.btnFixJson = new System.Windows.Forms.Button();
            this.btnParseJson = new System.Windows.Forms.Button();
            this.btnCopy2Project = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnFind = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOneKey
            // 
            this.btnOneKey.Location = new System.Drawing.Point(100, 41);
            this.btnOneKey.Name = "btnOneKey";
            this.btnOneKey.Size = new System.Drawing.Size(75, 23);
            this.btnOneKey.TabIndex = 0;
            this.btnOneKey.Text = "一键处理";
            this.btnOneKey.UseVisualStyleBackColor = true;
            this.btnOneKey.Click += new System.EventHandler(this.btnOneKey_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 158);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(967, 550);
            this.txtLog.TabIndex = 1;
            this.txtLog.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图片目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ui工程目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "json2lua工具目录";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "项目的uiLua目录";
            // 
            // txtImgDir
            // 
            this.txtImgDir.Enabled = false;
            this.txtImgDir.Location = new System.Drawing.Point(114, 19);
            this.txtImgDir.Name = "txtImgDir";
            this.txtImgDir.Size = new System.Drawing.Size(660, 21);
            this.txtImgDir.TabIndex = 6;
            // 
            // txtUIDir
            // 
            this.txtUIDir.Enabled = false;
            this.txtUIDir.Location = new System.Drawing.Point(114, 44);
            this.txtUIDir.Name = "txtUIDir";
            this.txtUIDir.Size = new System.Drawing.Size(300, 21);
            this.txtUIDir.TabIndex = 7;
            // 
            // txtParseToolDir
            // 
            this.txtParseToolDir.Enabled = false;
            this.txtParseToolDir.Location = new System.Drawing.Point(114, 71);
            this.txtParseToolDir.Name = "txtParseToolDir";
            this.txtParseToolDir.Size = new System.Drawing.Size(660, 21);
            this.txtParseToolDir.TabIndex = 8;
            // 
            // txtProjectUIDir
            // 
            this.txtProjectUIDir.Enabled = false;
            this.txtProjectUIDir.Location = new System.Drawing.Point(114, 97);
            this.txtProjectUIDir.Name = "txtProjectUIDir";
            this.txtProjectUIDir.Size = new System.Drawing.Size(660, 21);
            this.txtProjectUIDir.TabIndex = 9;
            // 
            // btnCheckImg
            // 
            this.btnCheckImg.Location = new System.Drawing.Point(6, 9);
            this.btnCheckImg.Name = "btnCheckImg";
            this.btnCheckImg.Size = new System.Drawing.Size(75, 23);
            this.btnCheckImg.TabIndex = 10;
            this.btnCheckImg.Text = "检测图片";
            this.btnCheckImg.UseVisualStyleBackColor = true;
            this.btnCheckImg.Click += new System.EventHandler(this.btnCheckImg_Click);
            // 
            // btnFixJson
            // 
            this.btnFixJson.Location = new System.Drawing.Point(6, 34);
            this.btnFixJson.Name = "btnFixJson";
            this.btnFixJson.Size = new System.Drawing.Size(75, 23);
            this.btnFixJson.TabIndex = 11;
            this.btnFixJson.Text = "修复json";
            this.btnFixJson.UseVisualStyleBackColor = true;
            this.btnFixJson.Click += new System.EventHandler(this.btnFixJson_Click);
            // 
            // btnParseJson
            // 
            this.btnParseJson.Location = new System.Drawing.Point(6, 59);
            this.btnParseJson.Name = "btnParseJson";
            this.btnParseJson.Size = new System.Drawing.Size(75, 23);
            this.btnParseJson.TabIndex = 12;
            this.btnParseJson.Text = "转成lua";
            this.btnParseJson.UseVisualStyleBackColor = true;
            this.btnParseJson.Click += new System.EventHandler(this.btnParseJson_Click);
            // 
            // btnCopy2Project
            // 
            this.btnCopy2Project.Location = new System.Drawing.Point(6, 84);
            this.btnCopy2Project.Name = "btnCopy2Project";
            this.btnCopy2Project.Size = new System.Drawing.Size(75, 23);
            this.btnCopy2Project.TabIndex = 13;
            this.btnCopy2Project.Text = "拷贝到工程";
            this.btnCopy2Project.UseVisualStyleBackColor = true;
            this.btnCopy2Project.Click += new System.EventHandler(this.btnCopy2Project_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(420, 44);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(98, 21);
            this.txtProjectName.TabIndex = 14;
            this.txtProjectName.Text = "输入UI工程名称";
            this.txtProjectName.Enter += new System.EventHandler(this.txtProjectName_Enter);
            this.txtProjectName.Leave += new System.EventHandler(this.txtProjectName_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(791, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(189, 140);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOneKey);
            this.tabPage1.Controls.Add(this.btnCheckImg);
            this.tabPage1.Controls.Add(this.btnCopy2Project);
            this.tabPage1.Controls.Add(this.btnFixJson);
            this.tabPage1.Controls.Add(this.btnParseJson);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(181, 114);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图片修复";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnFind);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(181, 114);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查找重名";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(57, 41);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 720);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.txtProjectUIDir);
            this.Controls.Add(this.txtParseToolDir);
            this.Controls.Add(this.txtUIDir);
            this.Controls.Add(this.txtImgDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "根据图片修正Json文件";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOneKey;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.TextBox txtImgDir;
        private System.Windows.Forms.TextBox txtUIDir;
        private System.Windows.Forms.TextBox txtParseToolDir;
        private System.Windows.Forms.TextBox txtProjectUIDir;
        private System.Windows.Forms.Button btnCheckImg;
        private System.Windows.Forms.Button btnFixJson;
        private System.Windows.Forms.Button btnParseJson;
        private System.Windows.Forms.Button btnCopy2Project;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnFind;
    }
}

