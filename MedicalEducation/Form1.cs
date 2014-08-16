using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalEducation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MainForm lmfrm = new MainForm();
            //lmfrm.MdiParent = this;
            //lmfrm.Show();

            DefaultForm ldefFrm = new DefaultForm();
            ldefFrm.MdiParent = this;
            ldefFrm.Show();

            //Form2 lmfrm1 = new Form2();
            //lmfrm1.MdiParent = this;
            //lmfrm1.Show();
        }
    }
}
