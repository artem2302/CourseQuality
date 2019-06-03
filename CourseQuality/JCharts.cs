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
    public partial class JCharts : Form
    {
        private string[] qsts;
        private int courseID;
        private DataSet dSet1, dSet2, dSet3, dSet4, dSet5, dSet6, dSet7, dSet8;

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet2, qsts[1], courseID);
            adet.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet3, qsts[2], courseID);
            adet.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet4, qsts[3], courseID);
            adet.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet5, qsts[4], courseID);
            adet.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet6, qsts[5], courseID);
            adet.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet7, qsts[6], courseID);
            adet.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet8, qsts[7], courseID);
            adet.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnswerDetails adet = new AnswerDetails(dSet1, qsts[0], courseID);
            adet.Show();
        }

        public JCharts()
        {
            InitializeComponent();
        }

        public JCharts(int cid, DataSet ds1, DataSet ds2, DataSet ds3, DataSet ds4, 
            DataSet ds5, DataSet ds6, DataSet ds7, DataSet ds8, string[] qs)
        {
            InitializeComponent();
            Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            qsts = qs;
            courseID = cid;
            dSet1 = ds1;
            dSet2 = ds2;
            dSet3 = ds3;
            dSet4 = ds4;

            dSet5 = ds5;
            dSet6 = ds6;
            dSet7 = ds7;
            dSet8 = ds8;

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

          
            chart3.DataSource = dSet3;
            chart3.Series[0].XValueMember = dSet3.Tables[0].Columns[0].ToString();
            chart3.Series[0].YValueMembers = dSet3.Tables[0].Columns[1].ToString();
            chart3.Visible = true;
            chart3.DataBind();
   
            chart4.DataSource = dSet4;
            chart4.Series[0].XValueMember = dSet4.Tables[0].Columns[0].ToString();
            chart4.Series[0].YValueMembers = dSet4.Tables[0].Columns[1].ToString();
            chart4.Visible = true;
            chart4.DataBind();

            chart5.DataSource = dSet5;
            chart5.Series[0].XValueMember = dSet5.Tables[0].Columns[0].ToString();
            chart5.Series[0].YValueMembers = dSet5.Tables[0].Columns[1].ToString();
            chart5.Visible = true;
            chart5.DataBind();

            chart6.DataSource = dSet6;
            chart6.Series[0].XValueMember = dSet6.Tables[0].Columns[0].ToString();
            chart6.Series[0].YValueMembers = dSet6.Tables[0].Columns[1].ToString();
            chart6.Visible = true;
            chart6.DataBind();

            chart7.DataSource = dSet7;
            chart7.Series[0].XValueMember = dSet7.Tables[0].Columns[0].ToString();
            chart7.Series[0].YValueMembers = dSet7.Tables[0].Columns[1].ToString();
            chart7.Visible = true;
            chart7.DataBind();

            chart8.DataSource = dSet8;
            chart8.Series[0].XValueMember = dSet8.Tables[0].Columns[0].ToString();
            chart8.Series[0].YValueMembers = dSet8.Tables[0].Columns[1].ToString();
            chart8.Visible = true;
            chart8.DataBind();

            for (int i = 0; i < chart1.Series.Count; i++)
                chart1.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart2.Series.Count; i++)
                chart2.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart3.Series.Count; i++)
                chart3.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart4.Series.Count; i++)
                chart4.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart5.Series.Count; i++)
                chart5.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart6.Series.Count; i++)
                chart6.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart7.Series.Count; i++)
                chart7.Series[i]["PieLabelStyle"] = "Disabled";

            for (int i = 0; i < chart8.Series.Count; i++)
                chart8.Series[i]["PieLabelStyle"] = "Disabled";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
