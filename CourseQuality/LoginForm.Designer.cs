namespace CourseQuality
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginEnterButton = new System.Windows.Forms.Button();
            this.loginCloseButton = new System.Windows.Forms.Button();
            this.modeGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.modeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 11);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(16, 14);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(37, 13);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Логiн:";
            this.loginLabel.Click += new System.EventHandler(this.loginLabel_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(16, 40);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(48, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Пароль:";
            this.passwordLabel.Click += new System.EventHandler(this.passwordLabel_Click);
            // 
            // loginEnterButton
            // 
            this.loginEnterButton.Location = new System.Drawing.Point(12, 63);
            this.loginEnterButton.Name = "loginEnterButton";
            this.loginEnterButton.Size = new System.Drawing.Size(75, 23);
            this.loginEnterButton.TabIndex = 4;
            this.loginEnterButton.Text = "Увійти";
            this.loginEnterButton.UseVisualStyleBackColor = true;
            this.loginEnterButton.Click += new System.EventHandler(this.loginEnterButton_Click);
            // 
            // loginCloseButton
            // 
            this.loginCloseButton.Location = new System.Drawing.Point(106, 63);
            this.loginCloseButton.Name = "loginCloseButton";
            this.loginCloseButton.Size = new System.Drawing.Size(75, 23);
            this.loginCloseButton.TabIndex = 5;
            this.loginCloseButton.Text = "Вихід";
            this.loginCloseButton.UseVisualStyleBackColor = true;
            this.loginCloseButton.Click += new System.EventHandler(this.loginCloseButton_Click);
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.radioButton3);
            this.modeGroupBox.Controls.Add(this.radioButton2);
            this.modeGroupBox.Controls.Add(this.radioButton1);
            this.modeGroupBox.Location = new System.Drawing.Point(187, 1);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Size = new System.Drawing.Size(167, 90);
            this.modeGroupBox.TabIndex = 6;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Режим:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 62);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(151, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Адміністратор (ректорат)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(146, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Адміністратор (деканат)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Студент";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 89);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://qa.khnu.km.ua";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 111);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.modeGroupBox);
            this.Controls.Add(this.loginCloseButton);
            this.Controls.Add(this.loginEnterButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизація";
            this.modeGroupBox.ResumeLayout(false);
            this.modeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginEnterButton;
        private System.Windows.Forms.Button loginCloseButton;
        private System.Windows.Forms.GroupBox modeGroupBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

