<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="MeusVinhos.aspx.cs" Inherits="WebVinhos.Utilizadores.MeusVinhos" %>

<%@ Register Src="~/Web Form User Control/VinhoPorUtilizador.ascx" TagPrefix="uc1" TagName="VinhoPorUtilizador" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Admin/forms.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <div class="d-flex justify-content-center align-items-center">
        <asp:Button ID="ButtonInseriri" runat="server" Text="Inserir Novo Vinho" CssClass="btnMeu" Style="width:250px; margin-bottom:30px;" OnClick="ButtonInseriri_Click"/>
    </div>

    <div class="row row-cols-auto d-flex justify-content-center align-items-center">
        <div class="col">
            <uc1:VinhoPorUtilizador runat="server" ID="VinhoPorUtilizador" />
        </div>
    </div>

</asp:Content>
