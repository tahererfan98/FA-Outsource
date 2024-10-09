<%@ Page language="C#" autoeventwireup="true" codebehind="ReportViewer.aspx.cs" inherits="BombayTools.Reports.ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
            <asp:updatepanel id="updatepanel1" runat="server">
            <ContentTemplate>
                <rsweb:ReportViewer ID="ReportViewer1" Height="97%" runat="server" ShowZoomControl="true" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BorderColor="#D0D1D7" BorderStyle="Solid" BorderWidth="2px" PageCountMode="Actual">
 
                </rsweb:ReportViewer>
            </ContentTemplate>
        </asp:updatepanel>
        </div>
    </form>
</body>
</html>
