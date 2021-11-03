<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="WebVinhos.Pesquisar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />
    <link href="Admin/forms.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="d-flex justify-content-center align-items-center">
                <div class="container">
                    <table class="table table-responsive table-borderless">
                        <tr>
                            <th colspan="2" class="thTitulo">
                                <asp:Label ID="LabelTitulo" runat="server" Text="Pesquisa de Vinhos" CssClass="tituloLabel" Style="color: black;"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2" class="thTitulo">&nbsp;</th>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:TextBox ID="TextBoxNome" runat="server" CssClass="textBoxMed" Style="float: right; width: 200px; margin-right: 100px;"></asp:TextBox>
                            </td>
                            <td class="tdLabel" style="text-align: center">
                                <asp:Label ID="LabelCastas" runat="server" Text="Castas" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:DropDownList ID="DropDownListCastas" runat="server" CssClass="dropDownVinho" Style="float: right; margin-right: 100px;" AutoPostBack="True" OnSelectedIndexChanged="ButtonPesquisar_Click"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLabel" style="text-align: center">
                                <asp:Label ID="LabelRegião" runat="server" Text="Região" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:DropDownList ID="DropDownListRegião" runat="server" CssClass="dropDownVinho" Style="float: right; margin-right: 100px;" AutoPostBack="True" OnSelectedIndexChanged="ButtonPesquisar_Click"></asp:DropDownList>
                            </td>
                            <td class="tdLabel" style="text-align: center">
                                <asp:Label ID="LabelEnologos" runat="server" Text="Enologos" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:DropDownList ID="DropDownListEnologos" runat="server" CssClass="dropDownVinho" Style="float: right; margin-right: 100px;" AutoPostBack="True" OnSelectedIndexChanged="ButtonPesquisar_Click"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLabel" style="text-align: center">
                                <asp:Label ID="Produtor" runat="server" Text="Produtor" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:DropDownList ID="DropDownListProdutor" runat="server" CssClass="dropDownVinho" Style="float: right; margin-right: 100px;" AutoPostBack="True" OnSelectedIndexChanged="ButtonPesquisar_Click"></asp:DropDownList>
                            </td>
                            <td class="tdLabel" style="text-align: center">
                                <asp:Label ID="LabelTipoVinho" runat="server" Text="Tipo d'Vinho" CssClass="camposLabel" Style="margin-right: 100px;"></asp:Label>
                                <asp:DropDownList ID="DropDownListTipoVinho" runat="server" CssClass="dropDownVinho" Style="float: right; margin-right: 100px;" AutoPostBack="True" OnSelectedIndexChanged="ButtonPesquisar_Click"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div class="d-flex justify-content-center align-items-center">
                        <asp:Button ID="ButtonPesquisar" runat="server" Text="Pesquisar" class="btnMeu" OnClick="ButtonPesquisar_Click" />
                    </div>
                    <div style="margin-top: 50px;">
                        <asp:GridView ID="GridViewPesquisa" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="true" HorizontalAlign="Center" PageSize="6" BorderStyle="None" HeaderStyle-ForeColor="DarkRed" HeaderStyle-Font-Underline="false" OnRowDataBound="GridViewPesquisa_RowDataBound" EnableTheming="True"></asp:GridView>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
