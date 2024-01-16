Public Class DropDown
    Sub New(panel As Panel)
        Styles.UserControl(Me, 25, 11)
        InitializeComponent()
        InitializeDropDownButton(panel)
    End Sub
    Private Sub InitializeDropDownButton(panel As Panel)
        Dim button = Tools.CreateLabel(Me, 25, 11, 0, 0)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     Handlers.OpenPanel(panel)
                                 End Sub
    End Sub
End Class
