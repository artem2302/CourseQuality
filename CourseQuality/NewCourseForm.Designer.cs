namespace CourseQuality
{
    partial class NewCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCourseForm));
            this.newCourseNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveNewCourseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newCourseNameBox
            // 
            this.newCourseNameBox.Location = new System.Drawing.Point(78, 8);
            this.newCourseNameBox.Name = "newCourseNameBox";
            this.newCourseNameBox.Size = new System.Drawing.Size(100, 20);
            this.newCourseNameBox.TabIndex = 0;
            this.newCourseNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newCourseNameBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Назва курсу:";
            // 
            // saveNewCourseButton
            // 
            this.saveNewCourseButton.Location = new System.Drawing.Point(12, 34);
            this.saveNewCourseButton.Name = "saveNewCourseButton";
            this.saveNewCourseButton.Size = new System.Drawing.Size(75, 23);
            this.saveNewCourseButton.TabIndex = 2;
            this.saveNewCourseButton.Text = "Зберегти";
            this.saveNewCourseButton.UseVisualStyleBackColor = true;
            this.saveNewCourseButton.Click += new System.EventHandler(this.saveNewCourseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(103, 34);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Вiдмiна";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // NewCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 64);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveNewCourseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newCourseNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новий курс";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newCourseNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveNewCourseButton;
        private System.Windows.Forms.Button cancelButton;
    }
}