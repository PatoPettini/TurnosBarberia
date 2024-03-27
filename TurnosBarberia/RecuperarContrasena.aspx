<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="TurnosBarberia.RecuperarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="E-Mail:"></asp:Label>
    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ErrorMessage="Debe completar este campo" ControlToValidate="txtEmail" runat="server" />
    <asp:RegularExpressionValidator ErrorMessage="No tiene formato Email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
    <div>
        <asp:Button ID="btnRecuperar" OnClick="btnRecuperar_Click" CssClass="btn btn-secondary" runat="server" Text="Recuperar" />
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    <div><a id="btnLogIn" runat="server" href="LogIn.aspx">Loguearse</a></div>
</asp:Content>
