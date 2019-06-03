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

namespace CourseQuality
{
    public partial class TestForm : Form
    {
        //TODO: rem from res
        private int hpressed;
        private int courseId, pageNumber, studId;
        private string qSubj, q1, q2, q3, q4, comQ, newQ, a1, a2, a3, a4, a5;
        private int[] answers;
        private string[] comments;
        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        public int StudId
        {
            set { studId = value; }
        }
        public TestForm()
        {
            InitializeComponent();

            hpressed = 0;


            courseId = 0;
            pageNumber = 1;
            setLabels("A. Навчання:", "1. Ви вважаєте цей модуль змагально та інтелектуально стимулюючим", "2. Ви вивчили щось, що ви вважаєте цінним",
                "3. Ваша зацікавленість в предметі збільшилась в результаті цього модуля", "4. Ви вивчили та зрозуміли матеріали по темі цього модуля",
                "Чи маєте ви якісь коментарі щодо навчального оточення модуля?");
            applyLabels();
            lastPanel.Hide();
            answers = new int[39];
            comments = new string[9];
        }
        private void applyLabels()
        {
            testGroupBox.Text = qSubj;
            q1Label.Text = q1;
            q2Label.Text = q2;
            q3Label.Text = q3;
            q4Label.Text = q4;
            comQLabel.Text = comQ;
        }
        private void setLabels(string qsubj, string qone, string qtwo, string qthree, string qfour, string comq)
        {
            qSubj = qsubj;
            q1 = qone;
            q2 = qtwo;
            q3 = qthree;
            q4 = qfour;
            comQ = comq;
        }
        private void setNewLabels(string q, string aone, string atwo, string athree, string afour, string afive)
        {
            newQ = q;
            a1 = aone;
            a2 = atwo;
            a3 = athree;
            a4 = afour;
            a5 = afive;
        }
        private void applyNewLabels()
        {
            lastGroupBox.Text = newQ;
            radioButton29.Text = a1;
            radioButton30.Text = a2;
            radioButton31.Text = a3;
            radioButton32.Text = a4;
            radioButton33.Text = a5;

        }
        private void reorganize()
        {
            switch (pageNumber)
            {
                case 7:
                    q4GroupBox.Hide();
                    q1GroupBox.Height += 15;

                    q2GroupBox.Height += 15;
                    q2GroupBox.Top += 30;

                    q3GroupBox.Height += 15;
                    q3GroupBox.Top += 50;
               break;
                case 8:
                    q3GroupBox.Hide();

                    q2GroupBox.Top += 80;
                    break;
                case 10:
                    lastPanel.Show();
                    break;
            }
        }

        private void loadQuestion()
        {
            switch (pageNumber)
            {
                case 2:
                    setLabels(
                        "B. Ентузіазм:",
                        "1. Викладач з ентузіазмом викладає модуль",
                        "2. Викладач динамічно і енергічно проводить заняття",
                        "3. Викладач покращує наглядність за допомогою гумору",
                        "4. Стиль викладання викладача притягує увагу протягом заняття",
                        "Чи маєте ви якісь коментарі щодо ентузіазму викладача?");
                    applyLabels();
                    break;
                case 3:
                    setLabels(
                        "C. Організація:",
                        "1. Пояснення викладача зрозумілі",
                        "2. Матеріали модуля добре підготовлені та точно пояснені",
                        "3. Запропоновані цілі погоджені з навчальним планом, тому ви знаєте, як продовжиться модуль",
                        "4. Лекції викладача доповнюються за допомогою нотаток",
                        "Чи маєте ви якісь коментарі щодо організації викладача?");
                    applyLabels();
                    break;
                case 4:
                    setLabels(
                        "D. Колективна взаємодія:",
                        "1. Студенти заохочені до участі в дискусіях",
                        "2. Студенти запрошені ділитися своїми ідеями та знаннями",
                        "3. Студенти заохочені задавати питання і отримують змістовні відповіді",
                        "4. Студенти заохочені виражати свої власні ідеї та/або запитувати викладача",
                        "Чи маєте ви якісь коментарі щодо колективної взаємодії в цього викладача?");
                    applyLabels();
                    break;
                case 5:
                    setLabels(
                        "E. Індивідуальний підхід",
                        "1. Викладач дружньо відноситься до кожного студента",
                        "2. Студенти можуть вільно звернутися за допомогою або порадою в позаурочний час",
                        "3. Викладач має істиний інтерес в індивідуальних студентах",
                        "4. Викладач доступний студентам під час роботи в години після занять",
                        "Чи маєте ви якісь коментарі щодо індивідуального підходу в цього викладача?");
                    applyLabels();
                    break;
                case 6:
                    setLabels(
                        "F. Повнота",
                        "1. Викладач порівнює різні теорії та їх наслідки",
                        "2. Викладач показує походження (або джерело) ідей(чи концепцій) розвинених в аудиторії під час лекції",
                        "3. Викладач показує точки зору, відмінні від його в разі необхідності",
                        "4. Викладач адекватно обговорює поточні сучасні розробки в галузі",
                        "Чи маєте ви якісь коментарі щодо повноти викладання цього курсу?");
                    applyLabels();
                    break;
                case 7:
                    setLabels(
                        "G. Іспити:",
                        "1. На скільки цінна реакція (коментарі) на іспитах (чи оцінюванні),\n тобто на скільки пропрацьованні помилки допущені на іспиті після його проведення",
                        "2. Методи оцінювання роботи студента є справедливими і відповідними",
                        "3. Матеріал іспитів/оцінки тестового модулю є змістовним, як і наголосив викладач",
                        " ",
                        "Чи маєте ви якісь коментарі щодо іспитів з цього курсу?");
                    applyLabels();
                    reorganize();
                    break;
                case 8:
                    setLabels(
                        "H. Призначення:",
                        "1. Необхідна(вказана викладачем) література для вивчення курсу є цінною",
                        "2. Читання, домашня роботота, і т. д., впливають на оцінку і розуміння предмету",
                        " ",
                        " ",
                        "Чи маєте ви якісь коментарі щодо призначення цього модуля?");
                    applyLabels();
                    reorganize();
                    break;
                case 9:
                    setLabels(
                        "I. Загальне",
                        "1. Як Вам цей курс порівняно з іншими курсами, які ви оцінювали в цьому тесті",
                        "2. Як Вам викладач порівняно з іншими викладачами, яких ви оцінювали в цьому тесті",
                        " ",
                        " ",
                        "Чи маєте ви якісь коментарі щодо загальної оцінки цього курсу?");
                    applyLabels();
                    break;
                case 10:
                    setLabels("J. Характеристика навчання та курсу:", " ", " ", " ", " ", " ");
                    applyLabels();
                    setNewLabels("1. Складність курсу, порівняно з іншими курсами, є: ",
                        "дуже легка",
                        "легка",
                        "середня",
                        "важка",
                        "дуже важка");
                    applyNewLabels();
                    reorganize();
                    break;
                case 11:
                    setNewLabels("2. Навантаженість курсу, порівняно з іншими, є: ",
                        "дуже легка",
                        "легка",
                        "середня",
                        "важка",
                        "дуже важка");
                    applyNewLabels();
                    break;
                case 12:
                    setNewLabels("3. Темп проходження курсу, порівняно з іншими, є: ",
                        "дуже повільний",
                        "повільний",
                        "помірний",
                        "швидкий",
                        "дуже швидкий");
                    applyNewLabels();
                    break;
                case 13:
                    setNewLabels("4. Необхідна кількість позааудиторних годин (на тиждень): ",
                        "Менше 10",
                        "10-20",
                        "20-30",
                        "30-40",
                        "Більше 40");
                    applyNewLabels();
                    break;
                case 14:
                    setNewLabels("5. Ваш рівень зацікавленості до теми, що стосується цього курсу: ",
                        "дуже низький",
                        "низький",
                        "середній",
                        "високий",
                        "дуже високий");
                    applyNewLabels();
                    break;
                case 15:
                    setNewLabels("6. Ваш середній бал: ",
                        "A",
                        "B",
                        "C",
                        "D",
                        "F");
                    applyNewLabels();
                    break;
                case 16:
                    setNewLabels("7. Бал, на який Ви сподівались: ",
                        "A",
                        "B",
                        "C",
                        "D",
                        "F");
                    applyNewLabels();
                    break;
                case 17:
                    setNewLabels("8. Скільки курсів у Вас було до цього? ",
                        "Менше 5",
                        "5-10",
                        "10-20",
                        "20-30",
                        "Бiльше 30");
                    applyNewLabels();
                    break;

            }
        }
        private void saveResult()
        {

            int i; 
            if (Enumerable.Range(1,9).Contains(pageNumber))
            {
                i = pageNumber * 4 - 4;
                comments[pageNumber-1] = commentBox.Text;
                var checkedRadio = new[] { q1GroupBox, q2GroupBox, q3GroupBox, q4GroupBox }
                    .SelectMany(g => g.Controls.OfType<RadioButton>().Where(r => r.Checked));
                foreach (var c in checkedRadio)
                    answers[i++] = int.Parse(c.Text);
            }
            else
            {   
                i = pageNumber+21;
                if (radioButton29.Checked)
                    answers[i] = 1;
                if (radioButton30.Checked)
                    answers[i] = 2;
                if (radioButton31.Checked)
                    answers[i] = 3;
                if (radioButton32.Checked)
                    answers[i] = 4;
                if (radioButton33.Checked)
                    answers[i] = 5;
            }
        }
        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void testGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void sendResults()
        {
            string insertAnswersString = @"INSERT INTO `answers` 
(`id_students`, `id_courses`, `a1`, `a2`, `a3`, `a4`, `a5`, `a6`, `a7`,
`a8`, `a9`, `a10`, `a11`, `a12`, `a13`, `a14`, `a15`, `a16`, `a17`, `a18`, `a19`,
`a20`, `a21`, `a22`, `a23`, `a24`, `a25`, `a26`, `a27`, `a28`, `a29`, `a30`, `a31`, `a32`, `a33`,
`a34`, `a35`, `a36`, `a37`, `a38`, `a39`)
VALUES("+ studId +", "+CourseId;
            foreach (int i in answers)
                insertAnswersString += ", " + i;
            insertAnswersString += ");\n";
            string insertCommentsString = @"INSERT INTO `comments`
(`id_students`,`id_courses`, `c1`,`c2`,`c3`,`c4`,`c5`,`c6`,`c7`,`c8`,`c9`)
VALUES(" + studId + ", " + CourseId;
            foreach (string s in comments)
                if (s.Length > 0)
                    insertCommentsString += ", \"" + AdminForm.MySQLEscape(s)+"\"";
                else insertCommentsString += ", NULL";
            insertCommentsString += ");";
            string resultingQuery = insertAnswersString + insertCommentsString;
            //MessageBox.Show(resultingQuery);
            
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.MainConnectionString);
            MySqlCommand sqlCom = new MySqlCommand(resultingQuery, connection);
         
            connection.Open();
            sqlCom.ExecuteNonQuery();

        }

        private void clearControls()
        {
            nextButton.Enabled = false;
            if (pageNumber < 10)
            {
                commentBox.Clear();
                var checkedRadio = new[] { q1GroupBox, q2GroupBox, q3GroupBox, q4GroupBox }
                 .SelectMany(g => g.Controls.OfType<RadioButton>().Where(r => r.Checked));
                foreach (var c in checkedRadio)
                    c.Checked = false;
                radioButton22.Checked = true;
                radioButton24.Checked = true;
                radioButton26.Checked = true;
                radioButton28.Checked = true;
            }
            else
            {
                 var checkedRadio = new[] { lastGroupBox }
                 .SelectMany(g => g.Controls.OfType<RadioButton>().Where(r => r.Checked));
                 foreach (var c in checkedRadio)
                     c.Checked = false;
                radioButton29.Checked = true;
            }
            nextButton.Enabled = true;
        }

        private void testOver()
        {
            nextButton.Enabled = false;
            MessageBox.Show("Тест завершено! Натиснiть ОК для вiдправки");
            sendResults();
            MessageBox.Show("Результати надiслано! Дякуємо за увагу!");
            Application.Exit();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            saveResult();
            clearControls();
            if (pageNumber >= 17)
                testOver();
            pageNumber++;
            loadQuestion();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if (hpressed != 9)
            {
                string help = @"Вітаємо Вас у програмi оцінювання якості курсів!
Дайте відповідь на запропоновані запитання наступним чином:
1 - Повністю незгоден / дуже погано
2 - Рішуче незгоден / погано
3 - Незгоден / недостатньо
4 - Згоден / прийнятно
5 - Рішуче згоден / добре
6 - Повністю згоден / дуже добре
Будьте уважні у виборі відповіді!";
                MessageBox.Show(help, "Допомога");
                if (hpressed<10) hpressed++;
            }
            else if (hpressed == 9)
            {
                MessageBox.Show(@"Будь с виду бестолков. И вольный хмель веков
Хоть пригоршнями пей, мороча простаков.
Поймет и бестолочь, тут без толку соваться:
«Что толку толковать тому, кто бестолков!»

Омар Хайям.");
              hpressed++;
            }
        }

        private void TestForm_Shown(object sender, EventArgs e)
        {
            string help = @"Вітаємо Вас у програмi оцінювання якості курсів!
Дайте відповідь на запропоновані запитання наступним чином:
1 - Повністю незгоден / дуже погано
2 - Рішуче незгоден / погано
3 - Незгоден / недостатньо
4 - Згоден / прийнятно
5 - Рішуче згоден / добре
6 - Повністю згоден / дуже добре
Будьте уважні у виборі відповіді!";
            MessageBox.Show(help, "Допомога");
        }
    }
}
