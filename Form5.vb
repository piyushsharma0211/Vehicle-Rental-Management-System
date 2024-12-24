Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class Form5

    'dim con = new sqlconnetcion("data source=...........)

    Private Sub Populate()
        Dim conn As New MY_CONNECTION()
        Dim command As MySqlCommand
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            conn.openConnection()
            Dim Query As String
            Query = "Select * from sep.rent_tbl"
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


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
        PopulateReturn()
    End Sub

    Dim delay = 0

    Private Sub Calculatedelay()


        'calculate the delay
        'Dim diff As System.TimeSpan = Convert.ToDateTime(TextBox3.Text).Subtract(DateTime.Today.Date)
        Dim diff As System.TimeSpan = DateTime.Today.Date.Subtract(Convert.ToDateTime(TextBox3.Text))
        MsgBox(diff.TotalDays)
        Dim days = diff.TotalDays
        If days < 0 Then
            days = 0
            TextBox4.Text = "no delay"
        Else
            TextBox4.Text = days

        End If
        Dim fine = days * 500
        '500 rs penatlty fine per days
        TextBox4.Text = days
        TextBox5.Text = fine

    End Sub

    Private Sub CalculateFine()

        'calculate the fine due to delay
        If TextBox4.Text = "no delay" Then
            TextBox5.Text = "no fine"
        Else
            Dim days = Convert.ToInt32(TextBox4.Text)
            '500 rs penatlty fine per days
            Dim fine = days * 500
            TextBox5.Text = fine


        End If

    End Sub

    Dim MyReturn As DateTime
    Dim key = 0

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        TextBox1.Text = row.Cells(1).Value.ToString
        TextBox2.Text = row.Cells(3).Value.ToString
        TextBox3.Text = row.Cells(5).Value.ToString
        MyReturn = row.Cells(5).Value
        If TextBox1.Text = "" Then
            key = 0
        Else
            key = row.Cells(0).Value.ToString

        End If


    End Sub



    Private Sub TextBox4_OnValueChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        CalculateFine()

    End Sub

    Private Sub UpdateCar()
        Dim conn As New MY_CONNECTION
        Dim status As String = "Yes"
        Dim reg As String = TextBox1.Text
        Try
            conn.openConnection()
            Dim adapter As New MySqlDataAdapter()
            Dim table As New DataTable()
            Dim command As New MySqlCommand("UPDATE car_tbl SET available=@av WHERE regno=@rg", conn.getConnection())
            command.Parameters.Add("@av", MySqlDbType.VarChar).Value = status
            command.Parameters.Add("@rg", MySqlDbType.VarChar).Value = reg
            command.ExecuteNonQuery()
            conn.closeConnection()

            'con.open()
            'Dim query = "UPDATE car_tbl SET available = '"& Status &"' WHERE regNo ='"& textbox1.text &"'
            'Dim cmd as sqlcommand
            'cmd = New sqlcommand(query, Con)
            'cmd.ExecuteNonQuery()
            'con.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Delete()
        Dim conn As New MY_CONNECTION()
        Dim carReg As String = TextBox1.Text
        Try
            conn.openConnection()
            Dim cmd As New MySqlCommand("DELETE FROM rent_tbl WHERE carReg = @ky", conn.getConnection())
            cmd.Parameters.Add("@ky", MySqlDbType.VarChar).Value = carReg
            cmd.ExecuteNonQuery()
            'Con.open()
            'Dim query = "DELETE FROM rent_tbl WHERE rid = "& key  &"'"
            'Dim cmd As sqlcommand
            'cmd=new sqlcommand(qery,con)
            'cmd.executeNonQuery()
            MsgBox("car Successfully deleted")
            conn.closeConnection()

            Clear()
            Populate()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim conn As New MY_CONNECTION
        Dim retId As Int32 = key
        Dim carReg As String = TextBox1.Text
        Dim custname As String = TextBox2.Text


        If TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("selete the car to return ")
        Else
            Dim delay, fine
            If TextBox4.Text = "no delay" Then
                delay = 0
            Else
                delay = TextBox4.Text
            End If
            If TextBox5.Text = "no fine" Then
                fine = 0
            Else
                fine = TextBox5.Text
            End If

            Try
                conn.openConnection()
                Dim command As New MySqlCommand("INSERT INTO `return_tbl` (`retId`, `carReg`, `custname`, `returnDate`, `delay`, `fine`) VALUES (@ret, @cr, @cn, @rd, @dly, @fn)", conn.getConnection())
                command.Parameters.Add("@ret", MySqlDbType.Int32).Value = retId
                command.Parameters.Add("@cr", MySqlDbType.VarChar).Value = carReg
                command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = custname
                command.Parameters.Add("@rd", MySqlDbType.Date).Value = MyReturn
                command.Parameters.Add("@dly", MySqlDbType.Int32).Value = delay
                command.Parameters.Add("@fn", MySqlDbType.Int32).Value = fine
                command.ExecuteNonQuery()
                'con.open
                'dim query = "INSERT INTO renturn_tbl VALUES('"& texbox1.text &"', '"& texbox2.text &"', '"& MyReturn &"','"& delay &"', '"& fine &"')"
                'dim cmd as sqlcommand
                'cmd = new sql command(query, con)
                'cmd.executenonquery()
                MsgBox("car successfully returned")
                'con.close()
                conn.closeConnection()
                UpdateCar()

                PopulateReturn()
                Delete()
                Clear()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PopulateReturn()

        Dim conn As New MY_CONNECTION()
        Dim command As MySqlCommand
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            conn.openConnection()
            Dim Query As String
            Query = "Select * from sep.return_tbl"
            command = New MySqlCommand(Query, conn.getConnection())
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView2.DataSource = bSource
            SDA.Update(dbDataSet)
            conn.closeConnection()
        Catch ex As Exception

        Finally
            conn.getConnection().Dispose()
        End Try

        'con.open()
        'dim sql = "selct * from return_tbl"
        'dim cmd = New sqlcommand(sql,con)
        'dim adapter as sqldataadapter
        ' adapter = new sqldataadapter(cmd)
        'dim builder as sqlcommandbuilder
        'builder = new sqlcommandbuilder(adapter)
        'dim ds as dataset
        'ds = new dataset
        'adapter.fill(ds)
        'DataGridView2.datasource = ds.tables(0)
        'con.close()

    End Sub

    'Private Sub TextBox3_OnValueChanged(sender As Object, e As EventArgs) Handles TextBox3.OnValueChanged

    'calculateDelay()

    'End Sub




    Private Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        key = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim car As New Form3()
        car.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim cust As New Form4()
        cust.Show()
    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Calculatedelay()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Dim lg As New Form2()
        lg.Show()
    End Sub
End Class