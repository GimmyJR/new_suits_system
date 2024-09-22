using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace new_suits_system.BL
{
    internal class CLS_PRODUCT
    {
        public DataTable Get_All_Products()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_All_Products", null);
            DAL.Close();
            return dt;
        }

        public void ADD_PRODUCT(string name,string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@all_details", SqlDbType.VarChar, 200);
            param[0].Value = name;
            param[1] = new SqlParameter("@product_ID", SqlDbType.VarChar, 50);
            param[1].Value = id;
            DAL.ExecuteCommand("ADD_PRODUCT", param);
            DAL.Close();
        }
        public DataTable VerifyProductID(string id)
        {
            DAL.DataAccessLayer DAL= new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@product_ID", SqlDbType.VarChar, 50);
            param[0].Value=id;
            dt = DAL.SelectData("VerifyProductID", param);
            DAL.Close();
            return dt;
        }
    }
}
