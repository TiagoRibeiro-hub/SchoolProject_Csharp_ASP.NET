<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="InseririNovoVinho.aspx.cs" Inherits="WebVinhos.Utilizadores.InseririNovoVinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Admin/forms.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />


</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonInserir" />
        </Triggers>
        <ContentTemplate>

            <div class="container d-flex flex-column">

                <div class="row g-3 divCaixaForms">
                    <%-- Titulo --%>
                    <div class="col-md-12 divTitulo" style="margin-bottom: 25px;">
                        <asp:Label ID="LabelVinhos" runat="server" Text="Inserir Vinho" CssClass="tituloLabel"></asp:Label>
                    </div>
                    <%-- Nome --%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="dropDownVinho"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>
                    <%-- Ano --%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelAno" runat="server" Text="Ano" CssClass="camposLabel "></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="TextBoxAno" runat="server" CssClass="dropDownVinho"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAno" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidatorAno" runat="server" ErrorMessage="Data entre 1900 e ano corrente" Display="Dynamic" MinimumValue="1900" Type="Integer" CssClass="valiTextNumeros" ControlToValidate="TextBoxAno"></asp:RangeValidator>
                    </div>
                    <%-- Volume--%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelVolume" runat="server" Text="Volume" CssClass="camposLabel "></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="TextBoxVolume" runat="server" CssClass="dropDownVinho"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxVolume" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                        
                        <asp:RangeValidator ID="RangeValidatorVolume" runat="server" ErrorMessage="Valor entre 0 e 10" Display="Dynamic" ControlToValidate="TextBoxVolume" MinimumValue="0" MaximumValue="10" Type="Double" CssClass="valiTextNumeros"></asp:RangeValidator>                    
                    </div>
                    <%-- TeorAlcoolico--%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelTeorAlcoolico" runat="server" Text="Teor Alcoolico" CssClass="camposLabel "></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="TextBoxTeorAlcoolico" runat="server" CssClass="dropDownVinho"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxTeorAlcoolico" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                        
                        <asp:RangeValidator ID="RangeValidatorTeorAlcoolico" runat="server" ErrorMessage="Valor entre 0 e 99,99" Display="Dynamic" MinimumValue="0" MaximumValue="99,99" Type="Double" CssClass="valiTextNumeros" ControlToValidate="TextBoxTeorAlcoolico"></asp:RangeValidator>                                                
                    </div>
                    <%-- Temperatura--%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelTemperatura" runat="server" Text="Temperatura" CssClass="camposLabel "></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="TextBoxTemperatura" runat="server" CssClass="dropDownVinho"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxTemperatura" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                        
                        <asp:RangeValidator ID="RangeValidatorTemperatura" runat="server" ErrorMessage="Valor entre 0 e 99,99" Display="Dynamic" MinimumValue="0" MaximumValue="99,99" Type="Double" CssClass="valiTextNumeros" ControlToValidate="TextBoxTemperatura"></asp:RangeValidator>                                                
                    </div>

                    <%-- Regioes --%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelRegiao" runat="server" Text="Região" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:DropDownList ID="DropDownListRegiao" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <%-- Produtor --%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelProdutor" runat="server" Text="Produtor" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:DropDownList ID="DropDownListProdutor" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <%-- Tipos Vinho--%>
                    <div class="col-md-3 ">
                        <asp:Label ID="LabelTiposVinho" runat="server" Text="Tipos d'Vinhos" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:DropDownList ID="DropDownListTiposVinho" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                    </div>

                    <%-- Foto --%>
                    <div class="col-md-6" style="text-align: center;">
                        <asp:Label ID="LabelCastasDisponiveis" runat="server" Text="Castas Disponiveis" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-6" style="text-align: center;">
                        <asp:Label ID="LabelEnologosDisponiveis" runat="server" Text="Enologos Disponiveis" CssClass="camposLabel"></asp:Label>
                    </div>


                    <%-- Grid View--%>
                    <div class="col-md-6 d-flex justify-content-center align-content-center">
                        <asp:GridView ID="GridViewCastasDisponiveis" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateSelectButton="True" OnRowDataBound="GridViewCastasDisponiveis_RowDataBound">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle ForeColor="darkred" BackColor="White" Font-Bold="True"></HeaderStyle>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="black" />
                            <SelectedRowStyle BackColor="#B3B3B3" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <div class="col-md-6 d-flex justify-content-center align-content-center">
                        <asp:GridView ID="GridViewEnologosDisponiveis" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateSelectButton="True" OnRowDataBound="GridViewEnologosDisponiveis_RowDataBound">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle ForeColor="darkred" BackColor="White" Font-Bold="True"></HeaderStyle>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="black" />
                            <SelectedRowStyle BackColor="#B3B3B3" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <%-- Botoes Associar--%>
                    <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 30px;">
                        <asp:Button ID="ButtonAssociarCasta" runat="server" Text="Associar Casta" CssClass="btnMeu" Style="width: 250px;" OnClick="ButtonAssociarCasta_Click" CausesValidation="False" />
                    </div>
                    <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 30px;">
                        <asp:Button ID="ButtonAssociarEnologo" runat="server" Text="Associar Enologo" CssClass="btnMeu" Style="width: 250px;" OnClick="ButtonAssociarEnologo_Click" CausesValidation="False" />
                    </div>

                    <%-- Label Escolhidos --%>
                    <div class="col-md-6" style="text-align: center; margin-top: 30px;">
                        <asp:Label ID="LabelCastasEscolhidas" runat="server" Text="Castas Escolhidas" CssClass="camposLabel" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-6" style="text-align: center; margin-top: 30px;">
                        <asp:Label ID="LabelEnologosEscolhidos" runat="server" Text="Enologos Escolhidos" CssClass="camposLabel" Visible="false"></asp:Label>
                    </div>
                    <%-- Grid View Escolhidos --%>
                    <div class="col-md-6 d-flex justify-content-center align-content-center">
                        <asp:GridView ID="GridViewCastasEscolhidas" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateSelectButton="True" OnRowDataBound="GridViewCastasEscolhidas_RowDataBound">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle ForeColor="darkred" BackColor="White" Font-Bold="True"></HeaderStyle>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="black" />
                            <SelectedRowStyle BackColor="#B3B3B3" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <div class="col-md-6 d-flex justify-content-center align-content-center">
                        <asp:GridView ID="GridViewEnologosEscolhidos" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateSelectButton="True" OnRowDataBound="GridViewEnologosEscolhidos_RowDataBound">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle ForeColor="darkred" BackColor="White" Font-Bold="True"></HeaderStyle>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="black" />
                            <SelectedRowStyle BackColor="#B3B3B3" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>

                    <%-- Botoes Remover--%>
                    <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 30px;">
                        <asp:Button ID="ButtonRemoverCasta" runat="server" Text="Remover Casta" CssClass="btnMeu" Style="width: 250px;" Visible="false" OnClick="ButtonRemoverCasta_Click" CausesValidation="False" />
                    </div>
                    <div class="col-md-6 d-flex justify-content-center align-content-center" style="margin-top: 30px;">
                        <asp:Button ID="ButtonRemoverEnologo" runat="server" Text="Remover Enologo" CssClass="btnMeu" Style="width: 250px;" Visible="false" OnClick="ButtonRemoverEnologo_Click" CausesValidation="False" />
                    </div>

                    <%-- Foto --%>
                    <div class="col-md-8 d-flex justify-content-center align-content-center">
                        <asp:Label ID="LabelFoto" runat="server" Text="Foto" CssClass="camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-4 d-flex justify-content-center align-content-center">
                        <asp:CheckBox ID="CheckBoxActivar" runat="server" AutoPostBack="True" Checked="True" Text="Desactivada a possibilidade de eliminar " CssClass="camposLabel camposLabelDesactivar" OnCheckedChanged="CheckBoxActivar_CheckedChanged" />
                    </div>
                    <div class="col-md-8 d-flex justify-content-center align-content-center">
                        <asp:FileUpload ID="FileUploadImagem" runat="server" />
                    </div>

                    <%-- Botao Inserir--%>
                    <div class="col-md-12 d-flex justify-content-center align-content-center" style="margin-top: 50px;">
                        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" CssClass="btnMeu" Style="width: 250px;" OnClick="ButtonInserir_Click" />
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
