<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="set_actions.aspx.cs" Inherits="MxliDashboard.set_actions" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <div class="row">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Actions Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True">
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
    <div class="row" id="METRIC_ACTIONS" runat="server" visible="False">       
        <p>
            <asp:Label ID="Label1" runat="server" Text="ACTIONS CATALOGS"></asp:Label>
        </p>
        <div class="row" id="Div1" runat="server" visible="TRUE">
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAct" EnableTheming="True" KeyFieldName="tbl_set_actions_id" Theme="Mulberry" Width="100%" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize">
                <SettingsPager Visible="False" AlwaysShowPager="True" Mode="ShowAllRecords">
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="5" Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" />
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
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowNewButtonInHeader="True">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="tbl_set_actions_id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="metric" VisibleIndex="2" Caption="METRIC">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn  Caption="TYPE" FieldName="sType" VisibleIndex="3">
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="DESCRIPTION" FieldName="sDesc" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceAct" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                SelectCommand="SELECT [tbl_set_actions_id], [metric], [sType], [sDesc] FROM [tbl_set_actions] where [metric] = @param1"
                UpdateCommand="UPDATE [tbl_set_actions] SET [sType] = @sType, [sDesc] = @sDesc WHERE [tbl_set_actions_id] = @tbl_set_actions_id"
                InsertCommand="INSERT into[tbl_set_actions]([metric],[sType],[sDesc]) values(@param1, @sType, @sDesc)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sType" Type="String" />
                    <asp:Parameter Name="sDesc" Type="String" />
                    <asp:Parameter Name="tbl_set_actions_id" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxF1"
                        Name="param1" PropertyName="Value" Type="String" />
                    <asp:Parameter Name="sType" Type="String" />
                    <asp:Parameter Name="sDesc" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
        </div>
        <p></p>

    </div>

</asp:Content>
