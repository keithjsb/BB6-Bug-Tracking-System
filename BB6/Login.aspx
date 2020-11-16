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
            max-width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="/Login.aspx" method="post">
        <nav class="navbar navbar-expand navbar-dark bg-primary">
          <a class="navbar-brand" href="../Login.aspx">
            BigBrain6
          </a>
        </nav>
        <div class="container-fluid text-center">
            <div class="row mt-5">
                <h4><strong>Welcome to BigBrain6 Bug Tracking System.</strong></h4>
            </div>
            <div class="row mt-5">
                <div class="col-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnLogin" />
                        </Triggers>
                        <ContentTemplate>
                            <div class="card">
                                <h5 class="card-header text-left">Log in</h5> 
                                <div class="card-body text-left px-5">
                                    <div class="mb-2 row">
                                        <div class="col-md-3">
                                            <label class="col-form-label" for="inputDefault">Username</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control col-md-9"></asp:TextBox>
                                    </div>
                                    <div class="mb-2 row">
                                        <div class="col-md-3">
                                            <label class="col-form-label" for="inputDefault">Password</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control col-md-9" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="mb-2 row">
                                        <div class="col-md-3">
                                            <label class="col-form-label" for="exampleSelect2">User type</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlUserType"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control col-md-9">
                                            <asp:ListItem Text="-" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Bug Reporter" Value="BR"></asp:ListItem>
                                            <asp:ListItem Text="Developer" Value="D"></asp:ListItem>
                                            <asp:ListItem Text="Reviewer" Value="R"></asp:ListItem>
                                            <asp:ListItem Text="Triager" Value="T"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <hr />
                                    <div class="mb-2 row">
                                        <label class="col-form-label col-3"></label>
                                        <asp:Button runat="server" Text="Log in >>" CssClass="btn btn-dark col-9" ID="btnLogin" OnClick="btnLogin_Click" />
                                    </div>
                                    <div class="mb-2 row">
                                        <label class="col-form-label col-3"></label>
                                        <asp:Label ID="lblError" runat="server" CssClass="col-form-label col-9 text-danger"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
			</div>
		</div>

    </form>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.js" integrity="sha256-DrT5NfxfbHvMHux31Lkhxg42LY6of8TaYyK50jnxRnM=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
