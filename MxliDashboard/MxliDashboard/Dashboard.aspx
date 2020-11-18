<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MxliDashboard.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <p></p>
            <div class="row">
                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views" ForeColor="Black" AllowCollapsingByHeaderClick="True">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <table style="table-layout: fixed">
                                <tr>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Tier view:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxVF" runat="server" ValueType="System.String" AutoPostBack="True"
                                            OnSelectedIndexChanged="ASPxComboBoxVF_SelectedIndexChanged">
                                            <Items>
                                                <dx:ListEditItem Selected="True" Text="All" Value="0" />
                                                <dx:ListEditItem Text="T1" Value="1" />
                                                <dx:ListEditItem Text="T2" Value="2" />
                                                <dx:ListEditItem Text="T3" Value="3" />
                                                <dx:ListEditItem Text="TFunction" Value="4" />
                                                <dx:ListEditItem Text="WarRoom" Value="5" />
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
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
            <p></p>
            <div>
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="NOVEMBER" Font-Size="XX-Large" ForeColor="#C20406"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" Width="1180px" OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText">
                    <SettingsPager Visible="False" PageSize="50">
                    </SettingsPager>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="METRIC" FieldName="smetric" VisibleIndex="0" Width="150px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="YTD Plan" FieldName="factual" VisibleIndex="1" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="YTD Actual" FieldName="fgoal" VisibleIndex="2" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="NOV Plan" FieldName="factual" VisibleIndex="3" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="NOV Actual" FieldName="fgoal" VisibleIndex="4" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="STATUS" VisibleIndex="5" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="TREND" VisibleIndex="6" Width="70px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="HIGHLIGHTS" VisibleIndex="7" Width="460px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="DETAILS" FieldName="smetric" VisibleIndex="8" Width="70px">
                            <PropertiesHyperLinkEdit NavigateUrlFormatString = "~/n3_quality/{0}.aspx" Text="View Details" Style-HorizontalAlign="Center" > 
                                <Style HorizontalAlign="Center">
                                </Style>
                            </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="REPORT" FieldName="smetric" VisibleIndex="8" Width="80px">
                            <PropertiesHyperLinkEdit NavigateUrlFormatString = "n3_etad/v_kaizens.aspx" Text="View Report" Style-HorizontalAlign="Center" > 
                                <Style HorizontalAlign="Center">
                                </Style>
                            </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                    </Columns>
                    <Styles>
                        <Header BackColor="#666666" Border-BorderColor="White" Border-BorderStyle="Solid" Border-BorderWidth="3px" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center">
                        </Header>
                        <Row Font-Size="Medium">
                        </Row>
                        <AlternatingRow BackColor="#F3F3F3">
                        </AlternatingRow>
                    </Styles>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" SelectCommand="
                    SELECT [smetric], [factual], [fgoal] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] where sfilter = 'site' and stype = 'yearly'
                "></asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
