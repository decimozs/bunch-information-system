Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class AdminDashboard
    Dim popUpPanel As New Panel
    Dim testConnectionPopUpPanel As New Panel
    Dim deletedPopUpPanel As New Panel
    Dim updatedPopUpPanel As New Panel
    Public dataNotFoundPanel As New Panel
    Public searchFilterPanel As New Panel
    Public patientSearch As New TextBox
    Public guardianSearch As New TextBox
    Public insuredSearch As New TextBox
    Public patientDataButton As New Panel
    Public guardianDataButton As New Panel
    Public insuredDataButton As New Panel
    Public filterPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        SearchFilterDropDown()
        InputSearchPatient()
        InputSearchGuardian()
        InputSearchInsured()
        TestConnectionButton()
        PatientDataButtonLbl()
        GuardianDataButtonLbl()
        InsuredDataButtonLbl()
        AddPatientButton()
        LogoutButton()
        CloseButton()
        MinimzedButton()
        PopUp()
        LoadPatientData()
        LoadGuardianData()
        LoadInsuredData()
        FilterButton()
    End Sub
    Private Sub CloseButton()
        Dim closeBtn = Tools.CreateButton(Me, 51, 53, 1350, 23)
        AddHandler closeBtn.Click, Sub(sender As Object, e As EventArgs)
                                       Handlers.CloseWindow(Me)
                                   End Sub
    End Sub
    Private Sub MinimzedButton()
        Dim minimizedBtn = Tools.CreateButton(Me, 48, 53, 1291, 22)
        AddHandler minimizedBtn.Click, Sub(sender As Object, e As EventArgs)
                                           Handlers.MinimizedWindow(Me)
                                       End Sub
    End Sub
    Private Sub AddPatientButton()
        Dim addPatientBtn = Tools.CreateButton(Me, 178, 67, 72, 915)
        AddHandler addPatientBtn.Click, Sub(sender As Object, e As EventArgs)
                                            Handlers.OpenWindow(Me, ServiceOfferedForm)
                                        End Sub
    End Sub
    Private Sub LogoutButton()
        Dim logutBtn = Tools.CreateButton(Me, 178, 67, 1189, 915)
        AddHandler logutBtn.Click, Sub(sender As Object, e As EventArgs)
                                       Handlers.OpenWindow(Me, AdminLoginForm)
                                   End Sub
    End Sub
    Private Sub TestConnectionButton()
        Dim testConnectionBtn = Tools.CreateButton(Me, 230, 67, 921, 915)
        AddHandler testConnectionBtn.Click, Sub(sender As Object, e As EventArgs)
                                                TestConnectionPopUp()
                                            End Sub
    End Sub
    Private Sub InputSearchPatient()
        patientSearch = Tools.CreateInputBox(Me, "Enter patient number", 290, 52, 1000, 164)
        AddHandler patientSearch.KeyDown, AddressOf PatientSearchTextBox_KeyDown
    End Sub
    Private Sub InputSearchGuardian()
        guardianSearch = Tools.CreateInputBox(Me, "Enter guardian number", 290, 52, 1000, 164)
        guardianSearch.Visible = False
        AddHandler guardianSearch.KeyDown, AddressOf GuardianTextBox_KeyDown
    End Sub
    Private Sub InputSearchInsured()
        insuredSearch = Tools.CreateInputBox(Me, "Enter insured number", 290, 52, 1000, 164)
        insuredSearch.Visible = False
        AddHandler insuredSearch.KeyDown, AddressOf InsuredTextBox_KeyDown
    End Sub
    Private Sub SearchFilterDropDown()
        searchFilterPanel = Tools.CreatePanel(Me, 218, 138, 1149, 211)
        searchFilterPanel.BringToFront()
        Dim searchFilterInstance As New SearchFilterBox
        searchFilterPanel.Controls.Add(searchFilterInstance)
        Dim searchBtn As New DropDown(searchFilterPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(20, 7),
            .Location = New Point(1060, 115)
        }
        Me.Controls.Add(searchBtn)
    End Sub
    Private Sub PatientSearchTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then
            Return
        Else
            Dim patientNo As String = patientSearch.Text
            SearchInsured(patientNo)
            SearchGuardian(patientNo)
            SearchPatient(patientNo)
        End If
    End Sub
    Private Sub GuardianTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then
            Return
        Else
            Dim patientNo As String = guardianSearch.Text
            SearchInsured(patientNo)
            SearchPatient(patientNo)
            SearchGuardian(patientNo)
        End If
    End Sub
    Private Sub InsuredTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then
            Return
        Else
            Dim patientNo As String = insuredSearch.Text
            SearchGuardian(patientNo)
            SearchPatient(patientNo)
            SearchInsured(patientNo)
        End If
    End Sub
    Private Sub SearchPatient(patientno As String)
        Dim convertedPatientNo As Integer = Handlers.ConvertTextToInteger(patientno)

        For Each row As DataGridViewRow In patientTable.Rows
            If row.Cells("patientno").Value IsNot Nothing AndAlso row.Cells("patientno").Value.ToString() = convertedPatientNo.ToString() Then
                PatientViewDetails.uniquePatientNo = row.Cells("patientno").Value
                PatientViewDetails.patientNo.Text = $"Patient No. {row.Cells("patientno").Value}"
                PatientViewDetails.firstName.Text = row.Cells("firstname").Value
                PatientViewDetails.lastname.Text = row.Cells("lastname").Value
                PatientViewDetails.middleInitial.Text = row.Cells("middleinitial").Value
                Dim birthdate As String = row.Cells("birthdate").Value.ToString
                If Handlers.ContainsMonth(birthdate) Then
                    Dim parsedDate As Date
                    If Date.TryParse(birthdate, parsedDate) Then
                        PatientViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                        PatientViewDetails.day.Text = parsedDate.Day.ToString()
                        PatientViewDetails.year.Text = parsedDate.Year.ToString()
                    Else
                        MessageBox.Show("Invalid birthdate format.")
                    End If
                End If
                PatientViewDetails.homeNo.Text = row.Cells("homeno").Value
                PatientViewDetails.cellNo.Text = row.Cells("cellno").Value
                PatientViewDetails.email.Text = row.Cells("email").Value
                PatientViewDetails.maritalStatus.Text = row.Cells("maritalstatus").Value
                PatientViewDetails.streetAddress.Text = row.Cells("streetaddress").Value
                PatientViewDetails.barangay.Text = row.Cells("barangay").Value
                PatientViewDetails.city.Text = row.Cells("city").Value
                PatientViewDetails.zipCode.Text = row.Cells("zipcode").Value
                PatientViewDetails.Show()
                PatientViewDetails.PopUp()
                Return
            End If
        Next
        DataNotFoundPopUp()
    End Sub
    Private Sub SearchGuardian(patientno As String)
        Dim convertedPatientNo As Integer = Handlers.ConvertTextToInteger(patientno)
        For Each row As DataGridViewRow In guardianTable.Rows
            If row.Cells("guardianno").Value IsNot Nothing AndAlso row.Cells("guardianno").Value.ToString() = convertedPatientNo.ToString() Then
                GuardianViewDetails.uniqueGuardianNo = row.Cells("guardianno").Value
                GuardianViewDetails.guardianNo.Text = $"Guardian No. {row.Cells("guardianno").Value}"
                GuardianViewDetails.relationshipToPatient.Text = row.Cells("relationshiptopatient").Value
                GuardianViewDetails.fullname.Text = row.Cells("guardianname").Value
                Dim guardianBirthdate As String = row.Cells("guardianbirthdate").Value.ToString
                If Handlers.ContainsMonth(guardianBirthdate) Then
                    Dim parsedDate As Date
                    If Date.TryParse(guardianBirthdate, parsedDate) Then
                        GuardianViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                        GuardianViewDetails.day.Text = parsedDate.Day.ToString()
                        GuardianViewDetails.year.Text = parsedDate.Year.ToString()
                    Else
                        MessageBox.Show("Invalid birthdate format.")
                    End If
                End If
                GuardianViewDetails.homeNo.Text = row.Cells("guardianhomeno").Value
                GuardianViewDetails.cellNo.Text = row.Cells("guardiancellno").Value
                GuardianViewDetails.email.Text = row.Cells("guardianemail").Value
                GuardianViewDetails.address.Text = row.Cells("guardianaddress").Value
                GuardianViewDetails.Show()
                GuardianViewDetails.DataFoundPopUp()
                Return
            End If
        Next
        DataNotFoundPopUp()
    End Sub
    Private Sub SearchInsured(patientno As String)
        Dim convertedPatientNo As Integer = Handlers.ConvertTextToInteger(patientno)

        For Each row As DataGridViewRow In insuredTable.Rows
            If row.Cells("insuredno").Value IsNot Nothing AndAlso row.Cells("insuredno").Value.ToString() = convertedPatientNo.ToString() Then
                InsuredViewDetails.uniqueInusredNo = row.Cells("insuredno").Value
                InsuredViewDetails.insuredNo.Text = $"Insured No. {row.Cells("insuredno").Value}"
                InsuredViewDetails.relationshipToPatient.Text = row.Cells("relationshiptopatientins").Value
                InsuredViewDetails.fullname.Text = row.Cells("nameins").Value
                InsuredViewDetails.ssiNumber.Text = row.Cells("ssino").Value
                Dim insuredBirthdate As String = row.Cells("birthdateins").Value.ToString
                If Handlers.ContainsMonth(insuredBirthdate) Then
                    Dim parsedDate As Date
                    If Date.TryParse(insuredBirthdate, parsedDate) Then
                        InsuredViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                        InsuredViewDetails.day.Text = parsedDate.Day.ToString()
                        InsuredViewDetails.year.Text = parsedDate.Year.ToString()
                    Else
                        MessageBox.Show("Invalid birthdate format.")
                    End If
                End If
                InsuredViewDetails.homeNo.Text = row.Cells("homenoins").Value
                InsuredViewDetails.cellNo.Text = row.Cells("cellnoins").Value
                InsuredViewDetails.email.Text = row.Cells("emailins").Value
                InsuredViewDetails.address.Text = row.Cells("addressins").Value
                InsuredViewDetails.Show()
                InsuredViewDetails.DataFoundPopUp()
                Return
            End If
        Next
        DataNotFoundPopUp()
    End Sub
    Private Sub PopUp()
        popUpPanel = New Panel
        Dim popUp As New WelcomeAdminPopUp
        Dim timer As New Timer()
        popUpPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        popUpPanel.Controls.Add(popUp)
        popUpPanel.Visible = True
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(popUpPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
    Private Sub TestConnectionPopUp()
        testConnectionPopUpPanel = New Panel
        Dim popUp As New ConnectedToTheDatabasePopUp
        Dim timer As New Timer()
        testConnectionPopUpPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        testConnectionPopUpPanel.Controls.Add(popUp)
        testConnectionPopUpPanel.Visible = True
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(testConnectionPopUpPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
    Public Sub DeletedPatientPopUp()
        dataNotFoundPanel.Visible = False
        deletedPopUpPanel = New Panel
        Dim popUp As New DataDeletedPopUp
        Dim timer As New Timer()
        deletedPopUpPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        deletedPopUpPanel.Controls.Add(popUp)
        deletedPopUpPanel.Visible = True
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(deletedPopUpPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
    Public Sub UpdatedPatientPopUp()
        dataNotFoundPanel.Visible = False
        updatedPopUpPanel = New Panel
        Dim popUp As New DataUpdatedPopUp
        Dim timer As New Timer()
        updatedPopUpPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        updatedPopUpPanel.Controls.Add(popUp)
        updatedPopUpPanel.Visible = True
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(updatedPopUpPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
    Public Sub DataNotFoundPopUp()
        dataNotFoundPanel = New Panel
        Dim popUp As New DataNotFoundPopUp
        Dim timer As New Timer()
        dataNotFoundPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        dataNotFoundPanel.Controls.Add(popUp)
        dataNotFoundPanel.Visible = True
        timer.Interval = 5000
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Handlers.TimerTick(dataNotFoundPanel, sender, e)
                               End Sub

        timer.Start()
    End Sub
    Private Sub PatientDataButtonLbl()
        patientDataButton = Tools.CreatePanel(Me, 186, 44, 72, 177)
        patientDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\PatientButtonC.png")
        patientDataButton.Visible = True
        AddHandler patientDataButton.Click, Sub(sender As Object, e As EventArgs)
                                                patientTable.Visible = True
                                                guardianTable.Visible = False
                                                insuredTable.Visible = False
                                                filterTable.Visible = False
                                                patientDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\PatientButtonC.png")
                                                insuredDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\InsuredButtonUC.png")
                                                guardianDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\GuardianButtonUC.png")
                                            End Sub
    End Sub

    Private Sub GuardianDataButtonLbl()
        guardianDataButton = Tools.CreatePanel(Me, 207, 44, 258, 177)
        guardianDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\GuardianButtonUC.png")
        guardianDataButton.Visible = True
        AddHandler guardianDataButton.Click, Sub(sender As Object, e As EventArgs)
                                                 guardianTable.Visible = True
                                                 patientTable.Visible = False
                                                 insuredTable.Visible = False
                                                 filterTable.Visible = False
                                                 guardianDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\GuardianButtonC.png")
                                                 insuredDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\InsuredButtonUC.png")
                                                 patientDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\PatientButtonUC.png")
                                             End Sub
    End Sub

    Private Sub InsuredDataButtonLbl()
        insuredDataButton = Tools.CreatePanel(Me, 185, 44, 465, 177)
        insuredDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\InsuredButtonUC.png")
        insuredDataButton.Visible = True
        AddHandler insuredDataButton.Click, Sub(sender As Object, e As EventArgs)
                                                insuredTable.Visible = True
                                                guardianTable.Visible = False
                                                patientTable.Visible = False
                                                filterTable.Visible = False
                                                insuredDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\InsuredButtonC.png")
                                                patientDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\PatientButtonUC.png")
                                                guardianDataButton.BackgroundImage = Image.FromFile("C:\Users\acer\Documents\get yo ass up\get yo ass up on vb\DENTAL-INFORMATION-SYSTEM\DENTAL-INFORMATION-SYSTEM\Images\GuardianButtonUC.png")
                                            End Sub
    End Sub
    Public Sub LoadPatientData()
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Dim query As String = "SELECT patient_no, date, first_name, middle_initial, last_name, birthdate, marital_status, home_phone_no, cell_phone_no, email, street_address, barangay, city, zip_code from patients"
                Using command = Database.GetCommand(query)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        patientTable.Rows.Clear()

                        While reader.Read()
                            Dim patientno As String = reader("patient_no").ToString
                            Dim dateCreated As String = reader("date").ToString
                            Dim firstname As String = reader("first_name").ToString
                            Dim middleinitial As String = reader("middle_initial").ToString
                            Dim lastname As String = reader("last_name").ToString
                            Dim birthdate As String = reader("birthdate").ToString
                            Dim maritalstatus As String = reader("marital_status").ToString
                            Dim homeno As String = reader("home_phone_no").ToString
                            Dim cellno As String = reader("cell_phone_no").ToString
                            Dim email As String = reader("email").ToString
                            Dim streetaddress As String = reader("street_address").ToString
                            Dim barangay As String = reader("barangay").ToString
                            Dim city As String = reader("city").ToString
                            Dim zipcode As String = reader("zip_code").ToString

                            patientTable.Rows.Add(patientno, dateCreated, firstname, middleinitial, lastname, birthdate, maritalstatus, homeno, cellno, email, streetaddress, barangay, city, zipcode)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
        AddHandler patientTable.CellClick, AddressOf ViewPatientData
    End Sub
    Public Sub LoadGuardianData()
        guardianTable.Visible = False
        filterTable.Visible = False
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Dim query As String = "SELECT guardian_no, relationship_to_patient, guardian_name, birthdate, home_phone_no, cell_phone_no, email, full_address from guardians"
                Using command = Database.GetCommand(query)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        guardianTable.Rows.Clear()

                        While reader.Read()
                            Dim guardianno As String = reader("guardian_no").ToString
                            Dim relationshiptopatient As String = reader("relationship_to_patient").ToString
                            Dim name As String = reader("guardian_name").ToString
                            Dim birthdate As String = reader("birthdate").ToString
                            Dim homeno As String = reader("home_phone_no").ToString
                            Dim cellno As String = reader("cell_phone_no").ToString
                            Dim email As String = reader("email").ToString
                            Dim address As String = reader("full_address").ToString
                            guardianTable.Rows.Add(guardianno, relationshiptopatient, name, birthdate, homeno, cellno, email, address)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
        AddHandler guardianTable.CellClick, AddressOf ViewGuardianData
    End Sub
    Public Sub LoadInsuredData()
        insuredTable.Visible = False
        filterTable.Visible = False
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Dim query As String = "SELECT insured_no, relationship_to_patient, insured_name, SSINo, birthdate, home_phone_no, cell_phone_no, email, full_address from insureds"
                Using command = Database.GetCommand(query)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        insuredTable.Rows.Clear()

                        While reader.Read()
                            Dim insuredno As String = reader("insured_no").ToString
                            Dim relationshiptopatient As String = reader("relationship_to_patient").ToString
                            Dim name As String = reader("insured_name").ToString
                            Dim ssino As String = reader("SSINo").ToString
                            Dim birthdate As String = reader("birthdate").ToString
                            Dim homeno As String = reader("home_phone_no").ToString
                            Dim cellno As String = reader("cell_phone_no").ToString
                            Dim email As String = reader("email").ToString
                            Dim address As String = reader("full_address").ToString
                            insuredTable.Rows.Add(insuredno, relationshiptopatient, name, ssino, birthdate, homeno, cellno, email, address)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
        AddHandler insuredTable.CellClick, AddressOf ViewInsuredData
    End Sub
    Private Sub ViewPatientData(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' fetch patient info
            PatientViewDetails.uniquePatientNo = patientTable.Rows(e.RowIndex).Cells("patientno").Value
            PatientViewDetails.patientNo.Text = $"Patient No. {patientTable.Rows(e.RowIndex).Cells("patientno").Value}"
            PatientViewDetails.firstName.Text = patientTable.Rows(e.RowIndex).Cells("firstname").Value
            PatientViewDetails.lastname.Text = patientTable.Rows(e.RowIndex).Cells("lastname").Value
            PatientViewDetails.middleInitial.Text = patientTable.Rows(e.RowIndex).Cells("middleinitial").Value
            Dim birthdate As String = patientTable.Rows(e.RowIndex).Cells("birthdate").Value.ToString
            If Handlers.ContainsMonth(birthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    PatientViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    PatientViewDetails.day.Text = parsedDate.Day.ToString()
                    PatientViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            PatientViewDetails.homeNo.Text = patientTable.Rows(e.RowIndex).Cells("homeno").Value
            PatientViewDetails.cellNo.Text = patientTable.Rows(e.RowIndex).Cells("cellno").Value
            PatientViewDetails.email.Text = patientTable.Rows(e.RowIndex).Cells("email").Value
            PatientViewDetails.maritalStatus.Text = patientTable.Rows(e.RowIndex).Cells("maritalstatus").Value
            PatientViewDetails.streetAddress.Text = patientTable.Rows(e.RowIndex).Cells("streetaddress").Value
            PatientViewDetails.barangay.Text = patientTable.Rows(e.RowIndex).Cells("barangay").Value
            PatientViewDetails.city.Text = patientTable.Rows(e.RowIndex).Cells("city").Value
            PatientViewDetails.zipCode.Text = patientTable.Rows(e.RowIndex).Cells("zipcode").Value

            'fetch guardian info
            GuardianViewDetails.uniqueGuardianNo = guardianTable.Rows(e.RowIndex).Cells("guardianno").Value
            GuardianViewDetails.guardianNo.Text = $"Guardian No. {guardianTable.Rows(e.RowIndex).Cells("guardianno").Value}"
            GuardianViewDetails.relationshipToPatient.Text = guardianTable.Rows(e.RowIndex).Cells("relationshiptopatient").Value
            GuardianViewDetails.fullname.Text = guardianTable.Rows(e.RowIndex).Cells("guardianname").Value
            Dim guardianBirthdate As String = guardianTable.Rows(e.RowIndex).Cells("guardianbirthdate").Value.ToString
            If Handlers.ContainsMonth(guardianBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    GuardianViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    GuardianViewDetails.day.Text = parsedDate.Day.ToString()
                    GuardianViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            GuardianViewDetails.homeNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardianhomeno").Value
            GuardianViewDetails.cellNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardiancellno").Value
            GuardianViewDetails.email.Text = guardianTable.Rows(e.RowIndex).Cells("guardianemail").Value
            GuardianViewDetails.address.Text = guardianTable.Rows(e.RowIndex).Cells("guardianaddress").Value

            'fetch insured info
            InsuredViewDetails.uniqueInusredNo = insuredTable.Rows(e.RowIndex).Cells("insuredno").Value
            InsuredViewDetails.insuredNo.Text = $"Insured No. {insuredTable.Rows(e.RowIndex).Cells("insuredno").Value}"
            InsuredViewDetails.relationshipToPatient.Text = insuredTable.Rows(e.RowIndex).Cells("relationshiptopatientins").Value
            InsuredViewDetails.fullname.Text = insuredTable.Rows(e.RowIndex).Cells("nameins").Value
            InsuredViewDetails.ssiNumber.Text = insuredTable.Rows(e.RowIndex).Cells("ssino").Value
            Dim insuredBirthdate As String = insuredTable.Rows(e.RowIndex).Cells("birthdateins").Value.ToString
            If Handlers.ContainsMonth(insuredBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    InsuredViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    InsuredViewDetails.day.Text = parsedDate.Day.ToString()
                    InsuredViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            InsuredViewDetails.homeNo.Text = insuredTable.Rows(e.RowIndex).Cells("homenoins").Value
            InsuredViewDetails.cellNo.Text = insuredTable.Rows(e.RowIndex).Cells("cellnoins").Value
            InsuredViewDetails.email.Text = insuredTable.Rows(e.RowIndex).Cells("emailins").Value
            InsuredViewDetails.address.Text = insuredTable.Rows(e.RowIndex).Cells("addressins").Value

            PatientViewDetails.Show()
        End If
    End Sub

    Private Sub ViewGuardianData(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' fetch patient info
            PatientViewDetails.uniquePatientNo = patientTable.Rows(e.RowIndex).Cells("patientno").Value
            PatientViewDetails.firstName.Text = patientTable.Rows(e.RowIndex).Cells("firstname").Value
            PatientViewDetails.lastname.Text = patientTable.Rows(e.RowIndex).Cells("lastname").Value
            PatientViewDetails.middleInitial.Text = patientTable.Rows(e.RowIndex).Cells("middleinitial").Value
            Dim birthdate As String = patientTable.Rows(e.RowIndex).Cells("birthdate").Value.ToString
            If Handlers.ContainsMonth(birthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    PatientViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    PatientViewDetails.day.Text = parsedDate.Day.ToString()
                    PatientViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            PatientViewDetails.homeNo.Text = patientTable.Rows(e.RowIndex).Cells("homeno").Value
            PatientViewDetails.cellNo.Text = patientTable.Rows(e.RowIndex).Cells("cellno").Value
            PatientViewDetails.email.Text = patientTable.Rows(e.RowIndex).Cells("email").Value
            PatientViewDetails.maritalStatus.Text = patientTable.Rows(e.RowIndex).Cells("maritalstatus").Value
            PatientViewDetails.streetAddress.Text = patientTable.Rows(e.RowIndex).Cells("streetaddress").Value
            PatientViewDetails.barangay.Text = patientTable.Rows(e.RowIndex).Cells("barangay").Value
            PatientViewDetails.city.Text = patientTable.Rows(e.RowIndex).Cells("city").Value
            PatientViewDetails.zipCode.Text = patientTable.Rows(e.RowIndex).Cells("zipcode").Value

            'fetch guardian info
            GuardianViewDetails.uniqueGuardianNo = guardianTable.Rows(e.RowIndex).Cells("guardianno").Value
            GuardianViewDetails.relationshipToPatient.Text = guardianTable.Rows(e.RowIndex).Cells("relationshiptopatient").Value
            GuardianViewDetails.fullname.Text = guardianTable.Rows(e.RowIndex).Cells("guardianname").Value
            Dim guardianBirthdate As String = guardianTable.Rows(e.RowIndex).Cells("guardianbirthdate").Value.ToString
            If Handlers.ContainsMonth(guardianBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    GuardianViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    GuardianViewDetails.day.Text = parsedDate.Day.ToString()
                    GuardianViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            GuardianViewDetails.homeNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardianhomeno").Value
            GuardianViewDetails.cellNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardiancellno").Value
            GuardianViewDetails.email.Text = guardianTable.Rows(e.RowIndex).Cells("guardianemail").Value
            GuardianViewDetails.address.Text = guardianTable.Rows(e.RowIndex).Cells("guardianaddress").Value

            'fetch insured info
            InsuredViewDetails.uniqueInusredNo = insuredTable.Rows(e.RowIndex).Cells("insuredno").Value
            InsuredViewDetails.relationshipToPatient.Text = insuredTable.Rows(e.RowIndex).Cells("relationshiptopatientins").Value
            InsuredViewDetails.fullname.Text = insuredTable.Rows(e.RowIndex).Cells("nameins").Value
            InsuredViewDetails.ssiNumber.Text = insuredTable.Rows(e.RowIndex).Cells("ssino").Value
            Dim insuredBirthdate As String = insuredTable.Rows(e.RowIndex).Cells("birthdateins").Value.ToString
            If Handlers.ContainsMonth(insuredBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    InsuredViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    InsuredViewDetails.day.Text = parsedDate.Day.ToString()
                    InsuredViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            InsuredViewDetails.homeNo.Text = insuredTable.Rows(e.RowIndex).Cells("homenoins").Value
            InsuredViewDetails.cellNo.Text = insuredTable.Rows(e.RowIndex).Cells("cellnoins").Value
            InsuredViewDetails.email.Text = insuredTable.Rows(e.RowIndex).Cells("emailins").Value
            InsuredViewDetails.address.Text = insuredTable.Rows(e.RowIndex).Cells("addressins").Value

            GuardianViewDetails.Show()
        End If
    End Sub

    Private Sub ViewInsuredData(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' fetch patient info
            PatientViewDetails.uniquePatientNo = patientTable.Rows(e.RowIndex).Cells("patientno").Value
            PatientViewDetails.firstName.Text = patientTable.Rows(e.RowIndex).Cells("firstname").Value
            PatientViewDetails.lastname.Text = patientTable.Rows(e.RowIndex).Cells("lastname").Value
            PatientViewDetails.middleInitial.Text = patientTable.Rows(e.RowIndex).Cells("middleinitial").Value
            Dim birthdate As String = patientTable.Rows(e.RowIndex).Cells("birthdate").Value.ToString
            If Handlers.ContainsMonth(birthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    PatientViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    PatientViewDetails.day.Text = parsedDate.Day.ToString()
                    PatientViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            PatientViewDetails.homeNo.Text = patientTable.Rows(e.RowIndex).Cells("homeno").Value
            PatientViewDetails.cellNo.Text = patientTable.Rows(e.RowIndex).Cells("cellno").Value
            PatientViewDetails.email.Text = patientTable.Rows(e.RowIndex).Cells("email").Value
            PatientViewDetails.maritalStatus.Text = patientTable.Rows(e.RowIndex).Cells("maritalstatus").Value
            PatientViewDetails.streetAddress.Text = patientTable.Rows(e.RowIndex).Cells("streetaddress").Value
            PatientViewDetails.barangay.Text = patientTable.Rows(e.RowIndex).Cells("barangay").Value
            PatientViewDetails.city.Text = patientTable.Rows(e.RowIndex).Cells("city").Value
            PatientViewDetails.zipCode.Text = patientTable.Rows(e.RowIndex).Cells("zipcode").Value

            'fetch guardian info
            GuardianViewDetails.uniqueGuardianNo = guardianTable.Rows(e.RowIndex).Cells("guardianno").Value
            GuardianViewDetails.relationshipToPatient.Text = guardianTable.Rows(e.RowIndex).Cells("relationshiptopatient").Value
            GuardianViewDetails.fullname.Text = guardianTable.Rows(e.RowIndex).Cells("guardianname").Value
            Dim guardianBirthdate As String = guardianTable.Rows(e.RowIndex).Cells("guardianbirthdate").Value.ToString
            If Handlers.ContainsMonth(guardianBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    GuardianViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    GuardianViewDetails.day.Text = parsedDate.Day.ToString()
                    GuardianViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            GuardianViewDetails.homeNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardianhomeno").Value
            GuardianViewDetails.cellNo.Text = guardianTable.Rows(e.RowIndex).Cells("guardiancellno").Value
            GuardianViewDetails.email.Text = guardianTable.Rows(e.RowIndex).Cells("guardianemail").Value
            GuardianViewDetails.address.Text = guardianTable.Rows(e.RowIndex).Cells("guardianaddress").Value

            'fetch insured info
            InsuredViewDetails.uniqueInusredNo = insuredTable.Rows(e.RowIndex).Cells("insuredno").Value
            InsuredViewDetails.relationshipToPatient.Text = insuredTable.Rows(e.RowIndex).Cells("relationshiptopatientins").Value
            InsuredViewDetails.fullname.Text = insuredTable.Rows(e.RowIndex).Cells("nameins").Value
            InsuredViewDetails.ssiNumber.Text = insuredTable.Rows(e.RowIndex).Cells("ssino").Value
            Dim insuredBirthdate As String = insuredTable.Rows(e.RowIndex).Cells("birthdateins").Value.ToString
            If Handlers.ContainsMonth(insuredBirthdate) Then
                Dim parsedDate As Date
                If Date.TryParse(birthdate, parsedDate) Then
                    InsuredViewDetails.month.Text = parsedDate.ToString("MMMM", CultureInfo.InvariantCulture)
                    InsuredViewDetails.day.Text = parsedDate.Day.ToString()
                    InsuredViewDetails.year.Text = parsedDate.Year.ToString()
                Else
                    MessageBox.Show("Invalid birthdate format.")
                End If
            End If
            InsuredViewDetails.homeNo.Text = insuredTable.Rows(e.RowIndex).Cells("homenoins").Value
            InsuredViewDetails.cellNo.Text = insuredTable.Rows(e.RowIndex).Cells("cellnoins").Value
            InsuredViewDetails.email.Text = insuredTable.Rows(e.RowIndex).Cells("emailins").Value
            InsuredViewDetails.address.Text = insuredTable.Rows(e.RowIndex).Cells("addressins").Value

            InsuredViewDetails.Show()
        End If
    End Sub
    Public Sub FilterButton()
        Dim button As Label = Tools.CreateButton(Me, 121, 67, 762, 915)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     FilterPanelPopup()
                                 End Sub
    End Sub
    Public Sub FilterPanelPopup()
        filterPanel = Tools.CreatePanel(Me, 562, 225, 439, 446)
        Dim filterPanelInstance As New FilterControl
        filterPanel.Controls.Add(filterPanelInstance)
        filterPanel.Visible = True
        filterPanel.BringToFront()
    End Sub
    Public Sub LoadGuardianDataForRelationships(relationship As String)
        filterTable.Rows.Clear()

        Dim guardianExtractedRelationship As String = ExtractRelationship(relationship)

        filterTable.Visible = True
        filterTable.BringToFront()
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Dim query As String = "
                SELECT p.patient_no, p.first_name, p.last_name, g.relationship_to_patient AS guardian_relationship, g.guardian_name
                FROM patients p
                JOIN guardians g ON p.patient_no = g.guardian_no
                WHERE g.relationship_to_patient = @relationship
            "
                Using command = Database.GetCommand(query)
                    command.Parameters.AddWithValue("@relationship", guardianExtractedRelationship)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        filterTable.Rows.Clear()

                        While reader.Read()
                            Dim patientNo As String = reader("patient_no").ToString
                            Dim firstName As String = reader("first_name").ToString
                            Dim lastName As String = reader("last_name").ToString
                            Dim relationshipToPatient As String = reader("guardian_relationship").ToString
                            Dim relativeName As String = reader("guardian_name").ToString

                            filterTable.Rows.Add(patientNo, firstName, lastName, relationshipToPatient, relativeName)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadInsuredDataForRelationships(relationship As String)
        filterTable.Rows.Clear()

        Dim insuredExtractedRelationship As String = ExtractRelationship(relationship)

        filterTable.Visible = True
        filterTable.BringToFront()
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Dim query As String = "
                SELECT p.patient_no, p.first_name, p.last_name, i.relationship_to_patient AS insured_relationship, i.insured_name
                FROM patients p
                JOIN insureds i ON p.patient_no = i.insured_no
                WHERE i.relationship_to_patient = @relationship
            "
                Using command = Database.GetCommand(query)
                    command.Parameters.AddWithValue("@relationship", insuredExtractedRelationship)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        filterTable.Rows.Clear()

                        While reader.Read()
                            Dim patientNo As String = reader("patient_no").ToString
                            Dim firstName As String = reader("first_name").ToString
                            Dim lastName As String = reader("last_name").ToString
                            Dim relationshipToPatient As String = reader("insured_relationship").ToString
                            Dim relativeName As String = reader("insured_name").ToString

                            filterTable.Rows.Add(patientNo, firstName, lastName, relationshipToPatient, relativeName)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Public Function ExtractRelationship(inputText As String) As String
        Dim lowerCaseInput As String = inputText.ToLower()

        ' Check if the input contains either "guardian" or "insured"
        If lowerCaseInput.Contains("guardian") OrElse lowerCaseInput.Contains("insured") Then
            ' Find the index of either "guardian" or "insured"
            Dim keyword As String = If(lowerCaseInput.Contains("guardian"), "guardian", "insured")
            Dim keywordIndex As Integer = lowerCaseInput.IndexOf(keyword)

            ' Extract the substring after the keyword
            If keywordIndex + keyword.Length < inputText.Length Then
                Return inputText.Substring(keywordIndex + keyword.Length).Trim()
            End If
        End If

        Return String.Empty
    End Function

End Class

