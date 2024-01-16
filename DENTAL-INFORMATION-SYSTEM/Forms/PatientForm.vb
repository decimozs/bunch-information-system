Imports System.Net

Public Class PatientForm
    Private detailsConfirmationInstance As New DetailsConfirmationComponent("Patient Information")
    Public monthBoxPanel As New Panel
    Public maritalStatusPanel As New Panel
    Public detailsConfirmationPanel As New Panel
    Public serviceLbl As New Label
    Public patientNo As New Label
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
    Dim popUpPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub PatientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        LoadComponents()
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
    End Sub
    Private Sub LoadComponents()
        MaritalStatusDropDownButton()
        MonthDropDownButton()
        CloseButton()
        MinimzedButton()
        ServiceLabel()
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
    Private Sub BackButton()
        Dim backBtn = Tools.CreateButton(Me, 54, 24, 62, 60)
        AddHandler backBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.OpenWindow(Me, ServiceOfferedForm)
                                      Handlers.ResetInputBoxes(Me)
                                  End Sub
    End Sub
    Private Sub NextButton()
        Dim nextBtn = Tools.CreateButton(Me, 232, 60, 1142, 893)
        AddHandler nextBtn.Click, Sub(sender As Object, e As EventArgs)
                                      If ValidateInput() Then
                                          detailsConfirmationInstance.patientName.Text = Handlers.AutoCapitalizeFirstLetter($"{lastname.Text}, {firstName.Text}")
                                          detailsConfirmationInstance.birthdate.Text = $"{month.Text} {day.Text} ,{year.Text}"
                                          detailsConfirmationInstance.maritalStatus.Text = maritalStatus.Text
                                          detailsConfirmationInstance.homeNo.Text = homeNo.Text
                                          detailsConfirmationInstance.cellNo.Text = cellNo.Text
                                          detailsConfirmationInstance.email.Text = email.Text
                                          detailsConfirmationInstance.address.Text = Handlers.AutoCapitalizeFirstLetter($"{streetAddress.Text}")
                                          detailsConfirmationInstance.addressExt.Text = Handlers.AutoCapitalizeFirstLetter($"{barangay.Text}, {city.Text}, {zipCode.Text}")
                                          ConfirmationPanel()
                                      Else
                                          PopUp()
                                      End If
                                  End Sub
    End Sub
    Private Sub ConfirmationPanel()
        detailsConfirmationPanel = Tools.CreatePanel(Me, 563, 730, 439, 147)
        detailsConfirmationPanel.Controls.Add(detailsConfirmationInstance)
        detailsConfirmationPanel.Visible = True
        detailsConfirmationPanel.BringToFront()
    End Sub
    Private Sub ServiceLabel()
        serviceLbl = Tools.CreateLabel(Me, 240, 49, 1083, 158)
        Styles.TextStyleAlignment(serviceLbl, "subtext", "center")
    End Sub
    Private Sub InputPatientNo()
        patientNo = Tools.CreateLabel(Me, 238, 49, 1083, 98)
        patientNo.Text = $"Patient No. {Database.FetchPatientNo}"
        Styles.TextStyleAlignment(patientNo, "subtext", "center")
    End Sub
    Private Sub InputFirstName()
        firstName = Tools.CreateInputBox(Me, "First name", 195, 40, 421, 350)
    End Sub
    Private Sub InputLastName()
        lastname = Tools.CreateInputBox(Me, "Last name", 195, 40, 670, 350)
    End Sub
    Private Sub InputMiddleInitial()
        middleInitial = Tools.CreateInputBox(Me, "M.I", 103, 40, 919, 350)
    End Sub
    Private Sub InputMonth()
        month = Tools.CreateInputBox(Me, "Month", 193, 40, 421, 448)
        month.ReadOnly = True
    End Sub
    Private Sub InputDay()
        day = Tools.CreateInputBox(Me, "Day", 128, 40, 671, 448)
    End Sub
    Private Sub InputYear()
        year = Tools.CreateInputBox(Me, "Year", 169, 40, 853, 448)
    End Sub
    Private Sub InputHomeNo()
        homeNo = Tools.CreateInputBox(Me, "Home Number", 276, 40, 421, 545)
    End Sub
    Private Sub InputCellNo()
        cellNo = Tools.CreateInputBox(Me, "Phone Number", 268, 40, 754, 545)
    End Sub
    Private Sub InputEmail()
        email = Tools.CreateInputBox(Me, "Email Address", 336, 40, 421, 644)
    End Sub
    Private Sub InputMaritalStatus()
        maritalStatus = Tools.CreateInputBox(Me, "Status", 215, 40, 808, 644)
        maritalStatus.ReadOnly = True
    End Sub
    Private Sub InputStreetAddress()
        streetAddress = Tools.CreateInputBox(Me, "Street Address", 597, 40, 421, 741)
    End Sub
    Private Sub InputBarangay()
        barangay = Tools.CreateInputBox(Me, "Barangay", 207, 40, 421, 808)
    End Sub
    Private Sub InputCity()
        city = Tools.CreateInputBox(Me, "City", 127, 40, 681, 808)
    End Sub
    Private Sub InputZipCode()
        zipCode = Tools.CreateInputBox(Me, "Zip Code", 160, 40, 858, 808)
    End Sub
    Private Sub MonthDropDownButton()
        monthBoxPanel = Tools.CreatePanel(Me, 231, 312, 404, 502)
        Dim monthBoxInstance As New MonthBox("Patient Information")
        monthBoxPanel.Controls.Add(monthBoxInstance)
        Dim dropDownBtn As New DropDown(monthBoxPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(593, 456)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Private Sub MaritalStatusDropDownButton()
        maritalStatusPanel = Tools.CreatePanel(Me, 244, 149, 794, 698)
        Dim maritalStatusInstance As New MaritalStatusBox("Patient Information")
        maritalStatusPanel.Controls.Add(maritalStatusInstance)
        Dim dropDownBtn As New DropDown(maritalStatusPanel) With {
            .BackColor = Color.Transparent,
            .Size = New Size(25, 11),
            .Location = New Point(992, 651)
        }
        Me.Controls.Add(dropDownBtn)
    End Sub
    Public Sub InsertPatientData()
        Dim zipCodeAsInteger = Handlers.ConvertTextToInteger(zipCode.Text)
        Dim cellNoAsInteger = Handlers.ConvertTextToInteger(cellNo.Text)

        Dim query As String = "insert into patients (
                                            date,
                                            first_name,
                                            last_name,
                                            middle_initial,
                                            birthdate,
                                            marital_status,
                                            home_phone_no,
                                            cell_phone_no,
                                            email,
                                            street_address,
                                            barangay,
                                            city,
                                            zip_code
                                            )
                                            VALUES (
                                                @date,
                                                @firstname,
                                                @lastname,
                                                @middleinitial,
                                                @birthdate,
                                                @maritalstatus,
                                                @homeno,
                                                @cellno,
                                                @email,
                                                @streetaddress,
                                                @barangay,
                                                @city,
                                                @zipcode
                                            );
                                        "
        Try
            Using connection = Database.GetConnection
                connection.Open()
                Using command = Database.GetCommand(query)
                    Try
                        command.Parameters.AddWithValue("@date", dateNow)
                        command.Parameters.AddWithValue("@firstname", Handlers.AutoCapitalizeFirstLetter(firstName.Text))
                        command.Parameters.AddWithValue("@lastname", Handlers.AutoCapitalizeFirstLetter(lastname.Text))
                        command.Parameters.AddWithValue("@middleinitial", Handlers.AutoCapitalizeFirstLetter(middleInitial.Text))
                        command.Parameters.AddWithValue("@birthdate", $"{month.Text} {day.Text} ,{year.Text}")
                        command.Parameters.AddWithValue("@maritalstatus", maritalStatus.Text)
                        command.Parameters.AddWithValue("@homeno", homeNo.Text)
                        command.Parameters.AddWithValue("@cellno", cellNoAsInteger)
                        command.Parameters.AddWithValue("@email", email.Text)
                        command.Parameters.AddWithValue("@streetaddress", Handlers.AutoCapitalizeFirstLetter(streetAddress.Text))
                        command.Parameters.AddWithValue("@barangay", Handlers.AutoCapitalizeFirstLetter(barangay.Text))
                        command.Parameters.AddWithValue("@city", Handlers.AutoCapitalizeFirstLetter(city.Text))
                        command.Parameters.AddWithValue("@zipcode", zipCodeAsInteger)
                        command.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox($"Failed to insert patients: {ex}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox($"Database Error: {ex}")
        End Try
    End Sub
    Private Sub PopUp()
        popUpPanel = New Panel
        Dim popUp As New RequiredInfoPopUp
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
    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(firstName.Text) OrElse
       String.IsNullOrWhiteSpace(lastname.Text) OrElse
       String.IsNullOrWhiteSpace(month.Text) OrElse
       String.IsNullOrWhiteSpace(day.Text) OrElse
       String.IsNullOrWhiteSpace(year.Text) OrElse
       String.IsNullOrWhiteSpace(homeNo.Text) OrElse
       String.IsNullOrWhiteSpace(cellNo.Text) OrElse
       String.IsNullOrWhiteSpace(email.Text) OrElse
       String.IsNullOrWhiteSpace(streetAddress.Text) OrElse
       String.IsNullOrWhiteSpace(barangay.Text) OrElse
       String.IsNullOrWhiteSpace(city.Text) OrElse
       String.IsNullOrWhiteSpace(zipCode.Text) Then
            Return False
        End If

        If IsPlaceholderEmpty(firstName, "First name") OrElse
       IsPlaceholderEmpty(lastname, "Last name") OrElse
       IsPlaceholderEmpty(month, "Month") OrElse
       IsPlaceholderEmpty(day, "Day") OrElse
       IsPlaceholderEmpty(year, "Year") OrElse
       IsPlaceholderEmpty(homeNo, "Home Number") OrElse
       IsPlaceholderEmpty(cellNo, "Phone Number") OrElse
       IsPlaceholderEmpty(email, "Email Address") OrElse
       IsPlaceholderEmpty(streetAddress, "Street Address") OrElse
       IsPlaceholderEmpty(barangay, "Barangay") OrElse
       IsPlaceholderEmpty(city, "City") OrElse
       IsPlaceholderEmpty(zipCode, "Zip Code") Then
            Return False
        End If
        Return True
    End Function

    Private Function IsPlaceholderEmpty(textBox As TextBox, placeholder As String) As Boolean
        Return textBox.Text.Trim() = placeholder.Trim()
    End Function
End Class