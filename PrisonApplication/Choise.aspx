<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Choise.aspx.cs" Inherits="PrisonApplication.Choise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <asp:Button ID ="btPrisoners" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Заключённые" OnClick="btPrisoners_Click" />
            <asp:Button ID ="btGuardians" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Охранники" OnClick="btGuardians_Click" />
            <asp:Button ID ="btWeapons" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Оружие" OnClick="btWeapons_Click" />
            <asp:Button ID ="btTypeWeapon" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Типы оружия" OnClick="btTypeWeapon_Click" />
            <asp:Button ID ="btBlock" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Тюремный блок" OnClick="btBlock_Click" />
            <asp:Button ID ="btNakladnaya" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Накладная" OnClick="btNakladnaya_Click"/>
            <asp:Button ID ="btBack" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Вернутся на авторизацию" OnClick="btBack_Click" />
         </center>
        <div>
        </div>
    </form>
</body>
</html>
