Imports EmployManagement.Employee.Models
Imports Newtonsoft.Json
Imports NLog

Public Class DetailsView
    Inherits System.Web.UI.Page

    Dim obj As New EmployeeCommonDetails()
    Private logger As Logger = LogManager.GetCurrentClassLogger()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the "Id" query string parameter exists
            If Not String.IsNullOrEmpty(Request.QueryString("Id")) Then
                Dim empId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                ViewState("SelectedEmployeeId") = empId
                LoadEmployeeDetails(empId)
            End If
        End If
    End Sub
    Private Sub LoadEmployeeDetails(empId As Integer)
        Try
            Dim employee = obj.GetEmployeeId(empId)
            If employee IsNot Nothing Then
                lblId.Text = employee.Id
                lblName.Text = employee.Name
                lblDepartment.Text = employee.Department.ToString()
                lblEmail.Text = employee.Email

                ' Optional: Store the employee ID in ViewState for the Edit/Delete operations
                ViewState("SelectedEmployeeId") = empId
                Session("SelectedEmployeeId") = empId
            Else
                ' Handle the case where the employee is not found
                ' For example, redirect back to the list or show an error message
            End If
        Catch ex As Exception
            logger.Error(ex, "LoadEmployeeDetails")
        End Try
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim selectedEmployeeId As Integer = Convert.ToInt32(ViewState("SelectedEmployeeId"))
            Response.Redirect($"~/Edit.aspx?Id={selectedEmployeeId}")
        Catch ex As Exception
            logger.Error(ex, "btnEdit_Click")
        End Try
    End Sub


End Class