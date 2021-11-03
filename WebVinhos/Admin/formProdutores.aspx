<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/indice2.master" AutoEventWireup="true" CodeBehind="formProdutores.aspx.cs" Inherits="WebVinhos.Admin.formProdutos" %>

<%@ MasterType VirtualPath="~/Admin/indice2.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderFormHead" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="forms.css" rel="stylesheet" />
    <link href="../Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container d-flex flex-column">

                <div class="row g-3 divCaixaForms">
                    <%-- Titulo --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelProdutores" runat="server" Text="Produtores" CssClass="tituloLabel"></asp:Label>
                    </div>

                    <%-- Nome --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Morada --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelMorada" runat="server" Text="Morada" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxMorada" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMorada" runat="server" ControlToValidate="TextBoxMorada" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMorada" runat="server" ControlToValidate="TextBoxMorada" Display="Dynamic" ErrorMessage="Só deve incluir letras, números e espaços" ValidationExpression="^[0-9a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇºª.,\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Codigo Postal --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelCodigoPosta" runat="server" Text="Codigo-Postal" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxCodigoPosta" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCodigoPosta" runat="server" ControlToValidate="TextBoxCodigoPosta" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCodigoPosta" runat="server" ControlToValidate="TextBoxCodigoPosta" Display="Dynamic" ErrorMessage="Permite apena o formato 0000-000 ou 0000" ValidationExpression="^[1-9]\d{3}(-\d{3})?$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Localidade --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelLocalidade" runat="server" Text="Localidade" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxLocalidade" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalidade" runat="server" ControlToValidate="TextBoxLocalidade" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLocalidade" runat="server" ControlToValidate="TextBoxLocalidade" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Telefone --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelTelefone" runat="server" Text="Telefone" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxTelefone" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefone" runat="server" ControlToValidate="TextBoxTelefone" ErrorMessage="Deve comecar por 9, seguido de (1, 2, 3 ou 6), seguido de 7 dígitos ou comecar por 2 ou 3, seguido de 8 dígitos" ValidationExpression="(^[9][1|2|3|6]\d{7}) | (^[2|3]\d{8})" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Email --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelEmail" runat="server" Text="Email" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Formato: exemplo@exem.com" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- URL --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelURL" runat="server" Text="URL" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxURL" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxURL" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxURL" ErrorMessage="Formato ex.: www.exemplo.com; https://www.exemplo.pt" ValidationExpression="([-a-zA-Z0-9^\p{L}\p{C}\u00a1-\uffff@:%_\+.~#?&//=]{2,256}){1}(\.[a-z]{2,4}){1}(\:[0-9]*)?(\/[-a-zA-Z0-9\u00a1-\uffff\(\)@:%,_\+.~#?&//=]*)?([-a-zA-Z0-9\(\)@:%,_\+.~#?&//=]*)?" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>                        
                    </div>

                    <%-- Activar --%>
                    <div class="col-md-12">
                        <div class="form-check">
                            <asp:CheckBox ID="CheckBoxActivar" runat="server" Text="Desactivada a possibilidade de eliminar " CssClass="camposLabel camposLabelDesactivar" Checked="True" AutoPostBack="True" OnCheckedChanged="CheckBoxActivar_CheckedChanged" />
                        </div>
                    </div>


                    <%-- LINK INSERIR --%>
                    <div class="col-md-12">
                        <div class="form-check">
                            <asp:LinkButton ID="LinkButtonInserir" runat="server" CssClass="camposLabel linkButton" Visible="False" Text="Inserir" OnClick="LinkButtonInserir_Click" CausesValidation="False"></asp:LinkButton>
                        </div>
                    </div>

                    <%-- Botoes --%>
                    <div class="col-md-12 d-flex justify-content-evenly">
                        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" CssClass="btnForms" OnClick="ButtonInserir_Click" />
                        <div>
                            <asp:Button ID="ButtonEliminar" runat="server" Text="Ocultar" CssClass="btnForms" OnClick="ButtonEliminar_Click" Visible="False" CausesValidation="False" />
                            <asp:Button ID="ButtonEliminarDeVez" runat="server" Text="Eliminar de vez" CssClass="btnForms btnEliminarVez" OnClick="ButtonEliminarDeVez_Click" Visible="False" CausesValidation="False" />
                        </div>
                    </div>

                    <%-- Produtores Registados --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelProdutoresRegistados" runat="server" Text="Produtores Registados" CssClass="form-label camposLabel" Style="font-weight: bold;"></asp:Label>
                    </div>
                </div>

                <%-- GRIDVIEW --%>
                <div class="container divCaixaGrid">
                    <asp:GridView ID="GridViewProdutores" runat="server" CssClass="table table-responsive table-hover" AllowSorting="True" HorizontalAlign="Center" AllowPaging="True" PageSize="6" AutoGenerateSelectButton="True" OnPageIndexChanging="GridViewProdutores_PageIndexChanging" OnRowDataBound="GridViewProdutores_RowDataBound" OnSelectedIndexChanged="GridViewProdutores_SelectedIndexChanged" EnableSortingAndPagingCallbacks="True">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FF5B5B" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
