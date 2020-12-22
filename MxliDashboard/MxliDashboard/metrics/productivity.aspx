<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productivity.aspx.cs" Inherits="MxliDashboard.n3_Productivity.productivity" %>

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
                        <table style="table-layout: fixed">
                            <tr>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select VSM">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="NP_Area"
                                        TextField="NP_Area" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
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
                                    <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="NP_Celda"
                                        TextField="NP_Celda" ValueType="System.String" DataSourceID="SqlDataSourceCell"
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
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series3" Color="Black" MarkerStyle="Circle" BorderWidth="2" MarkerBorderColor="Black" MarkerBorderWidth="2" MarkerColor="White" MarkerSize="10" YAxisType="Secondary" IsValueShownAsLabel="True" LabelFormat="{0:0.0%}">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series4" Color="IndianRed" BorderWidth="2" MarkerSize="1" YAxisType="Secondary" LabelFormat="{0:0.0%}">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                        <LabelStyle Format="{0:0.00%}" />
                                    </AxisY2>
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
                                <dx:GridViewDataTextColumn FieldName="NP_CentroCostos" VisibleIndex="0" Caption="Cost Center">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Area" VisibleIndex="1" Caption="VSM">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Celda" VisibleIndex="2" Caption="Cell">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_TotalHrs" VisibleIndex="3" Caption="Total Hrs">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Qty" VisibleIndex="4" Caption="Units">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_EarnedHrs" VisibleIndex="5" Caption="Earned Hrs">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Productivity" VisibleIndex="6" Caption="% Productivity">
                                    <PropertiesTextEdit DisplayFormatString="{0:n2}%">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Week" VisibleIndex="7" Caption="Wk">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Month" VisibleIndex="8" Caption="Month">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NP_Year" VisibleIndex="9" Caption="Yr">
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
                SelectCommand="SELECT [NP_CentroCostos], [NP_Area], [NP_Celda], [NP_TotalHrs], [NP_Qty], [NP_EarnedHrs], [NP_Productivity], [NP_Week], [NP_Month], [NP_Year] FROM [tblLaborProductivity]
                                  WHERE [NP_Celda] LIKE @pCell AND [NP_Area] LIKE @pVsm 
                                    ORDER BY
                                            CASE 
				                                WHEN NP_Month = 'Jan' THEN 1
				                                WHEN NP_Month = 'Feb' THEN 2
				                                WHEN NP_Month = 'Mar' THEN 3
				                                WHEN NP_Month = 'Apr' THEN 4
				                                WHEN NP_Month = 'May' THEN 5
				                                WHEN NP_Month = 'Jun' THEN 6
				                                WHEN NP_Month = 'Jul' THEN 7
				                                WHEN NP_Month = 'Aug' THEN 8
				                                WHEN NP_Month = 'Sep' THEN 9
				                                WHEN NP_Month = 'Oct' THEN 10
				                                WHEN NP_Month = 'Nov' THEN 11
				                                WHEN NP_Month = 'Dec' THEN 12
			                                END desc, NP_Week desc, NP_Year, NP_Area, NP_Celda
                ">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxCellInContent"
                        Name="pCell" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                        Name="pVsm" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [NP_Celda] FROM [tblLaborProductivity] order by NP_Celda"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [NP_Area] FROM [tblLaborProductivity] order by NP_Area"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceFilters" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT TOP 2 * FROM [tblFilters]"></asp:SqlDataSource>
            <p/>
            <hr/>
            <p/>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>