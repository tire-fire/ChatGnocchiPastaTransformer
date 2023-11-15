<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatGnocchiPastaTransformer.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat GnocchiPastaTransformer</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; height: 100vh; display: flex; }
        #container { flex-grow: 1; display: flex; }
        #sidebar { width: 200px; height: 100%; }
        #mainContent { flex-grow: 1; position: relative; padding-bottom: 130px; }
        #inputArea { position: fixed; bottom: 0; left: 200px; right: 0; padding: 30px; background-color: white; box-shadow: 0px -2px 5px rgba(0,0,0,0.2); }
        #history { overflow-y: auto; height: 100%; }
        .question, .answer { margin: 10px 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="sidebar">
                <h3>Chat Gnocchi Pasta Transformer</h3>
            </div>
            <div id="mainContent">
                <asp:Panel ID="HistoryPanel" runat="server" />
                <div id="inputArea">
                    <asp:TextBox ID="QuestionTextBox" runat="server" Width="700"></asp:TextBox>
                    <asp:Button ID="AskButton" runat="server" Text="Ask the Gnocchi" OnClick="AskButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>