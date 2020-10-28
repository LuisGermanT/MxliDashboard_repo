﻿using DevExpress.Web;
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
            this.ASPxComboBoxF11.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF11_SelectedIndexChanged);
            this.ASPxComboBoxF12.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF12_SelectedIndexChanged);
            llenarDatos_S01(0);
            loadChartS01(0, "All", "SITE");
            llenarDatos_S02(0);
            loadChartS02(0, "All", "SITE");
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
        protected void cmbox_DataBoundF10(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF10.Items.Insert(0, defaultItem);
            ASPxComboBoxF10.SelectedIndex = 0;
        }
        protected void cmbox_DataBoundF11(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF11.Items.Insert(0, defaultItem);
            ASPxComboBoxF11.SelectedIndex = 0;
        }
        protected void cmbox_DataBoundF12(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF12.Items.Insert(0, defaultItem);
            ASPxComboBoxF12.SelectedIndex = 0;
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
            if (ASPxComboBoxF11.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF11.SelectedIndex = 0;
                bandChange = 0;
            }
            if (ASPxComboBoxF12.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF12.SelectedIndex = 0;
                bandChange = 0;
            }
            llenarDatos_S01(0);
            loadChartS01(ASPxComboBoxV.SelectedIndex, "All", "SITE");
            llenarDatos_S02(0);
            loadChartS02(ASPxComboBoxV.SelectedIndex, "All", "SITE");
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
                    llenarDatos_S01(0);
                    loadChartS01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_S01(0);
                    loadChartS01(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF2.SelectedIndex = 0;
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
                    llenarDatos_S01(0);
                    loadChartS01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_S01(0);
                    loadChartS01(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF1.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                int tipoV = ASPxComboBoxV.SelectedIndex;
                string xFilter = "RESPONSIBLE";
                string tipoVSM = ASPxComboBoxF3.SelectedItem.ToString();
                if (ASPxComboBoxF3.SelectedIndex == 0)
                {
                    llenarDatos_S02(0);
                    loadChartS02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_S02(0);
                    loadChartS02(tipoV, tipoVSM, xFilter);
                }
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
                string xFilter = "STATUS";
                string tipoVSM = ASPxComboBoxF4.SelectedItem.ToString();
                if (ASPxComboBoxF4.SelectedIndex == 0)
                {
                    llenarDatos_S02(0);
                    loadChartS02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_S02(0);
                    loadChartS02(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF3.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxF5_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF6_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF7_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF8_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF9_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF10_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF11_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void ASPxComboBoxF12_SelectedIndexChanged(object sender, EventArgs e)
        { }

        public void llenarDatos_S01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'incidentes' and sfilter = 'SITE' and sdesc = '" + (semana-1) + "' order by id", conn1);   //porque no existe semana actual
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
            string imagen = "good";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'mst' and sfilter = 'SITE' and sdesc = '" + (semana-1) + "' order by id", conn1);   //porque si existe semana actual
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelS02.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual < aop) { imagen = "bad"; }
            imgS02.ImageUrl = "~/img/" + imagen + ".png";

            S02Actual.Text = (actual).ToString();
            S02AOP.Text = (aop).ToString();
        }

        private void loadChartS01(int tipo, string clase, string filtro)
        {
            chartTS01.Series["Series1"].Points.Clear();
            chartTS01.Series["Series2"].Points.Clear();
            chartTS01.Series["Series3"].Points.Clear();
            chartPS01.Series["Series1"].Points.Clear();
            chartPS01.Series["Series2"].Points.Clear();

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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'incidentes' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id", conn1);
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

            string query2 = "select top 10 * from [sta_nivel2p] where smetric = 'incidentes' and stype = 'causes' order by id";
            string qry2 = "select * from (" + query2 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper2.QryManager(qry2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPS01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPS01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                chartPS01.Series["Series1"].ToolTip = "#VALX";
            }
        }

        private void loadChartS02(int tipo, string clase, string filtro)
        {
            chartTS02.Series["Series1"].Points.Clear();
            chartTS02.Series["Series2"].Points.Clear();
            chartTS02.Series["Series3"].Points.Clear();
            chartPS02.Series["Series1"].Points.Clear();
            chartPS02.Series["Series2"].Points.Clear();

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

            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            string query1 = "";
            if (xTipo == "WEEKLY")
            {
                query1 = "select top 13 * from [sta_nivel2] where smetric = 'mst' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' and sdesc <= '" + (semana-1) + "'  order by id desc";
            }
            else
            {
                query1 = "select top 13 * from [sta_nivel2] where smetric = 'mst' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            }
            string qry = "select * from (" + query1 + ") q1 order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTS02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTS02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTS02.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            string tipoP = "";
            if(filtro == "STATUS")
            {
                tipoP = "STATUS";
            }
            else
            {
                tipoP = "RESPONSIBLE";
            }

            string query2 = "select top 10 * from [sta_nivel2p] where smetric = 'mst' and stype = '" + tipoP + "' order by id";
            string qry2 = "select * from (" + query2 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper2.QryManager(qry2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPS02.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPS02.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                chartPS02.Series["Series1"].ToolTip = "#VALX";
            }
        }     
        

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
            if (indice == 1)
            {
                S01.Visible = true;
                S02.Visible = false;
            }
            else
            {
                S01.Visible = true;
                S02.Visible = true;
            }
        }


    }
}