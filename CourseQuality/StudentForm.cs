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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace CourseQuality
{
    public partial class StudentForm : Form
    {
        private int studId;
        private string passHash;
        public StudentForm(int s, string hash)
        {
            InitializeComponent();
            studId = s;
            string selQuery = @"SELECT courses.* FROM courses
LEFT OUTER JOIN answers
ON courses.id = answers.id_courses AND answers.id_students = " + studId.ToString() +
" WHERE answers.id_students IS NULL";
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();
            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);
            coursesListBox.DataSource = ds3.Tables[0];
            coursesListBox.DisplayMember = "name";
            passHash = hash;
            connection.Close();
        }

        private void DisplayTutor()
        {
            if (coursesListBox.SelectedIndex == -1) return;
            DataTable dtb = (DataTable)coursesListBox.DataSource;
            DataRow dtr = dtb.Rows[coursesListBox.SelectedIndex];
            int tutorIndex = dtr.Field<int>("id_tutors");
            string selQuery = "SELECT * FROM tutors WHERE id = " +tutorIndex;

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();

            DataSet ds = new DataSet();
            sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds);

            tutorTextBox.Text = ds.Tables[0].Rows[0].Field<string>("name");
                          
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainDataSet.courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.mainDataSet.courses);
            DisplayTutor();
        }

        private void selectCourseButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)coursesListBox.DataSource;
            DataRow dtr = dt.Rows[coursesListBox.SelectedIndex];
            int choice = dtr.Field<int>("id");
            TestForm testForm = new TestForm();
            testForm.CourseId = choice;
            testForm.StudId = studId;
            testForm.Show();
            Hide();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void coursesListBox_Click(object sender, EventArgs e)
        {

            
        }

        private void coursesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTutor();
        }

        private void clearBoxes()
        {
            oldPasswordBox.Text = "";
            newPasswordBox.Text = "";
            confirmPasswordBox.Text = "";
        }

        private void changePassword()
        {
            if (LoginForm.sha1(oldPasswordBox.Text) != passHash)
            {
                MessageBox.Show("Невiрно введений старий пароль!");
                clearBoxes();
                return;
            }
            if (newPasswordBox.Text == "")
            {
                MessageBox.Show("Пароль не може бути пустим!");
                clearBoxes();
                return;
            }
            if (newPasswordBox.Text != confirmPasswordBox.Text)
            {
                MessageBox.Show("Введенi паролi не спiвпадають!");
                clearBoxes();
                return;
            }
            try
            {
                string pass = newPasswordBox.Text;
                string query = "UPDATE students SET `password` = \""+LoginForm.sha1(pass)+"\" WHERE id ="+studId.ToString();
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                connection.Open();
                sqlCom = new MySqlCommand(query, connection);
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Пароль змiнено! Перезайдiть у програму");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!");
            }
            clearBoxes();
        }

        private void applyPasswordButton_Click(object sender, EventArgs e)
        {
            changePassword();
        }
    }
}
