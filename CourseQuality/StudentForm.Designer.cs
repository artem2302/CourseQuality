namespace CourseQuality
{
    partial class StudentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.coursesListBox = new System.Windows.Forms.ListBox();
            this.coursesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDataSet = new CourseQuality.MainDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.selectCourseButton = new System.Windows.Forms.Button();
            this.coursesTableAdapter = new CourseQuality.MainDataSetTableAdapters.coursesTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.tutorTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.applyPasswordButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oldPasswordBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // coursesListBox
            // 
            this.coursesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.coursesListBox.FormattingEnabled = true;
            this.coursesListBox.HorizontalScrollbar = true;
            this.coursesListBox.Location = new System.Drawing.Point(1, 16);
            this.coursesListBox.Name = "coursesListBox";
            this.coursesListBox.Size = new System.Drawing.Size(239, 277);
            this.coursesListBox.TabIndex = 0;
            this.coursesListBox.Click += new System.EventHandler(this.coursesListBox_Click);
            this.coursesListBox.SelectedIndexChanged += new System.EventHandler(this.coursesListBox_SelectedIndexChanged);
            // 
            // coursesBindingSource
            // 
            this.coursesBindingSource.DataMember = "courses";
            this.coursesBindingSource.DataSource = this.mainDataSet;
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оберіть курс для оцінювання:";
            // 
            // selectCourseButton
            // 
            this.selectCourseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectCourseButton.Location = new System.Drawing.Point(92, 322);
            this.selectCourseButton.Name = "selectCourseButton";
            this.selectCourseButton.Size = new System.Drawing.Size(75, 23);
            this.selectCourseButton.TabIndex = 2;
            this.selectCourseButton.Text = "Обрати";
            this.selectCourseButton.UseVisualStyleBackColor = true;
            this.selectCourseButton.Click += new System.EventHandler(this.selectCourseButton_Click);
            // 
            // coursesTableAdapter
            // 
            this.coursesTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Викладач:";
            // 
            // tutorTextBox
            // 
            this.tutorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tutorTextBox.Location = new System.Drawing.Point(62, 296);
            this.tutorTextBox.Name = "tutorTextBox";
            this.tutorTextBox.ReadOnly = true;
            this.tutorTextBox.Size = new System.Drawing.Size(178, 20);
            this.tutorTextBox.TabIndex = 4;
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(346, 57);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.PasswordChar = '•';
            this.newPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordBox.TabIndex = 12;
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(346, 81);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.PasswordChar = '•';
            this.confirmPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.confirmPasswordBox.TabIndex = 13;
            // 
            // applyPasswordButton
            // 
            this.applyPasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.applyPasswordButton.Location = new System.Drawing.Point(328, 107);
            this.applyPasswordButton.Name = "applyPasswordButton";
            this.applyPasswordButton.Size = new System.Drawing.Size(75, 23);
            this.applyPasswordButton.TabIndex = 14;
            this.applyPasswordButton.Text = "ОК";
            this.applyPasswordButton.UseVisualStyleBackColor = true;
            this.applyPasswordButton.Click += new System.EventHandler(this.applyPasswordButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Змiнити пароль:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Новий пароль:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Повторiть пароль:";
            // 
            // oldPasswordBox
            // 
            this.oldPasswordBox.Location = new System.Drawing.Point(346, 33);
            this.oldPasswordBox.Name = "oldPasswordBox";
            this.oldPasswordBox.PasswordChar = '•';
            this.oldPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.oldPasswordBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Старий пароль:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 349);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.oldPasswordBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applyPasswordButton);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.tutorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectCourseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coursesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вибір курса";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentForm_FormClosed);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox coursesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectCourseButton;
        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource coursesBindingSource;
        private MainDataSetTableAdapters.coursesTableAdapter coursesTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tutorTextBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.Button applyPasswordButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox oldPasswordBox;
        private System.Windows.Forms.Label label6;
    }
}