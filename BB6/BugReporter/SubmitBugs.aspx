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
                            <asp:AsyncPostBackTrigger ControlID="btnClear" />
                        </Triggers>
                        <ContentTemplate>
                            <h5 class="card-header text-left">New bug</h5> 
                            <div class="card-body text-left px-4">
                                <div class="form-group row">
                                    <div class="col-md-3">
                                        <label class="col-form-label" for="inputDefault">Title</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTitle" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control col-md-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-3">
                                        <label class="col-form-label" for="inputDefault">Keywords</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtKeywords" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control col-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-3">
                                        <label class="col-form-label" for="inputDefault">Category</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCategory" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control col-9">
                                        <asp:ListItem Text="Select category.." Value=""></asp:ListItem>
                                        <asp:ListItem Value="Error Handling"></asp:ListItem>
                                        <asp:ListItem Value="Server"></asp:ListItem>
                                        <asp:ListItem Value="Syntactics"></asp:ListItem>
                                        <asp:ListItem Value="UI"></asp:ListItem>
                                        <asp:ListItem Value="Others"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-3">
                                        <label class="col-form-label" for="inputDefault">Description</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDescription" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control col-9" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <label class="col-form-label col-3"></label>
                                    <button type="button" class="btn btn-info col-4" runat="server" onserverclick="btnSubmit_Click" id="btnSubmit" ValidationGroup="Submit">Submit >></button>
                                    <label class="col-form-label col-1"></label>
                                    <button type="button" class="btn btn-danger col-4" runat="server" onserverclick="btnClear_Click" id="btnClear">Clear</button>
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
