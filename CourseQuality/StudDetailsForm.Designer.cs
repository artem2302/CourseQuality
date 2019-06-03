namespace CourseQuality
{
    partial class StudDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudDetailsForm));
            this.answersListBox = new System.Windows.Forms.ListBox();
            this.respondentsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.respondentTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // answersListBox
            // 
            this.answersListBox.FormattingEnabled = true;
            this.answersListBox.Location = new System.Drawing.Point(12, 21);
            this.answersListBox.Name = "answersListBox";
            this.answersListBox.Size = new System.Drawing.Size(211, 264);
            this.answersListBox.TabIndex = 0;
            this.answersListBox.SelectedIndexChanged += new System.EventHandler(this.answersListBox_SelectedIndexChanged);
            // 
            // respondentsListBox
            // 
            this.respondentsListBox.FormattingEnabled = true;
            this.respondentsListBox.Location = new System.Drawing.Point(232, 21);
            this.respondentsListBox.Name = "respondentsListBox";
            this.respondentsListBox.Size = new System.Drawing.Size(142, 238);
            this.respondentsListBox.TabIndex = 1;
            this.respondentsListBox.SelectedIndexChanged += new System.EventHandler(this.respondentsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Варiант вiдповiдi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Респонденти:";
            // 
            // respondentTextBox
            // 
            this.respondentTextBox.Location = new System.Drawing.Point(274, 268);
            this.respondentTextBox.Name = "respondentTextBox";
            this.respondentTextBox.ReadOnly = true;
            this.respondentTextBox.Size = new System.Drawing.Size(100, 20);
            this.respondentTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Група:";
            // 
            // StudDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 299);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.respondentTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.respondentsListBox);
            this.Controls.Add(this.answersListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Респонденти";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox answersListBox;
        private System.Windows.Forms.ListBox respondentsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox respondentTextBox;
        private System.Windows.Forms.Label label3;
    }
}