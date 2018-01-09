<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Atras" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Limpiar todo" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Graficar" />
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Graficar Espejo" />
        </div>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cargar" style="height: 26px" />
            </p>
        <p>
            &nbsp;</p>
        <p>
            Inserción de usuarios:</p>
        <p>
            <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
            Nickname</p>
        <p>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            Password</p>
        <p>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            Correo Electrónico</p>
        <p>
            <asp:TextBox ID="txtConectado" runat="server"></asp:TextBox>
&nbsp;Conectado(0 o 1)</p>
        <p>
            &nbsp;<asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Insertar" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Modificar Usuarios:</p>
        <p>
            Usuario a modificar<asp:TextBox ID="txtModificar" runat="server"></asp:TextBox>
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Cargar Datos" />
        &nbsp;</p>
        <p>
            <asp:TextBox ID="txtNickname0" runat="server"></asp:TextBox>
            Nickname</p>
        <p>
            <asp:TextBox ID="txtPassword0" runat="server"></asp:TextBox>
            Password</p>
        <p>
            <asp:TextBox ID="txtCorreo0" runat="server"></asp:TextBox>
            Correo Electrónico</p>
        <p>
            <asp:TextBox ID="txtConectado0" runat="server"></asp:TextBox>
&nbsp;Conectado(0 o 1)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Graficar Contactos" />
        </p>
        <p>
            <asp:TextBox ID="txtContactoUsuario" runat="server"></asp:TextBox>
            Usuario</p>
        <p>
            <asp:TextBox ID="txtContactoContraseña" runat="server"></asp:TextBox>
            Contraseña</p>
        <p>
            <asp:TextBox ID="txtContactoCorreo" runat="server"></asp:TextBox>
            Correo electrónico</p>
        <p>
            <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Insertar Contacto" />
            <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Eliminar Contacto" />
        </p>
        <p>
            Oponente, Unidades Desplegadas, Unidades Sobrevivientes, Unidades Destruidas, Gano (1 si, 0 no)</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Width="312px"></asp:TextBox>
            Juegos</p>
        <p>
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Modificar" />
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Eliminar usuario" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Consultas" />
        <br />
        <asp:TextBox ID="txtGanados" runat="server"></asp:TextBox>
        Top 10 jugadores con más juegos ganados<br />
        <asp:TextBox ID="txtDestruidas" runat="server"></asp:TextBox>
        Top 10 jugadores con más porcentaje de unidades destruídas<br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Datos del árbol" />
        <br />
        <asp:TextBox ID="txtAltura" runat="server"></asp:TextBox>
        Altura<br />
        <asp:TextBox ID="txtNiveles" runat="server"></asp:TextBox>
        Niveles<br />
        <asp:TextBox ID="txtHojas" runat="server"></asp:TextBox>
        Cantidad de nodos hoja<br />
        <asp:TextBox ID="txtRamas" runat="server"></asp:TextBox>
        Cantidad de nodos rama<p>
            <asp:Image ID="imgContactos" runat="server" />
        </p>
        <p>
            <asp:Image ID="Image1" runat="server" />
        </p>
    </form>
</body>
</html>
