using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YukseklisansProje.Yonetici
{
    public partial class Yonetici : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TC"] == null)
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("YoneticiGiris.aspx");
        }
    }
}