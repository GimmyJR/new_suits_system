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
    public partial class block : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-T4PK5IN;Database=new_suits_system;Integrated Security=true");
        
        BL.block blc= new BL.block();
        public block()
        {
            InitializeComponent();
            this.dvg_block.DataSource = blc.blocking();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
