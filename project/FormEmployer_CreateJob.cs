using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace project
{
    public partial class FormEmployer_CreateJob : Form
    {
        private FormEmployer FormEmployer = null;
        public FormEmployer_CreateJob(Form callingForm)
        {
            FormEmployer = callingForm as FormEmployer;
            InitializeComponent();
            addList();
        }

        DataTable DataJobs = new DataTable();
        string title = "";
        List<Button> LstSkill = new List<Button>();
        bool CheckEditTitle = false;
        bool CheckEditSkill = false;
        bool CheckEditInfo = false;
        bool CheckEditReason = false;
        bool CheckEditDescription = false;
        bool CheckEditRequest = false;
        bool CheckEditLoveWork = false;

        bool CheckCreateJob = false;
        string CompanyName = "";
        string slogan = "";

        public DataTable getsetDataJob
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
        public string setTitle
        {
            set
            {
                title = value;
            }
        }
        public bool setCheckCreateJob
        {
            set
            {
                CheckCreateJob = value;
            }
        }
        public string setCompanyName
        {
            set
            {
                CompanyName = value;
            }
        }
        public string setSlogan
        {
            set
            {
                slogan = value;
            }
        }
        void addList()
        {
            LstSkill.Add(FormEmp_detail_bt_Skill1);
            LstSkill.Add(FormEmp_detail_bt_Skill2);
            LstSkill.Add(FormEmp_detail_bt_Skill3);
            LstSkill.Add(FormEmp_detail_bt_Skill4);
            LstSkill.Add(FormEmp_detail_bt_Skill5);
        }

        void setDisplay()
        {
            if (!CheckCreateJob)
            {
                for (int j = 0; j < 5; j++)
                {
                    LstSkill[j].Visible = false;
                }
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    LstSkill[j].Visible = true;
                }
            }
            
        }
        private void FormEmployer_CreateJob_Load(object sender, EventArgs e)
        {
            setDisplay();
            if (!CheckCreateJob)
            {
                FormEmp_detail_bt_Update.Text = "Cập nhật";
                string exp = string.Format("title = '{0}'", title);
                DataRow[] rowJobs = DataJobs.Select(exp);
                FormEmp_detail_tb_Title.Text = title;
                FormEmp_detail_lb_companyName.Text = rowJobs[0]["company_name"].ToString();
                FormEmp_detail_tb_Salary.Text = rowJobs[0]["salary"].ToString();
                FormEmp_detail_TimeUpJob.Text = rowJobs[0]["distance_time"].ToString();
                FormEmp_detail_tb_LocationJob.Text = rowJobs[0]["location_detail"].ToString();
                FormEmp_detail_rtb_JobReason.Text = rowJobs[0]["reason_job"].ToString();
                FormEmp_detail_rtb_JobDescription.Text = rowJobs[0]["job_description"].ToString();
                FormEmp_detail_rtb_JobSkillExp.Text = rowJobs[0]["skill_experience"].ToString();
                FormEmp_detail_rtb_JobLoveWork.Text = rowJobs[0]["love_working"].ToString();

                string[] arraySkill = rowJobs[0]["skill"].ToString().Split("-".ToCharArray());
                for (int j = 0; j < arraySkill.Length; j++)
                {
                    if (j > 5)
                    {
                        break;
                    }
                    LstSkill[j].Visible = true;
                    LstSkill[j].Text = arraySkill[j];
                }
            }
            else
            {
                FormEmp_detail_bt_Update.Text = "Đăng việc";
                FormEmp_detail_lb_companyName.Text = CompanyName;

            }
            
        }
        int checkIdSkill = 0;
        private void FormEmp_detail_bt_Skill1_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = true;
            checkIdSkill = 0;
        }

        private void FormEmp_detail_bt_Skill2_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = true;
            checkIdSkill = 1;
        }

        private void FormEmp_detail_bt_Skill3_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = true;
            checkIdSkill = 2;
        }

        private void FormEmp_detail_bt_Skill4_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = true;
            checkIdSkill = 3;
        }

        private void FormEmp_detail_bt_Skill5_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = true;
            checkIdSkill = 4;
        }

        private void FormEmp_detail_bt_DoneSkill_Click(object sender, EventArgs e)
        {
            FormEmp_detail_pn_EditSkill.Visible = false;
            LstSkill[checkIdSkill].Text = FormEmp_detail_tb_EditSkill.Text;
        }
        private void FormEmp_LinkLb_EditTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditTitle == false)
            {
                FormEmp_detail_tb_Title.ReadOnly = false;
                FormEmp_LinkLb_EditTitle.Text = "Xong";
                CheckEditTitle = true;

            }
            else
            {
                FormEmp_detail_tb_Title.ReadOnly = true;
                FormEmp_LinkLb_EditTitle.Text = "Chỉnh sửa";
                CheckEditTitle = false;
            }
        }

        private void FormEmp_LinkLb_EditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditInfo == false)
            {
                FormEmp_detail_tb_Salary.ReadOnly = false;
                FormEmp_detail_tb_LocationJob.ReadOnly = false;

                FormEmp_LinkLb_EditInfo.Text = "Xong";
                CheckEditInfo = true;

            }
            else
            {
                FormEmp_detail_tb_Salary.ReadOnly = true;
                FormEmp_detail_tb_LocationJob.ReadOnly = true;
                FormEmp_LinkLb_EditInfo.Text = "Chỉnh sửa";
                CheckEditInfo = false;
            }
        }

        private void FormEmp_LinkLb_EditReason_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditReason == false)
            {
                FormEmp_detail_rtb_JobReason.ReadOnly = false;
                FormEmp_LinkLb_EditReason.Text = "Xong";
                CheckEditReason = true;
            }
            else
            {
                FormEmp_detail_rtb_JobReason.ReadOnly = true;
                FormEmp_LinkLb_EditReason.Text = "Chỉnh sửa";
                CheckEditReason = false;
            }
        }

        private void FormEmp_LinkLb_EditDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditDescription == false)
            {
                FormEmp_detail_rtb_JobDescription.ReadOnly = false;
                FormEmp_LinkLb_EditDescription.Text = "Xong";
                CheckEditDescription = true;
            }
            else
            {
                FormEmp_detail_rtb_JobDescription.ReadOnly = true;
                FormEmp_LinkLb_EditDescription.Text = "Chỉnh sửa";
                CheckEditDescription = false;
            }
        }

        private void FormEmp_LinkLb_EditRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditRequest == false)
            {
                FormEmp_detail_rtb_JobSkillExp.ReadOnly = false;
                FormEmp_LinkLb_EditRequest.Text = "Xong";
                CheckEditRequest = true;
            }
            else
            {
                FormEmp_detail_rtb_JobSkillExp.ReadOnly = true;
                FormEmp_LinkLb_EditRequest.Text = "Chỉnh sửa";
                CheckEditRequest = false;
            }
        }

        private void FormEmp_LinkLb_EditLoveWork_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckEditLoveWork == false)
            {
                FormEmp_detail_rtb_JobLoveWork.ReadOnly = false;
                FormEmp_LinkLb_EditLoveWork.Text = "Xong";
                CheckEditLoveWork = true;
            }
            else
            {
                FormEmp_detail_rtb_JobLoveWork.ReadOnly = true;
                FormEmp_LinkLb_EditLoveWork.Text = "Chỉnh sửa";
                CheckEditLoveWork = false;
            }
        }

        public string getCurrentDateTime()
        {
            return string.Format("{0}-{1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"));
        }
        public string combineSkill()
        {
            string skill = LstSkill[0].Text;
            for (int i = 1; i < 5; i++)
            {
                if (LstSkill[i].Text != "")
                {
                    skill = skill + string.Format("-{0}",LstSkill[i].Text);
                }
            }
            return skill;
        }
        string messNotify = "";
        public string setmessNotify
        {
            set
            {
                messNotify = value;
            }
        }
        private void FormEmp_detail_bt_Update_Click(object sender, EventArgs e)
        {
            if (CheckCreateJob)
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string DataAccEmp = Path.Combine(executableLocation, "data_jobs.xlsx");

                //Create COM Objects.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                //Notice: Change this path to your real excel file path
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                ExcelApp.Range r = (ExcelApp.Range)excelSheet.Rows[2];
                r.Insert();
                
                excelApp.Cells[2, 1] = CompanyName;
                excelApp.Cells[2, 2] = FormEmp_detail_tb_Title.Text;
                excelApp.Cells[2, 3] = FormEmp_detail_tb_Salary.Text;
                excelApp.Cells[2, 4] = getCurrentDateTime();
                excelApp.Cells[2, 5] = "New";
                excelApp.Cells[2, 6] = combineSkill();
                excelApp.Cells[2, 7] = FormEmp_detail_tb_LocationJob.Text;
                excelApp.Cells[2, 8] = FormEmp_detail_rtb_JobReason.Text;
                excelApp.Cells[2, 9] = FormEmp_detail_rtb_JobDescription.Text;
                excelApp.Cells[2, 10] = FormEmp_detail_rtb_JobSkillExp.Text;
                excelApp.Cells[2, 11] = FormEmp_detail_rtb_JobLoveWork.Text;
                excelApp.Cells[2, 12] = slogan;

                insertDataJobs();
                FormEmployer.setDataJobs = DataJobs;
                FormEmployer.DisplayJob();

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

                MessageBox.Show("Đăng công việc thành công");
            }
            else
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string DataAccEmp = Path.Combine(executableLocation, "data_jobs.xlsx");

                //Create COM Objects.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                //Notice: Change this path to your real excel file path
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DataAccEmp);
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int row = excelRange.Rows.Count;
                int id = 0;
                //ExcelApp.Range r = (ExcelApp.Range)excelSheet.Rows[2];
                //r.Insert();
                for (int i = 0; i < row - 1; i++)
                {
                    if (title == DataJobs.Rows[i]["title"].ToString())
                    {
                        id = i;
                        break;
                    }
                }

                excelApp.Cells[id + 2, 1] = CompanyName;
                excelApp.Cells[id + 2, 2] = FormEmp_detail_tb_Title.Text;
                excelApp.Cells[id + 2, 3] = FormEmp_detail_tb_Salary.Text;
                excelApp.Cells[id + 2, 4] = getCurrentDateTime();
                excelApp.Cells[id + 2, 5] = "New";
                excelApp.Cells[id + 2, 6] = combineSkill();
                excelApp.Cells[id + 2, 7] = FormEmp_detail_tb_LocationJob.Text;
                excelApp.Cells[id + 2, 8] = FormEmp_detail_rtb_JobReason.Text;
                excelApp.Cells[id + 2, 9] = FormEmp_detail_rtb_JobDescription.Text;
                excelApp.Cells[id + 2, 10] = FormEmp_detail_rtb_JobSkillExp.Text;
                excelApp.Cells[id + 2, 11] = FormEmp_detail_rtb_JobLoveWork.Text;
                excelApp.Cells[id + 2, 12] = slogan;

                EditDataJobs(id);
                FormEmployer.setDataJobs = DataJobs;
                FormEmployer.DisplayJob();

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

                MessageBox.Show("Cập nhật công việc thành công");
            }

            
            
        }
        public void insertDataJobs()
        {
            DataRow toInsertJob = DataJobs.NewRow();

            toInsertJob["company_name"] = CompanyName;
            toInsertJob["title"] = FormEmp_detail_tb_Title.Text;
            toInsertJob["salary"] = FormEmp_detail_tb_Salary.Text;
            toInsertJob["distance_time"] = getCurrentDateTime();
            toInsertJob["feature_new_text"] = "New";
            toInsertJob["skill"] = combineSkill();
            toInsertJob["location_detail"] = FormEmp_detail_tb_LocationJob.Text;
            toInsertJob["reason_job"] = FormEmp_detail_rtb_JobReason.Text;
            toInsertJob["job_description"] = FormEmp_detail_rtb_JobDescription.Text;
            toInsertJob["skill_experience"] = FormEmp_detail_rtb_JobSkillExp.Text;
            toInsertJob["love_working"] = FormEmp_detail_rtb_JobLoveWork.Text;
            toInsertJob["slogan"] = slogan;

            DataJobs.Rows.InsertAt(toInsertJob, 0);
        }
        public void EditDataJobs(int id)
        {

            DataJobs.Rows[id]["company_name"] = CompanyName;
            DataJobs.Rows[id]["title"] = FormEmp_detail_tb_Title.Text;
            DataJobs.Rows[id]["salary"] = FormEmp_detail_tb_Salary.Text;
            DataJobs.Rows[id]["distance_time"] = getCurrentDateTime();
            DataJobs.Rows[id]["feature_new_text"] = "New";
            DataJobs.Rows[id]["skill"] = combineSkill();
            DataJobs.Rows[id]["location_detail"] = FormEmp_detail_tb_LocationJob.Text;
            DataJobs.Rows[id]["reason_job"] = FormEmp_detail_rtb_JobReason.Text;
            DataJobs.Rows[id]["job_description"] = FormEmp_detail_rtb_JobDescription.Text;
            DataJobs.Rows[id]["skill_experience"] = FormEmp_detail_rtb_JobSkillExp.Text;
            DataJobs.Rows[id]["love_working"] = FormEmp_detail_rtb_JobLoveWork.Text;
            DataJobs.Rows[id]["slogan"] = slogan;
        }
    }
}
