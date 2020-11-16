<%@ Page Title="" Language="C#" MasterPageFile="~/Developer/Developer.Master" AutoEventWireup="true" CodeBehind="ViewDetails.aspx.cs" Inherits="BB6.Developer.ViewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container-fluid{
            max-width: 60%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2">
        <div class="row mt-3">
            <h3 class="m-0"><asp:Label ID="CategoryLabel" runat="server" Text=""></asp:Label> - <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label> <small id="IdLabel" runat="server" class="text-muted"></small></h3>
        </div>
        <div class="row mt-3">
            <asp:Label ID="StatusLabel" runat="server"></asp:Label><asp:Label ID="ReporterLabel" runat="server" CssClass="ml-2 mr-2"></asp:Label><asp:Label ID="CommentCountLabel" runat="server" Text="Label"></asp:Label>
            <hr />
        </div>
        <div class="row mt-3">
            <div class="row col-12">
                <div class="col-12 m-0">
                    <div class="card">
                    <div class="card-header font-weight-bold">Details</div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="mb-1">
                                        <label class="font-weight-bold">Description</label><br />
                                        <asp:TextBox ID="DescriptionLabel" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="10" CssClass="form-control bg-transparent"></asp:TextBox>
                                        <div class="d-flex justify-content-between mt-2">
                                            <div class="form-group form-inline">
                                                <label class="font-weight-bold mr-1">Uploaded fix: </label><a runat="server" id="aFix" onclick="fix()"></a>
                                            </div>
                                            <div class="form-group form-inline">
                                                <asp:Label ID="Label1" runat="server" CssClass="col-form-label"></asp:Label>
                                            <button type="button" runat="server" onserverclick="upload_File" id="btnUpload" class="btn btn-success">Upload Fix</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-1">
                                        <label class="font-weight-bold">Assignees</label><br />
                                        <asp:Label ID="AssigneeLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="mb-1 border-top">
                                        <label class="font-weight-bold">Priority</label><br />
                                        <asp:Label ID="PriorityLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="mb-1 border-top">
                                        <label class="font-weight-bold">Keywords</label><br />
                                        <asp:Label ID="KeyLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="mb-1 border-top">
                                        <label class="font-weight-bold">Date Reported</label><br />
                                        <asp:Label ID="DateLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="mb-1 border-top">
                                        <label class="font-weight-bold">Date Modified</label><br />
                                        <asp:Label ID="DateModifiedLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="mb-1">
                                        <label class="font-weight-bold">Date Resolved</label><br />
                                        <asp:Label ID="DateResolvedLabel" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 m-0">
                    <div class="card mt-4">
                        <div class="card-header font-weight-bold">Leave a comment</div>
                        <div class="card-body">
                            <asp:TextBox ID="commentBox" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                            <div class="d-flex justify-content-end mt-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*You can't leave an empty comment!" ForeColor="Red" ControlToValidate="commentBox" ValidationGroup="commentsGroup"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label3" runat="server" CssClass="col-form-label"></asp:Label>
                                <asp:Button ID="commentButton" runat="server" Text="Comment" CssClass="btn btn-sm btn-success ml-2" OnClick="btnComment_Click"  ValidationGroup="commentsGroup"/>
                            </div>
                        </div>
                    </div>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="card mt-2">
                                <div class="card-header"><label class="font-weight-bold"><%#Eval("comment_username")%></label> commented on <%#Eval("comment_date")%></div>
                                <div class="card-body">
                                    <p>
                                        <%#Eval("comment_text")%>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <script>
        function fix() {
            if (confirm("Download this fix?"))
                alert("Fix downloaded.");
        }
    </script>
</asp:Content>

