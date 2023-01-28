<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="YukseklisansProje.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.0/font/bootstrap-icons.css" />
    <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Lisansüstü Programlar</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Programın Adı</td>
                    <td>Fakülte Adı</td>
                    <td>Bölüm Adı</td>
                    <td>Kontenjan</td>
                    <td>Tez Durumu</td>
                    <td>Program Türü</td>
                    <td>Detay</td>
                    <td>Başvuru</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="programRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ProgramAd") %></td>
                                <td><%#Eval("FakulteAd") %></td>
                                <td><%#Eval("BolumAd") %></td>
                                <td><%#Eval("Kontenjan") %></td>
                                <td><%#Eval("TezDurum")%></td>
                                <td><%#Eval("YuksekLisansMi")%></td>
                                <td>
                                    <a href="ProgramDetay.aspx?secilenProgramID=<%#Eval("ProgramID") %>" class="btn text-white p-2" style="background-color: #006600">Detay</a>
                                </td>
                                <%--<td><asp:Button ID="btnDetay" class="btn text-white" runat="server" Text="Detay" BackColor="#006600" OnClick="btnDetay_Click"/></td>--%>
                                <td>
                                    <a href="BasvuruSayfasi.aspx?secilenProgramID=<%#Eval("ProgramID") %>" class="btn text-white bg-danger p-2">Başvur</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <hr />
    <div class="container-fluid rounded rounded-2 shadow py-3" ">
        <footer>
            <div class="container-fluid footer text-success wow fadeIn">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 ms-2">
                            <p class="mb-2"><i class="bi bi-geo-alt-fill me-3" style="color:red"></i>Balcalı Kampüsü:Çukurova Üniversitesi Rektörlüğü 01250,Sarıçam / Adana, TÜRKİYE</p>
                            <p class="mb-2"><i class="bi bi-telephone-inbound-fill me-3" style="color:black"></i>+90 322 338 60 84</p>
                            <p class="mb-2"><i class="bi bi-envelope-plus-fill me-3" style="color:blue"></i>bilgi@cu.edu.tr </p>
                        </div>

                    </div>
                </div>
            </div>
        </footer>
    </div>


</asp:Content>
