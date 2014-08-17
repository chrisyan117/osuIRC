namespace osu__IRC
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxSendTo = new System.Windows.Forms.TextBox();
            this.listBoxTargetList = new System.Windows.Forms.ListBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxIRCPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.sendMessageCooldownTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.labelPing = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.richTextBoxMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.richTextBoxMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.richTextBoxMessage.Location = new System.Drawing.Point(12, 31);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new System.Drawing.Size(826, 293);
            this.richTextBoxMessage.TabIndex = 3;
            this.richTextBoxMessage.TabStop = false;
            this.richTextBoxMessage.Text = "";
            this.richTextBoxMessage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.textBoxMessage.ForeColor = System.Drawing.Color.White;
            this.textBoxMessage.Location = new System.Drawing.Point(132, 335);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(762, 28);
            this.textBoxMessage.TabIndex = 5;
            this.textBoxMessage.Visible = false;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBoxSendTo
            // 
            this.textBoxSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSendTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBoxSendTo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.textBoxSendTo.ForeColor = System.Drawing.Color.White;
            this.textBoxSendTo.Location = new System.Drawing.Point(12, 335);
            this.textBoxSendTo.Name = "textBoxSendTo";
            this.textBoxSendTo.Size = new System.Drawing.Size(114, 28);
            this.textBoxSendTo.TabIndex = 4;
            this.textBoxSendTo.Visible = false;
            this.textBoxSendTo.TextChanged += new System.EventHandler(this.textBoxSendTo_TextChanged);
            // 
            // listBoxTargetList
            // 
            this.listBoxTargetList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTargetList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.listBoxTargetList.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.listBoxTargetList.ForeColor = System.Drawing.Color.White;
            this.listBoxTargetList.FormattingEnabled = true;
            this.listBoxTargetList.ItemHeight = 16;
            this.listBoxTargetList.Location = new System.Drawing.Point(844, 48);
            this.listBoxTargetList.Name = "listBoxTargetList";
            this.listBoxTargetList.Size = new System.Drawing.Size(108, 276);
            this.listBoxTargetList.TabIndex = 7;
            this.listBoxTargetList.TabStop = false;
            this.listBoxTargetList.Visible = false;
            this.listBoxTargetList.SelectedValueChanged += new System.EventHandler(this.listBoxOnlineUser_SelectedValueChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonLogin.Location = new System.Drawing.Point(736, 280);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(61, 30);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxIRCPassword
            // 
            this.textBoxIRCPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIRCPassword.BackColor = System.Drawing.Color.White;
            this.textBoxIRCPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.textBoxIRCPassword.Location = new System.Drawing.Point(698, 217);
            this.textBoxIRCPassword.Name = "textBoxIRCPassword";
            this.textBoxIRCPassword.PasswordChar = '●';
            this.textBoxIRCPassword.Size = new System.Drawing.Size(127, 24);
            this.textBoxIRCPassword.TabIndex = 0;
            this.textBoxIRCPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIRCPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(586, 220);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "IRC Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSendMessage.Location = new System.Drawing.Point(900, 335);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(52, 28);
            this.buttonSendMessage.TabIndex = 6;
            this.buttonSendMessage.TabStop = false;
            this.buttonSendMessage.Text = "Send";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Visible = false;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // sendMessageCooldownTimer
            // 
            this.sendMessageCooldownTimer.Enabled = true;
            this.sendMessageCooldownTimer.Interval = 1000;
            this.sendMessageCooldownTimer.Tick += new System.EventHandler(this.sendMessageCooldownTimer_Tick);
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRememberPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.checkBoxRememberPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRememberPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBoxRememberPassword.ForeColor = System.Drawing.Color.White;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(657, 250);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(168, 24);
            this.checkBoxRememberPassword.TabIndex = 1;
            this.checkBoxRememberPassword.Text = "Remember Password";
            this.checkBoxRememberPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRememberPassword.UseVisualStyleBackColor = false;
            this.checkBoxRememberPassword.CheckedChanged += new System.EventHandler(this.checkBoxRememberPassword_CheckedChanged);
            // 
            // labelPing
            // 
            this.labelPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPing.AutoSize = true;
            this.labelPing.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPing.Location = new System.Drawing.Point(847, 27);
            this.labelPing.Name = "labelPing";
            this.labelPing.Size = new System.Drawing.Size(0, 20);
            this.labelPing.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.channelsToolStripMenuItem.Text = "Channels";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(964, 375);
            this.Controls.Add(this.labelPing);
            this.Controls.Add(this.checkBoxRememberPassword);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIRCPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.listBoxTargetList);
            this.Controls.Add(this.textBoxSendTo);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(390, 350);
            this.Name = "Form1";
            this.Text = " osu! IRC Beta v1.0.13a";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxSendTo;
        private System.Windows.Forms.ListBox listBoxTargetList;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxIRCPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Timer sendMessageCooldownTimer;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
        private System.Windows.Forms.Label labelPing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    }
}

