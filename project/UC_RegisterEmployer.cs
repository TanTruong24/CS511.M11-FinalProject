using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class UC_RegisterEmployer : UserControl
    {
        private static UC_RegisterEmployer _instance;
        public static UC_RegisterEmployer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_RegisterEmployer();
                return _instance;
            }
        }

        DataTable DataAccEmployer = new DataTable();
        string logoPath = "";
        string evidencePath = "";


        public DataTable getDataAccEmployer
        {
            get
            {
                return DataAccEmployer;
            }
        }
        public UC_RegisterEmployer()
        {
            InitializeComponent();
            AddColumnData();
            UCRegEmp_lb_Error.Visible = false;
        }
        void AddColumnData()
        {
            DataAccEmployer.Columns.Add("company_name", typeof(string));
            DataAccEmployer.Columns.Add("company_web", typeof(string));
            DataAccEmployer.Columns.Add("full_name", typeof(string));
            DataAccEmployer.Columns.Add("email", typeof(string));
            DataAccEmployer.Columns.Add("password", typeof(string));
            DataAccEmployer.Columns.Add("phone", typeof(string));
            DataAccEmployer.Columns.Add("address", typeof(string));
            DataAccEmployer.Columns.Add("evidence_name", typeof(string));
            DataAccEmployer.Columns.Add("logo_name", typeof(string));
        }
        void ImportDataEmployer()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccEmp = Path.Combine(executableLocation, "data_employers.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int coutRowAcc = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= coutRowAcc; i++)  // <= coutRowAcc
            {
                row = DataAccEmployer.NewRow();
                row["company_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["company_web"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["full_name"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["email"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["password"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["phone"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["address"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["evidence_name"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["logo_name"] = excelRange.Cells[i, 5].Value2.ToString(); //string

                DataAccEmployer.Rows.Add(row);
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
        public void InsertAccExcel()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccEmp = Path.Combine(executableLocation, "data_employers.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int row = excelRange.Rows.Count;

            excelApp.Cells[row + 1, 1] = UCRegEmp_tb_CompanyName.Text;
            excelApp.Cells[row + 1, 2] = UCRegEmp_tb_Web.Text;
            excelApp.Cells[row + 1, 3] = UCRegEmp_tb_FullName.Text;
            excelApp.Cells[row + 1, 4] = UCRegEmp_tb_Email.Text;
            excelApp.Cells[row + 1, 5] = UCRegEmp_tb_Password.Text;
            excelApp.Cells[row + 1, 6] = UCRegEmp_tb_Phone.Text;
            excelApp.Cells[row + 1, 7] = UCRegEmp_tb_Address.Text;
            excelApp.Cells[row + 1, 8] = UCRegEmp_lb_FileEnvidenceName.Text;
            excelApp.Cells[row + 1, 9] = UCRegEmp_lb_FileLogoName.Text;

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
        public void setOrigin()
        {
            ImportDataEmployer();
            UCRegEmp_lb_Error.Visible = false;
            UCRegEmp_tb_CompanyName.Text = "";
            UCRegEmp_tb_Web.Text = "";
            UCRegEmp_tb_FullName.Text = "";
            UCRegEmp_tb_Email.Text = "";
            UCRegEmp_tb_Password.Text = "";
            UCRegEmp_tb_Phone.Text = "";
            UCRegEmp_tb_Address.Text = "";
            UCRegEmp_lb_FileLogoName.Text = "";
            UCRegEmp_lb_FileEnvidenceName.Text = "";
        }
        public bool checkInfo()
        {
            ImportDataEmployer();
            bool check = false;
            if (UCRegEmp_tb_Web.Text == "")
            {
                UCRegEmp_tb_Web.Text = "none";
            }
            if (UCRegEmp_tb_FullName.Text.Length < 5)
            { 
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ Họ và Tên";
            }
            else if (UCRegEmp_tb_Phone.Text.Length < 9)
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ Số điện thoại ";
            }
            else if (UCRegEmp_tb_Address.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ Địa chỉ";
            }
            else if (UCRegEmp_tb_Email.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ Email";
            }
            else if (UCRegEmp_tb_Password.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ mật khẩu";
            }
            else if (UCRegEmp_tb_CompanyName.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng nhập đầy đủ tên công ty";
            }
            else if (UCRegEmp_lb_FileEnvidenceName.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng chọn minh chứng";
            }
            else if (UCRegEmp_lb_FileLogoName.Text == "")
            {
                UCRegEmp_lb_Error.Visible = true;
                UCRegEmp_lb_Error.Text = "Vui lòng chọn logo công ty";
            }
            else
            {
                check = true;
                for (int i = 0; i < DataAccEmployer.Rows.Count; i++)
                {
                    if (DataAccEmployer.Rows[i]["email"].ToString() == UCRegEmp_tb_Email.Text)
                    {
                        UCRegEmp_lb_Error.Visible = true;
                        UCRegEmp_lb_Error.Text = "Email đã được đăng ký";
                        check = false;
                        break;
                    }
                }
            }
            if (check)
            {
                UCRegEmp_lb_Error.Visible = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UCRegEmp_bt_ChooseEvidence_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;
                string ext = Path.GetExtension(filePath);
                if (ext != ".doc" && ext != ".docx" && ext != ".pdf" && ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".jpe" && ext != ".jfif")
                {
                    UCRegEmp_lb_FileEnvidenceName.Text = "Vui lòng chọn ảnh đúng yêu cầu JPEG/PNG hoặc MS Word/PDF";
                    UCRegEmp_lb_FileEnvidenceName.ForeColor = Color.Red;
                }
                else
                {
                    evidencePath = filePath;
                    UCRegEmp_lb_FileEnvidenceName.Text = Path.GetFileName(filePath);
                    UCRegEmp_lb_FileEnvidenceName.ForeColor = Color.Black;
                    CopyFile(evidencePath, UCRegEmp_lb_FileEnvidenceName.Text, 1);
                }
            }
        }

        private void UCRegEmp_bt_ChooseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;
                string ext = Path.GetExtension(filePath);
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".jpe" && ext != ".jfif")
                {
                    UCRegEmp_lb_FileLogoName.Text = "Vui lòng chọn ảnh đúng yêu cầu JPEG hoặc PNG";
                    UCRegEmp_lb_FileLogoName.ForeColor = Color.Red;
                }
                else
                {
                    logoPath = filePath;
                    UCRegEmp_lb_FileLogoName.Text = Path.GetFileName(filePath);
                    UCRegEmp_lb_FileLogoName.ForeColor = Color.Black;
                    CopyFile(logoPath, UCRegEmp_lb_FileLogoName.Text, 0);
                }
            }
        }
        public void CopyFile(string sourceFile, string fileName, int check)
        {
            string targetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (check == 0)
            {
                targetPath += "/logo";
            }
            else
            {
                targetPath += "/evidence";
            }
            
            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true);
        }
        public void insertInfoCompany()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccEmp = Path.Combine(executableLocation, "data_info_company.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            //int row = excelRange.Rows.Count;
            ExcelApp.Range r = (ExcelApp.Range)excelSheet.Rows[2];
            r.Insert();

            excelApp.Cells[2, 1] = UCRegEmp_lb_FileLogoName.Text;
            excelApp.Cells[2, 2] = UCRegEmp_tb_CompanyName.Text;
            excelApp.Cells[2, 3] = "none";
            excelApp.Cells[2, 4] = "none";
            excelApp.Cells[2, 5] = "none";
            excelApp.Cells[2, 6] = "none";
            excelApp.Cells[2, 7] = "none";
            excelApp.Cells[2, 8] = "none";
            excelApp.Cells[2, 9] = "none";

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
        private void UCRegEmp_bt_SignIn_Click(object sender, EventArgs e)
        {
            if (checkInfo())
            {
                InsertAccExcel();
                insertInfoCompany();
                MessageBox.Show("Đăng ký Nhà tuyển dụng thành công. Vui lòng đợi Quản trị viên kiểm duyệt thông tin của bạn");
                setOrigin();
            }
        }
    }
}
