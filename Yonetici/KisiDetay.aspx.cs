using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje.Yonetici
{
    public partial class KisiDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var kullaniciTC = Convert.ToInt64(Request.QueryString["kisiTC"]);
                var kullaniciID = db.KisiTablosu.Where(x=>x.TC == kullaniciTC).Select(y=>y.ID).FirstOrDefault();

                var lisansBilgisi = (from lisans in db.LisansTablosu
                                     join universite in db.UniversiteTablosu
                                     on lisans.Fk_UniversiteID equals universite.ID
                                     join fakulte in db.FakulteTablosu
                                     on lisans.Fk_FakulteID equals fakulte.ID
                                     join bolum in db.BolumTablosu
                                     on lisans.Fk_BolumID equals bolum.ID
                                     where lisans.Fk_KisiID == kullaniciID && (lisans.Fk_EgitimTuruID == 1 || lisans.Fk_EgitimTuruID == 2)
                                     select new
                                     {
                                         Fk_KisiID = lisans.Fk_KisiID,
                                         UniversiteAd = universite.UniversiteAd,
                                         FakulteAd = fakulte.FakulteAd,
                                         BolumAd = bolum.BolumAd,
                                         DiplomaNotu = lisans.DiplomaNotu,
                                         NotTuru = lisans.NotSistemi,
                                         Diploma = lisans.DiplomaOrnegi,
                                         EgitimTuru = lisans.Fk_EgitimTuruID

                                     }).ToList();
                lisansRepeater.DataSource = lisansBilgisi;
                lisansRepeater.DataBind();

                var doktoraBilgisi = (from lisans in db.LisansTablosu
                                      join universite in db.UniversiteTablosu
                                      on lisans.Fk_UniversiteID equals universite.ID
                                      join fakulte in db.FakulteTablosu
                                      on lisans.Fk_FakulteID equals fakulte.ID
                                      join bolum in db.BolumTablosu
                                      on lisans.Fk_BolumID equals bolum.ID
                                      where lisans.Fk_KisiID == kullaniciID && lisans.Fk_EgitimTuruID == 3
                                      select new
                                      {
                                          Fk_KisiID = lisans.Fk_KisiID,
                                          UniversiteAd = universite.UniversiteAd,
                                          FakulteAd = fakulte.FakulteAd,
                                          BolumAd = bolum.BolumAd,
                                          Diploma = lisans.DiplomaOrnegi

                                      }).ToList();
                doktoraRepeater.DataSource = doktoraBilgisi;
                doktoraRepeater.DataBind();

                sinavRepeater.DataSource = db.SinavTablosu.Where(x => x.Fk_KisiID == kullaniciID).ToList();
                sinavRepeater.DataBind();


                var basvuruListe = from basvuru in db.BasvuruTablosu
                                   join program in db.ProgramTablosu
                                   on basvuru.Fk_ProgramID equals program.ID
                                   where (basvuru.Fk_KisiID == kullaniciID)
                                   select new
                                   {
                                       BasvuruID = basvuru.ID,
                                       KisiID = basvuru.Fk_KisiID,
                                       ProgramID = program.ID,
                                       ProgramAd = program.ProgramAd + "/(" + ((program.YuksekLisansMi == true) ? "Yüksek Lisans" : "Doktora") + ")",
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