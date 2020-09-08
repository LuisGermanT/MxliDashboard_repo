using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class Productivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarDatos_P01(0);
            llenarDatos_P02(0);
            llenarDatos_P03(0);
            llenarDatos_P04(0);
        }

        public void llenarDatos_P01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgP01.ImageUrl = "~/img/" + imagen + ".png";

            P01Actual.Text = actual + "";
            P01AOP.Text = aop + "";

            loadChartP01(indice);
        }
        public void llenarDatos_P02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgP02.ImageUrl = "~/img/" + imagen + ".png";

            P02Actual.Text = actual + "";
            P02AOP.Text = aop + "";

            loadChartP02(indice);
        }
        public void llenarDatos_P03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgP03.ImageUrl = "~/img/" + imagen + ".png";

            P03Actual.Text = actual + "";
            P03AOP.Text = aop + "";

            loadChartP03(indice);
        }
        public void llenarDatos_P04(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgP04.ImageUrl = "~/img/" + imagen + ".png";

            P04Actual.Text = actual + "";
            P04AOP.Text = aop + "";

            loadChartP04(indice);
        }

        private void loadChartP01(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTP01.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTP01.Series["Series2"].Points.Clear();
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTP01.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPP01.Series["Series1"].Points.Clear();
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPP01.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPP01.Series["Series2"].Points.Clear();
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPP01.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartP02(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTP02.Series["Series1"].Points.Clear();
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTP02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTP02.Series["Series2"].Points.Clear();
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTP02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPP02.Series["Series1"].Points.Clear();
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPP02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPP02.Series["Series2"].Points.Clear();
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPP02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartP03(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTP03.Series["Series1"].Points.Clear();
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTP03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTP03.Series["Series2"].Points.Clear();
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTP03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPP03.Series["Series1"].Points.Clear();
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPP03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPP03.Series["Series2"].Points.Clear();
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPP03.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartP04(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTP04.Series["Series1"].Points.Clear();
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTP04.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTP04.Series["Series2"].Points.Clear();
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTP04.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPP04.Series["Series1"].Points.Clear();
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPP04.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPP04.Series["Series2"].Points.Clear();
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPP04.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }


    }
}