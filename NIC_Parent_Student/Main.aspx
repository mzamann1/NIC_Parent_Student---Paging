<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NIC_Parent_Student.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 689px;
        }
    </style>
</head>
<body style="height: 736px">
   
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID"/>
                <asp:BoundField DataField="g_Fname" HeaderText="First Name"/>
                <asp:BoundField DataField="g_Lname" HeaderText="Last Name"/>
                <asp:BoundField DataField="g_Address" HeaderText="Address"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="ViewLink" OnClick="Unnamed_Click" runat="server" CommandArgument='<%#Eval("id")%>'>View Students</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" Width="275px">
        </asp:GridView>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
   
</body>
</html>
