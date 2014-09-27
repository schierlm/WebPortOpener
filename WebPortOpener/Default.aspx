<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPortOpener.Index" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        body {
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
    </style>
    <title>WebPortOpener</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>WebPortOpener</h1>
        <p style="border: 1px solid blue; background-color: yellow; padding: 1em">
            <asp:Label ID="status" runat="server" Text="Your IP: ?" />
        </p>
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="username" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="password" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>CAPTCHA:</td>
                <td>
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server"/>
                </td>
            </tr>
        </table>
        <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    </form>
</body>
</html>
