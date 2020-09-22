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
    public partial class Inventory : System.Web.UI.Page
    {
        public int bandChange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
            this.ASPxComboBoxF2.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF2_SelectedIndexChanged);
            this.ASPxComboBoxF3.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF3_SelectedIndexChanged);
            llenarDatos_I01(0);
            loadChartI01(0, "All");
            llenarDatos_I02(0);
            loadChartI02(0, "All");
            llenarDatos_I03(0);
            loadChartI03(0);
        }

        protected void cmbox_DataBoundV(object sender, EventArgs e)
        {
            ASPxComboBoxV.Items.Insert(0, new ListEditItem("All"));
            ASPxComboBoxV.Items.Insert(1, new ListEditItem("T1"));
            ASPxComboBoxV.Items.Insert(2, new ListEditItem("T2"));
            ASPxComboBoxV.Items.Insert(3, new ListEditItem("T3"));
            ASPxComboBoxV.Items.Insert(4, new ListEditItem("Function"));
            ASPxComboBoxV.Items.Insert(5, new ListEditItem("WarRoom"));
            ASPxComboBoxV.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF1(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF1.Items.Insert(0, defaultItem);
            ASPxComboBoxF1.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF2(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF2.Items.Insert(0, defaultItem);
            ASPxComboBoxF2.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF3(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF3.Items.Insert(0, defaultItem);
            ASPxComboBoxF3.SelectedIndex = 0;
        }

        protected void ASPxComboBoxF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxF1.SelectedIndex;
                string vsm = ASPxComboBoxF1.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(1, vsm);
                    llenarDatos_I02(0);
                    loadChartI02(1, vsm);
                }
            }

            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF2.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF3.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxF2.SelectedIndex;
                string cell = ASPxComboBoxF2.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(2, cell);
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
            }

            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF1.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF3.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxF3.SelectedIndex;
                string mrp = ASPxComboBoxF3.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(2, mrp);
                }
            }

            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF1.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF2.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        public void llenarDatos_I01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'inventario' and sfilter = 'SITE' and sdesc = '"+(semana-1)+"' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelI.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgI01.ImageUrl = "~/img/" + imagen + ".png";

            I01Actual.Text = (actual / 1000).ToString("C2") + "K";
            I01AOP.Text = (aop / 1000).ToString("C2") + "K";


        }
        public void llenarDatos_I02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'entitlement' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelE.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgI02.ImageUrl = "~/img/" + imagen + ".png";

            I02Actual.Text = (actual / 1000).ToString("C2") + "K";
            I02AOP.Text = (aop / 1000).ToString("C2") + "K";
        }

        public void llenarDatos_I03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'vmi' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelV.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgI03.ImageUrl = "~/img/" + imagen + ".png";

            I03Actual.Text = (actual / 1000).ToString("C2") + "K";
            I03AOP.Text = (aop / 1000).ToString("C2") + "K";
        }

        private void loadChartI01(int tipo, string clase)
        {
            chartTI01.Series["Series1"].Points.Clear();
            chartTI01.Series["Series2"].Points.Clear();
            chartTI01.Series["Series3"].Points.Clear();
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
                xFilter = "CELL";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'inventario' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            double xTemp = 60.1;
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual/1000000),2));
                chartTI01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal/1000000), 2));
                chartTI01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), xTemp);
                xTemp = xTemp - .15;
            }
        }

        private void loadChartI02(int tipo, string clase)
        {
            chartTI02.Series["Series1"].Points.Clear();
            chartTI02.Series["Series2"].Points.Clear();
            chartTI02.Series["Series3"].Points.Clear();
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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'entitlement' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual / 1000000), 2));
                chartTI02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                chartTI02.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }
        }

        private void loadChartI03(int indice)
        {
            chartTI03.Series["Series1"].Points.Clear();
            chartTI03.Series["Series2"].Points.Clear();
            chartTI03.Series["Series3"].Points.Clear();
            String xFilter = "SITE";
            string xTipo = "weekly";
            string xClass = "All";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'vmi' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI03.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual / 1000000), 2));
                chartTI03.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                chartTI03.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxV.SelectedIndex;
            if (indice == 1)
            {
                I01.Visible = true;
                I02.Visible = false;
                I03.Visible = false;
            }
            else
            {
                I01.Visible = true;
                I02.Visible = true;
                I03.Visible = true;
            }
        }


    }
}