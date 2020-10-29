<%@ Page Title="" Language="C#" MasterPageFile="~/BugReporter/BugReporter.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="BB6.BugReporter.Test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlTest" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtTest" EventName="TextChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:DropDownList ID="ddlTest" runat="server" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="-" Value="-"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtTest" runat="server" AutoPostBack="True" OnTextChanged="txtTest_TextChanged"></asp:TextBox>
                <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
                <table class="table table-bordered table-sm">
                        <thead>
                            <tr>
                                <th>Bugs</th>
                                <th>Validity</th>
                            </tr>
                        </thead>
                          <asp:Repeater runat="server" id="Repeater1">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <p class="m-0"><%#Eval("title")%></p>
                                        <small class="m-0">#<%#Eval("bug_id")%> submitted on <%#Eval("date_reported")%> by <%#Eval("bugreporter")%></small>
                                    </td>
                                    <td>
                                        valid
                                    </td>
                                </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr />
        <hr />
        <asp:Label runat="server" Text="TITLE: "></asp:Label><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label> <br />
        <asp:Label  runat="server" Text="KEYWOWRDS:"></asp:Label><asp:Label ID="lblKeywords" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
