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
    public partial class newFacForm : Form
    {
        public newFacForm()
        {
            InitializeComponent();
        }

        private void addFac()
        {
            if (facNameBoxC.Text == "") MessageBox.Show("Назва не може бути пустою!");
            else
            {
                string query = "INSERT INTO facutlies(name) VALUES(\"" + AdminForm.MySQLEscape(facNameBoxC.Text) + "\")";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                connection.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Успiшно додано!");
                Close();
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            addFac();
        }

        private void facNameBoxC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addFac();
        }
    }
}
