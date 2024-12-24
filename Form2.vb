Imports MySql.Data.MySqlClient

Module GlobalVariables
    Public LoggedInUser As String
End Module


Public Class Form2
    'Dim rent As New Form6()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MY_CONNECTION()
        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        Dim command As New MySqlCommand("SELECT `username`, `password` FROM `tbl_accounts` WHERE `username` = @usn AND `password` = @pass", conn.getConnection())

        command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBox2.Text

        If TextBox1.Text.Trim() = "" Or TextBox1.Text.Trim().ToLower() = "username" Then
            MessageBox.Show("Enter your Username to login", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox2.Text.Trim() = "" Or TextBox2.Text.Trim().ToLower() = "password" Then
            MessageBox.Show("Enter your Password To Login", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            adapter.SelectCommand = command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                Me.Hide()
                MessageBox.Show("Login Successful")
                Dim mainAppForm As New Form7()
                'Dim mainAppForm As New Form3()
                GlobalVariables.LoggedInUser = TextBox1.Text
                mainAppForm.Show()
                'mainAppForm.Label1.Text = TextBox1.Text
            Else
                MessageBox.Show("Invalid Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.Orange
    End Sub

    ' label go to signup form mouse leave
    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Dim rform As New Form1()
        rform.Show()
    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Dim admin As New Form9()
        admin.Show()
    End Sub
End Class