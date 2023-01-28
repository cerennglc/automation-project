using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YukseklisansProje
{
    public partial class KodKontrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible = false;
        }

        protected void btnKontrol_Click(object sender, EventArgs e)
        {
            var yenilemeKodu = Convert.ToInt64(Session["yenilemeKodu"]);
            var girilenKod = Convert.ToInt64(tbxKod.Text);

            if (yenilemeKodu == girilenKod)
            {
                Response.Redirect("SifreYenileme.aspx");
            }
            else
            {
                lblSonuc.Visible = true;
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Text = "Hatalı Kod.";
            }

        }
    }
}