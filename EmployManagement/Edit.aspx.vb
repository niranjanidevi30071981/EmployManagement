Imports EmployManagement.Employee.Models
Imports Newtonsoft.Json
Imports NLog

''' <summary>
''' Ticket No:<<>>
''' Update the selected employee field values.
''' </summary>
Public Class Edit
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Creating instance for local objects.
    ''' </summary>
    Dim objCommon As New EmployeeCommonDetails()
    Private logger As Logger = LogManager.GetCurrentClassLogger()

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Intialization of local objects and variables.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the "Id" query string parameter exists
            If Not String.IsNullOrEmpty(Request.QueryString("Id")) Then
                Dim empId As String = Convert.ToInt32(Session("SelectedEmployeeId")) 'sample testing purpose added session variable
                LoadEmployeeDetails(empId)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Intialize the local controls with the selected emplpyee values.
    ''' </summary>
    ''' <param name="empId"></param>
    Private Sub LoadEmployeeDetails(empId As Integer)
        Try
            Dim employee = objCommon.GetEmployeeId(empId)
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