<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guardian.aspx.cs" Inherits="NIC_Parent_Student.Guardian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
</head>
<body class="container">
    <div class="row">
    <form id="form1" runat="server" class="col col-3 offset-3">
        
         <asp:HiddenField ID="hf1" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
            <Columns>
                <asp:BoundField  DataField="id" HeaderText="ID"/>
                <asp:BoundField Datafield="g_Fname" HeaderText="First Name"/>
                <asp:BoundField DataField="g_Lname" HeaderText="Last Name" />
                <asp:BoundField DataField="g_Address" HeaderText="Address"/>
                <asp:BoundField DataField="std_id" HeaderText="Std_ID"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="MoreStudents" OnClick="MoreStudents_Click" CommandArgument='<%#Eval("std_id") %>'> View Students</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="dltGuardian" OnClick="dltGuardian_Click" CommandArgument='<%#Eval("id") %>'>Delete </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="updGuardian" OnClick="updGuardian_Click" CommandArgument='<%#Eval("id")%>'>Update </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>

        <div class="form-group">
        <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        <div class="form-group">        <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox></div>
    <div class="form-group">
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
        <asp:TextBox ID="txtStd_id" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        <div class="form-group">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Update" OnClick="btn_Update_Click" Text="Update"/>
           
        </div>

        <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
      

    </form>
        </div>
    
</body>
</html>
