Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Form13
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oldPass As String = TextBox1.Text
        Dim newPass As String = TextBox2.Text
        Dim confirmPass As String = TextBox3.Text

        If TextBox2.Text = TextBox3.Text Then
            Dim conn As New MY_CONNECTION()
            Dim adapter As New MySqlDataAdapter()

            Dim command As New MySqlCommand("Update tbl_accounts set password = @new where password= @old ", conn.getConnection())
            command.Parameters.Add("@old", MySqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@new", MySqlDbType.VarChar).Value = TextBox2.Text
            conn.openConnection()
            If command.ExecuteNonQuery() = 1 Then


                MessageBox.Show("Password Update Successfully ")
                Me.Hide()
                Dim mainAppForm As New Form2()
                mainAppForm.Show()

            Else

                'MessageBox.Show("Password Update Successfully", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Your old password is not matching in database", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If
        Else
            MessageBox.Show("password confirmation is not matching ")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text() = ""
        TextBox2.Text() = ""
        TextBox3.Text() = ""
    End Sub


End Class