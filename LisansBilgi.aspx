<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LisansBilgi.aspx.cs" Inherits="YukseklisansProje.LisansBilgi2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

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

    <section class="py-5 my-5">
        <div class="container font-monospace">
            <h1 class="mb-5">Lisans Bilgisi Ekleme</h1>
            <div class="bg-white shadow rounded-lg d-block d-sm-flex">
                <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                    <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="fw-bold">Eğitim Bilgisi</label>
                                    <asp:RadioButtonList ID="rdBtnEgitim" runat="server" OnSelectedIndexChanged="rdBtnEgitim_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem>Lisans</asp:ListItem>
                                        <asp:ListItem>Y&#252;ksek Lisans</asp:ListItem>
                                        <asp:ListItem>Doktora</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row" runat="server" id="egitimDiv">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="fw-bold">Üniversite</label>
                                        <asp:DropDownList ID="dropdownUniversite" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" OnSelectedIndexChanged="dropdownUniversite_SelectedIndexChanged" runat="server">
                                            <asp:ListItem>&#220;niversite Se&#231;iniz</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="fw-bold">Fakülte</label>
                                        <asp:DropDownList ID="dropdownFakulte" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropdownFakulte_SelectedIndexChanged" AppendDataBoundItems="false" runat="server">
                                            <asp:ListItem>Fak&#252;lte Se&#231;iniz</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="fw-bold">Bölüm</label>
                                        <asp:DropDownList ID="dropdownBolum" class="form-control" AppendDataBoundItems="false" runat="server">
                                            <asp:ListItem>B&#246;l&#252;m Se&#231;iniz</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 mt-4 pt-3">
                                    <label class="fw-bold">Diploma Örneği</label>
                                    <asp:FileUpload ID="fileUploadDiploma" runat="server" />
                                </div>
                            </div>
                            <div class="row" runat="server" id="notDiv">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="fw-bold">Diploma Notu</label>
                                        <asp:TextBox ID="tbxDiplomaNotu" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <label class="fw-bold">Not Sistemi</label>
                                    <asp:RadioButtonList ID="radioNotSistemi" runat="server">
                                        <asp:ListItem>4&#39;l&#252;k Not Sistem</asp:ListItem>
                                        <asp:ListItem>100&#39;l&#252;k Not Sistemi</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-12 text-center">
                                <asp:Button ID="btnEkle" class="btn text-white" runat="server" Text="Eğitim Bilgisini Kaydet" BackColor="#006600" OnClick="btnEkle_Click" />
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
