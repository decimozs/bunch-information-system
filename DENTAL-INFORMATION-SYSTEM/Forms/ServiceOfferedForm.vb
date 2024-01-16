Public Class ServiceOfferedForm
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub ServiceOfferedForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        CloseButton()
        MinimzedButton()
        BackButton()
        DentalExaminationButton()
        DentalCleaningButton()
        DiagnosticServicesButton()
        PreventiveDentistry()
        RestorativeDentistry()
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
                                      Handlers.OpenWindow(Me, Form1)
                                  End Sub
    End Sub
    Private Sub DentalExaminationButton()
        Dim dentalExaminationBtn = Tools.CreateButton(Me, 526, 96, 140, 205)
        AddHandler dentalExaminationBtn.Click, Sub(sender As Object, e As EventArgs)
                                                   Handlers.OpenWindow(Me, PatientForm)
                                                   Handlers.SetServiceLabel("Dental Examination")
                                               End Sub
    End Sub
    Private Sub DentalCleaningButton()
        Dim dentalCleaningBtn = Tools.CreateButton(Me, 526, 96, 140, 318)
        AddHandler dentalCleaningBtn.Click, Sub(sender As Object, e As EventArgs)
                                                Handlers.OpenWindow(Me, PatientForm)
                                                Handlers.SetServiceLabel("Dental Cleaning")
                                            End Sub
    End Sub
    Private Sub DiagnosticServicesButton()
        Dim diagnosticsServicesBtn = Tools.CreateButton(Me, 526, 96, 140, 431)
        AddHandler diagnosticsServicesBtn.Click, Sub(sender As Object, e As EventArgs)
                                                     Handlers.OpenWindow(Me, PatientForm)
                                                     Handlers.SetServiceLabel("Diagnostic Services")
                                                 End Sub
    End Sub
    Private Sub PreventiveDentistry()
        Dim preventiveDenstistryBtn = Tools.CreateButton(Me, 526, 96, 140, 544)
        AddHandler preventiveDenstistryBtn.Click, Sub(sender As Object, e As EventArgs)
                                                      Handlers.OpenWindow(Me, PatientForm)
                                                      Handlers.SetServiceLabel("Preventive Dentistry")
                                                  End Sub
    End Sub
    Private Sub RestorativeDentistry()
        Dim restorativeDentistryBtn = Tools.CreateButton(Me, 526, 96, 140, 657)
        AddHandler restorativeDentistryBtn.Click, Sub(sender As Object, e As EventArgs)
                                                      Handlers.OpenWindow(Me, PatientForm)
                                                      Handlers.SetServiceLabel("Restorative Examination")
                                                  End Sub
    End Sub
End Class