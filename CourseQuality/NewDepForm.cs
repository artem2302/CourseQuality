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
    public partial class NewDepForm : Form
    {
        private int fac_id;
        public int facultyID
        {
            set { fac_id = value; }
        }

        public NewDepForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            saveall();
        }

        private void saveall()
        {
            if (depNameBox.Text == "")
                MessageBox.Show("Назва не може бути пустою!");
            else
            {
                string query = "INSERT INTO departments(id_facutlies, name) VALUES(" + fac_id.ToString()
                    + ", \"" + AdminForm.MySQLEscape(depNameBox.Text) + "\")";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                connection.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Успiшно додано!");
                Close();
            }
        }

        private void depNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void depNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                saveall();
        }
    }
}
