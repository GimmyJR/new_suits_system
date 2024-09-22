using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_suits_system.PL
{
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN log=new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(textuser_name.Text, textpwd.Text);
            if(dt.Rows.Count > 0 )
            {
                FRM_MAIN.getMainForm.اضافةمنتججديدToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.التقريراليوميToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.التقريراليوميToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.تسجيلالخروجToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.حجزايجارToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.المحجوزاتToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.بيعToolStripMenuItem.Enabled= true;
                FRM_MAIN.getMainForm.دفعباقيToolStripMenuItem.Enabled=true;
                Program.SalesMan = dt.Rows[0]["username"].ToString();
                MessageBox.Show(" تم تسجيل الدخول");
                this.Close();
            }
            else
            {
                MessageBox.Show("فشل التسجيل");
                textuser_name.Clear();
                textpwd.Clear();
                textuser_name.Focus();
            }
            
        }

        private void textuser_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textpwd.Focus();
            }
        }

        private void textpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin.Focus();
            }
        }

        private void textuser_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
