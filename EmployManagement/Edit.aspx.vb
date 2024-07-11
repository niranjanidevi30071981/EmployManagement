Imports EmployManagement.Employee.Models
Imports Newtonsoft.Json
Imports NLog
Public Class Edit
    Inherits System.Web.UI.Page

    Dim obj As New EmployeeCommonDetails()
    Private logger As Logger = LogManager.GetCurrentClassLogger()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
            ' Check if the "Id" query string parameter exists
            If Not String.IsNullOrEmpty(Request.QueryString("Id")) Then
                Dim empId As String = Convert.ToInt32(Session("SelectedEmployeeId")) 'sample testing purpose added session variable
                LoadEmployeeDetails(empId)
            End If
        End If
End Sub
    Private Sub LoadEmployeeDetails(empId As Integer)
        Try
            Dim employee = obj.GetEmployeeId(empId)
            If employee IsNot Nothing Then
                lblId.Text = employee.Id
                txtName.Text = employee.Name
                txtDepartment.Text = employee.Department.ToString()
                txtEmail.Text = employee.Email
            Else
                logger.Info("No records found")
                ' Handle the case where the employee is not found
                ' For example, redirect back to the list or show an error message
            End If
        Catch ex As Exception
            logger.Error(ex, "LoadEmployeeDetails")
        End Try
    End Sub

End Class