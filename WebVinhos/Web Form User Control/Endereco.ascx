<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Endereco.ascx.cs" Inherits="WebVinhos.Endereco" %>

<link href="UserContro.css" rel="stylesheet" />

<style type="text/css">
    .auto-style1 {
        color: darkblue;
        height: 25px;
        padding-left: 120px;
        padding-right: 50px;
    }
</style>

<table class="caixaTable">
    <tr class="tr">
        <th colspan="2" class="thTitulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="LabelTitulo"></asp:Label>
        </th>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxNome" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$"></asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelMorada" runat="server" Text="Morada" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxMorada" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMorada" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMorada" runat="server" ControlToValidate="TextBoxMorada" Display="Dynamic" ErrorMessage="Só deve incluir letras, números e espaços" ValidationExpression="^[0-9a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇºª.,\s]+$"></asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelLocalidade" runat="server" Text="Localidade" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxLocalidade" runat="server" CssClass="textBoxMed"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxLocalidade" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLocalidade" runat="server" ControlToValidate="TextBoxLocalidade" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$"></asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelCodigoPostal" runat="server" Text="Codio-Postal" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxCodigoPostal" runat="server" CssClass="textBoxMed"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxCodigoPostal" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCodigoPostal" runat="server" ControlToValidate="TextBoxCodigoPostal" Display="Dynamic" ErrorMessage="Permite apena o formato 0000-000 ou 0000" ValidationExpression="^[1-9]\d{3}(-\d{3})?$"></asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelTelemovel" runat="server" Text="Telemovel" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxTelemovel" runat="server" CssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="auto-style1">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefone" runat="server" ControlToValidate="TextBoxTelemovel" Display="Dynamic" ErrorMessage="Incluir apenas valores que comecem por 9, seguido de um dos seguintes dígitos(1, 2, 3 ou 6), seguido de 7 dígitos ou valores que comecem por 2 ou 3, seguido de 8 dígitos" ValidationExpression="(^[9][1|2|3|6]\d{7}) | (^[2|3]\d{8})"></asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelEmail" runat="server" Text="Email" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textBoxMed"></asp:TextBox>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">validacao
        </td>
    </tr>

    <tr class="tr">
        <td colspan="2" class="tdBtnE">
            <asp:Button ID="Button1" runat="server" Text="Inserir" CssClass="btn" />
        </td>
    </tr>
</table>

