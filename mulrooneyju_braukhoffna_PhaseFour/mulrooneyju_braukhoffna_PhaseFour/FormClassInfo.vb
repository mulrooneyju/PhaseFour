Public Class FormClassInfo

    Private staffBindingSource As New BindingSource
    Private experienceBindingSource As New BindingSource
    Private qualificationBindingSource As New BindingSource

    Private qualificationsDataView As New DataView()
    Private experienceDataView As New DataView()


    Private Sub InfoScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        staffBindingSource.DataSource = Oracle.staffTable
        qualificationsDataView.Table = Oracle.qualificationTable
        experienceDataView.Table = Oracle.experienceTable

        qualificationBindingSource.DataSource = qualificationsDataView
        experienceBindingSource.DataSource = experienceDataView

        txtStaffno.DataBindings.Add("Text", staffBindingSource, "staffNo")
        txtFname.DataBindings.Add("Text", staffBindingSource, "fname")
        txtLastname.DataBindings.Add("Text", staffBindingSource, "lname")
        txtStreet.DataBindings.Add("Text", staffBindingSource, "Street")
        txtCity.DataBindings.Add("Text", staffBindingSource, "city")
        txtState.DataBindings.Add("Text", staffBindingSource, "state")
        txtZip.DataBindings.Add("Text", staffBindingSource, "zip")
        txtPhone.DataBindings.Add("Text", staffBindingSource, "phone")
        dtpDob.DataBindings.Add("Text", staffBindingSource, "dob")
        txtGender.DataBindings.Add("Text", staffBindingSource, "gender")
        txtNin.DataBindings.Add("Text", staffBindingSource, "nin")
        txtPosition.DataBindings.Add("Text", staffBindingSource, "position")
        txtCursalary.DataBindings.Add("Text", staffBindingSource, "cursalary")
        txtSalaryscale.DataBindings.Add("Text", staffBindingSource, "salaryScale")
        txtHrsperwk.DataBindings.Add("Text", staffBindingSource, "hrsPerWk")
        txtPospermtemp.DataBindings.Add("Text", staffBindingSource, "posPermTemp")
        txtTypeofpay.DataBindings.Add("Text", staffBindingSource, "typeOfPay")

        qualificationsDataView.RowFilter = "staffno = '" & txtStaffno.Text & "'"
        experienceDataView.RowFilter = "staffno = '" & txtStaffno.Text & "'"

        txtType.DataBindings.Add("Text", qualificationBindingSource, "type")
        txtInstname.DataBindings.Add("Text", qualificationBindingSource, "Instname")
        dtpQauldate.DataBindings.Add("Text", qualificationBindingSource, "qualdate")

        txtOrgname.DataBindings.Add("Text", experienceBindingSource, "orgname")
        txtPostition.DataBindings.Add("Text", experienceBindingSource, "Position")
        dtpStartDate.DataBindings.Add("Text", experienceBindingSource, "startdate")
        dtpFinishDate.DataBindings.Add("Text", experienceBindingSource, "finishdate")


        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        QualNum.Text = (qualificationBindingSource.Position + 1) & "/" & qualificationBindingSource.Count
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
        ButtonChecker()
    End Sub


    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtStreet.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub


    Private Sub UpdateQual()
        qualificationsDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"
        experienceDataView.RowFilter = "staffno = '" & txtStaffno.Text & "'"
        QualNum.Text = (qualificationBindingSource.Position + 1) & "/" & qualificationBindingSource.Count
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
        ButtonChecker()
    End Sub
    Private Sub ButtonChecker()
        If (staffBindingSource.Count > 1) Then
            InfoNext.Enabled = True
            InfoLast.Enabled = True
        ElseIf (staffBindingSource.Position = staffBindingSource.count - 1) Then
            InfoNext.Enabled = False
            InfoLast.Enabled = False
        End If
    End Sub


    ' Qaulification Buttons
    'Arrows
    Private Sub QualNext_Click(sender As Object, e As EventArgs) Handles QualNext.Click
        qualificationBindingSource.MoveNext()
        UpdateQual()

    End Sub

    Private Sub QualLast_Click(sender As Object, e As EventArgs) Handles QualLast.Click
        qualificationBindingSource.MoveLast()
        UpdateQual()
    End Sub

    Private Sub QaulPrevious_Click(sender As Object, e As EventArgs) Handles QaulPrevious.Click
        qualificationBindingSource.MovePrevious()
        UpdateQual()


    End Sub

    Private Sub QualFirst_Click(sender As Object, e As EventArgs) Handles QualFirst.Click
        qualificationBindingSource.MoveFirst()
        UpdateQual()
    End Sub

    'Action Buttons
    Private Sub QualSave_Click(sender As Object, e As EventArgs) Handles QualSave.Click
        Try
            qualificationBindingSource.EndEdit()
            Oracle.qualificationAdapter.Update(Oracle.staffTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub QualDelete_Click(sender As Object, e As EventArgs) Handles QualDelete.Click
        Try
            qualificationBindingSource.RemoveCurrent()
            QualNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
            QualSave.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub QualNew_Click(sender As Object, e As EventArgs) Handles QualNew.Click
        txtType.Clear()
        txtInstname.Clear()

        Dim row As DataRow

        row = Oracle.qualificationTable.NewRow
        Oracle.qualificationTable.Rows.Add(row)
        qualificationBindingSource.MoveLast()

        QualNum.Text = (qualificationBindingSource.Position + 1) & "/" & qualificationBindingSource.Count

    End Sub



    'Staff Buttons
    'Arrows
    Private Sub InfoFirst_Click(sender As Object, e As EventArgs) Handles InfoFirst.Click
        staffBindingSource.MoveFirst()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    Private Sub InfoPrevious_Click(sender As Object, e As EventArgs) Handles InfoPrevious.Click
        staffBindingSource.MovePrevious()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    Private Sub InfoNext_Click(sender As Object, e As EventArgs) Handles InfoNext.Click
        staffBindingSource.MoveNext()
        experienceDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()
    End Sub

    Private Sub InfoLast_Click(sender As Object, e As EventArgs) Handles InfoLast.Click
        staffBindingSource.MoveLast()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    'Action Buttons
    Private Sub StaffDelete_Click(sender As Object, e As EventArgs) Handles QaulPrevious.Click
        Try
            staffBindingSource.RemoveCurrent()
            TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
            StaffSave.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub StaffNew_Click(sender As Object, e As EventArgs) Handles StaffNew.Click
        txtStaffno.Clear()
        txtFname.Clear()
        txtLastname.Clear()
        txtStreet.Clear()
        txtCity.Clear()
        txtState.Clear()
        txtZip.Clear()
        txtPhone.Clear()
        txtGender.Clear()
        txtNin.Clear()
        txtPosition.Clear()
        txtCursalary.Clear()
        txtSalaryscale.Clear()
        txtHrsperwk.Clear()
        txtPospermtemp.Clear()
        txtTypeofpay.Clear()

        Dim row As DataRow

        row = Oracle.staffTable.NewRow
        Oracle.staffTable.Rows.Add(row)
        staffBindingSource.MoveLast()

        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count


    End Sub

    Private Sub StaffSave_Click(sender As Object, e As EventArgs) Handles StaffSave.Click
        Try
            staffBindingSource.EndEdit()
            Oracle.staffAdapter.Update(Oracle.staffTable)
            StaffSave.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    'Experience Buttons
    'Arrow
    Private Sub expFirst_Click(sender As Object, e As EventArgs) Handles expFirst.Click
        experienceBindingSource.MoveFirst()
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub expPrevious_Click(sender As Object, e As EventArgs) Handles expPrevious.Click
        experienceBindingSource.MovePrevious()
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub expNext_Click(sender As Object, e As EventArgs) Handles expNext.Click
        experienceBindingSource.MoveNext()
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub ExpLast_Click(sender As Object, e As EventArgs) Handles ExpLast.Click
        experienceBindingSource.MoveNext()
        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    'Action Buttons
    Private Sub ExpSave_Click(sender As Object, e As EventArgs) Handles ExpSave.Click
        Try
            experienceBindingSource.EndEdit()
            Oracle.experienceAdapter.Update(Oracle.staffTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExpDelete_Click(sender As Object, e As EventArgs) Handles ExpDelete.Click
        Try
            experienceBindingSource.RemoveCurrent()
            ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
            ExpSave.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExpNew_Click(sender As Object, e As EventArgs) Handles ExpNew.Click
        txtOrgname.Clear()
        txtPosition.Clear()

        Dim row As DataRow

        row = Oracle.experienceTable.NewRow
        Oracle.experienceTable.Rows.Add(row)
        experienceBindingSource.MoveLast()

        ExpNum.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    'Search

End Class