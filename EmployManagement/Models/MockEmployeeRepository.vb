Namespace Employee.Models

    Public Class MockEmployeeRepository
        Private ReadOnly _empList As List(Of Employee)

        Public Sub New()
            _empList = New List(Of Employee) From {
            New Employee() With {.Id = 1, .Name = "Mark", .Department = Dept.IT, .Email = "Mark@hotmail.com"},
            New Employee() With {.Id = 2, .Name = "Param", .Department = Dept.IT, .Email = "param@hotmail.com"},
            New Employee() With {.Id = 3, .Name = "Tom", .Department = Dept.HR, .Email = "Tom@hotmail.com"}
        }
        End Sub

        Public Function GetAllEmployee() As IEnumerable(Of Employee)
            Return _empList
        End Function

        Public Function GetEmployee(id As Integer) As Employee
            Return _empList.FirstOrDefault(Function(emp) emp.Id = id)
        End Function

        Public Function Add(employee As Employee) As Employee
            employee.Id = _empList.Max(Function(e) e.Id) + 1
            _empList.Add(employee)
            Return employee
        End Function

        Public Function Update(employeeUpdate As Employee) As Employee
            Dim emp = GetEmployee(employeeUpdate.Id)
            If emp IsNot Nothing Then
                emp.Name = employeeUpdate.Name
                emp.Email = employeeUpdate.Email
                emp.Department = employeeUpdate.Department
            End If

            Return emp
        End Function

        Public Function Remove(id As Integer) As Employee
            Dim empRemove = GetEmployee(id)
            If empRemove IsNot Nothing Then
                _empList.Remove(empRemove)
            End If

            Return empRemove
        End Function
    End Class




End Namespace


