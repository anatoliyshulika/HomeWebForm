<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HomeWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS_Style/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="image" runat="server" EnableViewState="true">
            <asp:Image ImageUrl="~/Picture/Fon2.jpg" runat="server" EnableViewState="true" />
        </asp:Panel>
            <asp:Panel ID="Device" runat="server" EnableViewState="false">
                <div id="addmenu">
            <asp:Button ID="addDevice" runat="server" Text="ADD DEVICE" OnClick="addDevice_Click" /><br />
            <asp:Label ID="typeOfDevice" runat="server" Text="Choice a device" /><br />
            <select id="selectDevice" runat="server">
                <option value="Lamp">Lamp</option>
                <option value="TV">TV</option>
                <option value="Bake">Bake</option>
                <option value="Frige">Frige</option>
                <option value="Radio">Radio</option>
            </select><br />
            <asp:Label ID="labelNameOfDevice" runat="server" Text="Enter name of device" /><br />
            <asp:TextBox ID="TextBoxNameOfDevice" runat="server" EnableViewState="false" ></asp:TextBox>
        </div>
            </asp:Panel>
    </form>
</body>
</html>
