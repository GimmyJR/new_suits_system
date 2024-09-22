using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace new_suits_system.PL
{
    public partial class FRM_rent : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-T4PK5IN;Database=new_suits_system;Integrated Security=true");
        BL.CLS_RENT rent = new BL.CLS_RENT();
        DataTable dt = new DataTable();
        void create_data_table()
        {
            dt.Columns.Add("كود المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("السعر");
            dataGridView1.DataSource = dt;
        }
        void clearboxes()
        {
            txtidproduct.Clear();
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            button1.Focus();

        }
        
        public FRM_rent()
        {
            InitializeComponent();
            create_data_table();
            cashier_name.Text = Program.SalesMan;
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.txt_recite_id.Text = rent.GET_LAST_RECITE_ID().Rows[0][0].ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_rent_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txt_recite_id.Text = rent.GET_LAST_RECITE_ID().Rows[0][0].ToString();
            button5.Enabled = false;
            btn_add.Enabled = true;
          
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtidproduct.Clear();
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtidproduct.Text = frm.dgv_products_list.CurrentRow.Cells[0].Value.ToString();
            txtnameproduct.Text = frm.dgv_products_list.CurrentRow.Cells[1].Value.ToString();
            txtpriceproduct.Focus();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
            //        try
            //        {

            //    string connectionString = "Data Source=DESKTOP-T4PK5IN;Initial Catalog=new_suits_system;Integrated Security=True;";
            //        string productId = txtidproduct.Text; // Replace with the actual product ID
            //    DateTime chosenDate = DateTime.Now.Date; // Example chosen date

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {

            //        connection.Open();

            //        string query = @"
            //    SELECT COUNT(*) 
            //    FROM fatora_details
            //    WHERE product_id = @product_id
            //        AND (ann_date = @chosen_date OR ann_date = DATEADD(day, -1, @chosen_date) OR ann_date = DATEADD(day, 1, @chosen_date))
            //";

            //        SqlCommand command = new SqlCommand(query, connection);
            //        command.Parameters.AddWithValue("@product_id", txtidproduct.Text);
            //        command.Parameters.AddWithValue("@chosen_date", anniversary_date.Value);
                  
                    
                    


            //        int bookingCount = (int)command.ExecuteScalar();
            //        if (bookingCount > 0)
            //        {
            //            MessageBox.Show("هذا المنتج محجوز في هذاالتاريخ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            return;
            //        }

            //    }
            //        }
            //        catch 
            //        {
            //        return;
            //        }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtidproduct.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                DataRow r = dt.NewRow();
                r[0]=txtidproduct.Text;
                r[1]=txtnameproduct.Text;
                r[2]=txtpriceproduct.Text;
                dt.Rows.Add(r);
                dataGridView1.DataSource =dt;
                clearboxes();
                txttotalsum.Text =
                (from DataGridViewRow row in dataGridView1.Rows
                 where row.Cells[2].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            }
        }

        private void txtidproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                txtnameproduct.Focus();
            }
        }

        private void txtnameproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpriceproduct.Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            txtidproduct.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnameproduct.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtpriceproduct.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            txtpriceproduct.Focus();
            }
            catch 
            {
                return;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txttotalsum.Text =
                (from DataGridViewRow row in dataGridView1.Rows
                 where row.Cells[2].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_DoubleClick(sender, e);
        }

        private void حذفالسطرالمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Refresh();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                // add  process detailes

                SqlCommand ccmd = new SqlCommand($"Insert Into fatora values('" + int.Parse(txt_recite_id.Text) + "','" + txt_customer_name.Text + "','" + (booking_date.Value) + "' ,'" + (anniversary_date.Value) + "' ,'" + txt_phone.Text + "','" + notes.Text + "','" + cashier_name.Text + "')",con );

                con.Open();
                ccmd.ExecuteNonQuery();
                con.Close();
                //add order detailes
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand($"Insert Into fatora_details values('" + int.Parse(txt_recite_id.Text) + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + (anniversary_date.Value) + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + int.Parse(txttotalsum.Text)+ "','" + int.Parse(txt_first_payment.Text)+ "','" + int.Parse(txt_second_payment.Text) + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("تم حفظ عملية البيع ");
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("يجب التأكد من بيانات الفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //rent.add_fatora(Convert.ToInt32(txt_recite_id.Text),txt_customer_name.Text,booking_date.Value,anniversary_date.Value,txt_phone.Text,notes.Text,cashier_name.Text);
            //for(int i=0;i<dataGridView1.Rows.Count-1;i++)
            // {
            //     rent.add_fatora_details(Convert.ToInt32(txt_recite_id.Text), dataGridView1.Rows[i].Cells[0].Value.ToString());
            // }
            //MessageBox.Show("تمت عملية الحفظ بنجاح","عملية الحفظ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txttotalsum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpriceproduct_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(rent.GET_LAST_OREDER_ID_FOR_PRINT().Rows[0][0]);
            RPT.CrystalReport1 report = new RPT.CrystalReport1();
            RPT.FRM_RPT frm = new RPT.FRM_RPT();
            report.SetDataSource(rent.get_fatora_details(order_id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor=Cursors.Default;
        }

        private void txtpriceproduct_Enter(object sender, EventArgs e)
        {

        }

        private void txtpriceproduct_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            
                string connectionString = "Data Source=DESKTOP-T4PK5IN;Initial Catalog=new_suits_system;Integrated Security=True;";
                string productId = txtidproduct.Text; // Replace with the actual product ID
                DateTime chosenDate = anniversary_date.Value; // Example chosen date

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    string query = @"
                    SELECT COUNT(*) 
                    FROM fatora_details
                    WHERE product_id = @product_idd
                        AND (ann_date = @chosen_datee OR ann_date = DATEADD(day, -1, @chosen_datee) OR ann_date = DATEADD(day, 1, @chosen_datee))
                ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@product_idd", productId);
                    command.Parameters.AddWithValue("@chosen_datee", chosenDate);

                    int bookingCount = (int)command.ExecuteScalar();
                    if (bookingCount > 0)
                    {
                        MessageBox.Show("هذا المنتج محجوز في هذاالتاريخ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        
                    }
                    else
                    {
                        MessageBox.Show("هذا المنتج متاح في هذاالتاريخ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                }
            
            
        }
        }
}
