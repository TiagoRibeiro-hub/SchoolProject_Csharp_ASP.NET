<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="VerVinho.aspx.cs" Inherits="WebVinhos.VerVinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Admin/forms.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.min.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Indice2" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="d-flex justify-content-center align-items-center">
                <div class="row g-3" style="margin: 20px; margin-bottom: 25px; width: 40vw;">
                    <div class="col-md-8 row g-3">
                        <div class="col-md-12">
                            <asp:Label ID="NomeLabel" runat="server" CssClass="linkTitulo" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Produtor: </span>
                            <asp:HyperLink ID="ProdutorLabel" runat="server" CssClass="userLink"></asp:HyperLink>
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Região: </span>
                            <asp:Label ID="RegiãoLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Tipo de Vinho: </span>
                            <asp:Label ID="TipoVinhoLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Ano: </span>
                            <asp:Label ID="AnoLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Volume: </span>
                            <asp:Label ID="VolumeLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Teor Alcoolico: </span>
                            <asp:Label ID="TeorAlcoolicoLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Temperatura: </span>
                            <asp:Label ID="TemperaturaLabel" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <span class="tituloLabel spanSize">Utilizador: </span>
                            <asp:Label ID="UtilizadorLabel" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <asp:Image ID="Image1" runat="server" CssClass="imgVerVinhos" />
                    </div>

                    <div class="col-md-12 d-flex justify-content-center align-content-center" style="padding-top: 0px">
                        <div class="col-md-6 d-flex justify-content-center align-content-center">
                            <asp:GridView ID="GridViewCastas" runat="server" AllowPaging="True" OnPageIndexChanging="GridViewCastasEnologos_PageIndexChanging" PageSize="8" Style="margin-bottom: 50px;" BorderStyle="None" HeaderStyle-ForeColor="DarkRed" HeaderStyle-Font-Underline="false">
                            </asp:GridView>
                        </div>
                        <div class="col-md-6 d-flex justify-content-center align-content-center">
                            <asp:GridView ID="GridViewEnologos" runat="server" AllowPaging="True" OnPageIndexChanging="GridViewCastasEnologos_PageIndexChanging" PageSize="8" Style="margin-top: 50px;" BorderStyle="None" HeaderStyle-ForeColor="DarkRed" HeaderStyle-Font-Underline="false">
                            </asp:GridView>
                        </div>
                    </div>
                    <%-- COMENTAR --%>

                    <asp:Panel ID="PanelComentar" runat="server" Visible="false" Style="margin-bottom: 40px;">
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
                            <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 15px;">
                                <asp:LinkButton ID="LinkButtonComentario" runat="server" CssClass="userLink" OnClick="LinkButtonComentario_Click">Registar Comentário</asp:LinkButton>
                            </div>
                            <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 15px;">
                                <asp:LinkButton ID="LinkButtonVerComentarios" runat="server" CssClass="userLink" OnClick="LinkButtonVerComentarios_Click">Ver Comentarios</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-12 d-flex justify-content-center align-content-center" style="margin-top: 15px">
                            <asp:LinkButton ID="LinkButtonSair" runat="server" CssClass="userLink" OnClick="LinkButtonSair_Click" Style="float: left">Sair</asp:LinkButton>
                        </div>
                    </asp:Panel>


                    <%-- FIM COMENTAR --%>
                    <div class="col-md-4 d-flex justify-content-center align-content-center" style="margin-top: 40px;">
                        <asp:Button ID="ButtonEditar" runat="server" Text="Editar" OnClick="ButtonEditar_Click" Visible="false" CssClass="btnForms"></asp:Button>
                    </div>
                    <div class="col-md-4 d-flex justify-content-center align-content-center" style="margin-top: 40px;">
                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" Visible="false" CssClass="btnForms"></asp:Button>
                    </div>
                    <div class="col-md-4 d-flex justify-content-center align-content-center" style="margin-top: 40px;">
                        <asp:Button ID="ButtonComentar" runat="server" Text="Comentar" Visible="false" CssClass="btnForms" OnClick="ButtonComentar_Click"></asp:Button>
                    </div>
                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                        <asp:GridView ID="GridViewVerComentarios" runat="server" Class="table table-responsive" Style="margin-top: 50px;" HeaderStyle-ForeColor="DarkRed" HeaderStyle-Font-Underline="false" OnRowDataBound="GridViewVerComentarios_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridViewCastasEnologos_PageIndexChanging" PageSize="8" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="5" EnableSortingAndPagingCallbacks="True" Visible="false">
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
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
