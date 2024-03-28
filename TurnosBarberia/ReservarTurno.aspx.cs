using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class ReservarTurno : System.Web.UI.Page
    {
        BarberoBusiness barberoBusiness = new BarberoBusiness();
        TurnosBusiness turnosBusiness = new TurnosBusiness();
        ServicioBusiness servicioBusiness = new ServicioBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClientesEntity c = (ClientesEntity)Session["cliente"];
                if (c == null)
                {
                    Session.Add("error", "debe loguearse para ingresar aca");
                    Response.Redirect("error.aspx");
                }
                if (!IsPostBack)
                {
                    ddlBarbero.DataSource = barberoBusiness.GetBarbero();
                    ddlBarbero.DataTextField = "Nombre";
                    ddlBarbero.DataValueField = "ID";
                    ddlBarbero.DataBind();
                    ddlServicio.DataSource = servicioBusiness.GetServicios();
                    ddlServicio.DataTextField = "Servicio";
                    ddlServicio.DataValueField = "ID";
                    ddlServicio.DataBind();
                    btnEliminar.Visible = false;

                    if (Request.QueryString["id"] != null)
                    {
                        var id = Request.QueryString["id"];
                        TurnosEntity turno = turnosBusiness.GetTurno().Find(t => t.Id == Convert.ToInt32(id));
                        ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                        turnosBusiness.ValidarId(turno, cliente);
                        ddlBarbero.SelectedValue = turno.IdPeluquero.ToString();
                        ddlServicio.SelectedValue = turno.IdServicio.ToString();
                        txtDia.Text = turno.Dia.ToString("yyyy-MM-dd");
                        txtNombre.Text = turno.Cliente.Nombre;
                        ddlHora.DataSource = turnosBusiness.GetTurnosDisponibles(txtDia.Text, ddlBarbero.SelectedItem.ToString());
                        ddlHora.DataBind();
                        ddlHora.Items.Add(turno.Hora.ToString());
                        ddlHora.Text = turno.Hora.ToString();
                        btnReservar.Text = "Modificar";
                        btnEliminar.Visible = true;
                        labelHora.Visible = true;
                        ddlHora.Visible = true;
                        btnReservar.Enabled = true;
                    }
                    else
                    {
                        btnEliminar.Visible = false;
                        labelHora.Visible = false;
                        ddlHora.Visible = false;
                        btnReservar.Enabled = false;
                    }
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Validaciones.EsAdmin((ClientesEntity)Session["cliente"])))
                {
                    if (txtNombre.Text == "") throw new Exception("Debe completar el campo nombre");
                }

                ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                TurnosEntity turno = new TurnosEntity();
                if (Validaciones.EsAdmin(cliente))
                {
                    turno.Cliente = new ClientesEntity();
                    turno.Cliente.Nombre = txtNombre.Text;
                }
                else turno.IdCliente = cliente.Id;
                turno.IdPeluquero = Convert.ToInt32(ddlBarbero.SelectedValue);
                turno.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
                turno.Servicio = new ServicioEntity();
                turno.Servicio.Servicio = ddlServicio.SelectedItem.ToString();
                turno.Dia = Convert.ToDateTime(txtDia.Text);
                turno.Hora = TimeSpan.Parse(ddlHora.Text);
                if (Request.QueryString["id"] != null)
                {
                    turno.Id = Convert.ToInt32(Request.QueryString["id"]);
                    turnosBusiness.ModificarTurno(turno);
                    Envio_Email servicio = new Envio_Email();
                    servicio.ArmarCorreo(cliente.Email, "Modificacion de turno", "<h1>Hola " + cliente.Nombre + "!</h1> <br>Modificaste tu turno para el dia " + txtDia.Text + " a las " + ddlHora.Text + " horas.<br>" + turno.Servicio.Servicio + " con " + ddlBarbero.SelectedItem);
                    servicio.EnviarEmail();
                    Response.Redirect("Turnos.aspx", false);
                }
                else
                {
                    turnosBusiness.AltaTurno(turno);
                    Envio_Email servicio = new Envio_Email();
                    servicio.ArmarCorreo(cliente.Email, "Alta de turno", "<h1>Hola " + cliente.Nombre + "!</h1> <br>Se agendo tu turno para el dia " + txtDia.Text + " a las " + ddlHora.Text + " horas." + turno.Servicio.Servicio + " con " + ddlBarbero.SelectedItem);
                    servicio.EnviarEmail();
                    Response.Redirect("turnos.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                TurnosEntity turno = new TurnosEntity();
                var id = Request.QueryString["id"];
                turno.Id = Convert.ToInt32(id);
                turnosBusiness.EliminarTurno(turno); 
                Response.Redirect("turnos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txtDia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDia.Text != "")
                {
                    if (Convert.ToDateTime(txtDia.Text) < DateTime.Today)
                    {
                        lblDia.Text = "El dia no puede ser anterior al dia de hoy";
                        labelHora.Visible = false;
                        ddlHora.Visible = false;
                        btnReservar.Enabled = false;
                    }
                    else if (Convert.ToDateTime(txtDia.Text) > DateTime.Now.AddDays(7))
                    {
                        lblDia.Text = "No se puede reservar un turno para mas de una semana";
                        labelHora.Visible = false;
                        ddlHora.Visible = false;
                        btnReservar.Enabled = false;
                    }
                    else
                    {
                        int diadelasemana = Convert.ToInt32(Convert.ToDateTime(txtDia.Text).DayOfWeek);
                        var a = Convert.ToDateTime(txtDia.Text);
                        var b = Convert.ToDateTime("01/04/2024");
                        if (Convert.ToDateTime(txtDia.Text) == Convert.ToDateTime("01/04/2024"))
                        {
                            lblDia.Text = "Cerrado por remodelacion";
                            labelHora.Visible = false;
                            ddlHora.Visible = false;
                            btnReservar.Enabled = false;
                        }
                        else if (diadelasemana == 0)
                        {
                            lblDia.Text = "Los domingos no está abierta la barberia";
                            labelHora.Visible = false;
                            ddlHora.Visible = false;
                            btnReservar.Enabled = false;
                        }
                        else
                        {
                            lblDia.Text = "";
                            labelHora.Visible = true;
                            ddlHora.Visible = true;
                            ddlHora.DataSource = turnosBusiness.GetTurnosDisponibles(txtDia.Text, ddlBarbero.SelectedItem.ToString());
                            ddlHora.DataBind();
                            btnReservar.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlBarbero_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDia.Text != "")
                {
                    ddlHora.DataSource = turnosBusiness.GetTurnosDisponibles(txtDia.Text, ddlBarbero.SelectedItem.ToString());
                    ddlHora.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}