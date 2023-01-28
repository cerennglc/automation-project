using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
namespace YukseklisansProje
{
    public partial class Basvurularim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new OtomasyonDBEntities())
                {
                    long kullaniciTC = Convert.ToInt64(Session["TC"]);
                    var kisiID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y=>y.ID).FirstOrDefault();
                    
                    var basvuruListe = from basvuru in db.BasvuruTablosu
                                       join program in db.ProgramTablosu
                                       on basvuru.Fk_ProgramID equals program.ID
                                       where (basvuru.Fk_KisiID == kisiID)
                                       select new
                                       {
                                           KisiID = basvuru.Fk_KisiID,
                                           ProgramID = program.ID,
                                           ProgramAd = program.ProgramAd + "/(" + ((program.YuksekLisansMi == true)?"Yüksek Lisans":"Doktora" ) +")",
                                           Kontenjan = program.Kontenjan,
                                           TezDurum = (program.TezDurumu == true) ? "Tezli" : "Tezsiz",
                                           BasvuruTarihi = basvuru.BasvuruTarihi
                                       };

                    programRepeater.DataSource = basvuruListe.ToList();
                    programRepeater.DataBind();

                }
            }
        }
    }
}