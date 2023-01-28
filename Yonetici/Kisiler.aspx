<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="Kisiler.aspx.cs" Inherits="YukseklisansProje.Yonetici.Kisiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-2 rounded rounded-2 shadow-lg mt-3 mb-3 pt-3">
        <div class="table-responsive">
            <h4 class="text-center">KİŞİLER</h4>
            <table class="table table-bordered table-hover text-center">
                <thead>
                    <tr class="text-center text-white" style="background-color: #006600">
                        <th>Fotoğraf</th>
                        <th>Adı Soyadı</th>
                        <th>T.C. Kimlik Numarası</th>
                        <th>Baba Adı</th>
                        <th>Email</th>
                        <th>Adres</th>
                        <th>Detay</th>
                    </tr> 
                </thead>
                <tbody>
                    <asp:Repeater ID="kisilerRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="../Bootstrap/images/Ogrenciler/<%#Eval("ID") %>/<%#Eval("Fotograf") + ("?r=" + DateTime.Now.Ticks.ToString()) %>" width="60"/>

                                </td>
                                <td><%#Eval("Ad") %> <%#Eval("Soyad") %></td>
                                <td><%#Eval("TC") %></td>
                                <td><%#Eval("BabaAdi") %></td>
                                <td><%#Eval("Email") %></td>
                                <td><%#Eval("Adres") %></td>
                                <td>
                                    <a href="KisiDetay.aspx?kisiTC=<%#Eval("TC") %>" class="btn text-white bg-success p-2">Detay</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
