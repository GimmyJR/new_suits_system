using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_suits_system.BL
{
    internal class CLS_SELL
    {
        public DataTable get_bar_fatora(int id_order)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@fatora_id", SqlDbType.Int);
            param[0].Value = id_order;
            dt = DAL.SelectData("get_bar_fatora", param);
            DAL.Close();
            return dt;

        }
        public DataTable get_last()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_last", null);
            DAL.Close();
            return dt;
        }
        public DataTable get_last_for_print()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_last_for_print", null);
            DAL.Close();
            return dt;
        }
        public DataTable verify_qty(int product_barcode_id,int qty_entered)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_barcode_id",SqlDbType.Int);
            param[0].Value= product_barcode_id;
            param[1] = new SqlParameter("@qty_entered", SqlDbType.Int);
            param[1].Value = qty_entered;
            dt = DAL.SelectData("verify_qty",param);
            DAL.Close();
            return dt;
        }
    }
}
