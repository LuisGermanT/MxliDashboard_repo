using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class Quality : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            llenarDatos_Q01(0);
            llenarDatos_Q02(0);
            llenarDatos_Q03(0);
        }

        public void llenarDatos_Q01(int indice)
        {
            double actual = 3922;
            double aop = 3827;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgQ01.ImageUrl = "~/img/" + imagen + ".png";

            Q01Actual.Text = actual + "";
            Q01AOP.Text = aop + "";

            loadChartQ01(indice);
        }
        public void llenarDatos_Q02(int indice)
        {
            double actual = 4;
            double aop = 3;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgQ02.ImageUrl = "~/img/" + imagen + ".png";

            Q02Actual.Text = actual + "";
            Q02AOP.Text = aop + "";

            loadChartQ02(indice);
        }
        public void llenarDatos_Q03(int indice)
        {
            double actual = 317;
            double aop = 180;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgQ03.ImageUrl = "~/img/" + imagen + ".png";

            Q03Actual.Text = actual + "";
            Q03AOP.Text = aop + "";

            loadChartQ03(indice);
        }

        private void loadChartQ01(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTQ01.Series["Series1"].Points.Clear();
            chartTQ01.Series["Series2"].Points.Clear();
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 12), 998);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 12), 7022);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 11), 1783);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 11), 7022);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 10), 820);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 10), 7022);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 9), 7013);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 8), 4237);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 8), 3831);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 7), 3827);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 6), 3501);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 6), 3827);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 5), 1200);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 5), 3827);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 4), 2481);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 4), 3831);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 3), 2614);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 3), 3831);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 2), 3827);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 1), 1359);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 1), 3827);
            chartTQ01.Series["Series1"].Points.AddXY("W" + (semana - 0), 3922);
            chartTQ01.Series["Series2"].Points.AddXY("W" + (semana - 0), 3827);

            chartPQ01.Series["Series1"].Points.Clear();
            chartPQ01.Series["Series2"].Points.Clear();
            chartPQ01.Series["Series1"].Points.AddXY("Unknown", 7);
            chartPQ01.Series["Series2"].Points.AddXY("Unknown", 7);
            chartPQ01.Series["Series1"].Points.AddXY("Operations - Assembly", 5);
            chartPQ01.Series["Series2"].Points.AddXY("Operations - Assembly", 12);
            chartPQ01.Series["Series1"].Points.AddXY("Supplier - Honeywell", 2);
            chartPQ01.Series["Series2"].Points.AddXY("Supplier - Honeywell", 14);
            chartPQ01.Series["Series1"].Points.AddXY("Design/Project/ETS", 1);
            chartPQ01.Series["Series2"].Points.AddXY("Design/Project/ETS", 15);
            chartPQ01.Series["Series1"].Points.AddXY("Operations - Gral/Mfg/Fab", 1);
            chartPQ01.Series["Series2"].Points.AddXY("Operations - Gral/Mfg/Fab", 16);
            chartPQ01.Series["Series1"].Points.AddXY("Other - Cause Status", 1);
            chartPQ01.Series["Series2"].Points.AddXY("Other - Cause Status", 17);
        }

        private void loadChartQ02(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTQ02.Series["Series1"].Points.Clear();
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 12), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 11), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 10), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 9), 0);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 8), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 7), 0);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 6), 3);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 5), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 4), 2);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 3), 2);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 2), 0);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 1), 1);
            chartTQ02.Series["Series1"].Points.AddXY("W" + (semana - 0), 4);

            chartTQ02.Series["Series2"].Points.Clear();
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 12), 5);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 11), 5);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 10), 5);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 9), 5);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 8), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 7), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 6), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 5), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 4), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 3), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 2), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 1), 3);
            chartTQ02.Series["Series2"].Points.AddXY("W" + (semana - 0), 3);

            chartPQ02.Series["Series1"].Points.Clear();
            chartPQ02.Series["Series2"].Points.Clear();
            chartPQ02.Series["Series1"].Points.AddXY("Unknown", 7);
            chartPQ02.Series["Series2"].Points.AddXY("Unknown", 7);
            chartPQ02.Series["Series1"].Points.AddXY("Operations - Assembly", 5);
            chartPQ02.Series["Series2"].Points.AddXY("Operations - Assembly", 12);
            chartPQ02.Series["Series1"].Points.AddXY("Supplier - Honeywell", 2);
            chartPQ02.Series["Series2"].Points.AddXY("Supplier - Honeywell", 14);
            chartPQ02.Series["Series1"].Points.AddXY("Design/Project/ETS", 1);
            chartPQ02.Series["Series2"].Points.AddXY("Design/Project/ETS", 15);
            chartPQ02.Series["Series1"].Points.AddXY("Operations - Gral/Mfg/Fab", 1);
            chartPQ02.Series["Series2"].Points.AddXY("Operations - Gral/Mfg/Fab", 16);
            chartPQ02.Series["Series1"].Points.AddXY("Other - Cause Status", 1);
            chartPQ02.Series["Series2"].Points.AddXY("Other - Cause Status", 17);

            //forecast
            chartTQ02.Series["Series3"].Points.Clear();
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 12), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 11), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 10), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 9), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 8), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 7), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 6), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 5), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 4), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 3), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 2), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 1), 0);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana - 0), 0);
            chartTQ02.Series["Series3"].Points[0].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[1].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[2].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[3].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[4].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[5].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[6].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[7].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[8].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[9].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[10].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[11].IsEmpty = true;
            chartTQ02.Series["Series3"].Points[12].IsEmpty = true;
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana + 2), 3);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana + 3), 3);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana + 4), 3);
            chartTQ02.Series["Series3"].Points.AddXY("W" + (semana + 5), 3);

            chartTQ02.Series["Series4"].Points.Clear();
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 12), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 11), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 10), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 9), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 8), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 7), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 6), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 5), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 4), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 3), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 2), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 1), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana - 0), 0);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana + 2), 2);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana + 3), 2);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana + 4), 2);
            chartTQ02.Series["Series4"].Points.AddXY("W" + (semana + 5), 2);
        }

        private void loadChartQ03(int indice)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTQ03.Series["Series1"].Points.Clear();
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 12), 400);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 11), 210);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 10), 274);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 9), 3);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 8), 59);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 7), 112);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 6), 202);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 5), 183);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 4), 232);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 3), 203);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 2), 276);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 1), 262);
            chartTQ03.Series["Series1"].Points.AddXY("W" + (semana - 0), 317);

            chartTQ03.Series["Series2"].Points.Clear();
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 12), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 11), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 10), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 9), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 8), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 7), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 6), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 5), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 4), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 3), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 2), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 1), 180);
            chartTQ03.Series["Series2"].Points.AddXY("W" + (semana - 0), 180);

            chartPQ03.Series["Series1"].Points.Clear();
            chartPQ03.Series["Series1"].Points.AddXY("Surface Damage", 353);
            chartPQ03.Series["Series1"].Points.AddXY("ID Out of Spec", 145);
            chartPQ03.Series["Series1"].Points.AddXY("Length Out of Spec", 135);
            chartPQ03.Series["Series1"].Points.AddXY("Pressure High", 124);
            chartPQ03.Series["Series1"].Points.AddXY("Paint", 118);
            chartPQ03.Series["Series1"].Points.AddXY("Location Out of Position", 108);
            chartPQ03.Series["Series1"].Points.AddXY("Weld / Braze - Cracks", 104);
            chartPQ03.Series["Series1"].Points.AddXY("Pressure Low", 99);
            chartPQ03.Series["Series1"].Points.AddXY("Penetrant Reject", 68);
            chartPQ03.Series["Series1"].Points.AddXY("Insulation Damage", 65);

            chartPQ03.Series["Series2"].Points.Clear();
            chartPQ03.Series["Series2"].Points.AddXY("Surface Damage", 353);
            chartPQ03.Series["Series2"].Points.AddXY("ID Out of Spec", 998);
            chartPQ03.Series["Series2"].Points.AddXY("Length Out of Spec", 1133);
            chartPQ03.Series["Series2"].Points.AddXY("Pressure High", 1257);
            chartPQ03.Series["Series2"].Points.AddXY("Paint", 1375);
            chartPQ03.Series["Series2"].Points.AddXY("Location Out of Position", 1483);
            chartPQ03.Series["Series2"].Points.AddXY("Weld / Braze - Cracks", 1587);
            chartPQ03.Series["Series2"].Points.AddXY("Pressure Low", 1686);
            chartPQ03.Series["Series2"].Points.AddXY("Penetrant Reject", 1754);
            chartPQ03.Series["Series2"].Points.AddXY("Insulation Damage", 1819);
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxV.SelectedIndex;
            if (indice == 1)
            {
                Q02.Visible = true;
                Q01.Visible = false;
                Q03.Visible = false;
            }
            else
            {
                Q01.Visible = true;
                Q02.Visible = true;
                Q03.Visible = true;
            }
        }


    }
}