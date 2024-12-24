Imports MySql.Data.MySqlClient

Public Class Form4

    Private Sub Populate()
        Dim conn As New MY_CONNECTION()
        Dim command As MySqlCommand
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            conn.openConnection()
            Dim Query As String
            Query = "Select * from sep.tbl_accounts"
            command = New MySqlCommand(Query, conn.getConnection())
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            conn.closeConnection()
        Catch ex As Exception

        Finally
            conn.getConnection().Dispose()
        End Try
    End Sub
    'Private Sub populate()
    'con.open()
    'dim sql = "selct * from account_tbl"
    'dim cmd = New sqlcommand(sql,con)
    'dim adapter as sqldataadapter
    ' adapter = new sqldataadapter(cmd)
    'dim builder as sqlcommandbuilder
    'builder = new sqlcommandbuilder(adapter)
    'dim ds as dataset
    'ds = new dataset
    'adapter.fill(ds)
    'DataGridView1.datasource = ds.tables(0)
    'con.close()
    'End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim car As New Form3()
        car.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim ret As New Form5()
        ret.Show()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Dim lg As New Form2()
        lg.Show()
    End Sub
End Class