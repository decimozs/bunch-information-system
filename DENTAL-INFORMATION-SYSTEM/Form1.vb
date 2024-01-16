
Public Class Form1
    Public popUpPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PatientForm.Show()
        GuardianForm.Show()
        InsuredForm.Show()
        PatientViewDetails.Show()
        GuardianViewDetails.Show()
        InsuredViewDetails.Show()
        PatientForm.Hide()
        GuardianForm.Hide()
        InsuredForm.Hide()
        PatientViewDetails.Hide()
        GuardianViewDetails.Hide()
        InsuredViewDetails.Hide()
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
        PopUp()
    End Sub
    Private Sub LoadComponents()
        CloseButton()
        MinimzedButton()
        PatientButton()
        AdminButton()
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
    Private Sub PatientButton()
        Dim patentBtn = Tools.CreateButton(Me, 328, 60, 1046, 823)
        AddHandler patentBtn.Click, Sub(sender As Object, e As EventArgs)
                                        Handlers.OpenWindow(Me, ServiceOfferedForm)
                                    End Sub
    End Sub
    Private Sub AdminButton()
        Dim adminBtn = Tools.CreateButton(Me, 328, 60, 1046, 893)
        AddHandler adminBtn.Click, Sub(sender As Object, e As EventArgs)
                                       Handlers.OpenWindow(Me, AdminLoginForm)
                                   End Sub
    End Sub
    Private Sub PopUp()
        popUpPanel = New Panel
        Dim popUp As New WelcomePopUp
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
