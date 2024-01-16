Imports MySql.Data.MySqlClient
Imports Mysqlx

Module Database
    Private ReadOnly server As String = "localhost"
    Private ReadOnly database As String = "bunch_dental_information_system_db"
    Private ReadOnly user As String = "root"
    Private ReadOnly password As String = "admin"
    Private ReadOnly token As String = $"Server={server};Database={database};User={user};Password={password};"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(token)
    End Function
    Public Function GetCommand(query As String) As MySqlCommand
        Dim connection As MySqlConnection = GetConnection()
        connection.Open()
        Return New MySqlCommand(query, connection)
    End Function
    Public Sub TestDatabaseConnection()
        Using connection As MySqlConnection = GetConnection()
            Try
                connection.Open()
                MsgBox("Connection successful!")
            Catch ex As Exception
                MsgBox($"Connection failed: {ex.Message}")
            End Try
        End Using
    End Sub
    Public Function FetchPatientNo() As String
        Dim patientCount As Integer
        Dim query As String = "SELECT COUNT(*) FROM patients"
        Using command = GetCommand(query)
            patientCount = CInt(command.ExecuteScalar()) + 1
        End Using

        Return patientCount.ToString
    End Function
    Public Function FetchIndividualPatientNo() As String
        Dim patientCount As Integer
        Dim query As String = "SELECT COUNT(*) FROM patients"
        Using command = GetCommand(query)
            patientCount = CInt(command.ExecuteScalar())
        End Using

        Return patientCount.ToString
    End Function
End Module
