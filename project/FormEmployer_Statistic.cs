using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace project
{
    public partial class FormEmployer_Statistic : Form
    {
        private FormEmployer FormEmployer = null;
        public FormEmployer_Statistic(Form callingForm)
        {
            FormEmployer = callingForm as FormEmployer;
            InitializeComponent();
            FormEmp_dt_StartDay.Value.ToString("dd/MM/yyyy");
            FormEmp_dt_EndDay.Value.ToString("dd/MM/yyyy");
        }

        DataTable CountViewRequest = new DataTable();
        DataTable CountCVRequest = new DataTable();
        Dictionary<string, int> DicCountOfDay = new Dictionary<string, int>();
        Dictionary<string, int> DicCountCVOfDay = new Dictionary<string, int>();

        public DataTable setCountViewRequest
        {
            set
            {
                CountViewRequest = value;
            }
        }
        private void FormEmp_bt_Result_Click(object sender, EventArgs e)
        {
            int StartDay = Int32.Parse(FormEmp_dt_StartDay.Value.ToString("dd"));
            int StartMonth = Int32.Parse(FormEmp_dt_StartDay.Value.ToString("MM"));
            int StartYear = Int32.Parse(FormEmp_dt_StartDay.Value.ToString("yyyy"));

            int EndDay = Int32.Parse(FormEmp_dt_EndDay.Value.ToString("dd"));
            int EndMonth = Int32.Parse(FormEmp_dt_EndDay.Value.ToString("MM"));
            int EndYear = Int32.Parse(FormEmp_dt_EndDay.Value.ToString("yyyy"));

            CountViewRequest = FormEmployer.CountViewJobs(StartDay, StartMonth, StartYear, EndDay, EndMonth, EndYear, true);
            CountCVRequest = FormEmployer.CountApplyCV(StartDay, StartMonth, StartYear, EndDay, EndMonth, EndYear, true);
            Load_GridView_Viewer();
            DrawChar();
        }
        public void Load_GridView_Viewer()
        {
            if (FormEmp_cbox_ChooseStatistic.SelectedIndex == 0)
            {
                List<GridView_Viewer> dataViewer = new List<GridView_Viewer>();
                for (int i = 0; i < CountViewRequest.Rows.Count; i++)
                {
                    string title = CountViewRequest.Rows[i][1].ToString();
                    string time = CountViewRequest.Rows[i][2].ToString();
                    dataViewer.Add(new GridView_Viewer() { Title = title, ApplyTime = time });
                }
                dtGv_showResult.DataSource = dataViewer;

                dtGv_showResult.Columns[0].Width = 150;
                dtGv_showResult.Columns[1].Width = 180;
                dtGv_showResult.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                for (int i = 0; i < dtGv_showResult.Rows.Count; i++)
                {
                    dtGv_showResult.Rows[i].Height = 30;
                }
            }
            else
            {
                List<GridView_Apply> dataApply = new List<GridView_Apply>();
                for (int i = 0; i < CountCVRequest.Rows.Count; i++)
                {
                    string title = CountCVRequest.Rows[i][1].ToString();
                    string time = CountCVRequest.Rows[i][5].ToString();
                    string name = CountCVRequest.Rows[i][1].ToString();
                    string mail = CountCVRequest.Rows[i][2].ToString();
                    string cvfile = CountCVRequest.Rows[i][6].ToString();

                    dataApply.Add(new GridView_Apply() { Title = title, ApplyTime = time, candidate_name = name, candidate_mail = mail, CV_file = cvfile  });
                }
                dtGv_showResult.DataSource = dataApply;

                dtGv_showResult.Columns[0].Width = 100;
                dtGv_showResult.Columns[1].Width = 100;
                dtGv_showResult.Columns[2].Width = 100;
                dtGv_showResult.Columns[3].Width = 100;
                dtGv_showResult.Columns[4].Width = 100;
                dtGv_showResult.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                for (int i = 0; i < dtGv_showResult.Rows.Count; i++)
                {
                    dtGv_showResult.Rows[i].Height = 30;
                }
            }
            
        }

        public void DrawChar()
        {
            foreach (var series in FormEmp_Char.Series)
            {
                 series.Points.Clear();
            }

            DicCountOfDay = FormEmployer.getDicCountOfDay;
            DicCountCVOfDay = FormEmployer.getDicCountCVOfDay;
            foreach (KeyValuePair<string, int> entry in DicCountOfDay)
            {
                FormEmp_Char.Series["Lượt xem"].Points.AddXY(entry.Key, entry.Value.ToString());
            }
            foreach (KeyValuePair<string, int> entry in DicCountCVOfDay)
            {
                FormEmp_Char.Series["Lượt ứng tuyển"].Points.AddXY(entry.Key, entry.Value.ToString());
            }
            FormEmployer.clearDicCountOfDay();
            
        }

    }
}
