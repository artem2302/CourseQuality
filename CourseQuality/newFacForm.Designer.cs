namespace CourseQuality
{
    partial class newFacForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newFacForm));
            this.label1 = new System.Windows.Forms.Label();
            this.facNameBoxC = new System.Windows.Forms.TextBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва:";
            // 
            // facNameBoxC
            // 
            this.facNameBoxC.Location = new System.Drawing.Point(12, 22);
            this.facNameBoxC.Name = "facNameBoxC";
            this.facNameBoxC.Size = new System.Drawing.Size(218, 20);
            this.facNameBoxC.TabIndex = 1;
            this.facNameBoxC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.facNameBoxC_KeyPress);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(86, 48);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(75, 23);
            this.saveChangesButton.TabIndex = 2;
            this.saveChangesButton.Text = "Додати";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // newFacForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 79);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.facNameBoxC);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "newFacForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новий факультет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox facNameBoxC;
        private System.Windows.Forms.Button saveChangesButton;
    }
}