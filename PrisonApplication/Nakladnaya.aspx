<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nakladnaya.aspx.cs" Inherits="PrisonApplication.Nakladnaya" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <link rel ="stylesheet" href ="CSSSaleSite.css" />
    <form id="NakladnayaPage" runat="server">
        <asp:SqlDataSource ID ="sdsTypeNakladnaya" runat ="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat="server" CssClass ="font_style" Text ="Список накладных"></asp:Label>
        </center>
        <div style ="overflow : unset">
            <div style ="float : left">
                 <asp:Label ID ="lbNameNakladnaya" runat ="server" CssClass ="font_style" Text ="Название оружия"></asp:Label>
                <br>
                <asp:TextBox ID ="tbNameNakladnaya" runat ="server" CssClass ="tb_Style" Text ="Введите номер накладной" Width="184px"
                    ></asp:TextBox><br>
                <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новую накладную" OnClick="btInsert_Click"/><br>

                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить наклданую" OnClick="btUpdate_Click"/><br>
                <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить наклданую" OnClick="btDelete_Click"  /><br>
                <asp:Button ID = "btBack" runat ="server" CssClass ="bt_Style" 
                    Text ="Назад" OnClick="btBack_Click" /><br>
        <div>
        </div>
                 <asp:ListBox ID ="lbNakladnaya" runat ="server" CssClass ="font_style" Width="221px" ></asp:ListBox>
                <br>
                <asp:Button ID="btSelect" runat ="server" CssClass="bt_Style"
                     Text ="Выбрать" OnClick="btSelect_Click"/>
    </form>
</body>
</html>
