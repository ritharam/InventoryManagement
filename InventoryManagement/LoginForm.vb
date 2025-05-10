Public Class LoginForm
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = txtUserName.Text
        Dim password As String = txtPassword.Text

        If username = "" Then
            MsgBox("User Name is required", MsgBoxStyle.Critical)
            txtUserName.Clear()
            txtPassword.Clear()
        End If
        If password = "" Then
            MsgBox("Password is required", MsgBoxStyle.Critical)
            txtUserName.Clear()
            txtPassword.Clear()
        End If

        If (username = "admin" And password = "password") Then
            Form1.Show()
            Me.Hide()
        Else
            MsgBox("Incorrect Credentias")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class