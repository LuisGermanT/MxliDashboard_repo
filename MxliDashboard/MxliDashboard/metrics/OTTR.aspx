<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OTTR.aspx.cs" Inherits="MxliDashboard.WebForm1" %>

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

            <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Views" ForeColor="Black" AllowCollapsingByHeaderClick="true">
                <HeaderStyle ForeColor="White" />
                <HeaderContent BackColor="#666666">
                </HeaderContent>
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent4" runat="server">
                        <table style="table-layout: fixed">
                            <tr>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption3" runat="server" Text="View By Period" Font-Names="Honeywell Sans Web" Font-Size="Medium">
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
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption5" runat="server" Text="Select Chart View" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxMCInContent" runat="server" ValueType="System.String" AutoPostBack="True"
                                            OnSelectedIndexChanged="ASPxComboBoxMCInContent_SelectedIndexChanged" Theme="Office365" >
                                        <Items>
                                            <dx:ListEditItem Selected="true" Text="Default" Value="0" />
                                            <dx:ListEditItem Text="OTTR All Areas" Value="1" />
                                            <dx:ListEditItem Text="OTTR All Cells" Value="2" />
                                            <dx:ListEditItem Text="OTTR All MRPs" Value="3" />
                                        </Items>
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

            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views and Filters" ForeColor="Black" AllowCollapsingByHeaderClick="true">
                <HeaderStyle ForeColor="White" />
                <HeaderContent BackColor="#666666">
                </HeaderContent>
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent1" runat="server">
                        <table style="table-layout: fixed">
                            <tr>
                                <th>
                                    <dx:ASPxLabel ID="ASPxLabelCaption1" runat="server" Text="Select VSM:" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="TO_rArea"
                                        TextField="TO_rArea" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged" Theme="Office365">
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
                                    <dx:ASPxLabel ID="ASPxLabelCaption2" runat="server" Text="Select Cell:" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="TO_Cell"
                                        TextField="TO_Cell" ValueType="System.String" DataSourceID="SqlDataSourceCell"
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
                                    <dx:ASPxLabel ID="ASPxLabelCaption4" runat="server" Text="Select Mrp:" Font-Names="Honeywell Sans Web" Font-Size="Medium">
                                    </dx:ASPxLabel>
                                    <dx:ASPxComboBox ID="ASPxComboBoxMrpInContent" runat="server" ValueField="TO_MRP"
                                        TextField="TO_MRP" ValueType="System.String" DataSourceID="SqlDataSourceMrp"
                                        AutoPostBack="True" OnDataBound="cmbox_DataBoundMrp" OnSelectedIndexChanged="ASPxComboBoxMrpInContent_SelectedIndexChanged" Theme="Office365">
                                        <ClientSideEvents Validation="function(s, e) {
                                                if (s.GetSelectedIndex()==0) {
                                                e.isValid = false;
                                                e.errorText = &quot;You should Select One Mrp&quot;;
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
                        <dx:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="" CrosshairEnabled="True" Height="300px" Width="1100px"
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
                                    <SecondaryAxesY>
                                        <dx:SecondaryAxisY AxisID="0" Name="Secondary AxisY 1" VisibleInPanesSerializable="-1">
                                            <Label TextPattern="{V:0%}">
                                            </Label>
                                            <NumericScaleOptions AutoGrid="False" GridSpacing="0.5" />
                                        </dx:SecondaryAxisY>
                                    </SecondaryAxesY>
                                </dx:XYDiagram>
                            </DiagramSerializable>
                            <Legend Name="Default Legend" Font="Honeywell Sans Web Medium, 8pt"></Legend>
                            <SeriesSerializable>
                                <dx:Series LabelsVisibility="True" Name="On Time" CrosshairLabelPattern="{V:#,#}" LegendTextPattern="{V:#,#}" >
                                    <ViewSerializable>
                                        <dx:SideBySideBarSeriesView Color="55, 96, 146" BarWidth="0.8">
                                            <Border Color="79, 129, 189" Visibility="False" />
                                            <FillStyle FillMode="Solid">
                                            </FillStyle>
                                        </dx:SideBySideBarSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:SideBySideBarSeriesLabel TextPattern="{V:#,#}">
                                        </dx:SideBySideBarSeriesLabel>
                                    </LabelSerializable>
                                </dx:Series>
                                <dx:Series Name="Total Ord" LabelsVisibility="True" CrosshairLabelPattern="{V:#,#}" LegendTextPattern="{V:#,#}" >
                                    <ViewSerializable>
                                        <dx:SideBySideBarSeriesView Color="185, 205, 229">
                                        </dx:SideBySideBarSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:SideBySideBarSeriesLabel TextPattern="{V:#,#}">
                                        </dx:SideBySideBarSeriesLabel>
                                    </LabelSerializable>
                                </dx:Series>
                                <dx:Series Name="% OTTR" CrosshairLabelPattern="{V:0.00%}" LabelsVisibility="True" LegendName="Default Legend" LegendTextPattern="{V:0.00%}">
                                    <ViewSerializable>
                                        <dx:LineSeriesView AxisYName="Secondary AxisY 1" Color="Black" MarkerVisibility="True">
                                            <LineMarkerOptions Color="White" Size="8">
                                            </LineMarkerOptions>
                                        </dx:LineSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:PointSeriesLabel TextPattern="{V:0.00%}">
                                        </dx:PointSeriesLabel>
                                    </LabelSerializable>
                                </dx:Series>
                                <dx:Series Name="AOP" CrosshairLabelPattern="{V:0.00%}" LegendTextPattern="{V:0.00%}">
                                    <ViewSerializable>
                                        <dx:LineSeriesView AxisYName="Secondary AxisY 1" Color="192, 80, 77" MarkerVisibility="False">
                                        </dx:LineSeriesView>
                                    </ViewSerializable>
                                    <LabelSerializable>
                                        <dx:PointSeriesLabel TextPattern="{V:0.00%}">
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
                            <SettingsExport EnableClientSideExportAPI="true" FileName="OTTR" />
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
                                <dx:GridViewDataTextColumn FieldName="STO" VisibleIndex="0" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OrderType" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Material" VisibleIndex="2" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PnDesc" VisibleIndex="3" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cell" VisibleIndex="5" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MRP" VisibleIndex="6" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ReqQty" VisibleIndex="7" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ShipedQty" VisibleIndex="8" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsExcluded" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="HitMiss" VisibleIndex="10" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="RequestedDate" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Wk" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="12">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Month" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Yr" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="14">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DelayCode" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="15">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Category" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="16">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CauseComment" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="17">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SupplierName" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="18">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Component" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="19">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Countermeasure" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="20">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Owner" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="21">
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
                SelectCommand="SELECT * FROM [vw_OTTR_Details] WHERE [Area] <> 'R&O' AND [Area] LIKE @pVsm AND [Cell] Like @pCell AND [MRP] LIKE @pMrp
                                 Order By [Yr] desc, [Wk] desc, [Month], [Area], [Cell], [MRP]
                ">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxCellInContent"
                        Name="pCell" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVsmInContent"
                        Name="pVsm" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxMrpInContent"
                        Name="pMrp" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_Cell] FROM [tblOTTR] WHERE [TO_rArea] <> 'R&O' order by [TO_Cell]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_rArea] FROM [tblOTTR] WHERE [TO_rArea] <> 'R&O' order by [TO_rArea]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceMrp" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_MRP] FROM [tblOTTR] WHERE [TO_rArea] <> 'R&O' order by [TO_MRP]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceFilters" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT * FROM [tblFilters] WHERE [TF_Name] = 'Week' Or [TF_Name] = 'Month' Or [TF_Name] = 'Year'"></asp:SqlDataSource>
            <p/>
            <hr/>
            <p/>

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
                        <asp:Parameter Name="report" Type="String" DefaultValue="OTTR" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="ottr" Name="report" Type="String" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
