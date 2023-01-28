using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje.Yonetici
{
    public partial class BasvuruDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnOnay.Visible = false;
            btnRed.Visible = false;
            using (var db = new OtomasyonDBEntities())
            {
                var basvuruID = Convert.ToInt32(Request.QueryString["basvuruID"]);

                var basvuruBilgisi = db.BasvuruTablosu.Where(x => x.ID == basvuruID).FirstOrDefault();


                var basvuruListe = from basvuru in db.BasvuruTablosu
                                   join program in db.ProgramTablosu
                                   on basvuru.Fk_ProgramID equals program.ID
                                   where (basvuru.ID == basvuruID)
                                   select new
                                   {
                                       KisiID = basvuru.Fk_KisiID,
                                       ProgramID = program.ID,
                                       ProgramAd = program.ProgramAd + "/(" + ((program.YuksekLisansMi == true) ? "Yüksek Lisans" : "Doktora") + ")",
                                       Kontenjan = program.Kontenjan,
                                       TezDurum = (program.TezDurumu == true) ? "Tezli" : "Tezsiz",
                                       BasvuruTarihi = basvuru.BasvuruTarihi,
                                       Sonuc = basvuru.Sonuc
                                   };

                programRepeater.DataSource = basvuruListe.ToList();
                programRepeater.DataBind();


                if (basvuruBilgisi.Sonuc == "Red")
                {
                    btnOnay.Visible = true;
                    btnRed.Visible = false;
                }
                else if(basvuruBilgisi.Sonuc == "Kabul")
                {
                    btnOnay.Visible = false;
                    btnRed.Visible = true;
                }
                else
                {
                    btnOnay.Visible = true;
                    btnRed.Visible = true;
                }

                sinavRepeater.DataSource = db.SinavTablosu.Where(x => x.ID == basvuruBilgisi.Fk_SecilenSinavID).ToList();
                sinavRepeater.DataBind();


                var basvurulanProgramID = basvuruBilgisi.Fk_ProgramID;

                var secilenProgram = db.ProgramTablosu.Where(x => x.ID == basvurulanProgramID).Select(y => y.YuksekLisansMi).FirstOrDefault();

                if (secilenProgram)
                {
                    var secilenLisansID = basvuruBilgisi.Fk_SecilenLisansID;
                    var lisansBilgisi = (from lisans in db.LisansTablosu
                                         join universite in db.UniversiteTablosu
                                         on lisans.Fk_UniversiteID equals universite.ID
                                         join fakulte in db.FakulteTablosu
                                         on lisans.Fk_FakulteID equals fakulte.ID
                                         join bolum in db.BolumTablosu
                                         on lisans.Fk_BolumID equals bolum.ID
                                         where lisans.Fk_KisiID == basvuruBilgisi.Fk_KisiID && lisans.ID == secilenLisansID
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
                }
                else
                {
                    var secilenLisansID = basvuruBilgisi.Fk_SecilenLisansID;
                    var secilenYuksekLisansID = basvuruBilgisi.Fk_SecilenYuksekLisansID;

                    var lisansBilgisi = (from lisans in db.LisansTablosu
                                         join universite in db.UniversiteTablosu
                                         on lisans.Fk_UniversiteID equals universite.ID
                                         join fakulte in db.FakulteTablosu
                                         on lisans.Fk_FakulteID equals fakulte.ID
                                         join bolum in db.BolumTablosu
                                         on lisans.Fk_BolumID equals bolum.ID
                                         where lisans.Fk_KisiID == basvuruBilgisi.Fk_KisiID && (lisans.ID == secilenLisansID || lisans.ID == secilenYuksekLisansID)
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
                }

                
            }
        }

        protected void btnOnay_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var basvuruID = Convert.ToInt32(Request.QueryString["basvuruID"]);

                var basvuruBilgisi = db.BasvuruTablosu.Where(x => x.ID == basvuruID).FirstOrDefault();

                basvuruBilgisi.Sonuc = "Kabul";

                var entity = db.Entry(basvuruBilgisi);
                entity.State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnRed_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var basvuruID = Convert.ToInt32(Request.QueryString["basvuruID"]);

                var basvuruBilgisi = db.BasvuruTablosu.Where(x => x.ID == basvuruID).FirstOrDefault();

                basvuruBilgisi.Sonuc = "Red";

                var entity = db.Entry(basvuruBilgisi);
                entity.State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}