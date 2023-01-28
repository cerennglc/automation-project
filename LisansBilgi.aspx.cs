using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
using System.Globalization;
namespace YukseklisansProje
{
    public partial class LisansBilgi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            egitimDiv.Visible = false;
            notDiv.Visible = false;
            using (var db = new OtomasyonDBEntities())
            {
                var kullaniciTC = Convert.ToInt64(Session["TC"]);
                var kisiID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();

                var lisansBilgisi = (from lisans in db.LisansTablosu
                                    join universite in db.UniversiteTablosu
                                    on lisans.Fk_UniversiteID equals universite.ID
                                    join fakulte in db.FakulteTablosu
                                    on lisans.Fk_FakulteID equals fakulte.ID
                                    join bolum in db.BolumTablosu
                                    on lisans.Fk_BolumID equals bolum.ID
                                    where lisans.Fk_KisiID == kisiID && (lisans.Fk_EgitimTuruID == 1 || lisans.Fk_EgitimTuruID == 2)
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
                                    where lisans.Fk_KisiID == kisiID && lisans.Fk_EgitimTuruID == 3
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


                var universiteListe = db.UniversiteTablosu.ToList();
                dropdownUniversite.DataSource = universiteListe;
                dropdownUniversite.DataTextField = "UniversiteAd";
                dropdownUniversite.DataValueField = "ID";
                dropdownUniversite.DataBind();

                if(rdBtnEgitim.SelectedIndex == 0 || rdBtnEgitim.SelectedIndex == 1)
                {
                    egitimDiv.Visible = true;
                    notDiv.Visible = true;
                }
                else if(rdBtnEgitim.SelectedIndex == 2)
                {
                    egitimDiv.Visible = true;
                    notDiv.Visible = false;
                }

            }
        }

        
        protected void rdBtnEgitim_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEkle.Focus();
            if (rdBtnEgitim.SelectedIndex == 0 || rdBtnEgitim.SelectedIndex == 1)
            {
                egitimDiv.Visible = true;
                notDiv.Visible = true;
            }
            else if (rdBtnEgitim.SelectedIndex == 2)
            {
                egitimDiv.Visible = true;
                notDiv.Visible = false;
            }
        }

        protected void dropdownUniversite_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var secilenUniversiteID = dropdownUniversite.SelectedIndex;
                var fakulteListe = db.FakulteTablosu.Where(x=>x.Fk_UniversiteID == secilenUniversiteID).ToList();
                dropdownFakulte.DataSource = fakulteListe;
                dropdownFakulte.DataTextField = "FakulteAd";
                dropdownFakulte.DataValueField = "ID";
                dropdownFakulte.DataBind();

            }
        }

        protected void dropdownFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var secilenUniversiteID = dropdownUniversite.SelectedIndex;
                var secilenFakulteAd = dropdownFakulte.SelectedItem.ToString();
                var secilenFakulteID = db.FakulteTablosu.Where(x => x.FakulteAd == secilenFakulteAd && x.Fk_UniversiteID == secilenUniversiteID).Select(y => y.ID).FirstOrDefault();

                var bolumListe = db.BolumTablosu.Where(x => x.Fk_UniversiteID == secilenUniversiteID && x.Fk_FakulteID == secilenFakulteID).ToList();
                dropdownBolum.DataSource = bolumListe;
                dropdownBolum.DataTextField = "BolumAd";
                dropdownBolum.DataValueField = "ID";
                dropdownBolum.DataBind();
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {

                decimal diplomaNotu = 0;
                if (tbxDiplomaNotu.Text.Length != 0)
                {
                    diplomaNotu = Convert.ToDecimal(tbxDiplomaNotu.Text, new CultureInfo("en-US"));
                }


                if (dropdownUniversite.SelectedIndex < 1 || dropdownFakulte.SelectedIndex < 0 || dropdownBolum.SelectedIndex < 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Seçenekleri Doldurunuz.";
                }
                else if (rdBtnEgitim.SelectedIndex != 2 && radioNotSistemi.SelectedIndex < 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Not Sistemini Seçiniz.";
                }
                else if (!fileUploadDiploma.HasFile)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Diploma Örneği Yükleyiniz.";
                }
                else if (rdBtnEgitim.SelectedIndex != 2 && tbxDiplomaNotu.Text.Length <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Diploma Notunuzu Giriniz.";
                }
                else
                {
                    if (radioNotSistemi.SelectedIndex == 0)
                    {
                        if (diplomaNotu > 4 || diplomaNotu < 2)
                        {
                            lblSonuc.Visible = true;
                            lblSonuc.ForeColor = System.Drawing.Color.Red;
                            lblSonuc.Text = "Lütfen Geçerli Aralık Giriniz.";
                        }

                    }
                    else if (radioNotSistemi.SelectedIndex == 1)
                    {
                        if (diplomaNotu > 100 || diplomaNotu < 60)
                        {
                            lblSonuc.Visible = true;
                            lblSonuc.ForeColor = System.Drawing.Color.Red;
                            lblSonuc.Text = "Lütfen Seçenekleri Doldurunuz.";
                        }
                    }

                    // Tabloya ekleme işlemleri başlayacaktır

                    LisansTablosu lisans = new LisansTablosu();
                    var secilenUniversiteID = dropdownUniversite.SelectedIndex;

                    var secilenFakulteAd = dropdownFakulte.SelectedItem.ToString();
                    var secilenFakulteID = db.FakulteTablosu.Where(x => x.FakulteAd == secilenFakulteAd && x.Fk_UniversiteID == secilenUniversiteID).Select(y => y.ID).FirstOrDefault();

                    var secilenBolumAd = dropdownBolum.SelectedItem.ToString();
                    var secilenBolumID = db.BolumTablosu.Where(x => x.BolumAd == secilenBolumAd && x.Fk_FakulteID == secilenFakulteID && x.Fk_UniversiteID == secilenUniversiteID).Select(y => y.ID).FirstOrDefault();

                    lisans.Fk_UniversiteID = secilenUniversiteID;
                    lisans.Fk_FakulteID = secilenFakulteID;
                    lisans.Fk_BolumID = secilenBolumID;


                    var kullaniciTC = Convert.ToInt64(Session["TC"]);
                    var kisiID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();
                    lisans.Fk_KisiID = kisiID;
                    if (fileUploadDiploma.HasFile)
                    {
                        var uzanti = fileUploadDiploma.FileName.Split('.')[(fileUploadDiploma.FileName.Split('.').Length - 1)];
                        var dosya = Server.MapPath("~/Bootstrap/images/Ogrenciler/") + kisiID.ToString();

                        var kod = Guid.NewGuid().ToString();
                        // Burada Guid kullanarak benzersiz fotoğraf isimleri elde ettik. Böylece her eğitim bilgisinin belge adı eşsiz oluyor.

                        if (!Directory.Exists(dosya))
                        {
                            Directory.CreateDirectory(dosya);
                            fileUploadDiploma.SaveAs((dosya + "\\" + kisiID.ToString() + "_" + kod + "." + uzanti));
                            lisans.DiplomaOrnegi = kisiID.ToString() + "_"+ kod + "." + uzanti;
                        }
                        else
                        {
                            fileUploadDiploma.SaveAs((dosya + "\\" + kisiID.ToString() + "_" + kod + "." + uzanti));
                            lisans.DiplomaOrnegi = kisiID.ToString() + "_" + kod + "." + uzanti;
                        }


                        if (rdBtnEgitim.SelectedIndex == 0)
                        {
                            lisans.Fk_EgitimTuruID = 1;
                            lisans.DiplomaNotu = diplomaNotu;

                            if (radioNotSistemi.SelectedIndex == 0)
                            {
                                lisans.NotSistemi = false;
                            }
                            else if (radioNotSistemi.SelectedIndex == 1)
                            {
                                lisans.NotSistemi = true;
                            }
                        }
                        else if (rdBtnEgitim.SelectedIndex == 1)
                        {
                            lisans.Fk_EgitimTuruID = 2;
                            lisans.DiplomaNotu = diplomaNotu;

                            if (radioNotSistemi.SelectedIndex == 0)
                            {
                                lisans.NotSistemi = false;
                            }
                            else if (radioNotSistemi.SelectedIndex == 1)
                            {
                                lisans.NotSistemi = true;
                            }
                        }
                        else if (rdBtnEgitim.SelectedIndex == 2)
                        {
                            lisans.Fk_EgitimTuruID = 3;
                        }

                        lisans.KayitTarihi = DateTime.Now;
                        lisans.IpAdresi = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                        db.LisansTablosu.Add(lisans);
                        db.SaveChanges();
                        Response.Redirect(Request.RawUrl);
                    }

                }
            }
        }
    }
}