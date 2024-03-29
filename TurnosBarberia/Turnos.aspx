<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="TurnosBarberia.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%if (Business.Validaciones.EsAdmin((Entity.ClientesEntity)Session["cliente"]))
        { %>
    <div class="row">
        <div class="mb-3">
            <asp:Label ID="Label2" runat="server" Text="Cliente"></asp:Label>
            <asp:TextBox runat="server" ID="txtFiltrarPorCliente" CssClass="form-control" OnTextChanged="txtFiltrarPorCliente_TextChanged" AutoPostBack="true" />
        </div>
        <div>
            <asp:CheckBox ID="chkFiltroAvanzado" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" AutoPostBack="true" Text="Filtro Avanzado" runat="server" />
            <%if (chkFiltroAvanzado.Checked)
                {%>
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Barbero"></asp:Label>
                <asp:DropDownList ID="ddlBarbero" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label3" runat="server" Text="Servicio"></asp:Label>
                <asp:DropDownList ID="ddlServicio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Cualquiera" />
                    <asp:ListItem Text="Atendido" />
                    <asp:ListItem Text="Reservado" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label6" runat="server" Text="Mes"></asp:Label>
                <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Cualquiera" />
                    <asp:ListItem Text="Enero" />
                    <asp:ListItem Text="Febrero" />
                    <asp:ListItem Text="Marzo" />
                    <asp:ListItem Text="Abril" />
                    <asp:ListItem Text="Mayo" />
                    <asp:ListItem Text="Junio" />
                    <asp:ListItem Text="Julio" />
                    <asp:ListItem Text="Agosto" />
                    <asp:ListItem Text="Septiembre" />
                    <asp:ListItem Text="Octubre" />
                    <asp:ListItem Text="Noviembre" />
                    <asp:ListItem Text="Diciembre" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkFiltroDia" OnCheckedChanged="chkFiltroDia_CheckedChanged" AutoPostBack="true" Text="Filtrar por dia" runat="server" />
                <%if (chkFiltroDia.Checked)
                    { %>
                <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Dia"></asp:Label>
                    <asp:TextBox ID="txtDia" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <%} %>
            </div>
            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Filtrar" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-secondary" Text="Limpiar" OnClick="btnLimpiar_Click" />
            <%}%>
        </div>
        <%} %>
        <div class="row">
            <asp:GridView runat="server" ID="dgvTurnos" DataKeyNames="id" CssClass="table table-dark table-bordered" OnPageIndexChanging="dgvTurnos_PageIndexChanging"
                AllowPaging="true" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged" PageSize="15" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Barbero" DataField="Barbero.Nombre" />
                    <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                    <asp:BoundField HeaderText="Servicio" DataField="Servicio.Servicio" />
                    <asp:BoundField HeaderText="Dia" DataField="Dia" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField HeaderText="Hora" DataField="Hora" DataFormatString="{0:hh\:mm}" />
                    <asp:BoundField HeaderText="Precio" DataField="Servicio.Precio" DataFormatString="{0:$#####}" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
            <a href="ReservarTurno.aspx">Agregar Turno</a>
        </div>
    </div>
</asp:Content>
