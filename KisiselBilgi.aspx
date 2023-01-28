<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="KisiselBilgi.aspx.cs" Inherits="YukseklisansProje.KisiselBilgi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <section class="py-5 my-5">
        <div class="container font-monospace">
            <h1 class="mb-5">Kişisel Bilgiler</h1>
            <div class="bg-white shadow rounded-lg d-block d-sm-flex">
                <div class="profile-tab-nav border-right">
                    <div class="mt-4">
                        <div class="img-fluid text-center mb-3 mt-4 pt-5">
                            
                            <asp:Image ID="kullaniciResim" class="shadow " runat="server" Width="240" />
                            <br />
                            <br />
                                
                            <asp:FileUpload runat="server" CssClass="ms-5" ID="fileUploadResim" onchange="preview()"/>
                        </div>
                        <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                    <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Ad</label>
                                    <asp:TextBox ID="tbxAd" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Soyad</label>
                                    <asp:TextBox ID="tbxSoyad" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Baba Adı</label>
                                    <asp:TextBox ID="tbxBabaAdi" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">TC</label>
                                    <asp:TextBox ID="tbxTC" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Telefon</label>
                                    <asp:TextBox ID="tbxTelefon" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Doğum Tarihi</label>
                                    <asp:TextBox ID="tbxDogumTarihi" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="fw-bold">Email</label> 
                                    <asp:TextBox ID="tbxEmail" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Şifre</label>
                                    <asp:TextBox ID="tbxSifre" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Şifre Tekrar</label>
                                    <asp:TextBox ID="tbxSifreTekrar" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="fw-bold">Adres</label>
                                    <asp:TextBox ID="tbxAdres" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="btnGuncelle"  class="btn text-white" runat="server" Text="Güncelle" BackColor="#006600" Width="132px" OnClick="btnGuncelle_Click1"/>
                        </div>
                        <asp:Label ID="lblSonuc" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%--<script>
        function preview() {
            frame.src = URL.createObjectURL(event.target.files[0]);
        }
    </script>
    <script src="Bootstrap/js/main.js"></script>--%>
</asp:Content>
