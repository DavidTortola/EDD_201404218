<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuJugador.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.MenuJugador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Conectar a juego" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Colocar Unidades" />
        </p>
    </form>
</body>
</html>
