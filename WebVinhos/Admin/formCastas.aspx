<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/indice2.master" AutoEventWireup="true" CodeBehind="formCastas.aspx.cs" Inherits="WebVinhos.Admin.formCastas" %>

<%@ MasterType VirtualPath="~/Admin/indice2.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderFormHead" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="forms.css" rel="stylesheet" />
    <link href="../Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container d-flex flex-column">

                <div class="row g-3 divCaixaForms">
                    <%-- Titulo --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelCastas" runat="server" Text="Castas" CssClass="tituloLabel"></asp:Label>
                    </div>

                    <%-- Nome --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Caracteristica --%>
                    <div class="col-md-3">
                        <asp:Label ID="LabelCaracteristica" runat="server" Text="Caracteristicas" CssClass="form-label camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="TextBoxCaracteristica" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <%-- Tipo de Vinho --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelTipoVinho" runat="server" Text="Tipo de Vinho" CssClass="form-label camposLabel"></asp:Label>
                        <asp:DropDownList ID="DropDownListTipoVinho" runat="server" CssClass="dropDownVinho linkInserirNovoTipoVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipoVinho" runat="server" ControlToValidate="DropDownListTipoVinho" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>

                        <asp:LinkButton ID="LinkButtonNovoTipoVinho" runat="server" CssClass="camposLabel linkButton linkInserirNovoTipoVinho" OnClick="LinkButtonNovoTipoVinho_Click" CausesValidation="False">Novo Tipo de Vinho</asp:LinkButton>
                        <asp:TextBox ID="TextBoxNovoTipoVinho" runat="server" CssClass="textBoxMed" Visible="False"></asp:TextBox>
                        <asp:Button ID="ButtonNovoTipoVinho" runat="server" Text="OK" CssClass="btnMeu" Style="width: 45px; height: 25px;" OnClick="ButtonNovoTipoVinho_Click" CausesValidation="False" Visible="False" />

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
                            <asp:Button ID="ButtonEliminar" runat="server" Text="Ocultar" CssClass="btnForms" Visible="False" OnClick="ButtonEliminar_Click1" CausesValidation="False" />
                            <asp:Button ID="ButtonEliminarDeVez" runat="server" Text="Eliminar de vez" CssClass="btnForms btnEliminarVez" Visible="False" OnClick="ButtonEliminarDeVez_Click" CausesValidation="False" />
                        </div>
                    </div>

                    <%-- Castas Registados --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelCastasRegistados" runat="server" Text="Castas Registados" CssClass="form-label camposLabel" Style="font-weight: bold;"></asp:Label>
                    </div>
                </div>

                <%-- GRIDVIEW --%>
                <div class="container divCaixaGrid">
                    <asp:GridView ID="GridViewCastas" runat="server" CssClass="table table-responsive table-hover" AllowSorting="True" HorizontalAlign="Center" AutoGenerateSelectButton="True" PageSize="6" AllowPaging="True" OnPageIndexChanging="GridViewCastas_PageIndexChanging" OnRowDataBound="GridViewCastas_RowDataBound1" OnSelectedIndexChanged="GridViewCastas_SelectedIndexChanged1" CellPadding="4" ForeColor="#333333" GridLines="None" EnableSortingAndPagingCallbacks="True">
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
