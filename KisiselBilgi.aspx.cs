using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
namespace YukseklisansProje
{
    public partial class KisiselBilgi : System.Web.UI.Page
    {
        Sifreleme sifreleme = new Sifreleme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblSonuc.Visible = false;
                using (var db = new OtomasyonDBEntities())
                {
                    long kullaniciTC = Convert.ToInt64(Session["TC"]);
                    var bilgiSatiri = db.KisiTablosu.Where(x => x.TC == kullaniciTC).FirstOrDefault();
                    var kisiID = bilgiSatiri.ID;
                    tbxAd.Text = bilgiSatiri.Ad;
                    tbxSoyad.Text = bilgiSatiri.Soyad;
                    tbxBabaAdi.Text = bilgiSatiri.BabaAdi;
                    tbxTC.Text = Convert.ToString(bilgiSatiri.TC);
                    tbxTelefon.Text = Convert.ToString(bilgiSatiri.Telefon);
                    
                    if(bilgiSatiri.DogumTarihi != null)
                    {
                        tbxDogumTarihi.Text = bilgiSatiri.DogumTarihi.Value.ToString("dd-MM-yyyy");
                    }
                    tbxEmail.Text = bilgiSatiri.Email;
                    tbxAdres.Text = bilgiSatiri.Adres;

                    if(bilgiSatiri.Fotograf != null)
                    {
                        kullaniciResim.ImageUrl = "~/Bootstrap/images/Ogrenciler/" + kisiID.ToString() +"/"+ bilgiSatiri.Fotograf +"?r=324324234234";
                    }
                    else
                    {
                        kullaniciResim.ImageUrl = "~/Bootstrap/images/unnamed.jpg";
                    }

                }
            }
        }
        protected void btnGuncelle_Click1(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                var yas = 0;
                if (tbxDogumTarihi.Text.Length != 0)
                {
                    //Yaş hesaplama
                    var bugun = DateTime.Now;
                    var dogumTarihi = Convert.ToDateTime(tbxDogumTarihi.Text);
                    yas = ((bugun - dogumTarihi).Days) / 365;
                }

                //Zorunlu alan kontrolü
                if (tbxAd.Text.Length <= 0 || tbxSoyad.Text.Length <= 0 || tbxBabaAdi.Text.Length <= 0 || tbxTC.Text.Length <= 0
                    || tbxEmail.Text.Length <= 0 || tbxSifre.Text.Length <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen *Zorunlu Alanları Doldurunuz.";

                }
                //Sifre uzunluk kontrolü
                else if (tbxSifre.Text.Length < 8)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen güvenli bir şifre seçiniz.";
                }//Sifre uyumluluk kontrolü
                else if (tbxSifre.Text != tbxSifreTekrar.Text)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Şifreler uyuşmuyor.";
                }//TC uzunluk ve 0 ile başlamama kontrolü
                else if (tbxTC.Text.Length != 11 || tbxTC.Text.StartsWith("0"))
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Geçerli Bir TC Giriniz.";
                }//Ad Soyad Baba Adı için sadece harf kontrolü
                else if (!tbxAd.Text.All(char.IsLetter) || !tbxSoyad.Text.All(char.IsLetter) || !tbxBabaAdi.Text.All(char.IsLetter))
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Geçerli Harflerden Oluşacak Şekilde Giriniz.";
                }
                //Telefon numarası girilmişse uzunluk ve 0 ile başlamama kontrolü
                else if (tbxTelefon.Text.Length != 0 && (tbxTelefon.Text.Length != 10 || tbxTelefon.Text.StartsWith("0")))
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen telefon numarasını başında 0 olmadan ve 10 hane olacak şekilde giriniz.";
                }//Doğum tarihi girilmişse yaş-doğruluk kontrolü
                else if (tbxDogumTarihi.Text.Length != 0 && (yas < 18 || yas >100))
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Uygun Bir Tarih Giriniz.";
                }
                else
                {
                    var kullaniciTC = Convert.ToInt64(Session["TC"]);
                    var kullaniciSatir = db.KisiTablosu.Where(x => x.TC == kullaniciTC).FirstOrDefault();
                    int kullaniciID = kullaniciSatir.ID;

                    kullaniciSatir.Ad = tbxAd.Text;
                    kullaniciSatir.Soyad = tbxSoyad.Text;
                    kullaniciSatir.BabaAdi = tbxBabaAdi.Text;
                    kullaniciSatir.Adres = tbxAdres.Text;
                    kullaniciSatir.Email = tbxEmail.Text;
                    kullaniciSatir.TC = Convert.ToInt64(tbxTC.Text);
                    kullaniciSatir.Telefon = Convert.ToInt64(tbxTelefon.Text);
                    if (tbxDogumTarihi.Text.Length != 0)
                    {
                        kullaniciSatir.DogumTarihi = Convert.ToDateTime(tbxDogumTarihi.Text);
                    }
                    kullaniciSatir.Sifre = sifreleme.MD5Sifreleme(tbxSifre.Text);
                    if (fileUploadResim.HasFile)
                    {
                        var uzanti = fileUploadResim.FileName.Split('.')[(fileUploadResim.FileName.Split('.').Length - 1)];
                        var resimAd = kullaniciID.ToString() + "." + uzanti;
                        var dosyaKonum = Server.MapPath(@"\Bootstrap\images\Ogrenciler\") + kullaniciID.ToString();

                        if (!Directory.Exists(dosyaKonum))
                        {
                            Directory.CreateDirectory(dosyaKonum);
                            fileUploadResim.SaveAs(Server.MapPath(@"\Bootstrap\images\Ogrenciler\" + kullaniciID.ToString() + "\\" + resimAd));
                            kullaniciSatir.Fotograf = resimAd;
                        }
                        else
                        {
                            fileUploadResim.SaveAs(Server.MapPath(@"\Bootstrap\images\Ogrenciler\" + kullaniciID.ToString() + "\\" + resimAd));
                            kullaniciSatir.Fotograf = resimAd;
                        }

                    }
                    var entity = db.Entry(kullaniciSatir);
                    entity.State = EntityState.Modified;
                    db.SaveChanges();

                    GuncellemeTablosu guncelleme = new GuncellemeTablosu();
                    guncelleme.Fk_KisiID = kullaniciID;
                    guncelleme.Fk_GuncellemeYapanID = 0;
                    guncelleme.GuncellemeTarihi = DateTime.Now;
                    guncelleme.IpAdresi = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                    db.GuncellemeTablosu.Add(guncelleme);
                    db.SaveChanges();

                    Session["TC"] = Convert.ToInt64(tbxTC.Text); //TC güncellemesi yapılınca eski session bilgisi yeni tc ile güncellenmeli
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}