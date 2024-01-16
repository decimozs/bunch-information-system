Public Class AdminLoginForm
    Public username As New TextBox
    Public password As New TextBox
    Public popUpPanel As New Panel
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub AdminLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.FormStyle(Me)
        Me.BeginInvoke(New Action(Sub() Me.ActiveControl = Nothing))
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        LoginButton()
        InputUsername()
        InputPassword()
        CloseButton()
        MinimzedButton()
        BackButton()
        PopUp()
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
    Private Sub InputUsername()
        username = Tools.CreateInputBox(Me, "Username", 485, 48, 478, 672)
    End Sub
    Private Sub InputPassword()
        password = Tools.CreateInputBox(Me, "Password", 485, 48, 478, 770)

        AddHandler password.Enter, Sub(sender As Object, e As EventArgs)
                                       Styles.PasswordTextBox_GotFocus(password, sender, e)
                                   End Sub
        AddHandler password.Leave, Sub(sender As Object, e As EventArgs)
                                       Styles.PasswordTextBox_LostFocus(password, sender, e)
                                   End Sub
    End Sub
    Private Sub PopUp()
        popUpPanel = New Panel
        Dim popUp As New InvalidCredentialsPopUp
        popUpPanel = Tools.CreatePanel(Me, 372, 83, 534, 39)
        popUpPanel.Controls.Add(popUp)
    End Sub
    Private Sub LoginButton()
        Dim loginBtn = Tools.CreateButton(Me, 232, 60, 772, 863)
        AddHandler loginBtn.Click, Sub(sender As Object, e As EventArgs)
                                       Handlers.Authentication(Me, username.Text, password.Text)
                                   End Sub
    End Sub
End Class