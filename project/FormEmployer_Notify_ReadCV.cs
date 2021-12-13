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
    public partial class FormEmployer_Notify_ReadCV : Form
    {
        private FormEmployer_Notify FormEmployer_Notify = null;
        public FormEmployer_Notify_ReadCV(Form callingForm)
        {
            FormEmployer_Notify = callingForm as FormEmployer_Notify;
            InitializeComponent();
        }

        string pathCV = "";
        string nameCV = "";
        public string setpathCV
        {
            set
            {
                pathCV = value;
            }
        }
        public string setnameCV
        {
            set
            {
                nameCV = value;
            }
        }
        public void ReadCV()
        {
            axAcroPDF1.LoadFile(pathCV);
        }

        private void FormEmployer_Notify_ReadCV_Load(object sender, EventArgs e)
        {
            this.Text = nameCV;
            ReadCV();
        }
    }
}
