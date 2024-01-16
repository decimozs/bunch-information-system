Module Tools
    Public Function CreateButton(form As Control, width As Integer, height As Integer, x As Integer, y As Integer) As Label
        Dim button As New Label
        Styles.Label(button, width, height, x, y)
        form.Controls.Add(button)
        Return button
    End Function
    Public Function CreateLabel(form As Control, width As Integer, height As Integer, x As Integer, y As Integer) As Label
        Dim button As New Label
        Styles.Label(button, width, height, x, y)
        form.Controls.Add(button)
        Return button
    End Function
    Public Function CreateInputBox(form As Control, placeholder As String, width As Integer, height As Integer, x As Integer, y As Integer)
        Dim textbox As New TextBox
        Styles.TextBox(textbox, placeholder, width, height, x, y)
        form.Controls.Add(textbox)
        Return textbox
    End Function
    Public Function CreatePanel(form As Form, width As Integer, height As Integer, x As Integer, y As Integer) As Panel
        Dim panel As New Panel
        Styles.Panel(panel, width, height, x, y)
        form.Controls.Add(panel)
        Return panel
    End Function
    Public Function CreateTable(form As Form) As DataGridView
        Dim table As New DataGridView
        Styles.Table(table)
        form.Controls.Add(table)
        Return table
    End Function
End Module
