namespace FindSpriteFrame
{
    partial class FormFindSprite
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrameName = new System.Windows.Forms.TextBox();
            this.btnFindImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "FrameName";
            // 
            // txtFrameName
            // 
            this.txtFrameName.Location = new System.Drawing.Point(91, 62);
            this.txtFrameName.Name = "txtFrameName";
            this.txtFrameName.Size = new System.Drawing.Size(356, 21);
            this.txtFrameName.TabIndex = 3;
            // 
            // btnFindImage
            // 
            this.btnFindImage.Location = new System.Drawing.Point(453, 61);
            this.btnFindImage.Name = "btnFindImage";
            this.btnFindImage.Size = new System.Drawing.Size(171, 23);
            this.btnFindImage.TabIndex = 5;
            this.btnFindImage.Text = "根据精灵帧名获取图片";
            this.btnFindImage.UseVisualStyleBackColor = true;
            this.btnFindImage.Click += new System.EventHandler(this.btnFindImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "findRootPath";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(109, 22);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(515, 21);
            this.txtRootPath.TabIndex = 7;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 104);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(857, 236);
            this.txtLog.TabIndex = 8;
            this.txtLog.WordWrap = false;
            // 
            // FormFindSprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 340);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFindImage);
            this.Controls.Add(this.txtFrameName);
            this.Controls.Add(this.label2);
            this.Name = "FormFindSprite";
            this.Text = "图片查找";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrameName;
        private System.Windows.Forms.Button btnFindImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.TextBox txtLog;
    }
}

