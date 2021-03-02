<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="set_aop_goals.aspx.cs" Inherits="MxliDashboard.set_aop_goals" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <div class="row">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="AOP Goals Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table>
                        <tr>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaptionF1" runat="server" Text="Metric:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxF1" runat="server" ValueField="svalue"
                                    TextField="svalue" ValueType="System.String" DataSourceID="SqlDataSourceMetric"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundF1" OnSelectedIndexChanged="ASPxComboBoxF1_SelectedIndexChanged">
                                    <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Metric&quot;;
                                            }}" />
                                    <ValidationSettings ValidateOnLeave="False">
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </th>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSourceMetric" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                        SelectCommand="SELECT svalue FROM tbl_settings WHERE stype = 'metric' order by svalue"></asp:SqlDataSource>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    </div>
    <hr />
    <p></p>
    <div class="row" id="METRIC_GOALS" runat="server" visible="False">       
        <p>
            <asp:Label ID="Label1" runat="server" Text="SITE GOALS"></asp:Label>
        </p>
        <div class="row" id="Div1" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAOP" EnableTheming="True" KeyFieldName="tbl_set_aopgoals_id" Theme="Mulberry" Width="100%" >
                <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="5" Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                <SettingsPopup>
                    <EditForm Modal="True" Width="750px" SettingsAdaptivity-Mode="OnWindowInnerWidth">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
                    </EditForm>
                </SettingsPopup>
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                    </SettingsAdaptivity>

                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_set_aopgoals_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gDesc" VisibleIndex="2" Caption="DESC" ReadOnly="true">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="LAST GOAL" FieldName="gPreviousYear" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JAN" FieldName="gM1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="FEB" FieldName="gM2" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAR" FieldName="gM3" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="APR" FieldName="gM4" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAY" FieldName="gM5" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUN" FieldName="gM6" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUL" FieldName="gM7" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="AUG" FieldName="gM8" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SEP" FieldName="gM9" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OCT" FieldName="gM10" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NOV" FieldName="gM11" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DEC" FieldName="gM12" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GOAL" FieldName="gActualYear" VisibleIndex="16">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceAOP" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_set_aopgoals_id], [gDesc], [gPreviousYear],[gM1], [gM2], [gM3], [gM4], [gM5], [gM6], [gM7], [gM8], [gM9], [gM10], [gM11], [gM12], [gActualYear] FROM [tbl_set_aopgoals] where [metric] = @param1 and gType = 'SITE'"
                UpdateCommand="UPDATE [tbl_set_aopgoals] SET [gPreviousYear] = @gPreviousYear, [gActualYear] = @gActualYear, [gM1] = @gM1, [gM2] = @gM2, [gM3] = @gM3, [gM4] = @gM4, [gM5] = @gM5, [gM6] = @gM6, [gM7] = @gM7, [gM8] = @gM8, [gM9] = @gM9, [gM10] = @gM10, [gM11] = @gM11, [gM12] = @gM12 WHERE [tbl_set_aopgoals_id] = @tbl_set_aopgoals_id">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="gPreviousYear" Type="String" />
                    <asp:Parameter Name="gActualYear" Type="String" />
                    <asp:Parameter Name="gM1" Type="String" />
                    <asp:Parameter Name="gM2" Type="String" />
                    <asp:Parameter Name="gM3" Type="String" />
                    <asp:Parameter Name="gM4" Type="String" />
                    <asp:Parameter Name="gM5" Type="String" />
                    <asp:Parameter Name="gM6" Type="String" />
                    <asp:Parameter Name="gM7" Type="String" />
                    <asp:Parameter Name="gM8" Type="String" />
                    <asp:Parameter Name="gM9" Type="String" />
                    <asp:Parameter Name="gM10" Type="String" />
                    <asp:Parameter Name="gM11" Type="String" />
                    <asp:Parameter Name="gM12" Type="String" />
                    <asp:Parameter Name="tbl_set_aopgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label2" runat="server" Text="VSM GOALS"></asp:Label>
        </p>
        <div class="row" id="Div2" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceVSM" EnableTheming="True" KeyFieldName="tbl_set_aopgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
                <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="5" Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                <SettingsPopup>
                    <EditForm Modal="True" Width="750px" SettingsAdaptivity-Mode="OnWindowInnerWidth">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
                    </EditForm>
                </SettingsPopup>
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                    </SettingsAdaptivity>

                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_set_aopgoals_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gDesc" VisibleIndex="2" Caption="VSM" ReadOnly="true">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="LAST GOAL" FieldName="gPreviousYear" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JAN" FieldName="gM1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="FEB" FieldName="gM2" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAR" FieldName="gM3" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="APR" FieldName="gM4" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAY" FieldName="gM5" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUN" FieldName="gM6" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUL" FieldName="gM7" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="AUG" FieldName="gM8" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SEP" FieldName="gM9" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OCT" FieldName="gM10" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NOV" FieldName="gM11" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DEC" FieldName="gM12" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GOAL" FieldName="gActualYear" VisibleIndex="16">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceVSM" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_set_aopgoals_id], [gDesc], [gPreviousYear],[gM1], [gM2], [gM3], [gM4], [gM5], [gM6], [gM7], [gM8], [gM9], [gM10], [gM11], [gM12], [gActualYear] FROM [tbl_set_aopgoals] where [metric] = @param1 and gType = 'VSM'"
                UpdateCommand="UPDATE [tbl_set_aopgoals] SET [gPreviousYear] = @gPreviousYear, [gActualYear] = @gActualYear, [gM1] = @gM1, [gM2] = @gM2, [gM3] = @gM3, [gM4] = @gM4, [gM5] = @gM5, [gM6] = @gM6, [gM7] = @gM7, [gM8] = @gM8, [gM9] = @gM9, [gM10] = @gM10, [gM11] = @gM11, [gM12] = @gM12 WHERE [tbl_set_aopgoals_id] = @tbl_set_aopgoals_id">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="gPreviousYear" Type="String" />
                    <asp:Parameter Name="gActualYear" Type="String" />
                    <asp:Parameter Name="gM1" Type="String" />
                    <asp:Parameter Name="gM2" Type="String" />
                    <asp:Parameter Name="gM3" Type="String" />
                    <asp:Parameter Name="gM4" Type="String" />
                    <asp:Parameter Name="gM5" Type="String" />
                    <asp:Parameter Name="gM6" Type="String" />
                    <asp:Parameter Name="gM7" Type="String" />
                    <asp:Parameter Name="gM8" Type="String" />
                    <asp:Parameter Name="gM9" Type="String" />
                    <asp:Parameter Name="gM10" Type="String" />
                    <asp:Parameter Name="gM11" Type="String" />
                    <asp:Parameter Name="gM12" Type="String" />
                    <asp:Parameter Name="tbl_set_aopgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label3" runat="server" Text="AREA GOALS"></asp:Label>
        </p>
        <div class="row" id="Div3" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceArea" EnableTheming="True" KeyFieldName="tbl_set_aopgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
                <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="5" Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                <SettingsPopup>
                    <EditForm Modal="True" Width="750px" SettingsAdaptivity-Mode="OnWindowInnerWidth">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
                    </EditForm>
                </SettingsPopup>
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                    </SettingsAdaptivity>

                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_set_aopgoals_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gDesc" VisibleIndex="2" Caption="AREA" ReadOnly="true">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="LAST GOAL" FieldName="gPreviousYear" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JAN" FieldName="gM1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="FEB" FieldName="gM2" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAR" FieldName="gM3" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="APR" FieldName="gM4" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAY" FieldName="gM5" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUN" FieldName="gM6" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUL" FieldName="gM7" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="AUG" FieldName="gM8" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SEP" FieldName="gM9" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OCT" FieldName="gM10" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NOV" FieldName="gM11" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DEC" FieldName="gM12" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GOAL" FieldName="gActualYear" VisibleIndex="16">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceArea" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_set_aopgoals_id], [gDesc], [gPreviousYear],[gM1], [gM2], [gM3], [gM4], [gM5], [gM6], [gM7], [gM8], [gM9], [gM10], [gM11], [gM12], [gActualYear] FROM [tbl_set_aopgoals] where [metric] = @param1 and gType = 'AREA'"
                UpdateCommand="UPDATE [tbl_set_aopgoals] SET [gPreviousYear] = @gPreviousYear, [gActualYear] = @gActualYear, [gM1] = @gM1, [gM2] = @gM2, [gM3] = @gM3, [gM4] = @gM4, [gM5] = @gM5, [gM6] = @gM6, [gM7] = @gM7, [gM8] = @gM8, [gM9] = @gM9, [gM10] = @gM10, [gM11] = @gM11, [gM12] = @gM12 WHERE [tbl_set_aopgoals_id] = @tbl_set_aopgoals_id">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="gPreviousYear" Type="String" />
                    <asp:Parameter Name="gActualYear" Type="String" />
                    <asp:Parameter Name="gM1" Type="String" />
                    <asp:Parameter Name="gM2" Type="String" />
                    <asp:Parameter Name="gM3" Type="String" />
                    <asp:Parameter Name="gM4" Type="String" />
                    <asp:Parameter Name="gM5" Type="String" />
                    <asp:Parameter Name="gM6" Type="String" />
                    <asp:Parameter Name="gM7" Type="String" />
                    <asp:Parameter Name="gM8" Type="String" />
                    <asp:Parameter Name="gM9" Type="String" />
                    <asp:Parameter Name="gM10" Type="String" />
                    <asp:Parameter Name="gM11" Type="String" />
                    <asp:Parameter Name="gM12" Type="String" />
                    <asp:Parameter Name="tbl_set_aopgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label4" runat="server" Text="CELL GOALS"></asp:Label>
        </p>
        <div class="row" id="Div4" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCell" EnableTheming="True" KeyFieldName="tbl_set_aopgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
                <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="5" Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                <SettingsPopup>
                    <EditForm Modal="True" Width="750px" SettingsAdaptivity-Mode="OnWindowInnerWidth">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
                    </EditForm>
                </SettingsPopup>
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                    </SettingsAdaptivity>

                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_set_aopgoals_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gDesc" VisibleIndex="2" Caption="CELL" ReadOnly="true">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="LAST GOAL" FieldName="gPreviousYear" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JAN" FieldName="gM1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="FEB" FieldName="gM2" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAR" FieldName="gM3" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="APR" FieldName="gM4" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAY" FieldName="gM5" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUN" FieldName="gM6" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUL" FieldName="gM7" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="AUG" FieldName="gM8" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SEP" FieldName="gM9" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OCT" FieldName="gM10" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NOV" FieldName="gM11" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DEC" FieldName="gM12" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GOAL" FieldName="gActualYear" VisibleIndex="16">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_set_aopgoals_id], [gDesc], [gPreviousYear],[gM1], [gM2], [gM3], [gM4], [gM5], [gM6], [gM7], [gM8], [gM9], [gM10], [gM11], [gM12], [gActualYear] FROM [tbl_set_aopgoals] where [metric] = @param1 and gType = 'CELL'"
                UpdateCommand="UPDATE [tbl_set_aopgoals] SET [gPreviousYear] = @gPreviousYear, [gActualYear] = @gActualYear, [gM1] = @gM1, [gM2] = @gM2, [gM3] = @gM3, [gM4] = @gM4, [gM5] = @gM5, [gM6] = @gM6, [gM7] = @gM7, [gM8] = @gM8, [gM9] = @gM9, [gM10] = @gM10, [gM11] = @gM11, [gM12] = @gM12 WHERE [tbl_set_aopgoals_id] = @tbl_set_aopgoals_id">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="gPreviousYear" Type="String" />
                    <asp:Parameter Name="gActualYear" Type="String" />
                    <asp:Parameter Name="gM1" Type="String" />
                    <asp:Parameter Name="gM2" Type="String" />
                    <asp:Parameter Name="gM3" Type="String" />
                    <asp:Parameter Name="gM4" Type="String" />
                    <asp:Parameter Name="gM5" Type="String" />
                    <asp:Parameter Name="gM6" Type="String" />
                    <asp:Parameter Name="gM7" Type="String" />
                    <asp:Parameter Name="gM8" Type="String" />
                    <asp:Parameter Name="gM9" Type="String" />
                    <asp:Parameter Name="gM10" Type="String" />
                    <asp:Parameter Name="gM11" Type="String" />
                    <asp:Parameter Name="gM12" Type="String" />
                    <asp:Parameter Name="tbl_set_aopgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
