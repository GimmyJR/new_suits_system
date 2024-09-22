using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
namespace new_suits_system.BL
{
    internal class CLS_RENT
    {
        public DataTable GET_LAST_RECITE_ID()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt= new DataTable();
            dt = DAL.SelectData("GET_LAST_OREDER_ID", null);
            DAL.Close();
            return dt;
        }
        public DataTable GET_LAST_OREDER_ID_FOR_PRINT()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_LAST_OREDER_ID_FOR_PRINT", null);
            DAL.Close();
            return dt;
        }
        public DataTable get_fatora_details(int id_order)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@fatora_id", SqlDbType.Int);
            param[0].Value = id_order;
            dt = DAL.SelectData("get_fatora_details", param);
            DAL.Close();
            return dt;

        }

        public DataTable search_orders(string cri)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cri", SqlDbType.VarChar,50);
            param[0].Value = cri;
            dt = DAL.SelectData("search_orders", param);
            DAL.Close();
            return dt;

        }

        public void add_fatora(int fatora_id, string client_name,DateTime booking_date, DateTime ann_date, string phone, string notes, string salesman)
        {
            DAL.DataAccessLayer DAL =new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@fatora_id", SqlDbType.Int);
            param[0].Value = fatora_id;
            param[1] = new SqlParameter("@client_name", SqlDbType.VarChar,50);
            param[1].Value = client_name;
            param[2] = new SqlParameter("@booking_date", SqlDbType.Date);
            param[2].Value = booking_date;
            param[3] = new SqlParameter("@ann_date", SqlDbType.Date);
            param[3].Value = ann_date;
            param[4] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[4].Value = phone;
            param[5] = new SqlParameter("@notes", SqlDbType.VarChar,2000);
            param[5].Value = notes;
            param[6] = new SqlParameter("@salesman", SqlDbType.VarChar, 75);
            param[6].Value = salesman;
            DAL.ExecuteCommand("add_fatora", null);
            DAL.Close();
                
        }
        public void add_fatora_details(int fatora_id, string product_id,DateTime ann_date,int product_price,int total_money,int first_payment,int last_payment)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@fatora_id", SqlDbType.Int);
            param[0].Value = fatora_id;
            param[1] = new SqlParameter("@product_id", SqlDbType.VarChar, 50);
            param[1].Value = product_id;
            param[2] = new SqlParameter("@ann_date", SqlDbType.Date);
            param[2].Value = ann_date;
            param[3] = new SqlParameter("@product_price", SqlDbType.Int);
            param[3].Value = product_price;
            param[4] = new SqlParameter("@total_money", SqlDbType.Int);
            param[4].Value = total_money;
            param[5] = new SqlParameter("@first_payment", SqlDbType.Int);
            param[5].Value = first_payment;
            param[6] = new SqlParameter("@last_payment", SqlDbType.Int);
            param[6].Value = last_payment;
            DAL.ExecuteCommand("add_fatora_details", null);
            DAL.Close();

        }
    }
}
