namespace CourseQuality
{
    partial class newStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newStudentForm));
            this.studentNameBox = new System.Windows.Forms.TextBox();
            this.idNumberBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generatePasswordButton = new System.Windows.Forms.Button();
            this.saveNewStudentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentNameBox
            // 
            this.studentNameBox.Location = new System.Drawing.Point(4, 21);
            this.studentNameBox.Name = "studentNameBox";
            this.studentNameBox.Size = new System.Drawing.Size(100, 20);
            this.studentNameBox.TabIndex = 0;
            // 
            // idNumberBox
            // 
            this.idNumberBox.Location = new System.Drawing.Point(110, 21);
            this.idNumberBox.Name = "idNumberBox";
            this.idNumberBox.Size = new System.Drawing.Size(100, 20);
            this.idNumberBox.TabIndex = 1;
            this.idNumberBox.TextChanged += new System.EventHandler(this.idNumberBox_TextChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(216, 21);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.ReadOnly = true;
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ПIБ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Студ. квиток:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль:";
            // 
            // generatePasswordButton
            // 
            this.generatePasswordButton.Location = new System.Drawing.Point(322, 2);
            this.generatePasswordButton.Name = "generatePasswordButton";
            this.generatePasswordButton.Size = new System.Drawing.Size(79, 39);
            this.generatePasswordButton.TabIndex = 6;
            this.generatePasswordButton.Text = "Згенерувати пароль";
            this.generatePasswordButton.UseVisualStyleBackColor = true;
            this.generatePasswordButton.Click += new System.EventHandler(this.generatePasswordButton_Click);
            // 
            // saveNewStudentButton
            // 
            this.saveNewStudentButton.Location = new System.Drawing.Point(166, 47);
            this.saveNewStudentButton.Name = "saveNewStudentButton";
            this.saveNewStudentButton.Size = new System.Drawing.Size(79, 37);
            this.saveNewStudentButton.TabIndex = 7;
            this.saveNewStudentButton.Text = "Зберегти";
            this.saveNewStudentButton.UseVisualStyleBackColor = true;
            this.saveNewStudentButton.Click += new System.EventHandler(this.saveNewStudentButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Скопiювати пароль";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 88);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveNewStudentButton);
            this.Controls.Add(this.generatePasswordButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.idNumberBox);
            this.Controls.Add(this.studentNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "newStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новий студент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentNameBox;
        private System.Windows.Forms.TextBox idNumberBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generatePasswordButton;
        private System.Windows.Forms.Button saveNewStudentButton;
        private System.Windows.Forms.Button button1;
    }
}