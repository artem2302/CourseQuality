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
    public partial class StudDetailsForm : Form
    {
        private DataTable dt;
        private int courseNo; 
        public StudDetailsForm(DataTable d, int course_no)
        {
            InitializeComponent();
            dt = d;
            courseNo = course_no;
            answersListBox.DataSource = dt;
            answersListBox.DisplayMember = dt.Columns[0].ColumnName;

        }

        private void answersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (answersListBox.SelectedIndex == -1) return;
            string ans_name = dt.Columns[2].ColumnName;
            int ans_no = dt.Rows[answersListBox.SelectedIndex].Field<int>(ans_name);
            string query = @"SELECT stud.*
FROM students stud
INNER JOIN answers ans ON
ans.id_students = stud.id
INNER JOIN courses cour ON
cour.id = ans.id_courses
WHERE id_courses = "+courseNo+ " AND ans."+ans_name+" ="+ans_no;
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(query, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);
            respondentsListBox.DataSource = ds.Tables[0];
            respondentsListBox.DisplayMember = "name";

          
            connection.Close();
        }

        private void respondentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (respondentsListBox.SelectedIndex == -1) return;
            DataTable dt = (DataTable)respondentsListBox.DataSource;
            string query = "SELECT name FROM groups WHERE id=" + dt.Rows[respondentsListBox.SelectedIndex].Field<int>("id_groups") + " LIMIT 1";
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(query, connection);
            connection.Open();
            respondentTextBox.Text = sqlCom.ExecuteScalar().ToString();
            connection.Close();

        }
    }
}
