using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;
using System.Net;
using System.Net.Mail;

namespace YukseklisansProje
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible = false;
        }

        protected void btnKontrol_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                if (tbxTC.Text.Length <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "T.C. Kimlik Numaranızı Giriniz.";
                }
                else if (tbxEmail.Text.Length <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Email Adresinizi Giriniz.";
                }
                else
                {
                    var girilenTC = Convert.ToInt64(tbxTC.Text);
                    var girilenEmail = tbxEmail.Text;
                    var bilgiKontrol = db.KisiTablosu.Where(x => x.TC == girilenTC && x.Email == girilenEmail).Select(y => y.ID).Count();

                    if (bilgiKontrol <=0)
                    {
                        lblSonuc.Visible = true;
                        lblSonuc.ForeColor = System.Drawing.Color.Red;
                        lblSonuc.Text = "Bilgiler Uyuşmuyor";
                    }
                    else
                    {
                        //Burada kullanıcı doğru bilgileri göndermiş. Mail gönderme işlemi gerçekleştirilecek.
                        Random random = new Random();
                        int yenilemeKodu = random.Next(100000, 999999);

                        MailMessage mail = new MailMessage();
                        mail.To.Add(girilenEmail);
                        mail.From = new MailAddress("crngulcu@gmail.com");
                        mail.Subject = "Çukurova Üniversitesi Lisansüstü Başvuru Sistemi";
                        mail.Body = "<p>Şifre Yenileme Kodu: " + yenilemeKodu.ToString() +"<p>";
                        mail.IsBodyHtml=true;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Credentials = new NetworkCredential("crngulcu@gmail.com", "vyubchehwtwfitvt");
                        smtp.Send(mail);


                        Session["yenilemeKodu"] = yenilemeKodu;
                        Session["kullaniciTC"] = girilenTC;

                        Response.Redirect("KodKontrol.aspx");
                    }
                }
            }
        }
    }
}