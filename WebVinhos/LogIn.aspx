<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback ="true" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebVinhos.LogIn1" %>

<%@ Register Src="~/Web Form User Control/LogIn.ascx" TagPrefix="uc1" TagName="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="row row-cols-auto d-flex justify-content-center align-items-center">
        <div class="col">
            <uc1:LogIn runat="server" ID="LogIn" />
        </div>
    </div>
</asp:Content>
