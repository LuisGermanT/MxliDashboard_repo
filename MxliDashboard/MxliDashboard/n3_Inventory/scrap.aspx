<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="scrap.aspx.cs" Inherits="MxliDashboard.n3_Inventory.scrap" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>
<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <p />
            <hr />
            <p />

            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views and Filters" ForeColor="Black" AllowCollapsingByHeaderClick="true">
                <HeaderStyle ForeColor="White" />
                <HeaderContent BackColor="#666666">
                </HeaderContent>
                <PanelCollection>

                    <dx:PanelContent ID="PanelContent1" runat="server">
                        
                        <table style="table-layout:fixed">
                            <tr>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select VSM"></dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="Area"
                                        TextField="Area" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged">
                                        <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One VSM&quot;;
                                                    }}" />
                                        <ValidationSettings ValidateOnLeave="False">
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </th>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption2" runat="server" Text="Select Cell:">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="Cell"
                                        TextField="Cell" ValueType="System.String" DataSourceID="SqlDataSourceCell"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundCell" OnSelectedIndexChanged="ASPxComboBoxCellInContent_SelectedIndexChanged">
                                        <ClientSideEvents Validation="function(s, e) {
                                                if (s.GetSelectedIndex()==0) {
                                                e.isValid = false;
                                                e.errorText = &quot;You should Select One Cell&quot;;
                                                }}" />
                                        <ValidationSettings ValidateOnLeave="False">
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </th>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption3" runat="server" Text="View By Month/Week">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxMWInContent" runat="server" ValueField="TF_ID"
                                        TextField="TF_Name" ValueType="System.String" DataSourceID="SqlDataSourceFilters"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundFilters" OnSelectedIndexChanged="ASPxComboBoxFiltersInContent_SelectedIndexChanged">
                                        <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One Option&quot;;
                                                    }}" />
                                        <ValidationSettings ValidateOnLeave="False">
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </th>
                            </tr>
                        </table>

                    </dx:PanelContent>

                </PanelCollection>

            </dx:ASPxRoundPanel>

            <p />
            <hr />
            <p />

            <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Data chart" ForeColor="Black" AllowCollapsingByHeaderClick="true">
                <HeaderStyle ForeColor="White"/>
                <HeaderContent BackColor="#666666"/>
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent2" runat="server">
                        <asp:Chart ID="chartTP01" runat="server" Width="1024px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="55, 96, 146" IsValueShownAsLabel="True" LabelFormat="{0:#,#}">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series2" Color="185, 205, 229" IsValueShownAsLabel="True" LabelFormat="{0:#,#}">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="true" LineWidth="0">
                                        <MajorGrid Enabled="true" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>

            
            <p/>
            <hr/>
            <p/>

            <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Source data" ForeColor="Black" AllowCollapsingByHeaderClick="true">
                <HeaderStyle ForeColor="White" />
                <HeaderContent BackColor="#666666"/>
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent3" runat="server">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ds_prod" Theme="Default" Width="1024px">
                            <SettingsPager Mode="ShowPager" PageSize="20">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            <SettingsSearchPanel Visible="True" />
                            <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />
                            <Toolbars>
                                <dx:GridViewToolbar>
                                    <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
                                    <Items>
                                        <dx:GridViewToolbarItem Command="ExportToPdf" />
                                        <dx:GridViewToolbarItem Command="ExportToXlsx" />
                                        <dx:GridViewToolbarItem Command="ExportToCsv" />
                                        <dx:GridViewToolbarItem Command="ExportToDocx" />                    
                                    </Items>
                                </dx:GridViewToolbar>
                            </Toolbars>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="AccName" VisibleIndex="0" Caption="Account">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AccConcept" VisibleIndex="1" Caption="Concept">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="2" Caption="Amount">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Qty" VisibleIndex="3" Caption="Qty">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="4" Caption="Area">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cell" VisibleIndex="5" Caption="Cell">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MRP" VisibleIndex="6" Caption="MRP">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Material" VisibleIndex="7" Caption="Material">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Ordr" VisibleIndex="8" Caption="Order">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Text" VisibleIndex="9" Caption="QN">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Defect" VisibleIndex="10" Caption="Defect">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EID" VisibleIndex="11" Caption="EID">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PstDate" VisibleIndex="12" Caption="Posting Date">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Week" VisibleIndex="13" Caption="Wk">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MntNum" VisibleIndex="14" Caption="#Month">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MntName" VisibleIndex="15" Caption="Month">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="16" Caption="Yr">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <Header BackColor="IndianRed" ForeColor="White">
                                </Header>
                            </Styles>
                        </dx:ASPxGridView>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>


            <asp:SqlDataSource ID="ds_prod" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT * FROM [vw_scrap_gridview]
                                  WHERE [Cell] LIKE @pCell AND [Area] LIKE @pVsm 
                                    ORDER BY [PstDate],[Area],[Cell]
                ">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxCellInContent"
                        Name="pCell" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                        Name="pVsm" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [Cell] FROM [vw_scrap_gridview] order by Cell"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [Area] FROM [vw_scrap_gridview] order by Area"></asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSourceFilters" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT TOP 2 * FROM [tblFilters]"></asp:SqlDataSource>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>