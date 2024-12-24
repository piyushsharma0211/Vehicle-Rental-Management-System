Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 59000  ' Set interval to 1 minutes
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim gg As New Form10()
        gg.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
        Dim frm2 As New Form10()
        frm2.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Dim cr As New Form14()
        cr.Show()
    End Sub
End Class