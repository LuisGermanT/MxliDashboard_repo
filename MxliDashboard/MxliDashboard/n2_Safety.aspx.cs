using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class Safety : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            llenarDatos_S01(0);
            llenarDatos_S02(0);
            llenarDatos_S03(0);
            loadChartS01(0, "All");
            loadChartS02(0, "All");
        }

        public void llenarDatos_S01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'incidentes' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelS01.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgS01.ImageUrl = "~/img/" + imagen + ".png";

            S01Actual.Text = (actual).ToString();
            S01AOP.Text = (aop).ToString();
        }
        public void llenarDatos_S02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'mst' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelS02.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgS02.ImageUrl = "~/img/" + imagen + ".png";

            S02Actual.Text = (actual).ToString();
            S02AOP.Text = (aop).ToString();
        }
        public void llenarDatos_S03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }   //usar '>' cuando es 'B'
            imgS03.ImageUrl = "~/img/" + imagen + ".png";

            S03Actual.Text = actual + "";
            S03AOP.Text = aop + "";

            loadChartS03(indice);
        }

        private void loadChartS01(int tipo, string clase)
        {
            chartTS01.Series["Series1"].Points.Clear();
            chartTS01.Series["Series2"].Points.Clear();
            chartTS01.Series["Series3"].Points.Clear();
            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";

            if (tipo == 1)
            {
                xClass = clase;
                xFilter = "AREA";
            }
            if (tipo == 2)
            {
                xClass = clase;
                xFilter = "MRP";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'incidentes' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTS01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTS01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTS01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'ppms' and stype = 'causes' order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //foreach (DataRow dr2 in dt2.Rows)
            //{
            //    double xActual = Convert.ToDouble(dr2["factual"].ToString());
            //    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
            //    chartPQ01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
            //    chartPQ01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            //}
        }

        private void loadChartS02(int tipo, string clase)
        {
            chartTS02.Series["Series1"].Points.Clear();
            chartTS02.Series["Series2"].Points.Clear();
            chartTS02.Series["Series3"].Points.Clear();
            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";
            if (tipo == 1)
            {
                xClass = clase;
                xFilter = "VSM";
            }
            if (tipo == 2)
            {
                xClass = clase;
                xFilter = "MRP";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'MST' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTS02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTS02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTS02.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'escapes' and stype = 'causes' order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //foreach (DataRow dr2 in dt2.Rows)
            //{
            //    double xActual = Convert.ToDouble(dr2["factual"].ToString());
            //    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
            //    chartPQ02.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
            //    chartPQ02.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            //}
        }

        private void loadChartS03(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTS03.Series["Series1"].Points.Clear();
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTS03.Series["Series2"].Points.Clear();
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTS03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPS03.Series["Series1"].Points.Clear();
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPS03.Series["Series2"].Points.Clear();
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxV.SelectedIndex;
            if (indice == 1)
            {
                S02.Visible = true;
                S01.Visible = false;
                S03.Visible = false;
            }
            else
            {
                S01.Visible = true;
                S02.Visible = true;
                S03.Visible = true;
            }
        }


    }
}