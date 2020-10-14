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
            this.ASPxComboBoxVF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVF_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
            this.ASPxComboBoxF2.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF2_SelectedIndexChanged);
            this.ASPxComboBoxF3.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF3_SelectedIndexChanged);
            this.ASPxComboBoxF4.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF4_SelectedIndexChanged);
            this.ASPxComboBoxF5.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF5_SelectedIndexChanged);
            this.ASPxComboBoxF6.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF6_SelectedIndexChanged);
            this.ASPxComboBoxF7.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF7_SelectedIndexChanged);
            this.ASPxComboBoxF8.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF8_SelectedIndexChanged);
            this.ASPxComboBoxF9.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF9_SelectedIndexChanged);
            this.ASPxComboBoxF10.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF10_SelectedIndexChanged);

            llenarDatos_I01(0);
            loadChartI01(0, "All", "SITE");
            llenarDatos_I02(0);
            loadChartI02(0, "All", "SITE");
            llenarDatos_I03(0);
            loadChartI03(0, "All", "SITE");
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

        protected void cmbox_DataBoundF4(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF4.Items.Insert(0, defaultItem);
            ASPxComboBoxF4.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF5(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF5.Items.Insert(0, defaultItem);
            ASPxComboBoxF5.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF6(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF6.Items.Insert(0, defaultItem);
            ASPxComboBoxF6.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF7(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF7.Items.Insert(0, defaultItem);
            ASPxComboBoxF7.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF8(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ListEditItem defaultItem2 = new ListEditItem("BuyParts", "%%");
            ASPxComboBoxF8.Items.Insert(0, defaultItem);
            ASPxComboBoxF8.Items.Insert(1, defaultItem2);
            ASPxComboBoxF8.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF9(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ListEditItem defaultItem2 = new ListEditItem("BuyParts", "%%");
            ASPxComboBoxF9.Items.Insert(0, defaultItem);
            ASPxComboBoxF9.Items.Insert(1, defaultItem2);
            ASPxComboBoxF9.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF10(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ListEditItem defaultItem2 = new ListEditItem("VMI", "%%");
            ASPxComboBoxF10.Items.Insert(0, defaultItem);
            ASPxComboBoxF10.Items.Insert(1, defaultItem2);
            ASPxComboBoxF10.SelectedIndex = 0;
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF3.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF4.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF5.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF5.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF6.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF7.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF8.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF8.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF9.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF10.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF10.SelectedIndex = 0;
                bandChange = 0;
            }
            llenarDatos_I01(0);
            loadChartI01(ASPxComboBoxV.SelectedIndex, "All", "SITE");
            llenarDatos_I02(0);
            loadChartI02(ASPxComboBoxV.SelectedIndex, "All", "SITE");
            llenarDatos_I03(0);
            loadChartI03(ASPxComboBoxV.SelectedIndex, "All", "SITE");
        }

        protected void ASPxComboBoxF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "VSM";
                string tipoVSM = ASPxComboBoxF1.SelectedItem.ToString();
                if (ASPxComboBoxF1.SelectedIndex == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(tipoV, "All","SITE");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(tipoV, tipoVSM,xFilter);
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
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF4.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF2.SelectedItem.ToString();
                if (ASPxComboBoxF2.SelectedIndex == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(tipoV, tipoVSM, xFilter);
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
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF4.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "MRP";
                string tipoVSM = ASPxComboBoxF3.SelectedItem.ToString();
                if (ASPxComboBoxF3.SelectedIndex == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(tipoV, tipoVSM, xFilter);
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
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF4.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "PFEP";
                string tipoVSM = ASPxComboBoxF4.SelectedItem.ToString();
                if (ASPxComboBoxF4.SelectedIndex == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(tipoV, tipoVSM, xFilter);
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
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF3.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "VSM";
                string tipoVSM = ASPxComboBoxF5.SelectedItem.ToString();
                if (ASPxComboBoxF5.SelectedIndex == 0)
                {
                    llenarDatos_I02(0);
                    loadChartI02(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_I02(0);
                    loadChartI02(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF6.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF7.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF6.SelectedItem.ToString();
                if (ASPxComboBoxF6.SelectedIndex == 0)
                {
                    llenarDatos_I02(0);
                    loadChartI02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I02(0);
                    loadChartI02(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF5.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF5.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF7.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF7_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "MRP";
                string tipoVSM = ASPxComboBoxF7.SelectedItem.ToString();
                if (ASPxComboBoxF7.SelectedIndex == 0)
                {
                    llenarDatos_I02(0);
                    loadChartI02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I02(0);
                    loadChartI02(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF5.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF5.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF6.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF8_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "PFEP";
                string tipoVSM = ASPxComboBoxF8.SelectedItem.ToString();
                if (ASPxComboBoxF8.SelectedIndex == 0)
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");   //no hay filtros
                    //llenarDatos_I03(0);
                    //loadChartI03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF9.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF10.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF10.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "VSM";
                string tipoVSM = ASPxComboBoxF9.SelectedItem.ToString();
                if (ASPxComboBoxF9.SelectedIndex == 0)
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");   //no hay filtros
                    //llenarDatos_I03(0);
                    //loadChartI03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF8.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF8.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF10.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF10.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF10.SelectedItem.ToString();
                if (ASPxComboBoxF10.SelectedIndex == 0)
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_I03(0);
                    loadChartI03(0, "All", "SITE");   //no hay filtros
                    //llenarDatos_I03(0);
                    //loadChartI03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF8.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF8.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF9.SelectedIndex = 0;
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

            //DateTime day = DateTime.Today;
            //while (day.DayOfWeek != DayOfWeek.Friday)
            //    day = day.AddDays(-1);
            //ASPxLabelI.Text = "Last update: " + day.ToShortDateString();

            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                //ASPxLabelI.Text = "Last update: " + DateTime.Today.ToShortDateString();
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

        private void loadChartI01(int tipo, string clase, string filtro)
        {
            chartTI01.Series["Series1"].Points.Clear();
            chartTI01.Series["Series2"].Points.Clear();
            chartTI01.Series["Series3"].Points.Clear();
            string xTipo = "weekly";
            if (tipo < 2)
            {
                xTipo = "WEEKLY";
            }
            if (tipo == 2)
            {
                xTipo = "MONTHLY";
            }
            if (tipo == 3)
            {
                xTipo = "QUARTERLY";
            }
            if (tipo == 4)
            {
                xTipo = "YEARLY";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'inventario' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            //double xTemp = 60.1;
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual/1000000),2));
                chartTI01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal/1000000), 2));
                chartTI01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2)*.9);
                //xTemp = xTemp - .15;
            }
        }

        private void loadChartI02(int tipo, string clase, string filtro)
        {
            chartTI02.Series["Series1"].Points.Clear();
            chartTI02.Series["Series2"].Points.Clear();
            chartTI02.Series["Series3"].Points.Clear();
            string xTipo = "weekly";
            if (tipo < 2)
            {
                xTipo = "WEEKLY";
            }
            if (tipo == 2)
            {
                xTipo = "MONTHLY";
            }
            if (tipo == 3)
            {
                xTipo = "QUARTERLY";
            }
            if (tipo == 4)
            {
                xTipo = "YEARLY";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'entitlement' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual / 1000000), 2));
                chartTI02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                chartTI02.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2) * .9);
            }
        }

        private void loadChartI03(int tipo, string clase, string filtro)
        {
            chartTI03.Series["Series1"].Points.Clear();
            chartTI03.Series["Series2"].Points.Clear();
            chartTI03.Series["Series3"].Points.Clear();
            string xTipo = "weekly";
            if (tipo < 2)
            {
                xTipo = "WEEKLY";
            }
            if (tipo == 2)
            {
                xTipo = "MONTHLY";
            }
            if (tipo == 3)
            {
                xTipo = "QUARTERLY";
            }
            if (tipo == 4)
            {
                xTipo = "YEARLY";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'vmi' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI03.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual / 1000000), 2));
                chartTI03.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                chartTI03.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2) * .9);
            }
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
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