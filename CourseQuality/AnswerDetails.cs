using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseQuality
{
    public partial class AnswerDetails : Form
    {
        private int courseId;
        public AnswerDetails()
        {
            InitializeComponent();
        }
        public AnswerDetails(DataSet dSet, string quest, int c)
        {
            InitializeComponent();
            richTextBox1.Text = quest;
            dataGridView1.DataSource = dSet;
            dataGridView1.DataMember = dSet.Tables[0].TableName;
            dataGridView1.Columns[0].HeaderText = "Варіант відповіді";
            dataGridView1.Columns[1].HeaderText = "Відповіло осіб";
            dataGridView1.Columns[2].Visible = false;
            courseId = c;
        }

        private void OkB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openNamesButton_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)dataGridView1.DataSource;
            StudDetailsForm form = new StudDetailsForm(ds.Tables[0],courseId);
            form.ShowDialog();
        }
    }
}
