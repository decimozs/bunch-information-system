Module Styles
    Public Sub FormStyle(ByVal component As Form)
        component.Size = New Size(1459, 1072)
        component.StartPosition = FormStartPosition.Manual
        component.Location = New Point(230, 30)
        component.FormBorderStyle = FormBorderStyle.None
        component.BackColor = Color.Magenta
        component.TransparencyKey = Color.Magenta
    End Sub
    Public Sub Table(ByVal table As DataGridView)
        table.BackgroundColor = Color.White
        table.ReadOnly = True
        table.BorderStyle = BorderStyle.None
        table.ForeColor = Color.Black
    End Sub
    Public Sub CloseButton(ByVal component As UserControl)
        component.Size = New Size(51, 53)
        component.Location = New Point(1350, 23)
        component.BackColor = Color.Transparent
    End Sub
    Public Sub Button(ByVal component As Label, width As Integer, height As Integer)
        component.Size = New Size(width, height)
        component.BackColor = Color.Transparent
        component.AutoSize = False
    End Sub
    Public Sub MinimizeButton(ByVal component As UserControl)
        component.Size = New Size(48, 53)
        component.Location = New Point(1291, 23)
        component.BackColor = Color.Transparent
    End Sub
    Public Sub UserControl(ByVal component As UserControl, width As Integer, height As Integer)
        component.Size = New Size(width, height)
        component.BackColor = Color.Transparent
    End Sub
    Public Sub PatientButton(ByVal component As UserControl)
        component.BackColor = Color.Transparent
        component.Size = New Size(328, 60)
        component.Location = New Point(1046, 823)
    End Sub
    Public Sub AdminButton(ByVal component As UserControl)
        component.BackColor = Color.Transparent
        component.Size = New Size(328, 60)
        component.Location = New Point(1046, 893)
    End Sub
    Public Sub BackButton(ByVal component As UserControl)
        component.BackColor = Color.Transparent
        component.Size = New Size(55, 22)
        component.Location = New Point(62, 61)
    End Sub
    Public Sub ServiceButton(ByVal component As UserControl, x As Integer, y As Integer)
        component.BackColor = Color.Transparent
        component.Size = New Size(526, 96)
        component.Location = New Point(x, y)
        component.AutoSize = False

    End Sub
    Public Sub Label(ByVal component As Label, width As Integer, height As Integer, x As Integer, y As Integer)
        component.BackColor = Color.Transparent
        component.Size = New Size(width, height)
        component.Location = New Point(x, y)
    End Sub
    Public Sub TextStyleAlignment(component As Label, content As String, alignment As String)
        If content = "header" Then
            component.Font = New Font("Poppins", 16, FontStyle.Bold)
        ElseIf content = "subtext" Then
            component.Font = New Font("Poppins", 12, FontStyle.Bold)
        ElseIf content = "text" Then
            component.Font = New Font("Poppins", 11, FontStyle.Regular)
        Else
            component.Font = New Font("Poppins", 9, FontStyle.Regular)
        End If

        If alignment = "left" Then
            component.TextAlign = ContentAlignment.MiddleLeft
        ElseIf alignment = "right" Then
            component.TextAlign = ContentAlignment.MiddleRight
        Else
            component.TextAlign = ContentAlignment.MiddleCenter
        End If
    End Sub
    Public Sub ServiceLabel(ByVal component As UserControl)
        component.BackColor = Color.Transparent
        component.Size = New Size(238, 49)
        component.Location = New Point(1083, 158)
    End Sub
    Public Sub NextButton(ByVal component As UserControl)
        component.BackColor = Color.Transparent
        component.Size = New Size(232, 60)
        component.Location = New Point(1142, 893)
    End Sub
    Public Sub DropDown(ByVal component As UserControl, width As Integer, height As Integer, x As Integer, y As Integer)
        component.BackColor = Color.Transparent
        component.Size = New Size(width, height)
        component.Location = New Point(x, y)
    End Sub
    Public Sub SetPlaceholder(textBox As TextBox, placeholderText As String)
        textBox.Text = placeholderText
        textBox.ForeColor = Color.Gray

        AddHandler textBox.GotFocus, Sub() TextBoxGotFocus(textBox, placeholderText)
        AddHandler textBox.LostFocus, Sub() TextBoxLostFocus(textBox, placeholderText)
    End Sub
    Public Sub Panel(component As Panel, width As Integer, height As Integer, x As Integer, y As Integer)
        component.BackColor = Color.Transparent
        component.Size = New Size(width, height)
        component.Location = New Point(x, y)
        component.Visible = False
        component.BringToFront()
    End Sub
    Public Sub TextBox(ByVal component As TextBox, placeholder As String, width As Integer, height As Integer, x As Integer, y As Integer)
        component.Size = New Size(width, height)
        component.BackColor = Color.White
        component.Location = New Point(x, y)
        component.BorderStyle = BorderStyle.None
        component.Font = New Font("Poppins", 11, FontStyle.Bold)
        component.TextAlign = HorizontalAlignment.Center
        component.Tag = placeholder
        Styles.SetPlaceholder(component, placeholder)
    End Sub
    Private Sub TextBoxGotFocus(textBox As TextBox, placeholderText As String)
        If textBox.Text = placeholderText Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBoxLostFocus(textBox As TextBox, placeholderText As String)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.Text = placeholderText
            textBox.ForeColor = Color.Gray
        End If
    End Sub
    Public Sub PasswordTextBox_GotFocus(passwordTextBox As TextBox, sender As Object, e As EventArgs)
        If passwordTextBox.Text = "Password" Then
            passwordTextBox.Text = ""
            passwordTextBox.ForeColor = SystemColors.ControlText
            passwordTextBox.PasswordChar = "*"c
        End If
    End Sub

    Public Sub PasswordTextBox_LostFocus(passwordTextBox As TextBox, sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(passwordTextBox.Text) Then
            passwordTextBox.Text = "Password"
            passwordTextBox.ForeColor = Color.Gray
            passwordTextBox.PasswordChar = ControlChars.NullChar
        ElseIf passwordTextBox.Text = "Password" Then
            passwordTextBox.ForeColor = Color.Gray
            passwordTextBox.PasswordChar = ControlChars.NullChar
        End If
    End Sub
End Module
