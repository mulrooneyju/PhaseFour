Public Class FormClassLogin

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Oracle.Result = Oracle.ResponseType.Cancel

        Application.Exit()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Oracle.UserName = TextBox1.Text
        Oracle.PassWord = TextBox2.Text
        Oracle.Server = TextBox3.Text

        Oracle.Result = Oracle.ResponseType.OK

        Me.Close()
    End Sub
End Class
