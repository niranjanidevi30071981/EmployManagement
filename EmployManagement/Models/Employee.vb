Imports System.ComponentModel.DataAnnotations

Namespace Employee.Models

    Public Class Employee
        Public Property Id As Integer
        Public Property Name As String
        <Required>
        Public Property Email As String
        Public Property Password As String
        Public Property ConfirmPassword As String
        <Required>
        Public Property Department As Dept?
    End Class




End Namespace


