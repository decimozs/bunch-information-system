Imports System.Net

Public Class GuardianViewDetails
    Public monthBoxPanel As New Panel
    Public relationshipToPatientPanel As New Panel
    Public uniqueGuardianNo As String
    Public guardianNo As New TextBox
    Public fullname As New TextBox
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
    Private Sub GuardianViewDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        NextButton()
        RelationshipToPatinetDropDownButton()
        MonthDropDownButton()
        NextButton()
        InputGuardianNo()
        InputGuardianName()
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
                                      PatientViewDetails.Hide()
                                      InsuredViewDetails.Hide()
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
    Private Sub SaveButton()
        Dim saveBtn = Tools.CreateButton(Me, 175, 67, 817, 895)
        AddHandler saveBtn.Click, Sub(sender As Object, e As EventArgs)
                                      UpdateGuardianData()
                                  End Sub
    End Sub
    Private Sub PreviousButton()
        Dim prevBtn = Tools.CreateButton(Me, 54, 97, 146, 411)
        AddHandler prevBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.OpenWindow(Me, PatientViewDetails)
                                  End Sub
    End Sub
    Private Sub NextButton()
        Dim nextBtn = Tools.CreateButton(Me, 54, 97, 1241, 411)
        AddHandler nextBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.OpenWindow(Me, InsuredViewDetails)
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
        day.ForeColor = Color.Gray
        month.ForeColor = Color.Gray
        relationshipToPatient.ForeColor = Color.Gray
        year.ForeColor = Color.Gray
        homeNo.ForeColor = Color.Gray
        cellNo.ForeColor = Color.Gray
        email.ForeColor = Color.Gray
        address.ForeColor = Color.Gray
        barangay.ForeColor = Color.Gray
        city.ForeColor = Color.Gray
        zipCode.ForeColor = Color.Gray
    End Sub
    Private Sub InputGuardianNo()
        guardianNo = Tools.CreateInputBox(Me, "", 225, 52, 608, 58)
        guardianNo.ForeColor = Color.Black
        guardianNo.ReadOnly = True
    End Sub
    Private Sub InputGuardianName()
        fullname = Tools.CreateInputBox(Me, "Guardian Name", 597, 40, 421, 285)
        fullname.ReadOnly = True
    End Sub
    Private Sub InputMonth()
        month = Tools.CreateInputBox(Me, "Month", 193, 40, 421, 383)
        month.ReadOnly = True
    End Sub
    Private Sub InputDay()
        day = Tools.CreateInputBox(Me, "Day", 128, 40, 671, 383)
        day.ReadOnly = True
    End Sub
    Private Sub InputYear()
        year = Tools.CreateInputBox(Me, "Year", 169, 40, 853, 383)
        year.ReadOnly = True
    End Sub
    Private Sub InputHomeNo()
        homeNo = Tools.CreateInputBox(Me, "Home Number", 276, 40, 421, 480)
        homeNo.ReadOnly = True
    End Sub
    Private Sub InputCellNo()
        cellNo = Tools.CreateInputBox(Me, "Phone Number", 268, 40, 754, 480)
        cellNo.ReadOnly = True
    End Sub
    Private Sub InputEmail()
        email = Tools.CreateInputBox(Me, "Email Address", 336, 40, 421, 579)
        email.ReadOnly = True
    End Sub
    Private Sub InputRelationshipToPatient()
        relationshipToPatient = Tools.CreateInputBox(Me, "Status", 215, 40, 808, 579)
        relationshipToPatient.ReadOnly = True
    End Sub
    Private Sub InputAddress()
        address = Tools.CreateInputBox(Me, "Address", 597, 110, 421, 674)
        address.ReadOnly = True
        address.Multiline = True
    End Sub
    Private Sub MonthDropDownButton()
        monthBoxPanel = Tools.CreatePanel(Me, 231, 312, 403, 430)
        Dim monthBoxInstance As New MonthBox("Guardian View Details")
        monthBoxPanel.Controls.Add(monthBoxInstance)
        Dim dropDownBtn As New DropDown(monthBoxPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(593, 391)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Private Sub RelationshipToPatinetDropDownButton()
        relationshipToPatientPanel = Tools.CreatePanel(Me, 244, 176, 794, 625)
        Dim relationshipStatusToPatientInstance As New RelationshipToPatientBox("Guardian View Details")
        relationshipToPatientPanel.Controls.Add(relationshipStatusToPatientInstance)
        Dim dropDownBtn As New DropDown(relationshipToPatientPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(992, 586)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Public Sub UpdateGuardianData()
        Dim zipCodeAsInteger = Handlers.ConvertTextToInteger(zipCode.Text)
        Dim cellNoAsInteger = Handlers.ConvertTextToInteger(cellNo.Text)
        Dim parsedGuardianNo = Handlers.ConvertTextToInteger(uniqueGuardianNo)

        Dim query As String = $"update guardians set 
                                relationship_to_patient = @relationshiptopatient,
                                guardian_name = @guardianname,
                                birthdate = @birthdate,
                                home_phone_no = @homeno,
                                cell_phone_no = @cellno,
                                email = @email,
                                full_address = @address
                                where guardian_no = {parsedGuardianNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(query)
                    Try
                        command.Parameters.AddWithValue("@relationshiptopatient", relationshipToPatient.Text)
                        command.Parameters.AddWithValue("@guardianname", Handlers.AutoCapitalizeFirstLetter(fullname.Text))
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
                        InsuredViewDetails.Hide()
                        Me.Hide()
                    Catch ex As Exception
                        MsgBox($"Failed to update guardians: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        CloseViewDetailsWindows()
    End Sub
    Public Sub DeletePatientData()
        Dim parsedPatientNo = Handlers.ConvertTextToInteger(uniqueGuardianNo)
        Dim zquery As String = $"delete from guardians where guardian_no = {parsedPatientNo}"
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

        Dim yquery As String = $"delete from insureds where insured_no = {parsedPatientNo}"
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

        Dim squery As String = $"delete from patients where patient_no = {parsedPatientNo}"
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
        InsuredViewDetails.Hide()
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