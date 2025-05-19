using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace REYES_ARRAY
{
    public partial class Form4: Form
    {
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        Workbook book = new Workbook();
        public Form4()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(DisplayIt.ProfilePath) && File.Exists(DisplayIt.ProfilePath))
            {
                pcbProfile.Image = Image.FromFile(DisplayIt.ProfilePath);
            }

            lblBasketballNum.Text = showCount(0, 3, "Basketball").ToString();
            lblVolleyBallNum.Text = showCount(0, 3, "Volleyball").ToString();
            lblBadmintonNum.Text = showCount(0, 3, "Soccer").ToString();
            lblBsitNum.Text = showCount(0, 12, "BSIT").ToString();
            lblBscsNum.Text = showCount(0, 12, "BSCS").ToString();
            lblBscpeNum.Text = showCount(0, 12, "BSCPE").ToString();
            lblMaleNum.Text = showCount(0, 2, "Male").ToString();
            lblFemaleNum.Text = showCount(0, 2, "Female").ToString();
            lblWhiteNum.Text = showCount(0, 8, "White").ToString();
            lblBlackNum.Text = showCount(0, 8, "Black").ToString();
            lblBrownNum1.Text = showCount(0, 8, "Brown").ToString();


            lblActiveNum.Text = showCount(0, 13, "1").ToString();
            lblInactiveNum.Text = showCount(1, 13, "0",true).ToString();

            lblName.Text = DisplayIt.DisplayName;
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");






        }







        public int showCount(int worksheetIndex,int c, string val, bool countZeros = false)
        {
            book.LoadFromFile(ExcelFilePath);
            Worksheet sh = book.Worksheets[worksheetIndex];

            int row = sh.Rows.Length;
            int counter = 0;

            for (int i = 2; i <= row; i++)
            {
                string cellValue = sh.Range[i,c].Value?.Trim()?? "";
                
                if (countZeros && cellValue == "0")
                {
                    counter++;
                }
                else if (!countZeros && cellValue == val.Trim())
                {
                    counter++;
                }
               
            }

            return counter;

        }






        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Logged Out.");

            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();

        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Clicked the Active Form.");
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }



        private void btnInactive_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Clicked the Inactive Form.");
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Hide();
        }



        private void btnLogs_Click(object sender, EventArgs e)
        {
            MyLogs logs = new MyLogs();
            logs.insertLog(DisplayIt.CurrentUser, "Clicked logs.");

            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {

        }

        private void lblWhiteNum_Click(object sender, EventArgs e)
        {

        }

        private void lblInactive_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void lblActive_Click(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHobbies_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCourse_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblBsit_Click(object sender, EventArgs e)
        {

        }

        private void lblBscpe_Click(object sender, EventArgs e)
        {

        }

        private void lblBscs_Click(object sender, EventArgs e)
        {

        }

        private void lblBscsNum_Click(object sender, EventArgs e)
        {

        }

        private void lblBscpeNum_Click(object sender, EventArgs e)
        {

        }

        private void lblBsitNum_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void lblBasketballNum_Click(object sender, EventArgs e)
        {

        }

        private void lblVolleyBallNum_Click(object sender, EventArgs e)
        {

        }

        private void lblBadmintonNum_Click(object sender, EventArgs e)
        {

        }

        private void lblBadminton_Click(object sender, EventArgs e)
        {

        }

        private void lblVolleyBall_Click(object sender, EventArgs e)
        {

        }

        private void lblBasketball_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblBlack_Click(object sender, EventArgs e)
        {

        }

        private void lblBrown_Click(object sender, EventArgs e)
        {

        }

        private void lblWhite_Click(object sender, EventArgs e)
        {

        }

        private void lblBrownNum1_Click(object sender, EventArgs e)
        {

        }

        private void lblBlackNum_Click(object sender, EventArgs e)
        {

        }
    }
}
