<%@ Page Title="" Language="C#" MasterPageFile="~/BugReporter/BugReporter.Master" AutoEventWireup="true" CodeBehind="SubmitBugs.aspx.cs" Inherits="BB6.BugReporter.SubmitBugs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid text-center">
        <div class="row mt-5">
            <div class="col-12">
                <div class="card">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                        <ContentTemplate>
                            <h5 class="card-header text-left">New bug</h5> 
                            <div class="card-body text-left px-4">
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="inputDefault">Title</label>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control col-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="inputDefault">Keywords</label>
                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control col-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="inputDefault">Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control col-9" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <label class="col-form-label col-3"></label>
                                    <button type="button" class="btn btn-info col-4" runat="server" onserverclick="btnSubmit_Click" id="btnSubmit">Submit >></button>
                                    <label class="col-form-label col-1"></label>
                                    <button type="button" class="btn btn-danger col-4" runat="server" onserverclick="btnClear_Click">Clear</button>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3"></label>
                                    <label class="col-form-label col-9 text-danger" runat="server" id="lblError"></label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
