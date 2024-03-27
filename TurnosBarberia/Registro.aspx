<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TurnosBarberia.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtNombre" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtNombre" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Telefono:</label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtTelefono" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Solo numeros!" ValidationExpression="^[0-9]+$" ControlToValidate="txtTelefono" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtUsuario" class="form-label">Usuario:</label>
            <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtUsuario" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="No tiene formato email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtContraseña" class="form-label">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtContraseña" runat="server" />
        </div>
        <asp:Button ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-primary" runat="server" Text="Registrarme" />
    </div>
</asp:Content>
