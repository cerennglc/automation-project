<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Basvurularim.aspx.cs" Inherits="YukseklisansProje.Basvurularim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container rounded rounded-2 shadow py-5 my-5">
        <div class="container">
            <h5 class="mb-5">Başvuru Yapılan Programlar</h5>
            <table class="table text-center table-bordered">
                <tr class="text-center text-white" style="background-color: #006600">
                    <td>Programın Adı</td>
                    <td>Kontenjan</td>
                    <td>Tez Durumu</td>
                    <td>Başvuru Tarihi</td>
                </tr>
                <tbody>
                    <asp:Repeater ID="programRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ProgramAd") %></td>
                                <td><%#Eval("Kontenjan") %></td>
                                <td><%#Eval("TezDurum")%></td>
                                <td><%#Eval("BasvuruTarihi")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
