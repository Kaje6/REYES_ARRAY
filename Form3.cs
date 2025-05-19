using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace REYES_ARRAY
{
    public partial class Form3: Form
    {
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        public Form3()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[0];

            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Please input a username.");
            }
            else
            {
                if (txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("Please input a password.");
                }
            }


            int row = sheet.Rows.Length;
            bool log = false;

            for (int i = 2; i <= row; i++)
            {
                if (sheet.Range[i, 9].Value == txtUsername.Text && sheet.Range[i, 10].Value == txtPassword.Text)
                {
                    
                    log = true;
                    Form1 frm1 = new Form1();
                    DisplayIt.CurrentUser = txtUsername.Text;
                    DisplayIt.DisplayName = sheet.Range[i, 1].Value;
                    DisplayIt.ProfilePath = sheet.Range[i, 14].Value;
                    MyLogs logs = new MyLogs();
                    logs.insertLog(DisplayIt.CurrentUser, "Logged in.");
                    break;
                }
                else
                {
                    log = false;

                }
            }
            if (log == true)
            {

                MessageBox.Show("Successfully logged in.", "Logged in.", MessageBoxButtons.OK , MessageBoxIcon.Information);
                Form4 frm4 = new Form4();
                this.Hide();
                frm4.Show();

            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
