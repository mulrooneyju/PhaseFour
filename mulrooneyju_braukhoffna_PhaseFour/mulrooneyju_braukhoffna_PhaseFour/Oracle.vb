Public Class Oracle

    Public Enum ResponseType
        OK
        Cancel
    End Enum

    Friend Shared OracleConnection As New System.Data.OracleClient.OracleConnection
    'Log in page
    Friend Shared frmLogin As New FormClassLogin
    Private Shared frmInfo As New FormClassInfo


    Friend Shared Result As ResponseType
    Friend Shared UserName As String
    Friend Shared PassWord As String
    Friend Shared Server As String

    'Variables for Staff
    Friend Shared staffAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared staffCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared staffCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared staffTable As New System.Data.DataTable

    'Variables for qualification
    Friend Shared qualificationAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared qualificationCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared qualificationCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared qualificationTable As New System.Data.DataTable("UWP_Qualifications")

    'Variables for Expectation
    Friend Shared experienceAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared experienceCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared experienceCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared experienceTable As New System.Data.DataTable("UWP_Experience")


    Public Shared Sub LogInAtRunTime()


        OracleConnection.ConnectionString = "Data Source=" & Server & ";User ID=" & UserName & ";Password=" & PassWord & ";Unicode=True"

        'staff table set up
        staffCommand.CommandType = CommandType.Text
        staffCommand.CommandText = "Select * from UWP_STAFF"
        staffCommand.Connection = OracleConnection

        staffAdapter.SelectCommand = staffCommand
        staffCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(staffAdapter)
        staffAdapter.Fill(staffTable)

        'qualification table set up 
        qualificationCommand.CommandType = CommandType.Text
        qualificationCommand.CommandText = "Select * from UWP_Qualification"
        qualificationCommand.Connection = OracleConnection

        qualificationAdapter.SelectCommand = qualificationCommand
        qualificationCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(qualificationAdapter)
        staffAdapter.Fill(qualificationTable)


        'Work Experience table set up
        experienceCommand.CommandType = CommandType.Text
        experienceCommand.CommandText = "Select * from UWP_WorkExperience"
        experienceCommand.Connection = OracleConnection

        experienceAdapter.SelectCommand = experienceCommand
        experienceCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(experienceAdapter)
        experienceAdapter.Fill(experienceTable)


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