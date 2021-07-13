<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guardians.aspx.cs" Inherits="PrisonApplication.Guardians" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:SqlDataSource ID="sdsGuardians" runat ="server"></asp:SqlDataSource>
    <form id="Guardians" runat="server">
        <center>
          <asp:Label ID ="lblTitle" runat = "server" Text =  "Список охранников"
            font-Size = "20" Font-Names = "Arial"></asp:label>
        </center>
        <div>
            <center>
              <asp:GridView ID="gvGuardians" runat ="server" Font-Size="16"
              Font-Names ="Arial" OnRowDataBound="gvGuardians_RowDataBound" OnSelectedIndexChanged="gvGuardians_SelectedIndexChanged" AllowSorting="True" OnSorting="gvGuardians_Sorting">
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
            <br />
            <asp:Label ID="lblFirstName" runat ="server"
                Font-Size="14" Font-Names="Arial" Text="Фамилия охранника"></asp:Label>
            <br>
            <asp:TextBox ID="tbFirstName" runat ="server"></asp:TextBox>
            <br>
            <asp:Label ID="lblName" runat ="server"
                Font-Size="14" Font-Names="Arial" Text="Имя охранника"></asp:Label>
            <br>
            <asp:TextBox ID="tbName" runat ="server"></asp:TextBox>
            <br>
            <asp:Label ID="lblMiddleName" runat ="server"
                Font-Size="14" Font-Names="Arial" Text="Отчество охранника"></asp:Label>
            <br>
            <asp:TextBox ID="tbMiddleName" runat ="server"></asp:TextBox>
            <br>
        </div>
            <center>
                <asp:Button ID ="btInsert" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Добавить охранника" OnClick="btInsert_Click" style="height: 29px" />
                <asp:Button ID ="btUpdate" runat ="server" Font-Size ="12" CommandName="Arial"
                    Text="Изменить данные об охраннике" OnClick="btUpdate_Click" />
                <asp:Button ID ="btDelete" runat ="server" Font-Size ="12" CommandName="Arial"
                    Text="Удалить охранника" OnClick="btDelete_Click"/>
                <asp:Button ID ="btSearch" runat ="server" Font-Size ="12" CommandNames="Arial"
                    Text="Поиск" OnClick="btSearch_Click" />
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
