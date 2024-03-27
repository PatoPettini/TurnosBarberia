<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TurnosBarberia.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const txtContraseña = document.getElementById("txtContraseña");
            const txtTelefono = document.getElementById("txtTelefono");
            if (txtContraseña.value == "" && txtTelefono.value == "") {
                txtContraseña.classList.add("is-invalid");
                txtContraseña.classList.remove("is-valid");
                txtTelefono.classList.add("is-invalid");
                txtTelefono.classList.remove("is-valid");
                return false;
            } else if (txtContraseña.value == "" && txtTelefono.value != "") {
                txtContraseña.classList.add("is-invalid");
                txtContraseña.classList.remove("is-valid");
                txtTelefono.classList.add("is-valid");
                txtTelefono.classList.remove("is-invalid");
                return false;
            } else if (txtContraseña.value != "" && txtTelefono.value == "") {
                txtContraseña.classList.add("is-valid");
                txtContraseña.classList.remove("is-invalid");
                txtTelefono.classList.add("is-invalid");
                txtTelefono.classList.remove("is-valid");
                return false;
            } else {
                txtContraseña.classList.add("is-valid");
                txtContraseña.classList.remove("is-invalid");
                txtTelefono.classList.add("is-valid");
                txtTelefono.classList.remove("is-invalid");
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">
        <div class="mb-3">
            <label for="txtUsuario" class="form-label">Usuario:</label>
            <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtContraseña" class="form-label">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida" ControlToValidate="txtContraseña" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Telefono:</label>
            <asp:TextBox ID="txtTelefono" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="El telefono es requerido" ControlToValidate="txtTelefono" runat="server" />
        </div>
        <asp:Button ID="btnGuardar" OnClientClick="return validar()" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
    </div>
</asp:Content>
