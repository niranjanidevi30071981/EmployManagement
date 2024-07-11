Namespace Employee.Models



    'Module ModelBuilderExtensions
    '    Sub Seed()
    '        ' Assuming you have a DbContext or similar way to access your database
    '        Using context As New ApplicationDBContext()
    '            ' Check if employees already exist to prevent re-seeding data
    '            If Not context.Employees.Any() Then
    '                Dim employees As New List(Of Employee) From {
    '                New Employee() With {.Id = 1, .Name = "Mark", .Department = Dept.IT, .Email = "Mark@hotmail.com"},
    '                New Employee() With {.Id = 2, .Name = "Param", .Department = Dept.IT, .Email = "param@hotmail.com"},
    '                New Employee() With {.Id = 3, .Name = "Tom", .Department = Dept.HR, .Email = "Tom@hotmail.com"}
    '            }
    '                context.Employees.AddRange(employees)
    '                context.SaveChanges()
    '            End If
    '        End Using
    '    End Sub
    'End Module



End Namespace


