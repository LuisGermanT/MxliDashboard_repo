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
    public partial class n2_Delivery : System.Web.UI.Page
    {
        public int bandChange = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVF_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
            this.ASPxComboBoxF2.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF2_SelectedIndexChanged);
            this.ASPxComboBoxF3.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF3_SelectedIndexChanged);

            llenarDatos_D01(0);
            loadChartD01(0, "All", "SITE");
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

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
            if (indice == 1)
            {
                D01.Visible = true;
                D02.Visible = false;
                D03.Visible = false;
                D04.Visible = true;
                D05.Visible = false;
                D06.Visible = false;
            }
            else
            {
                D01.Visible = true;
                D02.Visible = true;
                D03.Visible = true;
                D04.Visible = true;
                D05.Visible = true;
                D06.Visible = true;
            }
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
            llenarDatos_D01(0);
            loadChartD01(ASPxComboBoxV.SelectedIndex, "All", "SITE");
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
                    llenarDatos_D01(0);
                    loadChartD01(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_D01(0);
                    loadChartD01(tipoV, tipoVSM, xFilter);
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
                    llenarDatos_D01(0);
                    loadChartD01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D01(0);
                    loadChartD01(tipoV, tipoVSM, xFilter);
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
                    llenarDatos_D01(0);
                    loadChartD01(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D01(0);
                    loadChartD01(tipoV, tipoVSM, xFilter);
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

        public void llenarDatos_D01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";
            string xClass = "All";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            //string qry = "SELECT TOP 1 * FROM vw_ottr_by_wk ORDER BY [TO_Yr] desc, [TO_Wk] desc, [TO_Month] desc";
            string qry = "select TOP 1 * from [sta_nivel2] where smetric = 'OTTR' and sClass = '" + xClass + "' order by id desc";
            DataTable dtPareto = dBHelper.QryManager(qry);

            if (dtPareto.Rows.Count > 0)
            {
                actual = Convert.ToDouble(dtPareto.Rows[0]["factual"].ToString());
                aop = Convert.ToDouble(dtPareto.Rows[0]["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgD01.ImageUrl = "~/img/" + imagen + ".png";

            D01Actual.Text = actual + "%";
            D01AOP.Text = aop + "%";
        }


        private void loadChartD01(int tipo, string clase, string filtro)
        {
            chartTD01.Series["Series1"].Points.Clear();
            chartTD01.Series["Series2"].Points.Clear();
            chartTD01.Series["Series3"].Points.Clear();
            chartPD01.Series["Series1"].Points.Clear();
            chartPD01.Series["Series2"].Points.Clear();

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

            string query1 = "select top 13 * from [sta_nivel2] where smetric = 'ottr' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            string qry1 = "select * from (" + query1 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTD01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTD01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTD01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
            }

            string query2 = "select top 10 * from [sta_nivel2p] where smetric = 'ottr' and stype = 'causes' order by id";
            string qry2 = "select * from (" + query2 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper2.QryManager(qry2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPD01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPD01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                chartPD01.Series["Series1"].ToolTip = "#VALX";
            }
        }

        


    }
}