#pragma warning disable 0169
#pragma warning disable 0168
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CourseQuality;
using MySql.Data.MySqlClient;

namespace CourseQuality
{
    public partial class NewGroupForm : Form
    {
        private List<enterField> enterFields;
        private int fac_id;
        public int facultyID
        {
            set { fac_id = value; }
        }
        public NewGroupForm()
        {
            InitializeComponent();
            enterFields = new List<enterField>();
            enterFields.Add(new enterField());
 
            flowLayoutPanel1.Controls.Add(enterFields[0].mainPanel);
        }

        private void NewGroupForm_Load(object sender, EventArgs e)
        {
           
        }

        private void fillPasswords()
        {
            var rnd = new Random();
            for (var i = 0; i < enterFields.Count; i++)
            {
                enterFields[i].passwordBox.Text = AdminForm.newPassword(rnd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillPasswords();
        }

        private void addFields()
        {
            enterFields.Add(new enterField());
            flowLayoutPanel1.Controls.Add(enterFields[enterFields.Count - 1].mainPanel);
        }


        private void addFieldsButton_Click(object sender, EventArgs e)
        {
            addFields();
        }

        private void deleteFields()
        {
            //enterFields[enterFields.Count - 1] = null;
            if (enterFields.Count>1)
            try
            {
                enterFields[enterFields.Count - 1].mainPanel.Dispose();
                enterFields.RemoveAt(enterFields.Count - 1);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void deleteFieldsButton_Click(object sender, EventArgs e)
        {
            deleteFields();
        }

        private bool checkFields()
        {
            if (groupNameBox.Text.Length == 0) return false;
            int no;
            foreach (var v in enterFields)
                if ((v.passwordBox.Text.Length == 0) | (v.idNumberBox.Text.Length == 0) | (v.studentNameBox.Text.Length == 0) | !int.TryParse(v.idNumberBox.Text, out no))
                    return false;
            return true;
        }

        private void applyChanges()
        {
            try
            {
                if (checkFields())
                {
                    button1.Enabled = false;
                    string query = "INSERT INTO groups(id_facutlies, name) VALUES(" + fac_id.ToString() + ", \"" + AdminForm.MySQLEscape(groupNameBox.Text) + "\")";
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand sqlCom = new MySqlCommand(query, connection);
                    connection.Open();
                    try
                    {
                        sqlCom.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Помилка створення групи!");
                        button1.Enabled = true;
                        return;
                    }

                    query = "SELECT id FROM groups WHERE name = \"" + AdminForm.MySQLEscape(groupNameBox.Text) + "\" LIMIT 1 ";
                    sqlCom = new MySqlCommand(query, connection);
                    int group_id = int.Parse(sqlCom.ExecuteScalar().ToString());

                    query = "INSERT INTO students(name, stud_nomer, password, id_groups) VALUES";
                    foreach (var field in enterFields)
                        query += "(\"" + AdminForm.MySQLEscape(field.studentNameBox.Text) + "\", "
                               + int.Parse(field.idNumberBox.Text) + ", "
                               + "\"" + LoginForm.sha1(field.passwordBox.Text) + "\", "
                               + group_id.ToString() + "),";
                    query = query.Remove(query.LastIndexOf(','));
                    sqlCom = new MySqlCommand(query, connection);
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                    button1.Enabled = true;
                    makeGroupList();
                    Close();
                }
                else MessageBox.Show("Присутнi пустi поля або нецифровi символи в номерах студентських квиткiв!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка! Перевiрте правильнiсть даних");
                button1.Enabled = true;
            }

        }

        private void makeGroupList()
        {
            //todo: secure
            GroupListForm grouplistform = new GroupListForm(groupNameBox.Text);
            grouplistform.enterFields = enterFields;
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand("SELECT name FROM facutlies WHERE id = " + fac_id.ToString() + " LIMIT 1", connection);
            connection.Open();
            grouplistform.fac_name = sqlCom.ExecuteScalar().ToString();
            connection.Close();
            grouplistform.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            applyChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkFields()) makeGroupList();
                else MessageBox.Show("Присутнi пустi поля або нецифровi символи в номерах студентських квиткiв!");
        }
    }
    public class enterField
    {
        public TextBox studentNameBox, idNumberBox, passwordBox;
        public Label nameLabel, loginLabel, passwordLabel;

        public Panel mainPanel;

        public enterField(Point[] locs)
        {
            //init labels:
            nameLabel = new Label();
            nameLabel.Size = new System.Drawing.Size(28, 13);
            nameLabel.Location = locs[0];
            nameLabel.Text = "ПIБ:";
            loginLabel = new Label();
            loginLabel.Size = new System.Drawing.Size(74, 13);
            loginLabel.Location = locs[1];
            loginLabel.Text = "Студ. квиток:";
            passwordLabel = new Label();
            passwordLabel.Size = new System.Drawing.Size(48, 13);
            passwordLabel.Location = locs[2];
            passwordLabel.Text = "Пароль:";
            //init textboxes:
            studentNameBox = new TextBox();
            studentNameBox.Size = new System.Drawing.Size(100, 20);
            studentNameBox.Location = locs[3];
            idNumberBox = new TextBox();
            idNumberBox.Size = new System.Drawing.Size(100, 20);
            idNumberBox.Location = locs[4];
            passwordBox = new TextBox();
            passwordBox.ReadOnly = true;
            passwordBox.Size = new System.Drawing.Size(100, 20);
            passwordBox.Location = locs[5];


        }
        public enterField()
        {
            nameLabel = new Label();
            nameLabel.Size = new System.Drawing.Size(28, 13);
            nameLabel.Location = new Point(3,4);
            nameLabel.Text = "ПIБ:";
            loginLabel = new Label();
            loginLabel.Size = new System.Drawing.Size(74, 13);
            loginLabel.Location = new Point(106,4);
            loginLabel.Text = "Студ. квиток:";
            passwordLabel = new Label();
            passwordLabel.Size = new System.Drawing.Size(48, 13);
            passwordLabel.Location = new Point(212,4);
            passwordLabel.Text = "Пароль:";
            //init textboxes:
            studentNameBox = new TextBox();
            studentNameBox.Size = new System.Drawing.Size(100, 20);
            studentNameBox.Location = new Point(3,20);
            idNumberBox = new TextBox();
            idNumberBox.Size = new System.Drawing.Size(100, 20);
            idNumberBox.Location = new Point(109,20);
            passwordBox = new TextBox();
            passwordBox.ReadOnly = true;
            passwordBox.Size = new System.Drawing.Size(70, 20);
            passwordBox.Location = new Point(215,20);
            //ADDING TO PANEL:
            mainPanel = new Panel();
            mainPanel.Width = 310;
            mainPanel.Height = 40;
            mainPanel.Controls.Add(loginLabel);
            mainPanel.Controls.Add(nameLabel);
            mainPanel.Controls.Add(studentNameBox);
            mainPanel.Controls.Add(idNumberBox);
            mainPanel.Controls.Add(passwordBox);
            mainPanel.Controls.Add(passwordLabel);
        }
    }
}
