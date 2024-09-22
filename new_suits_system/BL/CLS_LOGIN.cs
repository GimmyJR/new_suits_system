using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace new_suits_system.BL
{
    internal class CLS_LOGIN
    {
        public DataTable LOGIN(string user_name, string pwd)
        {
            DAL.DataAccessLayer DAL=new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("id", SqlDbType.VarChar,50);
            param[0].Value = user_name;
            param[1] = new SqlParameter("pwd", SqlDbType.VarChar, 50);
            param[1].Value = pwd;
            DAL.Open();
            DataTable dt= new DataTable();
            dt = DAL.SelectData("sp_login", param);
            return dt;
        }    
    }
}
