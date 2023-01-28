using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using YukseklisansProje.Model;


namespace YukseklisansProje
{
    public partial class Kayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible=false;
        }
        Sifreleme sifreleme = new Sifreleme();
        protected void Button1_Click(object sender, EventArgs e)
        {
            var yas = 0;
            if(tbxDogumT.Text.Length != 0)
            {
                //Yaş hesaplama
                var bugun = DateTime.Now;
                var dogumTarihi = Convert.ToDateTime(tbxDogumT.Text);
                yas = ((bugun - dogumTarihi).Days) / 365;
            }
            

            //Zorunlu alan kontrolü
            if (tbxAd.Text.Length <= 0 || tbxSoyad.Text.Length <= 0 || tbxBabaAd.Text.Length <= 0 || tbxTC.Text.Length <= 0
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
            else if (tbxSifre.Text != tbxSifre2.Text)
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
            else if (!tbxAd.Text.All(char.IsLetter) || !tbxSoyad.Text.All(char.IsLetter) || !tbxBabaAd.Text.All(char.IsLetter))
            {
                lblSonuc.Visible = true;
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Text = "Lütfen Geçerli Harflerden Oluşacak Şekilde Giriniz.";
            }
            //Telefon numarası girilmişse uzunluk ve 0 ile başlamama kontrolü
            else if (tbxTelNo.Text.Length !=0 &&(tbxTelNo.Text.Length != 10 || tbxTelNo.Text.StartsWith("0")))
            {
                lblSonuc.Visible = true;
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Text = "Lütfen telefon numarasını başında 0 olmadan ve 10 hane olacak şekilde giriniz.";
            }//Doğum tarihi girilmişse yaş-doğruluk kontrolü
            else if (tbxDogumT.Text.Length !=0  && yas<18 )
            {
                lblSonuc.Visible = true;
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Text = "Lütfen Uygun Bir Tarih Giriniz.";
            }
            else
            {
                using (var db = new OtomasyonDBEntities())
                {
                    var kullaniciTC = Convert.ToInt64(tbxTC.Text); //TC bilgisinin string tipinden long tipine dönüştürme
                    KisiTablosu kisi = new KisiTablosu();
                    var sorgu = db.KisiTablosu.Where(x => x.TC == kullaniciTC).FirstOrDefault();
                    if (sorgu != null)
                    {
                        lblSonuc.Visible = true;
                        lblSonuc.ForeColor = System.Drawing.Color.Red;
                        lblSonuc.Text = "Lütfen Geçerli Bir TC Giriniz.";
                    }
                    else
                    {
                        kisi.Ad = tbxAd.Text;
                        kisi.Soyad = tbxSoyad.Text;
                        kisi.BabaAdi = tbxBabaAd.Text;
                        kisi.TC = Convert.ToInt64(tbxTC.Text);
                        if(tbxTelNo.Text.Length !=0)
                            kisi.Telefon = Convert.ToInt64(tbxTelNo.Text);
                        kisi.Email = tbxEmail.Text;
                        kisi.Adres = tbxAdres.Text;
                        if (tbxDogumT.Text.Length != 0)
                            kisi.DogumTarihi = Convert.ToDateTime(tbxDogumT.Text);
                        kisi.KayitZamani = DateTime.Now;
                        kisi.Sifre = sifreleme.MD5Sifreleme(tbxSifre.Text);
                        kisi.IpAdresi = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                        kisi.YoneticiMi = false;
                        db.KisiTablosu.Add(kisi);
                        db.SaveChanges();
                                               

                        Response.Redirect("Giris.aspx");

                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
    
}