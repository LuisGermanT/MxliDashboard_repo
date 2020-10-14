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
    public partial class Quality : System.Web.UI.Page
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
            llenarDatos_Q01(0);
            loadChartQ01(0, "All", "SITE");
            llenarDatos_Q02(0);
            loadChartQ02(0, "All", "SITE");
            llenarDatos_Q03(0);
            loadChartQ03(0, "All", "SITE");
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
            ASPxComboBoxF8.Items.Insert(0, defaultItem);
            ASPxComboBoxF8.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundF9(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF9.Items.Insert(0, defaultItem);
            ASPxComboBoxF9.SelectedIndex = 0;
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
            llenarDatos_Q01(0);
            loadChartQ01(ASPxComboBoxV.SelectedIndex, "All", "SITE");
            llenarDatos_Q02(0);
            loadChartQ02(ASPxComboBoxV.SelectedIndex, "All", "SITE");
            llenarDatos_Q03(0);
            loadChartQ03(ASPxComboBoxV.SelectedIndex, "All", "SITE");
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
                    llenarDatos_Q01(0);
                    loadChartQ01(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(tipoV, tipoVSM, xFilter);
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
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF2.SelectedItem.ToString();
                if (ASPxComboBoxF2.SelectedIndex == 0)
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(tipoV, tipoVSM, xFilter);
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
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "MRP";
                string tipoVSM = ASPxComboBoxF3.SelectedItem.ToString();
                if (ASPxComboBoxF3.SelectedIndex == 0)
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(tipoV, tipoVSM, xFilter);
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

        protected void ASPxComboBoxF4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "VSM";
                string tipoVSM = ASPxComboBoxF4.SelectedItem.ToString();
                if (ASPxComboBoxF4.SelectedIndex == 0)
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(tipoV, tipoVSM, xFilter);
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

        protected void ASPxComboBoxF5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF5.SelectedItem.ToString();
                if (ASPxComboBoxF5.SelectedIndex == 0)
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF4.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF6.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "MRP";
                string tipoVSM = ASPxComboBoxF6.SelectedItem.ToString();
                if (ASPxComboBoxF6.SelectedIndex == 0)
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q02(0);
                    loadChartQ02(tipoV, tipoVSM, xFilter);
                }
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
        }

        protected void ASPxComboBoxF7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "VSM";
                string tipoVSM = ASPxComboBoxF7.SelectedItem.ToString();
                if (ASPxComboBoxF7.SelectedIndex == 0)
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(tipoV, tipoVSM, xFilter);
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

        protected void ASPxComboBoxF8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "CELL";
                string tipoVSM = ASPxComboBoxF8.SelectedItem.ToString();
                if (ASPxComboBoxF8.SelectedIndex == 0)
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF7.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF9.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "MRP";
                string tipoVSM = ASPxComboBoxF9.SelectedItem.ToString();
                if (ASPxComboBoxF9.SelectedIndex == 0)
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_Q03(0);
                    loadChartQ03(tipoV, tipoVSM, xFilter);
                }
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
        }

        public void llenarDatos_Q01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'ppms' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelQ01.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgQ01.ImageUrl = "~/img/" + imagen + ".png";

            Q01Actual.Text = (actual).ToString();
            Q01AOP.Text = (aop).ToString();


        }
        public void llenarDatos_Q02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'escapes' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelQ02.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0,10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgQ02.ImageUrl = "~/img/" + imagen + ".png";

            Q02Actual.Text = (actual).ToString();
            Q02AOP.Text = (aop).ToString();
        }

        public void llenarDatos_Q03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'defectos' and sfilter = 'SITE' and sdesc = '" + (semana - 1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelQ03.Text = "Last update: " + dr1["sLstWkDay"].ToString();
            }

            if (actual > aop) { imagen = "badB"; }
            imgQ03.ImageUrl = "~/img/" + imagen + ".png";

            Q03Actual.Text = (actual).ToString();
            Q03AOP.Text = (aop).ToString();
        }

        private void loadChartQ01(int tipo, string clase, string filtro)
        {
            chartTQ01.Series["Series1"].Points.Clear();
            chartTQ01.Series["Series2"].Points.Clear();
            chartTQ01.Series["Series3"].Points.Clear();
            chartPQ01.Series["Series1"].Points.Clear();
            chartPQ01.Series["Series2"].Points.Clear();

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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'ppms' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTQ01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTQ01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTQ01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn2 = new SqlConnection(myCnStr2);
            SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'ppms' and stype = 'top' order by id", conn2);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPQ01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPQ01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            }
        }

        private void loadChartQ02(int tipo, string clase, string filtro)
        {
            chartTQ02.Series["Series1"].Points.Clear();
            chartTQ02.Series["Series2"].Points.Clear();
            chartTQ02.Series["Series3"].Points.Clear();
            chartPQ02.Series["Series1"].Points.Clear();
            chartPQ02.Series["Series2"].Points.Clear();

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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'escapes' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTQ02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTQ02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTQ02.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn2 = new SqlConnection(myCnStr2);
            SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'escapes' and stype = 'causes' order by id", conn2);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPQ02.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPQ02.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            }
        }

        private void loadChartQ03(int tipo, string clase, string filtro)
        {
            chartTQ03.Series["Series1"].Points.Clear();
            chartTQ03.Series["Series2"].Points.Clear();
            chartTQ03.Series["Series3"].Points.Clear();
            chartPQ03.Series["Series1"].Points.Clear();
            chartPQ03.Series["Series2"].Points.Clear();

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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'defectos' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTQ03.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTQ03.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTQ03.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn2 = new SqlConnection(myCnStr2);
            SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'defectos' and stype = 'causes' order by id", conn2);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPQ03.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPQ03.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            }
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
            if (indice == 1)
            {
                Q01.Visible = true;
                Q02.Visible = false;
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