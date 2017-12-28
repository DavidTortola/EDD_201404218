<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Limpiar todo" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Graficar" />
        </div>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cargar" style="height: 26px" />
            </p>
        <p>
            &nbsp;</p>
        <p>
            Nickname<asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
        </p>
        <p>
            Password<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </p>
        <p>
            CorreoElectronico<asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        </p>
        <p>
            Conectado(0 o 1)<asp:TextBox ID="txtConectado" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Insertar" />
        </p>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Eliminar usuario" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Image ID="Image1" runat="server" />
        </p>
    </form>
</body>
</html>
