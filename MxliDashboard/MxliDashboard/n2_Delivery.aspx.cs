using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class n2_Delivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarDatos_D01(0);
                llenarDatos_D02(0);
                llenarDatos_D03(0);
                llenarDatos_D04(0);
                llenarDatos_D05(0);
                llenarDatos_D06(0);
                loadChartD01(0);
            }
        }

        public void llenarDatos_D01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgD01.ImageUrl = "~/img/" + imagen + ".png";

            D01Actual.Text = actual + "";
            D01AOP.Text = aop + "";

           //loadChartD01(indice);
        }

        public void llenarDatos_D02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgD02.ImageUrl = "~/img/" + imagen + ".png";

            D02Actual.Text = actual + "";
            D02AOP.Text = aop + "";

            loadChartD02(indice);
        }
        
        public void llenarDatos_D03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgD03.ImageUrl = "~/img/" + imagen + ".png";

            D03Actual.Text = actual + "";
            D03AOP.Text = aop + "";

            loadChartD03(indice);
        }
        
        public void llenarDatos_D04(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgD04.ImageUrl = "~/img/" + imagen + ".png";

            D04Actual.Text = actual + "";
            D04AOP.Text = aop + "";

            loadChartD04(indice);
        }
        
        public void llenarDatos_D05(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgD05.ImageUrl = "~/img/" + imagen + ".png";

            D05Actual.Text = actual + "";
            D05AOP.Text = aop + "";

            loadChartD05(indice);
        }
        
        public void llenarDatos_D06(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgD06.ImageUrl = "~/img/" + imagen + ".png";

            D06Actual.Text = actual + "";
            D06AOP.Text = aop + "";

            loadChartD06(indice);
        }

        private void loadChartD01(int indice)
        {
            chartTD01.Series["Series1"].Points.Clear();
            chartTD01.Series["Series2"].Points.Clear();
            chartTD01.Series["Series3"].Points.Clear();

            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "SELECT * FROM vw_ottr_by_wk WHERE [TO_Wk] BETWEEN " + (semana-12) + " AND " + semana + " ORDER BY [TO_Yr] ASC, [TO_Wk] ASC, [TO_Month] ASC" ;
            DataTable dtPareto = dBHelper.QryManager(qry);
            
            foreach (DataRow dr1 in dtPareto.Rows)
            {
                int xHit = int.Parse(dr1["Hit"].ToString());
                int xMiss = int.Parse(dr1["Miss"].ToString());
                int totOrdrs = int.Parse(dr1["TotalOrdrs"].ToString());
                double xGoal = (xHit / totOrdrs) * 100;

                chartTD01.Series["Series1"].Points.AddXY(dr1["TO_Wk"].ToString(), xHit);
                chartTD01.Series["Series2"].Points.AddXY(dr1["TO_Wk"].ToString(), xMiss);
                chartTD01.Series["Series3"].Points.AddXY(dr1["TO_Wk"].ToString(), xGoal);
            }
        }

        private void loadChartD02(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTD02.Series["Series1"].Points.Clear();
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTD02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTD02.Series["Series2"].Points.Clear();
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTD02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPD02.Series["Series1"].Points.Clear();
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPD02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPD02.Series["Series2"].Points.Clear();
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPD02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartD03(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTD03.Series["Series1"].Points.Clear();
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTD03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTD03.Series["Series2"].Points.Clear();
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTD03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPD03.Series["Series1"].Points.Clear();
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPD03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPD03.Series["Series2"].Points.Clear();
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPD03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartD04(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTD04.Series["Series1"].Points.Clear();
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTD04.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTD04.Series["Series2"].Points.Clear();
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTD04.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPD04.Series["Series1"].Points.Clear();
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPD04.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPD04.Series["Series2"].Points.Clear();
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPD04.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartD05(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTD05.Series["Series1"].Points.Clear();
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTD05.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTD05.Series["Series2"].Points.Clear();
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTD05.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPD05.Series["Series1"].Points.Clear();
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPD05.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPD05.Series["Series2"].Points.Clear();
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPD05.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartD06(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTD06.Series["Series1"].Points.Clear();
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTD06.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTD06.Series["Series2"].Points.Clear();
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTD06.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPD06.Series["Series1"].Points.Clear();
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPD06.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPD06.Series["Series2"].Points.Clear();
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPD06.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

    }
}