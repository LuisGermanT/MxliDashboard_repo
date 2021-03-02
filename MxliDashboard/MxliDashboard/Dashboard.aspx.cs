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
            this.ASPxComboBoxTV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxTV_SelectedIndexChanged);
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxGridView1.DataSourceID = "SqlDataSource1";
            ASPxGridView1.AutoGenerateColumns = false;
            ASPxGridView1.DataBind();
            ASPxComboBoxTV.SelectedIndex = 0;
            if(ASPxComboBoxVF.SelectedIndex == 0)
            {
                ASPxLabel2.Visible = false;
                ASPxComboBoxTV.Visible = false;
            }
            else
            {
                //ASPxLabel2.Visible = true;
                //ASPxComboBoxTV.Visible = true;
                ASPxGridView1.DataSourceID = "SqlDataSource2";
            }
        }

        protected void ASPxComboBoxTV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASPxComboBoxTV.SelectedIndex == 0)
            {
                ASPxGridView1.DataSourceID = "SqlDataSource1";
                ASPxGridView1.AutoGenerateColumns = false;
                ASPxGridView1.DataBind();
            }
            //if (ASPxComboBoxTV.SelectedIndex == 1)
            //{
            //    ASPxGridView1.DataSourceID = "SqlDataSource2";
            //    ASPxGridView1.AutoGenerateColumns = false;
            //    ASPxGridView1.DataBind();
            //}
            //if (ASPxComboBoxTV.SelectedIndex == 2)
            //{
            //    ASPxGridView1.DataSourceID = "SqlDataSource3";
            //    ASPxGridView1.AutoGenerateColumns = false;
            //    ASPxGridView1.DataBind();
            //}
            //if (ASPxComboBoxTV.SelectedIndex == 3)
            //{
            //    ASPxGridView1.DataSourceID = "SqlDataSource4";
            //    ASPxGridView1.AutoGenerateColumns = false;
            //    ASPxGridView1.DataBind();
            //}
        }

        protected void cmbox_DataBoundVF(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxVF.Items.Insert(0, defaultItem);
            ASPxComboBoxVF.SelectedIndex = 0;
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                //string xMetric = ASPxGridView1.GetRowValues(0, "smetric").ToString();
                string xMetric = Convert.ToString(e.GetValue("smetric"));

                e.Row.Cells[6].Text = loadHighlights(xMetric);
                e.Row.Cells[9].Text = loadUpdates(xMetric);
                string[] xValoresM = loadMonthly(xMetric);
                string[] xValoresY = loadYearly(xMetric);
                decimal v1 = Convert.ToDecimal(xValoresM[0]);
                decimal v2 = Convert.ToDecimal(xValoresM[1]);
                decimal v3 = Convert.ToDecimal(xValoresY[0]);
                decimal v4 = Convert.ToDecimal(xValoresY[1]);
                if (regresValueType(xMetric) == 1)
                {
                    e.Row.Cells[1].Text = String.Format("{0:N0}", v1);
                    e.Row.Cells[2].Text = String.Format("{0:N0}", v2);
                    e.Row.Cells[3].Text = String.Format("{0:N0}", v3);
                    e.Row.Cells[4].Text = String.Format("{0:N0}", v4);
                }
                if (regresValueType(xMetric) == 2)
                {
                    e.Row.Cells[1].Text = String.Format("{0:C2}", v1 / 1000000) + "M";
                    e.Row.Cells[2].Text = String.Format("{0:C2}", v2 / 1000000) + "M";
                    e.Row.Cells[3].Text = String.Format("{0:C2}", v3 / 1000000) + "M";
                    e.Row.Cells[4].Text = String.Format("{0:C2}", v4 / 1000000) + "M";
                }
                if (regresValueType(xMetric) == 3)
                {
                    e.Row.Cells[1].Text = String.Format("{0:N2}", v1) + "%";
                    e.Row.Cells[2].Text = String.Format("{0:N2}", v2) + "%";
                    e.Row.Cells[3].Text = String.Format("{0:N2}", v3) + "%";
                    e.Row.Cells[4].Text = String.Format("{0:N2}", v4) + "%";
                }
                if (regresValueType(xMetric) == 33)
                {
                    e.Row.Cells[1].Text = String.Format("{0:N2}", v1) + "";
                    e.Row.Cells[2].Text = String.Format("{0:N2}", v2) + "";
                    e.Row.Cells[3].Text = String.Format("{0:N2}", v3) + "";
                    e.Row.Cells[4].Text = String.Format("{0:N2}", v4) + "";
                }
                if (regresValueType(xMetric) == 22)
                {
                    e.Row.Cells[1].Text = String.Format("{0:C2}", v1 / 1000) + "K";
                    e.Row.Cells[2].Text = String.Format("{0:C2}", v2 / 1000) + "K";
                    e.Row.Cells[3].Text = String.Format("{0:C2}", v3 / 1000) + "K";
                    e.Row.Cells[4].Text = String.Format("{0:C2}", v4 / 1000) + "K";
                }

                ASPxImage img = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, null, "imgControl") as ASPxImage;
                if (regresaIconType(xMetric) == 1)
                {
                    if (v1 < v2) { img.ImageUrl = "img/bad.png"; }
                    else { img.ImageUrl = "img/good.png"; }
                }
                else
                {
                    if (v1 < v2) { img.ImageUrl = "img/goodB.png"; }
                    else { img.ImageUrl = "img/badB.png"; }
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                HttpContext.Current.Items.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Server.Transfer("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }


        protected string loadHighlights(string xMetric)
        {
            string xDescripcion = "";
            try
            {
                //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                string query = "SELECT TOP 1 * FROM tbl_highlights WHERE smetrico = '" + xMetric + "' order by highlight_id desc";
                string qry = "select * from (" + query + ") q1 order by highlight_id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    xDescripcion = dr1["descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
            return xDescripcion.Replace("\n", "<br />");
        }

        protected string loadUpdates(string xMetric)
        {
            string xDescripcion = "";
            try
            {
                //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                string query = "SELECT TOP 1 * FROM tbl_metricsUpdates WHERE reportName = '" + xMetric + "'";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(query);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    string[] dates = dr1["lastUpdateText"].ToString().Split(' ');
                    xDescripcion = dates[2] + "/2021";
                    //xDescripcion = dr1["lastUpdateDate"].ToString();
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }

            return xDescripcion;
        }

        protected string[] loadMonthly(string xMetric)
        {
            string[] xValores = { "0", "0" };
            try
            {
                int iVSM = ASPxComboBoxVF.SelectedIndex;
                string sVSM = ASPxComboBoxVF.SelectedItem.ToString();
                string query = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '" + xMetric + "' and sfilter = 'site' and stype = 'monthly' order by id desc";
                string qry = "select * from (" + query + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    xValores[0] = dr1["factual"].ToString();
                    xValores[1] = dr1["fgoal"].ToString();
                }

                if (iVSM > 6 || xMetric == "AGED WIP" || xMetric == "ESCAPES" || xMetric == "INCIDENTS" || xMetric == "INTERNAL ESCAPES" || xMetric == "LABOR PRODUCTIVITY" || xMetric == "OTTR" || xMetric == "PASTDUE" || xMetric == "PPMS" || xMetric == "SCRAP" || xMetric == "UTILIZATION")
                {
                    string query2 = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '" + xMetric + "' and sfilter = 'VSM' and stype = 'monthly' and sclass = '" + sVSM + "' order by id desc";
                    string qry2 = "select * from (" + query2 + ") q1 order by id";
                    SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                    DataTable dt2 = dBHelper.QryManager(qry2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        xValores[0] = dr2["factual"].ToString();
                        xValores[1] = dr2["fgoal"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }

            return xValores;
        }

        protected string[] loadYearly(string xMetric)
        {
            string[] xValores = { "0", "0" };
            try
            {
                //int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                int iVSM = ASPxComboBoxVF.SelectedIndex;
                string sVSM = ASPxComboBoxVF.SelectedItem.ToString();
                string query = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '" + xMetric + "' and sfilter = 'site' and stype = 'yearly' order by id desc";
                string qry = "select * from (" + query + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    xValores[0] = dr1["factual"].ToString();
                    xValores[1] = dr1["fgoal"].ToString();
                }

                if (iVSM > 6)
                {
                    string query2 = "SELECT top 1 * FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where smetric = '" + xMetric + "' and sfilter = 'VSM' and stype = 'yearly' and sclass = '" + sVSM + "' order by id desc";
                    string qry2 = "select * from (" + query2 + ") q1 order by id";
                    SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                    DataTable dt2 = dBHelper.QryManager(qry2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        xValores[0] = dr2["factual"].ToString();
                        xValores[1] = dr2["fgoal"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }

            return xValores;
        }

        protected int regresaIconType(string xMetric)
        {
            int xTipo = 1;
            try
            {
                string qry = "select sIconType from tbl_settings where stype = 'dashboard' and svalue = '" + xMetric + "'";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    xTipo = Convert.ToInt32(dr1["sIconType"].ToString());
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
            return xTipo;
        }

        protected int regresValueType(string xMetric)
        {
            int xTipo = 1;
            try
            {
                string qry = "select sValueType from tbl_settings where stype = 'dashboard' and svalue = '" + xMetric + "'";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    xTipo = Convert.ToInt32(dr1["sValueType"].ToString());
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Dashboard.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
            return xTipo;
        }
    }
}