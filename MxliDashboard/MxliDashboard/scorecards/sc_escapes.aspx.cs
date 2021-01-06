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
    public partial class sc_escapes : System.Web.UI.Page
    {
        public int bandChange = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVF_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
            this.ASPxComboBoxF2.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF2_SelectedIndexChanged);
            this.ASPxComboBoxGV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxGV_SelectedIndexChanged);
            llenarDatos_E01(0);
            loadChartE01(0, "All", "SITE",0);
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


        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
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
                llenarDatos_E01(0);
                loadChartE01(ASPxComboBoxV.SelectedIndex, "All", "SITE", ASPxComboBoxGV.SelectedIndex);
            }
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
                    llenarDatos_E01(0);
                    loadChartE01(0, "All", "SITE", ASPxComboBoxGV.SelectedIndex);
                }
                else
                {
                    llenarDatos_E01(0);
                    loadChartE01(tipoV, tipoVSM, xFilter, ASPxComboBoxGV.SelectedIndex);
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
                    llenarDatos_E01(0);
                    loadChartE01(0, "All", "SITE", ASPxComboBoxGV.SelectedIndex);
                }
                else
                {
                    llenarDatos_E01(0);
                    loadChartE01(tipoV, tipoVSM, xFilter, ASPxComboBoxGV.SelectedIndex);
                }
            }

            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF1.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoV = ASPxComboBoxV.SelectedIndex;
            string tipoVSM = "All";
            string xFilter = "SITE";
            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                tipoVSM = ASPxComboBoxF1.SelectedItem.ToString();
                xFilter = "VSM";
            }
            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                tipoVSM = ASPxComboBoxF2.SelectedItem.ToString();
                xFilter = "CELL";
                bandChange = 1;
                ASPxComboBoxV.SelectedIndex = 0;
                bandChange = 0;
            }
            loadChartE01(tipoV, tipoVSM, xFilter, ASPxComboBoxGV.SelectedIndex);
        }

        public void llenarDatos_E01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'escapes' and sfilter = 'SITE' and sdesc = '" + (semana-1) + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
                ASPxLabelE01.Text = "Last update: " + dr1["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual < aop) { imagen = "bad"; }
            imgE01.ImageUrl = "~/img/" + imagen + ".png";

            E01Actual.Text = (actual).ToString();
            E01AOP.Text = (aop).ToString();
        }

        private void loadChartE01(int tipo, string clase, string filtro, int xGraph)
        {
            chartE01.Series["Series1"].Points.Clear();
            chartE01.Series["Series2"].Points.Clear();
            chartE01.Series["Series3"].Points.Clear();

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

            if (xGraph < 2)
            {
                string query1 = "select top 13 * from [sta_nivel2] where smetric = 'escapes' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
                string qry1 = "select * from (" + query1 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    double xActual = Convert.ToDouble(dr1["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                    chartE01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                    chartE01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                    chartE01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
                }                
            }
            if (xGraph == 2)
            {
                string query2 = "select top 10 * from [sta_nivel2p] where smetric = 'escapes' and stype = 'causes' order by id";
                string qry2 = "select * from (" + query2 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                    chartE01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                    chartE01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                    chartE01.Series["Series1"].ToolTip = "#VALX";
                }
            }
            if (xGraph == 3)
            {
                string query2 = "select top 6 * from [sta_nivel2f] where smetric = 'escapes' and stype = '" + xTipo + "' order by id desc";
                string qry2 = "select * from (" + query2 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                    chartE01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                    chartE01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                    chartE01.Series["Series1"].ToolTip = "#VALX";
                }
            }
        }


        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
            if (indice == 1)
            {
                E01.Visible = true;
            }
            else
            {
                E01.Visible = true;
            }
        }


    }
}