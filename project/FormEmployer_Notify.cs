using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormEmployer_Notify : Form
    {
        private FormEmployer FormEmployer = null;
        public FormEmployer_Notify(Form callingForm)
        {
            FormEmployer = callingForm as FormEmployer;
            InitializeComponent();
            AddList();
        }

        List<GroupBox> LstNotify = new List<GroupBox>();
        List<TextBox> LstNotifyTitle = new List<TextBox>();
        List<TextBox> LstNotifyTimeUp = new List<TextBox>();
        List<GroupBox> LstCV = new List<GroupBox>();
        List<LinkLabel> LstCVName = new List<LinkLabel>();
        List<LinkLabel> LstCVFile = new List<LinkLabel>();

        DataTable DataJobs = new DataTable();
        DataTable DataApplyCV = new DataTable();

        string CompanyName = "";
        public string setCompanyName
        {
            set
            {
                CompanyName = value;
            }
        }
        public DataTable setDataJobs
        {
            set
            {
                DataJobs = value;
            }
        }
        public DataTable setDataApplyCV
        {
            set
            {
                DataApplyCV = value;
            }
        }
        private void FormEmployer_Notify_Load(object sender, EventArgs e)
        {
            ShowJobsNotify();
            setOriginApply();
        }
        public void AddList()
        {
            LstCVName.Add(FormEmp_LinkLb_CVName1);
            LstCVName.Add(FormEmp_LinkLb_CVName2);
            LstCVName.Add(FormEmp_LinkLb_CVName3);
            LstCVName.Add(FormEmp_LinkLb_CVName4);
            LstCVName.Add(FormEmp_LinkLb_CVName5);
            LstCVName.Add(FormEmp_LinkLb_CVName6);
            LstCVName.Add(FormEmp_LinkLb_CVName7);
            LstCVName.Add(FormEmp_LinkLb_CVName8);
            LstCVName.Add(FormEmp_LinkLb_CVName9);

            LstCVFile.Add(FormEmp_LinkLb_CVFile1);
            LstCVFile.Add(FormEmp_LinkLb_CVFile2);
            LstCVFile.Add(FormEmp_LinkLb_CVFile3);
            LstCVFile.Add(FormEmp_LinkLb_CVFile4);
            LstCVFile.Add(FormEmp_LinkLb_CVFile5);
            LstCVFile.Add(FormEmp_LinkLb_CVFile6);
            LstCVFile.Add(FormEmp_LinkLb_CVFile7);
            LstCVFile.Add(FormEmp_LinkLb_CVFile8);
            LstCVFile.Add(FormEmp_LinkLb_CVFile9);

            LstNotifyTitle.Add(FormEmp_tb_NotifyTitle1);
            LstNotifyTitle.Add(FormEmp_tb_NotifyTitle2);
            LstNotifyTitle.Add(FormEmp_tb_NotifyTitle3);
            LstNotifyTitle.Add(FormEmp_tb_NotifyTitle4);
            LstNotifyTitle.Add(FormEmp_tb_NotifyTitle5);
            LstNotifyTimeUp.Add(FormEmp_tb_TimeUp1);
            LstNotifyTimeUp.Add(FormEmp_tb_TimeUp2);
            LstNotifyTimeUp.Add(FormEmp_tb_TimeUp3);
            LstNotifyTimeUp.Add(FormEmp_tb_TimeUp4);
            LstNotifyTimeUp.Add(FormEmp_tb_TimeUp5);

            LstNotify.Add(FormEmp_grb_Notify1);
            LstNotify.Add(FormEmp_grb_Notify2);
            LstNotify.Add(FormEmp_grb_Notify3);
            LstNotify.Add(FormEmp_grb_Notify4);
            LstNotify.Add(FormEmp_grb_Notify5);

            LstCV.Add(FormEmp_grb_CV1);
            LstCV.Add(FormEmp_grb_CV2);
            LstCV.Add(FormEmp_grb_CV3);
            LstCV.Add(FormEmp_grb_CV4);
            LstCV.Add(FormEmp_grb_CV5);
            LstCV.Add(FormEmp_grb_CV6);
            LstCV.Add(FormEmp_grb_CV7);
            LstCV.Add(FormEmp_grb_CV8);
            LstCV.Add(FormEmp_grb_CV9);
        }

        int CountJobs = 0;
        int idCurPageJobs = 1;
        int idFutPageJobs = 1;
        int beginSTTJobs = 0;
        int endSTTJobs = 0;
        string titleApply = "";
        public void setOriginJobs()
        {
            for (int i = 0; i < 5; i++)
            {
                LstNotify[i].Visible = false;
            }
            for (int i = 0; i < 9; i++)
            {
                LstCV[i].Visible = false;
            }
        }
        public void DefineidCurPageJobs()
        {
            if (idCurPageJobs == 1 && idFutPageJobs == 1)
            {
                beginSTTJobs = 0;
                endSTTJobs = beginSTTJobs + 4;
                if (CountJobs - beginSTTJobs < 5)
                {
                    endSTTJobs = CountJobs - beginSTTJobs - 1;
                }
            }
            else
            {
                if (idFutPageJobs < idCurPageJobs)
                {
                    beginSTTJobs -= 5;
                    if (CountJobs - beginSTTJobs <= 5)
                    {
                        endSTTJobs = CountJobs - 1;
                    }
                    else
                    {
                        endSTTJobs = beginSTTJobs + 4;
                    }
                }
                else if (idFutPageJobs > idCurPageJobs)
                {
                    beginSTTJobs += 5;
                    if (CountJobs - beginSTTJobs <= 5)
                    {
                        endSTTJobs = CountJobs - 1;
                    }
                    else
                    {
                        endSTTJobs = beginSTTJobs + 4;
                    }
                }
            }

            int x = endSTTJobs - beginSTTJobs + 1;
            for (int i = 0; i < x; i++)
            {
                LstNotify[i].Visible = true;
            }
        }
        public void ShowJobsNotify()
        {
            FormEmp_bt_NotifyPageA.BackColor = Color.Red;
            string exp = string.Format("company_name = '{0}'", CompanyName);
            DataRow[] rowJobs = DataJobs.Select(exp);
            CountJobs = rowJobs.Length;
            DefineidCurPageJobs();
            if (beginSTTJobs < rowJobs.Length)
            {
                int idLst = 0;
                for (int i = beginSTTJobs; i <= endSTTJobs; i++)
                {
                    LstNotifyTitle[idLst].Text = rowJobs[i]["title"].ToString();
                    LstNotifyTimeUp[idLst].Text = rowJobs[i]["distance_time"].ToString();

                    string CountExp = string.Format("title = '{0}'", LstNotifyTitle[idLst].Text);
                    DataRow[] row = DataApplyCV.Select(CountExp);
                    LstNotify[idLst].Text = string.Format("({0})",row.Length.ToString());

                    idLst++;
                }
            }
        }
        void setColorOrigin()
        {
            for (int i = 0; i < 5; i++)
            {
                LstNotifyTitle[i].BackColor = Color.White;
            }
            for (int i = 0; i < 9; i++)
            {
                LstCVName[i].LinkColor = Color.Blue;
                LstCVFile[i].LinkColor = Color.Blue;
            }
        }
        private void FormEmp_grb_Notify1_Click(object sender, EventArgs e)
        {
            setColorOrigin();
            titleApply = FormEmp_tb_NotifyTitle1.Text;
            FormEmp_tb_NotifyTitle1.BackColor = Color.Red;
            ShowDetaiNotify();
        }

        private void FormEmp_grb_Notify2_Click(object sender, EventArgs e)
        {
            setColorOrigin();
            titleApply = FormEmp_tb_NotifyTitle2.Text;
            FormEmp_tb_NotifyTitle2.BackColor = Color.Red;
            ShowDetaiNotify();
        }

        private void FormEmp_grb_Notify3_Click(object sender, EventArgs e)
        {
            setColorOrigin();
            titleApply = FormEmp_tb_NotifyTitle3.Text;
            FormEmp_tb_NotifyTitle3.BackColor = Color.Red;
            ShowDetaiNotify();
        }

        private void FormEmp_grb_Notify4_Click(object sender, EventArgs e)
        {
            setColorOrigin();
            titleApply = FormEmp_tb_NotifyTitle4.Text;
            FormEmp_tb_NotifyTitle4.BackColor = Color.Red;
            ShowDetaiNotify();
        }

        private void FormEmp_grb_Notify5_Click(object sender, EventArgs e)
        {
            setColorOrigin();
            titleApply = FormEmp_tb_NotifyTitle5.Text;
            FormEmp_tb_NotifyTitle5.BackColor = Color.Red;
            ShowDetaiNotify();
        }

        private void FormEmp_bt_backNotifyPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_NotifyPageA.Text) - 3;
            int b = Int32.Parse(FormEmp_bt_NotifyPageB.Text) - 3;
            int c = Int32.Parse(FormEmp_bt_NotifyPageC.Text) - 3;
            FormEmp_bt_NotifyPageA.Text = a.ToString();
            FormEmp_bt_NotifyPageB.Text = b.ToString();
            FormEmp_bt_NotifyPageC.Text = c.ToString();
        }

        private void FormEmp_bt_NotifyPageA_Click(object sender, EventArgs e)
        {
            idFutPageJobs = Int32.Parse(FormEmp_bt_NotifyPageA.Text);
            setOriginJobs();
            ShowJobsNotify();
            FormEmp_bt_NotifyPageA.BackColor = Color.Red;
            FormEmp_bt_NotifyPageB.BackColor = Color.White;
            FormEmp_bt_NotifyPageC.BackColor = Color.White;
        }

        private void FormEmp_bt_NotifyPageB_Click(object sender, EventArgs e)
        {
            idFutPageJobs = Int32.Parse(FormEmp_bt_NotifyPageB.Text);
            if (CountJobs - beginSTTJobs >= 4)
            {
                setOriginJobs();
                ShowJobsNotify();
            }
            else
            {
                setOriginJobs();
            }
            FormEmp_bt_NotifyPageB.BackColor = Color.Red;
            FormEmp_bt_NotifyPageA.BackColor = Color.White;
            FormEmp_bt_NotifyPageC.BackColor = Color.White;
        }

        private void FormEmp_bt_NotifyPageC_Click(object sender, EventArgs e)
        {
            idFutPageJobs = Int32.Parse(FormEmp_bt_NotifyPageC.Text);
            if (CountJobs - beginSTTJobs >= 4)
            {
                setOriginJobs();
                ShowJobsNotify();
            }
            else
            {
                setOriginJobs();
            }
            FormEmp_bt_NotifyPageC.BackColor = Color.Red;
            FormEmp_bt_NotifyPageB.BackColor = Color.White;
            FormEmp_bt_NotifyPageA.BackColor = Color.White;
        }

        private void FormEmp_bt_nextNotifyPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_NotifyPageA.Text) + 3;
            int b = Int32.Parse(FormEmp_bt_NotifyPageB.Text) + 3;
            int c = Int32.Parse(FormEmp_bt_NotifyPageC.Text) + 3;
            FormEmp_bt_NotifyPageA.Text = a.ToString();
            FormEmp_bt_NotifyPageB.Text = b.ToString();
            FormEmp_bt_NotifyPageC.Text = c.ToString();
        }

        //**********************************
        //Sự kiện coi CV của ứng cử viên
        //************************************
        //Hiển thị số người apply
        int CountApply = 0;
        int idCurPageApply = 1;
        int idFutPageApply = 1;
        int beginSTTApply = 0;
        int endSTTApply = 0;
        public void setOriginApply()
        {
            for (int i = 0; i < 9; i++)
            {
                LstCV[i].Visible = false;
            }
        }
        public void DefineidCurPageApply()
        {
            if (idCurPageApply == 1 && idFutPageApply == 1)
            {
                beginSTTApply = 0;
                endSTTApply = beginSTTApply + 8;
                if (CountApply - beginSTTApply < 9)
                {
                    endSTTApply = CountApply - beginSTTApply - 1;
                }
            }
            else
            {
                if (idFutPageApply < idCurPageApply)
                {
                    beginSTTApply -= 9;
                    if (CountApply - beginSTTApply <= 9)
                    {
                        endSTTApply = CountApply - 1;
                    }
                    else
                    {
                        endSTTApply = beginSTTApply + 8;
                    }
                }
                else if (idFutPageApply > idCurPageApply)
                {
                    beginSTTApply += 9;
                    if (CountApply - beginSTTApply <= 9)
                    {
                        endSTTApply = CountApply - 1;
                    }
                    else
                    {
                        endSTTApply = beginSTTApply + 8;
                    }
                }
            }

            int x = endSTTApply - beginSTTApply + 1;
            for (int i = 0; i < x; i++)
            {
                LstCV[i].Visible = true;
            }
        }
        public void ShowDetaiNotify()
        {
            FormEmp_bt_CVPageA.BackColor = Color.Red;
            for (int i = 0; i < 9; i++)
            {
                LstCV[i].Visible = false;
            }
            string exp = string.Format("title = '{0}' AND company_name = '{1}'", titleApply, CompanyName);
            DataRow[] rowApply = DataApplyCV.Select(exp);
            CountApply = rowApply.Length;
            DefineidCurPageApply();
            if (beginSTTApply < rowApply.Length)
            {
                int idLst = 0;
                for (int i = beginSTTApply; i <= endSTTApply; i++)
                {
                    LstCV[idLst].Text = rowApply[i]["time_apply"].ToString();
                    LstCVName[idLst].Text = rowApply[i]["candidate_name"].ToString();
                    LstCVFile[idLst].Text = rowApply[i]["CV_name"].ToString();

                    idLst++;
                }
            }

        }
        public string pathCVFile(string name)
        {
            string exp = string.Format("title = '{0}' AND company_name = '{1}' AND candidate_name = '{2}'", titleApply, CompanyName, name);
            DataRow[] rowCV = DataApplyCV.Select(exp);
            if (rowCV.Length == 1)
            {
                return "CV/" + rowCV[0]["CV_name"].ToString();
            }
            else
            {
                return "CV/" + name;
            }
        }
        
        public void DetailCVName(string name)
        {
            FormEmp_pn_DetailCVName.Visible = true;
            FormEmp_tb_ApplyTitle.Text = titleApply;
            string exp = string.Format("title = '{0}' AND company_name = '{1}' AND candidate_name = '{2}'", titleApply, CompanyName, name);
            DataRow[] rowCVName = DataApplyCV.Select(exp);
            FormEmp_tb_UserEmail.Text = rowCVName[0]["candidate_mail"].ToString();
            FormEmp_rtb_UserDescribe.Text = rowCVName[0]["candidate_intro"].ToString();
        }
        private void FormEmp_LinkLb_CVName1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName1.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName1.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName2.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName2.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName3.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName3.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName4.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName4.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName5.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName5.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName6.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName6.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName7.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName7.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName8.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName8.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }

        private void FormEmp_LinkLb_CVName9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVName9.LinkColor = Color.Red;
            FormEmp_tb_UserName.Text = FormEmp_LinkLb_CVName9.Text;
            DetailCVName(FormEmp_tb_UserName.Text);
        }
        private void FormEmp_bt_CloseCVName_Click(object sender, EventArgs e)
        {
            FormEmp_pn_DetailCVName.Visible = false;
        }
        private void FormEmp_LinkLb_CVFile1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile1.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile1.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile1.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile2.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile2.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile2.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile3.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile3.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile3.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile4.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile4.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile4.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile5.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile5.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile5.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile6.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile6.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile6.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile7.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile7.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile7.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile8.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile8.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile8.Text;
            frmReadCV.Show();
        }

        private void FormEmp_LinkLb_CVFile9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmp_LinkLb_CVFile9.LinkColor = Color.Red;
            FormEmployer_Notify_ReadCV frmReadCV = new FormEmployer_Notify_ReadCV(this);
            frmReadCV.setpathCV = pathCVFile(FormEmp_LinkLb_CVFile9.Text);
            frmReadCV.setnameCV = FormEmp_LinkLb_CVFile9.Text;
            frmReadCV.Show();
        }

        private void FormEmp_bt_backCVPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_CVPageA.Text) - 3;
            int b = Int32.Parse(FormEmp_bt_CVPageB.Text) - 3;
            int c = Int32.Parse(FormEmp_bt_CVPageC.Text) - 3;
            FormEmp_bt_CVPageA.Text = a.ToString();
            FormEmp_bt_CVPageB.Text = b.ToString();
            FormEmp_bt_CVPageC.Text = c.ToString();
        }

        private void FormEmp_bt_CVPageA_Click(object sender, EventArgs e)
        {
            idFutPageApply = Int32.Parse(FormEmp_bt_CVPageA.Text);
            setOriginApply();
            ShowDetaiNotify();
            FormEmp_bt_CVPageA.BackColor = Color.Red;
            FormEmp_bt_CVPageB.BackColor = Color.White;
            FormEmp_bt_CVPageC.BackColor = Color.White;
        }

        private void FormEmp_bt_CVPageB_Click(object sender, EventArgs e)
        {
            idFutPageApply = Int32.Parse(FormEmp_bt_CVPageB.Text);
            if (CountApply - beginSTTApply >= 4)
            {
                setOriginApply();
                ShowDetaiNotify();
            }
            else
            {
                setOriginApply();
            }
            FormEmp_bt_CVPageB.BackColor = Color.Red;
            FormEmp_bt_CVPageA.BackColor = Color.White;
            FormEmp_bt_CVPageC.BackColor = Color.White;
        }

        private void FormEmp_bt_CVPageC_Click(object sender, EventArgs e)
        {
            idFutPageApply = Int32.Parse(FormEmp_bt_CVPageC.Text);
            if (CountApply - beginSTTApply >= 4)
            {
                setOriginApply();
                ShowDetaiNotify();
            }
            else
            {
                setOriginApply();
            }
            FormEmp_bt_CVPageC.BackColor = Color.Red;
            FormEmp_bt_CVPageB.BackColor = Color.White;
            FormEmp_bt_CVPageA.BackColor = Color.White;
        }

        private void FormEmp_bt_nextCVPage_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(FormEmp_bt_CVPageA.Text) + 3;
            int b = Int32.Parse(FormEmp_bt_CVPageB.Text) + 3;
            int c = Int32.Parse(FormEmp_bt_CVPageC.Text) + 3;
            FormEmp_bt_CVPageA.Text = a.ToString();
            FormEmp_bt_CVPageB.Text = b.ToString();
            FormEmp_bt_CVPageC.Text = c.ToString();
        }

    }
}
