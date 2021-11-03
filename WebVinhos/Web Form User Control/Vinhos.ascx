<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Vinhos.ascx.cs" Inherits="WebVinhos.Web_Form_User_Control.Vinhos" %>

<link href="UserContro.css" rel="stylesheet" />


<table class="caixaTable">
    <%-- TITULO --%>
    <tr class="tr">
        <th colspan="2" class="thTitulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="Vinho"></asp:Label>
        </th>
    </tr>

    <%-- NOME --%>
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

    <%-- ANO --%>
    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelAno" runat="server" Text="Ano" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxAno" runat="server" CssClass="textBoxNumeros"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxAno" Display="Dynamic" ErrorMessage="Só deve incluir numeros" ValidationExpression="^(-\d(\.\d|),|\d(\.\d|),|-\d(\.\d|)|\d(\.\d|))+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
        </td>
    </tr>

     <%-- VOLUME --%>
    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelVolume" runat="server" Text="Volume" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxVolume" runat="server" CssClass="textBoxNumeros"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxVolume" Display="Dynamic" ErrorMessage="Só deve incluir numeros" ValidationExpression="^(-\d(\.\d|),|\d(\.\d|),|-\d(\.\d|)|\d(\.\d|))+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <%-- TEOR ALCOOLICO --%>
    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelTeorAlcoolico" runat="server" Text="Teor Alcoolico" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxTeorAlcoolico" runat="server" CssClass="textBoxNumeros"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxTeorAlcoolico" Display="Dynamic" ErrorMessage="Só deve incluir numeros" ValidationExpression="^(-\d(\.\d|),|\d(\.\d|),|-\d(\.\d|)|\d(\.\d|))+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
        </td>
    </tr>

     <%-- TMPERATURA --%>
    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="LabelTemperatura" runat="server" Text="Temperatura" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxTemperatura" runat="server" CssClass="textBoxNumeros"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxTemperatura" Display="Dynamic" ErrorMessage="Só deve incluir numeros" ValidationExpression="^(-\d(\.\d|),|\d(\.\d|),|-\d(\.\d|)|\d(\.\d|))+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <%-- TMPERATURA --%>
    <tr class="tr">
        <td class="tdLabelE">
            <asp:Label ID="Label1" runat="server" Text="Região" CssClass="labels"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownListRegiao" runat="server" CssClass="dropDownVinho"></asp:DropDownList>
        </td>
    </tr>

</table>