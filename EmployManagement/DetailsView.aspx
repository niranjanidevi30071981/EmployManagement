<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailsView.aspx.vb" Inherits="EmployManagement.DetailsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="text-center">
            <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="~/images/BankImage.svg" alt="Card image cap" />
                <div class="card-body">
                    <h5 class="card-title">Employee</h5>
                     <p>Id: <asp:Label ID="lblId" runat="server"></asp:Label></p>
                    <p>Name: <asp:Label ID="lblName" runat="server"></asp:Label></p>
                    <p>Department: <asp:Label ID="lblDepartment" runat="server"></asp:Label></p>
                    <p>Email: <asp:Label ID="lblEmail" runat="server"></asp:Label></p>
                    <p><label id="lblStatus" color="red" /> </p>
                    <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Default.aspx" CssClass="btn btn-primary" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary" />
                    <input type="button" value="Delete"  onclick="deleteItem(<%=lblId.Text %>)" PostBackUrl="~/Default.aspx" class="btn btn-primary" />       
                  
                </div>
            </div>
        </div>

</asp:Content>

