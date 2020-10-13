<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="MxliDashboard.n3_Inventory.inventory" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>
<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p></p>
    <h3>Inventory cost.</h3>
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
                            <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="svsm"
                                TextField="svsm" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" 
                                OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged">
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
                            <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="scell"
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
                            <dx:ASPxComboBox ID="ASPxComboBoxPfepInContent" runat="server" ValueField="spfep"
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
    <p></p>
    <hr />
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Data chart" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server">
                <dx:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="" CrosshairEnabled="True" Height="200px" Width="1024px"
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
                        <dx:Series Name="Total" LabelsVisibility="True" CrosshairLabelPattern="{V:c2}">
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
                        <dx:Series LabelsVisibility="False" Name="Goal" CrosshairLabelPattern="{V:C2}">
                            <ViewSerializable>
                                <dx:LineSeriesView Color="IndianRed">
                                </dx:LineSeriesView>
                            </ViewSerializable>
                        </dx:Series>
                        <dx:Series Name="Adj" LabelsVisibility="True" CrosshairLabelPattern="{V:c2}">
                            <ViewSerializable>
                                <dx:StackedBarSeriesView Color="247, 150, 70">
                                </dx:StackedBarSeriesView>
                            </ViewSerializable>
                            <LabelSerializable>
                                <dx:StackedBarSeriesLabel TextPattern="{V:c2}">
                                </dx:StackedBarSeriesLabel>
                            </LabelSerializable>
                        </dx:Series>
                    </SeriesSerializable>
                </dx:WebChartControl>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
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
                        <dx:GridViewDataTextColumn FieldName="sPfep" VisibleIndex="8" Caption="PFEP">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem DisplayFormat="C2" FieldName="Total" ShowInColumn="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="Total" SummaryType="Sum" />
                    </GroupSummary>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>       
    </dx:ASPxRoundPanel>
    <asp:SqlDataSource ID="ds_inventory" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT [sMaterial], [totQty], [Price], [Total], [sVsm], [sCell], [sMrp], [sMakeBuy], [sPfep] FROM [tbl_inventario] where [xDay] = 1 and smrp like @pMrp and svsm like @pVsm and scell like @pCell and spfep like @pPfep">
    <SelectParameters>
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxMrpInContent"
                Name="pMrp" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                Name="pVsm" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxCellInContent"
                Name="pCell" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxPfepInContent"
                Name="pPfep" PropertyName="Value" Type="String" />
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
    <p />
    <hr />
    <p />
    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Actions" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent4" runat="server">
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceActions" KeyFieldName="tbl_actions_id" Width="100%" Theme="Default">
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
                        <dx:GridViewDataTextColumn FieldName="vsm" ShowInCustomizationForm="True" VisibleIndex="3" Caption="VSM" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mrp" ShowInCustomizationForm="True" VisibleIndex="4" Caption="MRP" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="report" ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="material" ShowInCustomizationForm="True" VisibleIndex="6" Width="7%" Caption="Material">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="issue" ShowInCustomizationForm="True" VisibleIndex="7" Width="25%" Caption="Issue">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="action" ShowInCustomizationForm="True" VisibleIndex="8" Width="25%" Caption="Action">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="responsible" ShowInCustomizationForm="True" VisibleIndex="9" Caption="Responsible" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="creation_date" ShowInCustomizationForm="True" VisibleIndex="11" Caption="Created on" Width="7%">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="creation_user" ShowInCustomizationForm="True" VisibleIndex="12" Caption="Created by" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="due_date" ShowInCustomizationForm="True" VisibleIndex="13" Caption="Due date" Width="7%">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="open_close" ShowInCustomizationForm="True" VisibleIndex="10" Width="7%" Visible="False">
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSourceActions" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" SelectCommand="SELECT [tbl_actions_id], [area], [vsm], [mrp], [report], [material], [issue], [action], [responsible], [open_close], [creation_date], [creation_user], [due_date] FROM [tbl_actions] WHERE ([report] = @report)" DeleteCommand="DELETE FROM [tbl_actions] WHERE [tbl_actions_id] = @tbl_actions_id" InsertCommand="INSERT INTO [tbl_actions] ([area], [vsm], [mrp], [report], [material], [issue], [action], [responsible], [open_close], [creation_date], [creation_user], [due_date]) VALUES (@area, @vsm, @mrp, @report, @material, @issue, @action, @responsible, @open_close, @creation_date, @creation_user, @due_date)" UpdateCommand="UPDATE [tbl_actions] SET [area] = @area, [vsm] = @vsm, [mrp] = @mrp, [report] = @report, [material] = @material, [issue] = @issue, [action] = @action, [responsible] = @responsible, [open_close] = @open_close, [creation_date] = @creation_date, [creation_user] = @creation_user, [due_date] = @due_date WHERE [tbl_actions_id] = @tbl_actions_id">
                    <DeleteParameters>
                        <asp:Parameter Name="tbl_actions_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="area" Type="String" DefaultValue="MATERIALES" />
                        <asp:Parameter Name="vsm" Type="String" />
                        <asp:Parameter Name="mrp" Type="String" />
                        <asp:Parameter Name="report" Type="String" DefaultValue="INVENTARIO" />
                        <asp:Parameter Name="material" Type="String" />
                        <asp:Parameter Name="issue" Type="String" />
                        <asp:Parameter Name="action" Type="String" />
                        <asp:Parameter Name="responsible" Type="String" />
                        <asp:Parameter Name="open_close" Type="String" DefaultValue="OPEN" />
                        <asp:Parameter Name="creation_date" Type="DateTime" />
                        <asp:Parameter Name="creation_user" Type="String" />
                        <asp:Parameter Name="due_date" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="INVENTARIO" Name="report" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="area" Type="String" />
                        <asp:Parameter Name="vsm" Type="String" />
                        <asp:Parameter Name="mrp" Type="String" />
                        <asp:Parameter Name="report" Type="String" />
                        <asp:Parameter Name="material" Type="String" />
                        <asp:Parameter Name="issue" Type="String" />
                        <asp:Parameter Name="action" Type="String" />
                        <asp:Parameter Name="responsible" Type="String" />
                        <asp:Parameter Name="open_close" Type="String" />
                        <asp:Parameter Name="creation_date" Type="DateTime" />
                        <asp:Parameter Name="creation_user" Type="String" />
                        <asp:Parameter Name="due_date" Type="DateTime" />
                        <asp:Parameter Name="tbl_actions_id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
</asp:Content>
