using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MxliDashboard.SQLHelper
{
    public class DBHelper
    {

        //Productivity n3
        public DataTable ProdN3(string qry)
        {
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand(qry, conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            return dt1;
        }

        //DBProductivity
        public DataTable GetBaseLine(string qry)
        {
            string myCnStr1 = Properties.Settings.Default.DB_Productivity;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand(qry, conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            return dt1;
        }

    }
}