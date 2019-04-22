<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGuardian.aspx.cs" Inherits="NIC_Parent_Student.AddGuardian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
</head>
<body>
    <div class="container">
        <!--Form Interaction Starts-->
    <form runat="server" class="col col-3 offset-3">    
        <asp:HiddenField ID="hf2" runat="server" />
       
        <div class="col-form-label text-lg-center pt-40 mt-40"> Add Guardian</div>

                <!--Input For Guardian's First Name-->
                <div class="form-group">
                        <asp:TextBox ID="txtGuardianFName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <!--Input For Guardian's Last Name-->
                <div class="form-group">
                        <asp:TextBox ID="txtGuardianLname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <!--Input For Guardian's Address -->
                <div class="form-group">
                        <asp:TextBox ID="txtGuardianAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <!--Button To Submit Info-->
                <div class="form-group">
                        <asp:Button ID="adGuardianBtn" runat="server" Text="Add Guardian" OnClick="adGuardianBtn_Click" CssClass="btn btn-success" />
                </div>
        </form>
        <!--Form Interaction Ends-->
        </div>

</body>
</html>
