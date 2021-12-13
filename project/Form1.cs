using ExcelDataReader;
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
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace project
{
    public partial class Form1 : Form
    {
        DataTable DataJobs = new DataTable();
        DataTable DataCompanyProfile = new DataTable();
        DataTable DataAccMember = new DataTable();

        int CountRowsJobs = 0;
        int CountRowsCompany = 0;

        Dictionary<int, int> countCompanyJobs = new Dictionary<int, int>();

        List<PictureBox> LstCompanyLogo = new List<PictureBox>();
        List<TextBox> LstCompanyName = new List<TextBox>();
        List<Label> LstCompanyNumJobs = new List<Label>();
        List<Button> LstCompanySkill = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            AddColumnData();
            ImportDataJobs();
            ImportDataCompany();
            AddList();
            SetDisplay();
            SortCompanyJobs();
            setValueAnotherForm();
        }
        public DataTable setDataAccMember
        {
            set
            {
                DataAccMember = value;
            }
        }
        public DataTable getDataJobs
        {
            get
            {
                return DataJobs;
            }
        }
        public DataTable getDataCompanyProfile
        {
            get
            {
                return DataCompanyProfile;
            }
        }
        void AddColumnData()
        {
            DataJobs.Columns.Add("company_name", typeof(string));
            DataJobs.Columns.Add("title", typeof(string));
            DataJobs.Columns.Add("salary", typeof(string));
            DataJobs.Columns.Add("distance_time", typeof(string));
            DataJobs.Columns.Add("feature_new_text", typeof(string));
            DataJobs.Columns.Add("skill", typeof(string));
            DataJobs.Columns.Add("location_detail", typeof(string));
            DataJobs.Columns.Add("reason_job", typeof(string));
            DataJobs.Columns.Add("job_description", typeof(string));
            DataJobs.Columns.Add("skill_experience", typeof(string));
            DataJobs.Columns.Add("love_working", typeof(string));
            DataJobs.Columns.Add("slogan", typeof(string));

            DataCompanyProfile.Columns.Add("logo_name", typeof(string));
            DataCompanyProfile.Columns.Add("company_name", typeof(string));
            DataCompanyProfile.Columns.Add("location", typeof(string));
            DataCompanyProfile.Columns.Add("field", typeof(string));
            DataCompanyProfile.Columns.Add("people", typeof(string));
            DataCompanyProfile.Columns.Add("country", typeof(string));
            DataCompanyProfile.Columns.Add("working_day", typeof(string));
            DataCompanyProfile.Columns.Add("timeOT", typeof(string));
            DataCompanyProfile.Columns.Add("slogan", typeof(string));
        }
        void AddList()
        {
            LstCompanyLogo.Add(Form1_ImgCompany1);
            LstCompanyLogo.Add(Form1_ImgCompany2);
            LstCompanyLogo.Add(Form1_ImgCompany3);
            LstCompanyLogo.Add(Form1_ImgCompany4);
            LstCompanyLogo.Add(Form1_ImgCompany5);
            LstCompanyLogo.Add(Form1_ImgCompany6);
            LstCompanyLogo.Add(Form1_ImgCompany7);
            LstCompanyLogo.Add(Form1_ImgCompany8);

            LstCompanyName.Add(Form1_tb_Title1);
            LstCompanyName.Add(Form1_tb_Title2);
            LstCompanyName.Add(Form1_tb_Title3);
            LstCompanyName.Add(Form1_tb_Title4);
            LstCompanyName.Add(Form1_tb_Title5);
            LstCompanyName.Add(Form1_tb_Title6);
            LstCompanyName.Add(Form1_tb_Title7);
            LstCompanyName.Add(Form1_tb_Title8);

            LstCompanyNumJobs.Add(Form1_lb_CountJobs1);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs2);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs3);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs4);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs5);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs6);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs7);
            LstCompanyNumJobs.Add(Form1_lb_CountJobs8);

            LstCompanySkill.Add(Form1_bt_TagFocus1a);
            LstCompanySkill.Add(Form1_bt_TagFocus1b);
            LstCompanySkill.Add(Form1_bt_TagFocus2a);
            LstCompanySkill.Add(Form1_bt_TagFocus2b);
            LstCompanySkill.Add(Form1_bt_TagFocus3a);
            LstCompanySkill.Add(Form1_bt_TagFocus3b);
            LstCompanySkill.Add(Form1_bt_TagFocus4a);
            LstCompanySkill.Add(Form1_bt_TagFocus4b);
            LstCompanySkill.Add(Form1_bt_TagFocus5a);
            LstCompanySkill.Add(Form1_bt_TagFocus5b);
            LstCompanySkill.Add(Form1_bt_TagFocus6a);
            LstCompanySkill.Add(Form1_bt_TagFocus6b);
            LstCompanySkill.Add(Form1_bt_TagFocus7a);
            LstCompanySkill.Add(Form1_bt_TagFocus7b);
            LstCompanySkill.Add(Form1_bt_TagFocus8a);
            LstCompanySkill.Add(Form1_bt_TagFocus8b);

        }
        public void SetDisplay()
        {
 
        }
        public void setValueAnotherForm()
        {
            UC_DisplayJobs.Instance.CopyDataForm1(DataCompanyProfile, DataJobs);
        }
        //Import data từ excel vào Datatable
        public void ImportDataJobs()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataJobsLocation = Path.Combine(executableLocation, "data_jobs.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataJobsLocation);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            CountRowsJobs = excelRange.Rows.Count;
            Form1_lb_countJobs.Text = "498 IT Jobs";
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= 500; i++)  // <= CountRowsJobs
            {
                row = DataJobs.NewRow();
                row["company_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["title"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["salary"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["distance_time"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["feature_new_text"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["skill"] = excelRange.Cells[i, 6].Value2.ToString(); //string
                row["location_detail"] = excelRange.Cells[i, 7].Value2.ToString(); //string
                row["reason_job"] = excelRange.Cells[i, 8].Value2.ToString(); //string
                row["job_description"] = excelRange.Cells[i, 9].Value2.ToString(); //string
                row["skill_experience"] = excelRange.Cells[i, 10].Value2.ToString(); //string
                row["love_working"] = excelRange.Cells[i, 11].Value2.ToString(); //string
                row["slogan"] = excelRange.Cells[i, 12].Value2.ToString(); //string

                DataJobs.Rows.Add(row);
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
        public void ImportDataCompany()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataCompanyLocation = Path.Combine(executableLocation, "data_info_company.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataCompanyLocation);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            CountRowsCompany = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= 500; i++)    //CountRowsCompany
            {
                row = DataCompanyProfile.NewRow();
                row["logo_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["company_name"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["location"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["field"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["people"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["country"] = excelRange.Cells[i, 6].Value2.ToString(); //string
                row["working_day"] = excelRange.Cells[i, 7].Value2.ToString(); //string
                row["timeOT"] = excelRange.Cells[i, 8].Value2.ToString(); //string
                row["slogan"] = excelRange.Cells[i, 9].Value2.ToString(); //string

                DataCompanyProfile.Rows.Add(row);
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
        public void SortCompanyJobs()
        {
            int count = 0;
            for (int i = 0; i < 298; i++)      //CountRowsCompany
            {
                count = 0;
                for (int j = 0; j < 198; j++)    //CountRowsJobs
                {
                    string x = DataCompanyProfile.Rows[i]["company_name"].ToString();
                    string y = DataJobs.Rows[j]["company_name"].ToString();

                    if (x == y)
                    {
                        count++;
                    }
                }
                countCompanyJobs.Add(i, count);
            }
            int id = 0;
            int idSkill = 0;
            foreach (var entry in countCompanyJobs.OrderByDescending(key => key.Value))
            {
                //int STT = entry.Key + 1;
                LstCompanyName[id].Text = DataCompanyProfile.Rows[entry.Key]["company_name"].ToString();
                if (LstCompanyName[id].Text.Length > 30)
                {
                    LstCompanyName[id].Font = new Font("Segoe UI", 12, FontStyle.Bold);
                }
                else
                {
                    LstCompanyName[id].Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }

                LstCompanyNumJobs[id].Text = entry.Value.ToString() + " Jobs";

                LstCompanySkill[idSkill].Text = DataCompanyProfile.Rows[entry.Key]["field"].ToString();
                LstCompanySkill[idSkill + 1].Text = DataCompanyProfile.Rows[entry.Key]["country"].ToString();

                string path_img = "logo/" + DataCompanyProfile.Rows[entry.Key]["logo_name"].ToString();
                LstCompanyLogo[id].Image = Image.FromFile(path_img);

                id++;
                idSkill += 2;
                if (id == 8)
                {
                    break;
                }
            }
        }
        //Gõ key và search 
        public void KeySearch()
        {
            string[] keySearch = Form1_tb_keySearch.Text.ToLower().Replace(",", "").Replace(".", "").Replace("-", " ").Replace("usd", "").Split(" ".ToCharArray());
            keySearch = keySearch.Where(val => val != "").ToArray();
            DataTable dkey = DataJobs.Clone();
            DataRow row = dkey.NewRow();
            for (int i = 0; i < 498; i++)   // CountRowsJobs
            {
                int countTitle = 0;
                int countSkill= 0;
                int countSalary = 0;
                int countName = 0;

                string temp1 = DataJobs.Rows[i]["title"].ToString().ToLower().Replace("(", " ").Replace("/", " ").Replace("-", " ").Replace(")", " ").Replace(",", " ");
                string[] keyTitle = temp1.Split(" ".ToCharArray());

                string tempName = DataJobs.Rows[i]["company_name"].ToString().ToLower().Replace(".", " ").Replace("-", " ").Replace(",", " ");
                string[] keyName = tempName.Split(" ".ToCharArray());
                string NameSearch = DataJobs.Rows[i]["company_name"].ToString().ToLower();

                string[] keySkill = DataJobs.Rows[i]["skill"].ToString().ToLower().Split("-".ToCharArray());

                string[] keySalary = DataJobs.Rows[i]["salary"].ToString().ToLower().Replace(",", "").Replace(".", "").Replace("-", " ").Replace("usd", "").Split(" ".ToCharArray());
                keySalary = keySalary.Where(val => val != "").ToArray();


                foreach (string key in keySearch)
                {
                    var a = keyTitle.Count(s => s == key);
                    countTitle += a;

                    var y = keySkill.Count(s => s == key);
                    countSkill += y;

                    var z = keySalary.Count(s => s == key);
                    countSalary += z;

                    var b = keyName.Count(s => s == key);
                    countName += b;
                }
                if (countTitle > 0 || countSkill > 0 || countSalary > 0 || countName > 0 || NameSearch == Form1_tb_keySearch.Text.ToLower())
                {
                    row = DataJobs.Rows[i];
                    dkey.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11]);
                }
            }

            UC_DisplayJobs.Instance.setDataResSearchKey(dkey, Form1_tb_keySearch.Text);
        }

        private void Form1_bt_LogOut_Click(object sender, EventArgs e)
        {
            FormLoginRegister FrmLogin = new FormLoginRegister();
            FrmLogin.ShowDialog();
            this.Close();
        }
        private void Form1_bt_Search_Click(object sender, EventArgs e)
        {
            KeySearch();
            if (!Form1_pn_home.Controls.Contains(UC_DisplayJobs.Instance))
            {
                Form1_pn_home.Controls.Add(UC_DisplayJobs.Instance);
                UC_DisplayJobs.Instance.Dock = DockStyle.Fill;
                UC_DisplayJobs.Instance.BringToFront();
            }
            else
            {
                UC_DisplayJobs.Instance.BringToFront();
            }
        }
        private void Form1_bt_AllJobs_Click(object sender, EventArgs e)
        {
            UC_DisplayJobs.Instance.setDataResSearchKey(DataJobs, "All");
            if (!Form1_pn_home.Controls.Contains(UC_DisplayJobs.Instance))
            {
                Form1_pn_home.Controls.Add(UC_DisplayJobs.Instance);
                UC_DisplayJobs.Instance.Dock = DockStyle.Fill;
                UC_DisplayJobs.Instance.BringToFront();
            }
            else
            {
                UC_DisplayJobs.Instance.BringToFront();
            }
        }

        private void Form1_bt_Tag1_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag1.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_bt_Tag2_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag2.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_bt_Tag3_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag3.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_bt_Tag4_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag4.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_bt_Tag5_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag5.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_bt_Tag6_Click(object sender, EventArgs e)
        {
            Form1_tb_keySearch.Text = Form1_bt_Tag6.Text;
            Form1_bt_Search.PerformClick();
        }

        private void Form1_ImgCompany1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ImgCompany8_Click(object sender, EventArgs e)
        {

        }
    }
}
