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
    public partial class YTD : Page
    {
        int contador = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            contador = 0;
            this.ASPxComboBoxVF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVF_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
        }

        protected void ASPxComboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        { }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        { }

        protected void imageStatus_Init(object sender, EventArgs e)
        {
            if (contador < 10) {
                contador++;
            }
            else{
                ASPxImage image = (ASPxImage)sender;
                GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)image.NamingContainer;
                double valueA = double.Parse(ASPxGridView1.DataColumns[1].ToString());
                double valueG = double.Parse(ASPxGridView1.DataColumns[2].ToString());
                if (valueA < valueG)
                    image.ImageUrl = "img/bad.png";
                else
                    image.ImageUrl = "img/good.png";
                contador++;
            }
        }


    }
}