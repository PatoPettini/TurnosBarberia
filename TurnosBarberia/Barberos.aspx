<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Barberos.aspx.cs" Inherits="TurnosBarberia.Barberos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:GridView ID="dgvBarberos" DataKeyNames="id" CssClass="table table-dark table-bordered" OnSelectedIndexChanged="dgvBarberos_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
        <a href="ABMBarbero.aspx">Agregar Barbero</a>
    </div>
</asp:Content>
