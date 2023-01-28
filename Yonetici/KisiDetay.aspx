<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KisiDetay.aspx.cs" Inherits="YukseklisansProje.Yonetici.KisiDetay" %>

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
                    <td>Detay</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="programRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ProgramAd") %></td>
                                <td><%#Eval("Kontenjan") %></td>
                                <td><%#Eval("TezDurum")%></td>
                                <td><%#Eval("BasvuruTarihi")%></td>
                                <td>
                                    <a href="BasvuruDetay.aspx?basvuruID=<%#Eval("BasvuruID") %>" class="btn text-white bg-success p-2">Detay</a>
                                </td>
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
                                <%--<td>
                                    <a href="ProgramDetay.aspx?secilenProgramID=<%#Eval("ProgramID") %>" class="btn text-white p-2" style="background-color: #006600">Detay</a>
                                </td>
                                <td><asp:Button ID="btnDetay" class="btn text-white" runat="server" Text="Detay" BackColor="#006600" OnClick="btnDetay_Click"/></td>
                                <td>
                                    <a href="BasvuruSayfasi.aspx?secilenProgramID=<%#Eval("ProgramID") %>" class="btn text-white bg-danger p-2">Başvur</a>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Doktora Bilgileri</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: steelblue">
                    <td>Diploma</td>
                    <td>Üniversite</td>
                    <td>Fakülte</td>
                    <td>Bölüm</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="doktoraRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="../Bootstrap/images/Ogrenciler/<%#Eval("Fk_KisiID") %>/<%#Eval("Diploma") +("?r=" + DateTime.Now.Ticks.ToString()) %>" width="60" />
                                </td>
                                <td><%#Eval("UniversiteAd") %></td>
                                <td><%#Eval("FakulteAd") %></td>
                                <td><%#Eval("BolumAd") %></td>
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


</asp:Content>
