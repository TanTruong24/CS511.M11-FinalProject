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
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;

namespace project
{
    public partial class FormApplyJob : Form
    {
        public FormApplyJob()
        {
            InitializeComponent();
        }

        string fileCVPath = "";
        string company_name = "";
        bool check = false;
        DataTable DataNotifyApplyCV = new DataTable();
        DataTable DataCompanyProfile = new DataTable();


        private void FormApplyJob_Load(object sender, EventArgs e)
        {
        }
        public void setTitle(string title, string companyName)
        {
            FormApply_Title.Text = title;
            company_name = companyName;
        }
        private void FormApply_bt_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;
                string ext = Path.GetExtension(filePath);
                if (ext != ".pdf")
                {
                    FormApply_tb_FileName.Text = "Vui lòng chọn lại CV đúng yêu cầu";
                    FormApply_tb_FileName.ForeColor = Color.Red;
                }
                else
                {
                    FormApply_tb_FileName.Text = Path.GetFileName(filePath);
                    fileCVPath = filePath;
                    FormApply_tb_FileName.ForeColor = Color.Black;
                    check = true;
                    CopyFile(filePath, FormApply_tb_FileName.Text);
                }
                
            }
        }
        //*************************************
        //Them du lieu
        public void CopyFile(string sourceFile, string fileName)
        {
            string targetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            targetPath += "/CV";

            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true);
        }
        public string getCurrentDateTime()
        {
            return string.Format("{0}-{1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"));
        }
        public void InsertAccExcel()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccEmp = Path.Combine(executableLocation, "data_applyCV.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int row = excelRange.Rows.Count;

            excelApp.Cells[row + 1, 1] = company_name;
            excelApp.Cells[row + 1, 2] = FormApply_Title.Text;
            excelApp.Cells[row + 1, 3] = FormApply_tb_UserName.Text;
            excelApp.Cells[row + 1, 4] = FormApply_tb_Email.Text;
            excelApp.Cells[row + 1, 5] = FormApply_rtb_Describe.Text;
            excelApp.Cells[row + 1, 6] = getCurrentDateTime();
            excelApp.Cells[row + 1, 7] = FormApply_tb_FileName.Text;
            

            //ExcelApp.Range r = (ExcelApp.Range)excelSheet.Rows[row];
            //r.Insert();

            //after reading, relaase the excel project
            excelBook.Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            excelBook.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);
        }


        //********************************************
        //Gửi CV qua mail
        // Chú ý chỉnh sửa lại địa chỉ mail theo công ty và member sửa dụng
        public void EmailSendCV()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("nt6926408@gmail.com");
                mail.To.Add("nt7508888@gmail.com");
                mail.Subject = "[ITJobs] - " + FormApply_tb_UserName.Text +  " - " + FormApply_Title.Text; //Title
                mail.Body = FormApply_rtb_Describe.Text;

                Attachment attachment;
                attachment = new Attachment(fileCVPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("nt6926408@gmail.com", "01646114846**");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send email. Error : " + ex);
            }
        }
        private void FormApply_bt_SendCV_Click(object sender, EventArgs e)
        {
            if (check)
            {
                EmailSendCV();
                InsertAccExcel();
                MessageBox.Show("Bạn đã gửi CV thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn file CV");
            }
           
        }
    }
}
