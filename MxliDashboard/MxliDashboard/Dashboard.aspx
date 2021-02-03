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
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Function view:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxVF" runat="server" ValueType="System.String" DataSourceID="SqlDataSourceVF" ValueField="sfunc" TextField="sfunc"
                                            OnSelectedIndexChanged="ASPxComboBoxVF_SelectedIndexChanged" OnDataBound="cmbox_DataBoundVF" AutoPostBack="True">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One View&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False"></ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>       
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Select VSM:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxTV" runat="server" ValueType="System.String" OnSelectedIndexChanged="ASPxComboBoxTV_SelectedIndexChanged" AutoPostBack="True">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One VSM&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False"></ValidationSettings>
                                            <Items>
                                                <dx:ListEditItem Selected="true" Text="All" Value="1" />
                                                <dx:ListEditItem Text="Buy Parts" Value="2" />
                                                <dx:ListEditItem Text="EP&A" Value="3" />
                                                <dx:ListEditItem Text="Heat Transfer" Value="4" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </th>                                    
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVF" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" 
                SelectCommand="SELECT distinct [sfunc] FROM [tbl_settings] where [stype] = 'DASHBOARD' order by sfunc"></asp:SqlDataSource>
            </div>
            <p></p>
            <div>
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="JANUARY" Font-Size="XX-Large" ForeColor="#C20406"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" ViewStateMode="Disabled" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" Width="1180px" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" >
                    <SettingsPager Visible="False" PageSize="50">
                    </SettingsPager>
                    <Settings VerticalScrollableHeight="640" VerticalScrollBarMode="Visible" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="METRIC" FieldName="smetric" VisibleIndex="0" Width="11%">
                            <CellStyle Font-Size="Medium" HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="MONTH Actual" VisibleIndex="1" Width="10%">
                            <CellStyle Font-Size="Medium" HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="MONTH Plan" VisibleIndex="2" Width="10%">
                            <CellStyle Font-Size="Medium" HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="YTD Actual"  VisibleIndex="3" Width="8%">
                            <CellStyle Font-Size="Medium" HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="YTD Plan" VisibleIndex="4" Width="8%">
                            <CellStyle Font-Size="Medium" HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="STATUS" VisibleIndex="5" Width="7%">
                            <DataItemTemplate>
                                <dx:ASPxImage runat="server" ID="imgControl" Width="24px" Height="24px" EnableViewState="true" />
                            </DataItemTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataMemoColumn Caption="HIGHLIGHTS" VisibleIndex="6" Width="25%">
                        </dx:GridViewDataMemoColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="DETAILS" FieldName="sUrl" VisibleIndex="7" Width="7%">
                            <PropertiesHyperLinkEdit NavigateUrlFormatString = "{0}" Text="View" Style-HorizontalAlign="Center" ImageHeight="50px" ImageUrl="~/img/table.png" Target="_blank">
                                <Style HorizontalAlign="Center">
                                </Style>
                            </PropertiesHyperLinkEdit>
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="REPORT" FieldName="sReport" VisibleIndex="8" Width="7%">
                            <PropertiesHyperLinkEdit NavigateUrlFormatString = "{0}" Text="Open" Style-HorizontalAlign="Center" ImageHeight="50px" ImageUrl="~/img/chart.png" Target="_blank">
                                <Style HorizontalAlign="Center">
                                </Style>
                            </PropertiesHyperLinkEdit>
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataHyperLinkColumn>                                        
                        <dx:GridViewDataDateColumn Caption="UPDATED" VisibleIndex="9" Width="7%">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                    </Columns>
                    <Styles>
                        <Header BackColor="#666666" Border-BorderColor="White" Border-BorderStyle="Solid" Border-BorderWidth="3px" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center">
                        </Header>
                        <Row Font-Size="Medium">
                        </Row>
                        <AlternatingRow BackColor="#F3F3F3">
                        </AlternatingRow>
                        <Cell Font-Size="Small">
                        </Cell>
                    </Styles>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                    SelectCommand="SELECT DISTINCT a.[smetric], b.[sFunc], b.[sUrl], b.[sReport] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] a, [DB_1033_Dashboard].[dbo].[tbl_settings] b  
                                    where a.[smetric] = b.sValue
                                    and b.[sType] = 'DASHBOARD'
                                    and b.[sFunc] like @param1
                                    and a.[smetric] in (select mname from tbl_set_tierviews)
                                    order by a.smetric">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVF"
                            Name="param1" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                    SelectCommand="SELECT DISTINCT a.[smetric], b.[sFunc], b.[sUrl], b.[sReport] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] a, [DB_1033_Dashboard].[dbo].[tbl_settings] b  
                                    where a.[smetric] = b.sValue
                                    and b.[sType] = 'DASHBOARD'
                                    and b.[sFunc] like @param1
                                    and a.[smetric] in (select mname from tbl_set_tierviews where vt1 = 'true')
                                    order by a.smetric">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVF"
                            Name="param1" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                    SelectCommand="SELECT DISTINCT a.[smetric], b.[sFunc], b.[sUrl], b.[sReport] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] a, [DB_1033_Dashboard].[dbo].[tbl_settings] b  
                                    where a.[smetric] = b.sValue
                                    and b.[sType] = 'DASHBOARD'
                                    and b.[sFunc] like @param1
                                    and a.[smetric] in (select mname from tbl_set_tierviews where vt2 = 'true')
                                    order by a.smetric">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVF"
                            Name="param1" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                    SelectCommand="SELECT DISTINCT a.[smetric], b.[sFunc], b.[sUrl], b.[sReport] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] a, [DB_1033_Dashboard].[dbo].[tbl_settings] b  
                                    where a.[smetric] = b.sValue
                                    and b.[sType] = 'DASHBOARD'
                                    and b.[sFunc] like @param1
                                    and a.[smetric] in (select mname from tbl_set_tierviews where vt3 = 'true')
                                    order by a.smetric">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVF"
                            Name="param1" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>"
                    SelectCommand="SELECT DISTINCT a.[smetric], b.[sFunc], b.[sUrl], b.[sReport] FROM [DB_1033_Dashboard].[dbo].[sta_nivel2] a, [DB_1033_Dashboard].[dbo].[tbl_settings] b  
                                    where a.[smetric] = b.sValue
                                    and b.[sType] = 'DASHBOARD'
                                    and b.[sFunc] like @param1
                                    and a.[smetric] in (select mname from tbl_set_tierviews where vwr = 'true')
                                    order by a.smetric">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxRoundPanel1$ASPxComboBoxVF"
                            Name="param1" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
