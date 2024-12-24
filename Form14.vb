Imports System.Text.RegularExpressions

Public Class Form14
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validate the input using regular expressions
        Dim regexCardNumber As New Regex("^\d{16}$")
        Dim regexExpirationDate As New Regex("^(0[1-9]|1[0-2])\/\d{2}$")
        Dim regexCVV As New Regex("^\d{3}$")
        Dim regexCardholderName As New Regex("^[A-Za-z\s]+$")

        If Not regexCardNumber.IsMatch(txtCardNumber.Text) Then
            MessageBox.Show("Please enter a valid card number (16 digits).")
            Return
        End If

        If Not regexExpirationDate.IsMatch(txtExpirationDate.Text) Then
            MessageBox.Show("Please enter a valid expiration date (MM/YY).")
            Return
        End If

        If Not regexCVV.IsMatch(txtCVV.Text) Then
            MessageBox.Show("Please enter a valid CVV (3 digits).")
            Return
        End If

        If Not regexCardholderName.IsMatch(txtCardholderName.Text) Then
            MessageBox.Show("Please enter a valid cardholder name.")
            Return
        End If

        ' Display a message box indicating that the payment was successful
        MessageBox.Show("Payment successful!")

        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        Form12.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form12.Show()
    End Sub
End Class