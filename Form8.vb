Imports MySql.Data.MySqlClient

Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Hatchback")
        ComboBox1.Items.Add("Sedan")
        ComboBox1.Items.Add("SUV")
    End Sub

    Private Sub Populate(ByVal a As String)
        Dim conn As New MY_CONNECTION()
        Dim command As MySqlCommand
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            conn.openConnection()
            command = New MySqlCommand("Select `brand` , `model` , `price` , `available`, `regno` from  `car_tbl` where `type`=@ty", conn.getConnection())
            command.Parameters.Add("@ty", MySqlDbType.VarChar).Value = a
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
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim type As String = ComboBox1.SelectedItem.ToString()
        Populate(type)
    End Sub

    'Dim rt As New Form6()
    Dim reg As String
    Dim r2 As String
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim decision As String = row.Cells(3).Value.ToString
        If decision = "Yes" Then
            Label1.Text = "You have selected " + row.Cells(1).Value.ToString + " of brand " + row.Cells(0).Value.ToString + " to proceed further click proceed button"
            reg = row.Cells(4).Value.ToString
            r2 = row.Cells(3).Value.ToString
        Else
            MessageBox.Show("Car is not available")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim rt As New Form6()
        rt.Show()
        rt.TextBox3.Text = reg
        rt.TextBox4.Text = Label2.Text
        'rt.TextBox5.Text = r2



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim bc As New Form7()
        bc.Show()

    End Sub


End Class