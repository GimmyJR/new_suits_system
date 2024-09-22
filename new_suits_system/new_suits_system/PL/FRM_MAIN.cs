using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_suits_system.PL
{
    public partial class FRM_MAIN : Form
    {
        public static FRM_MAIN frm;
        static void frm_Formclosed(object sender, EventArgs e)
        {
            frm = null;
        }
        public static FRM_MAIN getMainForm
        {
            get
            {
                if(frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_Formclosed);
                }
                return frm;

            }
        }
        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.اضافةمنتججديدToolStripMenuItem.Enabled = false;
            this.التقريراليوميToolStripMenuItem.Enabled = false;
            this.التقريراليوميToolStripMenuItem.Enabled = false;
            this.تسجيلالخروجToolStripMenuItem.Enabled = false;
            this.حجزايجارToolStripMenuItem.Enabled = false;
            this.المحجوزاتToolStripMenuItem.Enabled = false;
            this.بيعToolStripMenuItem.Enabled = false;
            this.دفعباقيToolStripMenuItem.Enabled = false;

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            frm.ShowDialog();
        }

        private void اضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT fRM = new FRM_ADD_PRODUCT();
            fRM.ShowDialog();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.اضافةمنتججديدToolStripMenuItem.Enabled = false;
            this.التقريراليوميToolStripMenuItem.Enabled = false;
            this.التقريراليوميToolStripMenuItem.Enabled = false;
            this.تسجيلالخروجToolStripMenuItem.Enabled = false;
            this.حجزايجارToolStripMenuItem.Enabled = false;
            this.المحجوزاتToolStripMenuItem.Enabled = false;
            this.بيعToolStripMenuItem.Enabled=false;
            this.دفعباقيToolStripMenuItem.Enabled = false;
            MessageBox.Show("تم تسجيل الخروج");
        }

        private void بيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void حجزايجارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_rent fRM = new FRM_rent();
            fRM.ShowDialog();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void المحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_orders_list frm = new frm_orders_list();
            frm.ShowDialog();
        }

        private void دفعباقيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_REM frm = new FRM_REM();
            frm.ShowDialog();
        }
    }
}
