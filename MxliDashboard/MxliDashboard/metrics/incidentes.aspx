﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="incidentes.aspx.cs" Inherits="MxliDashboard.n3_Safety.incidentes" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>
<%@ Register Assembly="DevExpress.XtraCharts.v20.1.Web, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <h3>Incidentes.</h3>
    <p></p>
        <asp:Label ID="Label1" runat="server" Text="labelUpdate"></asp:Label>
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server">
                <table style="table-layout: fixed">
                    <tr>
                        <th>
                            <dx:ASPxLabel ID="ASPxLabelV" runat="server" Text="Select Metric View:" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxV" runat="server" ValueType="System.String" AutoPostBack="True"
                                OnSelectedIndexChanged="ASPxComboBoxV_SelectedIndexChanged" Theme="Office365">
                                <Items>
                                    <dx:ListEditItem Selected="True" Text="Default" Value="0" />
                                    <dx:ListEditItem Text="Weekly" Value="1" />
                                    <dx:ListEditItem Text="Monthly" Value="2" />
                                    <dx:ListEditItem Text="Quarterly" Value="3" />
                                    <dx:ListEditItem Text="Yearly" Value="4" />
                                </Items>
                                <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One View&quot;;
                                                    }}" />
                                <ValidationSettings ValidateOnLeave="False">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </th>
                        <th>
                            <dx:ASPxLabel ID="ASPxLabelGV" runat="server" Text="Select Chart view:" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxGV" runat="server" ValueType="System.String" AutoPostBack="True"
                                OnSelectedIndexChanged="ASPxComboBoxGV_SelectedIndexChanged" Theme="Office365">
                                <Items>
                                    <dx:ListEditItem Selected="True" Text="Default" Value="0" />
                                    <dx:ListEditItem Text="Trend" Value="1" />
                                    <dx:ListEditItem Text="Pareto" Value="2" />
                                    <dx:ListEditItem Text="Forecast" Value="3" />
                                </Items>
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Graph View&quot;;
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
    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" >
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server">
                <table style="table-layout: fixed">
                    <tr>                       
                        <th>
                            <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select Area" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="area"
                                TextField="area" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" 
                                OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged" Theme="Office365">
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
                            <dx:ASPxLabel ID="ASPxLabelCaption2" runat="server" Text="Select Cell" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="celda"
                                TextField="celda" ValueType="System.String" DataSourceID="SqlDataSourceCell"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundCell" Theme="Office365">
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
                            <dx:ASPxLabel ID="ASPxLabelCaption3" runat="server" Text="Select Cause" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                            </dx:ASPxLabel>
                            <dx:ASPxComboBox ID="ASPxComboBoxCausaInContent" runat="server" ValueField="causa"
                                TextField="causa" ValueType="System.String" DataSourceID="SqlDataSourceCausa"
                                AutoPostBack="True" OnDataBound="cmbox_DataBoundCausa" Theme="Office365">
                                <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Cause&quot;;
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
    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Data chart" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent3" runat="server">
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
                            </AxisY>
                        </dx:XYDiagram>
                    </DiagramSerializable>
                    <Legend Name="Default Legend" Font="Honeywell Sans Web Medium, 8pt"></Legend>
                    <SeriesSerializable>
                        <dx:Series Name="Total" LabelsVisibility="True" >
                            <ViewSerializable>
                                <dx:SideBySideBarSeriesView BarWidth="0.8" Color="0, 102, 153">
                                    <Border Color="79, 129, 189" Visibility="False" />
                                    <FillStyle FillMode="Solid">
                                    </FillStyle>
                                </dx:SideBySideBarSeriesView>
                            </ViewSerializable>
                        </dx:Series>
                        <dx:Series LabelsVisibility="True" Name="Goal" >
                            <ViewSerializable>
                                <dx:LineSeriesView Color="192, 80, 77">
                                </dx:LineSeriesView>
                            </ViewSerializable>
                        </dx:Series>
                    </SeriesSerializable>
                </dx:WebChartControl>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <p />
    <hr />
    <p />
    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Source data" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent4" runat="server">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ds_incidentes" Theme="Default" Width="1024px">
                    <SettingsPager Mode="ShowPager" PageSize="20">
                    </SettingsPager>
                    <Settings ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsSearchPanel Visible="True" />
                    <SettingsExport EnableClientSideExportAPI="true" FileName="INCIDENTS" />
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
                        <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="0" Caption="ID">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="fecha" VisibleIndex="1" Caption="FECHA">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="empleado" VisibleIndex="2" Caption="EMPLEADO">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="area" VisibleIndex="3" Caption="AREA">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="celda" VisibleIndex="4" Caption="CELDA">
                        </dx:GridViewDataTextColumn>                       
                        <dx:GridViewDataTextColumn FieldName="causa" VisibleIndex="5" Caption="CAUSA">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="descripcion" VisibleIndex="6" Caption="DESCRIPCION">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="clasificacion" VisibleIndex="7" Caption="CLASIFICACION">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="assignedto" VisibleIndex="8" Caption="ASIGNADO">
                        </dx:GridViewDataTextColumn>                        
                        <dx:GridViewDataTextColumn FieldName="mstnumero" VisibleIndex="9" Caption="MST#">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="area" ShowInColumn="AREA" SummaryType="Count" />
                    </GroupSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="celda" ShowInColumn="CELDA" SummaryType="Count" />
                    </GroupSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="causa" ShowInColumn="CAUSA" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Header BackColor="IndianRed" ForeColor="White">
                        </Header>
                    </Styles>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <asp:SqlDataSource ID="ds_incidentes" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT [id], [fecha], [empleado], [area], [celda], [causa], [descripcion], [clasificacion], [assignedto], [mstnumero] FROM [sap_incidentes] where area like @pArea and celda like @pCelda and causa like @pCausa order by id">
        <SelectParameters>
            <asp:ControlParameter ControlID="ASPxRoundPanel2$ASPxComboBoxVsmInContent"
                Name="pArea" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel2$ASPxComboBoxCellInContent"
                Name="pCelda" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="ASPxRoundPanel2$ASPxComboBoxCausaInContent"
                Name="pCausa" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [area] FROM [sap_incidentes] order by area"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [celda] FROM [sap_incidentes] order by celda"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceCausa" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
        SelectCommand="SELECT distinct [causa] FROM [sap_incidentes] order by causa"></asp:SqlDataSource>
    <p />
    <hr />
    <p />
    <dx:ASPxRoundPanel ID="ASPxRoundPanel5" runat="server" Width="100%" HeaderText="Actions" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent5" runat="server">
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceActions" KeyFieldName="tbl_actions_id" Width="100%" Theme="Metropolis">
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
                        <dx:GridViewDataTextColumn FieldName="issue" ShowInCustomizationForm="True" VisibleIndex="2" Caption="ISSUE" Width="25%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="action" ShowInCustomizationForm="True" VisibleIndex="3" Caption="ACTION" Width="25%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="impact" ShowInCustomizationForm="True" VisibleIndex="4" Caption="IMPACT" Width="7%">
                            <PropertiesComboBox DropDownStyle="DropDownList" TextField="SelectImpact" ValueField="SelectImpact">
                                <Items>
                                    <dx:ListEditItem Text="DATE" Value="DATE" />
                                    <dx:ListEditItem Text="QUANTITY" Value="QUANTITY" />
                                    <dx:ListEditItem Text="VALUE" Value="VALUE" />
                                    <dx:ListEditItem Text="OTHER" Value="OTHER" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="imp_description" ShowInCustomizationForm="True" VisibleIndex="5" Caption="DESCRIPTION" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="material" ShowInCustomizationForm="True" VisibleIndex="6" Caption="MATERIAL" Width="7%" >
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="responsible" ShowInCustomizationForm="True" VisibleIndex="7" Caption="RESPONSIBLE" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="creation_date" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Created on" Width="7%">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="creation_user" ShowInCustomizationForm="True" VisibleIndex="9" Caption="Created by" Width="7%">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="due_date" ShowInCustomizationForm="True" VisibleIndex="10" Caption="Due date" Width="7%">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="open_close" ShowInCustomizationForm="True" VisibleIndex="11" Caption="Status" Width="7%">
                            <PropertiesComboBox DropDownStyle="DropDownList" TextField="SelectStatus" ValueField="SelectStatus">
                                <Items>
                                    <dx:ListEditItem Text="OPEN" Value="OPEN" />
                                    <dx:ListEditItem Text="CLOSED" Value="CLOSED" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <Styles>
                        <Header BackColor="#006699" ForeColor="White">
                        </Header>
                    </Styles>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSourceActions" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_actions] WHERE ([report] = @report)" 
                    DeleteCommand="DELETE FROM [tbl_actions] WHERE [tbl_actions_id] = @tbl_actions_id" 
                    InsertCommand="INSERT INTO [tbl_actions] ([report], [material], [issue], [action], [responsible], [open_close], [creation_date], [creation_user], [due_date], [impact], [imp_description]) VALUES (@report, @material, @issue, @action, @responsible, @open_close, @creation_date, @creation_user, @due_date, @impact, @imp_description)" 
                    UpdateCommand="UPDATE [tbl_actions] SET [material] = @material, [issue] = @issue, [action] = @action, [responsible] = @responsible, [open_close] = @open_close, [creation_user] = @creation_user, [due_date] = @due_date, [impact] = @impact, [imp_description] = @imp_description WHERE [tbl_actions_id] = @tbl_actions_id">
                    <DeleteParameters>
                        <asp:Parameter Name="tbl_actions_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>                        
                        <asp:Parameter Name="issue" Type="String" />
                        <asp:Parameter Name="action" Type="String" />
                        <asp:Parameter Name="impact" Type="String" />
                        <asp:Parameter Name="imp_description" Type="String" />
                        <asp:Parameter Name="material" Type="String" />
                        <asp:Parameter Name="responsible" Type="String" />                        
                        <asp:Parameter Name="creation_date" Type="DateTime" />
                        <asp:Parameter Name="creation_user" Type="String" />
                        <asp:Parameter Name="due_date" Type="DateTime" />
                        <asp:Parameter Name="open_close" Type="String" DefaultValue="OPEN" />
                        <asp:Parameter Name="report" Type="String" DefaultValue="INCIDENTS" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="incidents" Name="report" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>                        
                        <asp:Parameter Name="issue" Type="String" />
                        <asp:Parameter Name="action" Type="String" />
                        <asp:Parameter Name="impact" Type="String" />
                        <asp:Parameter Name="imp_description" Type="String" />
                        <asp:Parameter Name="material" Type="String" />
                        <asp:Parameter Name="responsible" Type="String" />                       
                        <asp:Parameter Name="creation_user" Type="String" />
                        <asp:Parameter Name="due_date" Type="DateTime" />
                        <asp:Parameter Name="open_close" Type="String" />
                        <asp:Parameter Name="tbl_actions_id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
</asp:Content>
