using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;

namespace project
{
    public partial class UC_RegisterMember : UserControl
    {
        private static UC_RegisterMember _instance;
        public static UC_RegisterMember Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_RegisterMember();
                return _instance;
            }
        }

        public UC_RegisterMember()
        {
            InitializeComponent();
            AddColumnData();
        }

        DataTable DataAccMember = new DataTable();
        int coutRowAcc = 0;
        
        void AddColumnData()
        {
            DataAccMember.Columns.Add("full_name", typeof(string));
            DataAccMember.Columns.Add("email", typeof(string));
            DataAccMember.Columns.Add("password", typeof(string));
            DataAccMember.Columns.Add("phone", typeof(string));
            DataAccMember.Columns.Add("address", typeof(string));
        }
        public DataTable getDataAccMem
        {
            get
            {
                return DataAccMember;
            }
        }
        void ImportDataMember()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccMem = Path.Combine(executableLocation, "data_members.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccMem);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            coutRowAcc = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= coutRowAcc; i++)  // <= coutRowAcc
            {
                row = DataAccMember.NewRow();
                row["full_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["email"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["password"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["phone"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["address"] = excelRange.Cells[i, 5].Value2.ToString(); //string

                DataAccMember.Rows.Add(row);
            }

            //after reading, relaase the excel project
            GC.Collect();
            GC.WaitForPendingFinalizers();
            excelBook.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);
        }
        public void setOrigin()
        {
            ImportDataMember();
            UCRegMem_lb_Error.Visible = false;
            UCRegMem_tb_FullName.Text = "";
            UCRegMem_tb_Phone.Text = "";
            UCRegMem_tb_Email.Text = "";
            UCRegMem_tb_Address.Text = "";
            UCRegMem_tb_Password.Text = "";
        }
        public bool checkInfo()
        {
            ImportDataMember();
            bool check = false;
            if (UCRegMem_tb_FullName.Text.Length < 5)
            {
                UCRegMem_lb_Error.Visible = true;
                UCRegMem_lb_Error.Text = "Vui lòng nhập đầy đủ Họ và Tên";
            }
            else if (UCRegMem_tb_Phone.Text.Length < 10)
            {
                UCRegMem_lb_Error.Visible = true;
                UCRegMem_lb_Error.Text = "Vui lòng nhập đầy đủ Số điện thoại ";
            }
            else if (UCRegMem_tb_Address.Text == "")
            {
                UCRegMem_lb_Error.Visible = true;
                UCRegMem_lb_Error.Text = "Vui lòng nhập đầy đủ Địa chỉ";
            }
            else if (UCRegMem_tb_Email.Text == "")
            {
                UCRegMem_lb_Error.Visible = true;
                UCRegMem_lb_Error.Text = "Vui lòng nhập đầy đủ Email";
            }
            else if (UCRegMem_tb_Password.Text == "")
            {
                UCRegMem_lb_Error.Visible = true;
                UCRegMem_lb_Error.Text = "Vui lòng nhập đầy đủ mật khẩu";
            }
            else
            {
                check = true;
                for (int i = 0; i < DataAccMember.Rows.Count; i++)
                {
                    if (DataAccMember.Rows[i]["email"].ToString() == UCRegMem_tb_Email.Text)
                    {
                        UCRegMem_lb_Error.Visible = true;
                        UCRegMem_lb_Error.Text = "Email đã được đăng ký";
                        check = false;
                        break;
                    }
                }
            }
            if (check)
            {
                UCRegMem_lb_Error.Visible = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EmailSendCV()
        {
            string body =   "Dear " + UCRegMem_tb_FullName.Text + ",\n" +
                            "Cảm ơn bạn đã đăng ký thành viên của ITJobs.\n" + 
                            "Thông tin tài khoản của bạn:\n"+
                            "Email đăng nhập: " + UCRegMem_tb_Email.Text +
                            "\nMật khẩu: " + UCRegMem_tb_Password.Text;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("nt6926408@gmail.com");
                mail.To.Add(UCRegMem_tb_Email.Text);
                mail.Subject = "[ITJobs] - Xác nhận đăng ký tài khoản thành công";
                mail.Body = body;

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
        public void InsertAccExcel()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccMem = Path.Combine(executableLocation, "data_members.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccMem);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int row = excelRange.Rows.Count;

            excelApp.Cells[row+1, 1] = UCRegMem_tb_FullName.Text;
            excelApp.Cells[row+1, 2] = UCRegMem_tb_Email.Text;
            excelApp.Cells[row+1, 3] = UCRegMem_tb_Password.Text;
            excelApp.Cells[row+1, 4] = UCRegMem_tb_Phone.Text;
            excelApp.Cells[row+1, 5] = UCRegMem_tb_Address.Text;

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
        private void UCRegMem_bt_SignIn_Click(object sender, EventArgs e)
        {
            if (checkInfo())
            {
                InsertAccExcel();
                EmailSendCV();
                MessageBox.Show("Đăng ký thành viên thành công. \nChúng tôi đã gửi mail thông báo đến bạn. Vui lòng trở lại trang Đăng nhập để tiếp tục");
                setOrigin();
            }
        }
    }
}
