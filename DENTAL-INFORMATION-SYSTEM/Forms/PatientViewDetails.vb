Public Class PatientViewDetails
    Public monthBoxPanel As New Panel
    Public maritalStatusPanel As New Panel
    Public uniquePatientNo As String
    Public patientNo As New TextBox
    Public firstName As New TextBox
    Public lastname As New TextBox
    Public middleInitial As New TextBox
    Public month As New TextBox
    Public day As New TextBox
    Public year As New TextBox
    Public homeNo As New TextBox
    Public cellNo As New TextBox
    Public email As New TextBox
    Public maritalStatus As New TextBox
    Public streetAddress As New TextBox
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
    Private Sub PatientViewDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        SaveButton()
        BackButton()
        DeleteButton()
        EditButton()
        NextButton()
        MaritalStatusDropDownButton()
        MonthDropDownButton()
        NextButton()
        InputPatientNo()
        InputFirstName()
        InputLastName()
        InputMiddleInitial()
        InputMonth()
        InputDay()
        InputYear()
        InputHomeNo()
        InputCellNo()
        InputEmail()
        InputMaritalStatus()
        InputStreetAddress()
        InputBarangay()
        InputCity()
        InputZipCode()
        BackButton()
    End Sub

    Private Sub BackButton()
        Dim backBtn = Tools.CreateButton(Me, 55, 26, 1345, 46)
        AddHandler backBtn.Click, Sub(sender As Object, e As EventArgs)
                                      TextBoxReadMeOnly()
                                      Me.Hide()
                                      GuardianViewDetails.Hide()
                                      InsuredViewDetails.Hide()
                                  End Sub
    End Sub
    Private Sub DeleteButton()
        Dim deleteBtn = Tools.CreateButton(Me, 175, 67, 449, 895)
        AddHandler deleteBtn.Click, Sub(sender As Object, e As EventArgs)
                                        DeletePatientData()
                                        TextBoxReadMeOnly()
                                        Me.Hide()
                                        GuardianViewDetails.Hide()
                                        InsuredViewDetails.Hide()
                                        AdminDashboard.DeletedPatientPopUp()
                                    End Sub
    End Sub
    Private Sub EditButton()
        Dim editBtn = Tools.CreateButton(Me, 175, 67, 633, 895)
        AddHandler editBtn.Click, Sub(sender As Object, e As EventArgs)
                                      firstName.ReadOnly = False
                                      lastname.ReadOnly = False
                                      middleInitial.ReadOnly = False
                                      day.ReadOnly = False
                                      year.ReadOnly = False
                                      homeNo.ReadOnly = False
                                      cellNo.ReadOnly = False
                                      email.ReadOnly = False
                                      streetAddress.ReadOnly = False
                                      barangay.ReadOnly = False
                                      city.ReadOnly = False
                                      zipCode.ReadOnly = False
                                      Handlers.SetEditStatus()
                                  End Sub
    End Sub
    Private Sub SaveButton()
        Dim saveBtn = Tools.CreateButton(Me, 175, 67, 817, 895)
        AddHandler saveBtn.Click, Sub(sender As Object, e As EventArgs)
                                      UpdatePatientData()
                                  End Sub
    End Sub
    Private Sub NextButton()
        Dim nextBtn = Tools.CreateButton(Me, 54, 97, 1241, 411)
        AddHandler nextBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.OpenWindow(Me, GuardianViewDetails)
                                  End Sub
    End Sub
    Private Sub TextBoxReadMeOnly()
        firstName.ReadOnly = True
        lastname.ReadOnly = True
        middleInitial.ReadOnly = True
        day.ReadOnly = True
        year.ReadOnly = True
        homeNo.ReadOnly = True
        cellNo.ReadOnly = True
        email.ReadOnly = True
        streetAddress.ReadOnly = True
        barangay.ReadOnly = True
        city.ReadOnly = True
        zipCode.ReadOnly = True

        firstName.ForeColor = Color.Gray
        lastname.ForeColor = Color.Gray
        middleInitial.ForeColor = Color.Gray
        month.ForeColor = Color.Gray
        day.ForeColor = Color.Gray
        year.ForeColor = Color.Gray
        maritalStatus.ForeColor = Color.Gray
        homeNo.ForeColor = Color.Gray
        cellNo.ForeColor = Color.Gray
        email.ForeColor = Color.Gray
        streetAddress.ForeColor = Color.Gray
        barangay.ForeColor = Color.Gray
        city.ForeColor = Color.Gray
        zipCode.ForeColor = Color.Gray
    End Sub
    Public Sub InputPatientNo()
        patientNo = Tools.CreateInputBox(Me, "", 225, 52, 608, 58)
        patientNo.ForeColor = Color.Black
        patientNo.ReadOnly = True
    End Sub
    Private Sub InputFirstName()
        firstName = Tools.CreateInputBox(Me, "First name", 195, 40, 421, 285)
        firstName.ReadOnly = True
    End Sub
    Private Sub InputLastName()
        lastname = Tools.CreateInputBox(Me, "Last name", 195, 40, 670, 285)
        lastname.ReadOnly = True
    End Sub
    Private Sub InputMiddleInitial()
        middleInitial = Tools.CreateInputBox(Me, "M.I", 103, 40, 919, 285)
        middleInitial.ReadOnly = True
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
    Private Sub InputMaritalStatus()
        maritalStatus = Tools.CreateInputBox(Me, "Status", 215, 40, 808, 579)
        maritalStatus.ReadOnly = True
    End Sub
    Private Sub InputStreetAddress()
        streetAddress = Tools.CreateInputBox(Me, "Street Address", 597, 40, 421, 676)
        streetAddress.ReadOnly = True
    End Sub
    Private Sub InputBarangay()
        barangay = Tools.CreateInputBox(Me, "Barangay", 207, 40, 421, 743)
        barangay.ReadOnly = True
    End Sub
    Private Sub InputCity()
        city = Tools.CreateInputBox(Me, "City", 127, 40, 681, 743)
        city.ReadOnly = True
    End Sub
    Private Sub InputZipCode()
        zipCode = Tools.CreateInputBox(Me, "Zip Code", 160, 40, 858, 743)
        zipCode.ReadOnly = True
    End Sub
    Private Sub MonthDropDownButton()
        monthBoxPanel = Tools.CreatePanel(Me, 231, 312, 403, 430)
        Dim monthBoxInstance As New MonthBox("Patient View Details")
        monthBoxPanel.Controls.Add(monthBoxInstance)
        Dim dropDownBtn As New DropDown(monthBoxPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(593, 391)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Private Sub MaritalStatusDropDownButton()
        maritalStatusPanel = Tools.CreatePanel(Me, 244, 149, 794, 625)
        Dim maritalStatusInstance As New MaritalStatusBox("Patient View Details")
        maritalStatusPanel.Controls.Add(maritalStatusInstance)
        Dim dropDownBtn As New DropDown(maritalStatusPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(992, 586)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Public Sub UpdatePatientData()
        Dim zipCodeAsInteger = Handlers.ConvertTextToInteger(zipCode.Text)
        Dim cellNoAsInteger = Handlers.ConvertTextToInteger(cellNo.Text)
        Dim parsedPatientNo = Handlers.ConvertTextToInteger(uniquePatientNo)

        Dim query As String = $"update patients set 
                                date = @date,
                                first_name = @firstname,
                                last_name = @lastname,
                                middle_initial = @middleinitial,
                                birthdate = @birthdate,
                                marital_status = @maritalstatus,
                                home_phone_no = @homeno,
                                cell_phone_no = @cellno,
                                email = @email,
                                street_address = @streetaddress,
                                barangay = @barangay,
                                city = @city,
                                zip_code = @zipcode
                                where patient_no = {parsedPatientNo}"
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(query)
                    Try
                        command.Parameters.AddWithValue("@date", dateNow)
                        command.Parameters.AddWithValue("@firstname", Handlers.AutoCapitalizeFirstLetter(firstName.Text))
                        command.Parameters.AddWithValue("@lastname", Handlers.AutoCapitalizeFirstLetter(lastname.Text))
                        command.Parameters.AddWithValue("@middleinitial", Handlers.AutoCapitalizeFirstLetter(middleInitial.Text))
                        command.Parameters.AddWithValue("@birthdate", $"{month.Text} {day.Text}, {year.Text}")
                        command.Parameters.AddWithValue("@maritalstatus", maritalStatus.Text)
                        command.Parameters.AddWithValue("@homeno", homeNo.Text)
                        command.Parameters.AddWithValue("@cellno", cellNoAsInteger)
                        command.Parameters.AddWithValue("@email", email.Text)
                        command.Parameters.AddWithValue("@streetaddress", Handlers.AutoCapitalizeFirstLetter(streetAddress.Text))
                        command.Parameters.AddWithValue("@barangay", Handlers.AutoCapitalizeFirstLetter(barangay.Text))
                        command.Parameters.AddWithValue("@city", Handlers.AutoCapitalizeFirstLetter(city.Text))
                        command.Parameters.AddWithValue("@zipcode", zipCodeAsInteger)
                        command.ExecuteNonQuery()
                        AdminDashboard.UpdatedPatientPopUp()
                        AdminDashboard.LoadPatientData()
                        AdminDashboard.LoadGuardianData()
                        AdminDashboard.LoadInsuredData()
                        TextBoxReadMeOnly()
                        GuardianViewDetails.Hide()
                        InsuredViewDetails.Hide()
                        Me.Hide()
                    Catch ex As Exception
                        MsgBox($"Failed to update patients: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try

        CloseViewDetailsWindows()
    End Sub
    Public Sub DeletePatientData()
        Dim parsedPatientNo = Handlers.ConvertTextToInteger(uniquePatientNo)
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
        GuardianViewDetails.Hide()
        InsuredViewDetails.Hide()
        Me.Hide()
    End Sub
    Public Sub PopUp()
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