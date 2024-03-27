using Business;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class Turnos : System.Web.UI.Page
    {
        TurnosBusiness turnosBusiness = new TurnosBusiness();
        BarberoBusiness barberoBusiness = new BarberoBusiness();
        ServicioBusiness servicioBusiness = new ServicioBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                    if (cliente == null)
                    {
                        Session.Add("error", "debe loguearse para entrar aca");
                        Response.Redirect("error.aspx");
                    }
                    if (Validaciones.EsAdmin(cliente))
                    {
                        dgvTurnos.DataSource = turnosBusiness.GetTurno();
                        dgvTurnos.DataBind();
                        ddlBarbero.DataSource = barberoBusiness.GetBarbero();
                        ddlBarbero.DataTextField = "nombre";
                        ddlBarbero.DataValueField = "id";
                        ddlBarbero.DataBind();
                        ddlBarbero.Items.Add("Cualquiera");
                        ddlServicio.DataSource = servicioBusiness.GetServicios();
                        ddlServicio.DataTextField = "servicio";
                        ddlServicio.DataValueField = "id";
                        ddlServicio.DataBind();
                        ddlServicio.Items.Add("Cualquiera");
                    }
                    else
                    {
                        List<TurnosEntity> lista = turnosBusiness.GetTurno().FindAll(t => t.IdCliente == cliente.Id);
                        dgvTurnos.DataSource = lista;
                        dgvTurnos.DataBind();
                    }
                }
                if (chkFiltroAvanzado.Checked)
                {
                    txtFiltrarPorCliente.Text = "";
                    txtFiltrarPorCliente.Enabled = false;
                }
                else txtFiltrarPorCliente.Enabled = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvTurnos.SelectedDataKey.Value.ToString();
            Response.Redirect("ReservarTurno.aspx?id=" + id);
        }

        protected void txtFiltrarPorCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<TurnosEntity> lista = turnosBusiness.GetTurno().FindAll(t => t.Cliente.Nombre.ToUpper().Contains(txtFiltrarPorCliente.Text.ToUpper()));
                dgvTurnos.DataSource = lista;
                dgvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTurnos.DataSource = turnosBusiness.GetTurno();
                dgvTurnos.DataBind();
                ddlServicio.Text = "Cualquiera";
                ddlBarbero.Text = "Cualquiera";
                lblCantidad.Text = "Cantidad de turnos: " + turnosBusiness.GetTurno().Count.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TurnosEntity> lista = turnosBusiness.FiltrarTurnos(ddlBarbero.SelectedItem.ToString(), ddlServicio.SelectedItem.ToString(), ddlEstado.SelectedItem.ToString(), ddlMes.SelectedItem.ToString(), txtDia.Text);
                dgvTurnos.DataSource = lista;
                dgvTurnos.DataBind();
                lblCantidad.Text = "Cantidad de turnos: " + lista.Count.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzado.Checked)
            {
                ddlBarbero.Text = "Cualquiera";
                ddlServicio.Text = "Cualquiera";
            }
        }

        protected void chkFiltroDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroDia.Checked)
            {
                ddlMes.Enabled = false;
                ddlMes.Text = "Cualquiera";
            }
            else ddlMes.Enabled = true;
        }
    }
}