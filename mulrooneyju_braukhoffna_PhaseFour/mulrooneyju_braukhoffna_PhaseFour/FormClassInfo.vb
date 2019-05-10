Public Class FormClassInfo

    Private staffBindingSource As New BindingSource
    Private experienceBindingSource As New BindingSource
    Private qualificationBindingSource As New BindingSource

    Private qualificationsDataView As New DataView()
    Private experienceDataView As New DataView()


    Private Sub InfoScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        staffBindingSource.DataSource = Oracle.staffTable
        experienceBindingSource.DataSource = Oracle.experienceTable
        qualificationsDataView.Table = Oracle.qualificationTable
        qualificationBindingSource.DataSource = qualificationsDataView

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

        'qualificationsDataView.Table = Oracle.qualificationTable

        qualificationsDataView.RowFilter = "staffno = '" & txtStaffno.Text & "'"

        txtType.DataBindings.Add("Text", qualificationBindingSource, "type")
        txtInstname.DataBindings.Add("Text", qualificationBindingSource, "Instname")
        dtpQauldate.DataBindings.Add("Text", qualificationBindingSource, "qualdate")




        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count



        'txtType.DataBindings.Add("Text", qualificationBindingSource, "Type")
        'txtInstname.DataBindings.Add("Text", qualificationBindingSource, "instname")

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
        qualificationsDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"
        experienceDataView.RowFilter = "STAFFNO = '" + txtStaffno.Text + "'"

        'Oracle.qualificationCommand.CommandText = "select * 
        '                                           from uwp_qualifications
        '                                           where staffno = " + txtStaffno.Text + ";"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles InfoLast.Click
        staffBindingSource.MoveLast()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles InfoFirst.Click
        staffBindingSource.MoveFirst()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles InfoPrevious.Click
        staffBindingSource.MovePrevious()
        TextBox16.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        qualificationBindingSource.MoveNext()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        qualificationBindingSource.MoveLast()

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        qualificationBindingSource.MovePrevious()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        qualificationBindingSource.MoveFirst()
    End Sub

End Class