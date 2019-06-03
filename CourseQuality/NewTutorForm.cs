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
    public partial class NewTutorForm : Form
    {
        private int dep_id;
        public NewTutorForm(int departmentID)
        {
            InitializeComponent();
            /*  string query = "SELECT * FROM departments WHERE id_facutlies="+fac_id.ToString();
              MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
              MySqlCommand command = new MySqlCommand(query, connection);
              connection.Open();
              MySqlDataAdapter dapt = new MySqlDataAdapter(command);
              DataSet ds = new DataSet();
              dapt.Fill(ds);
              connection.Close();
              comboBox1.DataSource = ds.Tables[0];
              comboBox1.DisplayMember = "name";*/
            dep_id = departmentID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveall()
        {
            if (textBox1.Text == "")
                MessageBox.Show("Некоректне iм\'я!");
            else
            {
                string query = "INSERT INTO tutors(id_departments, name) VALUES(" + dep_id.ToString()
                    + ", \"" + AdminForm.MySQLEscape(textBox1.Text) + "\")";

                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Успiшно додано!");
                Close();
            }
        }

        private void SaveTutorButton_Click(object sender, EventArgs e)
        {
            saveall();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                saveall();
        }
    }
}
