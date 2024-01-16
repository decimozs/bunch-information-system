Public Class GreenNotification
    Private Sub GreenNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.UserControl(Me, 372, 83)
    End Sub
    Sub New(text As String)
        InitializeComponent()
        CreateNotification(text)
    End Sub
    Private Sub CreateNotification(text As String)
        Dim notify As Label = Tools.CreateLabel(Me, 337, 52, 29, 30)
        notify.Text = text
        notify.ForeColor = Color.Black
        notify.TextAlign = ContentAlignment.MiddleCenter
        notify.Font = New Font("Poppins", 11, FontStyle.Bold)
    End Sub
End Class
