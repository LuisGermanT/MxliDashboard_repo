using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVF_SelectedIndexChanged);
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        { }

        protected void imageStatus_Init(object sender, EventArgs e)
        {

        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            string xMetric = Convert.ToString(e.GetValue("smetric"));

            //e.Row.Cells[1].Text = String.Format("{0:N0}", e.GetValue("factual"));
            //e.Row.Cells[2].Text = String.Format("{0:N0}", e.GetValue("fgoal"));
            //e.Row.Cells[3].Text = String.Format("{0:N0}", e.GetValue("factual"));
            //e.Row.Cells[4].Text = String.Format("{0:N0}", e.GetValue("fgoal"));
            //e.Row.Cells[6].Text = loadHighlights(xMetric);
            //if (xMetric == "INVENTARIO" || xMetric == "ENTITLEMENT" || xMetric == "PASTDUE" || xMetric == "VMI")
            //{
            //    e.Row.Cells[1].Text = String.Format("{0:C2}", e.GetValue("factual"));
            //    e.Row.Cells[2].Text = String.Format("{0:C2}", e.GetValue("fgoal"));
            //    e.Row.Cells[3].Text = String.Format("{0:C2}", e.GetValue("factual"));
            //    e.Row.Cells[4].Text = String.Format("{0:C2}", e.GetValue("fgoal"));
            //}    

            e.Row.Cells[6].Text = loadHighlights(xMetric);
            string[] xValoresM = loadMonthly(xMetric);
            string[] xValoresY = loadYearly(xMetric);
            decimal v1 = Convert.ToDecimal(xValoresM[0]);
            decimal v2 = Convert.ToDecimal(xValoresM[1]);
            decimal v3 = Convert.ToDecimal(xValoresY[0]);
            decimal v4 = Convert.ToDecimal(xValoresY[1]);
            e.Row.Cells[1].Text = String.Format("{0:N0}", v1);
            e.Row.Cells[2].Text = String.Format("{0:N0}", v2);
            e.Row.Cells[3].Text = String.Format("{0:N0}", v3);
            e.Row.Cells[4].Text = String.Format("{0:N0}", v4);
            if (xMetric == "INVENTARIO" || xMetric == "ENTITLEMENT" || xMetric == "PASTDUE" || xMetric == "VMI")
            {
                e.Row.Cells[1].Text = String.Format("{0:C2}", v1 / 1000000) + "M";
                e.Row.Cells[2].Text = String.Format("{0:C2}", v2 / 1000000) + "M";
                e.Row.Cells[3].Text = String.Format("{0:C2}", v3 / 1000000) + "M";
                e.Row.Cells[4].Text = String.Format("{0:C2}", v4 / 1000000) + "M";
            }
            if (xMetric == "OTTR" || xMetric == "Utilization" || xMetric == "Labor Productivity")
            {
                e.Row.Cells[1].Text = String.Format("{0:N2}", v1) + "%";
                e.Row.Cells[2].Text = String.Format("{0:N2}", v2) + "%";
                e.Row.Cells[3].Text = String.Format("{0:N2}", v3) + "%";
                e.Row.Cells[4].Text = String.Format("{0:N2}", v4) + "%";
            }

            ASPxImage img = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, null, "imgControl") as ASPxImage;
            if (v1 < v2)
            {
                img.ImageUrl = "img/bad.png";
            }
            else
            {
                img.ImageUrl = "img/good.png";
            }
        }


        protected string loadHighlights(string xMetric)
        {
            //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            string xDescripcion = "";
            string query = "SELECT TOP 1 * FROM tbl_highlights WHERE smetrico = '"+xMetric+ "' order by highlight_id desc";
            string qry = "select * from (" + query + ") q1 order by highlight_id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dt1.Rows)
            {
                xDescripcion = dr1["descripcion"].ToString();
            }
            return xDescripcion;
        }

        protected string[] loadMonthly(string xMetric)
        {
            //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            string[] xValores = { "0", "0" };
            string query = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '" + xMetric + "' and sfilter = 'site' and stype = 'monthly' order by id desc";
            string qry = "select * from (" + query + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dt1.Rows)
            {
                xValores[0] = dr1["factual"].ToString();
                xValores[1] = dr1["fgoal"].ToString();
            }
            return xValores;
        }

        protected string[] loadYearly(string xMetric)
        {
            //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            string[] xValores = { "0", "0" };
            string query = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '"+xMetric+"' and sfilter = 'site' and stype = 'yearly' order by id desc";
            string qry = "select * from (" + query + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);
            foreach (DataRow dr1 in dt1.Rows)
            {
                xValores[0] = dr1["factual"].ToString();
                xValores[1] = dr1["fgoal"].ToString();
            }
            return xValores;
        }

       
    }
}