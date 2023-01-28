<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YukseklisansProje.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="Bootstrap/css/welcome.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm navbar-light border border-bottom ">
            <div class="container-fluid text-black font-monospace fs-5 fw-bold">
                <img src="../Bootstrap/images/Cu_Logo.png" alt="Logo" style="width: 90px;" class="rounded-pill ms-5">
                <a class="navbar-brand fs-3 ms-3" style="color: green" href="anasayfa.aspx">ÇUKUROVA<br />
                    ÜNİVERSİTESİ</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-around" id="collapsibleNavbar">
                    <label class="h5 text-muted fw-bold">Lisansüstü Başvuru Sistemi</label>
                    <div>
                        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Giriş Yap" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Kayıt Yap" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </nav>
        <br />
        <br />
        <br />
        <div class=" text-center container rounded rounded-2 shadow py-5 my-5">
            <section class="container">
                <h1 class="title" style="color: green">
                    <span>ÇUKUROVA</span>
                    <span>ÜNİVERSİTESİ</span>
                </h1>
                <h3 class="title" style="color: black">
                    <span>Lisansüstü Program Başvuru Sistemine</span>
                </h3>
                <h3 class="title" style="color: black">
                    <span>Hoşgeldiniz</span>
                </h3>
            </section>
        </div>
    </form>
</body>
</html>
