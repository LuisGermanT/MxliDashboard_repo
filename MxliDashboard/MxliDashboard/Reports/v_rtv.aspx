﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="v_rtv.aspx.cs" Inherits="MxliDashboard.v_rtv" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">  
    .dxrd-preview .dxrd-right-panel-collapse, .dxrd-preview .dxrd-right-panel, .dxrd-preview .dxrd-right-tabs {  
        display: none;  
    }  

</style>  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" ColorScheme="softblue" ReportSourceId="r_rtv" DisableHttpHandlerValidation="False">
        </dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
