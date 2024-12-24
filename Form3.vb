Imports MySql.Data.MySqlClient

Public Class Form3





    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim vehicleNumber As String = TextBox1.Text.Trim()
        If vehicleNumber.Length <> 10 Then
            MessageBox.Show("Invalid vehicle number format: the length should be 10 characters")
            TextBox1.Focus()
            Return
        End If
        If Not Char.IsLetter(vehicleNumber.Chars(0)) OrElse Not Char.IsLetter(vehicleNumber.Chars(1)) Then
            MessageBox.Show("Invalid vehicle number format: the first two characters should be alphabets")
            TextBox1.Focus()
            Return
        End If
        If Not Char.IsDigit(vehicleNumber.Chars(2)) OrElse Not Char.IsDigit(vehicleNumber.Chars(3)) Then
            MessageBox.Show("Invalid vehicle number format: the third and fourth characters should be digits")
            TextBox1.Focus()
            Return
        End If
        If Not Char.IsLetter(vehicleNumber.Chars(4)) OrElse Not Char.IsLetter(vehicleNumber.Chars(5)) Then
            MessageBox.Show("Invalid vehicle number format: the fifth and sixth characters should be alphabets")
            TextBox1.Focus()
            Return
        End If
        If Not Char.IsDigit(vehicleNumber.Chars(6)) OrElse Not Char.IsDigit(vehicleNumber.Chars(7)) OrElse Not Char.IsDigit(vehicleNumber.Chars(8)) OrElse Not Char.IsDigit(vehicleNumber.Chars(9)) Then
            MessageBox.Show("Invalid vehicle number format: the last four characters should be digits")
            TextBox1.Focus()
            Return
        End If
    End Sub







    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try

            Dim cid As Int32 = 0
            Dim regno As String = TextBox1.Text
            Dim brand As String = ComboBox1.SelectedItem.ToString()
            Dim model As String = ComboBox3.SelectedItem.ToString()
            Dim color As String = TextBox3.Text
            Dim price As Int32 = TextBox4.Text
            Dim type As String = TextBox2.Text
            Dim available As String = ComboBox2.SelectedItem.ToString()

            Dim conn As New MY_CONNECTION()
            Dim adapter As New MySqlDataAdapter()
            Dim table As New DataTable()
            Dim command As New MySqlCommand("Insert INTO `car_tbl`(`cid`, `regno`, `brand`, `model`, `color`, `price`, `available`, `type`) VALUES(@cd,@rg,@br,@md,@cl,@pr,@av,@ty)", conn.getConnection())


            command.Parameters.Add("@cd", MySqlDbType.Int32).Value = cid
            command.Parameters.Add("@rg", MySqlDbType.VarChar).Value = regno
            command.Parameters.Add("@br", MySqlDbType.VarChar).Value = brand
            command.Parameters.Add("@md", MySqlDbType.VarChar).Value = model
            command.Parameters.Add("@cl", MySqlDbType.VarChar).Value = color
            command.Parameters.Add("@pr", MySqlDbType.Int32).Value = price
            command.Parameters.Add("@av", MySqlDbType.VarChar).Value = available
            command.Parameters.Add("@ty", MySqlDbType.VarChar).Value = type
            conn.openConnection()
            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Car Successfully Saved", "Admin Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.closeConnection()
            Else
                MessageBox.Show("Something Happens", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.closeConnection()
            End If
            'Con.open()
            'Dim query = "INSERT INTO car_tbl VALUES('"&TextBox1.text &"', '"&ComboBox1.SelectedItem.ToString() &"','"&TextBox2.text &"','"&TextBox4.text &"', '"&TextBox3.text &"','" &ComboBox2.SelectedItem.ToString() &'"
            'Dim cmd As sqlcommand
            'cmd=new sqlcommand(qery,con)
            'cmd.executeNonQuery()
            'MsgBox("car Successfully saved")
            'con.close()
            Clear()

            Populate()
        Catch ex As Exception

        End Try

    End Sub
    Dim Key As Int32 = 0
    Private Sub Clear()
        TextBox1.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.SelectedIndex = -1
        Key = 0
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Clear()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        'TextBox1.Text = row.Cells(2).ToString
        TextBox1.Text = row.Cells(1).Value.ToString
        ComboBox1.SelectedItem = row.Cells(2).Value.ToString
        ComboBox3.SelectedItem = row.Cells(3).Value.ToString
        TextBox2.Text = row.Cells(7).Value.ToString
        TextBox4.Text = row.Cells(4).Value.ToString
        TextBox3.Text = row.Cells(5).Value.ToString
        ComboBox2.SelectedItem = row.Cells(6).Value.ToString

        If TextBox1.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If

    End Sub

    Private Sub Populate()

        Dim conn As New MY_CONNECTION()
        Dim command As MySqlCommand
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            conn.openConnection()
            Dim Query As String
            Query = "Select * from sep.car_tbl"
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

        'con.open()
        'dim sql = "selct * from car_tbl"
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
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim conn As New MY_CONNECTION()
        If Key = 0 Then
            MsgBox("select the car")
        Else
            Try
                conn.openConnection()
                Dim cmd As New MySqlCommand("DELETE FROM `car_tbl` WHERE `cid` = @ky", conn.getConnection())
                cmd.Parameters.Add("@ky", MySqlDbType.Int32).Value = Key
                cmd.ExecuteNonQuery()
                'Con.open()
                'Dim query = "DELETE FROM car_tbl WHERE cid = "& key &""
                'Dim cmd As sqlcommand
                'cmd=new sqlcommand(qery,con)
                'cmd.executeNonQuery()
                MsgBox("car Successfully deleted")
                'con.close()
                conn.closeConnection()
                Clear()
                Populate()
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim conn As New MY_CONNECTION
        Dim cid As Int32 = Key
        Dim regno As String = TextBox1.Text
        Dim brand As String = ComboBox1.SelectedItem.ToString()
        Dim model As String = ComboBox3.SelectedItem.ToString()
        Dim color As String = TextBox3.Text
        Dim price As Int32 = TextBox4.Text
        Dim available As String = ComboBox2.SelectedItem.ToString()
        Dim type As String = TextBox2.Text
        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox2.SelectedIndex = -1 Or ComboBox3.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else

            'If textbox1.text = "" or combobox1.selectedindex = -1 or textbox2.tex = "" or textbox3.tex = "" or textbox4.tex = "" or combobox2.selectedindex = -1 
            'msgbox("missing information")
            Try
                Dim adapter As New MySqlDataAdapter()
                Dim table As New DataTable()
                Dim command As New MySqlCommand("UPDATE car_tbl SET regno=@rg, brand=@br, model=@md, color=@cl, price=@pr, available=@av , type=@ty WHERE cid=@cd", conn.getConnection())


                command.Parameters.Add("@cd", MySqlDbType.Int32).Value = cid
                command.Parameters.Add("@rg", MySqlDbType.VarChar).Value = regno
                command.Parameters.Add("@br", MySqlDbType.VarChar).Value = brand
                command.Parameters.Add("@md", MySqlDbType.VarChar).Value = model
                command.Parameters.Add("@cl", MySqlDbType.VarChar).Value = color
                command.Parameters.Add("@pr", MySqlDbType.Int32).Value = price
                command.Parameters.Add("@av", MySqlDbType.VarChar).Value = available
                command.Parameters.Add("@ty", MySqlDbType.VarChar).Value = type
                conn.openConnection()
                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Car Successfully Updated", "Admin Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    conn.closeConnection()
                Else
                    MessageBox.Show("Something Happens", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.closeConnection()
                End If
                'Con.open()
                'Dim query = "UPDATE car_tbl SET regNo='"&TextBox1.text &"', Brand= '"&ComboBox1.SelectedItem.ToString() &"',Model='"&TextBox2.text &"', price='"&TextBox4.text &"', color= '"&TextBox3.text &"', available= '" &ComboBox2.SelectedItem.ToString() &"' WHERE cid="&key&""
                'Dim cmd As sqlcommand
                'cmd=new sqlcommand(qery,con)
                'cmd.executeNonQuery()
                'MsgBox("car Successfully updated")
                'con.close()
                Clear()
                Populate()
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim cust As New Form4()
        cust.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim ret As New Form5()
        ret.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Tata" Then
            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Indica")
            ComboBox3.Items.Add("Indigo")
            ComboBox3.Items.Add("Altroz")
            ComboBox3.Items.Add("Tigor")
            ComboBox3.Items.Add("Sumo")
        End If
        If ComboBox1.SelectedItem = "Mahindra" Then
            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Bolero")
            ComboBox3.Items.Add("Scorpio")
            ComboBox3.Items.Add("XUV 500")
            ComboBox3.Items.Add("KUV 100")
        End If
        If ComboBox1.SelectedItem = "Maruti Suzuki" Then
            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Baleno")
            ComboBox3.Items.Add("Desire")
            ComboBox3.Items.Add("Alto")
            ComboBox3.Items.Add("Swift")
            ComboBox3.Items.Add("Ciaz")
        End If
        If ComboBox1.SelectedItem = "Hyundai" Then
            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Verna")
            ComboBox3.Items.Add("Creata")
            ComboBox3.Items.Add("i 20")
            ComboBox3.Items.Add("i 10")
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedItem = "Indica" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Indigo" Then
            TextBox2.Text = ""
            TextBox2.Text = "Sedan"
        End If
        If ComboBox3.SelectedItem = "Altroz" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Tigor" Then
            TextBox2.Text = ""
            TextBox2.Text = "Sedan"
        End If
        If ComboBox3.SelectedItem = "Sumo" Then
            TextBox2.Text = ""
            TextBox2.Text = "SUV"
        End If
        If ComboBox3.SelectedItem = "Bolero" Then
            TextBox2.Text = ""
            TextBox2.Text = "SUV"
        End If
        If ComboBox3.SelectedItem = "Scorpio" Then
            TextBox2.Text = ""
            TextBox2.Text = "SUV"
        End If
        If ComboBox3.SelectedItem = "XUV 500" Then
            TextBox2.Text = ""
            TextBox2.Text = "SUV"
        End If
        If ComboBox3.SelectedItem = "KUV 100" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Baleno" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Desire" Then
            TextBox2.Text = ""
            TextBox2.Text = "Sedan"
        End If
        If ComboBox3.SelectedItem = "Swift" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Alto" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "Ciaz" Then
            TextBox2.Text = ""
            TextBox2.Text = "Sedan"
        End If
        If ComboBox3.SelectedItem = "Verna" Then
            TextBox2.Text = ""
            TextBox2.Text = "Sedan"
        End If
        If ComboBox3.SelectedItem = "Creata" Then
            TextBox2.Text = ""
            TextBox2.Text = "SUV"
        End If
        If ComboBox3.SelectedItem = "i 20" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
        If ComboBox3.SelectedItem = "i 10" Then
            TextBox2.Text = ""
            TextBox2.Text = "HatchBack"
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Dim lg As New Form2()
        lg.Show()
    End Sub
End Class