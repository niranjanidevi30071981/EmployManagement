Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Reflection
Imports EmployManagement.Employee.Models
Imports System.Threading.Tasks
Imports NLog

Public Class EmployeeCommonDetails


    Private logger As Logger = LogManager.GetCurrentClassLogger()

    ''' <summary>
    ''' Ticket no:<<>>
    ''' Retrieves all employee IDs details from the API.
    ''' </summary>
    ''' <returns>A list of Employee objects.</returns>
    ''' <exception cref="Exception">Logs and handles exceptions that occur during the process.</exception>
    Public Function GetAllEmployeeId() As List(Of EmployManagement.Employee.Models.Employee)

        Try

            Using client = New HttpClient()

                Dim response = client.GetAsync($"http://localhost:5000/api/employees").Result

                If response.IsSuccessStatusCode Then

                    Dim json As String = response.Content.ReadAsStringAsync().Result
                    Dim data As List(Of EmployManagement.Employee.Models.Employee) = JsonConvert.DeserializeObject(Of List(Of EmployManagement.Employee.Models.Employee))(json)
                    Return data
                Else
                    Return New List(Of EmployManagement.Employee.Models.Employee)()
                End If
            End Using
        Catch ex As Exception
            logger.Error(ex, "GetAllEmployeeId")
        End Try
    End Function

    ''' <summary>
    ''' Ticket no:<<>>
    ''' Retrieves a specific employee by ID from the API.
    ''' </summary>
    ''' <param name="id">The ID of the employee to retrieve.</param>
    ''' <returns>An Employee object.</returns>
    ''' <exception cref="Exception">Logs and handles exceptions that occur during the process.</exception>
    Public Function GetEmployeeId(ByVal id As String) As EmployManagement.Employee.Models.Employee
        Try

            Using client = New HttpClient()

                Dim response = client.GetAsync($"http://localhost:5000/api/employees/{id}").Result

                If response.IsSuccessStatusCode Then

                    Dim json As String = response.Content.ReadAsStringAsync().Result
                    Dim data As EmployManagement.Employee.Models.Employee = JsonConvert.DeserializeObject(Of EmployManagement.Employee.Models.Employee)(json)
                    Return data
                Else
                    Return New EmployManagement.Employee.Models.Employee()
                End If
            End Using
        Catch ex As Exception
            logger.Error(ex, "GetEmployeeId")
        End Try
    End Function

    ''' <summary>
    ''' Ticket no:<<>>
    ''' Updates an existing employee asynchronously.
    ''' </summary>
    ''' <param name="employee">The employee data to update.</param>
    ''' <returns>A task representing an asynchronous operation that returns true if the update was successful, otherwise false.</returns>
    ''' <exception cref="Exception">Logs and handles exceptions that occur during the process.</exception>
    Public Async Function UpdateEmployeeAsync(employee As EmployManagement.Employee.Models.Employee) As Task(Of Boolean)
        Try

            Using client As New HttpClient()
                client.BaseAddress = New Uri("http://localhost:5000/api/")
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

                Dim json As String = JsonConvert.SerializeObject(employee)
                Dim content As New StringContent(json, Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = Await client.PutAsync($"employees/{employee.Id}", content)
                Return response.IsSuccessStatusCode
            End Using
        Catch ex As Exception
            logger.Error(ex, "UpdateEmployeeAsync")
        End Try
    End Function

    ''' <summary>
    ''' Ticket no:<<>>
    ''' Delete an existing employee asynchronously.
    ''' </summary>
    ''' <param name="id">The employee data to delete.</param>
    ''' <returns>A task representing an asynchronous operation that returns true if the delete was successful, otherwise false.</returns>
    ''' <exception cref="Exception">Logs and handles exceptions that occur during the process.</exception>
    Protected Friend Function DeleteEmployeeId(ByVal id As String) As Boolean
        Try
            Using client = New HttpClient()
                Dim response = client.DeleteAsync($"http://localhost:5000/api/employees/{id}").Result
                Return response.IsSuccessStatusCode
            End Using
        Catch ex As Exception
            logger.Error(ex, "DeleteEmployeeId")
        End Try
    End Function

End Class
