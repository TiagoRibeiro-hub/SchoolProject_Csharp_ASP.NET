<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="WebVinhos.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Admin/forms.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.min.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Indice2" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <asp:DataList ID="listVinhos" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="listVinhos_ItemDataBound">
            <ItemTemplate>
                <div class="container m-3">
                    <div class="row g-3" style="margin: 20px; margin-bottom: 25px;">
                        <div class="col-md-8 row g-3">
                            <div class="col-md-12">
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                                <%-- Query String com informação do id--%>
                                <a href="VerVinho.aspx?id=<%# Eval("Id") %>" style="text-decoration: none;">
                                    <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' CssClass="linkTitulo" />
                                </a>
                            </div>
                            <div class="col-md-12">
                                <span class="tituloLabel spanSize">Produtor: </span>
                                <a href="<%# Eval("URL_Produtor") %>" style="text-decoration: none;">
                                    <asp:Label ID="ProdutorLabel" runat="server" Text='<%# Eval("Produtor") %>' CssClass="userLink"/>
                                </a>
                            </div>
                            <div class="col-md-12">
                                <span class="tituloLabel spanSize">Região: </span>
                                <asp:Label ID="RegiãoLabel" runat="server" Text='<%# Eval("Regiao") %>' />
                            </div>
                            <div class="col-md-12">
                                <span class="tituloLabel spanSize">Tipo de Vinho: </span>
                                <asp:Label ID="TipoVinhoLabel" runat="server" Text='<%# Eval("Tipo de Vinho") %>' />
                            </div>
                            <div class="col-md-12">
                                <span class="tituloLabel spanSize">Utilizador: </span>
                                <a href="VinhoPorUtilizadorAnonimos.aspx?id=<%# Eval("ID_Utilizador") %>" style="text-decoration: none;">
                                    <asp:Label ID="UtilizadorLabel" runat="server" Text='<%# Eval("Utilizador") %>' CssClass="userLink" />
                                </a>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <a href="vinho.aspx?id=<%# Eval("Id") %>" class="link-primary">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Foto") %>' CssClass="imgVinhos" />
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <div class="d-flex justify-content-center align-items-center">
        <asp:Label ID="LabelPagina" runat="server" CssClass="linkButton linkInserirNovoTipoVinho linkButtonColorMargin"></asp:Label>
        <asp:LinkButton ID="linkPrimeira" runat="server" OnClick="linkPrimeira_Click" CssClass="linkButton linkInserirNovoTipoVinho linkButtonColorMargin">Primeira</asp:LinkButton>
        <asp:LinkButton ID="linkAnterior" runat="server" OnClick="linkAnterior_Click" CssClass="linkButton linkInserirNovoTipoVinho linkButtonColorMargin">Anterior</asp:LinkButton>
        <asp:LinkButton ID="linkSeguinte" runat="server" OnClick="linkSeguinte_Click" CssClass="linkButton linkInserirNovoTipoVinho linkButtonColorMargin">Seguinte</asp:LinkButton>
        <asp:LinkButton ID="linkUltima" runat="server" OnClick="linkUltima_Click" CssClass="linkButton linkInserirNovoTipoVinho linkButtonColorMargin">Ultima</asp:LinkButton>
    </div>
</asp:Content>

