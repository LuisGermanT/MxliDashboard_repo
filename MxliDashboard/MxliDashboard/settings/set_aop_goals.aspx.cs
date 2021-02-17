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
    public partial class set_aop_goals : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
        }

        protected void cmbox_DataBoundF1(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("Select one", "%%");
            ASPxComboBoxF1.Items.Insert(0, defaultItem);
            ASPxComboBoxF1.SelectedIndex = 0;
        }

        protected void ASPxComboBoxF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            METRIC_GOALS.Visible = true;
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "x")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("SITE");
                cmb.Items.Add("VSM");
                cmb.Items.Add("CELL");
                cmb.Items.Add("MRP");
            }
            if (e.Column.FieldName == "y")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("AVERAGE");
                cmb.Items.Add("LATEST");
                cmb.Items.Add("SUM");
            }
            if (e.Column.FieldName == "z")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("PERCENT");
                cmb.Items.Add("QUANTITY");
                cmb.Items.Add("VALUE");
            }
            if (e.Column.FieldName == "xyz")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("2020");
                cmb.Items.Add("2021");
                cmb.Items.Add("2022");
                cmb.Items.Add("2023");
                cmb.Items.Add("2024");
                cmb.Items.Add("2025");
            }
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            string xMetric = ASPxComboBoxF1.SelectedItem.ToString();
            string[] xValores = valoresX(e); ;
            decimal v1 = Convert.ToDecimal(xValores[0]);
            decimal v2 = Convert.ToDecimal(xValores[1]);
            decimal v3 = Convert.ToDecimal(xValores[2]);
            decimal v4 = Convert.ToDecimal(xValores[3]);
            decimal v5 = Convert.ToDecimal(xValores[4]);
            decimal v6 = Convert.ToDecimal(xValores[5]);
            decimal v7 = Convert.ToDecimal(xValores[6]);
            decimal v8 = Convert.ToDecimal(xValores[7]);
            decimal v9 = Convert.ToDecimal(xValores[8]);
            decimal v10 = Convert.ToDecimal(xValores[9]);
            decimal v11 = Convert.ToDecimal(xValores[10]);
            decimal v12 = Convert.ToDecimal(xValores[11]);
            decimal v13 = Convert.ToDecimal(xValores[12]);
            decimal v14 = Convert.ToDecimal(xValores[13]);
            if (xMetric == "INVENTORY" || xMetric == "ENTITLEMENT" || xMetric == "PASTDUE" || xMetric == "VMI" || xMetric == "AGED WIP" || xMetric == "SCRAP")
            {
                e.Row.Cells[2].Text = String.Format("{0:C2}", v1);
            }
        }

        private string[] valoresX(ASPxGridViewTableRowEventArgs e)
        {
            string[] xValores = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

            try
            {
                xValores[0] = Convert.ToString(e.GetValue("gPreviousYear"));
                xValores[1] = Convert.ToString(e.GetValue("gM1"));
                xValores[2] = Convert.ToString(e.GetValue("gM2"));
                xValores[3] = Convert.ToString(e.GetValue("gM3"));
                xValores[4] = Convert.ToString(e.GetValue("gM4"));
                xValores[5] = Convert.ToString(e.GetValue("gM5"));
                xValores[6] = Convert.ToString(e.GetValue("gM6"));
                xValores[7] = Convert.ToString(e.GetValue("gM7"));
                xValores[8] = Convert.ToString(e.GetValue("gM8"));
                xValores[9] = Convert.ToString(e.GetValue("gM9"));
                xValores[10] = Convert.ToString(e.GetValue("gM10"));
                xValores[11] = Convert.ToString(e.GetValue("gM11"));
                xValores[12] = Convert.ToString(e.GetValue("gM12"));
                xValores[13] = Convert.ToString(e.GetValue("gActualYear"));                
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
                Server.Transfer("~\\CustomErrors\\Errors.aspx?handler=YTD.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
            return xValores;
        }


    }
}