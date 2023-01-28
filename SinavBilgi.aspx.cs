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
    public partial class SinavBilgi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSonuc.Visible = false;
            using (var db = new OtomasyonDBEntities())
            {
                var kullaniciTC = Convert.ToInt64(Session["TC"]);
                var kisiID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();

                sinavRepeater.DataSource = db.SinavTablosu.Where(x => x.Fk_KisiID == kisiID).ToList();
                sinavRepeater.DataBind();
            }
                
        }

        protected void btnSinavEkle_Click(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                if(ddlSinavAd.SelectedIndex <= 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Sınav Türünü Seçiniz.";
                }
                else if(Convert.ToDecimal(tbxPuan.Text) <=0 || Convert.ToDecimal(tbxPuan.Text) > 100)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Geçerli Bir Puan Giriniz.";
                }
                else if (!fileUploadSonucBelgesi.HasFile)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Text = "Lütfen Sınav Sonuç Belgenizi Yükleyiniz.";
                }
                else
                {
                    var kullaniciTC = Convert.ToInt64(Session["TC"]);
                    var kisiID = db.KisiTablosu.Where(x => x.TC == kullaniciTC).Select(y => y.ID).FirstOrDefault();
                    SinavTablosu sinav = new SinavTablosu();
                    sinav.Fk_KisiID = kisiID;
                    var secilenSinav = "";
                    if (ddlSinavAd.SelectedIndex == 1)
                    {
                        sinav.SinavTuru = "ALES";
                        secilenSinav = "ALES";
                    }
                    else if (ddlSinavAd.SelectedIndex == 2)
                    {
                        sinav.SinavTuru = "YDS";
                        secilenSinav = "YDS";
                    }

                    sinav.Puan = Convert.ToDecimal(tbxPuan.Text);
                    if (fileUploadSonucBelgesi.HasFile)
                    {
                        var uzanti = fileUploadSonucBelgesi.FileName.Split('.')[(fileUploadSonucBelgesi.FileName.Split('.').Length - 1)];
                        var dosya = Server.MapPath(@"\Bootstrap\images\Ogrenciler\") + kisiID.ToString();

                        if (!Directory.Exists(dosya))
                        {
                            Directory.CreateDirectory(dosya);
                            fileUploadSonucBelgesi.SaveAs((dosya + "\\" + kisiID.ToString() + "_" + secilenSinav.ToString() + "." + uzanti));
                            sinav.SinavSonucBelgesi= kisiID.ToString() + "_" + secilenSinav.ToString() + "." + uzanti;
                        }
                        else
                        {
                            fileUploadSonucBelgesi.SaveAs((dosya + "\\" + kisiID.ToString() + "_" + secilenSinav.ToString() + "." + uzanti));
                            sinav.SinavSonucBelgesi = kisiID.ToString() + "_" + secilenSinav.ToString() + "." + uzanti;
                        }

                        sinav.KayitTarihi = DateTime.Now;
                        sinav.IpAdresi= Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                        db.SinavTablosu.Add(sinav);
                        db.SaveChanges();
                        Response.Redirect(Request.RawUrl);
                    }

                }
            }
            
        }
    }
}