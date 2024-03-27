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
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        Random random = new Random();
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogIn.Visible = false;
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;
                var contraseña = random.Next().ToString();
                ClientesEntity cliente = clienteBusiness.GetCliente().Find(c => c.Email == txtEmail.Text);
                if (cliente == null)
                {
                    Label2.Text = "El email ingresado no es correcto";
                    btnLogIn.Visible = false;
                }
                else
                {
                    cliente.Contraseña = contraseña;
                    clienteBusiness.ModificarCliente(cliente);
                    Envio_Email servicio = new Envio_Email();
                    servicio.ArmarCorreo(txtEmail.Text, "Recuperar contraseña", "<h1>Hola</h1> <br>Tu nueva contraseña es: " + contraseña +
                        "<br> Podes modificarla en el apartado Mi Perfil.");
                    servicio.EnviarEmail();
                    Label2.Text = "Se envio un email con tu nueva contraseña!";
                    btnLogIn.Visible = true;
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