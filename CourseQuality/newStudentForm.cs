using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace CourseQuality
{
    public partial class newStudentForm : Form
    {
        private int gr_id;
        public int groupID
        {
            set { gr_id = value; }
        }
        public newStudentForm()
        {
            InitializeComponent();
        }

        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            passwordBox.Text = AdminForm.newPassword(new Random());
        }

        private bool checkFields()
        {
            int no;
            if ((studentNameBox.Text == "") | (idNumberBox.Text == "") | (passwordBox.Text == "") | !int.TryParse(idNumberBox.Text,out no)) return false;
            return true;
        }

        private void saveNewStudentButton_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                studentNameBox.ReadOnly = true;
                idNumberBox.ReadOnly = true;
                string query = "INSERT INTO students(name, stud_nomer, password, id_groups) VALUES(\""+ AdminForm.MySQLEscape(studentNameBox.Text)+"\", "+ AdminForm.MySQLEscape(idNumberBox.Text)+", \""+LoginForm.sha1(passwordBox.Text)+"\", "+gr_id.ToString()+")";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Студента додано! Пароль скопiйовано до буферу обмiну");
                Clipboard.SetText(passwordBox.Text);
                Close();
            }
            else MessageBox.Show("Присутнi пустi поля або невiрний номер квитка!");
        }

        private void idNumberBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }
    }
}
