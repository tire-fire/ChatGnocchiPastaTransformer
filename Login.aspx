<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChatGnocchiPastaTransformer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat Gnocchi Pasta Transformer: Login</title>
</head>
<body>
    <div>
        <asp:Label ID="LoginErrorLabel" runat="server" Text=""></asp:Label>
    </div>
<br />
    <h1>Please log in</h1>
    <form id="Login" runat="server">
        <div>
            <asp:Label ID="LoginPanel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </div>
    </form>
</body>
</html>
