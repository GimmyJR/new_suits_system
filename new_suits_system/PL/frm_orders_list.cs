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

       

        private void frm_orders_list_Load(object sender, EventArgs e)
        {

        }

        private void dvg_orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int order_id = Convert.ToInt32(dvg_orders.CurrentRow.Cells[0].Value);
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
            {
                connection.Open();

                // SQL query to retrieve product name based on barcode ID
                string sqlQuery = "select notes from fatora where @fatora_id=fatora_id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    
                    command.Parameters.AddWithValue("@fatora_id", order_id);

                    
                    object result = command.ExecuteScalar();

                    
                    if (result != null)
                    {
                        // Display the product name in the txtNameProduct TextBox
                        textBox1.Text = result.ToString();
                    }
                    
                    
                }
            }
            
           
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                this.dvg_orders.DataSource = rent.search_date(dateTimePicker1.Value);
            }
            catch
            {
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                this.dvg_orders.DataSource = rent.search_id(int.Parse(textBox3.Text));
            }
            catch
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int order_id = Convert.ToInt32(dvg_orders.CurrentRow.Cells[0].Value);

            using (SqlConnection connection = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
            {
                connection.Open();

                // SQL query to retrieve all product IDs based on the order ID
                //string sqlQuery = "SELECT product_id FROM fatora_details WHERE fatora_id = @fatora_id";
                string sqlQuery = "SELECT all_details FROM product  inner join fatora_details  on  fatora_details.product_id=product.product_id and fatora_id = @fatora_id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@fatora_id", order_id);

                    // Use SqlDataReader to iterate through multiple results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in textBox2
                        textBox2.Clear();

                        // Iterate through the results and append each product ID to textBox2
                        while (reader.Read())
                        {
                            textBox2.AppendText(reader["all_details"].ToString() + Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}
