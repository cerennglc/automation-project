<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SinavBilgi.aspx.cs" Inherits="YukseklisansProje.SinavBilgi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    
    
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

    <section class="py-5 my-5">
        <div class="container font-monospace">
            <h1 class="mb-5">Sınav Bilgisi Ekleme</h1>
            <div class="bg-white shadow rounded-lg d-block d-sm-flex">
                <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                    <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Sınav Türü</label>
                                    <%--<asp:TextBox ID="tbxSinavAd" class="form-control" runat="server"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlSinavAd" class="form-control" runat="server">
                                        <asp:ListItem Selected="True">L&#252;tfen Sınav T&#252;r&#252; Se&#231;iniz</asp:ListItem>
                                        <asp:ListItem>ALES</asp:ListItem>
                                        <asp:ListItem>YDS</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="fw-bold">Sınav Puan</label>
                                    <asp:TextBox ID="tbxPuan" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-4 pt-3">
                                <label class="fw-bold">Sınav Sonuç Belgesi</label>
                                <asp:FileUpload ID="fileUploadSonucBelgesi" runat="server" />
                            </div>
                            <div class="col-12 mt-3 text-center">
                                <asp:Button ID="btnSinavEkle" class="btn text-white" runat="server" Text="Sınav Bilgisini Kaydet" BackColor="#006600" OnClick="btnSinavEkle_Click" />
                            </div>
                            <div class="col-12 text-center">
                                <asp:Label ID="lblSonuc" runat="server" Visible="False"></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
