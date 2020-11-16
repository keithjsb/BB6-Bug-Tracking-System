<%@ Page Title="" Language="C#" MasterPageFile="~/Reviewer/Reviewer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BB6.Reviewer.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2">
        <h3 class="row border-bottom"> BB6 Bug Tracking System </h3>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="btnClear" />
            </Triggers>
            <ContentTemplate>
                <div class="row justify-content-end mt-3">
                     <div class="form-group form-inline">
                         <asp:Label ID="lblError" runat="server" CssClass="form-label text-danger mr-2"></asp:Label>
                         <div class="input-group">
                             <asp:DropDownList ID="ddlSearchType" runat="server" CssClass="form-control">
                                 <asp:ListItem Text="Search type.."></asp:ListItem>
                                 <asp:ListItem Text="Title" Value="Title"></asp:ListItem>
                                 <asp:ListItem Text="Keywords" Value="Keywords"></asp:ListItem>
                                 <asp:ListItem Text="Assignee" Value="Assignee"></asp:ListItem>
                             </asp:DropDownList>
                             <asp:TextBox ID="txtSearch" cssclass="form-control" placeholder="Search..." runat="server"></asp:TextBox>
                             <div class="input-group-append">
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-outline-secondary" OnClick="btnSearch_Click"/>
                                 <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary" OnClick="btnClear_Click"/>
                             </div>
                         </div>
                    </div>
                </div>
                <div class="row" style="max-height: 100%;  overflow-y: auto;">
                    <table class="table table-sm">
                        <thead>
                            <tr>
                                <th style="width: 28%">Bugs</th>
                                <th style="width: 24%">Keywords</th>
                                <th style="width: 15%">Category</th>
                                <th style="width: 13%">Assignee</th>
                                <th style="width: 15%">Status</th>
                                <th style="width: 5%">Action</th>
                            </tr>
                            <asp:Repeater runat="server" ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <p class="m-0"><%#Eval("title")%></p>
                                            <small class="m-0">#<%#Eval("bug_id")%> submitted on <%#Eval("date_reported")%> by <%#Eval("bugreporter")%></small>
                                        </td>
                                        <td style="vertical-align:middle" ><asp:Label ID="Label1" runat="server" Text='<%#Eval("keywords")%>' cssclass="border bg-secondary form-rounded text-white"></asp:Label>
                                        <td style="vertical-align:middle"><%#Eval("category")%></td>
                                        <td style="vertical-align:middle"><asp:Label ID="lblAssignee" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "assignee") %>'></asp:Label></td>
                                        <td style="vertical-align:middle"><asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:Label></td>
                                        <td style="vertical-align:middle"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("bug_id", "~/Reviewer/ViewDetails.aspx?id={0}")%>' CssClass="btn btn-secondary">Details</asp:HyperLink></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </thead>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
