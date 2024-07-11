Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Reflection
Imports EmployManagement.Employee.Models
Imports System.Threading.Tasks
Imports NLog

Public Class EmployeeCommonDetails


    Private logger As Logger = LogManager.GetCurrentClassLogger()
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
