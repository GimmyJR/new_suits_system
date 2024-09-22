using new_suits_system.BL;
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
    public partial class FRM_PRODUCTS_LIST : Form
    {
        BL.CLS_PRODUCT prd = new BL.CLS_PRODUCT();
        public FRM_PRODUCTS_LIST()
        {
            InitializeComponent();
            this.dgv_products_list.DataSource = prd.Get_All_Products();
        }

        private void FRM_PRODUCTS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void dgv_products_list_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_products_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                this.dgv_products_list.DataSource = prd.search_pro_id(textBox1.Text);
            }
            catch
            {
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                this.dgv_products_list.DataSource = prd.search_pro_nme(textBox2.Text);
            }
            catch
            {
                return;
            }
        }
    }
}
