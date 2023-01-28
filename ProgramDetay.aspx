<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProgramDetay.aspx.cs" Inherits="YukseklisansProje.ProgramDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Bootstrap/css/myCSS.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <section class="py-5 my-5">
        <div class="container font-monospace">
            <div class="row">
                 <h1 class="mb-5">Programın Detayları</h1>
                <div class="col-8">
                    <div class="bg-white border border-1 shadow rounded-lg d-block d-sm-flex">
                        <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                            <div class="tab-pane fade show active" id="account" role="tabpanel" aria-labelledby="account-tab">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="fw-bold">Programın Adı</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxProgramAd" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="fw-bold">Fakülte</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxFakulte" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="fw-bold">Bolum</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxBolum" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <div class="bg-white border border-1 shadow rounded-lg d-block d-sm-flex">
                        <div class="tab-content p-4 p-md-5">
                            <div class="tab-pane fade show active" role="tabpanel" aria-labelledby="account-tab">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="fw-bold">Kontenjan</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxKontenjan" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="fw-bold">Tez Durumu</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxTezDurumu" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="fw-bold">Detay</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxDetay" class="form-control" runat="server" TextMode="MultiLine" ReadOnly="true" Height="122"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="fw-bold">Programın Dili</label>
                                            <div class="form-group">
                                                <asp:TextBox ID="tbxDil" class="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
