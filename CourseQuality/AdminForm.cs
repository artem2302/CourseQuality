#pragma warning disable 0169
#pragma warning disable 0168
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseQuality
{
    public partial class AdminForm : Form
    {
        private int chosenCourse, facultyID;
        private string admin_hash;
        private string[] questions;
        private DataSet coursesDS, groupsDataSet;
        private bool isRector;
        public int admin_id;

        private void QuestInit()
        {
            questions = new string[39];
            //A. Learning
            questions[0] = "Ви вважаєте цей модуль змагально та інтелектуально стимулюючим";
            questions[1] = "Ви вивчили щось, що ви вважаєте цінним";
            questions[2] = "Ваша зацікавленість в предметі збільшилась в результаті цього модуля";
            questions[3] = "Ви вивчили та зрозуміли матеріали по темі цього модуля";
            //B. Enthusiasm
            questions[4] = "Викладач з ентузіазмом викладає модуль";
            questions[5] = "Викладач динамічно і енергічно проводить заняття";
            questions[6] = "Викладач покращує наглядність за допомогою гумору";
            questions[7] = "Стиль викладання викладача притягує увагу протягом заняття";
            //C. Organization
            questions[8] = "Пояснення викладача зрозумілі";
            questions[9] = "Матеріали модуля добре підготовлені та точно пояснені";
            questions[10] = "Запропоновані цілі погоджені з навчальним планом, тому ви знаєте, як продовжиться модуль";
            questions[11] = "Лекції викладача доповнюються за допомогою нотаток";
            //D. Collective
            questions[12] = "Студенти заохочені до участі в дискусіях";
            questions[13] = "Студенти запрошені ділитися своїми ідеями та знаннями";
            questions[14] = "Студенти заохочені задавати питання і отримують змістовні відповіді";
            questions[15] = "Студенти заохочені виражати свої власні ідеї та/або запитувати викладача";
            //E. Individual
            questions[16] = "Викладач дружньо відноситься до кожного студента";
            questions[17] = "Студенти можуть вільно звернутися за допомогою або порадою в позаурочний час";
            questions[18] = "Викладач має істиний інтерес в індивідуальних студентах";
            questions[19] = "Викладач доступний студентам під час роботи в години після занять";
            //F. Breadth
            questions[20] = "Викладач порівнює різні теорії та їх наслідки";
            questions[21] = "Викладач показує походження (або джерело) ідей(чи концепцій) розвинених в аудиторії під час лекції";
            questions[22] = "Викладач показує точки зору, відмінні від його в разі необхідності";
            questions[23] = "Викладач адекватно обговорює поточні сучасні розробки в галузі";
            //G. Exams
            questions[24] = "На скільки цінна реакція (коментарі) на іспитах (чи оцінюванні), тобто на скільки пропрацьованні помилки допущені на іспиті після його проведення";
            questions[25] = "Методи оцінювання роботи студента є справедливими і відповідними";
            questions[26] = "Матеріал іспитів/оцінки тестового модулю є змістовним, як і наголосив викладач";
            //H. Dedication
            questions[27] = "Необхідна(вказана викладачем) література для вивчення курсу є цінною";
            questions[28] = "Читання, домашня роботота, і т. д., впливають на оцінку і розуміння предмету";
            //I. General
            questions[29] = "Як Вам цей курс порівняно з іншими курсами, які ви оцінювали в цьому тесті";
            questions[30] = "Як Вам викладач порівняно з іншими викладачами, яких ви оцінювали в цьому тесті";

            //J. Characteristics:
            questions[31] = "Складність курсу, порівняно з іншими курсами, є";
            questions[32] = "Навантаженість курсу, порівняно з іншими, є";
            questions[33] = "Темп проходження курсу, порівняно з іншими, є:";
            questions[34] = "Необхідна кількість позааудиторних годин (на тиждень):";
            questions[35] = "Ваш рівень зацікавленості до теми, що стосується цього курсу:";
            questions[36] = "Ваш середній бал:";
            questions[37] = "7. Бал, на який Ви сподівались:";
            questions[38] = "Скільки курсів у Вас було до цього?";
        }
        public int FacultyID
        {
            set { facultyID = value; }
        }

        public string adminHash
        {
            set { admin_hash = value; }
        }

        public static string MySQLEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
                delegate (Match match)
                {
                    string v = match.Value;
                    switch (v)
                    {
                        case "\x00":            // ASCII NUL (0x00) character
                    return "\\0";
                        case "\b":              // BACKSPACE character
                    return "\\b";
                        case "\n":              // NEWLINE (linefeed) character
                    return "\\n";
                        case "\r":              // CARRIAGE RETURN character
                    return "\\r";
                        case "\t":              // TAB
                    return "\\t";
                        case "\u001A":          // Ctrl-Z
                    return "\\Z";
                        default:
                            return "\\" + v;
                    }
                });
        }
        public AdminForm(int fid, bool rector, int aid)
        {

            InitializeComponent();
            try
            {
                isRector = rector;
                facultyID = fid;
                admin_id = aid;
                string selQuery = "SELECT * FROM facutlies";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
                if (!rector)
                {
                    DeanFaculAbel.Hide();
                    factultiesCombo.Hide();
                    adminTabControl.TabPages.RemoveAt(3);
                    panel3.Hide();
                    label16.Text = "Адмiнiстрування факультету:";


                    string query = "SELECT * FROM deanery_admins WHERE id_facutlies =" + fid + " AND id !=" + aid.ToString();
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand com = new MySqlCommand(query, con);
                    con.Open();
                    MySqlTransaction tr = con.BeginTransaction();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(com);
                    // con.EnlistTransaction();
                    tr.Commit();
                    DataSet tempDS = new DataSet();
                    adapt.Fill(tempDS);
                    recsCombo.DataSource = tempDS.Tables[0];
                    recsCombo.DisplayMember = "login";
                    con.Close();
                }
                else
                {
                    //TODO: REMOVE AND IMPLEMENT
                    deleteFacButton.Visible = false;

                    connection.Open();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(sqlCom);
                    DataSet tempDS = new DataSet(), tempDS2 = new DataSet(), tempDSF = new DataSet();
                    adapt.Fill(tempDS);
                    adapt.Fill(tempDS2);
                    adapt.Fill(tempDSF);
                    factultiesCombo.DataSource = tempDS.Tables[0];
                    factultiesCombo.DisplayMember = "name";
                    facsListBox.DataSource = tempDS2.Tables[0];
                    facsListBox.DisplayMember = "name";
                    admFacsCombo.DataSource = tempDSF.Tables[0];
                    admFacsCombo.DisplayMember = "name";
                    try
                    {
                        DataTable tdt = (DataTable)factultiesCombo.DataSource;
                        facultyID = tdt.Rows[0].Field<int>("id");
                    }
                    catch (Exception e)
                    {

                    }
                    connection.Close();


                    string q = "SELECT * FROM univer_admins WHERE id !=" + aid.ToString();
                    MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand comm = new MySqlCommand(q, conn);
                    conn.Open();
                    MySqlDataAdapter adapt2 = new MySqlDataAdapter(comm);
                    DataSet tempDS3 = new DataSet();
                    adapt2.Fill(tempDS3);
                    recsCombo.DataSource = tempDS3.Tables[0];
                    recsCombo.DisplayMember = "login";
                    conn.Close();
                }
                QuestInit();
                Text = adminTabControl.TabPages[adminTabControl.SelectedIndex].Text;
                selQuery = @"SELECT cour.id, cour.name, cour.id_tutors from courses cour
INNER JOIN tutors tut on tut.id = cour.id_tutors
INNER JOIN departments dep on dep.id = tut.id_departments
INNER JOIN facutlies fac on fac.id = dep.id_facutlies
WHERE dep.id_facutlies = " + facultyID.ToString();

                sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();

                MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
                coursesDS = new DataSet();
                dapt.Fill(coursesDS);


                refreshDeps();
                refreshTutors();
                refreshCourses();

                coursesListBox.DataSource = coursesDS.Tables[0];
                coursesListBox.DisplayMember = "name";
                connection.Close();

                if (coursesDS.Tables[0].Rows.Count < 1) return;

                DataRow dtr = coursesDS.Tables[0].Rows[0];
                int tutorIndex = dtr.Field<int>("id_tutors");
                selQuery = "SELECT * FROM tutors WHERE id = " + tutorIndex;

                connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();

                DataSet ds = new DataSet();
                sqlCom = new MySqlCommand(selQuery, connection);
                dapt = new MySqlDataAdapter(sqlCom);
                dapt.Fill(ds);

                tutorTextBox.Text = ds.Tables[0].Rows[0].Field<string>("name");
                chosenCourse = dtr.Field<int>("id");

                connection.Close();

                refreshGroups();

                changeGroup();
            }
            catch (Exception exc)
            {

            }

        }

        private bool courseHasAnswers(int cid)
        {
            string selQuery = "SELECT COUNT(*) FROM answers WHERE id_courses = " + cid.ToString();
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();
            if (int.Parse(sqlCom.ExecuteScalar().ToString()) == 0)
            {
                MessageBox.Show("Цей курс ще не проходив оцiнку!");
                return false;
            }
            connection.Close();
            return true;
        }

        private void refreshCourses()
        {
            MySqlConnection connection;
            MySqlCommand sqlCom;
            string selQuery;
            try
            {
                selQuery = @"SELECT cour.id, cour.name, cour.id_tutors from courses cour
INNER JOIN tutors tut on tut.id = cour.id_tutors
INNER JOIN departments dep on dep.id = tut.id_departments
INNER JOIN facutlies fac on fac.id = dep.id_facutlies
WHERE dep.id_facutlies = " + facultyID.ToString();
                connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();
                MySqlDataAdapter tempadap = new MySqlDataAdapter(sqlCom);
                DataSet tempdatas = new DataSet();
                tempadap.Fill(tempdatas);
                coursesListBox.DataSource = tempdatas.Tables[0];
                coursesListBox.DisplayMember = "name";
                connection.Close();
            }
            catch (Exception e)
            {

            }
            if ((changeTutorsListBox.SelectedIndex == -1) | (changeDepsListBox.SelectedIndex == -1))
            {
                changeCoursesListBox.DataSource = null;
                changeCourseNameBox.Text = "";
                return;
            }
            DataTable table1 = (DataTable)changeTutorsListBox.DataSource;

            DataTable table2 = (DataTable)changeDepsListBox.DataSource;

            selQuery = @"SELECT cour.id, cour.name, cour.id_tutors FROM courses cour
INNER JOIN tutors tut on cour.id_tutors = tut.id
INNER JOIN departments dep on dep.id = tut.id_departments
WHERE tut.id = " + table1.Rows[changeTutorsListBox.SelectedIndex].Field<int>("id").ToString() 
+" AND dep.id = " +table2.Rows[changeDepsListBox.SelectedIndex].Field<int>("id").ToString();
            connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            connection.Open();
            sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet datas3 = new DataSet();
            dapt.Fill(datas3);
            changeCoursesListBox.DataSource = datas3.Tables[0];
            changeCoursesListBox.DisplayMember = "name";
            connection.Close();
            changeCourseNameBox.Text = changeCoursesListBox.GetItemText(changeCoursesListBox.SelectedItem);
            if (tutorsComboBox.Items.Count >0) tutorsComboBox.SelectedIndex = changeTutorsListBox.SelectedIndex;
        }

        private void refreshTutors()
        {
            if (changeDepsListBox.Items.Count == 0)
            {
                changeTutorsListBox.DataSource = null;
                changeTutorsListBox.Items.Clear();
                tutorsComboBox.DataSource = null;
                tutorsComboBox.Items.Clear();
            }
            if (changeDepsListBox.SelectedIndex == -1) return;
            DataTable table = (DataTable)changeDepsListBox.DataSource;
            string selQuery = @"SELECT tut.id, tut.id_departments, tut.name FROM tutors tut
INNER JOIN departments dep on dep.id = tut.id_departments
INNER JOIN facutlies fac on fac.id = dep.id_facutlies
WHERE fac.id = " + facultyID.ToString() + " AND tut.id_departments = " + table.Rows[changeDepsListBox.SelectedIndex].Field<int>("id").ToString();
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            connection.Open();
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet datas3 = new DataSet();
            DataSet datas4 = new DataSet();
            dapt.Fill(datas3);
            dapt.Fill(datas4);
            changeTutorsListBox.DataSource = datas3.Tables[0];
            changeTutorsListBox.DisplayMember = "name";
            tutorsComboBox.DataSource = datas4.Tables[0];
            tutorsComboBox.DisplayMember = "name";
            connection.Close();
            changeTutorNameBox.Text = changeTutorsListBox.GetItemText(changeTutorsListBox.SelectedItem);
            if (departmentsCombo.Items.Count > 0)
                departmentsCombo.SelectedIndex = changeDepsListBox.SelectedIndex;
        }
        private void refreshGroups()
        {
            var selQuery = "SELECT * FROM groups WHERE id_facutlies = " + facultyID;
            var connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            var sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();

            groupsDataSet = new DataSet();
            sqlCom = new MySqlCommand(selQuery, connection);
            var dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(groupsDataSet);

            groupsListBox.DataSource = groupsDataSet.Tables[0];
            groupsListBox.DisplayMember = "name";

            connection.Close();
        }

        private void refreshStudents()
        {
            if (groupsListBox.Items.Count == 0)
            {
                studentsListBox.DataSource = null;
                studentsListBox.Items.Clear();
                groupTextBox.Text = "";
                studentNameBox.Text = "";
                idNumberBox.Text = "";
            }
            if (groupsListBox.SelectedIndex == -1) return;
            int groupID = groupsDataSet.Tables[0].Rows[groupsListBox.SelectedIndex].Field<int>("id");
            string selQuery = "SELECT * FROM students WHERE id_groups = " + groupID;
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            studentsListBox.DataSource = ds3.Tables[0];
            studentsListBox.DisplayMember = "name";
            passwordBox.Text = "";
            connection.Close();
        }
        private void changeGroup()
        {
            refreshStudents();
            groupTextBox.Text = groupsListBox.GetItemText(groupsListBox.SelectedItem);
        }
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static string newPassword(Random rnd)
        {
            string str = "abcdefghijklmnopqrstuvwxyz";
            string numeric = "0123456789";
            string password = "";
            string character = "";
            while (password.Length < 10)
            {
                int entity1 = (int)Math.Ceiling((str.Length * rnd.NextDouble() * rnd.NextDouble()));
                int entity2 = (int)Math.Ceiling(numeric.Length * rnd.NextDouble());
                char hold = str[entity1];
                hold = (entity1 % 2 == 0) ? (char.ToUpper(hold)) : (hold);
                character += hold;
                character += numeric[entity2-1];
                password = character;
            }
            return password;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDataSet.groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.mainDataSet.groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDataSet.students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.mainDataSet.students);
            // TODO: This line of code loads data into the 'mainDataSet2.courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.mainDataSet2.courses);
            // TODO: This line of code loads data into the 'mainDataSet2.question1' table. You can move, or remove it, as needed.
            //  this.question1TableAdapter.Fill(this.mainDataSet2.question1);
            // TODO: This line of code loads data into the 'mainDataSet2.q1_view' table. You can move, or remove it, as needed.
            //  this.q1_viewTableAdapter.Fill(this.mainDataSet2.q1_view);
            // TODO: This line of code loads data into the 'mainDataSet1.q1_view' table. You can move, or remove it, as needed.
            /*  DataRow dtr = mainDataSet2.Tables["courses"].Rows[coursesListBox.SelectedIndex];
              tutorTextBox.Text = dtr.Field<string>("tutor");
              chosenCourse = dtr.Field<int>("id");*/

            if (coursesListBox.SelectedIndex == -1) return;
            /*DataRow dtr = mainDataSet2.Tables["courses"].Rows[coursesListBox.SelectedIndex];
            int tutorIndex = dtr.Field<int>("id_tutors");
            string selQuery = "SELECT * FROM tutors WHERE id = " + tutorIndex;

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            connection.Open();

            DataSet ds = new DataSet();
            sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds);

            tutorTextBox.Text = ds.Tables[0].Rows[0].Field<string>("name");
            chosenCourse = dtr.Field<int>("id");*/


        }

        private void adminTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = adminTabControl.TabPages[adminTabControl.SelectedIndex].Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coursesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtb = (DataTable)coursesListBox.DataSource;
                DataRow dtr = dtb.Rows[coursesListBox.SelectedIndex];
                int tutorIndex = dtr.Field<int>("id_tutors");
                string selQuery = "SELECT * FROM tutors WHERE id = " + tutorIndex;

                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();

                DataSet ds = new DataSet();
                sqlCom = new MySqlCommand(selQuery, connection);
                MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
                dapt.Fill(ds);
                

                tutorTextBox.Text = ds.Tables[0].Rows[0].Field<string>("name");
                chosenCourse = dtr.Field<int>("id");
            }
            catch (Exception ex)
            {
               
            }
        }

        private void learningButton_Click(object sender, EventArgs e)
        {//TESTING HERE
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a1) as COUNT, a1
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a1
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a1";

            string selQuery2 = @"SELECT names.name, COUNT(a2) as COUNT, a2
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a2
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a2";

            string selQuery3 = @"SELECT names.name, COUNT(a3) as COUNT, a3
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a3
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a3";

            string selQuery4 = @"SELECT names.name, COUNT(a4) as COUNT, a4
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a4
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a4";

            string comQuery = @"SELECT id as ID, c1 as COMMENT
FROM comments
WHERE c1 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlTransaction tr = connection.BeginTransaction();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string []lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i];


            AFCharts learningCharts = new AFCharts(chosenCourse,ds,ds2,ds3,ds4,com_ds, "навчання",lquest);
            learningCharts.Show();
            tr.Commit();
            connection.Close();
        }

        private void enthusiasmButton_Click(object sender, EventArgs e)
        {

            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a5) as COUNT, a5
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a5
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a5";

            string selQuery2 = @"SELECT names.name, COUNT(a6) as COUNT, a6
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a6
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a6";

            string selQuery3 = @"SELECT names.name, COUNT(a7) as COUNT, a7
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a7
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a7";

            string selQuery4 = @"SELECT names.name, COUNT(a8) as COUNT, a8
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a8
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a8";

            string comQuery = @"SELECT id as ID, c2 as COMMENT
FROM comments
WHERE c2 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string []lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i+4];

            AFCharts enthCharts = new AFCharts(chosenCourse,ds,ds2,ds3,ds4,com_ds, "ентузіазм",lquest);
            enthCharts.Show();
            connection.Close();
        }

        private void organizationButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a9) as COUNT, a9
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a9
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a9";

            string selQuery2 = @"SELECT names.name, COUNT(a10) as COUNT, a10
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a10
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a10";

            string selQuery3 = @"SELECT names.name, COUNT(a11) as COUNT, a11
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a11
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a11";

            string selQuery4 = @"SELECT names.name, COUNT(a12) as COUNT, a12
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a12
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a12";

            string comQuery = @"SELECT id as ID, c3 as COMMENT
FROM comments
WHERE c3 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i + 8];

            AFCharts orgCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "організація", lquest);
            orgCharts.Show();
            connection.Close();
        }

        private void groupButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a13) as COUNT, a13
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a13
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a13";

            string selQuery2 = @"SELECT names.name, COUNT(a14) as COUNT, a14
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a14
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a14";

            string selQuery3 = @"SELECT names.name, COUNT(a15) as COUNT, a15
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a15
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a15";

            string selQuery4 = @"SELECT names.name, COUNT(a16) as COUNT, a16
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a16
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a16";

            string comQuery = @"SELECT id as ID, c4 as COMMENT
FROM comments
WHERE c4 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i + 12];

            AFCharts collectiveCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "колективна взаємодія", lquest);
            collectiveCharts.Show();
            connection.Close();
        }

        private void individualButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a17) as COUNT, a17
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a17
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a17";

            string selQuery2 = @"SELECT names.name, COUNT(a18) as COUNT, a18
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a18
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a18";

            string selQuery3 = @"SELECT names.name, COUNT(a19) as COUNT, a19
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a19
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a19";

            string selQuery4 = @"SELECT names.name, COUNT(a20) as COUNT, a20
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a20
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a20";

            string comQuery = @"SELECT id as ID, c5 as COMMENT
FROM comments
WHERE c5 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i + 16];

            AFCharts indCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "індивідуальний підхід", lquest);
            indCharts.Show();
            connection.Close();
        }

        private void breadthButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a21) as COUNT, a21
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a21
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a21";

            string selQuery2 = @"SELECT names.name, COUNT(a22) as COUNT, a22
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a22
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a22";

            string selQuery3 = @"SELECT names.name, COUNT(a23) as COUNT, a23
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a23
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a23";

            string selQuery4 = @"SELECT names.name, COUNT(a24) as COUNT, a24
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a24
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a24";

            string comQuery = @"SELECT id as ID, c6 as COMMENT
FROM comments
WHERE c6 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 4; i++)
                lquest[i] = questions[i + 20];

            AFCharts breadthCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "повнота", lquest);
            breadthCharts.Show();
            connection.Close();

        }

        private void examsButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a25) as COUNT, a25
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a25
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a25";

            string selQuery2 = @"SELECT names.name, COUNT(a26) as COUNT, a26
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a26
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a26";

            string selQuery3 = @"SELECT names.name, COUNT(a27) as COUNT, a27
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a27
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a27";

            string comQuery = @"SELECT id as ID, c7 as COMMENT
FROM comments
WHERE c7 IS NOT NULL AND id_courses = " + chosenCourse.ToString();
            //            MessageBox.Show(selQuery);

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = null;

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 3; i++)
                lquest[i] = questions[i + 24];

            AFCharts examCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "іспити", lquest);
            examCharts.threeQuest();

            examCharts.Show();
            connection.Close();
        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a28) as COUNT, a28
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a28
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a28";

            string selQuery2 = @"SELECT names.name, COUNT(a29) as COUNT, a29
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a29
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a29";



            string comQuery = @"SELECT id as ID, c8 as COMMENT
FROM comments
WHERE c8 IS NOT NULL AND id_courses = " + chosenCourse.ToString();

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = null;
            DataSet ds4 = null;

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 2; i++)
                lquest[i] = questions[i + 27];

            AFCharts assignCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "призначення", lquest);
            assignCharts.twoQuest();

            assignCharts.Show();
            connection.Close();
        }

        private void overallButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name, COUNT(a30) as COUNT, a30
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a30
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a30";

            string selQuery2 = @"SELECT names.name, COUNT(a31) as COUNT, a31
FROM answers ans
INNER JOIN ansnamesai names
ON names.number = ans.a31
WHERE id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a31"; 



            string comQuery = @"SELECT id as ID, c9 as COMMENT
FROM comments
WHERE c9 IS NOT NULL AND id_courses = " + chosenCourse.ToString();

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = null;
            DataSet ds4 = null;

            DataSet com_ds = new DataSet();
            sqlCom = new MySqlCommand(comQuery, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(com_ds);

            string[] lquest = new string[4];
            for (int i = 0; i < 2; i++)
                lquest[i] = questions[i + 29];

            AFCharts overallCharts = new AFCharts(chosenCourse, ds, ds2, ds3, ds4, com_ds, "загальне", lquest);
            overallCharts.twoQuest();

            overallCharts.Show();
            connection.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void changeStudent()
        {
            try
            {
                studentNameBox.Text = studentsListBox.GetItemText(studentsListBox.SelectedItem);
                var dtable = (DataTable)studentsListBox.DataSource;
                idNumberBox.Text = dtable.Rows[studentsListBox.SelectedIndex].Field<int>("stud_nomer").ToString();
                passwordBox.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void studentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeStudent();
        }

        private void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeGroup();
            if (studentsListBox.Items.Count == 0)
            {
                //TODO: LOCK THEM!
                studentNameBox.Text = "";
                idNumberBox.Text = "";
                return;
            }
        }

        private void saveGroupChangesButton_Click(object sender, EventArgs e)
        {
            if (groupTextBox.Text == "")
                MessageBox.Show("Назва групи не може бути пустою!");
            else if (MessageBox.Show("Змiнити назву групи?","Пiдтвердження",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE `groups` SET `name` =\'" + MySQLEscape(groupTextBox.Text) + "\' WHERE `groups`.`id` = " + groupsDataSet.Tables[0].Rows[groupsListBox.SelectedIndex].Field<int>("id");
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand sqlCom = new MySqlCommand(query, connection);
                    connection.Open();
                    sqlCom = new MySqlCommand(query, connection);
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                    refreshGroups();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void saveStudentChangesButton_Click(object sender, EventArgs e)
        {
            int no;
            if ((studentNameBox.Text == "") | (idNumberBox.Text == "") | !int.TryParse(idNumberBox.Text,out no))
                MessageBox.Show("Поля iменi та номеру квитка не можуть буть пустими!");
            else if (MessageBox.Show("Змiнити данi?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var dtable = (DataTable)studentsListBox.DataSource;
                    try
                    {
                        string query;
                        if (passwordBox.Text == "")
                            query = "UPDATE students SET name = \"" + MySQLEscape(studentNameBox.Text) + "\", stud_nomer = " + MySQLEscape(idNumberBox.Text) + " WHERE id = " + dtable.Rows[studentsListBox.SelectedIndex].Field<int>("id");
                        else
                            query = "UPDATE students SET name = \"" + MySQLEscape(studentNameBox.Text) + "\", stud_nomer = " + MySQLEscape(idNumberBox.Text) + ", password =\"" + LoginForm.sha1(passwordBox.Text) + "\" WHERE id = " + dtable.Rows[studentsListBox.SelectedIndex].Field<int>("id");
                        MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                        connection.Open();
                        MySqlCommand sqlCom = new MySqlCommand(query, connection);
                        sqlCom.ExecuteNonQuery();
                        connection.Close();
                        refreshStudents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка даних!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void newStudentButton_Click(object sender, EventArgs e)
        {
            if (groupsListBox.SelectedIndex<0)
            {
                MessageBox.Show("Не обрана група!");
                return;
            } 
            int gr_id = groupsDataSet.Tables[0].Rows[groupsListBox.SelectedIndex].Field<int>("id");
            newStudentForm newstudentform = new newStudentForm();
            newstudentform.groupID = gr_id;
            newstudentform.ShowDialog();
            refreshStudents();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            NewGroupForm newgroupform = new NewGroupForm();
            newgroupform.facultyID = facultyID;
            newgroupform.ShowDialog();
            refreshGroups();
        }

        private void deleteGroupButton_Click(object sender, EventArgs e)
        {
            if (groupsListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Видалити групу? Увага, разом iз групою будуть видаленi усi студенти, що до неї вiдносяться!", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = groupsDataSet.Tables[0].Rows[groupsListBox.SelectedIndex].Field<int>("id");

                    string query = "DELETE ans FROM answers ans INNER JOIN students stud on stud.id = ans.id_students WHERE stud.id_groups = " + id.ToString();
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand command = new MySqlCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    query = "DELETE com FROM comments com INNER JOIN students stud on stud.id = com.id_students WHERE stud.id_groups = " + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    query = "DELETE FROM `students` WHERE `id_groups` = " + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    query = "DELETE FROM `groups` WHERE `groups`.`id` = " + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    refreshGroups();
                }
            }
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            if (studentsListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Видалити студента?","Пiдтвердження", MessageBoxButtons.YesNo) ==  DialogResult.Yes)
                {
                    DataTable dts = (DataTable)studentsListBox.DataSource;
                    int id = dts.Rows[studentsListBox.SelectedIndex].Field<int>("id");
                    string query = "DELETE FROM answers WHERE id_students=" + id.ToString();
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    query = "DELETE FROM comments WHERE id_students=" + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    query = "DELETE FROM students WHERE id=" + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    refreshStudents();
                }
            }
        }

        private void refreshDeps()
        {
            string selQuery = "SELECT * FROM departments WHERE id_facutlies = " + facultyID.ToString();
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            connection.Open();
            MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet datas = new DataSet();
            DataSet datas2 = new DataSet();
            dapt.Fill(datas);
            dapt.Fill(datas2);
            changeDepsListBox.DataSource = datas.Tables[0];
            changeDepsListBox.DisplayMember = "name";
            departmentsCombo.DataSource = datas2.Tables[0];
            departmentsCombo.DisplayMember = "name";
            connection.Close();
            changeDepTextBox.Text = changeDepsListBox.GetItemText(changeDepsListBox.SelectedItem);

        }

        private void changeDepsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refreshDeps();
            refreshTutors();
            refreshCourses();
            changeDepTextBox.Text = changeDepsListBox.GetItemText(changeDepsListBox.SelectedItem);
        }

        private void changeTutorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshCourses();
            changeTutorNameBox.Text = changeTutorsListBox.GetItemText(changeTutorsListBox.SelectedItem);
        }

        private void newDepButton_Click(object sender, EventArgs e)
        {
            NewDepForm newdepform = new NewDepForm();
            newdepform.facultyID = facultyID;
            newdepform.ShowDialog();
            refreshDeps();
        }

        private void deleteDepartment()
        {
            DataTable dt = (DataTable)changeDepsListBox.DataSource;
            int dep_id = dt.Rows[changeDepsListBox.SelectedIndex].Field<int>("id");
            string query = @"DELETE ans FROM answers ans
INNER JOIN courses cour ON ans.id_courses = cour.id
INNER JOIN tutors tut ON tut.id=cour.id_tutors
INNER JOIN departments dep ON dep.id=tut.id_departments
WHERE dep.id = "+dep_id.ToString();
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            connection.Open();
            MySqlCommand sqlCom = new MySqlCommand(query, connection);
            sqlCom.ExecuteNonQuery();
            query = @"DELETE com FROM comments com
INNER JOIN courses cour ON com.id_courses = cour.id
INNER JOIN tutors tut ON tut.id=cour.id_tutors
INNER JOIN departments dep ON dep.id=tut.id_departments
WHERE dep.id = " + dep_id.ToString();
            sqlCom = new MySqlCommand(query, connection);
            sqlCom.ExecuteNonQuery();

            query = @"DELETE cour FROM COURSES cour
INNER JOIN tutors tut ON cour.id_tutors = tut.id
INNER JOIN departments dep ON dep.id = tut.id_departments
WHERE dep.id = " + dep_id.ToString();
            sqlCom = new MySqlCommand(query, connection);
            sqlCom.ExecuteNonQuery();
            query = "DELETE FROM tutors WHERE id_departments=" + dep_id.ToString();
            sqlCom = new MySqlCommand(query, connection);
            sqlCom.ExecuteNonQuery();
            query = "DELETE FROM departments WHERE id=" + dep_id.ToString();
            sqlCom = new MySqlCommand(query, connection);
            sqlCom.ExecuteNonQuery();
            connection.Close();
            refreshDeps();
            refreshTutors();
            refreshCourses();
        }

        private void deleteDepButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Увага! Видаляючи кафедру, ви видалите всiх її викладачiв та курси! Продовжити?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                deleteDepartment();
        }

        private void newCourseButton_Click(object sender, EventArgs e)
        {
            NewCourseForm newcourseform = new NewCourseForm();
            DataTable dt = (DataTable)changeTutorsListBox.DataSource;
            newcourseform.tutorsID = dt.Rows[changeTutorsListBox.SelectedIndex].Field<int>("id");
            newcourseform.ShowDialog();
            refreshCourses();
        }

        private void deleteCourseButton_Click(object sender, EventArgs e)
        {
            if (changeCoursesListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Видалити курс?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataTable dts = (DataTable)changeCoursesListBox.DataSource;
                    int id = dts.Rows[changeCoursesListBox.SelectedIndex].Field<int>("id");
                    string query = "DELETE FROM answers WHERE id_courses =" + id.ToString();
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    query = "DELETE FROM comments WHERE id_courses =" + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    query = "DELETE FROM courses WHERE id=" + id.ToString();
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    refreshCourses();
                }
            }
        }

        private void newTutorButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)changeDepsListBox.DataSource;
            int did = dt.Rows[changeDepsListBox.SelectedIndex].Field<int>("id");
            NewTutorForm newtutorform = new NewTutorForm(did);
            newtutorform.ShowDialog();
            refreshTutors();
        }

        private void deleteTutor()
        {
            DataTable tut_dt = (DataTable)changeTutorsListBox.DataSource;
            int tut_id = tut_dt.Rows[changeTutorsListBox.SelectedIndex].Field<int>("id");
            string query = @"DELETE ans FROM answers ans
INNER JOIN courses cour ON cour.id = ans.id_courses
INNER JOIN tutors tut ON tut.id = cour.id_tutors
WHERE cour.id_tutors = " + tut_id.ToString();
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            query = @"DELETE com FROM comments com
INNER JOIN courses cour ON cour.id = com.id_courses
INNER JOIN tutors tut ON tut.id = cour.id_tutors
WHERE cour.id_tutors = " + tut_id.ToString();
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();

            query = "DELETE FROM courses WHERE id_tutors=" + tut_id.ToString();
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            query = "DELETE FROM tutors WHERE id ="+tut_id.ToString();
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            refreshTutors();
            refreshCourses();
        }

        private void deleteTutorButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Увага! При видаленнi викладача видаляються всi його курси. Продовжити?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                deleteTutor();
            }
        }

        private void changeCoursesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCourseNameBox.Text = changeCoursesListBox.GetItemText(changeCoursesListBox.SelectedItem);
        }

        private void saveDepButton_Click(object sender, EventArgs e)
        {
            if (changeDepTextBox.Text == "")
                MessageBox.Show("Назва кафедри не може бути пустою!");
            else if (MessageBox.Show("Змiнити назву кафедри?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataTable dt = (DataTable)changeDepsListBox.DataSource;
                    string query = "UPDATE `departments` SET `name` =\'" + MySQLEscape(changeDepTextBox.Text) + "\' WHERE `id` = " + dt.Rows[changeDepsListBox.SelectedIndex].Field<int>("id");
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand sqlCom = new MySqlCommand(query, connection);
                    connection.Open();
                    sqlCom = new MySqlCommand(query, connection);
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                    refreshDeps();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void saveTutorButton_Click(object sender, EventArgs e)
        {
            if (changeTutorNameBox.Text == "")
                MessageBox.Show("Некоректне iм\'я!");
            else if (MessageBox.Show("Зберегти змiни?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataTable dt = (DataTable)changeTutorsListBox.DataSource;
                    DataTable dt2 = (DataTable)departmentsCombo.DataSource;
                    int tutid = dt.Rows[changeTutorsListBox.SelectedIndex].Field<int>("id");
                    int kafid = dt2.Rows[departmentsCombo.SelectedIndex].Field<int>("id");
                    string query = "UPDATE `tutors` SET `name` =\'" + MySQLEscape(changeTutorNameBox.Text) + "\', id_departments = " + kafid.ToString() + " WHERE `id` = " + tutid.ToString();
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand sqlCom = new MySqlCommand(query, connection);
                    connection.Open();
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                    refreshTutors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void factultiesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tutorTextBox.Text = "";
                DataTable tdt = (DataTable)factultiesCombo.DataSource;
                facultyID = tdt.Rows[factultiesCombo.SelectedIndex].Field<int>("id");
                refreshDeps();
                refreshTutors();
                refreshCourses();
                refreshGroups();
                refreshStudents();
            }
            catch (Exception ex)
            {

            }
        }

        private void saveCourseButton_Click(object sender, EventArgs e)
        {
            if (changeCourseNameBox.Text == "")
                MessageBox.Show("Назва не може бути пустою!");
            else if (MessageBox.Show("Зберегти змiни?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataTable dt = (DataTable)tutorsComboBox.DataSource;
                    DataTable dt2 = (DataTable)changeCoursesListBox.DataSource;
                    int tutid = dt.Rows[tutorsComboBox.SelectedIndex].Field<int>("id");
                    int kurid = dt2.Rows[changeCoursesListBox.SelectedIndex].Field<int>("id");
                    string query = "UPDATE `courses` SET `name` =\'" + MySQLEscape(changeCourseNameBox.Text) + "\', id_tutors = " + tutid.ToString() + " WHERE `id` = " + kurid.ToString();
                    MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                    MySqlCommand sqlCom = new MySqlCommand(query, connection);
                    connection.Open();
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                    refreshCourses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            passwordBox.Text = newPassword(new Random());
            Clipboard.SetText(passwordBox.Text);
            MessageBox.Show("Пароль згенеровано та скопiйовано. Для продовження збережiть змiни");
        }

        private void newFacButton_Click(object sender, EventArgs e)
        {
            newFacForm NF = new newFacForm();
            NF.ShowDialog();
            try
            {
                string selQuery = "SELECT * FROM facutlies";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(sqlCom);
                DataSet tempDS = new DataSet(), tempDS2 = new DataSet();
                adapt.Fill(tempDS);
                adapt.Fill(tempDS2);
                factultiesCombo.DataSource = tempDS.Tables[0];
                factultiesCombo.DisplayMember = "name";
                facsListBox.DataSource = tempDS2.Tables[0];
                facsListBox.DisplayMember = "name";
                DataTable tdt = (DataTable)factultiesCombo.DataSource;
                facultyID = tdt.Rows[0].Field<int>("id");
                connection.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void tutorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void factultiesCombo_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteFacButton_Click(object sender, EventArgs e)
        {

        }

        private void clearNewRecFields()
        {
            recNewPasswordBox.Text = "";
            recOldPasswordBox.Text = "";
            recConfirmPasswordBox.Text = "";
        }

        private void recChangePassButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginForm.sha1(recOldPasswordBox.Text) != admin_hash)
                {
                    MessageBox.Show("Невiрно введений пароль!");
                    clearNewRecFields();
                    return;
                }
                if (recNewPasswordBox.Text == "")
                {
                    MessageBox.Show("Пароль не може бути пустим!");
                    clearNewRecFields();
                    return;
                }
                if (recNewPasswordBox.Text != recConfirmPasswordBox.Text)
                {
                    MessageBox.Show("Введенi паролi не спiвпадають!");
                    clearNewRecFields();
                    return;
                }
                string selQuery = "";
                if (isRector)
                    selQuery = "UPDATE univer_admins SET password = \"" + LoginForm.sha1(recNewPasswordBox.Text) + "\" WHERE id=" + admin_id.ToString();
                else
                    selQuery = "UPDATE deanery_admins SET password = \"" + LoginForm.sha1(recNewPasswordBox.Text) + "\" WHERE id=" + admin_id.ToString();
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand sqlCom = new MySqlCommand(selQuery, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Пароль змiнено!");
                admin_hash = LoginForm.sha1(recNewPasswordBox.Text);
                clearNewRecFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!");
            }
        }

        private void clearNewAdmFields()
        {
            newRecLogBox.Text = "";
            newRecConfBox.Text = "";
            newRecPassBox.Text = "";
        }

        private void refreshRecs()
        {
            if (isRector)
            {
                string q = "SELECT * FROM univer_admins WHERE id !=" + admin_id.ToString();
                MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand comm = new MySqlCommand(q, conn);
                conn.Open();
                MySqlDataAdapter adapt2 = new MySqlDataAdapter(comm);
                DataSet tempDS3 = new DataSet();
                adapt2.Fill(tempDS3);
                recsCombo.DataSource = tempDS3.Tables[0];
                recsCombo.DisplayMember = "login";
                conn.Close();
            }
            else
            {
                string q = "SELECT * FROM deanery_admins WHERE id_facutlies =" + facultyID + " AND id !=" + admin_id.ToString();
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                MySqlCommand com = new MySqlCommand(q, con);
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(com);
                DataSet tempDS = new DataSet();
                adapt.Fill(tempDS);
                recsCombo.DataSource = tempDS.Tables[0];
                recsCombo.DisplayMember = "login";
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                if (newRecLogBox.Text == "")
                {
                    MessageBox.Show("Логiн не може бути пустим!");
                    clearNewAdmFields();
                    return;
                }
                if (newRecPassBox.Text == "")
                {
                    MessageBox.Show("Пароль не може бути пустим!");
                    clearNewAdmFields();
                    return;
                }
                if (newRecPassBox.Text != newRecConfBox.Text)
                {
                    MessageBox.Show("Паролi не спiвпадають!");
                    clearNewAdmFields();
                    return;
                }
                string query = "";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                if (isRector)
                    query = "INSERT INTO univer_admins(login,password) VALUES(\"" + MySQLEscape(newRecLogBox.Text) + "\", \"" + LoginForm.sha1(newRecPassBox.Text) + "\")";
                else
                    query = "INSERT INTO deanery_admins(login,password,id_facutlies) VALUES(\"" + MySQLEscape(newRecLogBox.Text) + "\", \"" + LoginForm.sha1(newRecPassBox.Text) + "\", " + facultyID + ")";
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Адмiнiстратора додано!");
                clearNewAdmFields();
                refreshRecs();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!");
            }

        }

        private void DeleteRecBut_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)recsCombo.DataSource;
            if ((dt == null) | (dt.Rows.Count<1) |(recsCombo.Items.Count<1))
            {
                MessageBox.Show("Не обраний адмiнiстратор!");
                return;
            }
            if (MessageBox.Show("Видалити адмiнiстратора?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = dt.Rows[recsCombo.SelectedIndex].Field<int>("id");
                string query = "";
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                if (isRector)
                    query = "DELETE FROM univer_admins WHERE id=" + id.ToString();
                else
                    query = "DELETE FROM deanery_admins WHERE id=" + id.ToString();
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Адмiнiстратора видалено!");
                refreshRecs();
            }
        }

        private void refreshFacAdmins()
        {
            if (admFacsCombo.SelectedIndex == -1) return;
            DataTable dt = (DataTable)admFacsCombo.DataSource;
            int id = dt.Rows[admFacsCombo.SelectedIndex].Field<int>("id");
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            string query = "SELECT * FROM deanery_admins WHERE id_facutlies=" + id.ToString();
            MySqlCommand sqlCom = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(sqlCom);
            DataSet tempDS = new DataSet();
            adapt.Fill(tempDS);
            facAdmsCombo.DataSource = tempDS.Tables[0];
            facAdmsCombo.DisplayMember = "login";
            connection.Close();
        }

        private void admFacsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFacAdmins();

        }

        private void deleteFacAdm_Click(object sender, EventArgs e)
        {
            if (facAdmsCombo.SelectedIndex == -1) return;
            if (MessageBox.Show("Видалити адмiнiстратора?", "Пiдтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                DataTable dt = (DataTable)facAdmsCombo.DataSource;
                int id = dt.Rows[facAdmsCombo.SelectedIndex].Field<int>("id");
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                string query = "DELETE FROM deanery_admins WHERE id=" + id.ToString();
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Адмiнiстратор видалений!");
                refreshFacAdmins();
            }
        }

        private void clearLastFields()
        {
            newFacAdmConfirmBox.Text = "";
            newFacAdmLogBox.Text = "";
            newFacAdmPassBox.Text = "";
        }

        private void saveNewFacAdm_Click(object sender, EventArgs e)
        {
            if (admFacsCombo.SelectedIndex == -1) return;
            try
            {
                if (newFacAdmLogBox.Text == "")
                {
                    MessageBox.Show("Логiн не може бути пустим!");
                    clearLastFields();
                    return;
                }
                if (newFacAdmPassBox.Text == "")
                {
                    MessageBox.Show("Пароль не може бути пустим!");
                    clearLastFields();
                    return;
                }
                if (newFacAdmPassBox.Text != newFacAdmConfirmBox.Text)
                {
                    MessageBox.Show("Паролi не спiвпадають!");
                    clearLastFields();
                    return;
                }
                string query = "";
                DataTable dt = (DataTable)admFacsCombo.DataSource;
                int fac_id = dt.Rows[admFacsCombo.SelectedIndex].Field<int>("id"); 
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
                query = "INSERT INTO deanery_admins(login,password,id_facutlies) VALUES(\"" + MySQLEscape(newFacAdmLogBox.Text) + "\", \"" + LoginForm.sha1(newFacAdmPassBox.Text) + "\", " + fac_id + ")";
                MySqlCommand sqlCom = new MySqlCommand(query, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Адмiнiстратора додано!");
                clearLastFields();
                refreshFacAdmins();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!");
            }
        }

        private void changeFacNameBut_Click(object sender, EventArgs e)
        {
            if (facsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не обраний факультет!");
                return;
            }
            string query = "";
            DataTable dt = (DataTable)facsListBox.DataSource;
            int fac_id = dt.Rows[facsListBox.SelectedIndex].Field<int>("id");
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            query = "UPDATE facutlies SET name=\""+MySQLEscape(textBox1.Text)+"\" WHERE id="+fac_id.ToString();
            MySqlCommand sqlCom = new MySqlCommand(query, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();

            query = "SELECT * FROM facutlies";
            sqlCom = new MySqlCommand(query, connection);
            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet facDS1 = new DataSet(), facDS2 = new DataSet();
            dapt.Fill(facDS1);
            dapt.Fill(facDS2);
            factultiesCombo.DataSource = facDS1.Tables[0];
            factultiesCombo.DisplayMember = "name";
            facsListBox.DataSource = facDS2.Tables[0];
            facsListBox.DisplayMember = "name";
            connection.Close();

        }

        private void facsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (facsListBox.SelectedIndex == -1) return;
                else textBox1.Text = facsListBox.GetItemText(facsListBox.SelectedItem);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void charsButton_Click(object sender, EventArgs e)
        {
            if (!courseHasAnswers(chosenCourse)) return;
            string selQuery1 = @"SELECT names.name2, COUNT(ans.a32) as COUNT, a32
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a32
WHERE ans.id_courses = " + chosenCourse.ToString()+
"\nGROUP BY a32";

            string selQuery2 = @"SELECT names.name2, COUNT(ans.a33) as COUNT, a33 
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a33
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a33";

            string selQuery3 = @"SELECT names.name3, COUNT(ans.a34) as COUNT, a34
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a34
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a34";

            string selQuery4 = @"SELECT names.name4, COUNT(ans.a35) as COUNT, a35
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a35
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a35";

            string selQuery5 = @"SELECT names.name5, COUNT(ans.a36) as COUNT, a36
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a36
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a36";

            string selQuery6 = @"SELECT names.name6, COUNT(ans.a37) as COUNT, a37 
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a37
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a37";

            string selQuery7 = @"SELECT names.name6, COUNT(ans.a38) as COUNT, a38
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a38
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a38";

            string selQuery8 = @"SELECT names.name7, COUNT(ans.a39) as COUNT, a39
FROM answers ans
INNER JOIN ansnamesai names ON
names.number = ans.a39
WHERE ans.id_courses = " + chosenCourse.ToString() +
"\nGROUP BY a39";

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(selQuery1, connection);
            connection.Open();

            MySqlDataAdapter dapt = new MySqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            dapt.Fill(ds);

            DataSet ds2 = new DataSet();
            sqlCom = new MySqlCommand(selQuery2, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds2);

            DataSet ds3 = new DataSet();
            sqlCom = new MySqlCommand(selQuery3, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds3);

            DataSet ds4 = new DataSet();
            sqlCom = new MySqlCommand(selQuery4, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds4);

            DataSet ds5 = new DataSet();
            sqlCom = new MySqlCommand(selQuery5, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds5);

            DataSet ds6 = new DataSet();
            sqlCom = new MySqlCommand(selQuery6, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds6);

            DataSet ds7 = new DataSet();
            sqlCom = new MySqlCommand(selQuery7, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds7);

            DataSet ds8 = new DataSet();
            sqlCom = new MySqlCommand(selQuery8, connection);
            dapt = new MySqlDataAdapter(sqlCom);
            dapt.Fill(ds8);


            string[] lquest = new string[8];
            for (int i = 0; i < 8; i++)
                lquest[i] = questions[i + 31];

            JCharts charsCharts = new JCharts(chosenCourse, ds, ds2, ds3, ds4, ds5, ds6, ds7, ds8, lquest);
            charsCharts.Show();
            connection.Close();
        }


    }
}
