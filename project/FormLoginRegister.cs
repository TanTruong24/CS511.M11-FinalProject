using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace project
{
    public partial class FormLoginRegister : Form
    {
        public FormLoginRegister()
        {
            InitializeComponent();
            setDisplay();
            AddColumnData();
        }

        Form1 frmMember = new Form1();
        

        bool checkRegMem = false;
        DataTable DataAccMember = new DataTable();
        DataTable DataAccEmployer = new DataTable();

        public DataTable getDataAccMember
        {
            get
            {
                return DataAccMember;
            }
        }
        public DataTable getDataAccEmployer
        {
            get
            {
                return DataAccEmployer;
            }
        }
        public void setDisplay()
        {
            FormLogin_lb_Error.Visible = false;
            FormLogin_LinkLb_BackLogin.Visible = false;
        }
        void AddColumnData()
        {
            DataAccMember.Columns.Add("full_name", typeof(string));
            DataAccMember.Columns.Add("email", typeof(string));
            DataAccMember.Columns.Add("password", typeof(string));
            DataAccMember.Columns.Add("phone", typeof(string));
            DataAccMember.Columns.Add("address", typeof(string));

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
        void ImportDataAccMember()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccMem = Path.Combine(executableLocation, "data_members.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccMem);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int coutRowMem = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= coutRowMem; i++)  // <= coutRowAcc
            {
                row = DataAccMember.NewRow();
                row["full_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["email"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["password"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["phone"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["address"] = excelRange.Cells[i, 5].Value2.ToString(); //string

                DataAccMember.Rows.Add(row);
            }

            //after reading, relaase the excel project\
            GC.Collect();
            GC.WaitForPendingFinalizers();
            excelBook.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);
        }
        void ImportDataAccEmployer()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataAccEmp = Path.Combine(executableLocation, "data_employers.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int coutRowEmp = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= coutRowEmp; i++)  // <= coutRowAcc
            {
                row = DataAccEmployer.NewRow();
                row["company_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["company_web"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["full_name"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["email"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["password"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["phone"] = excelRange.Cells[i, 6].Value2.ToString(); //string
                row["address"] = excelRange.Cells[i, 7].Value2.ToString(); //string
                row["evidence_name"] = excelRange.Cells[i, 8].Value2.ToString(); //string
                row["logo_name"] = excelRange.Cells[i, 9].Value2.ToString(); //string

                DataAccEmployer.Rows.Add(row);
            }

            //after reading, relaase the excel project\
            GC.Collect();
            GC.WaitForPendingFinalizers();
            excelBook.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);
        }
        private void FormLogin_bt_SignIn_Click(object sender, EventArgs e)
        {
            if (FormLogin_tb_Email.Text == "admin" && FormLogin_tb_Password.Text == "123")
            {
                //MessageBox.Show("Đăng nhập thành công trang quản trị");
                //frmEmployer.ShowDialog();
                //this.Close();
            }
            for (int i = 0; i < DataAccEmployer.Rows.Count; i++)
            {
                string mail = DataAccEmployer.Rows[i]["email"].ToString();
                string pass = DataAccEmployer.Rows[i]["password"].ToString();
                if (FormLogin_tb_Email.Text == mail && FormLogin_tb_Password.Text == pass)
                {
                    FormEmployer frmEmployer = new FormEmployer();
                    MessageBox.Show("Đăng nhập thành công");
                    frmEmployer.setDataAccEmployer = DataAccEmployer;
                    frmEmployer.setDataJobs = frmMember.getDataJobs;
                    frmEmployer.setDataCompanyProfile = frmMember.getDataCompanyProfile;
                    frmEmployer.setEmail = mail;
                    frmEmployer.ShowDialog();
                    //this.Close();
                }
            }
            for (int i = 0; i < DataAccMember.Rows.Count; i++)
            {
                string mail = DataAccMember.Rows[i]["email"].ToString();
                string pass = DataAccMember.Rows[i]["password"].ToString();
                if (FormLogin_tb_Email.Text == mail && FormLogin_tb_Password.Text == pass)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmMember.setDataAccMember = DataAccMember;
                    frmMember.ShowDialog();
                    //this.Close();
                }
            }
            FormLogin_lb_Error.Visible = true;
        }

        private void FormLogin_LinkLb_RegMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkRegMem = true;
            FormLogin_LinkLb_BackLogin.Visible = true;
            UC_RegisterMember.Instance.setOrigin();
            if (!FormLogin_pn_home.Controls.Contains(UC_RegisterMember.Instance))
            {
                FormLogin_pn_home.Controls.Add(UC_RegisterMember.Instance);
                UC_RegisterMember.Instance.Dock = DockStyle.Fill;
                UC_RegisterMember.Instance.BringToFront();
            }
            else
            {
                UC_RegisterMember.Instance.BringToFront();
            }
        }

        private void FormLogin_LinkLb_RegEmployer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkRegMem = false;
            FormLogin_LinkLb_BackLogin.Visible = true;
            if (!FormLogin_pn_home.Controls.Contains(UC_RegisterEmployer.Instance))
            {
                FormLogin_pn_home.Controls.Add(UC_RegisterEmployer.Instance);
                UC_RegisterEmployer.Instance.Dock = DockStyle.Fill;
                UC_RegisterEmployer.Instance.BringToFront();
            }
            else
            {
                UC_RegisterEmployer.Instance.setOrigin();
                UC_RegisterEmployer.Instance.BringToFront();
            }
        }

        private void FormLogin_tb_UserName_TextChanged(object sender, EventArgs e)
        {
            setDisplay();
        }

        private void FormLogin_tb_Password_TextChanged(object sender, EventArgs e)
        {
            setDisplay();
        }

        private void FormLogin_LinkLb_BackLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataAccMember = UC_RegisterMember.Instance.getDataAccMem;
            DataAccEmployer = UC_RegisterEmployer.Instance.getDataAccEmployer;
            if (checkRegMem)
            {
                FormLogin_pn_home.Controls.Remove(UC_RegisterMember.Instance);
            }
            else
            {
                FormLogin_pn_home.Controls.Remove(UC_RegisterEmployer.Instance);
            }
            FormLogin_LinkLb_BackLogin.Visible = false;
        }

        private void FormLoginRegister_Load(object sender, EventArgs e)
        {
            ImportDataAccMember();
            ImportDataAccEmployer();
        }
    }
}
