<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="NIC_Parent_Student.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
</head>
<body class="container">
    <div class="row">
    <form id="form1" runat="server" class="col col-4 offset-2">
        <table class="container">
           
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-bordered table-striped"  AllowCustomPaging="True">

            <Columns>
                <asp:BoundField DataField="std_id" HeaderText="Student ID"/>
                <asp:BoundField DataField="std_Fname" HeaderText="First Name"/>
                <asp:BoundField DataField="std_Lname" HeaderText="Last Name"/>
                <asp:BoundField DataField="std_class" HeaderText="Class"/>
                
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton class="btn btn-primary p-1 m-1" runat="server" ID="Edit"  CommandArgument='<%#Eval("std_id") %>' OnClick="Edit_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton class="btn btn-danger p-1 m-1" runat="server" ID="Delete"  CommandArgument='<%#Eval("std_id") %>' OnClick="Delete_Click"  >Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton class="btn btn-success p-1 m-1" runat="server" ID="AddGuardian" OnClick="AddGuardian_Click1" CommandArgument='<%#Eval("std_id") %>' > + Guardian</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:LinkButton CssClass="btn btn-secondary p-1 m-1" runat="server" ID="ViewSingleGuardian" OnClick="ViewSingleGuardian_Click1" CommandArgument='<%#Eval("std_id") %>' >View Guardian</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>

               
            </Columns>
            
                    
            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

            
        </asp:GridView>

            <tr class="row">
                <asp:LinkButton runat="server" ID="btnFirst" OnClick="btnFirst_Click" CssClass="p-2 m-2 text-center"> First</asp:LinkButton>
                <asp:LinkButton runat="server" ID="btnPrevious" OnClick="btnPrevious_Click" CssClass="p-2 m-2 text-center">Previous</asp:LinkButton>
                <asp:LinkButton runat="server" ID="btnNext" OnClick="btnNext_Click" CssClass="p-2 m-2 text-center">Next</asp:LinkButton>
                <asp:LinkButton runat="server" ID="btnLast" OnClick="btnLast_Click" CssClass="p-2 m-2 text-center">Last</asp:LinkButton>
            </tr>
            </table>

        <div class="form-group">
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        <div class="form-group">
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        <div class="form-group">
        <asp:TextBox  ID="txtClass" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
      
       

       
        <asp:HiddenField ID="hf1" runat="server" />
        
        
        
        
        
        
        <p><asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" CssClass="btn btn-success"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-dark text-white"/>
        </p>

        <div class="p-2 my-5">
        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-striped">
        </asp:GridView>
            </div>

    </form>
        </div>
    
    
    
</body>
</html>
