<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BasvuruSayfasi.aspx.cs" Inherits="YukseklisansProje.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <h1 class="mb-5">Başvuru Formu</h1>
    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Lisans - Yüksek Lisans Bilgileri</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Üniversite Adı</td>
                    <td>Fakülte Adı</td>
                    <td>Bölüm Adı</td>
                    <td>Diploma Notu</td>
                    <td>Not Sistemi</td>
                    <td>Eğitim Türü</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="lisansRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("UniversiteAd") %></td>
                                <td><%#Eval("FakulteAd") %></td>
                                <td><%#Eval("BolumAd") %></td>
                                <td><%#Eval("DiplomaNotu") %></td>
                                <td><%#Eval("NotSistemi").Equals(true)?"100'lük Sistem":"4'lük Sistem" %></td>
                                <td><%#Eval("EgitimTuru").Equals(1)?"Lisans":"Yüksek Lisans" %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="row">
                <div class="col-12">
                    <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click">Farklı Lisans Bilgisi Eklemek İçin Tıklayın</asp:LinkButton>
                </div>
                <div class="col-6 mt-5">
                    <asp:DropDownList ID="ddlLisansSec" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem>Lisans Bilgisini Se&#231;iniz</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-6 mt-5">
                    <asp:DropDownList ID="ddlYuksekLisansSec" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem>Yüksek Lisans Bilgisini Se&#231;iniz</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

   <%-- <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Doktora Bilgileri</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: steelblue">
                    <td>Üniversite</td>
                    <td>Fakülte</td>
                    <td>Bölüm</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="doktoraRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("UniversiteAd") %></td>
                                <td><%#Eval("FakulteAd") %></td>
                                <td><%#Eval("BolumAd") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>--%>

    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Sınav Bilgileri</h5>
            <table class="table text-center  table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Sınav Adı</td>
                    <td>Puan</td>

                </tr>
                <tbody>
                    <asp:Repeater ID="sinavRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("SinavTuru") %></td>
                                <td><%#Eval("Puan") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="row">
                <div class="col-12">
                    <asp:LinkButton ID="LinkButton2" class="ms-3" runat="server" OnClick="LinkButton2_Click">Farklı Sınav Bilgisi Eklemek İçin Tıklayın</asp:LinkButton>
                </div>
                <div class="col-12 mt-5">
                    <asp:DropDownList ID="ddlSinavSec" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem>Sinav Bilgisini Se&#231;iniz</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        

    </div>


    <section class="py-5 my-5">
        <div class="section font-monospace">
            <div class="bg-white shadow rounded-lg d-block d-sm-flex">
                <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                    <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="fw-bold">Program Adı</label>
                                    <asp:DropDownList ID="dropdownProgram" AppendDataBoundItems="true" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="dropdownProgram_SelectedIndexChanged">
                                        <asp:ListItem>Program Seçiniz</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Fakülte</label>
                                    <asp:TextBox ID="tbxFakulte" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Bölüm</label>
                                    <asp:TextBox ID="tbxBolum" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Kontenjan</label>
                                    <asp:TextBox ID="tbxKontenjan" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Tez Durumu</label>
                                    <asp:TextBox ID="tbxTez" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Detay</label>
                                    <asp:TextBox ID="tbxDetay" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Programın Dili</label>
                                    <asp:TextBox ID="tbxDil" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-4 pt-2">
                                <div class="form-group">
                                    <label id="lblDekont" class="fw-bold" runat="server">Dekont</label>

                                    <asp:FileUpload ID="fileUploadDekont" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 mt-4 pt-2">
                            <asp:Label ID="lblSonuc" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div>
                            <asp:Button ID="btnBasvuru" class="btn text-white" runat="server" Text="Başvur" BackColor="#006600" Width="132px" OnClick="btnBasvuru_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
