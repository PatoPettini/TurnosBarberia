<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ABMBarbero.aspx.cs" Inherits="TurnosBarberia.ABMBarbero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const txtNombre = document.getElementById("txtNombre");
            const txtTelefono = document.getElementById("txtTelefono");
            if (txtNombre.value == "" && txtTelefono.value == "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                txtTelefono.classList.add("is-invalid");
                txtTelefono.classList.remove("is-valid");
                return false;
            } else if (txtNombre.value == "" && txtTelefono.value != "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                txtTelefono.classList.add("is-valid");
                txtTelefono.classList.remove("is-invalid");
                return false;
            } else if (txtNombre.value != "" && txtTelefono.value == "") {
                txtNombre.classList.add("is-valid");
                txtNombre.classList.remove("is-invalid");
                txtTelefono.classList.add("is-invalid");
                txtTelefono.classList.remove("is-valid");
                return false;
            } else {
                txtNombre.classList.add("is-valid");
                txtNombre.classList.remove("is-invalid");
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
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtNombre" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtNombre" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Telefono:</label>
            <asp:TextBox ID="txtTelefono" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtTelefono" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Solo numeros!" ValidationExpression="^[0-9]+$" ControlToValidate="txtTelefono" runat="server" />
        </div>
        <asp:Button ID="btnAgregar" OnClientClick="return validar()" OnClick="Agregar_Click" CssClass="btn btn-primary" runat="server" Text="Ingresar" />
        <asp:Button ID="btnEliminar" OnClick="Eliminar_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
    </div>
</asp:Content>
