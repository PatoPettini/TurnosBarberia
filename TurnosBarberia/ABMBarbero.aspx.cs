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
    public partial class ABMBarbero : System.Web.UI.Page
    {
        BarberoBusiness barberoBusiness = new BarberoBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    var id = Request.QueryString["id"];
                    BarberosEntity barbero = barberoBusiness.GetBarbero().Find(b => b.Id == Convert.ToInt32(id));
                    txtNombre.Text = barbero.Nombre;
                    txtTelefono.Text = barbero.Telefono.ToString();
                    btnAgregar.Text = "Modificar";
                    btnEliminar.Visible = true;
                }
                else
                {
                    btnEliminar.Visible = false;
                }
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                BarberosEntity barbero = new BarberosEntity();
                barbero.Nombre = txtNombre.Text;
                barbero.Telefono = long.Parse(txtTelefono.Text);
                if (Request.QueryString["id"] != null)
                {
                    var id = Request.QueryString["id"];
                    barbero.Id = Convert.ToInt32(id);
                    barberoBusiness.ModificarBarbero(barbero);
                    Response.Redirect("Barberos.aspx", false);
                }
                else
                {
                    barberoBusiness.AltaBarbero(barbero);
                    Response.Redirect("Barberos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                BarberosEntity barbero = new BarberosEntity();
                barbero.Id = Convert.ToInt32(id);
                barberoBusiness.EliminarBarbero(barbero);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}