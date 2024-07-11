<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"  CodeBehind="Edit.aspx.vb" Inherits="EmployManagement.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="text-center">
            <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="~/images/BankImage.svg" alt="Card image cap" />
                <div class="card-body">
                    <h5 class="card-title">Employee</h5>
                     <p>Id: <asp:Label ID="lblId" runat="server"></asp:Label></p>
                    <p>Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>  </p>
                    <p>Department: <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></p>
                    <p>Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></p>
                    <p><label id="lblStatus" /> </p>
                    <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Default.aspx" CssClass="btn btn-primary" />
                    <input type="button" value="Update"  onclick="updateItem(<%=lblId.Text %>)" class="btn btn-primary" />       
                  
                </div>
            </div>
        </div>

</asp:Content>

