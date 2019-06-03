namespace CourseQuality
{
    partial class NewGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGroupForm));
            this.groupNameBox = new System.Windows.Forms.TextBox();
            this.generatePasswords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addFieldsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.deleteFieldsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupNameBox
            // 
            this.groupNameBox.Location = new System.Drawing.Point(143, 21);
            this.groupNameBox.MaxLength = 50;
            this.groupNameBox.Name = "groupNameBox";
            this.groupNameBox.Size = new System.Drawing.Size(100, 20);
            this.groupNameBox.TabIndex = 0;
            // 
            // generatePasswords
            // 
            this.generatePasswords.Location = new System.Drawing.Point(265, 5);
            this.generatePasswords.Name = "generatePasswords";
            this.generatePasswords.Size = new System.Drawing.Size(105, 36);
            this.generatePasswords.TabIndex = 3;
            this.generatePasswords.Text = "Згенерувати паролi";
            this.generatePasswords.UseVisualStyleBackColor = true;
            this.generatePasswords.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Назва групи:";
            // 
            // addFieldsButton
            // 
            this.addFieldsButton.Location = new System.Drawing.Point(5, 47);
            this.addFieldsButton.Name = "addFieldsButton";
            this.addFieldsButton.Size = new System.Drawing.Size(25, 25);
            this.addFieldsButton.TabIndex = 9;
            this.addFieldsButton.Text = "+";
            this.addFieldsButton.UseVisualStyleBackColor = true;
            this.addFieldsButton.Click += new System.EventHandler(this.addFieldsButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 309);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // deleteFieldsButton
            // 
            this.deleteFieldsButton.Location = new System.Drawing.Point(5, 78);
            this.deleteFieldsButton.Name = "deleteFieldsButton";
            this.deleteFieldsButton.Size = new System.Drawing.Size(25, 25);
            this.deleteFieldsButton.TabIndex = 11;
            this.deleteFieldsButton.Text = "-";
            this.deleteFieldsButton.UseVisualStyleBackColor = true;
            this.deleteFieldsButton.Click += new System.EventHandler(this.deleteFieldsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Застосувати змiни";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Створити список групи";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 410);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteFieldsButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.addFieldsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generatePasswords);
            this.Controls.Add(this.groupNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нова група";
            this.Load += new System.EventHandler(this.NewGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox groupNameBox;
        private System.Windows.Forms.Button generatePasswords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addFieldsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button deleteFieldsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}