<%@ Page Title="" Language="C#" MasterPageFile="~/Triager/Triager.Master" AutoEventWireup="true" CodeBehind="ViewDetails.aspx.cs" Inherits="BB6.Triager.ViewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2">
        <h3 class="row border-bottom"> BB6 Bug Tracking System </h3>

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
</table>
        <button type="button" runat="server" onserverclick="btnSubmit_Click" id="btnSubmit">Update</button>
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <hr/>
    <h3  class = "container-fluid text-left">
        <asp:Label ID="Label2" runat="server" Text="Comments"></asp:Label>
    </h3>
            <div class = "container-fluid text-left">
                <table>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                             <td style="text-align: left;"><%#Eval("comment_username")%>
                             <small class="m-0">posted on <%#Eval("comment_date")%></small>
                             </td>
                        </tr>
                        <tr style="border-style: solid; border-width: thin">
                             <td style="width: 400px; height: 150px; overflow:scroll; text-align: left; vertical-align: text-top;" ><%#Eval("comment_text")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
            </div>
     <hr/>
                <div class = "container-fluid text-left">
                         <asp:TextBox style="text-align: left; vertical-align: text-top;" ID="commentBox" runat="server" Height="150px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <button ID="commentButton" runat="server" onserverclick="btnComment_Click">Add Comment</button>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </div>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
