<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColocarUnidades.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.ColocarUnidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>satelites</asp:ListItem>
            <asp:ListItem>aviones</asp:ListItem>
            <asp:ListItem>barcos</asp:ListItem>
            <asp:ListItem>submarinos</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Mostrar" />
        <br />
        <br />
        Unidades restantes para ese nivel:
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="txtX" runat="server"></asp:TextBox>
        X
        <asp:TextBox ID="txtY" runat="server"></asp:TextBox>
        Y<br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar" />
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="INICIAR" />
    </form>
</body>
</html>
