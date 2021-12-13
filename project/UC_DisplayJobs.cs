using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace project
{
    public partial class UC_DisplayJobs : UserControl
    {
        private static UC_DisplayJobs _instance;
        public static UC_DisplayJobs Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_DisplayJobs();
                return _instance;
            }
        }

        DataTable ResSearchKey = new DataTable();
        DataTable DataCompanyProfile = new DataTable();
        DataTable DataJobs = new DataTable();

        List<GroupBox> LstGbJobItem = new List<GroupBox>();
        List<PictureBox> LstPbJobLogo = new List<PictureBox>();
        List<TextBox> LstTbJobTitle = new List<TextBox>();
        List<TextBox> LstTbJobSalary = new List<TextBox>();
        //Lưu trữ các button tương ứng với skill yêu cầu
        List<Button> LstBtSkillItem1 = new List<Button>();
        List<Button> LstBtSkillItem2 = new List<Button>();
        List<Button> LstBtSkillItem3 = new List<Button>();
        List<Button> LstBtSkillItem4 = new List<Button>();
        List<Button> LstBtSkillItem5 = new List<Button>();
        List<Button> LstBtSkillItem6 = new List<Button>();
        List<Button> LstBtSkillItem7 = new List<Button>();
        List<Button> LstBtSkillItem8 = new List<Button>();
        List<Button> LstBtSkillItem9 = new List<Button>();
        List<Button> LstBtSkillItem10 = new List<Button>();
        List<Button> LstBtSkillItem11 = new List<Button>();
        List<Button> LstBtSkillItem12 = new List<Button>();
        List<Button> LstBtSkillItem13 = new List<Button>();
        List<Button> LstBtSkillItem14 = new List<Button>();
        List<Button> LstBtSkillItem15 = new List<Button>();
        List<Button> LstBtSkillItem16 = new List<Button>();
        List<Button> LstBtSkillItem17 = new List<Button>();
        List<Button> LstBtSkillItem18 = new List<Button>();
        List<Button> LstBtSkillItem19 = new List<Button>();
        List<Button> LstBtSkillItem20 = new List<Button>();
        List<Button> LstBtSkillItem21 = new List<Button>();
        List<Button> LstBtDetailSkill = new List<Button>();
        List<List<Button>> LstListBtSkill = new List<List<Button>>();

        int idCurPage = 1;
        int idFutPage = 1;
        int beginSTT = 0;
        int endSTT = 0;

        public UC_DisplayJobs()
        {

            InitializeComponent();
            importColumnPnJobs();
            AddList();
            setDisplay();
        }
        public void AddList()
        {
            LstListBtSkill.Add(LstBtSkillItem1);
            LstListBtSkill.Add(LstBtSkillItem2);
            LstListBtSkill.Add(LstBtSkillItem3);
            LstListBtSkill.Add(LstBtSkillItem4);
            LstListBtSkill.Add(LstBtSkillItem5);
            LstListBtSkill.Add(LstBtSkillItem6);
            LstListBtSkill.Add(LstBtSkillItem7);
            LstListBtSkill.Add(LstBtSkillItem8);
            LstListBtSkill.Add(LstBtSkillItem9);
            LstListBtSkill.Add(LstBtSkillItem10);
            LstListBtSkill.Add(LstBtSkillItem11);
            LstListBtSkill.Add(LstBtSkillItem12);
            LstListBtSkill.Add(LstBtSkillItem13);
            LstListBtSkill.Add(LstBtSkillItem14);
            LstListBtSkill.Add(LstBtSkillItem15);
            LstListBtSkill.Add(LstBtSkillItem16);
            LstListBtSkill.Add(LstBtSkillItem17);
            LstListBtSkill.Add(LstBtSkillItem18);
            LstListBtSkill.Add(LstBtSkillItem19);
            LstListBtSkill.Add(LstBtSkillItem20);
            LstListBtSkill.Add(LstBtSkillItem21);

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

            LstBtSkillItem6.Add(bt_Skill_6a);
            LstBtSkillItem6.Add(bt_Skill_6b);
            LstBtSkillItem6.Add(bt_Skill_6c);
            LstBtSkillItem6.Add(bt_Skill_6d);
            LstBtSkillItem6.Add(bt_Skill_6e);
            LstBtSkillItem6.Add(bt_Skill_6f);

            LstBtSkillItem7.Add(bt_Skill_7a);
            LstBtSkillItem7.Add(bt_Skill_7b);
            LstBtSkillItem7.Add(bt_Skill_7c);
            LstBtSkillItem7.Add(bt_Skill_7d);
            LstBtSkillItem7.Add(bt_Skill_7e);
            LstBtSkillItem7.Add(bt_Skill_7f);

            LstBtSkillItem8.Add(bt_Skill_8a);
            LstBtSkillItem8.Add(bt_Skill_8b);
            LstBtSkillItem8.Add(bt_Skill_8c);
            LstBtSkillItem8.Add(bt_Skill_8d);
            LstBtSkillItem8.Add(bt_Skill_8e);
            LstBtSkillItem8.Add(bt_Skill_8f);

            LstBtSkillItem9.Add(bt_Skill_9a);
            LstBtSkillItem9.Add(bt_Skill_9b);
            LstBtSkillItem9.Add(bt_Skill_9c);
            LstBtSkillItem9.Add(bt_Skill_9d);
            LstBtSkillItem9.Add(bt_Skill_9e);
            LstBtSkillItem9.Add(bt_Skill_9f);

            LstBtSkillItem10.Add(bt_Skill_10a);
            LstBtSkillItem10.Add(bt_Skill_10b);
            LstBtSkillItem10.Add(bt_Skill_10c);
            LstBtSkillItem10.Add(bt_Skill_10d);
            LstBtSkillItem10.Add(bt_Skill_10e);
            LstBtSkillItem10.Add(bt_Skill_10f);

            LstBtSkillItem11.Add(bt_Skill_11a);
            LstBtSkillItem11.Add(bt_Skill_11b);
            LstBtSkillItem11.Add(bt_Skill_11c);
            LstBtSkillItem11.Add(bt_Skill_11d);
            LstBtSkillItem11.Add(bt_Skill_11e);
            LstBtSkillItem11.Add(bt_Skill_11f);

            LstBtSkillItem12.Add(bt_Skill_12a);
            LstBtSkillItem12.Add(bt_Skill_12b);
            LstBtSkillItem12.Add(bt_Skill_12c);
            LstBtSkillItem12.Add(bt_Skill_12d);
            LstBtSkillItem12.Add(bt_Skill_12e);
            LstBtSkillItem12.Add(bt_Skill_12f);

            LstBtSkillItem13.Add(bt_Skill_13a);
            LstBtSkillItem13.Add(bt_Skill_13b);
            LstBtSkillItem13.Add(bt_Skill_13c);
            LstBtSkillItem13.Add(bt_Skill_13d);
            LstBtSkillItem13.Add(bt_Skill_13e);
            LstBtSkillItem13.Add(bt_Skill_13f);

            LstBtSkillItem14.Add(bt_Skill_14a);
            LstBtSkillItem14.Add(bt_Skill_14b);
            LstBtSkillItem14.Add(bt_Skill_14c);
            LstBtSkillItem14.Add(bt_Skill_14d);
            LstBtSkillItem14.Add(bt_Skill_14e);
            LstBtSkillItem14.Add(bt_Skill_14f);

            LstBtSkillItem15.Add(bt_Skill_15a);
            LstBtSkillItem15.Add(bt_Skill_15b);
            LstBtSkillItem15.Add(bt_Skill_15c);
            LstBtSkillItem15.Add(bt_Skill_15d);
            LstBtSkillItem15.Add(bt_Skill_15e);
            LstBtSkillItem15.Add(bt_Skill_15f);

            LstBtSkillItem16.Add(bt_Skill_16a);
            LstBtSkillItem16.Add(bt_Skill_16b);
            LstBtSkillItem16.Add(bt_Skill_16c);
            LstBtSkillItem16.Add(bt_Skill_16d);
            LstBtSkillItem16.Add(bt_Skill_16e);
            LstBtSkillItem16.Add(bt_Skill_16f);

            LstBtSkillItem17.Add(bt_Skill_17a);
            LstBtSkillItem17.Add(bt_Skill_17b);
            LstBtSkillItem17.Add(bt_Skill_17c);
            LstBtSkillItem17.Add(bt_Skill_17d);
            LstBtSkillItem17.Add(bt_Skill_17e);
            LstBtSkillItem17.Add(bt_Skill_17f);

            LstBtSkillItem18.Add(bt_Skill_18a);
            LstBtSkillItem18.Add(bt_Skill_18b);
            LstBtSkillItem18.Add(bt_Skill_18c);
            LstBtSkillItem18.Add(bt_Skill_18d);
            LstBtSkillItem18.Add(bt_Skill_18e);
            LstBtSkillItem18.Add(bt_Skill_18f);

            LstBtSkillItem19.Add(bt_Skill_19a);
            LstBtSkillItem19.Add(bt_Skill_19b);
            LstBtSkillItem19.Add(bt_Skill_19c);
            LstBtSkillItem19.Add(bt_Skill_19d);
            LstBtSkillItem19.Add(bt_Skill_19e);
            LstBtSkillItem19.Add(bt_Skill_19f);

            LstBtSkillItem20.Add(bt_Skill_20a);
            LstBtSkillItem20.Add(bt_Skill_20b);
            LstBtSkillItem20.Add(bt_Skill_20c);
            LstBtSkillItem20.Add(bt_Skill_20d);
            LstBtSkillItem20.Add(bt_Skill_20e);
            LstBtSkillItem20.Add(bt_Skill_20f);

            LstBtSkillItem21.Add(bt_Skill_21a);
            LstBtSkillItem21.Add(bt_Skill_21b);
            LstBtSkillItem21.Add(bt_Skill_21c);
            LstBtSkillItem21.Add(bt_Skill_21d);
            LstBtSkillItem21.Add(bt_Skill_21e);
            LstBtSkillItem21.Add(bt_Skill_21f);

            LstBtDetailSkill.Add(UCJobs_detail_bt_Skill1);
            LstBtDetailSkill.Add(UCJobs_detail_bt_Skill2);
            LstBtDetailSkill.Add(UCJobs_detail_bt_Skill3);
            LstBtDetailSkill.Add(UCJobs_detail_bt_Skill4);
            LstBtDetailSkill.Add(UCJobs_detail_bt_Skill5);
        }
        public void setDisplay()
        {
            for (int i = 0; i < 21; i++)
            {
                LstGbJobItem[i].Visible = false;
                for (int j = 0; j < 6; j++)
                {
                    LstListBtSkill[i][j].Visible = false;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                LstBtDetailSkill[i].Visible = false;
            }

            if (idCurPage == 1)
            {
                UCJobs_bt_pageA.BackColor = Color.Red;
            }
        }
        public void importColumnPnJobs()
        {
            LstGbJobItem.Add(UCJobs_grb_Job1);
            LstGbJobItem.Add(UCJobs_grb_Job2);
            LstGbJobItem.Add(UCJobs_grb_Job3);
            LstGbJobItem.Add(UCJobs_grb_Job4);
            LstGbJobItem.Add(UCJobs_grb_Job5);
            LstGbJobItem.Add(UCJobs_grb_Job6);
            LstGbJobItem.Add(UCJobs_grb_Job7);
            LstGbJobItem.Add(UCJobs_grb_Job8);
            LstGbJobItem.Add(UCJobs_grb_Job9);
            LstGbJobItem.Add(UCJobs_grb_Job10);
            LstGbJobItem.Add(UCJobs_grb_Job11);
            LstGbJobItem.Add(UCJobs_grb_Job12);
            LstGbJobItem.Add(UCJobs_grb_Job13);
            LstGbJobItem.Add(UCJobs_grb_Job14);
            LstGbJobItem.Add(UCJobs_grb_Job15);
            LstGbJobItem.Add(UCJobs_grb_Job16);
            LstGbJobItem.Add(UCJobs_grb_Job17);
            LstGbJobItem.Add(UCJobs_grb_Job18);
            LstGbJobItem.Add(UCJobs_grb_Job19);
            LstGbJobItem.Add(UCJobs_grb_Job20);
            LstGbJobItem.Add(UCJobs_grb_Job21);

            LstPbJobLogo.Add(UCJobs_pb_Logo1);
            LstPbJobLogo.Add(UCJobs_pb_Logo2);
            LstPbJobLogo.Add(UCJobs_pb_Logo3);
            LstPbJobLogo.Add(UCJobs_pb_Logo4);
            LstPbJobLogo.Add(UCJobs_pb_Logo5);
            LstPbJobLogo.Add(UCJobs_pb_Logo6);
            LstPbJobLogo.Add(UCJobs_pb_Logo7);
            LstPbJobLogo.Add(UCJobs_pb_Logo8);
            LstPbJobLogo.Add(UCJobs_pb_Logo9);
            LstPbJobLogo.Add(UCJobs_pb_Logo10);
            LstPbJobLogo.Add(UCJobs_pb_Logo11);
            LstPbJobLogo.Add(UCJobs_pb_Logo12);
            LstPbJobLogo.Add(UCJobs_pb_Logo13);
            LstPbJobLogo.Add(UCJobs_pb_Logo14);
            LstPbJobLogo.Add(UCJobs_pb_Logo15);
            LstPbJobLogo.Add(UCJobs_pb_Logo16);
            LstPbJobLogo.Add(UCJobs_pb_Logo17);
            LstPbJobLogo.Add(UCJobs_pb_Logo18);
            LstPbJobLogo.Add(UCJobs_pb_Logo19);
            LstPbJobLogo.Add(UCJobs_pb_Logo20);
            LstPbJobLogo.Add(UCJobs_pb_Logo21);

            LstTbJobTitle.Add(UCJobs_tb_Title1);
            LstTbJobTitle.Add(UCJobs_tb_Title2);
            LstTbJobTitle.Add(UCJobs_tb_Title3);
            LstTbJobTitle.Add(UCJobs_tb_Title4);
            LstTbJobTitle.Add(UCJobs_tb_Title5);
            LstTbJobTitle.Add(UCJobs_tb_Title6);
            LstTbJobTitle.Add(UCJobs_tb_Title7);
            LstTbJobTitle.Add(UCJobs_tb_Title8);
            LstTbJobTitle.Add(UCJobs_tb_Title9);
            LstTbJobTitle.Add(UCJobs_tb_Title10);
            LstTbJobTitle.Add(UCJobs_tb_Title11);
            LstTbJobTitle.Add(UCJobs_tb_Title12);
            LstTbJobTitle.Add(UCJobs_tb_Title13);
            LstTbJobTitle.Add(UCJobs_tb_Title14);
            LstTbJobTitle.Add(UCJobs_tb_Title15);
            LstTbJobTitle.Add(UCJobs_tb_Title16);
            LstTbJobTitle.Add(UCJobs_tb_Title17);
            LstTbJobTitle.Add(UCJobs_tb_Title18);
            LstTbJobTitle.Add(UCJobs_tb_Title19);
            LstTbJobTitle.Add(UCJobs_tb_Title20);
            LstTbJobTitle.Add(UCJobs_tb_Title21);

            LstTbJobSalary.Add(UCJobs_tb_Salary1);
            LstTbJobSalary.Add(UCJobs_tb_Salary2);
            LstTbJobSalary.Add(UCJobs_tb_Salary3);
            LstTbJobSalary.Add(UCJobs_tb_Salary4);
            LstTbJobSalary.Add(UCJobs_tb_Salary5);
            LstTbJobSalary.Add(UCJobs_tb_Salary6);
            LstTbJobSalary.Add(UCJobs_tb_Salary7);
            LstTbJobSalary.Add(UCJobs_tb_Salary8);
            LstTbJobSalary.Add(UCJobs_tb_Salary9);
            LstTbJobSalary.Add(UCJobs_tb_Salary10);
            LstTbJobSalary.Add(UCJobs_tb_Salary11);
            LstTbJobSalary.Add(UCJobs_tb_Salary12);
            LstTbJobSalary.Add(UCJobs_tb_Salary13);
            LstTbJobSalary.Add(UCJobs_tb_Salary14);
            LstTbJobSalary.Add(UCJobs_tb_Salary15);
            LstTbJobSalary.Add(UCJobs_tb_Salary16);
            LstTbJobSalary.Add(UCJobs_tb_Salary17);
            LstTbJobSalary.Add(UCJobs_tb_Salary18);
            LstTbJobSalary.Add(UCJobs_tb_Salary19);
            LstTbJobSalary.Add(UCJobs_tb_Salary20);
            LstTbJobSalary.Add(UCJobs_tb_Salary21);

        }
        public void setDataResSearchKey(DataTable Form1_ResSearch, string Form1_tb_keySearch)
        {
            ResSearchKey = Form1_ResSearch.Copy();
            UCJobs_tb_countResSearch.Text = ResSearchKey.Rows.Count.ToString() + " '" + Form1_tb_keySearch + "' jobs";
        }
        public void CopyDataForm1(DataTable Form1_DataCompanyProfile, DataTable Form1_DataJobs)
        {
            DataCompanyProfile = Form1_DataCompanyProfile.Copy();
            DataJobs = Form1_DataJobs.Copy();
        }

        //Giá trị bắt đầu và kết thúc mỗi page
        public void DefineidCurPage()
        {
            if (idCurPage == 1 && idFutPage == 1)
            {
                beginSTT = 0;
                endSTT = beginSTT + 20;
                if (ResSearchKey.Rows.Count - beginSTT < 21)
                {
                    endSTT = ResSearchKey.Rows.Count - beginSTT - 1;
                }
            }
            else
            {
                if (idFutPage < idCurPage)
                {
                    beginSTT -= 21;
                    if (ResSearchKey.Rows.Count - beginSTT <= 21)
                    {
                        endSTT = ResSearchKey.Rows.Count- 1;
                    }
                    else
                    {
                        endSTT = beginSTT + 20;
                    }
                }
                else if (idFutPage > idCurPage)
                {
                    beginSTT += 21;
                    if (ResSearchKey.Rows.Count - beginSTT <= 21)
                    {
                        endSTT = ResSearchKey.Rows.Count - 1;
                    }
                    else
                    {
                        endSTT = beginSTT + 20;
                    }
                }
            }

            int x = endSTT - beginSTT + 1;
            for (int i = 0; i < x; i++)
            {
                LstGbJobItem[i].Visible = true;
            }
        }
        //Hiển thị các công việc trong mỗi groupbox
        public void JobsDisplayPage()
        {
            DefineidCurPage();
            if (beginSTT < ResSearchKey.Rows.Count)
            {
                int idLst = 0;
                for (int i = beginSTT; i <= endSTT; i++)
                {
                    LstTbJobTitle[idLst].Text = ResSearchKey.Rows[i]["title"].ToString();
                    LstTbJobSalary[idLst].Text = ResSearchKey.Rows[i]["salary"].ToString();

                    string[] arraySkill = ResSearchKey.Rows[i]["skill"].ToString().Split("-".ToCharArray());
                    for (int j = 0; j < arraySkill.Length; j++)
                    {
                        if (j > 6)
                        {
                            break;
                        }
                        LstListBtSkill[idLst][j].Visible = true;
                        LstListBtSkill[idLst][j].Text = arraySkill[j];
                    }

                    string exp = string.Format("company_name = '{0}'", ResSearchKey.Rows[i]["company_name"].ToString());
                    DataRow[] rowCompany = DataCompanyProfile.Select(exp);
                    if (rowCompany.Length > 0)
                    {
                        string path_img = "logo/" + rowCompany[0]["logo_name"].ToString();
                        LstPbJobLogo[idLst].Image = Image.FromFile(path_img);
                    }
                    idLst++;
                }
            }
            
        }

        //Hiển thị công việc chi tiết
        public void DetailJobsChoose(int idx)
        {
            if (ResSearchKey.Rows.Count != 0)
            {
                UCJobs_detail_pn_Detail.Visible = true;
                UCJobs_detail_lb_Title.Text = ResSearchKey.Rows[beginSTT + idx]["title"].ToString();
                UCJobs_detail_tb_Salary.Text = ResSearchKey.Rows[beginSTT + idx]["salary"].ToString();
                UCJobs_detail_tb_LocationJob.Text = ResSearchKey.Rows[beginSTT + idx]["location_detail"].ToString();
                UCJobs_detail_TimeUpJob.Text = ResSearchKey.Rows[beginSTT + idx]["distance_time"].ToString();
                UCJobs_detail_lb_companyName.Text = ResSearchKey.Rows[beginSTT + idx]["company_name"].ToString();
                //UCJobs_detail_TimeUpJob
                UCJobs_detail_rtb_JobReason.Text = ResSearchKey.Rows[beginSTT + idx]["reason_job"].ToString();
                if (UCJobs_detail_rtb_JobReason.Text == "none")
                {
                    UCJobs_detail_rtb_JobReason.Text = "";
                }
                UCJobs_detail_rtb_JobDescription.Text = ResSearchKey.Rows[beginSTT + idx]["job_description"].ToString();
                UCJobs_detail_rtb_JobSkillExp.Text = ResSearchKey.Rows[beginSTT + idx]["skill_experience"].ToString();
                UCJobs_detail_rtb_JobLoveWork.Text = ResSearchKey.Rows[beginSTT + idx]["love_working"].ToString();
                if (UCJobs_detail_rtb_JobLoveWork.Text == "none")
                {
                    UCJobs_detail_rtb_JobLoveWork.Text = "";
                }

                string[] arraySkill = ResSearchKey.Rows[beginSTT + idx]["skill"].ToString().Split("-".ToCharArray());
                for (int j = 0; j < arraySkill.Length; j++)
                {
                    if (j > 5)
                    {
                        break;
                    }
                    LstBtDetailSkill[j].Visible = true;
                    LstBtDetailSkill[j].Text = arraySkill[j];
                }

                UCJobs_detail_lb_CompanySlogan.Text = ResSearchKey.Rows[beginSTT + idx]["slogan"].ToString();
                string exp = string.Format("company_name = '{0}'", ResSearchKey.Rows[beginSTT + idx]["company_name"].ToString());
                DataRow[] rowCompany = DataCompanyProfile.Select(exp);
                string path_img = "logo/" + rowCompany[0]["logo_name"].ToString();
                UCJobs_detail_pb_CompanyLogo.Image = Image.FromFile(path_img);
                UCJobs_detail_lb_CompayName.Text = rowCompany[0]["company_name"].ToString();
                UCJobs_detail_tb_CompanyField.Text = rowCompany[0]["field"].ToString();
                UCJobs_detail_tb_CompanyPeople.Text = rowCompany[0]["people"].ToString();
                UCJobs_detail_tb_CompanyWorkingDay.Text = rowCompany[0]["working_day"].ToString();
                if (UCJobs_detail_tb_CompanyWorkingDay.Text == "none")
                {
                    UCJobs_detail_tb_CompanyWorkingDay.Text = "";
                }
                UCJobs_detail_tb_CompanyCountry.Text = rowCompany[0]["country"].ToString();
                UCJobs_detail_tb_CompanyTimeOT.Text = rowCompany[0]["timeOT"].ToString();
                if (UCJobs_detail_tb_CompanyTimeOT.Text == "none")
                {
                    UCJobs_detail_tb_CompanyTimeOT.Text = "";
                }
            }
            else
            {
                UCJobs_detail_pn_Detail.Visible = false;
            }
            
        }

        private void UC_DisplayJobs_Load(object sender, EventArgs e)
        {
            setDisplay();
            JobsDisplayPage();
            DefineidCurPage();
            DetailJobsChoose(0);
        }

        //********************************************
        //Sự kiện tìm kiếm từ khóa mới
        //********************************************
        //Chú ý CountRowsJobs
        public void DataSearch()
        {
            string[] keySearch = UCJobs_tb_keySearch.Text.ToLower().Replace(",", "").Replace(".", "").Replace("-", " ").Replace("usd", "").Split(" ".ToCharArray());
            keySearch = keySearch.Where(val => val != "").ToArray();
            DataTable dkey = DataJobs.Clone();
            DataRow row = dkey.NewRow();
            for (int i = 0; i < 498; i++)   // CountRowsJobs
            {
                int countTitle = 0;
                int countSkill = 0;
                int countSalary = 0;
                int countName = 0;

                string temp1 = DataJobs.Rows[i]["title"].ToString().ToLower().Replace("(", " ").Replace("/", " ").Replace("-", " ").Replace(")", " ").Replace(",", " ");
                string[] keyTitle = temp1.Split(" ".ToCharArray());

                string[] keySkill = DataJobs.Rows[i]["skill"].ToString().ToLower().Split("-".ToCharArray());

                string tempName = DataJobs.Rows[i]["company_name"].ToString().ToLower().Replace(".", " ").Replace("-", " ").Replace(",", " ").Replace("(", " ").Replace(")", " ");
                string[] keyName = tempName.Split(" ".ToCharArray());
                string NameSearch = DataJobs.Rows[i]["company_name"].ToString().ToLower();

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
                if (countTitle > 0 || countSkill > 0 || countSalary > 0 || countName > 0 || NameSearch == UCJobs_tb_keySearch.Text.ToLower())
                {
                    row = DataJobs.Rows[i];
                    dkey.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11]);
                }
                setDataResSearchKey(dkey, UCJobs_tb_keySearch.Text);
                UCJobs_tb_countResSearch.Text = ResSearchKey.Rows.Count.ToString() + " '" +  UCJobs_tb_keySearch.Text + "' jobs";
            }
        }
        private void UCJobs_bt_Search_Click(object sender, EventArgs e)
        {
            DataSearch();
            setDisplay();
            JobsDisplayPage();
        }

        //********************************************
        //Sự kiện next page
        //********************************************
        private void UCJobs_bt_backPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(UCJobs_bt_pageA.Text) - 3;
            int b = Int32.Parse(UCJobs_bt_pageB.Text) - 3;
            int c = Int32.Parse(UCJobs_bt_pageC.Text) - 3;
            UCJobs_bt_pageA.Text = a.ToString();
            UCJobs_bt_pageB.Text = b.ToString();
            UCJobs_bt_pageC.Text = c.ToString();
        }
        private void UCJobs_bt_nextPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(UCJobs_bt_pageA.Text) + 3;
            int b = Int32.Parse(UCJobs_bt_pageB.Text) + 3;
            int c = Int32.Parse(UCJobs_bt_pageC.Text) + 3;
            UCJobs_bt_pageA.Text = a.ToString();
            UCJobs_bt_pageB.Text = b.ToString();
            UCJobs_bt_pageC.Text = c.ToString();
        }
        private void UCJobs_bt_pageA_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(UCJobs_bt_pageA.Text);
            setDisplay();
            JobsDisplayPage();
            DetailJobsChoose(0);
            UCJobs_bt_pageA.BackColor = Color.Red;
            UCJobs_bt_pageB.BackColor = Color.White;
            UCJobs_bt_pageC.BackColor = Color.White;
        }

        private void UCJobs_bt_pageB_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(UCJobs_bt_pageB.Text);
            if (ResSearchKey.Rows.Count - beginSTT >= 20)
            {
                setDisplay();
                JobsDisplayPage();
                DetailJobsChoose(0);
            }
            else
            {
                setDisplay();
            }
            UCJobs_bt_pageB.BackColor = Color.Red;
            UCJobs_bt_pageA.BackColor = Color.White;
            UCJobs_bt_pageC.BackColor = Color.White;
        }

        private void UCJobs_bt_pageC_Click(object sender, EventArgs e)
        {
            idFutPage = Int32.Parse(UCJobs_bt_pageC.Text);
            if (ResSearchKey.Rows.Count - beginSTT >= 20)
            {
                setDisplay();
                JobsDisplayPage();
                DetailJobsChoose(0);
            }
            else
            {
                setDisplay();
            }
            UCJobs_bt_pageC.BackColor = Color.Red;
            UCJobs_bt_pageB.BackColor = Color.White;
            UCJobs_bt_pageA.BackColor = Color.White;
        }
        //*********************************
        public string getCurrentDateTime()
        {
            return string.Format("{0}-{1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"));
        }
        public void AddDataViewer(string title, string companyName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string DataView = Path.Combine(executableLocation, "data_counterViewJobs.xlsx");

            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();
            //Notice: Change this path to your real excel file path
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataView);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int row = excelRange.Rows.Count;

            excelApp.Cells[row+1, 1] = companyName;
            excelApp.Cells[row+1, 2] = title;
            excelApp.Cells[row+1, 3] = getCurrentDateTime();

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

        //***********************************
        //Sự kiện khi click vào mỗi groupbox mỗi công việc
        private void UCJobs_grb_Job1_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(0);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job2_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(1);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job3_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(2);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job4_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(3);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job5_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(4);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job6_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(5);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job7_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(6);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job8_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(7);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job9_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(8);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job10_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(9);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job11_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(10);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job12_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(11);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job13_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(12);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job14_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(13);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job15_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(14);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job16_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(15);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job17_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(16);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job18_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(17);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job19_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(18);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job20_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(19);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        private void UCJobs_grb_Job21_Click(object sender, EventArgs e)
        {
            DetailJobsChoose(20);
            AddDataViewer(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
        }

        //*********************************
        //Sự kiến khi click vào nút apply
        private void UCJobs_detail_bt_Apply_Click(object sender, EventArgs e)
        {
            FormApplyJob frmApply = new FormApplyJob();
            frmApply.setTitle(UCJobs_detail_lb_Title.Text, UCJobs_detail_lb_companyName.Text);
            frmApply.ShowDialog();
        }

        private void UCJobs_LinkLb_Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
