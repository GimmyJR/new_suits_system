using CrystalDecisions.CrystalReports.Engine;
using new_suits_system.RPT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_suits_system.PL
{
    public partial class FRM_GENRATE_BARCODE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;");
        BL.CLS_RENT rent = new BL.CLS_RENT();
        DataTable dt = new DataTable();
        CrystalReport1 cry = new CrystalReport1();
        public FRM_GENRATE_BARCODE()
        {
            InitializeComponent();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dt.Clear();
            for (int i = 0; i < Convert.ToInt32(txt_times.Text); i++)
            {
                dt.Rows.Add(txt_barcode.Text, txt_name.Text, txt_price.Text);
            }
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }

        private void FRM_GENRATE_BARCODE_Load(object sender, EventArgs e)
        {
            dt.TableName = "databarcode";
            dt.Columns.Add("barid", Type.GetType("system.string"));
            dt.Columns.Add("barname", Type.GetType("system.string"));
            dt.Columns.Add("barprice", Type.GetType("system.string"));
        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            Focus();
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_name.Focus();
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_price.Focus();
            }
        }

        private void txt_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_times.Focus();
            }
        }

        private void txt_times_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_print.Focus();
            }
        }
    }
}
