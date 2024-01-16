Public Class MonthBox
    Sub New(formName As String)
        Styles.UserControl(Me, 231, 312)
        InitializeComponent()
        InitializeMonthBox(formName)
    End Sub
    Private Sub InitializeMonthBox(formName As String)
        CreateMonth("January", 22, formName)
        CreateMonth("February", 45, formName)
        CreateMonth("March", 68, formName)
        CreateMonth("April", 91, formName)
        CreateMonth("May", 114, formName)
        CreateMonth("June", 137, formName)
        CreateMonth("July", 160, formName)
        CreateMonth("August", 183, formName)
        CreateMonth("September", 206, formName)
        CreateMonth("October", 229, formName)
        CreateMonth("November", 252, formName)
        CreateMonth("December", 275, formName)
    End Sub
    Private Sub CreateMonth(monthName As String, y As Integer, formName As String)
        Dim width As Integer = 117
        Dim height As Integer = 16
        Dim x As Integer = 56
        Dim button = Tools.CreateLabel(Me, width, height, x, y)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     Handlers.SetMonth(monthName, formName)
                                 End Sub
    End Sub
End Class
