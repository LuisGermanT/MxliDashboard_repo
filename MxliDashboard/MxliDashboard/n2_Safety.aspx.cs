using System;
using System.Collections.Generic;
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
            llenarDatos_S01(0);
            llenarDatos_S02(0);
            llenarDatos_S03(0);
        }

        public void llenarDatos_S01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgS01.ImageUrl = "~/img/" + imagen + ".png";

            S01Actual.Text = actual + "";
            S01AOP.Text = aop + "";

            loadChartS01(indice);
        }
        public void llenarDatos_S02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgS02.ImageUrl = "~/img/" + imagen + ".png";

            S02Actual.Text = actual + "";
            S02AOP.Text = aop + "";

            loadChartS02(indice);
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

        private void loadChartS01(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTS01.Series["Series1"].Points.Clear();
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTS01.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTS01.Series["Series2"].Points.Clear();
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTS01.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPS01.Series["Series1"].Points.Clear();
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPS01.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPS01.Series["Series2"].Points.Clear();
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPS01.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartS02(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTS02.Series["Series1"].Points.Clear();
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartTS02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartTS02.Series["Series2"].Points.Clear();
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartTS02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);

            chartPS02.Series["Series1"].Points.Clear();
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 12), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 8), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 4), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 3), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 1), 0);
            chartPS02.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPS02.Series["Series2"].Points.Clear();
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 12), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 11), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 10), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 9), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 8), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 7), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 6), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 5), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 4), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 3), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 2), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 1), 0);
            chartPS02.Series["Series2"].Points.AddXY("W" + (semana - 0), 0);
        }

        private void loadChartS03(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTS03.Series["Series1"].Points.Clear();
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 12), 1);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 9), 1);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 8), 1);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 4), 1);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 3), 1);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTS03.Series["Series1"].Points.AddXY("W" + (semana - 1), 1);
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
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 12), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 11), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 10), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 9), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 8), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 6), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 5), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 4), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 3), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 1), 1);
            chartPS03.Series["Series1"].Points.AddXY("W" + (semana - 0), 0);

            chartPS03.Series["Series2"].Points.Clear();
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 12), 1);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 11), 1);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 10), 1);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 9), 2);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 8), 3);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 7), 3);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 6), 3);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 5), 3);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 4), 4);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 3), 5);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 2), 5);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 1), 6);
            chartPS03.Series["Series2"].Points.AddXY("W" + (semana - 0), 6);
        }


    }
}