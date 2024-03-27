﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReservarTurno.aspx.cs" Inherits="TurnosBarberia.ReservarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="https://i.imgur.com/sDzMr15.png" alt="Precios" width="350px" />
    <img src="https://i.imgur.com/fIi1UlF.png" alt="Horarios" height="350px" width="300px" />
    <div class="row">
        <div class="col-md-6">
            <%if (Business.Validaciones.EsAdmin((Entity.ClientesEntity)Session["cliente"]))
                { %>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre del cliente:</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%}
            <div class="mb-3">
                <label for="ddlBarbero" class="form-label">Barbero:</label>
                <asp:DropDownList ID="ddlBarbero" AutoPostBack="true" OnSelectedIndexChanged="ddlBarbero_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlServicio" class="form-label">Servicio:</label>
                <asp:DropDownList ID="ddlServicio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtDia" class="form-label">Dia:</label>
                <asp:TextBox ID="txtDia" OnTextChanged="txtDia_TextChanged" AutoPostBack="true" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblDia" runat="server" Text=""></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="labelHora" runat="server" CssClass="form-label" Text="Hora"></asp:Label>
                <asp:DropDownList ID="ddlHora" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <asp:Button ID="btnReservar" OnClick="btnReservar_Click" CssClass="btn btn-primary" runat="server" Text="Reservar" />
            <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
        </div>
    </div>
</asp:Content>