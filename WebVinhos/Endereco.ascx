<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Endereco.ascx.cs" Inherits="WebVinhos.Endereco" %>
<style>
    .tdLabel {
        width: 200px;
    }
    .tdTextBox{
        width: 750px;
    }
    .textBoxBig{
        width: 500px;
    }
    .textBoxMed{
        width: 250px;
    }
</style>
<table>
       <th colspan="2">
            <asp:Label ID="LabelTitulo" runat="server" Text="LabelTitulo"></asp:Label>
       </th>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelNome" runat="server" Text="Nome"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxNome" runat="server" cssClass="textBoxBig"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelMorada" runat="server" Text="Morada"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxMorada" runat="server" cssClass="textBoxBig"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelLocalidade" runat="server" Text="Localidade"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxLocalidade" runat="server" cssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelCodigoPostal" runat="server" Text="Codio-Postal"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxCodigoPostal" runat="server" cssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelTelemovel" runat="server" Text="Telemovel"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxTelemovel" runat="server" cssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxEmail" runat="server" cssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>

</table>