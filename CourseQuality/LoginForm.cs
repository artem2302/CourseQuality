#pragma warning disable 0168
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace CourseQuality
{
    public partial class LoginForm : Form
    {
        private string phash;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        public static string sha1(string input)
        {
            byte[] hash;
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                hash = sha1.ComputeHash(Encoding.ASCII.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
        private bool studentLogin(out int id)
        {
            int stud_no = 0;
            try
            {
                stud_no = int.Parse(textBox1.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Невiрний логiн! Для студентiв логiном є номер студентського квитка");
                textBox1.Clear();
                textBox2.Clear();
                id = 0;
                return false;
            }
            string pass_hash = sha1(textBox2.Text);
            string CommandText = "SELECT COUNT(*) FROM students WHERE stud_nomer ="+ stud_no + " AND password =\""+ pass_hash +"\"";
            
            string Connect = Properties.Settings.Default.MainConnectionString;
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            int result = int.Parse(myCommand.ExecuteScalar().ToString());
            myConnection.Close();
            if (result == 0)
            {
                id = -1;
                MessageBox.Show("Помилка входу!");
                textBox1.Clear();
                textBox2.Clear();
                return false;
            }
            CommandText = @"SELECT id FROM `students`
WHERE stud_nomer = " + stud_no + " AND password =\"" + pass_hash + "\" LIMIT 1";
            myConnection = new MySqlConnection(Connect);
            myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            id = int.Parse(myCommand.ExecuteScalar().ToString());
            myConnection.Close();
            phash = pass_hash;
            return true;
        }

        private void studentMode()
        {
            //avoid deleting
            int stud_id;
            if (!studentLogin(out stud_id)) return;
            StudentForm studentForm = new StudentForm(stud_id, phash);
            studentForm.Show();
            Hide();
        }
        private bool deanLogin(out int fac_id, out int admin_id)
        {
            fac_id = 0;
            string login = textBox1.Text;
            string pass_hash = sha1(textBox2.Text);
            string CommandText = "SELECT COUNT(*) FROM deanery_admins WHERE login =\"" + AdminForm.MySQLEscape(login) + "\" AND password =\"" + pass_hash + "\"";
            string Connect = Properties.Settings.Default.MainConnectionString;
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            int result = int.Parse(myCommand.ExecuteScalar().ToString());
            myConnection.Close();
            if (result == 0)
            {
                fac_id = -1;
                admin_id = -1;
                MessageBox.Show("Помилка входу!");
                textBox1.Clear();
                textBox2.Clear();
                return false;
            }
            CommandText = "SELECT id_facutlies FROM `deanery_admins` WHERE login = \"" + AdminForm.MySQLEscape(login) + "\" AND password =\"" + pass_hash + "\" LIMIT 1";
            myConnection = new MySqlConnection(Connect);
            myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            fac_id = int.Parse(myCommand.ExecuteScalar().ToString());
            CommandText = "SELECT id FROM deanery_admins WHERE login =\"" + AdminForm.MySQLEscape(login) + "\" AND password =\"" + pass_hash + "\" LIMIT 1";
            myCommand = new MySqlCommand(CommandText, myConnection);
            admin_id = int.Parse(myCommand.ExecuteScalar().ToString());
            myConnection.Close();
            return true;
        }

        private void deanAdminMode()
        {
            //avoid_deleting
            int fac_id, d_id;
            if (!deanLogin(out fac_id, out d_id)) return;
            AdminForm adminForm = new AdminForm(fac_id, false, d_id);
            adminForm.FacultyID = fac_id;
            adminForm.adminHash = sha1(textBox2.Text);
            adminForm.Show();
            Hide();
        }

        private bool rectorLogin(out int r_id)
        {
            string login = textBox1.Text;
            string pass_hash = sha1(textBox2.Text);
            string CommandText = "SELECT COUNT(*) FROM univer_admins WHERE login =\"" + AdminForm.MySQLEscape(login) + "\" AND password =\"" + pass_hash + "\"";
            string Connect = Properties.Settings.Default.MainConnectionString;
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            int result = int.Parse(myCommand.ExecuteScalar().ToString());
            if (result<1)
            {
                r_id = -1;
                MessageBox.Show("Помилка входу!");
                textBox1.Text = "";
                textBox2.Text = "";
                myConnection.Close();          
                return false;
            }
            CommandText = "SELECT id FROM univer_admins WHERE login =\"" + AdminForm.MySQLEscape(login) + "\" AND password =\"" + pass_hash + "\" LIMIT 1";
            myCommand = new MySqlCommand(CommandText, myConnection);
            r_id = int.Parse(myCommand.ExecuteScalar().ToString());
            myConnection.Close();
            return true;
        }
        private void rectorAdminMode()
        {
            int r_id;
            if (!rectorLogin(out r_id)) return;
            AdminForm adminForm = new AdminForm(1, true, r_id);
            adminForm.adminHash = sha1(textBox2.Text);
            adminForm.Show();
            Hide();
        }
        private void loginCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void login()
        {
            if (radioButton1.Checked) studentMode();
            else
            if (radioButton2.Checked) deanAdminMode();
            else
            if (radioButton3.Checked) rectorAdminMode();
        }
        private void loginEnterButton_Click(object sender, EventArgs e)
        {
            login();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                login();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
