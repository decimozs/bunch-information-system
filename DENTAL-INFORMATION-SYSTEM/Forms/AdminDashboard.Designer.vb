<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(AdminDashboard))
        patientTable = New DataGridView()
        patientno = New DataGridViewTextBoxColumn()
        datenow = New DataGridViewTextBoxColumn()
        firstname = New DataGridViewTextBoxColumn()
        middleinitial = New DataGridViewTextBoxColumn()
        lastname = New DataGridViewTextBoxColumn()
        birthdate = New DataGridViewTextBoxColumn()
        maritalstatus = New DataGridViewTextBoxColumn()
        homeno = New DataGridViewTextBoxColumn()
        cellno = New DataGridViewTextBoxColumn()
        email = New DataGridViewTextBoxColumn()
        streetaddress = New DataGridViewTextBoxColumn()
        barangay = New DataGridViewTextBoxColumn()
        city = New DataGridViewTextBoxColumn()
        zipcode = New DataGridViewTextBoxColumn()
        guardianTable = New DataGridView()
        guardianno = New DataGridViewTextBoxColumn()
        relationshiptopatient = New DataGridViewTextBoxColumn()
        guardianname = New DataGridViewTextBoxColumn()
        guardianbirthdate = New DataGridViewTextBoxColumn()
        guardianhomeno = New DataGridViewTextBoxColumn()
        guardiancellno = New DataGridViewTextBoxColumn()
        guardianemail = New DataGridViewTextBoxColumn()
        guardianaddress = New DataGridViewTextBoxColumn()
        insuredTable = New DataGridView()
        insuredno = New DataGridViewTextBoxColumn()
        relationshiptopatientins = New DataGridViewTextBoxColumn()
        nameins = New DataGridViewTextBoxColumn()
        ssino = New DataGridViewTextBoxColumn()
        birthdateins = New DataGridViewTextBoxColumn()
        homenoins = New DataGridViewTextBoxColumn()
        cellnoins = New DataGridViewTextBoxColumn()
        emailins = New DataGridViewTextBoxColumn()
        addressins = New DataGridViewTextBoxColumn()
        filterTable = New DataGridView()
        DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn5 = New DataGridViewTextBoxColumn()
        CType(patientTable, ComponentModel.ISupportInitialize).BeginInit()
        CType(guardianTable, ComponentModel.ISupportInitialize).BeginInit()
        CType(insuredTable, ComponentModel.ISupportInitialize).BeginInit()
        CType(filterTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' patientTable
        ' 
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        patientTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        patientTable.BackgroundColor = Color.White
        patientTable.BorderStyle = BorderStyle.None
        patientTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = Color.Black
        DataGridViewCellStyle2.Padding = New Padding(20, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        patientTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        patientTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        patientTable.Columns.AddRange(New DataGridViewColumn() {patientno, datenow, firstname, middleinitial, lastname, birthdate, maritalstatus, homeno, cellno, email, streetaddress, barangay, city, zipcode})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        patientTable.DefaultCellStyle = DataGridViewCellStyle3
        patientTable.GridColor = Color.Black
        patientTable.Location = New Point(72, 221)
        patientTable.Name = "patientTable"
        patientTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        patientTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        patientTable.RowHeadersWidth = 51
        patientTable.RowTemplate.Height = 29
        patientTable.Size = New Size(1295, 675)
        patientTable.TabIndex = 0
        ' 
        ' patientno
        ' 
        patientno.HeaderText = "PATIENT NO."
        patientno.MinimumWidth = 6
        patientno.Name = "patientno"
        patientno.ReadOnly = True
        patientno.Width = 200
        ' 
        ' datenow
        ' 
        datenow.HeaderText = "DATE"
        datenow.MinimumWidth = 6
        datenow.Name = "datenow"
        datenow.ReadOnly = True
        datenow.Width = 210
        ' 
        ' firstname
        ' 
        firstname.HeaderText = "FIRST NAME"
        firstname.MinimumWidth = 6
        firstname.Name = "firstname"
        firstname.ReadOnly = True
        firstname.Width = 210
        ' 
        ' middleinitial
        ' 
        middleinitial.HeaderText = "MIDDLE INITIAL"
        middleinitial.MinimumWidth = 6
        middleinitial.Name = "middleinitial"
        middleinitial.ReadOnly = True
        middleinitial.Width = 210
        ' 
        ' lastname
        ' 
        lastname.HeaderText = "LAST NAME"
        lastname.MinimumWidth = 6
        lastname.Name = "lastname"
        lastname.ReadOnly = True
        lastname.Width = 210
        ' 
        ' birthdate
        ' 
        birthdate.HeaderText = "BIRTHDATE"
        birthdate.MinimumWidth = 6
        birthdate.Name = "birthdate"
        birthdate.ReadOnly = True
        birthdate.Width = 210
        ' 
        ' maritalstatus
        ' 
        maritalstatus.HeaderText = "MARITAL STATUS"
        maritalstatus.MinimumWidth = 6
        maritalstatus.Name = "maritalstatus"
        maritalstatus.Width = 210
        ' 
        ' homeno
        ' 
        homeno.HeaderText = "HOME PHONE NUMBER"
        homeno.MinimumWidth = 6
        homeno.Name = "homeno"
        homeno.ReadOnly = True
        homeno.Width = 360
        ' 
        ' cellno
        ' 
        cellno.HeaderText = "CELL PHONE NUMBER"
        cellno.MinimumWidth = 6
        cellno.Name = "cellno"
        cellno.ReadOnly = True
        cellno.Width = 360
        ' 
        ' email
        ' 
        email.HeaderText = "EMAIL"
        email.MinimumWidth = 6
        email.Name = "email"
        email.ReadOnly = True
        email.Width = 210
        ' 
        ' streetaddress
        ' 
        streetaddress.HeaderText = "STREET ADDRESS"
        streetaddress.MinimumWidth = 6
        streetaddress.Name = "streetaddress"
        streetaddress.ReadOnly = True
        streetaddress.Width = 250
        ' 
        ' barangay
        ' 
        barangay.HeaderText = "BARANGAY"
        barangay.MinimumWidth = 6
        barangay.Name = "barangay"
        barangay.ReadOnly = True
        barangay.Width = 210
        ' 
        ' city
        ' 
        city.HeaderText = "CITY"
        city.MinimumWidth = 6
        city.Name = "city"
        city.ReadOnly = True
        city.Width = 210
        ' 
        ' zipcode
        ' 
        zipcode.HeaderText = "ZIP CODE"
        zipcode.MinimumWidth = 6
        zipcode.Name = "zipcode"
        zipcode.ReadOnly = True
        zipcode.Width = 210
        ' 
        ' guardianTable
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.White
        DataGridViewCellStyle5.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle5.ForeColor = Color.Black
        DataGridViewCellStyle5.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        guardianTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        guardianTable.BackgroundColor = Color.White
        guardianTable.BorderStyle = BorderStyle.None
        guardianTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.Padding = New Padding(20, 0, 0, 0)
        DataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle6.SelectionForeColor = Color.White
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        guardianTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        guardianTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        guardianTable.Columns.AddRange(New DataGridViewColumn() {guardianno, relationshiptopatient, guardianname, guardianbirthdate, guardianhomeno, guardiancellno, guardianemail, guardianaddress})
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = Color.White
        DataGridViewCellStyle7.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.False
        guardianTable.DefaultCellStyle = DataGridViewCellStyle7
        guardianTable.GridColor = Color.Black
        guardianTable.Location = New Point(72, 221)
        guardianTable.Name = "guardianTable"
        guardianTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle8.ForeColor = Color.Black
        DataGridViewCellStyle8.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle8.SelectionForeColor = Color.White
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        guardianTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        guardianTable.RowHeadersWidth = 51
        guardianTable.RowTemplate.Height = 29
        guardianTable.Size = New Size(1295, 675)
        guardianTable.TabIndex = 1
        ' 
        ' guardianno
        ' 
        guardianno.HeaderText = "GUARDIAN NO."
        guardianno.MinimumWidth = 6
        guardianno.Name = "guardianno"
        guardianno.ReadOnly = True
        guardianno.Width = 200
        ' 
        ' relationshiptopatient
        ' 
        relationshiptopatient.HeaderText = "RELATIONSHIP"
        relationshiptopatient.MinimumWidth = 6
        relationshiptopatient.Name = "relationshiptopatient"
        relationshiptopatient.ReadOnly = True
        relationshiptopatient.Width = 210
        ' 
        ' guardianname
        ' 
        guardianname.HeaderText = "NAME"
        guardianname.MinimumWidth = 6
        guardianname.Name = "guardianname"
        guardianname.ReadOnly = True
        guardianname.Width = 210
        ' 
        ' guardianbirthdate
        ' 
        guardianbirthdate.HeaderText = "BIRTHDATE"
        guardianbirthdate.MinimumWidth = 6
        guardianbirthdate.Name = "guardianbirthdate"
        guardianbirthdate.ReadOnly = True
        guardianbirthdate.Width = 210
        ' 
        ' guardianhomeno
        ' 
        guardianhomeno.HeaderText = "HOME PHONE NUMBER"
        guardianhomeno.MinimumWidth = 6
        guardianhomeno.Name = "guardianhomeno"
        guardianhomeno.ReadOnly = True
        guardianhomeno.Width = 360
        ' 
        ' guardiancellno
        ' 
        guardiancellno.HeaderText = "CELL PHONE NUMBER"
        guardiancellno.MinimumWidth = 6
        guardiancellno.Name = "guardiancellno"
        guardiancellno.ReadOnly = True
        guardiancellno.Width = 360
        ' 
        ' guardianemail
        ' 
        guardianemail.HeaderText = "EMAIL"
        guardianemail.MinimumWidth = 6
        guardianemail.Name = "guardianemail"
        guardianemail.ReadOnly = True
        guardianemail.Width = 210
        ' 
        ' guardianaddress
        ' 
        guardianaddress.HeaderText = "ADDRESS"
        guardianaddress.MinimumWidth = 6
        guardianaddress.Name = "guardianaddress"
        guardianaddress.ReadOnly = True
        guardianaddress.Width = 250
        ' 
        ' insuredTable
        ' 
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = Color.White
        DataGridViewCellStyle9.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle9.ForeColor = Color.Black
        DataGridViewCellStyle9.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle9.SelectionForeColor = Color.White
        insuredTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        insuredTable.BackgroundColor = Color.White
        insuredTable.BorderStyle = BorderStyle.None
        insuredTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle10.ForeColor = Color.Black
        DataGridViewCellStyle10.Padding = New Padding(20, 0, 0, 0)
        DataGridViewCellStyle10.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle10.SelectionForeColor = Color.White
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        insuredTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        insuredTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        insuredTable.Columns.AddRange(New DataGridViewColumn() {insuredno, relationshiptopatientins, nameins, ssino, birthdateins, homenoins, cellnoins, emailins, addressins})
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = Color.White
        DataGridViewCellStyle11.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle11.ForeColor = Color.Black
        DataGridViewCellStyle11.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle11.SelectionForeColor = Color.White
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        insuredTable.DefaultCellStyle = DataGridViewCellStyle11
        insuredTable.GridColor = Color.Black
        insuredTable.Location = New Point(72, 221)
        insuredTable.Name = "insuredTable"
        insuredTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = Color.White
        DataGridViewCellStyle12.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle12.ForeColor = Color.Black
        DataGridViewCellStyle12.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle12.SelectionForeColor = Color.White
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        insuredTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        insuredTable.RowHeadersWidth = 51
        insuredTable.RowTemplate.Height = 29
        insuredTable.Size = New Size(1295, 675)
        insuredTable.TabIndex = 2
        ' 
        ' insuredno
        ' 
        insuredno.HeaderText = "INSURED NO."
        insuredno.MinimumWidth = 6
        insuredno.Name = "insuredno"
        insuredno.ReadOnly = True
        insuredno.Width = 200
        ' 
        ' relationshiptopatientins
        ' 
        relationshiptopatientins.HeaderText = "RELATIONSHIP"
        relationshiptopatientins.MinimumWidth = 6
        relationshiptopatientins.Name = "relationshiptopatientins"
        relationshiptopatientins.ReadOnly = True
        relationshiptopatientins.Width = 210
        ' 
        ' nameins
        ' 
        nameins.HeaderText = "NAME"
        nameins.MinimumWidth = 6
        nameins.Name = "nameins"
        nameins.ReadOnly = True
        nameins.Width = 210
        ' 
        ' ssino
        ' 
        ssino.HeaderText = "SSINo."
        ssino.MinimumWidth = 6
        ssino.Name = "ssino"
        ssino.ReadOnly = True
        ssino.Width = 210
        ' 
        ' birthdateins
        ' 
        birthdateins.HeaderText = "BIRTHDATE"
        birthdateins.MinimumWidth = 6
        birthdateins.Name = "birthdateins"
        birthdateins.ReadOnly = True
        birthdateins.Width = 210
        ' 
        ' homenoins
        ' 
        homenoins.HeaderText = "HOME PHONE NUMBER"
        homenoins.MinimumWidth = 6
        homenoins.Name = "homenoins"
        homenoins.ReadOnly = True
        homenoins.Width = 360
        ' 
        ' cellnoins
        ' 
        cellnoins.HeaderText = "CELL PHONE NUMBER"
        cellnoins.MinimumWidth = 6
        cellnoins.Name = "cellnoins"
        cellnoins.ReadOnly = True
        cellnoins.Width = 360
        ' 
        ' emailins
        ' 
        emailins.HeaderText = "EMAIL"
        emailins.MinimumWidth = 6
        emailins.Name = "emailins"
        emailins.ReadOnly = True
        emailins.Width = 210
        ' 
        ' addressins
        ' 
        addressins.HeaderText = "ADDRESS"
        addressins.MinimumWidth = 6
        addressins.Name = "addressins"
        addressins.ReadOnly = True
        addressins.Width = 250
        ' 
        ' filterTable
        ' 
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = Color.White
        DataGridViewCellStyle13.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle13.ForeColor = Color.Black
        DataGridViewCellStyle13.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle13.SelectionForeColor = Color.White
        filterTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        filterTable.BackgroundColor = Color.White
        filterTable.BorderStyle = BorderStyle.None
        filterTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = Color.White
        DataGridViewCellStyle14.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle14.ForeColor = Color.Black
        DataGridViewCellStyle14.Padding = New Padding(20, 0, 0, 0)
        DataGridViewCellStyle14.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle14.SelectionForeColor = Color.White
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.False
        filterTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        filterTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        filterTable.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5})
        DataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = Color.White
        DataGridViewCellStyle15.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle15.ForeColor = Color.Black
        DataGridViewCellStyle15.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle15.SelectionForeColor = Color.White
        DataGridViewCellStyle15.WrapMode = DataGridViewTriState.False
        filterTable.DefaultCellStyle = DataGridViewCellStyle15
        filterTable.GridColor = Color.Black
        filterTable.Location = New Point(72, 221)
        filterTable.Name = "filterTable"
        filterTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = Color.White
        DataGridViewCellStyle16.Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle16.ForeColor = Color.Black
        DataGridViewCellStyle16.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle16.SelectionForeColor = Color.White
        DataGridViewCellStyle16.WrapMode = DataGridViewTriState.True
        filterTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        filterTable.RowHeadersWidth = 51
        filterTable.RowTemplate.Height = 29
        filterTable.Size = New Size(1295, 675)
        filterTable.TabIndex = 3
        ' 
        ' DataGridViewTextBoxColumn1
        ' 
        DataGridViewTextBoxColumn1.HeaderText = "PATIENT NO"
        DataGridViewTextBoxColumn1.MinimumWidth = 6
        DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        DataGridViewTextBoxColumn1.ReadOnly = True
        DataGridViewTextBoxColumn1.Width = 200
        ' 
        ' DataGridViewTextBoxColumn2
        ' 
        DataGridViewTextBoxColumn2.HeaderText = "FIRST NAME"
        DataGridViewTextBoxColumn2.MinimumWidth = 6
        DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        DataGridViewTextBoxColumn2.ReadOnly = True
        DataGridViewTextBoxColumn2.Width = 210
        ' 
        ' DataGridViewTextBoxColumn3
        ' 
        DataGridViewTextBoxColumn3.HeaderText = "LAST NAME"
        DataGridViewTextBoxColumn3.MinimumWidth = 6
        DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        DataGridViewTextBoxColumn3.ReadOnly = True
        DataGridViewTextBoxColumn3.Width = 210
        ' 
        ' DataGridViewTextBoxColumn4
        ' 
        DataGridViewTextBoxColumn4.HeaderText = "RELATIONSHIP"
        DataGridViewTextBoxColumn4.MinimumWidth = 6
        DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        DataGridViewTextBoxColumn4.ReadOnly = True
        DataGridViewTextBoxColumn4.Width = 210
        ' 
        ' DataGridViewTextBoxColumn5
        ' 
        DataGridViewTextBoxColumn5.HeaderText = "RELATIVE NAME"
        DataGridViewTextBoxColumn5.MinimumWidth = 6
        DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        DataGridViewTextBoxColumn5.ReadOnly = True
        DataGridViewTextBoxColumn5.Width = 410
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1801, 1538)
        Controls.Add(filterTable)
        Controls.Add(insuredTable)
        Controls.Add(guardianTable)
        Controls.Add(patientTable)
        Font = New Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Margin = New Padding(4)
        Name = "AdminDashboard"
        Text = "AdminDashboard"
        CType(patientTable, ComponentModel.ISupportInitialize).EndInit()
        CType(guardianTable, ComponentModel.ISupportInitialize).EndInit()
        CType(insuredTable, ComponentModel.ISupportInitialize).EndInit()
        CType(filterTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents patientTable As DataGridView
    Friend WithEvents patientno As DataGridViewTextBoxColumn
    Friend WithEvents datenow As DataGridViewTextBoxColumn
    Friend WithEvents firstname As DataGridViewTextBoxColumn
    Friend WithEvents middleinitial As DataGridViewTextBoxColumn
    Friend WithEvents lastname As DataGridViewTextBoxColumn
    Friend WithEvents birthdate As DataGridViewTextBoxColumn
    Friend WithEvents maritalstatus As DataGridViewTextBoxColumn
    Friend WithEvents homeno As DataGridViewTextBoxColumn
    Friend WithEvents cellno As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents streetaddress As DataGridViewTextBoxColumn
    Friend WithEvents barangay As DataGridViewTextBoxColumn
    Friend WithEvents city As DataGridViewTextBoxColumn
    Friend WithEvents zipcode As DataGridViewTextBoxColumn
    Friend WithEvents guardianTable As DataGridView
    Friend WithEvents guardianno As DataGridViewTextBoxColumn
    Friend WithEvents relationshiptopatient As DataGridViewTextBoxColumn
    Friend WithEvents guardianname As DataGridViewTextBoxColumn
    Friend WithEvents guardianbirthdate As DataGridViewTextBoxColumn
    Friend WithEvents guardianhomeno As DataGridViewTextBoxColumn
    Friend WithEvents guardiancellno As DataGridViewTextBoxColumn
    Friend WithEvents guardianemail As DataGridViewTextBoxColumn
    Friend WithEvents guardianaddress As DataGridViewTextBoxColumn
    Friend WithEvents insuredTable As DataGridView
    Friend WithEvents insuredno As DataGridViewTextBoxColumn
    Friend WithEvents relationshiptopatientins As DataGridViewTextBoxColumn
    Friend WithEvents nameins As DataGridViewTextBoxColumn
    Friend WithEvents ssino As DataGridViewTextBoxColumn
    Friend WithEvents birthdateins As DataGridViewTextBoxColumn
    Friend WithEvents homenoins As DataGridViewTextBoxColumn
    Friend WithEvents cellnoins As DataGridViewTextBoxColumn
    Friend WithEvents emailins As DataGridViewTextBoxColumn
    Friend WithEvents addressins As DataGridViewTextBoxColumn
    Friend WithEvents filterTable As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
