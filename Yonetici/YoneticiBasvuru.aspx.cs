using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YukseklisansProje.Model;

namespace YukseklisansProje.Yonetici
{
    public partial class YoneticiBasvuru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new OtomasyonDBEntities())
                {
                    var programListe = db.ProgramTablosu.ToList();

                    dropdownProgram.DataValueField = "ID";
                    dropdownProgram.DataTextField = "ProgramAd";
                    dropdownProgram.DataSource = programListe;
                    dropdownProgram.DataBind();
                }
            }
        }

        protected void dropdownProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new OtomasyonDBEntities())
            {
                if (dropdownProgram.SelectedIndex >= 1)
                {
                    var secilenProgramID = Convert.ToInt32(dropdownProgram.SelectedValue.ToString());

                    var basvuruYapanlar = (from basvuru in db.BasvuruTablosu
                                          join kisi in db.KisiTablosu
                                          on basvuru.Fk_KisiID equals kisi.ID
                                          where basvuru.Fk_ProgramID == secilenProgramID
                                          select new
                                          {
                                              ID = kisi.ID,
                                              Fotograf = kisi.Fotograf,
                                              Ad = kisi.Ad,
                                              Soyad = kisi.Soyad,
                                              TC = kisi.TC,
                                              BabaAdi = kisi.BabaAdi,
                                              Email = kisi.Email,
                                              Adres = kisi.Adres,
                                              BasvuruID = basvuru.ID
                                          }).ToList();

                   
                    kisilerRepeater.DataSource = basvuruYapanlar;
                    kisilerRepeater.DataBind();
                }
            }
        }
    }
}