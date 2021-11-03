<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogIn.ascx.cs" Inherits="WebVinhos.LogIn" %>

<link href="UserContro.css" rel="stylesheet" />
<link href="../Admin/forms.css" rel="stylesheet" />
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<script src="../Scripts/bootstrap.min.js"></script>


<table class="caixaTable">
    <%-- TITULO --%>
    <tr class="tr">
        <th colspan="2" class="thTitulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="Log In"></asp:Label>
        </th>
    </tr>

    <%-- NOME --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="labels"></asp:Label>
        </td>
        <td class="textBoxNome">
            <asp:TextBox ID="TextBoxNome" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <%-- PASSWORD --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <%-- REPEAT PASSWORD --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelRepeatPassword" runat="server" Text="Repeat Password" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxRepeatPassword" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server" ControlToValidate="TextBoxRepeatPassword" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <%-- RECUPERAR PASSWORD --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:LinkButton ID="LinkButtonRecuperarPassword" runat="server" CssClass="labels linkRecPass linkButton" OnClick="LinkButtonRecuperarPassword_Click" CausesValidation="False">Recuperar Password</asp:LinkButton>
        </td>
        <td class="valiTextNumeros">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="As passowrds não coincidem." ControlToCompare="TextBoxRepeatPassword" ControlToValidate="TextBoxPassword" Display="Dynamic"></asp:CompareValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="Mais de 8 letras ou numeros e minimo 2 caracteres especiais" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <%-- BOTAO --%>
    <tr class="tr">
        <td colspan="2" class="tdBtn">
            <asp:Button ID="ButtonLogIn" runat="server" Text="Log In" CssClass="btnMeu" OnClick="ButtonLogIn_Click" />
        </td>
    </tr>
</table>


<%-- RECUPERAR PASSWORD --%>
<div class="d-flex justify-content-center">
    <asp:Panel ID="Panel1" runat="server" class="caixaTable" Style="margin-top:35px;" Visible="False">
          <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">Forgot Your Password?</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">Enter your User Name to receive your password.</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="tdTableRecuperarPass" Style="margin-left: 20px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$PasswordRecovery1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;" >
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="ctl00$PasswordRecovery1" CssClass="btnMeu tdTableRecuperarPass" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    </asp:Panel>
</div>
<%-- FIM RECUPERAR PASSWORD --%>


