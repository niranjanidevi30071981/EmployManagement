
Imports EmployManagement.Employee.Models
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports NLog
Imports System.Reflection

''' <summary>
''' Ticket No:<<>>
''' Implimneted the class for Get the all employee details and in table format
''' </summary>
Public Class _Default
    Inherits Page

    ''' <summary>
    ''' Creating local object for log and api call implimentation
    ''' </summary>
    Private logger As Logger = LogManager.GetCurrentClassLogger()
    Dim objCommon As New EmployeeCommonDetails()

    ''' <summary>
    ''' Ticket No:<<>>
    ''' page load event for instial page process
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' BindEmployeeList()
            BindGridView()

        End If
    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Bind the retun values to grid.
    ''' </summary>
    Protected Sub BindGridView()
        Try
            Dim data As List(Of EmployManagement.Employee.Models.Employee) = GetDataFromApi()
            GridView2.DataSource = data
            GridView2.DataBind()
        Catch ex As Exception
            logger.Error(ex, "BindGridView")
        End Try

    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' API return values are sending to the grid bind.
    ''' </summary>
    ''' <returns></returns>
    Protected Function GetDataFromApi() As List(Of EmployManagement.Employee.Models.Employee)
        Try

            Using client = New HttpClient()
                Dim response = client.GetAsync("http://localhost:5000/api/employees").Result
                logger.Info(response.StatusCode)

                If response.IsSuccessStatusCode Then
                    Dim json As String = response.Content.ReadAsStringAsync().Result
                    Dim data As List(Of EmployManagement.Employee.Models.Employee) = JsonConvert.DeserializeObject(Of List(Of EmployManagement.Employee.Models.Employee))(json)
                    Return data
                Else
                    Return New List(Of EmployManagement.Employee.Models.Employee)()
                End If
            End Using
        Catch ex As Exception
            logger.Error(ex, "GetDataFromApi")
        End Try
    End Function

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Navigating to the Employee view page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub EditRecord(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim id As String = btn.CommandArgument
            Session("SelectedEmployeeId") = id
            Response.Redirect($"~/Edit.aspx?Id={id}")
        Catch ex As Exception
            logger.Error(ex, "EditRecord")
        End Try

    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Navingatinthe employee view page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ViewRecord(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim id As String = btn.CommandArgument
            ' Response.Redirect("EditPage.aspx?id=" & id)
            Response.Redirect($"~/DetailsView.aspx?Id={id}")
        Catch ex As Exception
            logger.Error(ex, "ViewRecord")
        End Try

    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Delete the employee record.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DeleteRecord(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim id As String = btn.CommandArgument
            Dim success As Boolean = DeleteRecordInApi(id)

            If success Then
                BindGridView()
            Else
            End If
        Catch ex As Exception
            logger.Error(ex, "DeleteRecord")
        End Try
    End Sub

    ''' <summary>
    ''' Ticket No:<<>>
    ''' Calling of api method for delete employee record.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Protected Function DeleteRecordInApi(ByVal id As String) As Boolean
        Try
            Using client = New HttpClient()
                Dim response = client.DeleteAsync($"http://localhost:5000/api/employees/deleteEmployee/{id}").Result
                Return response.IsSuccessStatusCode
            End Using
        Catch ex As Exception
            logger.Error(ex, "DeleteRecordInApi")
        End Try
    End Function






    Private Sub BindEmployeeList()
        'Dim empRepo As New MockEmployeeRepository()
        'Dim employees = empRepo.GetAllEmployee()
        'GridView1.DataSource = employees
        'GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim selectedId As Integer = Convert.ToInt32(GridView1.SelectedDataKey.Value)
        ShowEmployeeDetails(selectedId)
    End Sub

    Private Sub ShowEmployeeDetails(id As Integer)
        '    Dim empRepo As New MockEmployeeRepository()
        '    Dim employee = empRepo.GetEmployee(id)
        '    ' Assuming you have a DetailsView or similar control to bind to
        '    DetailsView1.DataSource = New List(Of Employee) {employee}
        'DetailsView1.DataBind()
    End Sub
    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs)
        ' Response.Redirect($"~/Edit.aspx?Id={selectedId}")
    End Sub
    Protected Sub BtnRemove_Click(sender As Object, e As EventArgs)
        Dim empRepo As New MockEmployeeRepository()
        ' Assume we have a way to get the selected ID
        'empRepo.Remove(selectedId)
        ' Rebind the employee list to reflect changes
        BindEmployeeList()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        Dim selectedId As Integer = Convert.ToInt32(GridView1.DataKeys(rowIndex).Value)

        Select Case e.CommandName
            Case "View"
                ' Implement view logic here, e.g., redirect to a details page
                Response.Redirect($"~/DetailsView.aspx?Id={selectedId}")
            Case "Edit"
                ' Implement edit logic here, e.g., redirect to an edit page
                Response.Redirect($"~/Edit.aspx?Id={selectedId}")
            Case "Remove"
                ' Implement remove logic here
                Dim empRepo As New MockEmployeeRepository()
                empRepo.Remove(selectedId)
                BindEmployeeList()
        End Select
    End Sub

End Class