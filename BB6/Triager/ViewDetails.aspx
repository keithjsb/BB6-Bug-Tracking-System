<%@ Page Title="" Language="C#" MasterPageFile="~/Developer/Developer.Master" AutoEventWireup="true" CodeBehind="ViewDetails.aspx.cs" Inherits="BB6.Developer.DetailedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2">
        <h3 class="row border-bottom"> BB6 Bug Tracking System </h3>
        <div class="row justify-content-between mt-5">
             <div class="form-group form-inline">
                 <label class="form-label mr-2">Search by title:</label>
                 <asp:TextBox ID="txtSearchTitle" cssclass="form-control mr-2" placeholder="type title" runat="server"></asp:TextBox>
                 <label class="form-label mr-2">Search by keyword:</label>
                 <asp:TextBox ID="txtSearchKeyword" cssclass="form-control mr-2" placeholder="type keyword" runat="server"></asp:TextBox>   
                 <label class="form-label mr-2">Search by assignee:</label>
                 <asp:TextBox ID="txtSearchAssignee" cssclass="form-control mr-2" placeholder="type assignee" runat="server"></asp:TextBox>        
            </div>
        </div>
            <div class = "container-fluid text-center">
<table class="table table-bordered table-sm">
    <tr><th style="width: 5%">Bug ID</th><td><asp:Label ID="Idlabel" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="width: 25%">Title</th><td><asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="width: 20%">Keywords</th><td><asp:Label ID="KeyLabel" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="width: 10%">Bug Reporter</th><td><asp:Label ID="ReporterLabel" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="width: 10%">Date Reported</th><td><asp:Label ID="DateLabel" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="width: 8%">Priority</th><td>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> </td></tr>
    <tr><th style="width: 12%">Assignee</th><td><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td></tr>
    <tr><th style="width: 5%">Status</th><td>
        <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>  </td></tr>
    <tr><td><button type="button" runat="server" onserverclick="btnSubmit_Click" id="btnSubmit">Update</button></td></tr>
</table>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
