<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            Coordenada en x<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            Coordenada en y</div>
        <asp:Button ID="Button1" runat="server" Text="Mover" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        Coordenada en x<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        Coordenada en y<br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        Nivel<br />
        <asp:Button ID="Button2" runat="server" Text="Atacar" />
        <br />
        <br />
        Consola<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Satélites<br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <br />
        Aviones<br />
        <asp:Image ID="Image2" runat="server" />
        <br />
        <br />
        Barcos<br />
        <asp:Image ID="Image3" runat="server" />
        <br />
        <br />
        Submarinos<br />
        <asp:Image ID="Image4" runat="server" />
    </form>
</body>
</html>
