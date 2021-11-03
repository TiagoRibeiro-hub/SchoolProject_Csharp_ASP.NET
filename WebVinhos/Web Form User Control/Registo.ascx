<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Registo.ascx.cs" Inherits="WebVinhos.Registo" %>

<link href="UserContro.css" rel="stylesheet" />
<link href="../Content/bootstrap.min.css" rel="stylesheet" />




<table class="caixaTable">
    <tr class="tr">
        <th colspan="2" class="thTitulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="Registo/Alterar"></asp:Label>
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

    <%-- EMAIL --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelEmail" runat="server" Text="Email" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="Formato: exemplo@exem.com" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <%-- DATA NASCIMENTO --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelDataNascimento" runat="server" Text="Data de Nascimento" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxDataNascimento" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDataNascimento" runat="server" ControlToValidate="TextBoxDataNascimento" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDataNascimento" runat="server" ControlToValidate="TextBoxDataNascimento" Display="Dynamic" ErrorMessage="O formato deve ser (YYYY (/ou-) MM (/ou-) DD) ou (DD (/ou-) MM (/ou-) YYYY)" ValidationExpression="^(\d{4}(/|-)\d{1,2}(/|-)\d{1,2})|(\d{1,2}(/|-)\d{1,2}(/|-)\d{4})$"></asp:RegularExpressionValidator>
            <asp:CompareValidator ID="CompareValidatorMaiorIdade" runat="server" Display="Dynamic" ErrorMessage="CompareValidator" ControlToValidate="TextBoxDataNascimento"></asp:CompareValidator>
        </td>
    </tr>


    <%-- PASSSWORD --%>
    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>


    <tr class="tr">
        <td class="tdLabel">
            <asp:Label ID="LabelRepeatPassword" runat="server" Text="Repeat Password" CssClass="labels"></asp:Label>
        </td>
        <td class="tdTextBox">
            <asp:TextBox ID="TextBoxRepeatPassword" runat="server" CssClass="textBoxBig"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server" ControlToValidate="TextBoxRepeatPassword" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="trRegExp">
        <td colspan="2" class="tdRegExp">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="As passowrds não coincidem." ControlToCompare="TextBoxRepeatPassword" ControlToValidate="TextBoxPassword" Display="Dynamic"></asp:CompareValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="Mais de 8 letras ou numeros e minimo 2 caracteres especiais" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <%-- BOTAO --%>
    <tr class="tr">
        <td colspan="2" class="tdBtn">
            <asp:Button ID="Button1" runat="server" Text="Registar" CssClass="btnMeu" OnClick="Button1_Click" />
            <asp:Button ID="ButtonAlterarPass" runat="server" Text="Alterar Pass" CssClass="btnMeu" Visible="False" Style="margin-left: 200px;" OnClick="ButtonAlterarPass_Click" CausesValidation="False" />
        </td>
    </tr>

</table>

<div class="d-flex justify-content-center">


    <asp:ChangePassword ID="ChangePassword1" runat="server" Visible="False">
        <ChangePasswordTemplate>
            <table class="caixaTable" style="margin-top: 50px; border-collapse: collapse;" cellpadding="1" cellspacing="0" ">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2" style="height: 24px; padding-top:15px;">Change Your Password</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Style="margin-top: 20px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Style="margin-top: 20px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Style="margin-top: 20px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required." ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="ctl00$ChangePassword1" class="btnMeu" Style="margin-top: 20px; margin-bottom: 20px;"/>
                                </td>
                                <td>
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" class="btnMeu" Style="margin-top: 20px; margin-bottom: 20px; margin-left:20px;"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
    </asp:ChangePassword>

</div>
