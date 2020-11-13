<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="MxliDashboard.Settings" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <div class="row">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True">
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
            <asp:Label ID="Label1" runat="server" Text="METRIC DESCRIPTION"></asp:Label>
        </p>
        <div class="row" id="Div1" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMgrGoals" EnableTheming="True" KeyFieldName="tbl_MGRgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
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
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="35px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_MGRgoals_id" ReadOnly="True" VisibleIndex="1" Caption="#" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="metric" VisibleIndex="2" Caption="METRIC" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="TYPE" FieldName="gType" VisibleIndex="4">
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="UNIT" FieldName="gUnit" VisibleIndex="5">
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="YEAR" FieldName="nYear" VisibleIndex="6">
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="DESCRIPTION" FieldName="metricDesc" VisibleIndex="3">
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceMgrGoals" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_MGRgoals_id], [metric], [metricDesc], [gType], [gUnit], [nYear] FROM [tbl_MGRgoals]" DeleteCommand="DELETE FROM [tbl_MGRgoals] WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id" InsertCommand="INSERT INTO [tbl_MGRgoals] ([metric], [metricDesc], [gType], [gUnit], [nYear]) VALUES (@metric, @metricDesc, @gType, @gUnit, @nYear)" UpdateCommand="UPDATE [tbl_MGRgoals] SET [metric] = @metric, [metricDesc] = @metricDesc, [gType] = @gType, [gUnit] = @gUnit, [nYear] = @nYear WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id">
                <DeleteParameters>
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="metricDesc" Type="String" />
                    <asp:Parameter Name="gType" Type="String" />
                    <asp:Parameter Name="gUnit" Type="String" />
                    <asp:Parameter Name="nYear" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="metricDesc" Type="String" />
                    <asp:Parameter Name="gType" Type="String" />
                    <asp:Parameter Name="gUnit" Type="String" />
                    <asp:Parameter Name="nYear" Type="String" />
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label2" runat="server" Text="YEARLY GOALS"></asp:Label>
        </p>
        <div class="row" id="Div2" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="tbl_MGRgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
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
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="50px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_MGRgoals_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="metric" VisibleIndex="2" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gYear" VisibleIndex="3" Caption="YEARLY">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gQ1" VisibleIndex="4" Caption="QUARTER 1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="QUARTER 2" FieldName="gQ2" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="QUARTER 3" FieldName="gQ3" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="QUARTER 4" FieldName="gQ4" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_MGRgoals_id], [metric], [gYear], [gQ1], [gQ2], [gQ3], [gQ4] FROM [tbl_MGRgoals]" DeleteCommand="DELETE FROM [tbl_MGRgoals] WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id" InsertCommand="INSERT INTO [tbl_MGRgoals] ([metric], [gYear], [gQ1], [gQ2], [gQ3], [gQ4]) VALUES (@metric, @gYear, @gQ1, @gQ2, @gQ3, @gQ4)" UpdateCommand="UPDATE [tbl_MGRgoals] SET [metric] = @metric, [gYear] = @gYear, [gQ1] = @gQ1, [gQ2] = @gQ2, [gQ3] = @gQ3, [gQ4] = @gQ4 WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id">
                <DeleteParameters>
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="gYear" Type="String" />
                    <asp:Parameter Name="gQ1" Type="String" />
                    <asp:Parameter Name="gQ2" Type="String" />
                    <asp:Parameter Name="gQ3" Type="String" />
                    <asp:Parameter Name="gQ4" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="gYear" Type="String" />
                    <asp:Parameter Name="gQ1" Type="String" />
                    <asp:Parameter Name="gQ2" Type="String" />
                    <asp:Parameter Name="gQ3" Type="String" />
                    <asp:Parameter Name="gQ4" Type="String" />
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label3" runat="server" Text="MONTHLY GOALS"></asp:Label>
        </p>
        <div class="row" id="Div3" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" EnableTheming="True" KeyFieldName="tbl_MGRgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
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
                    <dx:GridViewDataTextColumn FieldName="gJan" VisibleIndex="1" Caption="JAN">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gFeb" VisibleIndex="2" Caption="FEB">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gMar" VisibleIndex="3" Caption="MAR">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="gApr" VisibleIndex="4" Caption="APR">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MAY" FieldName="gMay" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUN" FieldName="gJun" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="JUL" FieldName="gJul" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="AUG" FieldName="gAug" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SEP" FieldName="gSep" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OCT" FieldName="gOct" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NOV" FieldName="gNov" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DEC" FieldName="gDec" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_MGRgoals_id" ReadOnly="True" Visible="False" VisibleIndex="13">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="metric" Visible="False" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [gJan], [gFeb], [gMar], [gApr], [gMay], [gJun], [gJul], [gAug], [gSep], [gOct], [gNov], [gDec], [tbl_MGRgoals_id], [metric] FROM [tbl_MGRgoals]" DeleteCommand="DELETE FROM [tbl_MGRgoals] WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id" InsertCommand="INSERT INTO [tbl_MGRgoals] ([gJan], [gFeb], [gMar], [gApr], [gMay], [gJun], [gJul], [gAug], [gSep], [gOct], [gNov], [gDec], [metric]) VALUES (@gJan, @gFeb, @gMar, @gApr, @gMay, @gJun, @gJul, @gAug, @gSep, @gOct, @gNov, @gDec, @metric)" UpdateCommand="UPDATE [tbl_MGRgoals] SET [gJan] = @gJan, [gFeb] = @gFeb, [gMar] = @gMar, [gApr] = @gApr, [gMay] = @gMay, [gJun] = @gJun, [gJul] = @gJul, [gAug] = @gAug, [gSep] = @gSep, [gOct] = @gOct, [gNov] = @gNov, [gDec] = @gDec, [metric] = @metric WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id">
                <DeleteParameters>
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="gJan" Type="String" />
                    <asp:Parameter Name="gFeb" Type="String" />
                    <asp:Parameter Name="gMar" Type="String" />
                    <asp:Parameter Name="gApr" Type="String" />
                    <asp:Parameter Name="gMay" Type="String" />
                    <asp:Parameter Name="gJun" Type="String" />
                    <asp:Parameter Name="gJul" Type="String" />
                    <asp:Parameter Name="gAug" Type="String" />
                    <asp:Parameter Name="gSep" Type="String" />
                    <asp:Parameter Name="gOct" Type="String" />
                    <asp:Parameter Name="gNov" Type="String" />
                    <asp:Parameter Name="gDec" Type="String" />
                    <asp:Parameter Name="metric" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="gJan" Type="String" />
                    <asp:Parameter Name="gFeb" Type="String" />
                    <asp:Parameter Name="gMar" Type="String" />
                    <asp:Parameter Name="gApr" Type="String" />
                    <asp:Parameter Name="gMay" Type="String" />
                    <asp:Parameter Name="gJun" Type="String" />
                    <asp:Parameter Name="gJul" Type="String" />
                    <asp:Parameter Name="gAug" Type="String" />
                    <asp:Parameter Name="gSep" Type="String" />
                    <asp:Parameter Name="gOct" Type="String" />
                    <asp:Parameter Name="gNov" Type="String" />
                    <asp:Parameter Name="gDec" Type="String" />
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>
        <hr />
        <p>
            <asp:Label ID="Label4" runat="server" Text="WEEKLY GOALS"></asp:Label>
        </p>
        <div class="row" id="Div4" runat="server" visible="TRUE">
            <dx:ASPxVerticalGrid ID="ASPxVerticalGrid1" runat="server" Width="700px" AutoGenerateRows="False" DataSourceID="SqlDataSource3" EnableTheming="True" KeyFieldName="tbl_MGRgoals_id" Theme="Mulberry">
                <Rows>
                    <dx:VerticalGridCommandRow ShowEditButton="True" VisibleIndex="0">
                    </dx:VerticalGridCommandRow>
                    <dx:VerticalGridTextRow FieldName="tbl_MGRgoals_id" Visible="False" VisibleIndex="1">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="metric" Visible="False" VisibleIndex="2">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk01" VisibleIndex="3">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk02" VisibleIndex="4">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk03" VisibleIndex="5">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk04" VisibleIndex="6">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk05" VisibleIndex="7">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk06" VisibleIndex="8">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk07" VisibleIndex="9">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk08" VisibleIndex="10">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk09" VisibleIndex="11">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk10" VisibleIndex="12">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk11" VisibleIndex="13">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk12" VisibleIndex="14">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk13" VisibleIndex="15">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk14" VisibleIndex="16">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk15" VisibleIndex="17">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk16" VisibleIndex="18">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk17" VisibleIndex="19">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk18" VisibleIndex="20">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk19" VisibleIndex="21">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk20" VisibleIndex="22">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk21" VisibleIndex="23">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk22" VisibleIndex="24">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk23" VisibleIndex="25">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk24" VisibleIndex="26">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk25" VisibleIndex="27">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk26" VisibleIndex="28">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk27" VisibleIndex="29">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk28" VisibleIndex="30">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk29" VisibleIndex="31">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk30" VisibleIndex="32">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk31" VisibleIndex="33">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk32" VisibleIndex="34">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk33" VisibleIndex="35">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk34" VisibleIndex="36">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk35" VisibleIndex="37">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk36" VisibleIndex="38">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk37" VisibleIndex="39">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk38" VisibleIndex="40">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk39" VisibleIndex="41">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk40" VisibleIndex="42">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk41" VisibleIndex="43">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk42" VisibleIndex="44">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk43" VisibleIndex="45">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk4" VisibleIndex="46">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk45" VisibleIndex="47">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk46" VisibleIndex="48">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk47" VisibleIndex="49">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk48" VisibleIndex="50">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk49" VisibleIndex="51">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk50" VisibleIndex="52">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk51" VisibleIndex="53">
                    </dx:VerticalGridTextRow>
                    <dx:VerticalGridTextRow FieldName="wk52" VisibleIndex="54">
                    </dx:VerticalGridTextRow>
                </Rows>
                <Settings ShowCategoryIndents="False" />
<SettingsPager Mode="ShowPager" Visible="False"></SettingsPager>
                <SettingsEditing Mode="Batch">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
            </dx:ASPxVerticalGrid>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_MGRgoals_id], [metric], [wk01], [wk02], [wk03], [wk04], [wk05], [wk06], [wk07], [wk08], [wk09], [wk10], [wk11], [wk12], [wk13], [wk14], [wk15], [wk16], [wk17], [wk18], [wk19], [wk20], [wk21], [wk22], [wk23], [wk24], [wk25], [wk26], [wk27], [wk28], [wk29], [wk30], [wk31], [wk32], [wk33], [wk34], [wk35], [wk36], [wk37], [wk38], [wk39], [wk40], [wk41], [wk42], [wk43], [wk4], [wk45], [wk46], [wk47], [wk48], [wk49], [wk50], [wk51], [wk52] FROM [tbl_MGRgoals]" DeleteCommand="DELETE FROM [tbl_MGRgoals] WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id" InsertCommand="INSERT INTO [tbl_MGRgoals] ([metric], [wk01], [wk02], [wk03], [wk04], [wk05], [wk06], [wk07], [wk08], [wk09], [wk10], [wk11], [wk12], [wk13], [wk14], [wk15], [wk16], [wk17], [wk18], [wk19], [wk20], [wk21], [wk22], [wk23], [wk24], [wk25], [wk26], [wk27], [wk28], [wk29], [wk30], [wk31], [wk32], [wk33], [wk34], [wk35], [wk36], [wk37], [wk38], [wk39], [wk40], [wk41], [wk42], [wk43], [wk4], [wk45], [wk46], [wk47], [wk48], [wk49], [wk50], [wk51], [wk52]) VALUES (@metric, @wk01, @wk02, @wk03, @wk04, @wk05, @wk06, @wk07, @wk08, @wk09, @wk10, @wk11, @wk12, @wk13, @wk14, @wk15, @wk16, @wk17, @wk18, @wk19, @wk20, @wk21, @wk22, @wk23, @wk24, @wk25, @wk26, @wk27, @wk28, @wk29, @wk30, @wk31, @wk32, @wk33, @wk34, @wk35, @wk36, @wk37, @wk38, @wk39, @wk40, @wk41, @wk42, @wk43, @wk4, @wk45, @wk46, @wk47, @wk48, @wk49, @wk50, @wk51, @wk52)" UpdateCommand="UPDATE [tbl_MGRgoals] SET [metric] = @metric, [wk01] = @wk01, [wk02] = @wk02, [wk03] = @wk03, [wk04] = @wk04, [wk05] = @wk05, [wk06] = @wk06, [wk07] = @wk07, [wk08] = @wk08, [wk09] = @wk09, [wk10] = @wk10, [wk11] = @wk11, [wk12] = @wk12, [wk13] = @wk13, [wk14] = @wk14, [wk15] = @wk15, [wk16] = @wk16, [wk17] = @wk17, [wk18] = @wk18, [wk19] = @wk19, [wk20] = @wk20, [wk21] = @wk21, [wk22] = @wk22, [wk23] = @wk23, [wk24] = @wk24, [wk25] = @wk25, [wk26] = @wk26, [wk27] = @wk27, [wk28] = @wk28, [wk29] = @wk29, [wk30] = @wk30, [wk31] = @wk31, [wk32] = @wk32, [wk33] = @wk33, [wk34] = @wk34, [wk35] = @wk35, [wk36] = @wk36, [wk37] = @wk37, [wk38] = @wk38, [wk39] = @wk39, [wk40] = @wk40, [wk41] = @wk41, [wk42] = @wk42, [wk43] = @wk43, [wk4] = @wk4, [wk45] = @wk45, [wk46] = @wk46, [wk47] = @wk47, [wk48] = @wk48, [wk49] = @wk49, [wk50] = @wk50, [wk51] = @wk51, [wk52] = @wk52 WHERE [tbl_MGRgoals_id] = @tbl_MGRgoals_id">
                <DeleteParameters>
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="wk01" Type="String" />
                    <asp:Parameter Name="wk02" Type="String" />
                    <asp:Parameter Name="wk03" Type="String" />
                    <asp:Parameter Name="wk04" Type="String" />
                    <asp:Parameter Name="wk05" Type="String" />
                    <asp:Parameter Name="wk06" Type="String" />
                    <asp:Parameter Name="wk07" Type="String" />
                    <asp:Parameter Name="wk08" Type="String" />
                    <asp:Parameter Name="wk09" Type="String" />
                    <asp:Parameter Name="wk10" Type="String" />
                    <asp:Parameter Name="wk11" Type="String" />
                    <asp:Parameter Name="wk12" Type="String" />
                    <asp:Parameter Name="wk13" Type="String" />
                    <asp:Parameter Name="wk14" Type="String" />
                    <asp:Parameter Name="wk15" Type="String" />
                    <asp:Parameter Name="wk16" Type="String" />
                    <asp:Parameter Name="wk17" Type="String" />
                    <asp:Parameter Name="wk18" Type="String" />
                    <asp:Parameter Name="wk19" Type="String" />
                    <asp:Parameter Name="wk20" Type="String" />
                    <asp:Parameter Name="wk21" Type="String" />
                    <asp:Parameter Name="wk22" Type="String" />
                    <asp:Parameter Name="wk23" Type="String" />
                    <asp:Parameter Name="wk24" Type="String" />
                    <asp:Parameter Name="wk25" Type="String" />
                    <asp:Parameter Name="wk26" Type="String" />
                    <asp:Parameter Name="wk27" Type="String" />
                    <asp:Parameter Name="wk28" Type="String" />
                    <asp:Parameter Name="wk29" Type="String" />
                    <asp:Parameter Name="wk30" Type="String" />
                    <asp:Parameter Name="wk31" Type="String" />
                    <asp:Parameter Name="wk32" Type="String" />
                    <asp:Parameter Name="wk33" Type="String" />
                    <asp:Parameter Name="wk34" Type="String" />
                    <asp:Parameter Name="wk35" Type="String" />
                    <asp:Parameter Name="wk36" Type="String" />
                    <asp:Parameter Name="wk37" Type="String" />
                    <asp:Parameter Name="wk38" Type="String" />
                    <asp:Parameter Name="wk39" Type="String" />
                    <asp:Parameter Name="wk40" Type="String" />
                    <asp:Parameter Name="wk41" Type="String" />
                    <asp:Parameter Name="wk42" Type="String" />
                    <asp:Parameter Name="wk43" Type="String" />
                    <asp:Parameter Name="wk4" Type="String" />
                    <asp:Parameter Name="wk45" Type="String" />
                    <asp:Parameter Name="wk46" Type="String" />
                    <asp:Parameter Name="wk47" Type="String" />
                    <asp:Parameter Name="wk48" Type="String" />
                    <asp:Parameter Name="wk49" Type="String" />
                    <asp:Parameter Name="wk50" Type="String" />
                    <asp:Parameter Name="wk51" Type="String" />
                    <asp:Parameter Name="wk52" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="metric" Type="String" />
                    <asp:Parameter Name="wk01" Type="String" />
                    <asp:Parameter Name="wk02" Type="String" />
                    <asp:Parameter Name="wk03" Type="String" />
                    <asp:Parameter Name="wk04" Type="String" />
                    <asp:Parameter Name="wk05" Type="String" />
                    <asp:Parameter Name="wk06" Type="String" />
                    <asp:Parameter Name="wk07" Type="String" />
                    <asp:Parameter Name="wk08" Type="String" />
                    <asp:Parameter Name="wk09" Type="String" />
                    <asp:Parameter Name="wk10" Type="String" />
                    <asp:Parameter Name="wk11" Type="String" />
                    <asp:Parameter Name="wk12" Type="String" />
                    <asp:Parameter Name="wk13" Type="String" />
                    <asp:Parameter Name="wk14" Type="String" />
                    <asp:Parameter Name="wk15" Type="String" />
                    <asp:Parameter Name="wk16" Type="String" />
                    <asp:Parameter Name="wk17" Type="String" />
                    <asp:Parameter Name="wk18" Type="String" />
                    <asp:Parameter Name="wk19" Type="String" />
                    <asp:Parameter Name="wk20" Type="String" />
                    <asp:Parameter Name="wk21" Type="String" />
                    <asp:Parameter Name="wk22" Type="String" />
                    <asp:Parameter Name="wk23" Type="String" />
                    <asp:Parameter Name="wk24" Type="String" />
                    <asp:Parameter Name="wk25" Type="String" />
                    <asp:Parameter Name="wk26" Type="String" />
                    <asp:Parameter Name="wk27" Type="String" />
                    <asp:Parameter Name="wk28" Type="String" />
                    <asp:Parameter Name="wk29" Type="String" />
                    <asp:Parameter Name="wk30" Type="String" />
                    <asp:Parameter Name="wk31" Type="String" />
                    <asp:Parameter Name="wk32" Type="String" />
                    <asp:Parameter Name="wk33" Type="String" />
                    <asp:Parameter Name="wk34" Type="String" />
                    <asp:Parameter Name="wk35" Type="String" />
                    <asp:Parameter Name="wk36" Type="String" />
                    <asp:Parameter Name="wk37" Type="String" />
                    <asp:Parameter Name="wk38" Type="String" />
                    <asp:Parameter Name="wk39" Type="String" />
                    <asp:Parameter Name="wk40" Type="String" />
                    <asp:Parameter Name="wk41" Type="String" />
                    <asp:Parameter Name="wk42" Type="String" />
                    <asp:Parameter Name="wk43" Type="String" />
                    <asp:Parameter Name="wk4" Type="String" />
                    <asp:Parameter Name="wk45" Type="String" />
                    <asp:Parameter Name="wk46" Type="String" />
                    <asp:Parameter Name="wk47" Type="String" />
                    <asp:Parameter Name="wk48" Type="String" />
                    <asp:Parameter Name="wk49" Type="String" />
                    <asp:Parameter Name="wk50" Type="String" />
                    <asp:Parameter Name="wk51" Type="String" />
                    <asp:Parameter Name="wk52" Type="String" />
                    <asp:Parameter Name="tbl_MGRgoals_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
