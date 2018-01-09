<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesMatriz.aspx.cs" Inherits="_EDD_Proyecto1_Cliente.ReportesMatriz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Atras" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generar Reportes" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Generar Estado Inicial" />
        <p>
            Tablero de juego actual:</p>
        <p>
            Nivel 0 (submarinos)</p>
        <asp:Image ID="imgNivel0" runat="server" />
        <p>
            Nivel 1 (barcos)</p>
        <asp:Image ID="imgNivel1" runat="server" />
        <p>
            NIvel 2 (aviones)</p>
        <p>
            <asp:Image ID="imgNivel2" runat="server" />
        </p>
        <p>
            Nivel 3 (satélites)</p>
        <p>
            <asp:Image ID="imgNivel3" runat="server" />
        </p>
    </form>
</body>
</html>
