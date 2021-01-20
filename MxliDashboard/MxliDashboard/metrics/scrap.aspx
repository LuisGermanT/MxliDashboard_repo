﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="scrap.aspx.cs" Inherits="MxliDashboard.n3_Inventory.scrap" %>

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
            <asp:Label ID="lbLUpd" runat="server" Text="labelUpdate"></asp:Label>
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
                                    <dx:ASPxLabel ID="ASPxLabelCaption4" runat="server" Text="Select VSM"></dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxGroupInContent" runat="server" ValueField="VSM"
                                        TextField="VSM" ValueType="System.String" DataSourceID="SqlDataSourceGroup"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundGroup" OnSelectedIndexChanged="ASPxComboBoxGroupInContent_SelectedIndexChanged" Theme="Office365">
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
                                    <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select Area"></dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="Area"
                                        TextField="Area" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged" Theme="Office365">
                                        <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One Area&quot;;
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
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundCell" OnSelectedIndexChanged="ASPxComboBoxCellInContent_SelectedIndexChanged" Theme="Office365">
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
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundFilters" OnSelectedIndexChanged="ASPxComboBoxFiltersInContent_SelectedIndexChanged" Theme="Office365">
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
                        <dx:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="" CrosshairEnabled="True" Height="200px" Width="1100px"
                            ClientInstanceName="chart" AutoLayout="True">
                            <DiagramSerializable>
                                <dx:XYDiagram>
                                    <AxisX VisibleInPanesSerializable="-1" MinorCount="1" Visibility="True">
                                        <QualitativeScaleOptions AutoGrid="False" />
                                        <Tickmarks MinorVisible="False" />
                                        <Label Angle="270" Alignment="Center">
                                            <ResolveOverlappingOptions AllowHide="False" />
                                        </Label>
                                        <NumericScaleOptions AutoGrid="False" ScaleMode="Automatic" />
                                    </AxisX>
                                    <AxisY VisibleInPanesSerializable="-1">
                                        <Label TextPattern="{V:$#,##0.##}">
                                        </Label>
                                        <CrosshairAxisLabelOptions Pattern="{V:c2}" />
                                    </AxisY>
                                    <SecondaryAxesY>
                                        <dx:SecondaryAxisY AxisID="0" Name="Secondary AxisY 1" VisibleInPanesSerializable="-1" Visibility="False">
                                            <Label TextPattern="{V:c2}">
                                            </Label>
                                            <NumericScaleOptions AutoGrid="False" GridSpacing="0.5" />
                                        </dx:SecondaryAxisY>
                                    </SecondaryAxesY>
                                </dx:XYDiagram>
                            </DiagramSerializable>
                            <Legend Name="Default Legend" Font="Honeywell Sans Web Medium, 8pt"></Legend>
                            <SeriesSerializable>
                                <dx:Series LabelsVisibility="True" Name="$ Total Scrap" CrosshairLabelPattern="{V:c2}" LegendTextPattern="{V:c2}" >
                                    <ViewSerializable>
                                        <dx:SideBySideBarSeriesView Color="55, 96, 146" BarWidth="0.8">
                                            <Border Color="79, 129, 189" Visibility="False" />
                                            <FillStyle FillMode="Solid">
                                            </FillStyle>
                                        </dx:SideBySideBarSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:SideBySideBarSeriesLabel TextPattern="{V:c2}">
                                        </dx:SideBySideBarSeriesLabel>
                                    </LabelSerializable>
                                </dx:Series>
                                <dx:Series Name="Goal" CrosshairLabelPattern="{V:c2}" LegendTextPattern="{V:c2}" >
                                    <ViewSerializable>
                                        <dx:LineSeriesView AxisYName="Secondary AxisY 1" Color="192, 80, 77" MarkerVisibility="False">
                                        </dx:LineSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:PointSeriesLabel TextPattern="{V:c2}">
                                        </dx:PointSeriesLabel>
                                    </LabelSerializable>
                                </dx:Series>
                            </SeriesSerializable>
                        </dx:WebChartControl>
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
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ds_prod" Theme="Metropolis" Width="1024px">
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
                                <dx:GridViewDataTextColumn FieldName="AccName" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AccConcept" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="2" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Qty" VisibleIndex="3" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VSM" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cell" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MRP" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Material" VisibleIndex="8" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Ordr" VisibleIndex="9" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Text" VisibleIndex="10" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Defect" VisibleIndex="11" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EID" VisibleIndex="12" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="PstDate" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Week" VisibleIndex="14">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MntNum" VisibleIndex="15">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MntName" VisibleIndex="16">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="17">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <GroupSummary>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Defect"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="AccName"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="AccConcept"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="VSM"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Area"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Cell"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="MRP"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Material"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="EID"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="PstDate"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Week"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="MntNum"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="MntName"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total $: {0:c}" FieldName="Amount" ShowInColumn="Year"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Defect" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="AccName" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="AccConcept" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="VSM" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Area" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Cell" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MRP" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Material" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="EID" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="PstDate" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Week" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MntNum" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MntName" SummaryType="Sum" />
                                <dx:ASPxSummaryItem DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Year" SummaryType="Sum" />
                            </GroupSummary>
                            <GroupSummary>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Defect"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="AccName"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="AccConcept"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="VSM"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Area"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Cell"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MRP"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Material"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="EID"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="PstDate"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Week"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MntNum"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="MntName"></dx:ASPxSummaryItem>
                                <dx:ASPxSummaryItem SummaryType="Sum" DisplayFormat="Total Qty: {0:n2}" FieldName="Qty" ShowInColumn="Year"></dx:ASPxSummaryItem>
                            </GroupSummary>
                            <Styles>
                                <Header BackColor="IndianRed" ForeColor="White">
                                </Header>
                            </Styles>
                        </dx:ASPxGridView>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>


            <asp:SqlDataSource ID="ds_prod" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT AccName, AccConcept, Amount, Qty, VSM, Area, Cell, MRP, Material, Ordr, Text, Defect, EID, PstDate, Week, MntNum, MntName, Year 
                                FROM vw_scrap_gridview WHERE (Cell LIKE @pCell) AND (Area LIKE @pVsm) AND (VSM LIKE @pGroup) ORDER BY Year desc, Week desc, Area, Cell" ProviderName="System.Data.SqlClient">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxCellInContent"
                        Name="pCell" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                        Name="pVsm" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxGroupInContent"
                        Name="pGroup" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [Cell] FROM [vw_scrap_gridview] order by Cell"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [Area] FROM [vw_scrap_gridview] order by Area"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceGroup" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [VSM] FROM [vw_scrap_gridview] order by VSM"></asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSourceFilters" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT TOP 2 * FROM [tblFilters]"></asp:SqlDataSource>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>