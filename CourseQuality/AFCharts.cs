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

namespace CourseQuality
{
    public partial class AFCharts : Form
    {
        private int courseId;
        private DataSet dSet1, dSet2, dSet3, dSet4;
        private string[] questions;
        public int CourseId
        {
            set { courseId = value; }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void q1Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet1, questions[0], courseId);
            adet.Show();
        }

        private void q2Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet2, questions[1], courseId);
            adet.Show();
        }

        private void q3Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet3, questions[2], courseId);
            adet.Show();
        }

        private void q4Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet4, questions[3], courseId);
            adet.Show();
        }

        public AFCharts()
        {
            InitializeComponent();
        }
        public AFCharts(int cid, DataSet ds1, DataSet ds2, DataSet ds3, DataSet ds4, DataSet com_ds, string subj, string[]quests)
        {
            InitializeComponent();
            try
            {
                this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            }
            catch (Exception ex)
            {

            }

            questions = quests;

            label1.Text += subj + "\":";
            StringBuilder sb = new StringBuilder(subj);
            sb[0] = Char.ToUpper(sb[0]);
            Text = sb.ToString();

            courseId = cid;
            dSet1 = ds1;
            dSet2 = ds2;
            dSet3 = ds3;
            dSet4 = ds4;

            chart1.DataSource = dSet1;
            chart1.Series[0].XValueMember = dSet1.Tables[0].Columns[0].ToString();
            chart1.Series[0].YValueMembers = dSet1.Tables[0].Columns[1].ToString();
            chart1.Visible = true;
            chart1.DataBind();

            chart2.DataSource = dSet2;
            chart2.Series[0].XValueMember = dSet2.Tables[0].Columns[0].ToString();
            chart2.Series[0].YValueMembers = dSet2.Tables[0].Columns[1].ToString();
            chart2.Visible = true;
            chart2.DataBind();

            if (dSet3 != null)
            {
                chart3.DataSource = dSet3;
                chart3.Series[0].XValueMember = dSet3.Tables[0].Columns[0].ToString();
                chart3.Series[0].YValueMembers = dSet3.Tables[0].Columns[1].ToString();
                chart3.Visible = true;
                chart3.DataBind();
            }

            if (dSet4 != null)
            {
                chart4.DataSource = dSet4;
                chart4.Series[0].XValueMember = dSet4.Tables[0].Columns[0].ToString();
                chart4.Series[0].YValueMembers = dSet4.Tables[0].Columns[1].ToString();
                chart4.Visible = true;
                chart4.DataBind();
            }

            commentsListBox.DataSource = com_ds.Tables[0];
            commentsListBox.ValueMember = "ID";
            commentsListBox.DisplayMember = "COMMENT";

            if (commentsListBox.Items.Count == 0)
            {
                commentsListBox.DataSource = null;
                commentsListBox.Items.Add("Коментарi до даної теми вiдсутнi");
            }

            for (int i = 0; i<chart1.Series.Count; i++)
                chart1.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart2.Series.Count; i++)
                chart2.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart3.Series.Count; i++)
                chart3.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart4.Series.Count; i++)
                chart4.Series[i]["PieLabelStyle"] = "Disabled";

        }

        public void threeQuest()
        {
            tableLayoutPanel1.ColumnStyles[3].Width = 0;
        }

        public void twoQuest()
        {
            tableLayoutPanel1.ColumnStyles[3].Width = 0;
            tableLayoutPanel1.ColumnStyles[2].Width = 0;
        }

        private void AFCharts_Load(object sender, EventArgs e)
        {
               
        }
    }
}
