using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje
{
    public partial class SifreYenileme : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible = false;
        }

        protected void btnKontrol_Click(object sender, EventArgs e)
        {
            Sifreleme sifreleme = new Sifreleme();
            using (var db = new OtomasyonDBEntities())
            {
                //Sifre uzunluk kontrolü
                if (tbxSifre.Text.Length < 8)
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
                }
                else
                {
                    var kullaniciTC = Convert.ToInt64(Session["kullaniciTC"]);
                    var kullaniciBilgi = db.KisiTablosu.Where(x => x.TC == kullaniciTC).FirstOrDefault();
                    
                    kullaniciBilgi.Sifre = sifreleme.MD5Sifreleme(tbxSifre.Text);

                    var entity = db.Entry(kullaniciBilgi);
                    entity.State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    GuncellemeTablosu guncelleme = new GuncellemeTablosu();
                    guncelleme.Fk_KisiID = kullaniciBilgi.ID;
                    guncelleme.Fk_GuncellemeYapanID = 0;
                    guncelleme.GuncellemeTarihi = DateTime.Now;
                    guncelleme.IpAdresi = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                    db.GuncellemeTablosu.Add(guncelleme);
                    db.SaveChanges();

                    Session.Abandon();

                    Response.Redirect("Giris.aspx");

                }
            }
        }
    }
}