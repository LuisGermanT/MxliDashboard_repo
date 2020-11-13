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
            if (!Page.IsPostBack)
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
                //this.ASPxComboBoxF8.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF8_SelectedIndexChanged);
                this.ASPxComboBoxF9.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF9_SelectedIndexChanged);

                llenarDatos_D01(0);
                loadChartD01(0, "All", "SITE");
                llenarDatos_D02(0);
                loadChartD02(0, "All", "SITE");
                llenarDatos_D03(0);
                loadChartD03(0, "All", "SITE");
            }

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

        //protected void cmbox_DataBoundF8(object sender, EventArgs e)
        //{
        //    ListEditItem defaultItem = new ListEditItem("All", "%%");
        //    ASPxComboBoxF8.Items.Insert(0, defaultItem);
        //    ASPxComboBoxF8.SelectedIndex = 0;
        //}

        protected void cmbox_DataBoundF9(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxF9.Items.Insert(0, defaultItem);
            ASPxComboBoxF9.SelectedIndex = 0;
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxVF.SelectedIndex;
            if (indice == 1)
            {
                D01.Visible = true;
                D02.Visible = false;
                D03.Visible = false;
            }
            else
            {
                D01.Visible = true;
                D02.Visible = true;
                D03.Visible = true;
            }

            //FilterVariables 
            int xTipo = 0;
            string _ottrFilter = "SITE", _ottrVSM = "All", _opFilter = "SITE", _opVSM = "All", _pdFilter = "SITE", _pdVSM = "All";

            if (ASPxComboBoxV.SelectedIndex > 0)
            {
                xTipo = ASPxComboBoxV.SelectedIndex;
            }

            //VSM
            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                _ottrFilter = "VSM";
                _ottrVSM = ASPxComboBoxF1.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF1.SelectedIndex = 0;
                //bandChange = 0;
            }
            //Cell
            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                _ottrFilter = "CELL";
                _ottrVSM = ASPxComboBoxF2.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF2.SelectedIndex = 0;
                //bandChange = 0;
            }
            //MRP
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                _ottrFilter = "MRP";
                _ottrVSM = ASPxComboBoxF3.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF3.SelectedIndex = 0;
                //bandChange = 0;
            }
            
            //VSM
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                _opFilter = "MRP";
                _opVSM = ASPxComboBoxF4.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF4.SelectedIndex = 0;
                //bandChange = 0;
            }
            //Cell
            if (ASPxComboBoxF5.SelectedIndex > 0)
            {
                _opFilter = "MRP";
                _opVSM = ASPxComboBoxF5.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF5.SelectedIndex = 0;
                //bandChange = 0;
            }
            //MRP
            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                _opFilter = "MRP";
                _opVSM = ASPxComboBoxF6.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF6.SelectedIndex = 0;
                //bandChange = 0;
            }
           
            //VSM
            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                _pdFilter = "VSM";
                _pdVSM = ASPxComboBoxF7.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF7.SelectedIndex = 0;
                //bandChange = 0;
            }
            //MRP
            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                _pdFilter = "MRP";
                _pdVSM = ASPxComboBoxF9.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF9.SelectedIndex = 0;
                //bandChange = 0;
            }

            llenarDatos_D01(0);
            loadChartD01(xTipo, _ottrVSM, _ottrFilter);
            llenarDatos_D02(0);
            loadChartD02(xTipo, _opVSM, _opFilter);
            llenarDatos_D03(0);
            loadChartD03(xTipo, _pdVSM, _pdFilter);
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxV.SelectedIndex;

            //FilterVariables 
            string _ottrFilter = "SITE", _ottrVSM = "All", _opFilter = "SITE", _opVSM = "All", _pdFilter = "SITE", _pdVSM = "All";

            if (ASPxComboBoxF1.SelectedIndex > 0)
            {
                _ottrFilter = "VSM";
                _ottrVSM = ASPxComboBoxF1.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF1.SelectedIndex = 0;
                //bandChange = 0;
            }
            if (ASPxComboBoxF2.SelectedIndex > 0)
            {
                _ottrFilter = "CELL";
                _ottrVSM = ASPxComboBoxF2.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF2.SelectedIndex = 0;
                //bandChange = 0;
            }
            if (ASPxComboBoxF3.SelectedIndex > 0)
            {
                _ottrFilter = "MRP";
                _ottrVSM = ASPxComboBoxF3.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF3.SelectedIndex = 0;
                //bandChange = 0;
            }
            
            if (ASPxComboBoxF4.SelectedIndex > 0)
            {
                _opFilter = "VSM";
                _opVSM = ASPxComboBoxF4.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF4.SelectedIndex = 0;
                //bandChange = 0;
            }
            if (ASPxComboBoxF5.SelectedIndex > 0)
            {
                _opFilter = "CELL";
                _opVSM = ASPxComboBoxF5.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF5.SelectedIndex = 0;
                //bandChange = 0;
            }
            if (ASPxComboBoxF6.SelectedIndex > 0)
            {
                _opFilter = "MRP";
                _opVSM = ASPxComboBoxF6.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF6.SelectedIndex = 0;
                //bandChange = 0;
            }
           
            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                _pdFilter = "VSM";
                _pdVSM = ASPxComboBoxF7.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF7.SelectedIndex = 0;
                //bandChange = 0;
            }
            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                _pdFilter = "MRP";
                _pdVSM = ASPxComboBoxF9.SelectedItem.ToString();
                //bandChange = 1;
                //ASPxComboBoxF9.SelectedIndex = 0;
                //bandChange = 0;
            }

            llenarDatos_D01(0);
            loadChartD01(indice, _ottrVSM, _ottrFilter);
            llenarDatos_D02(0);
            loadChartD02(indice, _opVSM, _opFilter);
            llenarDatos_D03(0);
            loadChartD03(indice, _pdVSM, _pdFilter);
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

            //UpdPnl1.Update();

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
            //llenarDatos_D02(0);
            //loadChartD02(0, "All", "SITE");
            //llenarDatos_D03(0);
            //loadChartD03(0, "All", "SITE");
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
                    llenarDatos_D02(0);
                    loadChartD02(tipoV, "All", "SITE");
                }
                else
                {
                    llenarDatos_D02(0);
                    loadChartD02(tipoV, tipoVSM, xFilter);
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
                    llenarDatos_D02(0);
                    loadChartD02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D02(0);
                    loadChartD02(tipoV, tipoVSM, xFilter);
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
                    llenarDatos_D02(0);
                    loadChartD02(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D02(0);
                    loadChartD02(tipoV, tipoVSM, xFilter);
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
                    llenarDatos_D03(0);
                    loadChartD03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D03(0);
                    loadChartD03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF9.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF9.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        //protected void ASPxComboBoxF8_SelectedIndexChanged(object sender, EventArgs e)
        //{ }

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
                    llenarDatos_D03(0);
                    loadChartD03(0, "All", "SITE");
                }
                else
                {
                    llenarDatos_D03(0);
                    loadChartD03(tipoV, tipoVSM, xFilter);
                }
            }

            if (ASPxComboBoxF7.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxF7.SelectedIndex = 0;
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

            //string query1 = "select top 8 * from [sta_nivel2] where smetric = 'ottr' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);
            string qry = "select TOP 8 * from [sta_nivel2] where smetric = 'ottr' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "'" +
                         " AND [sLstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' Order by [sLstWkDay] desc";
            string qry1 = "select * from (" + qry + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTD01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTD01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                //chartTD01.Series["Series3"].Points.AddXY(dr1["sdesc"].ToString(), "0");
                chartTD01.Series["Series2"].ToolTip = "#VALY";
            }

            string query2 = "select top 5 * from [sta_nivel2p] where smetric = 'ottr' and stype = 'causes' order by id desc";
            string qry2 = "select * from (" + query2 + ") q1 order by fActual desc";
            SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper2.QryManager(qry2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartPD01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartPD01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
                chartPD01.Series["Series2"].ToolTip = "#VALX";
            }
        }

        public void llenarDatos_D02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "good";
            string xClass = "All";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "select TOP 1 * from [sta_nivel2] where smetric = 'output' and sClass = '" + xClass + "' order by id desc";
            DataTable dtPareto = dBHelper.QryManager(qry);

            if (dtPareto.Rows.Count > 0)
            {
                actual = Convert.ToDouble(dtPareto.Rows[0]["factual"].ToString());
                aop = Convert.ToDouble(dtPareto.Rows[0]["fgoal"].ToString());
                ASPxLabelD2.Text = "Last update: " + dtPareto.Rows[0]["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual < aop) { imagen = "bad"; }
            imgD02.ImageUrl = "~/img/" + imagen + ".png";

            D02Actual.Text = Math.Round(actual) + "";
            D02AOP.Text = aop + "";
        }


        private void loadChartD02(int tipo, string clase, string filtro)
        {
            chartTD02.Series["Series1"].Points.Clear();
            chartTD02.Series["Series2"].Points.Clear();
            chartTD02.Series["Series3"].Points.Clear();
            //chartPD02.Series["Series1"].Points.Clear();
            //chartPD02.Series["Series2"].Points.Clear();

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

            string query1 = "select top 13 * from [sta_nivel2] where smetric = 'output' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            string qry1 = "select * from (" + query1 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTD02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTD02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
                chartTD02.Series["Series2"].ToolTip = "#VALY";
            }

            //string query2 = "select top 10 * from [sta_nivel2p] where smetric = 'output' and stype = 'causes' order by id";
            //string qry2 = "select * from (" + query2 + ") q1 order by id";
            //SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            //DataTable dt2 = dBHelper2.QryManager(qry2);
            //foreach (DataRow dr2 in dt2.Rows)
            //{
            //    double xActual = Convert.ToDouble(dr2["factual"].ToString());
            //    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
            //    chartPD02.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
            //    chartPD02.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            //    chartPD02.Series["Series2"].ToolTip = "#VALX";
            //}
        }

        public void llenarDatos_D03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";
            string xClass = "All";

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            string qry = "select TOP 1 * from [sta_nivel2] where smetric = 'pastdue' and sClass = '" + xClass + "' order by id desc";
            DataTable dtPareto = dBHelper.QryManager(qry);

            if (dtPareto.Rows.Count > 0)
            {
                actual = Convert.ToDouble(dtPareto.Rows[0]["factual"].ToString());
                aop = Convert.ToDouble(dtPareto.Rows[0]["fgoal"].ToString());
                ASPxLabelD3.Text = "Last update: " + dtPareto.Rows[0]["sLstWkDay"].ToString().Substring(0, 10);
            }

            if (actual > aop) { imagen = "badB"; }
            imgD03.ImageUrl = "~/img/" + imagen + ".png";

            D03Actual.Text = (actual / 1000).ToString("C2") + "K";
            D03AOP.Text = (aop / 1000).ToString("C2") + "K";
        }


        private void loadChartD03(int tipo, string clase, string filtro)
        {
            chartTD03.Series["Series1"].Points.Clear();
            chartTD03.Series["Series2"].Points.Clear();
            chartTD03.Series["Series3"].Points.Clear();
            //chartPD02.Series["Series1"].Points.Clear();
            //chartPD02.Series["Series2"].Points.Clear();

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

            string query1 = "select top 13 * from [sta_nivel2] where smetric = 'pastdue' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            string qry1 = "select * from (" + query1 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTD03.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xActual / 1000000), 2));
                chartTD03.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                chartTD03.Series["Series2"].ToolTip = "#VALY";
            }

        }



    }
}