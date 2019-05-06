Public Class Oracle

    Public Enum ResponseType
        OK
        Cancel
    End Enum

    Friend Shared Result As ResponseType
    Friend Shared UserName As String
    Friend Shared PassWord As String
    Friend Shared Server As String

    Friend Shared OracleConnection As New System.Data.OracleClient.OracleConnection


    Friend Shared bookingAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared bookingCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared bookingCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared bookingTable As New System.Data.DataTable

    Friend Shared frmLogin As New FormClassLogin
    Private Shared frmInfo As New FormClassInfo



    Public Shared Sub LogInAtRunTime()
        OracleConnection.ConnectionString = "Data Source=" & Server & ";User ID=" & UserName & ";Password=" & PassWord & ";Unicode=True"
        bookingCommand.Connection = OracleConnection
        bookingCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(bookingAdapter)
    End Sub

    Public Shared Sub Main()
        Dim connected As Boolean

        While Not connected
            frmLogin.ShowDialog()
            If Result = ResponseType.Cancel Then
                Exit While
            End If

            Try
                LogInAtRunTime()
                connected = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End While

        If connected Then
            Application.Run(frmInfo)
        End If
    End Sub
End Class