﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuJuegos.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.MenuJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Atras" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Reportes" />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Cargar Juego" />
        <p>
            <asp:TextBox ID="txtNivel0" runat="server"></asp:TextBox>
            Unidades nivel 0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNivel1" runat="server"></asp:TextBox>
            Unidades nivel 1</p>
        <p>
            <asp:TextBox ID="txtNivel2" runat="server"></asp:TextBox>
            Unidades nivel 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNivel3" runat="server"></asp:TextBox>
            Unidades nivel 3</p>
        <br />
        Tamaño del tablero<p>
            <asp:TextBox ID="txtX" runat="server"></asp:TextBox>
            X<asp:TextBox ID="txtY" runat="server"></asp:TextBox>
            Y</p>
        <p>
            Tipo de juego</p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">Normal</asp:ListItem>
            <asp:ListItem Value="2">Tiempo</asp:ListItem>
            <asp:ListItem Value="3">Base</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtTiempo" runat="server"></asp:TextBox>
        tiempo<br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cargar juego" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Iniciar juego" OnClick="Button2_Click" />
        <br />
        <br />
        Estado del juego: <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
