using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class YTD : Page
    {
        decimal xValor = -1;
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
            if (ASPxComboBoxVF.SelectedIndex == 0)
            {
                ASPxLabel2.Visible = false;
                ASPxComboBoxTV.Visible = false;
            }
            else
            {
                ASPxLabel2.Visible = true;
                ASPxComboBoxTV.Visible = true;
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
            if (ASPxComboBoxTV.SelectedIndex == 1)
            {
                ASPxGridView1.DataSourceID = "SqlDataSource2";
                ASPxGridView1.AutoGenerateColumns = false;
                ASPxGridView1.DataBind();
            }
            if (ASPxComboBoxTV.SelectedIndex == 2)
            {
                ASPxGridView1.DataSourceID = "SqlDataSource3";
                ASPxGridView1.AutoGenerateColumns = false;
                ASPxGridView1.DataBind();
            }
            if (ASPxComboBoxTV.SelectedIndex == 3)
            {
                ASPxGridView1.DataSourceID = "SqlDataSource4";
                ASPxGridView1.AutoGenerateColumns = false;
                ASPxGridView1.DataBind();
            }
            if (ASPxComboBoxTV.SelectedIndex == 4)
            {
                ASPxGridView1.DataSourceID = "SqlDataSource5";
                ASPxGridView1.AutoGenerateColumns = false;
                ASPxGridView1.DataBind();
            }
        }

        protected void cmbox_DataBoundVF(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxVF.Items.Insert(0, defaultItem);
            ASPxComboBoxVF.SelectedIndex = 0;
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            string xMetric = Convert.ToString(e.GetValue("metric")); 
            string xType = Convert.ToString(e.GetValue("metric2"));
            int xStyle = Convert.ToInt32(e.GetValue("style"));
            
            int xComp = 0;

            string[] xValores = valoresX(e);;
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

            //para comparar PLAN vs ACTUAL
            if(xValor == -1)
            {
                xValor = v13;
            }
            else
            {
                if(v13 < xValor)
                {
                    xComp = 1;
                }
                else
                {
                    xComp = 2;
                }
                xValor = -1;
            }
            

            int index = 0;
            if (xType.Equals("ACTUAL"))
            {
                index = 1;
            }

            e.Row.Cells[2 - index].Text = String.Format("{0:N0}", v1);
            e.Row.Cells[3 - index].Text = String.Format("{0:N0}", v2);
            e.Row.Cells[4 - index].Text = String.Format("{0:N0}", v3);
            e.Row.Cells[5 - index].Text = String.Format("{0:N0}", v4);
            e.Row.Cells[6 - index].Text = String.Format("{0:N0}", v5);
            e.Row.Cells[7 - index].Text = String.Format("{0:N0}", v6);
            e.Row.Cells[8 - index].Text = String.Format("{0:N0}", v7);
            e.Row.Cells[9 - index].Text = String.Format("{0:N0}", v8);
            e.Row.Cells[10 - index].Text = String.Format("{0:N0}", v9);
            e.Row.Cells[11 - index].Text = String.Format("{0:N0}", v10);
            e.Row.Cells[12 - index].Text = String.Format("{0:N0}", v11);
            e.Row.Cells[13 - index].Text = String.Format("{0:N0}", v12);
            e.Row.Cells[14 - index].Text = String.Format("{0:N0}", v13);
            if (xMetric == "INVENTORY" || xMetric == "ENTITLEMENT" || xMetric == "PASTDUE" || xMetric == "VMI")
            {
                e.Row.Cells[2 - index].Text = String.Format("{0:C2}", v1 / 1000000) + "M";
                e.Row.Cells[3 - index].Text = String.Format("{0:C2}", v2 / 1000000) + "M";
                e.Row.Cells[4 - index].Text = String.Format("{0:C2}", v3 / 1000000) + "M";
                e.Row.Cells[5 - index].Text = String.Format("{0:C2}", v4 / 1000000) + "M";
                e.Row.Cells[6 - index].Text = String.Format("{0:C2}", v5 / 1000000) + "M";
                e.Row.Cells[7 - index].Text = String.Format("{0:C2}", v6 / 1000000) + "M";
                e.Row.Cells[8 - index].Text = String.Format("{0:C2}", v7 / 1000000) + "M";
                e.Row.Cells[9 - index].Text = String.Format("{0:C2}", v8 / 1000000) + "M";
                e.Row.Cells[10 - index].Text = String.Format("{0:C2}", v9 / 1000000) + "M";
                e.Row.Cells[11 - index].Text = String.Format("{0:C2}", v10 / 1000000) + "M";
                e.Row.Cells[12 - index].Text = String.Format("{0:C2}", v11 / 1000000) + "M";
                e.Row.Cells[13 - index].Text = String.Format("{0:C2}", v12 / 1000000) + "M";
                e.Row.Cells[14 - index].Text = String.Format("{0:C2}", v13 / 1000000) + "M";
            }
            if (xMetric == "OTTR" || xMetric == "UTILIZATION" || xMetric == "PRODUCTIVITY")
            {
                e.Row.Cells[2 - index].Text = String.Format("{0:N2}", v1) + "%";
                e.Row.Cells[3 - index].Text = String.Format("{0:N2}", v2) + "%";
                e.Row.Cells[4 - index].Text = String.Format("{0:N2}", v3) + "%";
                e.Row.Cells[5 - index].Text = String.Format("{0:N2}", v4) + "%";
                e.Row.Cells[6 - index].Text = String.Format("{0:N2}", v5) + "%";
                e.Row.Cells[7 - index].Text = String.Format("{0:N2}", v6) + "%";
                e.Row.Cells[8 - index].Text = String.Format("{0:N2}", v7) + "%";
                e.Row.Cells[9 - index].Text = String.Format("{0:N2}", v8) + "%";
                e.Row.Cells[10 - index].Text = String.Format("{0:N2}", v9) + "%";
                e.Row.Cells[11 - index].Text = String.Format("{0:N2}", v10) + "%";
                e.Row.Cells[12 - index].Text = String.Format("{0:N2}", v11) + "%";
                e.Row.Cells[13 - index].Text = String.Format("{0:N2}", v12) + "%";
                e.Row.Cells[14 - index].Text = String.Format("{0:N2}", v13) + "%";
            }

            if (xStyle == 1)
            {
                e.Row.BackColor = Color.WhiteSmoke;
            }

            //KAIZENS PRODUCTIVITY  OTTR OUTPUT
            if (xMetric == "DEFECTS" || xMetric == "ENTITLEMENT" || xMetric == "ESCAPES" || xMetric == "INCIDENTS" || xMetric == "INVENTORY" || xMetric == "MEPS" || xMetric == "MST" || xMetric == "PASTDUE" || xMetric == "PPMS" || xMetric == "TPMS")
            {
                if (xComp == 1)
                {
                    e.Row.Cells[2 - index].Style.Add("color", "green");
                    e.Row.Cells[2 - index].Font.Bold = true;
                    //e.Row.Cells[3 - index].Style.Add("color", "green");
                    //e.Row.Cells[3 - index].Font.Bold = true;
                    //e.Row.Cells[4 - index].Style.Add("color", "green");
                    //e.Row.Cells[4 - index].Font.Bold = true;
                    //e.Row.Cells[5 - index].Style.Add("color", "green");
                    //e.Row.Cells[5 - index].Font.Bold = true;
                    //e.Row.Cells[6 - index].Style.Add("color", "green");
                    //e.Row.Cells[6 - index].Font.Bold = true;
                    //e.Row.Cells[7 - index].Style.Add("color", "green");
                    //e.Row.Cells[7 - index].Font.Bold = true;
                    //e.Row.Cells[8 - index].Style.Add("color", "green");
                    //e.Row.Cells[8 - index].Font.Bold = true;
                    //e.Row.Cells[9 - index].Style.Add("color", "green");
                    //e.Row.Cells[9 - index].Font.Bold = true;
                    //e.Row.Cells[10 - index].Style.Add("color", "green");
                    //e.Row.Cells[10 - index].Font.Bold = true;
                    //e.Row.Cells[11 - index].Style.Add("color", "green");
                    //e.Row.Cells[11 - index].Font.Bold = true;
                    //e.Row.Cells[12 - index].Style.Add("color", "green");
                    //e.Row.Cells[12 - index].Font.Bold = true;
                    //e.Row.Cells[13 - index].Style.Add("color", "green");
                    //e.Row.Cells[13 - index].Font.Bold = true;
                    e.Row.Cells[14 - index].Style.Add("color", "green");
                    e.Row.Cells[14 - index].Font.Bold = true;
                }
                if (xComp == 2)
                {
                    e.Row.Cells[2 - index].Style.Add("color", "red");
                    e.Row.Cells[2 - index].Font.Bold = true;
                    //e.Row.Cells[3 - index].Style.Add("color", "red");
                    //e.Row.Cells[3 - index].Font.Bold = true;
                    //e.Row.Cells[4 - index].Style.Add("color", "red");
                    //e.Row.Cells[4 - index].Font.Bold = true;
                    //e.Row.Cells[5 - index].Style.Add("color", "red");
                    //e.Row.Cells[5 - index].Font.Bold = true;
                    //e.Row.Cells[6 - index].Style.Add("color", "red");
                    //e.Row.Cells[6 - index].Font.Bold = true;
                    //e.Row.Cells[7 - index].Style.Add("color", "red");
                    //e.Row.Cells[7 - index].Font.Bold = true;
                    //e.Row.Cells[8 - index].Style.Add("color", "red");
                    //e.Row.Cells[8 - index].Font.Bold = true;
                    //e.Row.Cells[9 - index].Style.Add("color", "red");
                    //e.Row.Cells[9 - index].Font.Bold = true;
                    //e.Row.Cells[10 - index].Style.Add("color", "red");
                    //e.Row.Cells[10 - index].Font.Bold = true;
                    //e.Row.Cells[11 - index].Style.Add("color", "red");
                    //e.Row.Cells[11 - index].Font.Bold = true;
                    //e.Row.Cells[12 - index].Style.Add("color", "red");
                    //e.Row.Cells[12 - index].Font.Bold = true;
                    //e.Row.Cells[13 - index].Style.Add("color", "red");
                    //e.Row.Cells[13 - index].Font.Bold = true;
                    e.Row.Cells[14 - index].Style.Add("color", "red");
                    e.Row.Cells[14 - index].Font.Bold = true;
                }
            }
            //KAIZENS PRODUCTIVITY  OTTR OUTPUT
            if (xMetric == "KAIZENS" || xMetric == "PRODUCTIVITY" || xMetric == "OTTR" || xMetric == "OUTPUT")
            {
                if (xComp == 1)
                {
                    e.Row.Cells[2 - index].Style.Add("color", "red");
                    e.Row.Cells[2 - index].Font.Bold = true;
                    //e.Row.Cells[3 - index].Style.Add("color", "red");
                    //e.Row.Cells[3 - index].Font.Bold = true;
                    //e.Row.Cells[4 - index].Style.Add("color", "red");
                    //e.Row.Cells[4 - index].Font.Bold = true;
                    //e.Row.Cells[5 - index].Style.Add("color", "red");
                    //e.Row.Cells[5 - index].Font.Bold = true;
                    //e.Row.Cells[6 - index].Style.Add("color", "red");
                    //e.Row.Cells[6 - index].Font.Bold = true;
                    //e.Row.Cells[7 - index].Style.Add("color", "red");
                    //e.Row.Cells[7 - index].Font.Bold = true;
                    //e.Row.Cells[8 - index].Style.Add("color", "red");
                    //e.Row.Cells[8 - index].Font.Bold = true;
                    //e.Row.Cells[9 - index].Style.Add("color", "red");
                    //e.Row.Cells[9 - index].Font.Bold = true;
                    //e.Row.Cells[10 - index].Style.Add("color", "red");
                    //e.Row.Cells[10 - index].Font.Bold = true;
                    //e.Row.Cells[11 - index].Style.Add("color", "red");
                    //e.Row.Cells[11 - index].Font.Bold = true;
                    //e.Row.Cells[12 - index].Style.Add("color", "red");
                    //e.Row.Cells[12 - index].Font.Bold = true;
                    //e.Row.Cells[13 - index].Style.Add("color", "red");
                    //e.Row.Cells[13 - index].Font.Bold = true;
                    e.Row.Cells[14 - index].Style.Add("color", "red");
                    e.Row.Cells[14 - index].Font.Bold = true;
                }
                if (xComp == 2)
                {
                    e.Row.Cells[2 - index].Style.Add("color", "green");
                    e.Row.Cells[2 - index].Font.Bold = true;
                    //e.Row.Cells[3 - index].Style.Add("color", "green");
                    //e.Row.Cells[3 - index].Font.Bold = true;
                    //e.Row.Cells[4 - index].Style.Add("color", "green");
                    //e.Row.Cells[4 - index].Font.Bold = true;
                    //e.Row.Cells[5 - index].Style.Add("color", "green");
                    //e.Row.Cells[5 - index].Font.Bold = true;
                    //e.Row.Cells[6 - index].Style.Add("color", "green");
                    //e.Row.Cells[6 - index].Font.Bold = true;
                    //e.Row.Cells[7 - index].Style.Add("color", "green");
                    //e.Row.Cells[7 - index].Font.Bold = true;
                    //e.Row.Cells[8 - index].Style.Add("color", "green");
                    //e.Row.Cells[8 - index].Font.Bold = true;
                    //e.Row.Cells[9 - index].Style.Add("color", "green");
                    //e.Row.Cells[9 - index].Font.Bold = true;
                    //e.Row.Cells[10 - index].Style.Add("color", "green");
                    //e.Row.Cells[10 - index].Font.Bold = true;
                    //e.Row.Cells[11 - index].Style.Add("color", "green");
                    //e.Row.Cells[11 - index].Font.Bold = true;
                    //e.Row.Cells[12 - index].Style.Add("color", "green");
                    //e.Row.Cells[12 - index].Font.Bold = true;
                    //e.Row.Cells[13 - index].Style.Add("color", "green");
                    //e.Row.Cells[13 - index].Font.Bold = true;
                    e.Row.Cells[14 - index].Style.Add("color", "green");
                    e.Row.Cells[14 - index].Font.Bold = true;
                }
            }
        }

        private string[] valoresX(ASPxGridViewTableRowEventArgs e)
        {
            string[] xValores = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"};
            xValores[0] = Convert.ToString(e.GetValue("mjan"));
            xValores[1] = Convert.ToString(e.GetValue("mfeb"));
            xValores[2] = Convert.ToString(e.GetValue("mmar"));
            xValores[3] = Convert.ToString(e.GetValue("mapr"));
            xValores[4] = Convert.ToString(e.GetValue("mmay"));
            xValores[5] = Convert.ToString(e.GetValue("mjun"));
            xValores[6] = Convert.ToString(e.GetValue("mjul"));
            xValores[7] = Convert.ToString(e.GetValue("maug"));
            xValores[8] = Convert.ToString(e.GetValue("msep"));
            xValores[9] = Convert.ToString(e.GetValue("moct"));
            xValores[10] = Convert.ToString(e.GetValue("mnov"));
            xValores[11] = Convert.ToString(e.GetValue("mdec"));
            xValores[12] = Convert.ToString(e.GetValue("ytd"));
            return xValores;
        }


    }
}