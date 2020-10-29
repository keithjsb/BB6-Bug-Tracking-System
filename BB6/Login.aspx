<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BB6.Login" ClientIDMode="Static" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <title>BB6 Bug Reporting System</title>
    <style>
        .container-fluid{
            max-width: 60%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="/Login.aspx" method="post">
        <nav class="navbar navbar-expand navbar-dark bg-primary">
          <a class="navbar-brand" href="../Login.aspx">
            BB6
          </a>
        </nav>
        <div class="container-fluid text-center">
            <h1>WE CAN'T FIX YOUR BUGS</h1>
            <div class="row">
                <table class="table table-bordered" id="testTable" runat="server">
                    <thead>
                        <tr>
                            <th>S/N</th>
                            <th>Username</th>
                            <th>Password</th>
                            <th>Type</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="row col-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnLogin" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="card col-12">
                            <h5 class="card-header text-left">Log in</h5> 
                            <div class="card-body text-left px-5">
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="inputDefault">Username</label>
                                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control col-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="inputDefault">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control col-9"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3" for="exampleSelect2">User type</label>
                                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control form-control-sm col-9">
                                        <asp:ListItem Text="-"></asp:ListItem>
                                        <asp:ListItem Text="Bug Reporter" Value="BR"></asp:ListItem>
                                        <asp:ListItem Text="Developer" Value="D"></asp:ListItem>
                                        <asp:ListItem Text="Reviewer" Value="R"></asp:ListItem>
                                        <asp:ListItem Text="Triager" Value="T"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <label class="col-form-label col-3"></label>
                                    <asp:Button ID="btnLogin" runat="server" Text="Log in >>" CssClass="btn btn-warning col-9" OnClick="btnLogin_Click"/>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-3"></label>
                                    <label class="col-form-label col-9 text-danger" id="lblError" runat="server"></label>
                                </div>
                            </div>
                         </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
