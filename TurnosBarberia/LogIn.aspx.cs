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
    public partial class LogIn : System.Web.UI.Page
    {
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                ClientesEntity cl = (ClientesEntity)clienteBusiness.GetCliente().Find(c => c.Email == txtEmail.Text && c.Contraseña == txtContraseña.Text);
                if (cl != null)
                {
                    Session.Add("cliente", cl);
                    Response.Redirect("Reservarturno.aspx", false);
                }
                else
                {
                    Session.Add("error", "el email y/o la contraseña son incorrectos");
                    Response.Redirect("error.aspx", false);
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