<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/indice2.master" AutoEventWireup="true" CodeBehind="formVinhos.aspx.cs" Inherits="WebVinhos.formVinhos" %>

<%@ MasterType VirtualPath="~/Admin/indice2.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderFormHead" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="forms.css" rel="stylesheet" />
    <link href="../Web%20Form%20User%20Control/UserContro.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
             <asp:PostBackTrigger ControlID="ButtonInserir" /> 
        </Triggers>
        <ContentTemplate>

            <div class="container d-flex flex-column">

                <div class="row g-3 divCaixaForms">
                    <%-- Titulo --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelVinhos" runat="server" Text="Vinhos" CssClass="tituloLabel"></asp:Label>
                    </div>

                    <%-- Nome --%>
                    <div class="col-md-12">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control" CausesValidation="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" ControlToValidate="TextBoxNome" Display="Dynamic" ErrorMessage="Só deve incluir letras (maiúsculas ou minúsculas) e espaços" ValidationExpression="^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$" CssClass="valiTextNumeros"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Ano --%>
                    <div class="col-md-3">
                        <asp:Label ID="LabelAno" runat="server" Text="Ano" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxAno" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAno" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidatorAno" runat="server" ErrorMessage="Data entre 1900 e ano corrente" Display="Dynamic" MinimumValue="1900" Type="Double" CssClass="valiTextNumeros" ControlToValidate="TextBoxAno"></asp:RangeValidator>
                    </div>

                    <%-- Volume --%>
                    <div class="col-md-3">
                        <asp:Label ID="LabelVolume" runat="server" Text="Volume" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxVolume" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxVolume" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                        
                        <asp:RangeValidator ID="RangeValidatorVolume" runat="server" ErrorMessage="Valor entre 0 e 10" Display="Dynamic" ControlToValidate="TextBoxVolume" MinimumValue="0" MaximumValue="10" Type="Integer" CssClass="valiTextNumeros"></asp:RangeValidator>
                    </div>

                    <%-- TeorAlcoolico --%>
                    <div class="col-md-3">
                        <asp:Label ID="LabelTeorAlcoolico" runat="server" Text="Teor Alcoolico" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxTeorAlcoolico" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxTeorAlcoolico" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                                                
                        <asp:RangeValidator ID="RangeValidatorTeorAlcoolico" runat="server" ErrorMessage="Valor entre 0 e 99,99" Display="Dynamic" MinimumValue="0" MaximumValue="99,99" Type="Double" CssClass="valiTextNumeros" ControlToValidate="TextBoxTeorAlcoolico"></asp:RangeValidator>                        
                    </div>

                    <%-- Temperatura --%>
                    <div class="col-md-3">
                        <asp:Label ID="LabelTemperatura" runat="server" Text="Temperatura" CssClass="form-label camposLabel"></asp:Label>
                        <asp:TextBox ID="TextBoxTemperatura" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxTemperatura" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>                        
                        <asp:RangeValidator ID="RangeValidatorTemperatura" runat="server" ErrorMessage="Valor entre 0 e 99,99" Display="Dynamic" MinimumValue="0" MaximumValue="99,99" Type="Double" CssClass="valiTextNumeros" ControlToValidate="TextBoxTemperatura"></asp:RangeValidator>                            
                    </div>

                    <%-- Regiao --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelRegiao" runat="server" Text="Região" CssClass="form-label camposLabel"></asp:Label>
                        <asp:DropDownList ID="DropDownListRegiao" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegiao" runat="server" ControlToValidate="DropDownListRegiao" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                    </div>

                    <%-- Produtor --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelProdutor" runat="server" Text="Produtor" CssClass="form-label camposLabel"></asp:Label>
                        <asp:DropDownList ID="DropDownListProdutor" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProdutor" runat="server" ControlToValidate="DropDownListProdutor" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                    </div>

                    <%-- Tipo Vinho --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelTipoVinho" runat="server" Text="Tipo de Vinho" CssClass="form-label camposLabel"></asp:Label>
                        <asp:DropDownList ID="DropDownListTipoVinho" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipoVinho" runat="server" ControlToValidate="DropDownListTipoVinho" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                    </div>

                    <%-- Utilizador --%>
                    <div class="col-md-6">
                        <asp:Label ID="LabelUtilizador" runat="server" Text="Utilizador: " CssClass="form-label camposLabel"></asp:Label>
                        <asp:Label ID="LabelUtilizadorNome" runat="server" CssClass="form-label camposLabel" Style="color: black; padding-left: 20px"></asp:Label>
                    </div>

                    <%-- Foto --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelFoto" runat="server" Text="Fotografia" CssClass="form-label camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-12 divTitulo">
                        <asp:Image ID="ImageFoto" runat="server" CssClass="Foto" />
                    </div>
                    <div class="col-md-12 divTitulo">
                        <asp:FileUpload ID="FileUploadImagem" runat="server" />
                    </div>

                    <%-- Label Castas e Enologos --%>     
                    <div class="col-md-6 divTitulo">
                        <asp:Label ID="LabelCastas" runat="server" Text="Castas" CssClass="form-label camposLabel"></asp:Label>
                    </div>
                    <div class="col-md-6 divTitulo">
                        <asp:Label ID="LabelEnologos" runat="server" Text="Enologos" CssClass="form-label camposLabel"></asp:Label>
                    </div>

                    <%-- Castas e Enologos dropdownlist --%>
                    <div class="col-md-6 divTitulo">
                        <asp:DropDownList ID="DropDownListCastas" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCastas" runat="server" ControlToValidate="DropDownListCastas" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6 divTitulo">
                        <asp:DropDownList ID="DropDownListEnologos" runat="server" CssClass="dropDownVinho" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEnologo" runat="server" ControlToValidate="DropDownListEnologos" Display="Dynamic" ErrorMessage="*" CssClass="valiText"></asp:RequiredFieldValidator>
                    </div>


                    <%-- GRIDVIEW Castas e Enologos --%>
                    <div class="col-md-6 divTitulo">
                        <asp:ListBox ID="ListBoxCastas" runat="server" CssClass="listbox" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    <div class="col-md-6 divTitulo">
                        <asp:ListBox ID="ListBoxEnologos" runat="server" CssClass="listbox" SelectionMode="Multiple"></asp:ListBox>
                    </div>

                    <%-- Botoes --%>
                    <div class="col-md-6 divTitulo d-flex justify-content-evenly">
                        <asp:Button ID="ButtonInserirCasta" runat="server" Text="Inserir" CssClass="btnForms" OnClick="ButtonInserirCasta_Click" CausesValidation="False" />
                        <asp:Button ID="ButtonEliminarCasta" runat="server" Text="Eliminar" CssClass="btnForms" OnClick="ButtonEliminarCasta_Click" CausesValidation="False" />
                    </div>

                    <div class="col-md-6 divTitulo d-flex justify-content-evenly">
                        <asp:Button ID="ButtonInserirEnologo" runat="server" Text="Inserir" CssClass="btnForms" OnClick="ButtonInserirEnologo_Click" CausesValidation="False" />
                        <asp:Button ID="ButtonEliminarEnologo" runat="server" Text="Eliminar" CssClass="btnForms" OnClick="ButtonEliminarEnologo_Click" CausesValidation="False" />
                    </div>

                    <%-- Activar --%>
                    <div class="col-md-12">
                        <div class="form-check">
                            <asp:CheckBox ID="CheckBoxActivar" runat="server" Text="Desactivada a possibilidade de eliminar " CssClass="camposLabel camposLabelDesactivar" Checked="True" AutoPostBack="True" OnCheckedChanged="CheckBoxActivar_CheckedChanged" />
                        </div>
                    </div>


                    <%-- LINK INSERIR --%>
                    <div class="col-md-12">
                        <div class="form-check">
                            <asp:LinkButton ID="LinkButtonInserir" runat="server" CssClass="camposLabel linkButton" Visible="False" Text="Inserir" OnClick="LinkButtonInserir_Click" CausesValidation="False"></asp:LinkButton>
                        </div>
                    </div>

                    <%-- Botoes --%>
                    <div class="col-md-12 d-flex justify-content-evenly">
                        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" CssClass="btnForms" OnClick="ButtonInserir_Click" />
                        <div>
                            <asp:Button ID="ButtonEliminar" runat="server" Text="Ocultar" CssClass="btnForms" OnClick="ButtonEliminar_Click" Visible="False" CausesValidation="False" />
                            <asp:Button ID="ButtonEliminarDeVez" runat="server" Text="Eliminar de vez" CssClass="btnForms btnEliminarVez" OnClick="ButtonEliminarDeVez_Click" Visible="False" CausesValidation="False" />
                        </div>
                    </div>

                    <%-- Vinhos Registados --%>
                    <div class="col-md-12 divTitulo">
                        <asp:Label ID="LabelVinhosRegistados" runat="server" Text="Vinhos Registados" CssClass="form-label camposLabel" Style="font-weight: bold;"></asp:Label>
                    </div>
                </div>

                <%-- GRIDVIEW --%>
                <div class="container divCaixaGrid">
                    <asp:GridView ID="GridViewVinhos" runat="server" CssClass="table table-responsive table-hover" AllowSorting="True" HorizontalAlign="Center" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="GridViewVinhos_PageIndexChanging" OnRowDataBound="GridViewVinhos_RowDataBound" OnSelectedIndexChanged="GridViewVinhos_SelectedIndexChanged" PageSize="6" EnableSortingAndPagingCallbacks="True">
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

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
