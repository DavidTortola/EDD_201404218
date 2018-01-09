<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Estado de juego:
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:Label ID="lblResultados" runat="server"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:Label ID="lblTiempo" runat="server"></asp:Label>
            <br />
            Mover unidad en:<br />
            <br />
            <asp:TextBox ID="txtMoverX" runat="server"></asp:TextBox>
            Coordenada en x (Números)<br />
            <asp:TextBox ID="txtMoverY" runat="server"></asp:TextBox>
            Coordenada en y (Letras)<br />
        <asp:TextBox ID="txtMoverNivel" runat="server"></asp:TextBox>
        Nivel<br />
            <br />
            A la posición:<br />
            <asp:TextBox ID="txtMoverX2" runat="server"></asp:TextBox>
            Coordenada en x (Números)<br />
            <asp:TextBox ID="txtMoverY2" runat="server"></asp:TextBox>
            Coordenada en y (Letras)<br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Mover" OnClick="Button1_Click" />
        <asp:TextBox ID="txtResultado" runat="server" Width="524px"></asp:TextBox>
        <br />
        <br />
        <br />
        Atacar con la unidad en la posición:<br />
            <br />
            <asp:TextBox ID="txtAtacarX" runat="server"></asp:TextBox>
            Coordenada en x<br />
            <asp:TextBox ID="txtAtacarY" runat="server"></asp:TextBox>
            Coordenada en y<br />
        <asp:TextBox ID="txtAtacarNivel" runat="server"></asp:TextBox>
        Nivel<br />
        <br />
        A la unidad en la posición:<br />
        <asp:TextBox ID="txtAtacarX2" runat="server"></asp:TextBox>
        Coordenada en x<br />
        <asp:TextBox ID="txtAtacarY2" runat="server"></asp:TextBox>
        Coordenada en y<br />
        <asp:TextBox ID="txtAtacarNivel2" runat="server"></asp:TextBox>
        Nivel<br />
        <asp:Button ID="Button2" runat="server" Text="Atacar" OnClick="Button2_Click" />
        <asp:TextBox ID="txtResultado0" runat="server" Width="524px"></asp:TextBox>
        <br />
        <br />
        Consola:<br />
        <asp:TextBox ID="TextBox12" runat="server" Width="577px"></asp:TextBox>
        <br />
        <br />
        SUBMARINOS (NIVEL 0):<br />
        <asp:Image ID="imgNivel0" runat="server" />
        <br />
        <br />
        BARCOS (NIVEL 1):<br />
        <asp:Image ID="imgNivel1" runat="server" />
        <br />
        <br />
        AVIONES (NIVEL 2):<br />
        <asp:Image ID="imgNivel2" runat="server" />
        <br />
        <br />
        SATÉLITES (NIVEL 3):<br />
        <asp:Image ID="imgNivel3" runat="server" />
    </form>
</body>
</html>
