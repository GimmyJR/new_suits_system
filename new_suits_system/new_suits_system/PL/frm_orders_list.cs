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
    public partial class frm_orders_list : Form
    {
        BL.CLS_RENT rent = new BL.CLS_RENT();
        public frm_orders_list()
        {
            InitializeComponent();
            this.dvg_orders.DataSource = rent.search_orders("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dvg_orders.DataSource = rent.search_orders(txt_search.Text);
            }
            catch 
            {
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dvg_orders.CurrentRow.Cells[0].Value);
            //int order_id = Convert.ToInt32(rent.GET_LAST_OREDER_ID_FOR_PRINT().Rows[0][0]);
            RPT.CrystalReport1 report = new RPT.CrystalReport1();
            RPT.FRM_RPT frm = new RPT.FRM_RPT();
            report.SetDataSource(rent.get_fatora_details(order_id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
