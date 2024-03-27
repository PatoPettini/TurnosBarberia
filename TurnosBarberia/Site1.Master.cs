using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClientesEntity cliente = (ClientesEntity)Session["cliente"];
                if (cliente == null)
                {
                    if (!(Page is LogIn || Page is Registro || Page is RecuperarContraseña || Page is Error))
                    {
                        Session.Add("error", "debe loguearse para entrar aca!");
                        Response.Redirect("error.aspx", false);
                    }
                }
                else
                {
                    lblUser.Text = cliente.Nombre;
                    if (Page is Registro || Page is LogIn)
                    {
                        Session.Add("error", "Debe salir para loguearse o registrar una cuenta");
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}