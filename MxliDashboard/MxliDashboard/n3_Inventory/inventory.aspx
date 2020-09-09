<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="MxliDashboard.n3_Inventory.inventory" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>
<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p></p>
    <h3>Inventory cost.</h3>
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server">
                <table style="table-layout: fixed">
                    <tr>
                        <th>
                            <dx:ASPxLabel ID="ASPxLabelCaption2" runat="server" Text="Select VSM">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="svsm"
                                TextField="svsm" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm">
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
                            <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select MRP">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxMrpInContent" runat="server" ValueField="smrp"
                                TextField="smrp" ValueType="System.String" DataSourceID="SqlDataSourceMrp"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundMrp">
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One MRP&quot;;
                                            }}" />
                                <ValidationSettings ValidateOnLeave="False">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </th>
                        <th>
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Cell">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueField="scell"
                                TextField="scell" ValueType="System.String" DataSourceID="SqlDataSourceCell"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundCell">
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One MRP&quot;;
                                            }}" />
                                <ValidationSettings ValidateOnLeave="False">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </th>
                        <th>
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Select PFEP">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" ValueField="spfep"
                                TextField="spfep" ValueType="System.String" DataSourceID="SqlDataSourcePfep"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundPfep">
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One MRP&quot;;
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
    <p>    </p>
    <dx:WebChartControl ID="WebChartControl1" runat="server" DataSourceID = "SqlDataSource1" CrosshairEnabled="True" Height="200px" Width="1024px" 
ClientInstanceName="chart" AutoLayout="True">
        <DiagramSerializable>
            <dx:XYDiagram>
                <axisx visibleinpanesserializable="-1" MinorCount="1">
                    <QualitativeScaleOptions AutoGrid="False" />
                    <Label Angle="270" Alignment="Center">
                        <ResolveOverlappingOptions AllowHide="False" />
                    </Label>
                </axisx>
                <axisy visibleinpanesserializable="-1">
                </axisy>
            </dx:XYDiagram>
        </DiagramSerializable>
<Legend Name="Default Legend"></Legend>
        <SeriesSerializable>
            <dx:Series Name="Total" LabelsVisibility="True" ArgumentDataMember="sDay" ValueDataMembersSerializable="fTotal" CrosshairLabelPattern="{V:c2}">
                <ViewSerializable>
                    <dx:SideBySideBarSeriesView>
                        <Border Color="49, 133, 155" />
                    </dx:SideBySideBarSeriesView>
                </ViewSerializable>
                <LabelSerializable>
                    <dx:SideBySideBarSeriesLabel TextPattern="{V:c2}">
                    </dx:SideBySideBarSeriesLabel>
                </LabelSerializable>
            </dx:Series>
            <dx:Series LabelsVisibility="False" Name="Goal" ArgumentDataMember="sDay" ValueDataMembersSerializable="fGoal" CrosshairLabelPattern="{V:C2}">
                <ViewSerializable>
                    <dx:LineSeriesView Color="IndianRed">
                    </dx:LineSeriesView>
                </ViewSerializable>
            </dx:Series>
        </SeriesSerializable>
    </dx:WebChartControl>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ" SelectCommand="SELECT sDay, fTotal, fGoal FROM cht_inventario WHERE sFilter = 'All'">
    <SelectParameters>
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxMrpInContent"
                Name="pMrp" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                Name="pVsm" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p></p>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ds_inventory" Theme="Office2010Silver" Width="100%" EnableTheming="True" OnCustomUnboundColumnData="grid_CustomUnboundColumnData">
        <SettingsPager Mode="ShowPager" PageSize="20">
        </SettingsPager>
        <Settings ShowFooter="True" ShowGroupPanel="True" />
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
            <dx:GridViewDataTextColumn FieldName="sMaterial" VisibleIndex="0" Caption="Material">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="totQty" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" VisibleIndex="3">
                <PropertiesTextEdit DisplayFormatString="C2">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sVsm" VisibleIndex="4" Caption="VSM">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sCell" VisibleIndex="5" Caption="CELL">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sMrp" VisibleIndex="6" Caption="MRP">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sMakeBuy" VisibleIndex="7" Caption="MakeBuy">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sPfep" VisibleIndex="8" Caption="PFEP" UnboundType="Decimal">
                <PropertiesTextEdit DisplayFormatString="c" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="C2" FieldName="Total" ShowInColumn="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" />
        </TotalSummary>
        <GroupSummary>
            <dx:ASPxSummaryItem FieldName="Total" SummaryType="Sum" />
        </GroupSummary>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="ds_inventory" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT [sMaterial], [totQty], [Price], [Total], [sVsm], [sCell], [sMrp], [sMakeBuy], [sPfep] FROM [tbl_inventario] where [xDay] = 5 and smrp like @pMrp and svsm like @pVsm">
    <SelectParameters>
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxMrpInContent"
                Name="pMrp" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                Name="pVsm" PropertyName="Value" Type="String" />
        
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMrp" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [smrp] FROM [tbl_inventario] order by smrp"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [svsm] FROM [tbl_inventario] order by svsm"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [scell] FROM [tbl_inventario] order by scell"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePfep" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [spfep] FROM [tbl_inventario] order by spfep"></asp:SqlDataSource>
</asp:Content>
