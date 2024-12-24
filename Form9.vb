Public Class Form9
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim() = "" Then
            MsgBox("Please enter the admin password")
        Else
            If TextBox1.Text = "root@admin" Then
                MsgBox("Login successful")
                Me.Hide()
                Dim dash As New Form3()
                dash.Show()
            Else
                MsgBox("Invalid Admin password")
            End If
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Dim log As New Form2()
        log.Show()
    End Sub
End Class