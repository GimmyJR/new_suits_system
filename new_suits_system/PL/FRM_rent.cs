using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace new_suits_system.PL
{
    public partial class FRM_rent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;");
        BL.CLS_RENT rent = new BL.CLS_RENT();
        DataTable dt = new DataTable();
        void create_data_table()
        {
            dt.Columns.Add("كود المنتج");
            dt.Columns.Add("اسم المنتج");
            
            dataGridView1.DataSource = dt;
            booking_date.Enabled = false;
        }
        void clearboxes()
        {
            txtidproduct.Clear();
            txtnameproduct.Clear();
            
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
      
            //if(txt_customer_name.Text!=null&&txttotalsum.Text!=null&&txt_first_payment.Text!=null&&txt_second_payment!=null)
            //btn_add.Enabled = true;
            //else
            //{
            //    MessageBox.Show("تأكد من كتابة كل تفاصيل الفاتورة");
            //btn_add.Enabled = false;
            //    return;
            //}
            //clearboxes();
            //txt_customer_name.Clear();
            //txt_phone.Clear();
            //notes.Clear();
            //txttotalsum.Clear();
            //txt_first_payment.Clear();
            //txt_second_payment.Clear();
            //dt.Clear();
            dataGridView1.Refresh();
            txt_customer_name.Focus();
            button6.Enabled = true;
            button2.Enabled = false;


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtidproduct.Clear();
            txtnameproduct.Clear();
            
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtidproduct.Text = frm.dgv_products_list.CurrentRow.Cells[0].Value.ToString();
            txtnameproduct.Text = frm.dgv_products_list.CurrentRow.Cells[1].Value.ToString();
           
        }

        

        private void txtidproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
                {
                    connection.Open();

                    // SQL query to retrieve product name based on barcode ID
                    string sqlQuery = "SELECT all_details FROM product WHERE product_id = @BarcodeID";

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
                            txtidproduct.Focus  ();
                            MessageBox.Show("الباركود غير صحيح");
                            txtidproduct.Focus();
                            return;
                        }
                    }
                }
                button4.Focus();
            }
        }

        private void txtnameproduct_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            txtidproduct.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnameproduct.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            
            }
            catch 
            {
                return;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
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

                //SqlCommand ccmd = new SqlCommand($"Insert Into fatora values('" + int.Parse(txt_recite_id.Text) + "','" + txt_customer_name.Text + "','" + (booking_date.Value) + "' ,'" + (anniversary_date.Value) + "' ,'" + txt_phone.Text + "','" + notes.Text + "','" + cashier_name.Text + "')", con);

                //con.Open();
                //ccmd.ExecuteNonQuery();
                //con.Close();
                using (SqlConnection con = new SqlConnection("Data Source=./;Initial Catalog=new_suits_system;Integrated Security=True;"))
                {
                    con.Open();


                    int value1 = int.Parse(txt_recite_id.Text);
                    string value2 = txt_customer_name.Text;
                    DateTime value3 = booking_date.Value;
                    DateTime value4 = anniversary_date.Value;
                    DateTime value8 = txt_back.Value;
                    string value5 = txt_phone.Text;
                    string value6 = notes.Text;
                    string value7 = cashier_name.Text;



                    string query = "INSERT INTO fatora VALUES (@Value1, @Value2, @Value3, @Value4, @Value8, @Value5, @Value6, @Value7)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Value1", value1);
                        cmd.Parameters.AddWithValue("@Value2", value2);
                        cmd.Parameters.AddWithValue("@Value3", value3);
                        cmd.Parameters.AddWithValue("@Value4", value4);
                        cmd.Parameters.AddWithValue("@Value8", value8);
                        cmd.Parameters.AddWithValue("@Value5", value5);
                        cmd.Parameters.AddWithValue("@Value6", value6);
                        cmd.Parameters.AddWithValue("@Value7", value7);
                        cmd.ExecuteNonQuery();
                    }
                    //MessageBox.Show("تم حفظ عملية البيع ");


                }
                //add order detailes
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    //SqlCommand cmd = new SqlCommand($"Insert Into fatora_details values('" + int.Parse(txt_recite_id.Text) + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + (anniversary_date.Value) + "','" + (txt_back.Value) + "','" + int.Parse(txttotalsum.Text) + "','" + int.Parse(txttotalsum.Text) + "','" + int.Parse(txt_first_payment.Text) + "','" + int.Parse(txt_second_payment.Text) + "')", con);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    using (SqlConnection con = new SqlConnection("Data Source=./;Initial Catalog=new_suits_system;Integrated Security=True;"))
                    {
                        con.Open();


                        int value1 = int.Parse(txt_recite_id.Text);
                        string value2 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        DateTime value3 = (anniversary_date.Value);
                        DateTime value8 = (txt_back.Value);
                        int value4 = int.Parse(txttotalsum.Text); ;
                        int value5 = int.Parse(txttotalsum.Text);
                        int value6 = int.Parse(txt_first_payment.Text);
                        int value7 = int.Parse(txt_second_payment.Text);



                        // Using a parameterized query to handle the date value
                        string query = "INSERT INTO fatora_details VALUES (@Value1, @Value2, @Value3, @Value8, @Value4, @Value5, @Value6, @Value7)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Value1", value1);
                            cmd.Parameters.AddWithValue("@Value2", value2);
                            cmd.Parameters.AddWithValue("@Value3", value3);
                            cmd.Parameters.AddWithValue("@Value8", value8);
                            cmd.Parameters.AddWithValue("@Value4", value4);
                            cmd.Parameters.AddWithValue("@Value5", value5);
                            cmd.Parameters.AddWithValue("@Value6", value6);
                            cmd.Parameters.AddWithValue("@Value7", value7);
                            cmd.ExecuteNonQuery();
                        }


                    }
                }
                MessageBox.Show("تم حفظ عملية البيع ");
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("يجب التأكد من بيانات الفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_add.Enabled = false;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;";
            string pro_id=txtidproduct.Text;
            DateTime anndate = anniversary_date.Value;
            bool IsAnniversaryInRange(string productId, DateTime anniversaryDate)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming your table name is "Products" and the columns are named as specified
                    string query = "SELECT COUNT(*) FROM fatora_details " +
                                   "WHERE product_id = @productId AND @anniversary_date >= ann_date AND @anniversary_date <= back_date";
                                   

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        command.Parameters.AddWithValue("@anniversary_date", anniversaryDate);
                        // ExecuteScalar returns the first column of the first row
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // If count is greater than zero, the anniversary date is within the range
                        return count > 0;
                    }
                }
            }
            if (IsAnniversaryInRange(pro_id, anndate))
            {
                // Perform your add operation here
                MessageBox.Show("المنتج محجوز في هذا التاريخ");
                txtidproduct.Focus();
                return;
                // Add your code to add the product to the database or perform other actions.
            }
            DateTime back = txt_back.Value;
            if (IsAnniversaryInRange(pro_id, back))
            {
                // Perform your add operation here
                MessageBox.Show("المنتج محجوز في هذا التاريخ");
                txtidproduct.Focus();
                return;
                // Add your code to add the product to the database or perform other actions.
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
            dt.Rows.Add(r);
            dataGridView1.DataSource = dt;
            clearboxes();
            txtidproduct.Focus();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_customer_name.Text == "" || txttotalsum.Text == "" || txt_first_payment.Text == "" || txt_second_payment.Text == "")
            {
                MessageBox.Show("تأكد من كتابة كل تفاصيل الفاتورة");
                btn_add.Enabled = false;
                return;
            }
            else
                btn_add.Enabled = true;
            button6.Enabled = false;
        }

        private void txt_customer_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_phone.Focus();
            }
        }
        private void txt_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                anniversary_date.Focus();
            }
        }
        private void txt_anniversary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_back.Focus();
            }
        }

        private void txt_back_KeyDown(object sender, KeyEventArgs e)
        {
            
              if (e.KeyCode == Keys.Enter)
              {
                 notes.Focus();
              }
            
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string connectionString = @"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;";
                string pro_id = txtidproduct.Text;
                DateTime anndate = anniversary_date.Value;
                bool IsAnniversaryInRange(string productId, DateTime anniversaryDate)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Assuming your table name is "Products" and the columns are named as specified
                        string query = "SELECT COUNT(*) FROM fatora_details " +
                                       "WHERE product_id = @productId AND @anniversary_date >= ann_date AND @anniversary_date <= back_date";


                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@productId", productId);
                            command.Parameters.AddWithValue("@anniversary_date", anniversaryDate);
                            // ExecuteScalar returns the first column of the first row
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            // If count is greater than zero, the anniversary date is within the range
                            return count > 0;
                        }
                    }
                }
                if (IsAnniversaryInRange(pro_id, anndate))
                {
                    // Perform your add operation here
                    MessageBox.Show("المنتج محجوز في هذا التاريخ");
                    txtidproduct.Focus();
                    return;
                    // Add your code to add the product to the database or perform other actions.
                }
                DateTime back=txt_back.Value;
                if (IsAnniversaryInRange(pro_id, back))
                {
                    // Perform your add operation here
                    MessageBox.Show("المنتج محجوز في هذا التاريخ");
                    txtidproduct.Focus();
                    return;
                    // Add your code to add the product to the database or perform other actions.
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
                dt.Rows.Add(r);
                dataGridView1.DataSource = dt;
                clearboxes();
                txtidproduct.Focus();
            }
        }

        private void notes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtidproduct.Focus();
            }
        }

        private void txttotalsum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            txt_first_payment.Focus();
        }

        private void txt_first_payment_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txt_second_payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_customer_name.Text == "" || txttotalsum.Text == "" || txt_first_payment.Text == "" || txt_second_payment.Text == "")
                {
                    MessageBox.Show("تأكد من كتابة كل تفاصيل الفاتورة");
                    btn_add.Enabled = false;
                    return;
                }
                else
                    btn_add.Enabled = true;
            }
            button6.Enabled = false;
        }

        private void txt_first_payment_TextChanged(object sender, EventArgs e)
        {
            int a = txttotalsum.Text != "" ? Convert.ToInt32(txttotalsum.Text) : 0;
            int b = txt_first_payment.Text != "" ? Convert.ToInt32(txt_first_payment.Text) : 0;
            txt_second_payment.Text = (a - b).ToString();
        }

        private void txtnameproduct_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
