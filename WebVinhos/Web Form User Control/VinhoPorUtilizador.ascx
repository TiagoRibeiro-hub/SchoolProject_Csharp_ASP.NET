<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VinhoPorUtilizador.ascx.cs" Inherits="WebVinhos.Web_Form_User_Control.VinhoPorUtilizador1" %>

<link href="../Admin/forms.css" rel="stylesheet" />
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<link href="UserContro.css" rel="stylesheet" />

<div class="d-flex justify-content-center align-items-center">
    <asp:Label ID="LabelUtilizador" runat="server" Text='Utilizador' CssClass="tituloLabel" Style="margin-bottom: 30px;"></asp:Label>
</div>

<div class="container">
    <%-- DATALIST --%>
    <asp:DataList ID="listVinhos" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="container m-3">
                <div class="row g-3" style="margin: 20px; margin-bottom: 25px;">
                    <div class="col-md-8 row g-3">
                        <div class="col-md-12">
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                            <%-- Query String com informação do id--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/VerVinho.aspx?id={0}" , Eval("Id")) %>' Text='<%#string.Format("{0}", Eval("Nome")) %>' CssClass="linkTitulo" Style="text-decoration: none;">  
                            </asp:HyperLink>
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Produtor: </span>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("URL_Produtor") %>' Text='<%#string.Format("{0}", Eval("Produtor")) %>' CssClass="userLink" Style="text-decoration: none;">  
                            </asp:HyperLink>
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
                            <asp:Label ID="UtilizadorLabel" runat="server" Text='<%# Eval("Utilizador") %>' />
                        </div>
                    </div>
                    <div class="col-md-4 d-flex justify-content-center align-content-center">
                        <a href="VerVinho.aspx?id=<%# Eval("Id") %>" class="link-primary">
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
