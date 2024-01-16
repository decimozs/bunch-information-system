Public Class MaritalStatusBox
    Sub New(formName As String)
        Styles.UserControl(Me, 244, 149)
        InitializeComponent()
        InitializeMaritalStatusBox(formName)
    End Sub
    Private Sub InitializeMaritalStatusBox(formName As String)
        CreateStatus("Single", 21, formName)
        CreateStatus("Married", 45, formName)
        CreateStatus("Widowed", 68, formName)
        CreateStatus("Divorced", 91, formName)
        CreateStatus("Seperated", 114, formName)
    End Sub
    Private Sub CreateStatus(status As String, y As Integer, formName As String)
        Dim width As Integer = 117
        Dim height As Integer = 16
        Dim x As Integer = 64
        Dim button = Tools.CreateLabel(Me, width, height, x, y)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     Handlers.SetStatus(status, formName)
                                 End Sub
    End Sub
End Class
