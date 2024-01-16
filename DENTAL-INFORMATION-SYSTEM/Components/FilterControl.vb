Imports MySql.Data.MySqlClient

Public Class FilterControl
    Public inputFilterText As New TextBox
    Private Sub FilterControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Styles.UserControl(Me, 562, 225)
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        CreateFilterControl()
        CloseButton()
        FilterListButton()
    End Sub
    Private Sub CreateFilterControl()
        inputFilterText = Tools.CreateInputBox(Me, "Filter list", 470, 48, 53, 98)
    End Sub
    Private Sub CloseButton()
        Dim button As Label = Tools.CreateButton(Me, 37, 35, 511, 13)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     AdminDashboard.filterPanel.Visible = False
                                 End Sub
    End Sub
    Private Sub FilterListButton()
        Dim button As Label = Tools.CreateButton(Me, 157, 49, 371, 154)
        AddHandler button.Click, Sub(sender As Object, e As EventArgs)
                                     AdminDashboard.filterPanel.Visible = False

                                     Dim searchText As String = inputFilterText.Text.ToLower().Trim()

                                     Select Case True
                                         Case searchText.Contains("insured")
                                             AdminDashboard.LoadInsuredDataForRelationships(searchText)
                                         Case searchText.Contains("guardian")
                                             AdminDashboard.LoadGuardianDataForRelationships(searchText)
                                     End Select
                                 End Sub
    End Sub
End Class
