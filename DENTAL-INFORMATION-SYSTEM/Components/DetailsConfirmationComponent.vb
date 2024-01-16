Public Class DetailsConfirmationComponent
    Inherits UserControl

    Public patientNo As New Label
    Public patientName As New Label
    Public birthdate As New Label
    Public maritalStatus As New Label
    Public homeNo As New Label
    Public cellNo As New Label
    Public email As New Label
    Public address As New Label
    Public addressExt As New Label
    Public confirmationName As New Label
    Sub New(formName As String)
        Styles.UserControl(Me, 563, 730)
        InitializeComponent()
        InitializeDetailsConfirmationLabels()
        InitializeDetailsConfirmationComponent(formName)
    End Sub
    Private Sub InitializeDetailsConfirmationComponent(formName As String)
        InitializeConfirmationDetailsProvider(formName)
        ConfirmButton(formName)
        BackButton()
        PatientNumberInfo()
        PatientNameInfo()
        PatientBirthdateInfo()
        PatientMaritalStatusInfo()
        PatientHomeNoInfo()
        PatientCellNoInfo()
        PatientEmailInfo()
        PatientAddressInfo()
    End Sub
    Private Sub InitializeConfirmationDetailsProvider(formName As String)
        confirmationName = Tools.CreateLabel(Me, 350, 47, 27, 37)
        confirmationName.Text = formName
        Styles.TextStyleAlignment(confirmationName, "header", "left")
    End Sub
    Private Sub InitializeDetailsConfirmationLabels()
        Dim birthdateLbl = Tools.CreateLabel(Me, 171, 30, 67, 277)
        Styles.TextStyleAlignment(birthdateLbl, "subtext", "left")
        birthdateLbl.Text = "Birthdate"

        Dim maritalStatusLbl = Tools.CreateLabel(Me, 150, 30, 67, 310)
        Styles.TextStyleAlignment(maritalStatusLbl, "subtext", "left")
        maritalStatusLbl.Text = "Marital Status"

        Dim homeNoLbl = Tools.CreateLabel(Me, 171, 30, 67, 342)
        Styles.TextStyleAlignment(homeNoLbl, "subtext", "left")
        homeNoLbl.Text = "Home Phone No."

        Dim cellNoLbl = Tools.CreateLabel(Me, 171, 30, 67, 376)
        Styles.TextStyleAlignment(cellNoLbl, "subtext", "left")
        cellNoLbl.Text = "Cell Phone No."

        Dim emailLbl = Tools.CreateLabel(Me, 120, 30, 67, 408)
        Styles.TextStyleAlignment(emailLbl, "subtext", "left")
        emailLbl.Text = "Email"

        Dim addressLbl = Tools.CreateLabel(Me, 171, 30, 67, 441)
        Styles.TextStyleAlignment(addressLbl, "subtext", "left")
        addressLbl.Text = "Address"

    End Sub
    Private Sub PatientNumberInfo()
        patientNo = Tools.CreateLabel(Me, 307, 30, 186, 140)
        patientNo.Text = $"Patient No. {Database.FetchPatientNo}"
        Styles.TextStyleAlignment(patientNo, "text", "right")
    End Sub
    Private Sub PatientNameInfo()
        patientName = Tools.CreateLabel(Me, 310, 60, 186, 170)
        Styles.TextStyleAlignment(patientName, "header", "right")
    End Sub
    Private Sub PatientBirthdateInfo()
        birthdate = Tools.CreateLabel(Me, 427, 30, 67, 276)
        Styles.TextStyleAlignment(birthdate, "text", "right")
    End Sub
    Private Sub PatientMaritalStatusInfo()
        maritalStatus = Tools.CreateLabel(Me, 427, 30, 67, 309)
        Styles.TextStyleAlignment(maritalStatus, "text", "right")
    End Sub
    Private Sub PatientHomeNoInfo()
        homeNo = Tools.CreateLabel(Me, 427, 30, 67, 341)
        Styles.TextStyleAlignment(homeNo, "text", "right")
    End Sub
    Private Sub PatientCellNoInfo()
        cellNo = Tools.CreateLabel(Me, 427, 30, 67, 375)
        Styles.TextStyleAlignment(cellNo, "text", "right")
    End Sub
    Private Sub PatientEmailInfo()
        email = Tools.CreateLabel(Me, 427, 30, 67, 407)
        Styles.TextStyleAlignment(email, "text", "right")
    End Sub
    Private Sub PatientAddressInfo()
        address = Tools.CreateLabel(Me, 247, 30, 247, 440)
        Styles.TextStyleAlignment(address, "text", "right")
        addressExt = Tools.CreateLabel(Me, 323, 30, 171, 463)
        Styles.TextStyleAlignment(addressExt, "text", "right")
    End Sub
    Private Sub BackButton()
        Dim backBtn = Tools.CreateButton(Me, 50, 22, 479, 30)
        AddHandler backBtn.Click, Sub(sender As Object, e As EventArgs)
                                      Handlers.CloseConfirmationWindow()
                                  End Sub
    End Sub
    Private Sub ConfirmButton(formName As String)
        Dim confirmBtn = Tools.CreateButton(Me, 144, 55, 387, 640)
        AddHandler confirmBtn.Click, Sub(sender As Object, e As EventArgs)
                                         Handlers.CloseConfirmationWindow()
                                         Handlers.NextForm(formName)
                                     End Sub
    End Sub
End Class
