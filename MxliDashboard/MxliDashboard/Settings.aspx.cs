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
    public partial class Settings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "metricDesc")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("AVERAGE");
                cmb.Items.Add("LATEST");
                cmb.Items.Add("SUM");
            }
            if (e.Column.FieldName == "gUnit")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("PERCENT");
                cmb.Items.Add("QUANTITY");
                cmb.Items.Add("VALUE");
            }
        }


    }
}