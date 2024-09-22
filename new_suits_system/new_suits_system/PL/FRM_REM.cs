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
    public partial class FRM_REM : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-T4PK5IN;Database=new_suits_system;Integrated Security=true");
        public FRM_REM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select total_money,first_payment,last_payment from fatora_details where fatora_id='" + int.Parse(textBox1.Text) + "' ", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    textBox4.Text = dr.GetValue(2).ToString();
                    this.button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("يجب التأكد من رقم الفاتورة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                con.Close();
                
            }
            catch 
            {
                MessageBox.Show("يجب إدخال رقم الفاتورة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

                // add  process detailes

                SqlCommand ccmd = new SqlCommand($"Insert Into rem values('" + int.Parse(textBox1.Text) + "','" + textBox4.Text + "','" + DateTime.Now.Date + "')", con);
                con.Open();
                ccmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم حفظ العملية ");

            string connectionString = "Data Source=DESKTOP-T4PK5IN;Initial Catalog=new_suits_system;Integrated Security=True;";

            // Replace with your actual values
            int remIdToUpdate = int.Parse(textBox1.Text);
            string newRemValue = textBox4.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = $"UPDATE fatora_details SET first_payment = total_money,last_payment=0 WHERE fatora_id = @remIdToUpdate";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@newRemValue", newRemValue);
                    command.Parameters.AddWithValue("@remIdToUpdate", remIdToUpdate);

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
    }
}
