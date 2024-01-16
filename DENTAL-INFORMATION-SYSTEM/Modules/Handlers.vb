Imports System.Globalization
Imports System.Reflection.Emit

Module Handlers
    Private detailsConfirmationInstance As New DetailsConfirmationComponent("")
    Public Sub OpenWindow(currentForm As Control, openWindow As Form)
        currentForm.Hide()
        openWindow.Show()
    End Sub
    Public Sub NextForm(formName As String)
        Select Case formName
            Case "Patient Information"
                PatientForm.Hide()
                GuardianForm.Show()
            Case "Guardian Information"
                GuardianForm.Hide()
                InsuredForm.Show()
            Case "Insured Information"
                InsuredForm.Hide()
                ThankYouForm.Show()
        End Select
    End Sub
    Public Sub CloseWindow(currentForm As Control)
        currentForm.Hide()
        currentForm.Dispose()
    End Sub
    Public Sub MinimizedWindow(currentForm As Form)
        currentForm.WindowState = FormWindowState.Minimized
    End Sub
    Public Sub SetServiceLabel(serviceName As String)
        PatientForm.serviceLbl.Text = serviceName
        GuardianForm.serviceLbl.Text = serviceName
        InsuredForm.serviceLbl.Text = serviceName
    End Sub
    Public Sub SetMonth(text As String, formName As String)
        Select Case formName
            Case "Patient Information"
                PatientForm.month.ForeColor = Color.Black
                PatientForm.month.Text = text
                PatientForm.monthBoxPanel.Visible = False
            Case "Guardian Information"
                GuardianForm.month.ForeColor = Color.Black
                GuardianForm.month.Text = text
                GuardianForm.monthBoxPanel.Visible = False
            Case "Insured Information"
                InsuredForm.month.ForeColor = Color.Black
                InsuredForm.month.Text = text
                InsuredForm.monthBoxPanel.Visible = False
            Case "Patient View Details"
                PatientViewDetails.month.ForeColor = Color.Black
                PatientViewDetails.month.Text = text
                PatientViewDetails.monthBoxPanel.Visible = False
            Case "Guardian View Details"
                InsuredViewDetails.month.ForeColor = Color.Black
                InsuredViewDetails.month.Text = text
                InsuredViewDetails.monthBoxPanel.Visible = False
        End Select
    End Sub
    Public Sub SetStatus(text As String, formName As String)
        Select Case formName
            Case "Patient Information"
                PatientForm.maritalStatus.ForeColor = Color.Black
                PatientForm.maritalStatus.Text = text
                PatientForm.maritalStatusPanel.Visible = False
            Case "Guardian Information"
                GuardianForm.relationshipToPatient.ForeColor = Color.Black
                GuardianForm.relationshipToPatient.Text = text
                GuardianForm.relationshipToPatientPanel.Visible = False
            Case "Insured Information"
                InsuredForm.relationshipToPatient.ForeColor = Color.Black
                InsuredForm.relationshipToPatient.Text = text
                InsuredForm.relationshipToPatientPanel.Visible = False
            Case "Patient View Details"
                PatientViewDetails.maritalStatus.ForeColor = Color.Black
                PatientViewDetails.maritalStatus.Text = text
                PatientViewDetails.maritalStatusPanel.Visible = False
            Case "Guardian View Details"
                GuardianViewDetails.relationshipToPatient.ForeColor = Color.Black
                GuardianViewDetails.relationshipToPatient.Text = text
                GuardianViewDetails.relationshipToPatientPanel.Visible = False
            Case "Insured View Details"
                InsuredViewDetails.relationshipToPatient.ForeColor = Color.Black
                InsuredViewDetails.relationshipToPatient.Text = text
                InsuredViewDetails.relationshipToPatientPanel.Visible = False
        End Select
    End Sub
    Public Sub SetFilterBox(searchFilterName As String)
        If searchFilterName = "patient" Then
            AdminDashboard.patientSearch.Visible = True
            AdminDashboard.guardianSearch.Visible = False
            AdminDashboard.insuredSearch.Visible = False
            AdminDashboard.searchFilterPanel.Visible = False
            AdminDashboard.patientSearch.Text = "Enter patient number"
        ElseIf searchFilterName = "guardian" Then
            AdminDashboard.patientSearch.Visible = False
            AdminDashboard.guardianSearch.Visible = True
            AdminDashboard.insuredSearch.Visible = False
            AdminDashboard.searchFilterPanel.Visible = False
            AdminDashboard.guardianSearch.Text = "Enter guardian number"
        ElseIf searchFilterName = "insured" Then
            AdminDashboard.insuredSearch.Visible = True
            AdminDashboard.patientSearch.Visible = False
            AdminDashboard.guardianSearch.Visible = False
            AdminDashboard.searchFilterPanel.Visible = False
            AdminDashboard.insuredSearch.Text = "Enter insured number"
        End If
    End Sub
    Public Sub SetEditStatus()
        ' patient readonly textbox
        PatientViewDetails.firstName.ForeColor = Color.Black
        PatientViewDetails.lastname.ForeColor = Color.Black
        PatientViewDetails.middleInitial.ForeColor = Color.Black
        PatientViewDetails.month.ForeColor = Color.Black
        PatientViewDetails.day.ForeColor = Color.Black
        PatientViewDetails.year.ForeColor = Color.Black
        PatientViewDetails.homeNo.ForeColor = Color.Black
        PatientViewDetails.cellNo.ForeColor = Color.Black
        PatientViewDetails.email.ForeColor = Color.Black
        PatientViewDetails.maritalStatus.ForeColor = Color.Black
        PatientViewDetails.streetAddress.ForeColor = Color.Black
        PatientViewDetails.barangay.ForeColor = Color.Black
        PatientViewDetails.city.ForeColor = Color.Black
        PatientViewDetails.zipCode.ForeColor = Color.Black

        ' guardian readonly textbox
        GuardianViewDetails.fullname.ForeColor = Color.Black
        GuardianViewDetails.month.ForeColor = Color.Black
        GuardianViewDetails.day.ForeColor = Color.Black
        GuardianViewDetails.year.ForeColor = Color.Black
        GuardianViewDetails.homeNo.ForeColor = Color.Black
        GuardianViewDetails.cellNo.ForeColor = Color.Black
        GuardianViewDetails.email.ForeColor = Color.Black
        GuardianViewDetails.relationshipToPatient.ForeColor = Color.Black
        GuardianViewDetails.address.ForeColor = Color.Black

        ' insured readonly textbox
        InsuredViewDetails.fullname.ForeColor = Color.Black
        InsuredViewDetails.month.ForeColor = Color.Black
        InsuredViewDetails.day.ForeColor = Color.Black
        InsuredViewDetails.year.ForeColor = Color.Black
        InsuredViewDetails.homeNo.ForeColor = Color.Black
        InsuredViewDetails.cellNo.ForeColor = Color.Black
        InsuredViewDetails.email.ForeColor = Color.Black
        InsuredViewDetails.relationshipToPatient.ForeColor = Color.Black
        InsuredViewDetails.address.ForeColor = Color.Black
    End Sub
    Public Sub ResetConfirmationDetails(formName As String)
        Select Case formName
            Case "Patient Information"
                PatientForm.detailsConfirmationPanel.Visible = False
            Case "Guardian Information"
                GuardianForm.detailsConfirmationPanel.Visible = False
            Case "Insured Information"
                InsuredForm.detailsConfirmationPanel.Visible = False
        End Select
    End Sub
    Public Sub ShowPatientDetails(name As String)
        detailsConfirmationInstance.patientName.Text = name
    End Sub
    Public Sub OpenPanel(panel As Panel)
        panel.Visible = Not panel.Visible
        panel.BringToFront()
    End Sub
    Public Sub CloseConfirmationWindow()
        PatientForm.detailsConfirmationPanel.Visible = False
        GuardianForm.detailsConfirmationPanel.Visible = False
        InsuredForm.detailsConfirmationPanel.Visible = False
    End Sub
    Public Sub ResetInputBoxes(form As Control)
        For Each ctrl As Control In form.Controls
            If TypeOf ctrl Is TextBox Then
                Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                If Not String.IsNullOrEmpty(textBox.Tag) Then
                    textBox.Text = textBox.Tag.ToString()
                Else
                    textBox.Text = String.Empty
                End If
                textBox.ForeColor = Color.Gray
            End If
        Next
    End Sub
    Public Function AutoCapitalizeFirstLetter(Input As String) As String
        Dim words As String() = Input.Split(" "c)
        Dim result As New Text.StringBuilder()

        For Each word As String In words
            If word.Length > 0 Then
                Dim capitalizedWord As String = Char.ToUpper(word(0)) + word.Substring(1)
                result.Append(capitalizedWord)
            End If

            result.Append(" ")
        Next

        result.Length -= 1

        Return result.ToString()
    End Function
    Public Sub TimerTick(panel As Panel, sender As Object, e As EventArgs)
        panel.Visible = False
        DirectCast(sender, Timer).Stop()
        DirectCast(sender, Timer).Dispose()
    End Sub
    Public Sub Authentication(form As Form, username As String, password As String)
        If username <> "admin" OrElse password <> "12345" Then
            Dim timer As New Timer()
            AdminLoginForm.popUpPanel.Visible = True
            timer.Interval = 5000
            AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                       TimerTick(AdminLoginForm.popUpPanel, sender, e)
                                   End Sub
            timer.Start()
        Else
            AdminLoginForm.username.Text = "Username"
            AdminLoginForm.username.ForeColor = Color.Gray
            AdminLoginForm.password.Text = "Password"
            AdminLoginForm.password.ForeColor = Color.Gray
            OpenWindow(form, AdminDashboard)
        End If
    End Sub
    Public Function ConvertTextToInteger(text As String) As Integer
        Dim integerValue As Integer
        If Not String.IsNullOrEmpty(text) AndAlso Integer.TryParse(text, integerValue) Then
            Console.WriteLine("conversion successful: " & integerValue.ToString())
        Else
            Console.WriteLine("conversion failed. Please enter a valid integer.")
        End If
        Return integerValue
    End Function
    Public Function ContainsMonth(ByVal input As String) As Boolean
        Dim dtfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        For Each monthName As String In dtfi.MonthNames
            If input.Contains(monthName) Then
                Return True
            End If
        Next

        For Each abbreviatedMonthName As String In dtfi.AbbreviatedMonthNames
            If input.Contains(abbreviatedMonthName) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub CloseViewDetailsWindows()
        PatientViewDetails.Hide()
        GuardianViewDetails.Hide()
        InsuredViewDetails.Hide()
    End Sub
End Module
