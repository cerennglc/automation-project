<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kayit.aspx.cs" Inherits="YukseklisansProje.Kayit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Çukurova Üniversitesi Kayıt Formu</title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="/Bootstrap/fonts/material-icon/css/material-design-iconic-font.min.css">

    <!-- Main css -->
    <link rel="stylesheet" href="/Bootstrap/css/style.css">
</head>
<body style="background-color:whitesmoke">
    <form id="form1" runat="server">

        <div class="main">

            <section class="signup">

                <div class="container">
                    <div class="signup-content">

                        <h2 class="form-title">Kayıt Formu</h2>
                        <div class="form-group">

                            <asp:TextBox class="form-input" ID="tbxAd" placeholder="*Ad" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxSoyad" placeholder="*Soyad" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxBabaAd" placeholder="*Baba Adı" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxTC" placeholder="*T.C. Kimlik Numarası" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxDogumT" placeholder="Doğum Tarihi" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxTelNo" placeholder="Telefon Numarası" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxAdres" placeholder="Adres" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxEmail" placeholder="*Email" TextMode="Email" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxSifre" name="password" placeholder="*Şifre" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxSifre2" name="password" placeholder="*Şifre Tekrar" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <br />

                            <asp:Button ID="btnKayit" class="form-submit" runat="server" Text="Kayıt" BackColor="#4061DC" OnClick="Button1_Click" />
                            <br />
                            <br />
                            <asp:Label ID="lblSonuc" runat="server" Visible="False"></asp:Label>
                        </div>
                        <p class="loginhere">
                            <asp:LinkButton ID="LinkButton1" class="loginhere-link" runat="server" ForeColor="#CC0000" OnClick="LinkButton1_Click">Lisansüstü Programlar</asp:LinkButton>
                        </p>
                        <p class="loginhere">
                            Zaten Kaydın Var Mı? <a href="Giris.aspx" class="loginhere-link">Giriş Yap</a>
                        </p>
                        

                    </div>
                </div>
            </section>

        </div>

        <!-- JS -->
        <script src="/Bootstrap/vendor/jquery/jquery.min.js"></script>
        <script src="/Bootstrap/js/main.js"></script>
    </form>
</body>
</html>
