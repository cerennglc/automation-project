<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="BasvuruDetay.aspx.cs" Inherits="YukseklisansProje.Yonetici.BasvuruDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">


    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Başvuru Yapılan Programlar</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Programın Adı</td>
                    <td>Kontenjan</td>
                    <td>Tez Durumu</td>
                    <td>Başvuru Tarihi</td>
                    <td>Sonuc</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="programRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ProgramAd") %></td>
                                <td><%#Eval("Kontenjan") %></td>
                                <td><%#Eval("TezDurum")%></td>
                                <td><%#Eval("BasvuruTarihi")%></td>
                                <td><%#Eval("Sonuc")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>


    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Lisan - Yüksek Lisans Bilgileri</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Diploma</td>
                    <td>Üniversite</td>
                    <td>Fakülte</td>
                    <td>Bölüm</td>
                    <td>Diploma Notu</td>
                    <td>Not Türü</td>
                    <td>Eğitim Türü</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="lisansRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="../Bootstrap/images/Ogrenciler/<%#Eval("Fk_KisiID") %>/<%#Eval("Diploma") +("?r=" + DateTime.Now.Ticks.ToString()) %>" width="60" />
                                </td>
                                <td><%#Eval("UniversiteAd") %></td>
                                <td><%#Eval("FakulteAd") %></td>
                                <td><%#Eval("BolumAd") %></td>
                                <td><%#Eval("DiplomaNotu") %></td>
                                <td><%#Eval("NotTuru").Equals(true)?"100'lük Sistem":"4'lük Sistem"%></td>
                                <td><%#Eval("EgitimTuru").Equals(1)?"Lisans":"Yüksek Lisans"%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Sınav Bilgileri</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Belge</td>
                    <td>Sınav</td>
                    <td>Puan</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="sinavRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="../Bootstrap/images/Ogrenciler/<%#Eval("Fk_KisiID") %>/<%#Eval("SinavSonucBelgesi") +("?r=" + DateTime.Now.Ticks.ToString()) %>" width="60" />
                                </td>
                                <td><%#Eval("SinavTuru") %></td>
                                <td><%#Eval("Puan") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container text-center">
            <asp:Button ID="btnOnay" class="form-submit btn btn-success" runat="server" Text="Kabul Et" OnClick="btnOnay_Click" />
            <asp:Button ID="btnRed" class="form-submit btn btn-danger" runat="server" Text="Reddet" OnClick="btnRed_Click" />
        </div>
    </div>

</asp:Content>
