using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace new_suits_system.PL
{
    public partial class FRM_SELL : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;");
        BL.CLS_SELL sell = new BL.CLS_SELL();
        DataTable dt = new DataTable();
        void create_data_table()
        {
            dt.Columns.Add("كود المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("سعر المنتج");
            dt.Columns.Add("الكمية");
            dt.Columns.Add("الاجمالي ");
            dataGridView1.DataSource = dt;
        }
        void clearboxes()
        {
            txtidproduct.Clear();
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            txtqnt.Clear();
            txttotal.Clear();
            

        }
        public FRM_SELL()
        {
            InitializeComponent();
            create_data_table();
            cashier_name.Text = Program.SalesMan;
            order_date.Enabled = false;
            
        
        }

        private void FRM_SELL_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void txtnameproduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txt_recite_id.Text = sell.get_last().Rows[0][0].ToString();
            btn_add.Enabled = true;
            txtidproduct.Focus();
            txttotalsum.Clear();
            txtidproduct.Clear();
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            txtqnt.Clear();
            txttotal.Clear();
            dt.Clear();
            btn_add.Enabled = true;
            button2.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtidproduct.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnameproduct.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtpriceproduct.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtqnt.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttotal.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            }
            catch
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
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

                //SqlCommand ccmd = new SqlCommand($"Insert Into fatora values('" + int.Parse(txt_recite_id.Text) + "','" + txt_customer_name.Text + "','" + (booking_date.Value) + "' ,'" + (anniversary_date.Value) + "' ,'" + txt_phone.Text + "','" + notes.Text + "','" + cashier_name.Text + "')", con);

                //con.Open();
                //ccmd.ExecuteNonQuery();
                //con.Close();
                using (SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
                {
                    con.Open();


                    int value1 = int.Parse(txt_recite_id.Text);
                    DateTime value2 = order_date.Value;
                    string value3 = cashier_name.Text;



                    string query = "INSERT INTO databarcode_fatora VALUES (@Value1, @Value2, @Value3)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Value1", value1);
                        cmd.Parameters.AddWithValue("@Value2", value2);
                        cmd.Parameters.AddWithValue("@Value3", value3);
                        cmd.ExecuteNonQuery();
                    }
                    //MessageBox.Show("تم حفظ عملية البيع ");


                }
                //add order detailes
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
                    {
                        con.Open();


                        int value1 = int.Parse(txt_recite_id.Text);
                        int value2 = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        string value3 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        int value4 = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        int value5 = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        int value6 = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        int value7 =int.Parse(txttotalsum.Text);




                        // Using a parameterized query to handle the date value
                        string query = "INSERT INTO databarcode_fatora_details VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Value1", value1);
                            cmd.Parameters.AddWithValue("@Value2", value2);
                            cmd.Parameters.AddWithValue("@Value3", value3);
                            cmd.Parameters.AddWithValue("@Value4", value4);
                            cmd.Parameters.AddWithValue("@Value5", value5);
                            cmd.Parameters.AddWithValue("@Value6", value6);
                            cmd.Parameters.AddWithValue("@Value7", value7);
                            cmd.ExecuteNonQuery();
                        }
                        int IdToUpdate = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        int qty = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        string updateQuery = $"UPDATE databarcode SET product_quantity = product_quantity-@qty WHERE product_barcode_id = @IdToUpdate";

                        using (SqlCommand command = new SqlCommand(updateQuery, con))
                        {
                            command.Parameters.AddWithValue("@IdToUpdate", IdToUpdate);
                            command.Parameters.AddWithValue("@qty", qty);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Successfully updated {rowsAffected} rows.");
                            }
                            else
                            {
                                Console.WriteLine("No rows were updated.");
                            }
                        }


                    }
                }
                MessageBox.Show("تم حفظ عملية البيع ");
                button2.Enabled = true;
                btn_add.Enabled = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(sell.get_last_for_print().Rows[0][0]);
            RPT.sell_fatora report = new RPT.sell_fatora();
            RPT.FRM_RPT frm = new RPT.FRM_RPT();
            report.SetDataSource(sell.get_bar_fatora(order_id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void txtidproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                using (SqlConnection connection = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
                {
                    connection.Open();

                    // SQL query to retrieve product name based on barcode ID
                    string sqlQuery = "SELECT product_name FROM databarcode WHERE product_barcode_id = @BarcodeID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Add parameter for barcode ID
                        command.Parameters.AddWithValue("@BarcodeID", txtidproduct.Text);

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if a result is found
                        if (result != null)
                        {
                            // Display the product name in the txtNameProduct TextBox
                            txtnameproduct.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("الباركود غير صحيح");
                            txtidproduct.Focus();
                            return;
                        }
                    }
                }
                using (SqlConnection connection = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
                {
                    connection.Open();

                    // SQL query to retrieve product name based on barcode ID
                    string sqlQuery = "SELECT product_price FROM databarcode WHERE product_barcode_id = @BarcodeID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Add parameter for barcode ID
                        command.Parameters.AddWithValue("@BarcodeID", txtidproduct.Text);

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if a result is found
                        if (result != null)
                        {
                            // Display the product name in the txtNameProduct TextBox
                            txtpriceproduct.Text = result.ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Product not found for the given barcode ID.");
                        }
                    }
                }
                txtqnt.Focus();
            }
        }

        private void txtqnt_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtqnt.Text))
            txttotal.Text= (int.Parse(txtqnt.Text)*int.Parse(txtpriceproduct.Text)).ToString();
        }

        private void txtqnt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (sell.verify_qty(Convert.ToInt32(txtidproduct.Text), Convert.ToInt32(txtqnt.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكمية المدخلة لهذا المنتج غير متاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtidproduct.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                }
                DataRow r = dt.NewRow();
                r[0] = txtidproduct.Text;
                r[1] = txtnameproduct.Text;
                r[2] = txtpriceproduct.Text; 
                r[3] = txtqnt.Text;
                r[4] = txttotal.Text;
                dt.Rows.Add(r);
                dataGridView1.DataSource = dt;
                clearboxes();
                txtidproduct.Focus();
                txttotalsum.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[4].FormattedValue.ToString()!=string.Empty
                                    select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                
            }
        }

        private void txtqnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void txttotalsum_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                txtidproduct.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnameproduct.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                txttotalsum.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[4].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();

            }
            catch
            {
                return;
            }
        }

        private void تعديلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1_DoubleClick(sender, e);
            txttotalsum.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[4].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
        }

        private void حذفالسطرالمحددToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            txttotalsum.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[4].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
        }

        private void حذفالكلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Refresh();
            txttotalsum.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[4].FormattedValue.ToString()!=string.Empty
                                    select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
        }

        private void FRM_SELL_Load(object sender, EventArgs e)
        {

        }

        private void order_date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
