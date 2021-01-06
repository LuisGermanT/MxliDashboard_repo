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

namespace MxliDashboard.n3_Quality
{
    public partial class dEscapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVsmInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVsmInContent_SelectedIndexChanged);
            this.ASPxComboBoxCellInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCellInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            loadChartQ01(0, "All", "SITE");
        }

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
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
            int tipoV = ASPxComboBoxV.SelectedIndex;
            string xFilter = "VSM";
            string tipoVSM = ASPxComboBoxVsmInContent.SelectedItem.ToString();
            if (ASPxComboBoxVsmInContent.SelectedIndex == 0)
            {
                loadChartQ01(tipoV, "All", "SITE");
            }
            else
            {
                loadChartQ01(tipoV, tipoVSM, xFilter);
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoV = ASPxComboBoxV.SelectedIndex;
            string xFilter = "CELL";
            string tipoVSM = ASPxComboBoxCellInContent.SelectedItem.ToString();
            if (ASPxComboBoxCellInContent.SelectedIndex == 0)
            {
                loadChartQ01(0, "All", "SITE");
            }
            else
            {
                loadChartQ01(tipoV, tipoVSM, xFilter);
            }
        }

        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoV = ASPxComboBoxV.SelectedIndex;
            string xFilter = "MRP";
            string tipoVSM = ASPxComboBoxMrpInContent.SelectedItem.ToString();
            if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
            {
                loadChartQ01(0, "All", "SITE");
            }
            else
            {
                loadChartQ01(tipoV, tipoVSM, xFilter);
            }
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChartQ01(ASPxComboBoxV.SelectedIndex, "All", "SITE");
        }

        private void loadChartQ01(int tipo, string clase, string filtro)
        {
            chartTQ01.Series["Total"].Points.Clear();
            chartTQ01.Series["Planned"].Points.Clear();
            chartPQ01.Series["Series1"].Points.Clear();
            chartPQ01.Series["Series2"].Points.Clear();
            chartFQ01.Series["Series1"].Points.Clear();
            chartFQ01.Series["Series2"].Points.Clear();

            string xTipo = "weekly";
            int xTop = 13;
            if (tipo < 2)
            {
                xTipo = "WEEKLY";
                xTop = 13;
            }
            if (tipo == 2)
            {
                xTipo = "MONTHLY";
                xTop = 6;
            }
            if (tipo == 3)
            {
                xTipo = "QUARTERLY";
                xTop = 4;
            }
            if (tipo == 4)
            {
                xTipo = "YEARLY";
                xTop = 2;
            }

            string query = "select top " + xTop + " * from [sta_nivel2] where smetric = 'escapes' and sfilter = '" + filtro + "' and sclass = '" + clase + "' and stype = '" + xTipo + "' order by id desc";
            string qry = "select * from (" + query + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTQ01.Series["Total"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTQ01.Series["Planned"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }

            string query2 = "select top " + xTop + " * from [sta_nivel2f] where smetric = 'escapes' and stype = '" + xTipo + "' order by id";
            string qry2 = "select * from (" + query2 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper2.QryManager(qry2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                double xActual = Convert.ToDouble(dr2["factual"].ToString());
                double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                chartFQ01.Series["Series1"].Points.AddXY(dr2["scause"].ToString(), xActual);
                chartFQ01.Series["Series2"].Points.AddXY(dr2["scause"].ToString(), xGoal);
            }

            string query3 = "select top 5 * from [sta_nivel2p] where smetric = 'escapes' and stype = 'causes' order by id";
            string qry3 = "select * from (" + query3 + ") q2 order by id";
            SQLHelper.DBHelper dBHelper3 = new SQLHelper.DBHelper();
            DataTable dt3 = dBHelper2.QryManager(qry3);
            foreach (DataRow dr3 in dt3.Rows)
            {
                double xActual = Convert.ToDouble(dr3["factual"].ToString());
                double xGoal = Convert.ToDouble(dr3["fsum"].ToString());
                chartPQ01.Series["Series1"].Points.AddXY(dr3["scause"].ToString(), xActual);
                chartPQ01.Series["Series2"].Points.AddXY(dr3["scause"].ToString(), xGoal);
            }
        }


    }
}