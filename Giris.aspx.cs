using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible = false;
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                if (tbxTC.Text.Length ==0 || tbxSifre.Text.Length == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen TC ve Şifre giriniz.";
                }
                else
                {
                    if (tbxTC.Text.Length != 11 || tbxTC.Text.StartsWith("0"))
                    {
                        lblSonuc.Visible = true;
                        lblSonuc.ForeColor = System.Drawing.Color.Red;
                        lblSonuc.Text = "TC veya Şifre hatalı.";
                    }
                    else
                    {
                        long kullaniciTC = Convert.ToInt64(tbxTC.Text);
                        string kullaniciSifre = MD5Sifreleme(tbxSifre.Text);
                        var sorguTC = db.KisiTablosu.Where(x => x.TC == kullaniciTC && x.Sifre == kullaniciSifre && x.YoneticiMi == false).Count();

                        if(sorguTC > 0)
                        {
                            Session["TC"] = kullaniciTC;
                            Response.Redirect("Anasayfa.aspx"); //Giriş başarılı ve Response.redirect ile anasayfaya yönlendiriyoruz.
                        }
                        else
                        {
                            lblSonuc.Visible = true;
                            lblSonuc.ForeColor = System.Drawing.Color.Red;
                            lblSonuc.Text = "TC veya Şifre hatalı.";
                        }

                    }
                }
            }
        }

        public string MD5Sifreleme(string sifre)
        {
            // MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Parametre olarak gelen veriyi byte dizisine dönüştürdük.
            byte[] dizi = Encoding.UTF8.GetBytes(sifre);
            //dizinin hash'ini hesaplattık.
            dizi = md5.ComputeHash(dizi);
            //Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
            StringBuilder sb = new StringBuilder();
            //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürdük.
            return sb.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SifremiUnuttum.aspx");
        }
    }
}