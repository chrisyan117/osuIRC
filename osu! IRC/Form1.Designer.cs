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
            this.SuspendLayout();
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.richTextBoxMessage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBoxMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBoxMessage.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new System.Drawing.Size(592, 308);
            this.richTextBoxMessage.TabIndex = 3;
            this.richTextBoxMessage.TabStop = false;
            this.richTextBoxMessage.Text = "";
            this.richTextBoxMessage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxMessage.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.textBoxMessage.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxMessage.Location = new System.Drawing.Point(132, 331);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(528, 29);
            this.textBoxMessage.TabIndex = 5;
            this.textBoxMessage.Visible = false;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBoxSendTo
            // 
            this.textBoxSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSendTo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxSendTo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textBoxSendTo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSendTo.Location = new System.Drawing.Point(12, 332);
            this.textBoxSendTo.Name = "textBoxSendTo";
            this.textBoxSendTo.Size = new System.Drawing.Size(114, 27);
            this.textBoxSendTo.TabIndex = 4;
            this.textBoxSendTo.Visible = false;
            this.textBoxSendTo.TextChanged += new System.EventHandler(this.textBoxSendTo_TextChanged);
            // 
            // listBoxTargetList
            // 
            this.listBoxTargetList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTargetList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.listBoxTargetList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTargetList.ForeColor = System.Drawing.SystemColors.Window;
            this.listBoxTargetList.FormattingEnabled = true;
            this.listBoxTargetList.ItemHeight = 16;
            this.listBoxTargetList.Location = new System.Drawing.Point(610, 28);
            this.listBoxTargetList.Name = "listBoxTargetList";
            this.listBoxTargetList.Size = new System.Drawing.Size(108, 292);
            this.listBoxTargetList.TabIndex = 7;
            this.listBoxTargetList.Visible = false;
            this.listBoxTargetList.SelectedValueChanged += new System.EventHandler(this.listBoxOnlineUser_SelectedValueChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.Location = new System.Drawing.Point(516, 282);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxIRCPassword
            // 
            this.textBoxIRCPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIRCPassword.Location = new System.Drawing.Point(464, 254);
            this.textBoxIRCPassword.Name = "textBoxIRCPassword";
            this.textBoxIRCPassword.PasswordChar = '●';
            this.textBoxIRCPassword.Size = new System.Drawing.Size(127, 22);
            this.textBoxIRCPassword.TabIndex = 0;
            this.textBoxIRCPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIRCPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(387, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "IRC Password";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendMessage.Location = new System.Drawing.Point(666, 332);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(52, 23);
            this.buttonSendMessage.TabIndex = 6;
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
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.checkBoxRememberPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(389, 286);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(121, 16);
            this.checkBoxRememberPassword.TabIndex = 1;
            this.checkBoxRememberPassword.Text = "Remember Password";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = false;
            this.checkBoxRememberPassword.CheckedChanged += new System.EventHandler(this.checkBoxRememberPassword_CheckedChanged);
            // 
            // labelPing
            // 
            this.labelPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPing.AutoSize = true;
            this.labelPing.Location = new System.Drawing.Point(610, 9);
            this.labelPing.Name = "labelPing";
            this.labelPing.Size = new System.Drawing.Size(0, 12);
            this.labelPing.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(730, 367);
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
            this.MinimumSize = new System.Drawing.Size(390, 350);
            this.Name = "Form1";
            this.Text = " osu! IRC Beta v1.0.11";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

