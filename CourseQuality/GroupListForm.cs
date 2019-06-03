using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CourseQuality
{
    public partial class GroupListForm : Form
    {
        public List<enterField> enterFields;
        public string group_name, fac_name;
        public GroupListForm(string gr_name)
        {
            group_name = gr_name;
            InitializeComponent();
            saveFileDialog1.FileName = "Список групи " + group_name;
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, webBrowser1.DocumentText);
        }

        private void GroupListForm_Load(object sender, EventArgs e)
        {
            string text = "    <!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\" > ";
           text += @"
    <html>
	<head>

     <meta charset=utf-8>
      <title>Список групи " + group_name + " </title>";
            text+=@"
	</head>
	<body>
	<p align = left>Факультет: "+fac_name +" <br>Група: "+group_name+" </p>" +
	@"<hr>
	<table border = 1 align = center width = 100% >
  <tr>
    <th>ПIБ</th>
    <th>Логiн</th>
    <th>Пароль</th>
  </tr>";

            foreach (var v in enterFields)
                text += "<tr><th>" + v.studentNameBox.Text + "</th><th>" + v.idNumberBox.Text + "</th><th>" + v.passwordBox.Text + "</th></tr>";

            text += @"
    </table>
	<hr>
	</body>
</html>";
            webBrowser1.DocumentText = text;
            MessageBox.Show("Список групи сформовано. Увага! Якщо список не буде збережено, то пiсля закриття цього вiкна продивитися паролi неможливо!");
        }
    }
}
