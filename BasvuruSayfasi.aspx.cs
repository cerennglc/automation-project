using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
namespace YukseklisansProje
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new OtomasyonDBEntities())
                {
                    var kullaniciTC = Convert.ToInt64(Session["TC"]);
                    int kullaniciID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();

                    var programListe = db.ProgramTablosu.ToList();

                    dropdownProgram.DataValueField = "ID";
                    dropdownProgram.DataTextField = "ProgramAd";
                    dropdownProgram.DataSource = programListe;
                    dropdownProgram.DataBind();

                    if (Request.QueryString["secilenProgramID"] != null)
                    {
                        dropdownProgram.SelectedIndex = dropdownProgram.Items.IndexOf(dropdownProgram.Items.FindByValue(Request.QueryString["secilenProgramID"].ToString()));
                        var secilenProgramID = Convert.ToInt32(Request.QueryString["secilenProgramID"]);

                        var secilenprogramListe = (from program in db.ProgramTablosu
                                                   join fakulte in db.FakulteTablosu
                                                   on program.Fk_FakulteID equals fakulte.ID
                                                   join bolum in db.BolumTablosu
                                                   on program.Fk_BolumID equals bolum.ID
                                                   where program.ID == secilenProgramID
                                                   select new
                                                   {
                                                       ProgramID = program.ID,
                                                       ProgramAd = program.ProgramAd,
                                                       FakulteAd = fakulte.FakulteAd,
                                                       BolumAd = bolum.BolumAd,
                                                       Kontenjan = program.Kontenjan,
                                                       TezDurum = (program.TezDurumu == true) ? "Tezli" : "Tezsiz",
                                                       Detay = program.Detay,
                                                       PrograminDili = program.PrograminDili
                                                   }).FirstOrDefault();

                        dropdownProgram.SelectedIndex = secilenProgramID;
                        tbxFakulte.Text = secilenprogramListe.FakulteAd;
                        tbxBolum.Text = secilenprogramListe.BolumAd;
                        tbxTez.Text = secilenprogramListe.TezDurum;
                        tbxDetay.Text = secilenprogramListe.Detay;
                        tbxKontenjan.Text = Convert.ToString(secilenprogramListe.Kontenjan);
                        tbxDil.Text = secilenprogramListe.PrograminDili;
                    }

                    var lisansTablosu = from lisans in db.LisansTablosu
                                        join universite in db.UniversiteTablosu
                                        on lisans.Fk_UniversiteID equals universite.ID
                                        join fakulte in db.FakulteTablosu
                                        on lisans.Fk_FakulteID equals fakulte.ID
                                        join bolum in db.BolumTablosu
                                        on lisans.Fk_BolumID equals bolum.ID
                                        where (lisans.Fk_KisiID == kullaniciID && (lisans.Fk_EgitimTuruID == 1 || lisans.Fk_EgitimTuruID == 2))
                                        select new
                                        {
                                            UniversiteAd = universite.UniversiteAd,
                                            FakulteAd = fakulte.FakulteAd,
                                            BolumAd = bolum.BolumAd,
                                            DiplomaNotu = lisans.DiplomaNotu,
                                            NotSistemi = lisans.NotSistemi,
                                            EgitimTuru = lisans.Fk_EgitimTuruID
                                        };
                    lisansRepeater.DataSource = lisansTablosu.ToList();
                    lisansRepeater.DataBind();

                   
                    sinavRepeater.DataSource = db.SinavTablosu.Where(x => x.Fk_KisiID == kullaniciID).ToList();
                    sinavRepeater.DataBind();




                    var lisansBilgileri = (from lisans in db.LisansTablosu
                                           join universite in db.UniversiteTablosu
                                           on lisans.Fk_UniversiteID equals universite.ID
                                           join fakulte in db.FakulteTablosu
                                           on lisans.Fk_FakulteID equals fakulte.ID
                                           join bolum in db.BolumTablosu
                                           on lisans.Fk_BolumID equals bolum.ID
                                           where lisans.Fk_KisiID == kullaniciID && lisans.Fk_EgitimTuruID == 1
                                           select new
                                           {
                                               ID = lisans.ID,
                                               Lisans = universite.UniversiteAd + "/" + bolum.BolumAd + "/" + (lisans.DiplomaNotu).ToString()
                                           }).ToList();

                    ddlLisansSec.DataValueField = "ID";
                    ddlLisansSec.DataTextField = "Lisans";
                    ddlLisansSec.DataSource = lisansBilgileri;
                    ddlLisansSec.DataBind();

                    var yuksekLisansBilgileri = (from lisans in db.LisansTablosu
                                                 join universite in db.UniversiteTablosu
                                                 on lisans.Fk_UniversiteID equals universite.ID
                                                 join fakulte in db.FakulteTablosu
                                                 on lisans.Fk_FakulteID equals fakulte.ID
                                                 join bolum in db.BolumTablosu
                                                 on lisans.Fk_BolumID equals bolum.ID
                                                 where lisans.Fk_KisiID == kullaniciID && lisans.Fk_EgitimTuruID == 2
                                                 select new
                                                 {
                                                     ID = lisans.ID,
                                                     Lisans = universite.UniversiteAd + "/" + bolum.BolumAd + "/" + (lisans.DiplomaNotu).ToString()
                                                 }).ToList();

                    ddlYuksekLisansSec.DataValueField = "ID";
                    ddlYuksekLisansSec.DataTextField = "Lisans";
                    ddlYuksekLisansSec.DataSource = yuksekLisansBilgileri;
                    ddlYuksekLisansSec.DataBind();

                    var sinavBilgi = (from sinav in db.SinavTablosu
                                      where sinav.Fk_KisiID == kullaniciID
                                      select new
                                      {
                                          ID = sinav.ID,
                                          Sinav = sinav.SinavTuru + "/" + (sinav.Puan).ToString()
                                      }).ToList();

                    ddlSinavSec.DataValueField = "ID";
                    ddlSinavSec.DataTextField = "Sinav";
                    ddlSinavSec.DataSource = sinavBilgi;
                    ddlSinavSec.DataBind();

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LisansBilgi.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SinavBilgi.aspx");
        }

        protected void dropdownProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                Page.SetFocus(btnBasvuru);
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
                                       Detay = program.Detay,
                                       ProgramDil = program.PrograminDili
                                   };
                if (!Page.IsPostBack)
                {
                    dropdownProgram.DataSource = programListe.ToList();
                    dropdownProgram.DataValueField = "ProgramID";
                    dropdownProgram.DataTextField = "ProgramAd";
                    dropdownProgram.DataBind();
                }

                if (dropdownProgram.SelectedIndex >= 1)
                {
                    var secilenProgramID = Convert.ToInt32(dropdownProgram.SelectedValue);
                    tbxFakulte.Text = programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.FakulteAd).FirstOrDefault();
                    tbxBolum.Text = programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.BolumAd).FirstOrDefault();
                    tbxTez.Text = programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.TezDurum).FirstOrDefault();
                    tbxDetay.Text = programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.Detay).FirstOrDefault();
                    tbxKontenjan.Text = Convert.ToString(programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.Kontenjan).FirstOrDefault());
                    tbxDil.Text = programListe.Where(x => x.ProgramID == secilenProgramID).Select(y => y.ProgramDil).FirstOrDefault();
                    if (tbxTez.Text.Equals("Tezli"))
                    {
                        fileUploadDekont.Visible = false;
                        lblDekont.Visible = false;
                    }
                    else
                    {
                        lblDekont.Visible = true;
                        fileUploadDekont.Visible = true;
                    }
                }



            }


        }

        protected void btnBasvuru_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {

                var kullaniciTC = Convert.ToInt64(Session["TC"]);
                int kullaniciID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();
                var egitimBilgisi = db.LisansTablosu.Where(x => x.Fk_KisiID == kullaniciID).Select(y => y.Fk_KisiID).Count();
                var sinavBilgisi = db.SinavTablosu.Where(x => x.Fk_KisiID == kullaniciID).Select(y => y.Fk_KisiID).Count();


                var secilenProgramID = Convert.ToInt32(dropdownProgram.SelectedValue.ToString());


                var secilenProgram = db.ProgramTablosu.Where(x => x.ID == secilenProgramID).FirstOrDefault();
                var tezliMi = secilenProgram.TezDurumu;
                var kullaniciBasvurulari = db.BasvuruTablosu.Where(x => x.Fk_ProgramID == secilenProgramID && x.Fk_KisiID == kullaniciID).Select(y => y.ID).Count();


                if (kullaniciBasvurulari > 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Başvurulan Programa Tekrar Başvurulamaz.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (!secilenProgram.YuksekLisansMi && ddlYuksekLisansSec.SelectedIndex <=0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Yüksek Lisans Bilginizi Seçiniz.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (ddlSinavSec.SelectedIndex <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Eğitim Bilginizi Seçiniz.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (ddlLisansSec.SelectedIndex <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Sınav Bilginizi Seçiniz.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (egitimBilgisi < 1)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Eğitim Bilginiz Bulunamadı.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (sinavBilgisi < 1)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Sınav Bilginiz Bulunamadı.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (dropdownProgram.SelectedIndex < 1)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Program Seçiniz.";
                    Page.SetFocus(btnBasvuru);
                }
                else if (!tezliMi && !fileUploadDekont.HasFile)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Dekont Yükleyiniz.";
                    Page.SetFocus(btnBasvuru);
                }
                else
                {
                    BasvuruTablosu basvuru = new BasvuruTablosu();

                    if (fileUploadDekont.HasFile)
                    {
                        var uzanti = fileUploadDekont.FileName.Split('.')[(fileUploadDekont.FileName.Split('.').Length - 1)];
                        var dekontAd = kullaniciID.ToString() + "_dekont." + uzanti;
                        var dosyaKonum = Server.MapPath(@"\Bootstrap\images\Ogrenciler\") + kullaniciID.ToString();

                        if (!Directory.Exists(dosyaKonum))
                        {
                            Directory.CreateDirectory(dosyaKonum);
                            fileUploadDekont.SaveAs(Server.MapPath(@"\Bootstrap\images\Ogrenciler\" + kullaniciID.ToString() + "\\" + dekontAd));
                            basvuru.Dekont = dekontAd;
                        }
                        else
                        {
                            fileUploadDekont.SaveAs(Server.MapPath(@"\Bootstrap\images\Ogrenciler\" + kullaniciID.ToString() + "\\" + dekontAd));
                            basvuru.Dekont = dekontAd;
                        }

                    }

                    if (!secilenProgram.YuksekLisansMi)
                    {
                        basvuru.Fk_SecilenYuksekLisansID = Convert.ToInt32(ddlYuksekLisansSec.SelectedValue.ToString());
                    }

                    basvuru.Fk_SecilenLisansID = Convert.ToInt32(ddlLisansSec.SelectedValue.ToString());
                    basvuru.Fk_SecilenSinavID = Convert.ToInt32(ddlSinavSec.SelectedValue.ToString());
                    basvuru.Fk_KisiID = kullaniciID;
                    basvuru.Fk_ProgramID = Convert.ToInt32(dropdownProgram.SelectedValue.ToString());
                    basvuru.BasvuruTarihi = DateTime.Now;
                    basvuru.IpAdresi = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                    basvuru.Sonuc = "Bekleniyor";
                    db.BasvuruTablosu.Add(basvuru);
                    db.SaveChanges();
                    Response.Redirect("Basvurularim.aspx");
                }


            }
        }
    }
}