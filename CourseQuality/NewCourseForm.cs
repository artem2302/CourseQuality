using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseQuality
{
    public partial class NewCourseForm : Form
    {
        private int tut_id;
        public int tutorsID
        {
            set { tut_id = value; }
        }
        public NewCourseForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveNewCourseButton_Click(object sender, EventArgs e)
        {
            saveall();
        }

        private void saveall()
        {
            if (newCourseNameBox.Text == "")
                MessageBox.Show("Невiрна назва курсу!");
            else
            {
                string correctName = AdminForm.MySQLEscape(newCourseNameBox.Text);
                string query = "INSERT INTO courses(name, id_tutors) VALUES(\"" + correctName + "\", " + tut_id.ToString() + ")";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                connection.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Курс додано!");
                Close();
            }
        }
        private void newCourseNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                saveall();
        }
    }
}
