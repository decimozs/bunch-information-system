Public Class ThankYouForm
    Dim popUpPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub ThankYouForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
        PatientForm.InsertPatientData()
        GuardianForm.InsertGuardianData()
        InsuredForm.InsertInsuredData()
        AdminDashboard.LoadPatientData()
        AdminDashboard.LoadGuardianData()
        AdminDashboard.LoadInsuredData()
        PopUp()
    End Sub
    Private Sub LoadComponents()
        CloseButton()
        MinimzedButton()
        ReturnButton()
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
    Private Sub ReturnButton()
        Dim returnBtn = Tools.CreateButton(Me, 232, 60, 1142, 893)
        AddHandler returnBtn.Click, Sub(sender As Object, e As EventArgs)
                                        Handlers.OpenWindow(Me, Form1)
                                    End Sub
    End Sub
    Private Sub PopUp()
        popUpPanel = New Panel
        Dim popUp As New GreenNotification("Patient data added successfully!")
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
End Class