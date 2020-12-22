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
    public partial class set_highlights : System.Web.UI.Page
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
            METRIC_HIGHLIGHTS.Visible= true;
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "smes")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("JAN");
                cmb.Items.Add("FEB");
                cmb.Items.Add("MAR");
                cmb.Items.Add("APR");
                cmb.Items.Add("MAY");
                cmb.Items.Add("JUN");
                cmb.Items.Add("JUL");
                cmb.Items.Add("AUG");
                cmb.Items.Add("SEP");
                cmb.Items.Add("OCT");
                cmb.Items.Add("NOV");
                cmb.Items.Add("DEC");
            }
        }


    }
}