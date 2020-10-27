using DevExpress.Web;
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
    public partial class Productivity : System.Web.UI.Page
    {
        public int bandChange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) {
                llenarDatos_P01(0, "All");
                llenarDatos_P02(0, "All");
                llenarDatos_P03(0, "All");
                llenarDatos_P04(0, "All");
                llenarDatos_P05(0, "All");
                loadChartP01(0, "All");
                loadChartP02(0, "All");
                loadChartP03(0, "All");
                loadChartP04(0, "All");
                loadChartP05(0, "All");
            }
        }

        protected void cmbox_DataBoundVsm(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxVsmInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundCell(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCellInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCellInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxVsmInContent.SelectedIndex;
                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_P01(0, "All");
                    loadChartP01(0, "All");
                    llenarDatos_P02(0, "All");
                    loadChartP02(0, "All");
                    llenarDatos_P05(0, "All");
                    loadChartP05(0, "All");
                }
                else
                {
                    llenarDatos_P01(1, vsm);
                    loadChartP01(1, vsm);
                    llenarDatos_P02(1, vsm);
                    loadChartP02(1, vsm);
                    llenarDatos_P05(1, vsm);
                    loadChartP05(1, vsm);
                }
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxCellInContent.SelectedIndex;
                string cell = ASPxComboBoxCellInContent.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_P01(0, "All");
                    loadChartP01(0, "All");
                    llenarDatos_P02(0, "All");
                    loadChartP02(0, "All");
                    llenarDatos_P05(0, "All");
                    loadChartP05(0, "All");
                }
                else
                {
                    llenarDatos_P01(2, cell);
                    loadChartP01(2, cell);
                    llenarDatos_P02(2, cell);
                    loadChartP02(2, cell);
                    llenarDatos_P05(2, cell);
                    loadChartP05(2, cell);
                }
            }

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        //Labor Productivity
        public void llenarDatos_P01(int indice, string _sClass)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "";

            qry = "select TOP 1 * from [sta_nivel2] where smetric = 'labor productivity' and sClass = '" + _sClass + "' order by id desc";
            DataTable dtPareto = dBHelper.QryManager(qry);

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgP01.ImageUrl = "~/img/" + imagen + ".png";

            P01Actual.Text = actual + "%";
            P01AOP.Text = aop + "%";

            //loadChartP01(indice, _sClass);
        }

        //Net Productivity Data
        public void llenarDatos_P02(int indice, string _sClass)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "";
            qry = "select TOP 1 * from [sta_nivel2] where smetric = 'net productivity' and sClass = '" + _sClass + "' order by id desc";

            DataTable dtPareto = dBHelper.QryManager(qry);

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgP02.ImageUrl = "~/img/" + imagen + ".png";

            P02Actual.Text = actual + "%";
            P02AOP.Text = aop + "%";

            //loadChartP02(indice, "");
        }
        
        //MPS Load
        public void llenarDatos_P03(int indice, string _sClass)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            if (actual > aop) { imagen = "badB"; }
            imgP03.ImageUrl = "~/img/" + imagen + ".png";

            P03Actual.Text = actual + "";
            P03AOP.Text = aop + "";

            //loadChartP03(indice, "");
        }

        //MPS Starts
        public void llenarDatos_P04(int indice, string _sClass)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            if (actual < aop) { imagen = "bad"; }
            imgP04.ImageUrl = "~/img/" + imagen + ".png";

            P04Actual.Text = actual + "";
            P04AOP.Text = aop + "";

            //loadChartP04(indice,"");
        }

        //Utilization
        public void llenarDatos_P05(int indice, string _sClass) {
            double actual = 0;
            double aop = 0;
            string imagen = "good";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "";

            qry = "select TOP 1 * from [sta_nivel2] where smetric = 'Utilization' and sClass = '" + _sClass + "' order by id desc";
            DataTable dtPareto = dBHelper.QryManager(qry);

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgP05.ImageUrl = "~/img/" + imagen + ".png";

            P05Actual.Text = actual + "%";
            P05AOP.Text = aop + "%";
        }

        //Labor Charts
        private void loadChartP01(int indice, string clase)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series2"].Points.Clear();
            //chartPP01.Series["Series1"].Points.Clear();
            //chartPP01.Series["Series2"].Points.Clear();

            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";

            if (indice == 1)
            {
                xClass = clase;
                xFilter = "VSM";
            }
            if (indice == 2)
            {
                xClass = clase;
                xFilter = "CELL";
            }

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "";
            //qry = "select top 13 * from [sta_nivel2] where smetric = 'labor productivity' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' and sdesc between " + (semana - 12) + " and " + semana + " order by id";
            qry = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'labor productivity' AND [sClass] = '" + xClass + "' AND [sType] = '" + xTipo + "' AND [sFilter] = '" + xFilter + 
                    "' AND [sLstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'" +
                    " Order by [sLstWkDay]";

            DataTable dtPareto = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dtPareto.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTP01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTP01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                //chartPP01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                //chartPP01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }
        }

        //Net Productivity  Charts
        private void loadChartP02(int indice, string clase)
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

        private void loadChartP03(int indice, string clase)
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

        private void loadChartP04(int indice, string clase)
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
        
        private void loadChartP05(int indice, string clase)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);

            chartTP05.Series["Series1"].Points.Clear();
            chartTP05.Series["Series2"].Points.Clear();

            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";

            if (indice == 1)
            {
                xClass = clase;
                xFilter = "VSM";
            }
            if (indice == 2)
            {
                xClass = clase;
                xFilter = "CELL";
            }

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "";
            qry = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' AND [sClass] = '" + xClass + "' AND [sType] = '" + xTipo + "' AND [sFilter] = '" + xFilter +
                    "' AND [sLstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'" +
                    " Order by [sLstWkDay]";

            DataTable dtPareto = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dtPareto.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTP05.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTP05.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }
        }

    }
}