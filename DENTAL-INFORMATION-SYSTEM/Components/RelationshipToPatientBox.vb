Public Class RelationshipToPatientBox
    Sub New(formName As String)
        Styles.UserControl(Me, 244, 176)
        InitializeComponent()
        InitializeRelationshipToPatientBox(formName)
    End Sub
    Private Sub InitializeRelationshipToPatientBox(formName As String)
        CreateRelationship("Mother", 21, formName)
        CreateRelationship("Father", 45, formName)
        CreateRelationship("Sister", 69, formName)
        CreateRelationship("Brother", 91, formName)
        CreateRelationship("Guardian", 113, formName)
        CreateRelationship("Other", 137, formName)
    End Sub
    Private Sub CreateRelationship(status As String, y As Integer, formName As String)
        Dim width As Integer = 122
        Dim height As Integer = 18
        Dim x As Integer = 64
        Dim button = Tools.CreateLabel(Me, width, height, x, y)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     Handlers.SetStatus(status, formName)
                                 End Sub
    End Sub
End Class
