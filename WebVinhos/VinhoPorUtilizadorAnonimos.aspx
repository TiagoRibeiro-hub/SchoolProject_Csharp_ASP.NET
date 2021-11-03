<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="VinhoPorUtilizadorAnonimos.aspx.cs" Inherits="WebVinhos.VinhoPorUtilizadorAnonimos" %>

<%@ Register Src="~/Web Form User Control/VinhoPorUtilizador.ascx" TagPrefix="uc1" TagName="VinhoPorUtilizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="Admin/forms.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

        <div class="row row-cols-auto d-flex justify-content-center align-items-center">
        <div class="col">
            <uc1:VinhoPorUtilizador runat="server" id="VinhoPorUtilizador" />
        </div>
    </div>

</asp:Content>
