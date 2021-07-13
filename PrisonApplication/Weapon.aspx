<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weapon.aspx.cs" Inherits="PrisonApplication.Weapon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:SqlDataSource ID="sdsWeapon" runat ="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsTypeWeapon" runat ="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsNakladnaya" runat ="server"></asp:SqlDataSource>
    <form id="Prison" runat="server">
        <center>
          <asp:Label ID ="lblTitle" runat = "server" Text =  "Оружие"
            font-Size = "20" Font-Names = "Arial"></asp:label>
        </center>
        <div>
            <center>
              <asp:GridView ID="gvWeapon" runat ="server" Font-Size="16"
              Font-Names ="Arial" OnRowDataBound="gvWeapon_RowDataBound" OnSelectedIndexChanged="gvWeapon_SelectedIndexChanged" AllowSorting="True" OnSorting="gvWeapon_Sorting">
                  <Columns>
                    <asp:CommandField ShowSelectButton ="true" />
                  </Columns>
              </asp:GridView>
            </center>
        </div>
        <br>
        <div>
             <asp:Label ID ="lblSearch" runat ="server" 
                      Font-Size="14" Font-Names="Arial"  Text ="Введите значение для поиска" ></asp:Label>
             <asp:TextBox ID="tbSearch" runat ="server" 
                        CssClass ="tb_Style"></asp:TextBox>
             <br />
            <br>
            <asp:Label ID="lblWeaponName" runat ="server"
                Font-Size="14" Font-Names="Arial" Text="Название оружия"></asp:Label>
            <br>
            <asp:TextBox ID="tbWeaponName" runat ="server" style="margin-left: 0px"></asp:TextBox>
            <br>
            <asp:Label ID ="Label1" runat ="server" 
                      Font-Size="14" Font-Names="Arial"  Text ="Типы оружий" ></asp:Label>
            <br>
            <asp:ListBox ID ="lbType_Of_Weapon" runat ="server" CssClass ="font_style" Width="221px" ></asp:ListBox>
             <br>
            <asp:Label ID ="Label2" runat ="server" 
                      Font-Size="14" Font-Names="Arial"  Text ="Накладные" ></asp:Label>
            <br>
            <asp:ListBox ID ="lbNakladnaya" runat ="server" CssClass ="font_style" Width="221px" ></asp:ListBox>
            <br>
            <asp:Label ID="LabelGuardian" runat ="server"
                Font-Size="14" Font-Names="Arial" Text="Охранники
                "></asp:Label>
            <br >
             <asp:ListBox ID ="lbGuardians" runat ="server" CssClass ="font_style" Width="221px" ></asp:ListBox>
                <br>
             <br />
            <br>
        </div>
            <center>
                <asp:Button ID ="btInsert" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Добавить оружие" OnClick="btInsert_Click"/>
                <asp:Button ID ="btUpdate" runat ="server" Font-Size ="12" CommandName="Arial"
                    Text="Изменить данные об оружии" OnClick="btUpdate_Click"/>
                <asp:Button ID ="btDelete" runat ="server" Font-Size ="12" CommandName="Arial"
                    Text="Удалить оружие" OnClick="btDelete_Click"/>
                 <asp:Button ID ="btSearch" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Поиск" OnClick="btSearch_Click"/>
                 <asp:Button ID ="btFilter" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Фильтр" OnClick="btFilter_Click" />
                 <asp:Button ID ="btCancel" runat ="server" Font-Size ="12" CommandNames="Arial"
                         Text ="Отмена" OnClick="btCancel_Click" />
                <asp:Button ID ="btBack" runat ="server" Font-Size ="12" CommandName="Arial"
                    Text="To a hell and back(назад)" OnClick="btBack_Click" />
            </center>
        <div>
        </div>
    </form>
</body>
</html>
