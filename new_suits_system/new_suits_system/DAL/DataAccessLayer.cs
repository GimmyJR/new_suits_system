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
namespace new_suits_system.DAL
{
    internal class DataAccessLayer
    {
        SqlConnection SqlConnection;
        public DataAccessLayer()
        {
            SqlConnection = new SqlConnection("Server=DESKTOP-T4PK5IN;Database=new_suits_system;Integrated Security=true");
        }
        public void Open()
        {
            if(SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }
        public void Close() 
        {
               if(SqlConnection.State != ConnectionState.Closed) 
            {
                SqlConnection.Close(); 
            } 
        }   
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = SqlConnection;

            if(param != null ) 
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da= new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void ExecuteCommand(string stored_procedure,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
               
                    sqlcmd.Parameters.AddRange(param);
                
            }
            sqlcmd.ExecuteNonQuery();


        }
    }
}
