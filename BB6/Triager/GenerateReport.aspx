<%@ Page Title="" Language="C#" MasterPageFile="~/Triager/Triager.Master" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="BB6.Triager.GenerateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-sm">
        <tr><td><asp:Label ID="NumOfBugsReportedWeekly" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="NumOfBugsReportedMonthly" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="NumOfBugsFixedWeekly" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="NumOfBugsFixedMonthly" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="NumOfComments" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="BestReporter" runat="server" Text=""></asp:Label></td></tr>
        <tr><td><asp:Label ID="BestDeveloper" runat="server" Text=""></asp:Label></td></tr>
    </table>
</asp:Content>
