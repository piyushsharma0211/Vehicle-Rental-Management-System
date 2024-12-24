Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports Mysqlx
Imports System.Net.Mail
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim() = "" Or TextBox2.Text.Trim() = "" Or TextBox3.Text.Trim() = "" Or TextBox4.Text.Trim() = "" Or TextBox5.Text.Trim() = "" Or TextBox6.Text.Trim() = "" Or TextBox7.Text.Trim() = "" Then
            MessageBox.Show("Fill the all the details")
        ElseIf TextBox5.Text <> TextBox6.Text Then
            MessageBox.Show("Password are not matching")
        Else
            Dim first_name As String = TextBox1.Text
            Dim last_name As String = TextBox2.Text
            Dim email As String = TextBox3.Text
            Dim username As String = TextBox4.Text
            Dim password As String = TextBox5.Text
            Dim mobile_no As String = TextBox7.Text
            Dim dl_no As String = TextBox8.Text
            Dim conn As New MY_CONNECTION()
            Dim command As New MySqlCommand("INSERT INTO `tbl_accounts`(`fname`, `lname`, `email`, `username`, `password`, `mobno`, `dlno`) VALUES (@fnam, @lnam, @mail, @usn, @pass, @mob, @dl)", conn.getConnection())
            command.Parameters.Add("@fnam", MySqlDbType.VarChar).Value = first_name
            command.Parameters.Add("@lnam", MySqlDbType.VarChar).Value = last_name
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = email
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password
            command.Parameters.Add("@mob", MySqlDbType.Int64).Value = mobile_no
            command.Parameters.Add("@dl", MySqlDbType.VarChar).Value = dl_no
            conn.openConnection()


            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Resgistration Compeleted Successfully", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.closeConnection()
                Me.Hide()
                Dim lg As New Form2()
                lg.Show()
            Else
                MessageBox.Show("Something Happens", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.closeConnection()
            End If
        End If



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Dim lform As New Form2()
        lform.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        ' Validate email address
        Dim emailPattern As String = "^([\w-]+\.)?[\w-]+@[\w-]+\.([\w-]+\.)?[\w]+$"
        If Not Regex.IsMatch(TextBox3.Text.Trim(), emailPattern) Then
            MessageBox.Show("Please enter a valid email address", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        Dim pattern As String = "^(?:\+91[\-\s]?)?[0]?(?:[6789]\d[\-\s]?\d{8})$"
        If Not Regex.IsMatch(TextBox7.Text.Trim(), pattern) Then
            MessageBox.Show("Please enter a valid phone number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
        End If
    End Sub

    Function ValidateLicenseNumber(ByVal licenseNumber As String) As Boolean
        'Create a regular expression pattern to match the format
        Dim pattern As String = "^[A-Z]{2}[0-9]{2}[0-9]{10}$"
        'Create a regular expression object using the pattern
        Dim regex As New Regex(pattern)
        'Return True if the license number matches the pattern, False otherwise
        Return regex.IsMatch(licenseNumber)
    End Function

    'Call this function to validate the license number entered in TextBox8
    Private Sub TextBox8_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox8.Validating
        If Not ValidateLicenseNumber(TextBox8.Text) Then
            'Show an error message if the license number is invalid
            MessageBox.Show("Invalid license number. Please enter a valid Indian driving license number in the format 'AB123456789101'.")
            'Set the focus back to the TextBox8 control
            TextBox8.Focus()
        End If
    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only letters and spaces
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = " " Then
            e.Handled = True
            MessageBox.Show("Please enter only letters and spaces", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Allow only letters and spaces
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = " " Then
            e.Handled = True
            MessageBox.Show("Please enter only letters and spaces", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



End Class
