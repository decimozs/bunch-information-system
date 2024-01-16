Imports System.Net

Public Class InsuredViewDetails
    Public monthBoxPanel As New Panel
    Public relationshipToPatientPanel As New Panel
    Public uniqueInusredNo As String
    Public insuredNo As New TextBox
    Public fullname As New TextBox
    Public ssiNumber As New TextBox
    Public month As New TextBox
    Public day As New TextBox
    Public year As New TextBox
    Public homeNo As New TextBox
    Public cellNo As New TextBox
    Public email As New TextBox
    Public relationshipToPatient As New TextBox
    Public address As New TextBox
    Public barangay As New TextBox
    Public city As New TextBox
    Public zipCode As New TextBox
    Dim currentDate As DateTime = DateTime.Now
    Dim dateNow As String = currentDate.ToString("MMMM dd, yyyy")
    Dim dataFoundPopUpPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub InsuredViewDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        SaveButton()
        BackButton()
        DeleteButton()
        EditButton()
        PreviousButton()
        RelationshipToPatinetDropDownButton()
        MonthDropDownButton()
        InputInsuredNo()
        InputInsuredName()
        InputSSINumber()
        InputMonth()
        InputDay()
        InputYear()
        InputHomeNo()
        InputCellNo()
        InputEmail()
        InputRelationshipToPatient()
        InputAddress()
        BackButton()
    End Sub

    Private Sub BackButton()
        Dim backBtn = Tools.CreateButton(Me, 55, 26, 1345, 46)
        AddHandler backBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Me.Hide()
                                      TextBoxReadMeOnly()
                                      PatientViewDetails.Hide()
                                      GuardianViewDetails.Hide()
                                  End Sub
    End Sub
    Private Sub DeleteButton()
        Dim deleteBtn = Tools.CreateButton(Me, 175, 67, 449, 895)
        AddHandler deleteBtn.Click, Sub(sender As Object, e As EventArgs)
                                        DeletePatientData()
                                    End Sub
    End Sub
    Private Sub EditButton()
        Dim editBtn = Tools.CreateButton(Me, 175, 67, 633, 895)
        AddHandler editBtn.Click, Sub(sender As Object, e As EventArgs)
                                      fullname.ReadOnly = False
                                      day.ReadOnly = False
                                      year.ReadOnly = False
                                      homeNo.ReadOnly = False
                                      cellNo.ReadOnly = False
                                      email.ReadOnly = False
                                      address.ReadOnly = False
                                      barangay.ReadOnly = False
                                      city.ReadOnly = False
                                      zipCode.ReadOnly = False
                                      Handlers.SetEditStatus()
                                  End Sub
    End Sub
    Public Sub TextBoxReadMeOnly()
        fullname.ReadOnly = True
        day.ReadOnly = True
        year.ReadOnly = True
        homeNo.ReadOnly = True
        cellNo.ReadOnly = True
        email.ReadOnly = True
        address.ReadOnly = True
        barangay.ReadOnly = True
        city.ReadOnly = True
        zipCode.ReadOnly = True

        fullname.ForeColor = Color.Gray
        month.ForeColor = Color.Gray
        relationshipToPatient.ForeColor = Color.Gray
        day.ForeColor = Color.Gray
        year.ForeColor = Color.Gray
        homeNo.ForeColor = Color.Gray
        cellNo.ForeColor = Color.Gray
        email.ForeColor = Color.Gray
        address.ForeColor = Color.Gray
        barangay.ForeColor = Color.Gray
        city.ForeColor = Color.Gray
        zipCode.ForeColor = Color.Gray
    End Sub
    Private Sub SaveButton()
        Dim saveBtn = Tools.CreateButton(Me, 175, 67, 817, 895)
        AddHandler saveBtn.Click, Sub(sender As Object, e As EventArgs)
                                      UpdateInsuredData()
                                  End Sub
    End Sub
    Private Sub PreviousButton()
        Dim prevBtn = Tools.CreateButton(Me, 54, 97, 146, 411)
        AddHandler prevBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.OpenWindow(Me, GuardianViewDetails)
                                  End Sub
    End Sub
    Private Sub InputInsuredNo()
        insuredNo = Tools.CreateInputBox(Me, "", 225, 52, 608, 58)
        insuredNo.ForeColor = Color.Black
        insuredNo.ReadOnly = True
    End Sub
    Private Sub InputInsuredName()
        fullname = Tools.CreateInputBox(Me, "Guardian Name", 597, 40, 421, 270)
        fullname.ReadOnly = True
    End Sub
    Private Sub InputSSINumber()
        ssiNumber = Tools.CreateInputBox(Me, "SSI No.", 600, 52, 421, 365)
    End Sub
    Private Sub InputMonth()
        month = Tools.CreateInputBox(Me, "Month", 193, 40, 421, 459)
        month.ReadOnly = True
    End Sub
    Private Sub InputDay()
        day = Tools.CreateInputBox(Me, "Day", 128, 40, 671, 459)
        day.ReadOnly = True
    End Sub
    Private Sub InputYear()
        year = Tools.CreateInputBox(Me, "Year", 169, 40, 853, 459)
        year.ReadOnly = True
    End Sub
    Private Sub InputHomeNo()
        homeNo = Tools.CreateInputBox(Me, "Home Number", 276, 40, 421, 555)
        homeNo.ReadOnly = True
    End Sub
    Private Sub InputCellNo()
        cellNo = Tools.CreateInputBox(Me, "Phone Number", 268, 40, 754, 555)
        cellNo.ReadOnly = True
    End Sub
    Private Sub InputEmail()
        email = Tools.CreateInputBox(Me, "Email Address", 336, 40, 421, 655)
        email.ReadOnly = True
    End Sub
    Private Sub InputRelationshipToPatient()
        relationshipToPatient = Tools.CreateInputBox(Me, "Status", 215, 40, 808, 655)
        relationshipToPatient.ReadOnly = True
    End Sub
    Private Sub InputAddress()
        address = Tools.CreateInputBox(Me, "Address", 597, 110, 421, 750)
        address.ReadOnly = True
        address.Multiline = True
    End Sub
    Private Sub MonthDropDownButton()
        monthBoxPanel = Tools.CreatePanel(Me, 231, 312, 403, 504)
        Dim monthBoxInstance As New MonthBox("Insured View Details")
        monthBoxPanel.Controls.Add(monthBoxInstance)
        Dim dropDownBtn As New DropDown(monthBoxPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(591, 466)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Private Sub RelationshipToPatinetDropDownButton()
        relationshipToPatientPanel = Tools.CreatePanel(Me, 244, 176, 794, 700)
        Dim relationshipStatusToPatientInstance As New RelationshipToPatientBox("Insured View Details")
        relationshipToPatientPanel.Controls.Add(relationshipStatusToPatientInstance)
        Dim dropDownBtn As New DropDown(relationshipToPatientPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(993, 660)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Public Sub UpdateInsuredData()
        Dim zipCodeAsInteger = Handlers.ConvertTextToInteger(zipCode.Text)
        Dim cellNoAsInteger = Handlers.ConvertTextToInteger(cellNo.Text)
        Dim parsedInsuredNo = Handlers.ConvertTextToInteger(uniqueInusredNo)

        Dim query As String = $"update insureds set 
                                relationship_to_patient = @relationshiptopatient,
                                insured_name = @insuredname,
                                SSINo = @ssino,
                                birthdate = @birthdate,
                                home_phone_no = @homeno,
                                cell_phone_no = @cellno,
                                email = @email,
                                full_address = @address
                                where insured_no = {parsedInsuredNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(query)
                    Try
                        command.Parameters.AddWithValue("@relationshiptopatient", relationshipToPatient.Text)
                        command.Parameters.AddWithValue("@insured_name", Handlers.AutoCapitalizeFirstLetter(fullname.Text))
                        command.Parameters.AddWithValue("@ssino", ssiNumber.Text)
                        command.Parameters.AddWithValue("@birthdate", $"{month.Text} {day.Text}, {year.Text}")
                        command.Parameters.AddWithValue("@homeno", homeNo.Text)
                        command.Parameters.AddWithValue("@cellno", cellNoAsInteger)
                        command.Parameters.AddWithValue("@email", Handlers.AutoCapitalizeFirstLetter(email.Text))
                        command.Parameters.AddWithValue("@address", Handlers.AutoCapitalizeFirstLetter(address.Text))
                        command.ExecuteNonQuery()
                        AdminDashboard.UpdatedPatientPopUp()
                        AdminDashboard.LoadPatientData()
                        AdminDashboard.LoadGuardianData()
                        AdminDashboard.LoadInsuredData()
                        TextBoxReadMeOnly()
                        PatientViewDetails.Hide()
                        GuardianViewDetails.Hide()
                        AdminDashboard.UpdatedPatientPopUp()
                        Me.Hide()
                    Catch ex As Exception
                        MsgBox($"Failed to update insureds: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        CloseViewDetailsWindows()
    End Sub
    Public Sub DeletePatientData()
        Dim parsedInsuredNo = Handlers.ConvertTextToInteger(uniqueInusredNo)
        Dim zquery As String = $"delete from guardians where guardian_no = {parsedInsuredNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(zquery)
                    Try
                        command.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox($"Failed to delete guardians: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        Dim yquery As String = $"delete from insureds where insured_no = {parsedInsuredNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(yquery)
                    Try
                        command.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox($"Failed to delete insureds: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        Dim squery As String = $"delete from patients where patient_no = {parsedInsuredNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(squery)
                    Try
                        command.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox($"Failed to delete patients: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        AdminDashboard.LoadPatientData()
        AdminDashboard.LoadGuardianData()
        AdminDashboard.LoadInsuredData()
        TextBoxReadMeOnly()
        PatientViewDetails.Hide()
        GuardianViewDetails.Hide()
        AdminDashboard.DeletedPatientPopUp()
        Me.Hide()
    End Sub
    Public Sub DataFoundPopUp()
        dataFoundPopUpPanel = New Panel
        Dim popUp As New DataFoundPopUp
        Dim timer As New Timer()
        dataFoundPopUpPanel = Tools.CreatePanel(Me, 372, 83, 20, 20)
        dataFoundPopUpPanel.Controls.Add(popUp)
        dataFoundPopUpPanel.Visible = True
        dataFoundPopUpPanel.BringToFront()
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(dataFoundPopUpPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
End Class