﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="YukseklisansProje.SifremiUnuttum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title></title>
    <!-- Font Icon -->
    <link rel="stylesheet" href="/Bootstrap/fonts/material-icon/css/material-design-iconic-font.min.css">

    <!-- Main css -->
    <link rel="stylesheet" href="/Bootstrap/css/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="main ">
            <section class="signup ">
                <div class="container border border-1 rounded rounded-3 shadow-lg">
                    <div class="signup-content">

                        <h2 class="form-title">Şifremi Unuttum</h2>
                        <div class="form-group">

                            <asp:TextBox class="form-input" ID="tbxTC" placeholder="TC" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox class="form-input" ID="tbxEmail" placeholder="Email" TextMode="Email" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <br />

                            <asp:Button ID="btnKontrol" class="form-submit" runat="server" Text="Onayla" BackColor="#4061DC" OnClick="btnKontrol_Click"/>
                            <br />
                            <br />
                            <asp:Label ID="lblSonuc" runat="server" Visible="False"></asp:Label>
                        </div>
                        <!--Linkbuton renk değiş-->
                        <p class="loginhere">
                            Kaydınız Yok Mu? <a href="Kayit.aspx" class="loginhere-link">Kayıt Yap</a>
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
