using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje.Yonetici
{
    public partial class Kisiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var kisilerListesi = db.KisiTablosu.Where(x => x.YoneticiMi == false).ToList();
                kisilerRepeater.DataSource = kisilerListesi;
                kisilerRepeater.DataBind();
            }
        }
    }
}