Imports MySql.Data.MySqlClient
Public Class MY_CONNECTION
    Private connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=root;database=sep")
    ReadOnly Property getConnection() As MySqlConnection
        Get
            Return connection
        End Get
    End Property
    Sub openConnection()

        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

    End Sub
    Sub closeConnection()

        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If

    End Sub
End Class