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
    public partial class tdy_rpt : Form
    {
        BL.rprt rprt = new BL.rprt();
        public tdy_rpt()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = rprt.dty_rpt(DateTime.Now);
            rent.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[1].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
            this.dataGridView2.DataSource = rprt.t_r(DateTime.Now);
            rem.Text = (from DataGridViewRow row in dataGridView2.Rows
                         where row.Cells[1].FormattedValue.ToString() != string.Empty
                         select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
            this.dataGridView3.DataSource = rprt.td_rp(DateTime.Now);
            sell.Text = (from DataGridViewRow row in dataGridView3.Rows
                        where row.Cells[1].FormattedValue.ToString() != string.Empty
                        select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
            this.dataGridView4.DataSource = rprt.gt_gt(DateTime.Now);
            textBox2.Text = (from DataGridViewRow row in dataGridView4.Rows
                         where row.Cells[0].FormattedValue.ToString() != string.Empty
                         select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
            //rem.Text = (from DataGridViewRow row in dataGridView1.Rows
            //             where row.Cells[3].FormattedValue.ToString() != string.Empty
            //             select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            //sell.Text = (from DataGridViewRow row in dataGridView1.Rows
            //             where row.Cells[5].FormattedValue.ToString() != string.Empty
            //             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            ttl_mny.Text = (int.Parse(rent.Text) + int.Parse(rem.Text) + int.Parse(sell.Text)).ToString();
            textBox1.Text=(int.Parse(ttl_mny.Text)-int.Parse(textBox2.Text)).ToString();
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ttl_mny_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.\;Initial Catalog=new_suits_system;Integrated Security=True;"))
            {
                con.Open();


                int value1 = int.Parse(textBox3.Text);
                DateTime value2 = DateTime.Now;
               



                string query = "INSERT INTO masarief VALUES (@Value1, @Value2)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Value1", value1);
                    cmd.Parameters.AddWithValue("@Value2", value2);
                    
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("تمت الاضافة ");


            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
