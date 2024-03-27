using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                    if (cliente == null)
                    {
                        Session.Add("error", "debe loguearse para ingresar aca");
                        Response.Redirect("error.aspx");
                    }
                    txtUsuario.Text = cliente.Usuario;
                    txtUsuario.Enabled = false;
                    txtContraseña.Text = cliente.Contraseña;
                    txtEmail.Text = cliente.Email;
                    txtEmail.Enabled = false;
                    txtNombre.Text = cliente.Nombre;
                    txtNombre.Enabled = false;
                    txtTelefono.Text = cliente.Telefono.ToString();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch(Exception ex) 
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx",false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;
                ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                cliente.Telefono = long.Parse(txtTelefono.Text);
                cliente.Contraseña = txtContraseña.Text;
                clienteBusiness.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}