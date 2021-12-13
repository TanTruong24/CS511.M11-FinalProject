using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;

namespace project
{
    public partial class FormEmployer : Form
    {

        DataTable DataAccEmployer = new DataTable();
        DataTable DataJobs = new DataTable();
        DataTable DataCompanyProfile = new DataTable();
        DataTable DataNotifyApplyCV = new DataTable();
        DataTable DataViewJobs = new DataTable();
        string email = "";

        List<TextBox> LstTile = new List<TextBox>();
        List<GroupBox> LstItem = new List<GroupBox>();
        List<TextBox> LstSalary = new List<TextBox>();
        List<PictureBox> LstLogo = new List<PictureBox>();
        List<TextBox> LstTimeUp = new List<TextBox>();
        List<Button> LstBtSkillItem1 = new List<Button>();
        List<Button> LstBtSkillItem2 = new List<Button>();
        List<Button> LstBtSkillItem3 = new List<Button>();
        List<Button> LstBtSkillItem4 = new List<Button>();
        List<Button> LstBtSkillItem5 = new List<Button>();
        List<List<Button>> LstListBtSkill = new List<List<Button>>();
        List<GroupBox> LstGrbNotify = new List<GroupBox>();
        List<TextBox> LstTbNotifyTitle = new List<TextBox>();
        

        int idCurPage = 1;
        int idFutPage = 1;
        int beginSTT = 0;
        int endSTT = 0;
        int CountJobs = 0;

        public FormEmployer()
        {
            InitializeComponent();
            AddList();
            AddColumnDataApplyCV();
            ImportDataApplyCV();
            setOrigin();
        }

        public DataTable setDataAccEmployer
        {
            set
            {
                DataAccEmployer = value;
            }
        }
        public DataTable setDataNotifyApplyCV
        {
            set
            {
                DataNotifyApplyCV = value;
            }
        }
        public string setEmail
        {
            set
            {
                email = value;
            }
        }
        public DataTable setDataJobs
        {
            set
            {
                DataJobs = value;
            }
            get
            {
                return DataJobs;
            }
        }
        public DataTable setDataCompanyProfile
        {
            set
            {
                DataCompanyProfile = value;
            }
        }
        public void AddList()
        {
            LstTimeUp.Add(FormEmp_tb_TimeUp1);
            LstTimeUp.Add(FormEmp_tb_TimeUp2);
            LstTimeUp.Add(FormEmp_tb_TimeUp3);
            LstTimeUp.Add(FormEmp_tb_TimeUp4);
            LstTimeUp.Add(FormEmp_tb_TimeUp5);

            LstTile.Add(FormEmp_tb_Title1);
            LstTile.Add(FormEmp_tb_Title2);
            LstTile.Add(FormEmp_tb_Title3);
            LstTile.Add(FormEmp_tb_Title4);
            LstTile.Add(FormEmp_tb_Title5);
            LstLogo.Add(FormEmp_pb_Logo1);
            LstLogo.Add(FormEmp_pb_Logo2);
            LstLogo.Add(FormEmp_pb_Logo3);
            LstLogo.Add(FormEmp_pb_Logo4);
            LstLogo.Add(FormEmp_pb_Logo5);
            LstSalary.Add(FormEmp_tb_Salary1);
            LstSalary.Add(FormEmp_tb_Salary2);
            LstSalary.Add(FormEmp_tb_Salary3);
            LstSalary.Add(FormEmp_tb_Salary4);
            LstSalary.Add(FormEmp_tb_Salary5);

            LstItem.Add(FormEmp_grb_Job1);
            LstItem.Add(FormEmp_grb_Job2);
            LstItem.Add(FormEmp_grb_Job3);
            LstItem.Add(FormEmp_grb_Job4);
            LstItem.Add(FormEmp_grb_Job5);

            LstListBtSkill.Add(LstBtSkillItem1);
            LstListBtSkill.Add(LstBtSkillItem2);
            LstListBtSkill.Add(LstBtSkillItem3);
            LstListBtSkill.Add(LstBtSkillItem4);
            LstListBtSkill.Add(LstBtSkillItem5);
            LstBtSkillItem1.Add(bt_Skill_1a);
            LstBtSkillItem1.Add(bt_Skill_1b);
            LstBtSkillItem1.Add(bt_Skill_1c);
            LstBtSkillItem1.Add(bt_Skill_1d);
            LstBtSkillItem1.Add(bt_Skill_1e);
            LstBtSkillItem1.Add(bt_Skill_1f);
            LstBtSkillItem2.Add(bt_Skill_2a);
            LstBtSkillItem2.Add(bt_Skill_2b);
            LstBtSkillItem2.Add(bt_Skill_2c);
            LstBtSkillItem2.Add(bt_Skill_2d);
            LstBtSkillItem2.Add(bt_Skill_2e);
            LstBtSkillItem2.Add(bt_Skill_2f);
            LstBtSkillItem3.Add(bt_Skill_3a);
            LstBtSkillItem3.Add(bt_Skill_3b);
            LstBtSkillItem3.Add(bt_Skill_3c);
            LstBtSkillItem3.Add(bt_Skill_3d);
            LstBtSkillItem3.Add(bt_Skill_3e);
            LstBtSkillItem3.Add(bt_Skill_3f);
            LstBtSkillItem4.Add(bt_Skill_4a);
            LstBtSkillItem4.Add(bt_Skill_4b);
            LstBtSkillItem4.Add(bt_Skill_4c);
            LstBtSkillItem4.Add(bt_Skill_4d);
            LstBtSkillItem4.Add(bt_Skill_4e);
            LstBtSkillItem4.Add(bt_Skill_4f);
            LstBtSkillItem5.Add(bt_Skill_5a);
            LstBtSkillItem5.Add(bt_Skill_5b);
            LstBtSkillItem5.Add(bt_Skill_5c);
            LstBtSkillItem5.Add(bt_Skill_5d);
            LstBtSkillItem5.Add(bt_Skill_5e);
            LstBtSkillItem5.Add(bt_Skill_5f);

            LstGrbNotify.Add(FormEmp_grb_Notify1);
            LstGrbNotify.Add(FormEmp_grb_Notify2);
            LstGrbNotify.Add(FormEmp_grb_Notify3);
            LstTbNotifyTitle.Add(FormEmp_tb_NotifyTitle1);
            LstTbNotifyTitle.Add(FormEmp_tb_NotifyTitle2);
            LstTbNotifyTitle.Add(FormEmp_tb_NotifyTitle3);
        }

        public void AddColumnDataApplyCV()
        {
            DataNotifyApplyCV.Columns.Add("company_name", typeof(string));
            DataNotifyApplyCV.Columns.Add("title", typeof(string));
            DataNotifyApplyCV.Columns.Add("candidate_name", typeof(string));
            DataNotifyApplyCV.Columns.Add("candidate_mail", typeof(string));
            DataNotifyApplyCV.Columns.Add("candidate_intro", typeof(string));
            DataNotifyApplyCV.Columns.Add("time_apply", typeof(string));
            DataNotifyApplyCV.Columns.Add("CV_name", typeof(string));

            DataViewJobs.Columns.Add("company_name", typeof(string));
            DataViewJobs.Columns.Add("title", typeof(string));
            DataViewJobs.Columns.Add("view_time", typeof(string));
        }
        public void setOrigin()
        {
            for (int i = 0; i < 5; i++)
            {
                LstItem[i].Visible = false;
                for (int j = 0; j < 6; j++)
                {
                    LstListBtSkill[i][j].Visible = false;
                }
            }
        }
        //Giá trị bắt đầu và kết thúc mỗi page
        public void DefineidCurPage()
        {
            if (idCurPage == 1 && idFutPage == 1)
            {
                beginSTT = 0;
                endSTT = beginSTT + 4;
                if (CountJobs - beginSTT < 5)
                {
                    endSTT = CountJobs - beginSTT - 1;
                }
            }
            else
            {
                if (idFutPage < idCurPage)
                {
                    beginSTT -= 5;
                    if (CountJobs - beginSTT <= 5)
                    {
                        endSTT = CountJobs - 1;
                    }
                    else
                    {
                        endSTT = beginSTT + 4;
                    }
                }
                else if (idFutPage > idCurPage)
                {
                    beginSTT += 5;
                    if (CountJobs - beginSTT <= 5)
                    {
                        endSTT = CountJobs - 1;
                    }
                    else
                    {
                        endSTT = beginSTT + 4;
                    }
                }
            }

            int x = endSTT - beginSTT + 1;
            for (int i = 0; i < x; i++)
            {
                LstItem[i].Visible = true;
            }
        }
        public void DisplayJob()
        {
            string exp = string.Format("company_name = '{0}'", FormEmp_tb_CompanyName.Text);
            DataRow[] rowJobs = DataJobs.Select(exp);
            CountJobs = rowJobs.Length;
            DefineidCurPage();
            FormEmp_lb_countJobs.Text = rowJobs.Length.ToString() + " Jobs";
            if (beginSTT < rowJobs.Length)
            {
                int idLst = 0;
                for (int i = beginSTT; i <= endSTT; i++)
                {
                    LstTile[idLst].Text = rowJobs[i]["title"].ToString();
                    LstSalary[idLst].Text = rowJobs[i]["salary"].ToString();

                    LstTimeUp[idLst].Text = rowJobs[i]["distance_time"].ToString();

                    string[] arraySkill = rowJobs[i]["skill"].ToString().Split("-".ToCharArray());
                    for (int j = 0; j < arraySkill.Length; j++)
                    {
                        if (j > 6)
                        {
                            break;
                        }
                        LstListBtSkill[idLst][j].Visible = true;
                        LstListBtSkill[idLst][j].Text = arraySkill[j];
                    }

                    DataRow[] rowCompany = DataCompanyProfile.Select(exp);
                    if (rowCompany.Length > 0)
                    {
                        string path_img = "logo/" + rowCompany[0]["logo_name"].ToString();
                        LstLogo[idLst].Image = Image.FromFile(path_img);
                    }
                    idLst++;
                }
            }

        }
        private void FormEmployer_Load(object sender, EventArgs e)
        {
            FormEmp_tb_JobDone.BackColor = Color.Red;
            string exp = string.Format("email = '{0}'", email);
            DataRow[] rowAcc = DataAccEmployer.Select(exp);
            FormEmp_lb_Welcome.Text = "Chào mừng " + rowAcc[0]["full_name"];
            FormEmp_tb_CompanyName.Text = rowAcc[0]["company_name"].ToString();

            string exp2 = string.Format("company_name = '{0}'", FormEmp_tb_CompanyName.Text);
            DataRow[] rowCompany = DataCompanyProfile.Select(exp2);
            FormEmp_tb_CompanySlogan.Text = rowCompany[0]["slogan"].ToString();
            FormEmp_tb_Location.Text = rowCompany[0]["location"].ToString();
            FormEmp_tb_CompanyWorkingDay.Text = rowCompany[0]["working_day"].ToString(); ;
            FormEmp_tb_CompanyTimeOT.Text = rowCompany[0]["timeOT"].ToString(); ;
            FormEmp_tb_CompanyCountry.Text = rowCompany[0]["country"].ToString(); ;
            FormEmp_tb_CompanyField.Text = rowCompany[0]["field"].ToString(); ;
            FormEmp_tb_CompanyPeople.Text = rowCompany[0]["people"].ToString();

            string path_img = "logo/" + rowCompany[0]["logo_name"].ToString();
            FormEmp_pb_LogoHead.Image = Image.FromFile(path_img);

            FormEmp_bt_pageA.BackColor = Color.Red;

            DisplayJob();
            UpdateNotify(DataNotifyApplyCV);

            //Hiển thị lượt xem công việc
            ImportDataViewJobs();
            int x = CountViewJobs(1, 12, 2021, 31, 12, 2021, false).Rows.Count;
            int y = CountApplyCV(1, 12, 2021, 31, 12, 2021, false).Rows.Count;
            FormEmp_tb_StatisticView.Text = string.Format("01/12/2021 - nay: {0} truy cập", x);
            FormEmp_tb_StatisticCV.Text = string.Format("01/12/2021 - nay: {0} ứng tuyển", y);
        }

        private void FormEmp_pb_Logo1_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmEditJob = new FormEmployer_CreateJob(this);
            frmEditJob.getsetDataJob = DataJobs;
            frmEditJob.setTitle = LstTile[0].Text;
            frmEditJob.setCheckCreateJob = false;
            frmEditJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmEditJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmEditJob.ShowDialog();
        }

        private void FormEmp_pb_Logo2_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmEditJob = new FormEmployer_CreateJob(this);
            frmEditJob.getsetDataJob = DataJobs;
            frmEditJob.setmessNotify = "Cập nhật công việc thành công";
            frmEditJob.setTitle = LstTile[1].Text;
            frmEditJob.setCheckCreateJob = false;
            frmEditJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmEditJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmEditJob.ShowDialog();
        }

        private void FormEmp_pb_Logo3_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmEditJob = new FormEmployer_CreateJob(this);
            frmEditJob.getsetDataJob = DataJobs;
            frmEditJob.setmessNotify = "Cập nhật công việc thành công";
            frmEditJob.setTitle = LstTile[2].Text;
            frmEditJob.setCheckCreateJob = false;
            frmEditJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmEditJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmEditJob.ShowDialog();
        }

        private void FormEmp_pb_Logo4_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmEditJob = new FormEmployer_CreateJob(this);
            frmEditJob.getsetDataJob = DataJobs;
            frmEditJob.setmessNotify = "Cập nhật công việc thành công";
            frmEditJob.setTitle = LstTile[3].Text;
            frmEditJob.setCheckCreateJob = false;
            frmEditJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmEditJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmEditJob.ShowDialog();
        }

        private void FormEmp_pb_Logo5_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmEditJob = new FormEmployer_CreateJob(this);
            frmEditJob.getsetDataJob = DataJobs;
            frmEditJob.setmessNotify = "Cập nhật công việc thành công";
            frmEditJob.setTitle = LstTile[4].Text;
            frmEditJob.setCheckCreateJob = false;
            frmEditJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmEditJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmEditJob.ShowDialog();
        }

        private void FormEmp_tb_JobDone_Click(object sender, EventArgs e)
        {

        }

        private void FormEmp_bt_backPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_pageA.Text) - 3;
            int b = Int32.Parse(FormEmp_bt_pageB.Text) - 3;
            int c = Int32.Parse(FormEmp_bt_pageC.Text) - 3;
            FormEmp_bt_pageA.Text = a.ToString();
            FormEmp_bt_pageB.Text = b.ToString();
            FormEmp_bt_pageC.Text = c.ToString();
        }

        private void FormEmp_bt_pageA_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(FormEmp_bt_pageA.Text);
            setOrigin();
            DisplayJob();
            FormEmp_bt_pageA.BackColor = Color.Red;
            FormEmp_bt_pageB.BackColor = Color.White;
            FormEmp_bt_pageC.BackColor = Color.White;
        }

        private void FormEmp_bt_pageB_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(FormEmp_bt_pageB.Text);
            if (CountJobs - beginSTT >= 4)
            {
                setOrigin();
                DisplayJob();
            }
            else
            {
                setOrigin();
            }
            FormEmp_bt_pageB.BackColor = Color.Red;
            FormEmp_bt_pageA.BackColor = Color.White;
            FormEmp_bt_pageC.BackColor = Color.White;
        }

        private void FormEmp_bt_pageC_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(FormEmp_bt_pageC.Text);
            if (CountJobs - beginSTT >= 4)
            {
                setOrigin();
                DisplayJob();
            }
            else
            {
                setOrigin();
            }
            FormEmp_bt_pageC.BackColor = Color.Red;
            FormEmp_bt_pageB.BackColor = Color.White;
            FormEmp_bt_pageA.BackColor = Color.White;
        }

        private void FormEmp_bt_nextPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_pageA.Text) + 3;
            int b = Int32.Parse(FormEmp_bt_pageB.Text) + 3;
            int c = Int32.Parse(FormEmp_bt_pageC.Text) + 3;
            FormEmp_bt_pageA.Text = a.ToString();
            FormEmp_bt_pageB.Text = b.ToString();
            FormEmp_bt_pageC.Text = c.ToString();
        }

        //*************************************
        //Thong bao ung vien apply
        public void ImportDataApplyCV()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataCVLocation = Path.Combine(executableLocation, "data_applyCV.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataCVLocation);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int CountRowsCV = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= CountRowsCV; i++)  // <= CountRowsJobs
            {
                row = DataNotifyApplyCV.NewRow();
                row["company_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["title"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["candidate_name"] = excelRange.Cells[i, 3].Value2.ToString(); //string
                row["candidate_mail"] = excelRange.Cells[i, 4].Value2.ToString(); //string
                row["candidate_intro"] = excelRange.Cells[i, 5].Value2.ToString(); //string
                row["time_apply"] = excelRange.Cells[i, 6].Value2.ToString(); //string
                row["CV_name"] = excelRange.Cells[i, 7].Value2.ToString(); //string

                DataNotifyApplyCV.Rows.Add(row);
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
        public void UpdateNotify(DataTable DataNotifyApplyCV)
        {
            FormEmp_grb_Notify1.Visible = false;
            FormEmp_grb_Notify2.Visible = false;
            FormEmp_grb_Notify3.Visible = false;

            string exp = string.Format("company_name = '{0}'", FormEmp_tb_CompanyName.Text);
            DataRow[] rowJob = DataNotifyApplyCV.Select(exp);
            if (rowJob.Length > 0)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < rowJob.Length; i++)
                    {
                        if (j == 0 && rowJob[i]["title"].ToString() != LstTbNotifyTitle[j].Text)
                        {
                            LstGrbNotify[j].Visible = true;
                            LstTbNotifyTitle[j].Text = rowJob[i]["title"].ToString();
                            string exp1 = string.Format("title = '{0}'", LstTbNotifyTitle[j].Text);
                            DataRow[] CounterCV = DataNotifyApplyCV.Select(exp1);
                            LstGrbNotify[j].Text = string.Format("({0})", CounterCV.Length);
                            break;
                        }
                        else if (j == 1 && rowJob[i]["title"].ToString() != LstTbNotifyTitle[0].Text)
                        {
                            LstGrbNotify[j].Visible = true;
                            LstTbNotifyTitle[j].Text = rowJob[i]["title"].ToString();
                            string exp1 = string.Format("title = '{0}'", LstTbNotifyTitle[j].Text);
                            DataRow[] CounterCV = DataNotifyApplyCV.Select(exp1);
                            LstGrbNotify[j].Text = string.Format("({0})", CounterCV.Length);
                            break;
                        }
                        else if (j == 2 && rowJob[i]["title"].ToString() != LstTbNotifyTitle[0].Text && DataNotifyApplyCV.Rows[i]["title"].ToString() != LstTbNotifyTitle[1].Text)
                        {
                            LstGrbNotify[j].Visible = true;
                            LstTbNotifyTitle[j].Text = rowJob[i]["title"].ToString();
                            string exp1 = string.Format("title = '{0}'", LstTbNotifyTitle[j].Text);
                            DataRow[] CounterCV = DataNotifyApplyCV.Select(exp1);
                            LstGrbNotify[j].Text = string.Format("({0})", CounterCV.Length);
                            break;
                        }
                    }
                } 
            }
        }
        private void FormEmp_LinkLb_DetaiNotify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmployer_Notify frmNotify = new FormEmployer_Notify(this);
            frmNotify.setDataJobs = DataJobs;
            frmNotify.setDataApplyCV = DataNotifyApplyCV;
            frmNotify.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmNotify.Show();
        }

        private void FormEmp_bt_UpJobs_Click(object sender, EventArgs e)
        {
            FormEmployer_CreateJob frmCreatJob = new FormEmployer_CreateJob(this);
            frmCreatJob.setmessNotify = "Đăng việc mới thành công";
            frmCreatJob.getsetDataJob = DataJobs;
            frmCreatJob.setCompanyName = FormEmp_tb_CompanyName.Text;
            frmCreatJob.setSlogan = FormEmp_tb_CompanySlogan.Text;
            frmCreatJob.setCheckCreateJob = true;
            frmCreatJob.Show();
        }

        //*********************************
        //Thống kê số view và apply
        public void ImportDataViewJobs()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataView = Path.Combine(executableLocation, "data_counterViewJobs.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataView);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int CountRowsView = excelRange.Rows.Count;
            DataRow row;

            //first row using for heading, start second row for data
            for (int i = 2; i <= CountRowsView; i++)  // <= CountRowsJobs
            {
                row = DataViewJobs.NewRow();
                row["company_name"] = excelRange.Cells[i, 1].Value2.ToString(); //string
                row["title"] = excelRange.Cells[i, 2].Value2.ToString(); //string
                row["view_time"] = excelRange.Cells[i, 3].Value2.ToString(); //string

                DataViewJobs.Rows.Add(row);
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
        //*********************************
        //Thống kê lượt xem
        DataTable CountViewRequest = new DataTable();
        DataTable CountCVRequest = new DataTable();
        Dictionary<string, int> DicCountOfDay = new Dictionary<string, int>();
        Dictionary<string, int> DicCountCVOfDay = new Dictionary<string, int>();
        public DataTable CountViewJobs(int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear, bool checkDraw)
        {
            //int countRow = DataViewJobs.Rows.Count;
            string exp = string.Format("company_name = '{0}'", FormEmp_tb_CompanyName.Text);
            DataRow[] rowView = DataViewJobs.Select(exp);
            CountViewRequest = DataViewJobs.Clone();
            string temp;
            for (int i = 0; i < rowView.Length; i++)
            {
                temp = rowView[i]["view_time"].ToString().Substring(3, 2);
                int getMonth = Int32.Parse(temp);
                temp = rowView[i]["view_time"].ToString().Substring(6, 4);
                int getYear = Int32.Parse(temp);
                temp = rowView[i]["view_time"].ToString().Substring(0, 2);
                int getDay = Int32.Parse(temp);
                if ((getDay >= startDay && getDay <= endDay) && (getMonth >= startMonth && getMonth <= endMonth) && (getYear >= startYear && getYear <= endYear))
                {
                    CountViewRequest.Rows.Add(rowView[i]["company_name"], rowView[i]["title"], rowView[i]["view_time"]);
                    if (checkDraw == true)
                    {
                        if (i == 0)
                        {
                            DicCountOfDay.Add(rowView[i]["view_time"].ToString().Substring(0, 10), 1);
                        }
                        else
                        {
                            bool checkDup = false;
                            foreach (KeyValuePair<string, int> entry in DicCountOfDay)
                            {
                                if (entry.Key == rowView[i]["view_time"].ToString().Substring(0, 10))
                                {
                                    DicCountOfDay[entry.Key] += 1;
                                    checkDup = true;
                                    break;
                                }
                            }
                            if (!checkDup)
                            {
                                DicCountOfDay.Add(rowView[i]["view_time"].ToString().Substring(0, 10), 1);
                            }
                        }
                    }    
                    
                }
            }

            return CountViewRequest;
        }
        public Dictionary<string, int> getDicCountOfDay
        {
            get
            {
                return DicCountOfDay;
            }
        }
        public Dictionary<string, int> getDicCountCVOfDay
        {
            get
            {
                return DicCountCVOfDay;
            }
        }
        public void clearDicCountOfDay()
        {
            DicCountOfDay.Clear();
            DicCountCVOfDay.Clear();

        }
        //*********************************
        //Thống kê lượt CV

        public DataTable CountApplyCV(int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear, bool checkDraw)
        {
            string exp = string.Format("company_name = '{0}'", FormEmp_tb_CompanyName.Text);
            DataRow[] rowApplyCV = DataNotifyApplyCV.Select(exp);
            CountCVRequest = DataNotifyApplyCV.Clone();
            string temp;
            for (int i = 0; i < rowApplyCV.Length; i++)
            {
                temp = rowApplyCV[i]["time_apply"].ToString().Substring(3, 2);
                int getMonth = Int32.Parse(temp);
                temp = rowApplyCV[i]["time_apply"].ToString().Substring(6, 4);
                int getYear = Int32.Parse(temp);
                temp = rowApplyCV[i]["time_apply"].ToString().Substring(0, 2);
                int getDay = Int32.Parse(temp);
                if ((getDay >= startDay && getDay <= endDay) && (getMonth >= startMonth && getMonth <= endMonth) && (getYear >= startYear && getYear <= endYear))
                {
                    CountCVRequest.Rows.Add(rowApplyCV[i]["company_name"], rowApplyCV[i]["title"], rowApplyCV[i]["candidate_name"], rowApplyCV[i]["candidate_mail"], rowApplyCV[i]["candidate_intro"], rowApplyCV[i]["time_apply"], rowApplyCV[i]["CV_name"]);
                    if (checkDraw == true)
                    {
                        if (i == 0)
                        {
                            DicCountCVOfDay.Add(rowApplyCV[i]["time_apply"].ToString().Substring(0, 10), 1);
                        }
                        else
                        {
                            bool checkDup = false;
                            foreach (KeyValuePair<string, int> entry in DicCountCVOfDay)
                            {
                                if (entry.Key == rowApplyCV[i]["time_apply"].ToString().Substring(0, 10))
                                {
                                    DicCountCVOfDay[entry.Key] += 1;
                                    checkDup = true;
                                    break;
                                }
                            }
                            if (!checkDup)
                            {
                                DicCountCVOfDay.Add(rowApplyCV[i]["time_apply"].ToString().Substring(0, 10), 1);
                            }
                        }
                    }
                }
            }
            return CountCVRequest;
        }

        private void FormEmp_LinkLb_Statistic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmployer_Statistic frmStatistic = new FormEmployer_Statistic(this);
            frmStatistic.Show();
        }

        bool checlEditInfo = false;
        private void FormEmp_LinkLb_EditInfoCom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!checlEditInfo)
            {
                FormEmp_LinkLb_EditInfoCom.Text = "Xong";
                checlEditInfo = true;

                FormEmp_tb_CompanyName.ReadOnly = false;
                FormEmp_tb_CompanySlogan.ReadOnly = false;
                FormEmp_tb_Location.ReadOnly = false;
                FormEmp_tb_CompanyWorkingDay.ReadOnly = false;
                FormEmp_tb_CompanyCountry.ReadOnly = false;
                FormEmp_tb_CompanyTimeOT.ReadOnly = false;
                FormEmp_tb_CompanyField.ReadOnly = false;
                FormEmp_tb_CompanyPeople.ReadOnly = false;

                FormEmp_tb_CompanyName.BackColor = Color.Gray;
                FormEmp_tb_CompanySlogan.BackColor = Color.Gray;
                FormEmp_tb_Location.BackColor = Color.Gray;
                FormEmp_tb_CompanyWorkingDay.BackColor = Color.Gray;
                FormEmp_tb_CompanyCountry.BackColor = Color.Gray;
                FormEmp_tb_CompanyTimeOT.BackColor = Color.Gray;
                FormEmp_tb_CompanyField.BackColor = Color.Gray;
                FormEmp_tb_CompanyPeople.BackColor = Color.Gray;
            }
            else
            {
                FormEmp_LinkLb_EditInfoCom.Text = "Chỉnh sửa Thông tin";
                checlEditInfo = false;

                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string DataComp = Path.Combine(executableLocation, "data_info_company.xlsx");

                //Create COM Objects.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                //Notice: Change this path to your real excel file path
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataComp);
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                for (int i = 2; i <= 500; i++)
                {
                    if (excelRange.Cells[i, 2].Value2.ToString() == FormEmp_tb_CompanyName.Text)
                    {
                        excelApp.Cells[i, 2] = FormEmp_tb_CompanyName.Text;
                        excelApp.Cells[i, 3] = FormEmp_tb_Location.Text;
                        excelApp.Cells[i, 4] = FormEmp_tb_CompanyField.Text;
                        excelApp.Cells[i, 5] = FormEmp_tb_CompanyPeople.Text;
                        excelApp.Cells[i, 6] = FormEmp_tb_CompanyCountry.Text;
                        excelApp.Cells[i, 7] = FormEmp_tb_CompanyWorkingDay.Text;
                        excelApp.Cells[i, 8] = FormEmp_tb_CompanyTimeOT.Text;
                        excelApp.Cells[i, 9] = FormEmp_tb_CompanySlogan.Text;

                        break;
                    }
                    
                }

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

                FormEmp_tb_CompanyName.ReadOnly = true;
                FormEmp_tb_CompanySlogan.ReadOnly = true;
                FormEmp_tb_Location.ReadOnly = true;
                FormEmp_tb_CompanyWorkingDay.ReadOnly = true;
                FormEmp_tb_CompanyCountry.ReadOnly = true;
                FormEmp_tb_CompanyTimeOT.ReadOnly = true;
                FormEmp_tb_CompanyField.ReadOnly = true;
                FormEmp_tb_CompanyPeople.ReadOnly = true;
                FormEmp_tb_CompanyName.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanySlogan.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_Location.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanyWorkingDay.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanyCountry.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanyTimeOT.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanyField.BackColor = Color.FromArgb(20, 33, 61);
                FormEmp_tb_CompanyPeople.BackColor = Color.FromArgb(20, 33, 61);

                MessageBox.Show("Chỉnh sửa Thông tin thành công");
            }
        }
    }
}
