using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace new_suits_system.BL
{
    internal class block
    {
        public DataTable blocking()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_All_Products", null);
            DAL.Close();
            return dt;
        }
    }
}
