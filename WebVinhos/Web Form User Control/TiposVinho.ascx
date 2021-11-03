<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TiposVinho.ascx.cs" Inherits="WebVinhos.Web_Form_User_Control.TiposVinho" %>

<link href="UserContro.css" rel="stylesheet" />

<table class="caixaTable">
    <tr class="tr">
        <th colspan="2" class="thTitulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="Tipos de Vinhos"></asp:Label>
        </th>
    </tr>

    <%-- NOME --%>
    <tr class="tr">
        <td class="tdLabel">
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

    <%-- BOTAO --%>
    <tr class="tr">
        <td colspan="2" class="tdBtn">
            <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" CssClass="btn"/>
            <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn" Style="margin-left:150px;"/>
        </td>
    </tr>

</table>