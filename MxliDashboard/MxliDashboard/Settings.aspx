<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="MxliDashboard.Settings" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function onShowHideInfoClick(s, e) {
            var contactLayoutGroup = clientGrid.GetEditFormLayoutItemOrGroup("groupContactInfo");
            var isContactLayoutGroupVisible = contactLayoutGroup.GetVisible();
            s.SetText(isContactLayoutGroupVisible ? "Show Details..." : "Hide Details");
            contactLayoutGroup.SetVisible(!isContactLayoutGroupVisible);
        }
    </script>
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
                                <dx:ASPxLabel ID="ASPxLabelCaptionT" runat="server" Text="Select metric type:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox runat="server" ID="CmbType" DropDownStyle="DropDownList" AutoPostBack="True">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="AREA" Value="AREA" />
                                        <dx:ListEditItem Selected="False" Text="METRIC" Value="METRIC" />
                                    </Items>
                                    <%--<ClientSideEvents SelectedIndexChanged="function(s, e) { OnTypeChanged(s); }"></ClientSideEvents>--%>
                                </dx:ASPxComboBox>
                            </th>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSourceMetric" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                        SelectCommand="SELECT svalue FROM tbl_settings WHERE stype like @param1 order by svalue">
                        <SelectParameters>
                            <asp:Parameter Name="param1" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>        
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMgrGoals" EnableTheming="True" KeyFieldName="tbl_MGRgoals_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
            <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
            </SettingsPager>
            <SettingsEditing EditFormColumnCount="4" Mode="PopupEditForm">
            </SettingsEditing>
            <SettingsDataSecurity AllowDelete="False" />
            <SettingsPopup>
                <EditForm Modal="True" Width="750px" SettingsAdaptivity-Mode="OnWindowInnerWidth">
                </EditForm>
            </SettingsPopup>
            <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                </SettingsAdaptivity>
                <Items>
                <dx:GridViewTabbedLayoutGroup>
                    <Items>
                        <dx:GridViewLayoutGroup ColumnCount="2" Caption="Employee Information">
                            <Items>
                <dx:GridViewLayoutGroup GroupBoxDecoration="None" ColumnSpan="2" Name="groupContactInfo" ClientVisible="false" Paddings-PaddingTop="0">
                                    <Items>
                                        <dx:GridViewColumnLayoutItem ColumnName="Address" />
                                        <dx:GridViewColumnLayoutItem ColumnName="Notes" Width="100%" />
                                    </Items>
                                </dx:GridViewLayoutGroup>
                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColumnSpan="2">
                                    <Template>
                                        <dx:ASPxHyperLink runat="server" ID="hlShowHideInfo" Text="Show Details..." Cursor="pointer" Width="100">
                                            <ClientSideEvents Click="onShowHideInfoClick" />
                                        </dx:ASPxHyperLink>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>
                                </Items>
                            </dx:GridViewLayoutGroup>
                        </Items>
                    </dx:GridViewTabbedLayoutGroup>
                    </Items>
            </EditFormLayoutProperties>
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="tbl_MGRgoals_id" ReadOnly="True" VisibleIndex="1" Caption="#">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="metric" VisibleIndex="2" Caption="METRIC">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="metricDesc" VisibleIndex="4" Caption="GoalType" >
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="gType" VisibleIndex="3" Caption="TYPE">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="gUnit" VisibleIndex="5" Caption="GoalUnit">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="gJan" VisibleIndex="6" Caption="JAN">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gFeb" VisibleIndex="7" Caption="FEB">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gMar" VisibleIndex="8" Caption="MAR">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gMay" VisibleIndex="10" Caption="MAY">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gJun" VisibleIndex="11" Caption="JUN">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gJul" VisibleIndex="12" Caption="JUL">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gAug" VisibleIndex="13" Caption="AUG">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gSep" VisibleIndex="14" Caption="SEP">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gOct" VisibleIndex="15" Caption="OCT">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gNov" VisibleIndex="16" Caption="NOV">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gDec" VisibleIndex="17" Caption="DEC">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gQ1" Visible="False" VisibleIndex="18">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gQ2" Visible="False" VisibleIndex="19">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gQ3" Visible="False" VisibleIndex="20">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gQ4" Visible="False" VisibleIndex="21">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ01" Visible="False" VisibleIndex="22">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ02" Visible="False" VisibleIndex="23">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ03" Visible="False" VisibleIndex="24">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ04" Visible="False" VisibleIndex="25">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ05" Visible="False" VisibleIndex="26">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ06" Visible="False" VisibleIndex="27">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ08" Visible="False" VisibleIndex="28">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ09" Visible="False" VisibleIndex="29">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ10" Visible="False" VisibleIndex="30">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ11" Visible="False" VisibleIndex="31">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ12" Visible="False" VisibleIndex="32">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ13" Visible="False" VisibleIndex="33">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ14" Visible="False" VisibleIndex="34">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ15" Visible="False" VisibleIndex="35">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ16" Visible="False" VisibleIndex="36">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ17" Visible="False" VisibleIndex="37">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ18" Visible="False" VisibleIndex="38">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ19" Visible="False" VisibleIndex="39">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ20" Visible="False" VisibleIndex="40">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ21" Visible="False" VisibleIndex="41">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ22" Visible="False" VisibleIndex="42">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ23" Visible="False" VisibleIndex="43">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ24" Visible="False" VisibleIndex="44">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ25" Visible="False" VisibleIndex="45">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ26" Visible="False" VisibleIndex="46">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ27" Visible="False" VisibleIndex="47">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ28" Visible="False" VisibleIndex="48">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ29" Visible="False" VisibleIndex="49">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ30" Visible="False" VisibleIndex="50">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ31" Visible="False" VisibleIndex="51">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ32" Visible="False" VisibleIndex="52">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ33" Visible="False" VisibleIndex="53">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ34" Visible="False" VisibleIndex="54">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ35" Visible="False" VisibleIndex="55">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ36" Visible="False" VisibleIndex="56">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ37" Visible="False" VisibleIndex="57">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ38" Visible="False" VisibleIndex="58">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ39" Visible="False" VisibleIndex="59">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ40" Visible="False" VisibleIndex="60">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ41" Visible="False" VisibleIndex="61">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ42" Visible="False" VisibleIndex="62">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ43" Visible="False" VisibleIndex="63">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ44" Visible="False" VisibleIndex="64">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ45" Visible="False" VisibleIndex="65">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ46" Visible="False" VisibleIndex="66">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ47" Visible="False" VisibleIndex="67">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ48" Visible="False" VisibleIndex="68">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ49" Visible="False" VisibleIndex="69">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ50" Visible="False" VisibleIndex="70">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ51" Visible="False" VisibleIndex="71">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="wQ52" Visible="False" VisibleIndex="72">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gYear" Visible="False" VisibleIndex="73">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nYear" Visible="False" VisibleIndex="74">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="gApr" VisibleIndex="9" Caption="APR">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSourceMgrGoals" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT [tbl_MGRgoals_id], [metric], [metricDesc], [gType], [gUnit], [gJan], [gFeb], [gMar], [gApr], [gMay], [gJun], [gJul], [gAug], [gSep], [gOct], [gNov], [gDec], [gQ1], [gQ2], [gQ3], [gQ4], [wQ01], [wQ02], [wQ03], [wQ04], [wQ05], [wQ06], [wQ07], [wQ08], [wQ09], [wQ10], [wQ11], [wQ12], [wQ13], [wQ14], [wQ15], [wQ16], [wQ17], [wQ18], [wQ19], [wQ20], [wQ21], [wQ22], [wQ23], [wQ24], [wQ25], [wQ26], [wQ27], [wQ28], [wQ29], [wQ30], [wQ31], [wQ32], [wQ33], [wQ34], [wQ35], [wQ36], [wQ37], [wQ38], [wQ39], [wQ40], [wQ41], [wQ42], [wQ43], [wQ44], [wQ45], [wQ46], [wQ47], [wQ48], [wQ49], [wQ50], [wQ51], [wQ52], [gYear], [nYear] FROM [tbl_MGRgoals] where gtype like @paramT">
            <SelectParameters>
                <asp:ControlParameter ControlID="ASPxRoundPanel1$CmbType" Name="paramT" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <p></p>
    <hr />
    <p></p>
    
</asp:Content>
