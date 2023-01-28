using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje
{
    public partial class ProgramDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new OtomasyonDBEntities())
                {

                    var secilenProgramID = Convert.ToInt32(Request.QueryString["secilenProgramID"]);

                    var programListe = (from program in db.ProgramTablosu
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
                                           Detay = program.Detay,
                                           ProgramDil = program.PrograminDili
                                       }).Where(x=> x.ProgramID == secilenProgramID).FirstOrDefault();


                    tbxProgramAd.Text = programListe.ProgramAd;
                    tbxFakulte.Text = programListe.FakulteAd;
                    tbxBolum.Text = programListe.BolumAd;
                    tbxKontenjan.Text = Convert.ToString(programListe.Kontenjan);
                    tbxTezDurumu.Text = programListe.TezDurum;
                    tbxDetay.Text = programListe.Detay;
                    tbxDil.Text = programListe.ProgramDil;

                }
            }
        }
    }
}