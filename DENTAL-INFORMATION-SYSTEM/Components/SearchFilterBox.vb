Public Class SearchFilterBox
    Inherits UserControl
    Sub New()
        Styles.UserControl(Me, 218, 138)
        InitializeComponent()
        InitializeSearchFilter()
    End Sub
    Private Sub InitializeSearchFilter()
        CreateSearchFiler("patient", 10)
        CreateSearchFiler("guardian", 39)
        CreateSearchFiler("insured", 65)
    End Sub
    Private Sub CreateSearchFiler(searchFilterName As String, y As Integer)
        Dim width As Integer = 117
        Dim height As Integer = 21
        Dim x As Integer = 20
        Dim button = Tools.CreateLabel(Me, width, height, x, y)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     Handlers.SetFilterBox(searchFilterName)
                                 End Sub
    End Sub
End Class
