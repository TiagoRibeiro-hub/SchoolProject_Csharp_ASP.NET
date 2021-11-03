<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/indice2.master" AutoEventWireup="true" CodeBehind="Formularios.aspx.cs" Inherits="WebVinhos.Admin.Formularios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderFormHead" runat="server">

    <link href="forms.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderForm" runat="server">

    <div class="row row-cols-auto divCentro">
        <asp:ImageButton ID="ImageButtonVinhos" runat="server" ImageUrl="~/Imagens/garrafeiraVinhos.jpg" CssClass="col formVinhos" OnClick="ImageButtonVinhos_Click" />
        
        <asp:ImageButton ID="ImageButtonProdutores" runat="server" ImageUrl="~/Imagens/vindimas.jpg" CssClass="col formProdutores" OnClick="ImageButtonProdutores_Click" />

        <asp:ImageButton ID="ImageButtonRegioes" runat="server" ImageUrl="~/Imagens/mapa_regioes_viniculas.jpg" CssClass="col formRegioes" OnClick="ImageButtonRegioes_Click" />
        
        <asp:ImageButton ID="ImageButtonTipoVinhos" runat="server" ImageUrl="~/Imagens/tipos-de-vinho.jpg" CssClass="col formTipoVinhos" OnClick="ImageButtonTipoVinhos_Click" />

        <asp:ImageButton ID="ImageButtonCastas" runat="server" ImageUrl="~/Imagens/casta.jpg" CssClass="col formCastas" OnClick="ImageButtonCastas_Click" />

        <asp:ImageButton ID="ImageButtonEnologos" runat="server" ImageUrl="~/Imagens/enologo.jpg" CssClass="col formEnologos" OnClick="ImageButtonEnologos_Click" />

    </div>



</asp:Content>

