Public Class MyUserControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Label1.Text = "Welcome to my user control!"
        End If
    End Sub

End Class