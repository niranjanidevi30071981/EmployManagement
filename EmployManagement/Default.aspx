<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="EmployManagement._Default" %>
<%@ Register Src="~/MyUserControl.ascx" TagPrefix="uc" TagName="MyUserControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Getting Started</h2>           
           <div class="text-center">
            <h1>Employee List</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridView1_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' Text="View" CssClass="btn-sm btn-primary" />
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' Text="Edit" CssClass="btn-sm btn-primary" />
                            <asp:Button ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' Text="Remove" CssClass="btn-sm btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

         <div>
            <uc:MyUserControl ID="MyUserControl1" runat="server" />
        </div>

     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
     CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Department" HeaderText="Department" />
        <asp:BoundField DataField="Email" HeaderText="Email" />

        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton CssClass="btn btn-info btn-sm" CommandName="View" Text="View" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="ViewRecord"  />
                <asp:LinkButton CssClass="btn btn-info btn-sm" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="EditRecord" />
                <asp:LinkButton CssClass="btn btn-danger btn-sm" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="DeleteRecord"  />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </div>
          
        </div>
        
    </div>
   
        
   
</asp:Content>
