using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace MedicalEducation
{
    public partial class DefaultForm : BaseWinForm
    {
        public DefaultForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ClsGeneral lgeneral = new ClsGeneral();
            DataTable ldt = lgeneral.GetAllApplications();

            if (ldt.Rows.Count > 0)
            {
                grdApplication.DataSource = ldt;
            }
            else
            {
                
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            MainForm lmf = new MainForm(false);
            
            lmf.MdiParent = this.MdiParent;
            lmf.Show();
        }
    }
}
