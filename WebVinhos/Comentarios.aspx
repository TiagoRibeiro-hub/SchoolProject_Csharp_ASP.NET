<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="WebVinhos.Comentarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Admin/forms.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Indice2" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>

            <div class="d-flex justify-content-center align-items-center">
                <div class="container d-flex justify-content-center align-items-center">
                    <div class="row g-3" style="margin: 20px; margin-bottom: 25px; width: 40vw;">
                        <div class="col-md-12" style="text-align: center; margin-bottom: 50px">
                            <asp:Label ID="LabelTitulo" runat="server" Text="Comentarios" CssClass="tituloLabel" Style="color: black;"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="LabelEscolhaVinho" runat="server" Text="Escolha um Vinho" CssClass="camposLabel"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="DropDownListVinhos" runat="server" CssClass="dropDownVinho" AutoPostBack="True" OnSelectedIndexChanged="DropDownListVinhos_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-12 d-flex justify-content-center align-items-center">
                            <asp:LinkButton ID="LinkButtonPrimeiroComentar" runat="server" CssClass="userLink" Visible="False" OnClick="LinkButtonPrimeiroComentar_Click">Seja o primeiro a comentar !!</asp:LinkButton>
                        </div>
                        <%-- COMENTAR --%>
                        <asp:Panel ID="PanelComentar" runat="server" Visible="False">
                            <div class="col-md-12 d-flex justify-content-center align-content-center">
                                <asp:Label ID="LabelVinhoAComentar" runat="server" CssClass="camposLabel" Style="color: black"></asp:Label>
                            </div>
                            <div class="col-md-12 d-flex justify-content-center align-content-center">
                                <asp:TextBox ID="TextBoxComentario" runat="server" TextMode="MultiLine" Style="width: 500px; height: 150px"></asp:TextBox>
                            </div>
                            <div class="col-md-12" style="margin-top: 40px;">
                                <div class="form-check form-check-inline">
                                    <asp:CheckBox ID="CheckBox1Estrela" runat="server" Text="1Estrela" CssClass="form-check-label" AutoPostBack="True" OnCheckedChanged="CheckBox1Estrela_CheckedChanged" />
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:CheckBox ID="CheckBox2Estrelas" runat="server" Text="2Estrelas" CssClass="form-check-label" AutoPostBack="True" OnCheckedChanged="CheckBox2Estrelas_CheckedChanged" />
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:CheckBox ID="CheckBox3Estrelas" runat="server" Text="3Estrelas" CssClass="form-check-label" AutoPostBack="True" OnCheckedChanged="CheckBox3Estrelas_CheckedChanged" />
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:CheckBox ID="CheckBox4Estrelas" runat="server" Text="4Estrelas" CssClass="form-check-label" AutoPostBack="True" OnCheckedChanged="CheckBox4Estrelas_CheckedChanged" />
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:CheckBox ID="CheckBox5Estrelas" runat="server" Text="5Estrelas" CssClass="form-check-label" AutoPostBack="True" OnCheckedChanged="CheckBox5Estrelas_CheckedChanged" />
                                </div>
                            </div>
                            <div class="col-md-12 d-flex justify-content-center align-content-center" style="margin-top: 15px;">
                                <asp:LinkButton ID="LinkButtonComentario" runat="server" CssClass="userLink" OnClick="LinkButtonComentario_Click">Registar Comentário</asp:LinkButton>
                            </div>
                            <div class="col-md-12 d-flex justify-content-center align-content-center" style="margin-top: 15px">
                                <asp:LinkButton ID="LinkButtonSair" runat="server" CssClass="userLink" OnClick="LinkButtonSair_Click" style="float: left">Sair</asp:LinkButton>
                            </div>
                        </asp:Panel>
                        <%-- FIM COMENTAR --%>
                        <div class="col-md-12 d-flex justify-content-center align-items-center">
                            <asp:GridView ID="GridViewVerComentarios" runat="server" Class="table table-responsive" Style="margin-top: 50px;" HeaderStyle-ForeColor="DarkRed" HeaderStyle-Font-Underline="false" AllowPaging="True" PageSize="8" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="5" EnableSortingAndPagingCallbacks="True" Visible="false" OnPageIndexChanging="GridViewVerComentarios_PageIndexChanging" OnRowDataBound="GridViewVerComentarios_RowDataBound">
                                <alternatingrowstyle backcolor="White" />
                                <footerstyle backcolor="#990000" font-bold="True" forecolor="White" />
                                <headerstyle backcolor="#990000" font-bold="True" forecolor="White" />
                                <pagersettings mode="NumericFirstLast" />
                                <pagerstyle backcolor="#990000" forecolor="White" horizontalalign="Center" />
                                <rowstyle backcolor="#FFFBD6" forecolor="#333333" />
                                <selectedrowstyle backcolor="#FF5B5B" font-bold="True" forecolor="White" />
                                <sortedascendingcellstyle backcolor="#FDF5AC" />
                                <sortedascendingheaderstyle backcolor="#4D0000" />
                                <sorteddescendingcellstyle backcolor="#FCF6C0" />
                                <sorteddescendingheaderstyle backcolor="#820000" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
