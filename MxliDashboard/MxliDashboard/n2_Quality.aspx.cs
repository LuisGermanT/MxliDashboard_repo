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
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            llenarDatos_Q01(0);
            llenarDatos_Q02(0);
            llenarDatos_Q03(0);
            loadChartQ01(0, "All");
            loadChartQ02(0, "All");
            loadChartQ03(0);
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
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "");
                    llenarDatos_Q02(0);
                    loadChartQ02(0, "");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(1, vsm);
                    llenarDatos_Q02(0);
                    loadChartQ02(1, vsm);
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
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "");
                    llenarDatos_Q02(0);
                    loadChartQ02(0, "");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "");
                    llenarDatos_Q02(0);
                    loadChartQ02(0,"");
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
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "");
                    llenarDatos_Q02(0);
                    loadChartQ02(0, "");
                }
                else
                {
                    llenarDatos_Q01(0);
                    loadChartQ01(0, "");
                    llenarDatos_Q02(0);
                    loadChartQ02(2, mrp);
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

        private void loadChartQ01(int tipo, string clase)
        {
            chartTQ01.Series["Series1"].Points.Clear();
            chartTQ01.Series["Series2"].Points.Clear();
            chartTQ01.Series["Series3"].Points.Clear();
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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'ppms' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
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
            SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'ppms' and stype = 'causes' order by id", conn2);
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

        private void loadChartQ02(int tipo, string clase)
        {
            chartTQ02.Series["Series1"].Points.Clear();
            chartTQ02.Series["Series2"].Points.Clear();
            chartTQ02.Series["Series3"].Points.Clear();
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
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'escapes' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
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

        private void loadChartQ03(int indice)
        {
            chartTQ03.Series["Series1"].Points.Clear();
            chartTQ03.Series["Series2"].Points.Clear();
            chartTQ03.Series["Series3"].Points.Clear();
            String xFilter = "SITE";
            string xTipo = "weekly";
            string xClass = "All";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'defectos' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
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
            SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel2p] where smetric = 'defectos' and stype = 'material' order by id", conn2);
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