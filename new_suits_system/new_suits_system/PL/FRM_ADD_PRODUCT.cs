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
    public partial class FRM_ADD_PRODUCT : Form
    {
        BL.CLS_PRODUCT prd= new BL.CLS_PRODUCT();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prd.ADD_PRODUCT(text_product_name.Text,textcode.Text);
            MessageBox.Show("تمت الاضافة بنجاح", "عملية الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            text_product_name.Clear();
            textcode.Clear();
            text_product_name.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textcode_Validated(object sender, EventArgs e)
        {
            DataTable dt= new DataTable();
            dt=prd.VerifyProductID(textcode.Text);
            if(dt.Rows.Count > 0) 
            {
                MessageBox.Show("هذا المنتج مضاف مسبقا", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textcode.Focus();
                textcode.SelectionStart = 0;
                textcode.SelectionLength = textcode.TextLength;
            }
        }

        private void text_product_name_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textcode.Focus();
            }
        }

        private void textcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.Focus();
            }
            
        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }
    }
}
