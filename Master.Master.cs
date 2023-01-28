using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YukseklisansProje
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["TC"] == null) // Burada Session ile taşınan bilginin olup olmadığı kontrol ediyorum.Eğer yoksa kullaniciyi girise yönlendiriyorum
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon(); //BUrda kullanici çıkış yaptığı için session bilgisini boşaltıyoruz
            Response.Redirect("Giris.aspx");
        }
    }
}