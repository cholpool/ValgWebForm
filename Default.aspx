<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="StemmeLabel" runat="server" Text="Stem her"></asp:Label>
        <br />

        <asp:Label ID="KommuneLabel" runat="server" Text="Kommune :"></asp:Label>

        <br />

        <asp:DropDownList ID="DropDownListKommu" runat="server">
            <asp:ListItem Selected="True" Value="0">Velg kommune</asp:ListItem>
            </asp:DropDownList>

        <br />

        <asp:Label ID="PartiLabel" runat="server" Text="Parti :"></asp:Label>

        <br />

        <asp:DropDownList ID="DropDownListParti" runat="server">
            <asp:ListItem Selected="True" Value="0">Velg Party</asp:ListItem>
        </asp:DropDownList>

        <br /><br />

        <asp:Button ID="StemButton" runat="server" Text="Stem" OnClick="StemButton_Click" />

        <br /><br />

        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>        
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
