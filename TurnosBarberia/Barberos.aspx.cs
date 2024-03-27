using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class Barberos : System.Web.UI.Page
    {
        BarberoBusiness barberoBusiness = new BarberoBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvBarberos.DataSource = barberoBusiness.GetBarbero();
                dgvBarberos.DataBind();
            }
        }

        protected void dgvBarberos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvBarberos.SelectedDataKey.Value.ToString();
            Response.Redirect("ABMBarbero.aspx?id=" + id);
        }
    }
}