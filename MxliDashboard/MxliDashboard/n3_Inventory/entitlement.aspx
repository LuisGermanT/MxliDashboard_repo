<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="entitlement.aspx.cs" Inherits="MxliDashboard.n3_Inventory.entitlement" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>
<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p></p>
    <h3>WIP Entitlement.</h3>
    <p></p>
        <a class="btn btn-danger" href="../Reports/ReportViewer1.aspx">Print</a>
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" >
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
                            <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="vsm"
                                TextField="vsm" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
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
                            <dx:ASPxComboBox ID="ASPxComboBoxMrpInContent" runat="server" ValueField="mrp"
                                TextField="mrp" ValueType="System.String" DataSourceID="SqlDataSourceMrp"
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
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Status">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxStaInContent" runat="server" ValueField="status"
                                TextField="status" ValueType="System.String" DataSourceID="SqlDataSourceSta"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundSta">
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Status&quot;;
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
    <p></p>
    <hr />
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Data chart" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server">
                <dx:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" CrosshairEnabled="True" Height="200px" Width="1024px"
                    ClientInstanceName="chart" AutoLayout="True">
                    <DiagramSerializable>
                        <dx:XYDiagram>
                            <AxisX VisibleInPanesSerializable="-1" MinorCount="1">
                                <QualitativeScaleOptions AutoGrid="False" />
                                <Label Angle="270" Alignment="Center">
                                    <ResolveOverlappingOptions AllowHide="False" />
                                </Label>
                            </AxisX>
                            <AxisY VisibleInPanesSerializable="-1">
                            </AxisY>
                        </dx:XYDiagram>
                    </DiagramSerializable>
                    <Legend Name="Default Legend"></Legend>
                    <SeriesSerializable>
                        <dx:Series Name="Total" LabelsVisibility="True" ArgumentDataMember="sdesc" ValueDataMembersSerializable="fActual" CrosshairLabelPattern="{V:c2}">
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
                        <dx:Series LabelsVisibility="False" Name="Goal" ArgumentDataMember="sdesc" ValueDataMembersSerializable="fGoal" CrosshairLabelPattern="{V:C2}">
                            <ViewSerializable>
                                <dx:LineSeriesView Color="IndianRed">
                                </dx:LineSeriesView>
                            </ViewSerializable>
                        </dx:Series>
                    </SeriesSerializable>
                </dx:WebChartControl>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ" SelectCommand="SELECT sdesc, fActual, fGoal FROM sta_nivel2 WHERE smetric = 'entitlement' and sFilter = 'SITE' and sclass = 'All' and stype = 'weekly'">
    </asp:SqlDataSource>
    <p></p>
    <hr />
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Source data" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent3" runat="server">
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
                        <dx:GridViewDataTextColumn FieldName="outline" VisibleIndex="0" Caption="Material">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="actual_wip_v" VisibleIndex="1" Caption="WIP">
                            <PropertiesTextEdit DisplayFormatString="C2">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ideal_wip_v" VisibleIndex="2" Caption="IDEAL">
                            <PropertiesTextEdit DisplayFormatString="C2">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Vsm" VisibleIndex="3" Caption="VSM">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Mrp" VisibleIndex="4" Caption="MRP">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="status" VisibleIndex="5" Caption="STATUS">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem DisplayFormat="C2" FieldName="actual_wip_v" ShowInColumn="actual_wip_v" ShowInGroupFooterColumn="actual_wip_v" SummaryType="Sum" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="actual_wip_v" SummaryType="Sum" />
                    </GroupSummary>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>       
    </dx:ASPxRoundPanel>
    <asp:SqlDataSource ID="ds_inventory" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT [outline], [actual_wip_v], [ideal_wip_v], [Vsm], [Mrp], [status] FROM [sap_entitlement] where mrp like @pMrp and vsm like @pVsm and status like @pSta">
    <SelectParameters>
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxMrpInContent"
                Name="pMrp" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                Name="pVsm" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxStaInContent"
                Name="pSta" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMrp" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [mrp] FROM [sap_entitlement] order by mrp"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [vsm] FROM [sap_entitlement] order by vsm"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSta" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [status] FROM [sap_entitlement] order by status"></asp:SqlDataSource>
    <p />
    <hr />
    <p />
    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Actions" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent4" runat="server">
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceActions" KeyFieldName="tbl_actions_id" Width="100%">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                    <Settings ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="#" FieldName="tbl_actions_id" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="area" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="vsm" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mrp" ShowInCustomizationForm="True" Visible="False" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="report" ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="material" ShowInCustomizationForm="True" VisibleIndex="6" Width="10%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="issue" ShowInCustomizationForm="True" VisibleIndex="7" Width="25%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="action" ShowInCustomizationForm="True" VisibleIndex="8" Width="25%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="responsible" ShowInCustomizationForm="True" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="open_close" ShowInCustomizationForm="True" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="creation_date" ShowInCustomizationForm="True" VisibleIndex="11">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="creation_user" ShowInCustomizationForm="True" VisibleIndex="12">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="due_date" ShowInCustomizationForm="True" VisibleIndex="13">
                        </dx:GridViewDataDateColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSourceActions" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" SelectCommand="SELECT [tbl_actions_id], [area], [vsm], [mrp], [report], [material], [issue], [action], [responsible], [open_close], [creation_date], [creation_user], [due_date] FROM [tbl_actions]"></asp:SqlDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
</asp:Content>
