using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace REYES_ARRAY
{
    internal class MyLogs
    {
        private const string ExcelFilePath = @"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx";
        public void insertLog(string user, string message)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(ExcelFilePath);
            Worksheet sheet = book.Worksheets[2];

            int row = sheet.Rows.Length + 1;
            sheet.Range[row, 1].Value = user;
            sheet.Range[row, 2].Value = message;
            sheet.Range[row, 3].Value = DateTime.Now.ToString("MM/dd/yyyy");
            sheet.Range[row, 4].Value = DateTime.Now.ToString("hh : mm : ss : tt");
            book.SaveToFile(ExcelFilePath, ExcelVersion.Version2016);

        }
    }
}
