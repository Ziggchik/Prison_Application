<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrisonBlock.aspx.cs" Inherits="PrisonApplication.PrisonBlock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .tb_Style {}
    </style>
</head>
<body>
   <link rel ="stylesheet" href ="CSSSaleSite.css" />
    <form id="TypeProductPage" runat="server">
        <asp:SqlDataSource ID ="sdsBlock" runat ="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat="server" CssClass ="font_style" Text ="Список блоков"></asp:Label>
        </center>
        <div style ="overflow : unset">
            <div style ="float : left">
                 <asp:Label ID ="lbNameOfTypeWeapon" runat ="server" CssClass ="font_style" Text ="Название блока"></asp:Label>
                <br>
                <asp:TextBox ID ="tbName_of_Type" runat ="server" CssClass ="tb_Style" Text ="Введите новый блок" Width="146px"
                    ></asp:TextBox><br>
                <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новый тип" OnClick="btInsert_Click" /><br>
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить тип" OnClick="btUpdate_Click" /><br>
                <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить тип" OnClick="btDelete_Click" /><br>
                <asp:Button ID = "btBack" runat ="server" CssClass ="bt_Style" 
                    Text ="Назад" OnClick="btBack_Click"  /><br>
        <div>
        </div>
                 <asp:ListBox ID ="lbBlock" runat ="server" CssClass ="font_style" Width="221px" ></asp:ListBox>
                <br>
                <asp:Button ID="btSelect" runat ="server" CssClass="bt_Style"  Text ="Выбрать запись" OnClick="btSelect_Click" />
        <div>
        </div>
    </form>
</body>
</html>
