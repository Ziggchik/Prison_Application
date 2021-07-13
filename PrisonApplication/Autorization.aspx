<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autorization.aspx.cs" Inherits="PrisonApplication.Autorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script type ="text/javascript">
            if ((navigator.userAgent.indexOf("Microsoft Edge") || navigator.userAgent.indexOf('OPR')) != -1) {
                alert('Microsoft Edge');
            }
            else if (navigator.userAgent.indexOf("Chrome") != -1) {
                alert('Chrome');
            }
            else if (navigator.userAgent.indexOf("Safari") != -1) {
                alert('Safari');
            }
            else if (navigator.userAgent.indexOf("Firefox") != -1) {
                alert('Firefox');
            }
            else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
            {
                alert('IE');
            }
            else {
                alert('unknown');
            }
    </script>
     <%--<link rel ="stylesheet" href ="StyleSheet1.css" />--%>
    <form id="form1" runat="server">
       
        <center>
        <div class ="sizeChanged">
        <asp:Label ID ="lblTitle" runat ="server" 
                Text ="Авторизация"></asp:Label> 
            <br>
            <br>
            <br>
            <asp:Label ID ="lblSecrtnoeSlovo" runat ="server" Text ="Секретное слово"
               ></asp:Label>
            <br>
            <asp:TextBox id="tbSecrtnoeSlovo" runat ="server" TextMode ="Password"
                ></asp:TextBox>
             <br>
            <br>
            <asp:Button ID ="btEnter" runat ="server" Text ="Войти" 
              OnClick="btEnter_Click" />
        <div>
        </div>
    </form>
</body>
</html>
