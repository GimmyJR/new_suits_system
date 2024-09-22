using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_suits_system.BL
{
    internal class rprt
    {
        public DataTable dty_rpt(DateTime tdy_date)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tdy_date", SqlDbType.Date);
            param[0].Value = tdy_date;
            dt = DAL.SelectData("dty_rpt", param);
            DAL.Close();
            return dt;
        }
        public DataTable t_r(DateTime tdy_date)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tdy_date", SqlDbType.Date);
            param[0].Value = tdy_date;
            dt = DAL.SelectData("t_r", param);
            DAL.Close();
            return dt;
        }

        public DataTable gt_gt(DateTime tdy_date)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tdy_date", SqlDbType.Date);
            param[0].Value = tdy_date;
            dt = DAL.SelectData("gt_gt", param);
            DAL.Close();
            return dt;
        }
        public DataTable td_rp(DateTime tdy_date)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tdy_date", SqlDbType.Date);
            param[0].Value = tdy_date;
            dt = DAL.SelectData("td_rp", param);
            DAL.Close();
            return dt;
        }
    }
}
