using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
namespace YukseklisansProje
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new OtomasyonDBEntities())
                {
                    var programListe = from program in db.ProgramTablosu
                                       join fakulte in db.FakulteTablosu
                                       on program.Fk_FakulteID equals fakulte.ID
                                       join bolum in db.BolumTablosu
                                       on program.Fk_BolumID equals bolum.ID
                                       select new
                                       {
                                           ProgramID = program.ID,
                                           ProgramAd = program.ProgramAd,
                                           FakulteAd = fakulte.FakulteAd,
                                           BolumAd = bolum.BolumAd,
                                           Kontenjan = program.Kontenjan,
                                           TezDurum = (program.TezDurumu == true) ? "Tezli" : "Tezsiz",
                                           YuksekLisansMi = (program.YuksekLisansMi == true) ? "Yüksek Lisans":"Doktora",
                                       };

                    programRepeater.DataSource = programListe.ToList();
                    programRepeater.DataBind();

                }

            }
        }

        protected void btnBasvuru_Click(object sender, EventArgs e)
        {

        }

        //protected void btnDetay_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ProgramDetay.aspx");
        //}
    }
}