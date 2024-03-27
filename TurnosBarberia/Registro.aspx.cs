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
    public partial class Registro : System.Web.UI.Page
    {
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                ClientesEntity cliente = new ClientesEntity();
                cliente.Nombre = txtNombre.Text;
                cliente.Telefono = long.Parse(txtTelefono.Text);
                cliente.Usuario = txtUsuario.Text;
                cliente.Email = txtEmail.Text;
                cliente.Contraseña = txtContraseña.Text;
                cliente.Tipo = "Cliente";
                clienteBusiness.AltaCliente(cliente);
                cliente = clienteBusiness.GetCliente().Find(c => c.Usuario == cliente.Usuario);
                Session.Add("cliente", cliente);
                Envio_Email servicio = new Envio_Email();
                servicio.ArmarCorreo(cliente.Email, "Registro", "<h1>Hola " + cliente.Nombre + "!</h1> <br>Tu registro fue exitoso, te damos la bienvenida a la comunidad.");
                servicio.EnviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx",false);
            }
        }
    }
}