﻿Public Class FormClassInfo

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
        txtExpPostition.DataBindings.Add("Text", experienceBindingSource, "Position")
        dtpStartDate.DataBindings.Add("Text", experienceBindingSource, "startdate")
        dtpFinishDate.DataBindings.Add("Text", experienceBindingSource, "finishdate")


        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        TextBox17.Text = (qualificationBindingSource.Position + 1) & "/" & qualificationBindingSource.Count
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
        ButtonChecker()
    End Sub


    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtStreet.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles InfoNext.Click
        staffBindingSource.MoveNext()
        experienceDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles InfoLast.Click
        staffBindingSource.MoveLast()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles InfoFirst.Click
        staffBindingSource.MoveFirst()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles InfoPrevious.Click
        staffBindingSource.MovePrevious()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        UpdateQual()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles QualNext.Click
        qualificationBindingSource.MoveNext()
        UpdateQual()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles QualLast.Click
        qualificationBindingSource.MoveLast()
        UpdateQual()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles QualPrevious.Click
        qualificationBindingSource.MovePrevious()
        UpdateQual()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles QualFirst.Click
        qualificationBindingSource.MoveFirst()
        UpdateQual()
    End Sub

    Private Sub UpdateQual()
        qualificationsDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"
        experienceDataView.RowFilter = "staffno = '" & txtStaffno.Text & "'"
        TextBox17.Text = (qualificationBindingSource.Position + 1) & "/" & qualificationBindingSource.Count
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
        ButtonChecker()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles ExpFirst.Click
        experienceBindingSource.MoveFirst()
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles ExpPrevious.Click
        experienceBindingSource.MovePrevious()
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles ExpNext.Click
        experienceBindingSource.MoveNext()
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles ExpLast.Click
        experienceBindingSource.MoveNext()
        TextBox18.Text = (experienceBindingSource.Position + 1) & "/" & experienceBindingSource.Count
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

End Class