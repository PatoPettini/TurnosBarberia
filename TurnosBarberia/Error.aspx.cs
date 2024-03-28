using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnosBarberia
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["error"].ToString();

            if(Label1.Text.Contains("log"))  btnLoguearse.Visible= true;
            else btnLoguearse.Visible= false;
        }
    }
}