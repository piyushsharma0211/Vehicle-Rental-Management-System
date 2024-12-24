Imports MySql.Data.MySqlClient

Public Class Form6
    'Dim con = new sqlconnetion("datasource =.............)


    Private Sub fillRegistration()
        Dim Status = "Yes"
        'con.open()
        'Dim sql ="SELECT * FROM car_tbl WHERE Available='"& Status &"'"
        'Dim cmd As New Sqlcommand(sql,con)
        'Dim adapter As New Sql DataADapter(cmd)
        'Dim tbl as New DataTable()
        'adapter.Fill(Tbl)
        'combobox1.DataSource = tbl
        'combobox1.DisplayMember = "RegNo"
        'combobox1.ValueMember = "RegNo"
        'Con.Close()
    End Sub

    Private Sub UpdateCar()
        Dim status = "No"
        Dim conn As New MY_CONNECTION()
        Dim regno As String = TextBox3.Text
        Try
            conn.openConnection()
            Dim command As New MySqlCommand("Update `car_tbl` SET available=@st where regno=@rg", conn.getConnection())
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = status
            command.Parameters.Add("@rg", MySqlDbType.VarChar).Value = regno

            command.ExecuteNonQuery()
            conn.closeConnection()
            'con.open()
            'Dim query = "UPDATE car_tbl SET available = '"& Status &"' WHERE regNo ='"& ComboBox1.SelectedValue.ToString() &"'"

            'Dim cmd as sqlcommand
            'cmd = New sqlcommand(query, Con)
            'cmd.ExecuteNonQuery()
            'con.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fillCustomer()


        'con.open()
        'Dim sql ="SELECT * FROM customer_tbl"
        'Dim cmd As New Sqlcommand(sql,con)
        'Dim adapter As New Sql DataADapter(cmd)
        'Dim tbl as New DataTable()
        'adapter.Fill(Tbl)
        'combobox2.DataSource = tbl
        'combobox2.DisplayMember = "CustId"
        'combobox2.ValueMember = "CustId"
        'Con.Close()
    End Sub

    Private Sub GetCustName()
        Dim conn As New MY_CONNECTION()
        Dim regno As String = TextBox3.Text
        conn.openConnection()
        Dim command As New MySqlCommand("SELECT price FROM `car_tbl` WHERE regno=@rg", conn.getConnection())
        command.Parameters.Add("@rg", MySqlDbType.VarChar).Value = regno
        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        Dim reader As MySqlDataReader
        reader = command.ExecuteReader
        While reader.Read
            TextBox5.Text = reader(0).ToString()
        End While
        conn.closeConnection()


        'con.open()
        'Dim sql ="SELECT * FROM customer_tbl WHERE custid ="& combobox2.selectedValue.ToString() &""
        'Dim cmd As New Sqlcommand(sql,con)

        'Dim dt as New DataTable()
        'Dim reader As sqlDataReader
        'reader = cmd.ExecuteReader
        'while reader.Read 
        'textbox1.text = reader(1).Tostring()
        'end While
        'Con.Close()
    End Sub


    'Dim fee As String = TextBox5.Text

    'Dim Cost As Int32 = Label7.Text
    'Dim cost = 0


    Private Sub GetCarRent()

    End Sub


    'Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    'fillCustomer()
    'fillRegistration()
    'Populate()
    ' End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs)
        'GetCustName()

    End Sub

    Private Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    'Private Sub Populate()

    'con.open()
    'dim sql = "selct * from rent_tbl"
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


    Private Sub CalculateFee()
        'calculate the number of days the car will be rented
        Dim diff As System.TimeSpan = DateTimePicker2.Value.Date.Subtract(DateTimePicker1.Value.Date)
        'MsgBox(diff.TotalDays)
        Label10.Text = diff.TotalDays
        Dim Days = diff.TotalDays
        Dim fees = Days * Val(TextBox5.Text)
        TextBox2.Text = fees
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Missing data ")
        Else
            Dim conn As New MY_CONNECTION()
            Dim rid As Int32 = 0
            Dim d1, d2 As String
            d1 = DateTimePicker1.Value.Date.ToString("yyyy-MM-dd")
            d2 = DateTimePicker2.Value.Date.ToString("yyyy-MM-dd")
            Try

                'con Open()
                conn.openConnection()
                Dim Query = "INSERT INTO rent_tbl VALUES('" & rid & "', '" & TextBox3.Text & "','" & TextBox4.Text & "', '" & TextBox1.Text & "','" & d1 & "' , '" & d2 & "', '" & TextBox2.Text & "')"
                Dim command As New MySqlCommand(Query, conn.getConnection())
                command.ExecuteNonQuery()

                'Dim cmd As sqlcommand
                'cmd = new sqlCommand(query, con)
                'cmd.ExecuteNoQuery()
                MsgBox("Car Successfully Rented. Enjoy")
                'con.close()
                'clear()
                'fillRegistration()
                UpdateCar()
                conn.closeConnection()
                Me.Hide()
                Dim mc As New Form11()
                mc.Show()

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        GetCustName()
        CalculateFee()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.MinDate = DateTimePicker1.Value.AddDays(1)

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim dc As New Form7()
        dc.Show()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only letters and spaces
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = " " Then
            e.Handled = True
            MessageBox.Show("Please enter only letters and spaces", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label9.Text = GlobalVariables.LoggedInUser

        DateTimePicker1.Value = DateTime.Today
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
    End Sub





    'Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs)
    '   GetCarRent()
    'End Sub
End Class