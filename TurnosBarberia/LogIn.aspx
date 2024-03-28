<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TurnosBarberia.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtContraseña = document.getElementById("txtContraseña");
            if (txtEmail.value == "" && txtContraseña.value == "") {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                txtContraseña.classList.add("is-invalid");
                txtContraseña.classList.remove("is-valid");
                return false;
            } else if (txtEmail.value == "" && txtContraseña.value != "") {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                txtContraseña.classList.add("is-valid");
                txtContraseña.classList.remove("is-invalid");
                return false;
            } else if (txtEmail.value != "" && txtContraseña.value == "") {
                txtEmail.classList.add("is-valid");
                txtEmail.classList.remove("is-invalid");
                txtContraseña.classList.add("is-invalid");
                txtContraseña.classList.remove("is-valid");
                return false;
            } else {
                txtEmail.classList.add("is-valid");
                txtEmail.classList.remove("is-invalid");
                txtContraseña.classList.add("is-valid");
                txtContraseña.classList.remove("is-invalid");
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-4 d-flex justify-content-center">
        <div class="border rounded p-5">
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="No tiene formato Email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtContraseña" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtContraseña" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtContraseña" runat="server" />
            </div>
            <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" OnClientClick="return validar()" CssClass="btn btn-primary" runat="server" Text="Ingresar" />
            <div>
                <a href="RecuperarContrasena.aspx">He olvidado mi contraseña</a>
            </div>
        </div>
    </div>
</asp:Content>
