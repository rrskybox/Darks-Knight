<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDarksKnight
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
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.CheckBox1x1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2x2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3x3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4x4 = New System.Windows.Forms.CheckBox()
        Me.CCDTempBox = New System.Windows.Forms.NumericUpDown()
        Me.Check60 = New System.Windows.Forms.CheckBox()
        Me.Check90 = New System.Windows.Forms.CheckBox()
        Me.Check120 = New System.Windows.Forms.CheckBox()
        Me.Check180 = New System.Windows.Forms.CheckBox()
        Me.Check240 = New System.Windows.Forms.CheckBox()
        Me.Check300 = New System.Windows.Forms.CheckBox()
        Me.Check360 = New System.Windows.Forms.CheckBox()
        Me.Check420 = New System.Windows.Forms.CheckBox()
        Me.Check480 = New System.Windows.Forms.CheckBox()
        Me.Check1 = New System.Windows.Forms.CheckBox()
        Me.Check600 = New System.Windows.Forms.CheckBox()
        Me.Check540 = New System.Windows.Forms.CheckBox()
        Me.Check30 = New System.Windows.Forms.CheckBox()
        Me.Check10 = New System.Windows.Forms.CheckBox()
        Me.DarksCountBox = New System.Windows.Forms.NumericUpDown()
        Me.CheckOther = New System.Windows.Forms.CheckBox()
        Me.OtherExposureBox = New System.Windows.Forms.NumericUpDown()
        Me.BinningsBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TreeBox = New System.Windows.Forms.GroupBox()
        Me.OtherDirRadioButton = New System.Windows.Forms.RadioButton()
        Me.SaveTSXCheckBox = New System.Windows.Forms.RadioButton()
        Me.SavePreStackCheckBox = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BiasCount = New System.Windows.Forms.NumericUpDown()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.DestinationFolderDialog = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.CCDTempBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DarksCountBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherExposureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BinningsBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TreeBox.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.BiasCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(265, 474)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(84, 32)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'AbortButton
        '
        Me.AbortButton.Location = New System.Drawing.Point(145, 474)
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.Size = New System.Drawing.Size(84, 32)
        Me.AbortButton.TabIndex = 1
        Me.AbortButton.Text = "Abort"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(11, 474)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(84, 32)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'CheckBox1x1
        '
        Me.CheckBox1x1.AutoSize = True
        Me.CheckBox1x1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBox1x1.Location = New System.Drawing.Point(50, 22)
        Me.CheckBox1x1.Name = "CheckBox1x1"
        Me.CheckBox1x1.Size = New System.Drawing.Size(43, 17)
        Me.CheckBox1x1.TabIndex = 3
        Me.CheckBox1x1.Text = "1x1"
        Me.CheckBox1x1.UseVisualStyleBackColor = True
        '
        'CheckBox2x2
        '
        Me.CheckBox2x2.AutoSize = True
        Me.CheckBox2x2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBox2x2.Location = New System.Drawing.Point(50, 45)
        Me.CheckBox2x2.Name = "CheckBox2x2"
        Me.CheckBox2x2.Size = New System.Drawing.Size(43, 17)
        Me.CheckBox2x2.TabIndex = 4
        Me.CheckBox2x2.Text = "2x2"
        Me.CheckBox2x2.UseVisualStyleBackColor = True
        '
        'CheckBox3x3
        '
        Me.CheckBox3x3.AutoSize = True
        Me.CheckBox3x3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBox3x3.Location = New System.Drawing.Point(50, 68)
        Me.CheckBox3x3.Name = "CheckBox3x3"
        Me.CheckBox3x3.Size = New System.Drawing.Size(43, 17)
        Me.CheckBox3x3.TabIndex = 5
        Me.CheckBox3x3.Text = "3x3"
        Me.CheckBox3x3.UseVisualStyleBackColor = True
        '
        'CheckBox4x4
        '
        Me.CheckBox4x4.AutoSize = True
        Me.CheckBox4x4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBox4x4.Location = New System.Drawing.Point(50, 91)
        Me.CheckBox4x4.Name = "CheckBox4x4"
        Me.CheckBox4x4.Size = New System.Drawing.Size(43, 17)
        Me.CheckBox4x4.TabIndex = 6
        Me.CheckBox4x4.Text = "4x4"
        Me.CheckBox4x4.UseVisualStyleBackColor = True
        '
        'CCDTempBox
        '
        Me.CCDTempBox.Location = New System.Drawing.Point(49, 19)
        Me.CCDTempBox.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.CCDTempBox.Minimum = New Decimal(New Integer() {60, 0, 0, -2147483648})
        Me.CCDTempBox.Name = "CCDTempBox"
        Me.CCDTempBox.Size = New System.Drawing.Size(43, 20)
        Me.CCDTempBox.TabIndex = 7
        Me.CCDTempBox.Value = New Decimal(New Integer() {20, 0, 0, -2147483648})
        '
        'Check60
        '
        Me.Check60.AutoSize = True
        Me.Check60.ForeColor = System.Drawing.Color.White
        Me.Check60.Location = New System.Drawing.Point(19, 83)
        Me.Check60.Name = "Check60"
        Me.Check60.Size = New System.Drawing.Size(60, 17)
        Me.Check60.TabIndex = 9
        Me.Check60.Text = "60 Sec"
        Me.Check60.UseVisualStyleBackColor = True
        '
        'Check90
        '
        Me.Check90.AutoSize = True
        Me.Check90.ForeColor = System.Drawing.Color.White
        Me.Check90.Location = New System.Drawing.Point(19, 104)
        Me.Check90.Name = "Check90"
        Me.Check90.Size = New System.Drawing.Size(60, 17)
        Me.Check90.TabIndex = 10
        Me.Check90.Text = "90 Sec"
        Me.Check90.UseVisualStyleBackColor = True
        '
        'Check120
        '
        Me.Check120.AutoSize = True
        Me.Check120.ForeColor = System.Drawing.Color.White
        Me.Check120.Location = New System.Drawing.Point(19, 125)
        Me.Check120.Name = "Check120"
        Me.Check120.Size = New System.Drawing.Size(66, 17)
        Me.Check120.TabIndex = 11
        Me.Check120.Text = "120 Sec"
        Me.Check120.UseVisualStyleBackColor = True
        '
        'Check180
        '
        Me.Check180.AutoSize = True
        Me.Check180.ForeColor = System.Drawing.Color.White
        Me.Check180.Location = New System.Drawing.Point(19, 146)
        Me.Check180.Name = "Check180"
        Me.Check180.Size = New System.Drawing.Size(66, 17)
        Me.Check180.TabIndex = 12
        Me.Check180.Text = "180 Sec"
        Me.Check180.UseVisualStyleBackColor = True
        '
        'Check240
        '
        Me.Check240.AutoSize = True
        Me.Check240.ForeColor = System.Drawing.Color.White
        Me.Check240.Location = New System.Drawing.Point(19, 167)
        Me.Check240.Name = "Check240"
        Me.Check240.Size = New System.Drawing.Size(66, 17)
        Me.Check240.TabIndex = 13
        Me.Check240.Text = "240 Sec"
        Me.Check240.UseVisualStyleBackColor = True
        '
        'Check300
        '
        Me.Check300.AutoSize = True
        Me.Check300.ForeColor = System.Drawing.Color.White
        Me.Check300.Location = New System.Drawing.Point(19, 188)
        Me.Check300.Name = "Check300"
        Me.Check300.Size = New System.Drawing.Size(66, 17)
        Me.Check300.TabIndex = 14
        Me.Check300.Text = "300 Sec"
        Me.Check300.UseVisualStyleBackColor = True
        '
        'Check360
        '
        Me.Check360.AutoSize = True
        Me.Check360.ForeColor = System.Drawing.Color.White
        Me.Check360.Location = New System.Drawing.Point(19, 209)
        Me.Check360.Name = "Check360"
        Me.Check360.Size = New System.Drawing.Size(66, 17)
        Me.Check360.TabIndex = 15
        Me.Check360.Text = "360 Sec"
        Me.Check360.UseVisualStyleBackColor = True
        '
        'Check420
        '
        Me.Check420.AutoSize = True
        Me.Check420.ForeColor = System.Drawing.Color.White
        Me.Check420.Location = New System.Drawing.Point(19, 230)
        Me.Check420.Name = "Check420"
        Me.Check420.Size = New System.Drawing.Size(66, 17)
        Me.Check420.TabIndex = 16
        Me.Check420.Text = "420 Sec"
        Me.Check420.UseVisualStyleBackColor = True
        '
        'Check480
        '
        Me.Check480.AutoSize = True
        Me.Check480.ForeColor = System.Drawing.Color.White
        Me.Check480.Location = New System.Drawing.Point(19, 251)
        Me.Check480.Name = "Check480"
        Me.Check480.Size = New System.Drawing.Size(66, 17)
        Me.Check480.TabIndex = 17
        Me.Check480.Text = "480 Sec"
        Me.Check480.UseVisualStyleBackColor = True
        '
        'Check1
        '
        Me.Check1.AutoSize = True
        Me.Check1.ForeColor = System.Drawing.Color.White
        Me.Check1.Location = New System.Drawing.Point(19, 21)
        Me.Check1.Name = "Check1"
        Me.Check1.Size = New System.Drawing.Size(54, 17)
        Me.Check1.TabIndex = 18
        Me.Check1.Text = "1 Sec"
        Me.Check1.UseVisualStyleBackColor = True
        '
        'Check600
        '
        Me.Check600.AutoSize = True
        Me.Check600.ForeColor = System.Drawing.Color.White
        Me.Check600.Location = New System.Drawing.Point(19, 293)
        Me.Check600.Name = "Check600"
        Me.Check600.Size = New System.Drawing.Size(66, 17)
        Me.Check600.TabIndex = 19
        Me.Check600.Text = "600 Sec"
        Me.Check600.UseVisualStyleBackColor = True
        '
        'Check540
        '
        Me.Check540.AutoSize = True
        Me.Check540.ForeColor = System.Drawing.Color.White
        Me.Check540.Location = New System.Drawing.Point(19, 272)
        Me.Check540.Name = "Check540"
        Me.Check540.Size = New System.Drawing.Size(66, 17)
        Me.Check540.TabIndex = 20
        Me.Check540.Text = "540 Sec"
        Me.Check540.UseVisualStyleBackColor = True
        '
        'Check30
        '
        Me.Check30.AutoSize = True
        Me.Check30.ForeColor = System.Drawing.Color.White
        Me.Check30.Location = New System.Drawing.Point(19, 63)
        Me.Check30.Name = "Check30"
        Me.Check30.Size = New System.Drawing.Size(60, 17)
        Me.Check30.TabIndex = 21
        Me.Check30.Text = "30 Sec"
        Me.Check30.UseVisualStyleBackColor = True
        '
        'Check10
        '
        Me.Check10.AutoSize = True
        Me.Check10.ForeColor = System.Drawing.Color.White
        Me.Check10.Location = New System.Drawing.Point(19, 42)
        Me.Check10.Name = "Check10"
        Me.Check10.Size = New System.Drawing.Size(60, 17)
        Me.Check10.TabIndex = 22
        Me.Check10.Text = "10 Sec"
        Me.Check10.UseVisualStyleBackColor = True
        '
        'DarksCountBox
        '
        Me.DarksCountBox.Location = New System.Drawing.Point(50, 18)
        Me.DarksCountBox.Name = "DarksCountBox"
        Me.DarksCountBox.Size = New System.Drawing.Size(43, 20)
        Me.DarksCountBox.TabIndex = 23
        Me.DarksCountBox.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'CheckOther
        '
        Me.CheckOther.AutoSize = True
        Me.CheckOther.ForeColor = System.Drawing.Color.White
        Me.CheckOther.Location = New System.Drawing.Point(19, 317)
        Me.CheckOther.Name = "CheckOther"
        Me.CheckOther.Size = New System.Drawing.Size(74, 17)
        Me.CheckOther.TabIndex = 25
        Me.CheckOther.Text = "Other Sec"
        Me.CheckOther.UseVisualStyleBackColor = True
        '
        'OtherExposureBox
        '
        Me.OtherExposureBox.Location = New System.Drawing.Point(101, 317)
        Me.OtherExposureBox.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.OtherExposureBox.Name = "OtherExposureBox"
        Me.OtherExposureBox.Size = New System.Drawing.Size(54, 20)
        Me.OtherExposureBox.TabIndex = 26
        Me.OtherExposureBox.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'BinningsBox
        '
        Me.BinningsBox.Controls.Add(Me.CheckBox4x4)
        Me.BinningsBox.Controls.Add(Me.CheckBox3x3)
        Me.BinningsBox.Controls.Add(Me.CheckBox2x2)
        Me.BinningsBox.Controls.Add(Me.CheckBox1x1)
        Me.BinningsBox.ForeColor = System.Drawing.Color.White
        Me.BinningsBox.Location = New System.Drawing.Point(206, 71)
        Me.BinningsBox.Name = "BinningsBox"
        Me.BinningsBox.Size = New System.Drawing.Size(142, 125)
        Me.BinningsBox.TabIndex = 27
        Me.BinningsBox.TabStop = False
        Me.BinningsBox.Text = "Binnings"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CCDTempBox)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(207, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(142, 48)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CCD Temperature"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DarksCountBox)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(206, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 44)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Number of Darks (each)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Check600)
        Me.GroupBox3.Controls.Add(Me.Check60)
        Me.GroupBox3.Controls.Add(Me.Check90)
        Me.GroupBox3.Controls.Add(Me.OtherExposureBox)
        Me.GroupBox3.Controls.Add(Me.Check120)
        Me.GroupBox3.Controls.Add(Me.CheckOther)
        Me.GroupBox3.Controls.Add(Me.Check180)
        Me.GroupBox3.Controls.Add(Me.Check10)
        Me.GroupBox3.Controls.Add(Me.Check240)
        Me.GroupBox3.Controls.Add(Me.Check30)
        Me.GroupBox3.Controls.Add(Me.Check300)
        Me.GroupBox3.Controls.Add(Me.Check540)
        Me.GroupBox3.Controls.Add(Me.Check360)
        Me.GroupBox3.Controls.Add(Me.Check420)
        Me.GroupBox3.Controls.Add(Me.Check1)
        Me.GroupBox3.Controls.Add(Me.Check480)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(10, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 366)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Exposures"
        '
        'TreeBox
        '
        Me.TreeBox.Controls.Add(Me.OtherDirRadioButton)
        Me.TreeBox.Controls.Add(Me.SaveTSXCheckBox)
        Me.TreeBox.Controls.Add(Me.SavePreStackCheckBox)
        Me.TreeBox.ForeColor = System.Drawing.Color.White
        Me.TreeBox.Location = New System.Drawing.Point(206, 293)
        Me.TreeBox.Name = "TreeBox"
        Me.TreeBox.Size = New System.Drawing.Size(142, 93)
        Me.TreeBox.TabIndex = 31
        Me.TreeBox.TabStop = False
        Me.TreeBox.Text = "Save Method"
        '
        'OtherDirRadioButton
        '
        Me.OtherDirRadioButton.AutoSize = True
        Me.OtherDirRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.OtherDirRadioButton.Location = New System.Drawing.Point(17, 65)
        Me.OtherDirRadioButton.Name = "OtherDirRadioButton"
        Me.OtherDirRadioButton.Size = New System.Drawing.Size(96, 17)
        Me.OtherDirRadioButton.TabIndex = 2
        Me.OtherDirRadioButton.Text = "Other Directory"
        Me.OtherDirRadioButton.UseVisualStyleBackColor = True
        '
        'SaveTSXCheckBox
        '
        Me.SaveTSXCheckBox.AutoSize = True
        Me.SaveTSXCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.SaveTSXCheckBox.Location = New System.Drawing.Point(17, 42)
        Me.SaveTSXCheckBox.Name = "SaveTSXCheckBox"
        Me.SaveTSXCheckBox.Size = New System.Drawing.Size(46, 17)
        Me.SaveTSXCheckBox.TabIndex = 1
        Me.SaveTSXCheckBox.Text = "TSX"
        Me.SaveTSXCheckBox.UseVisualStyleBackColor = True
        '
        'SavePreStackCheckBox
        '
        Me.SavePreStackCheckBox.AutoSize = True
        Me.SavePreStackCheckBox.Checked = True
        Me.SavePreStackCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.SavePreStackCheckBox.Location = New System.Drawing.Point(17, 19)
        Me.SavePreStackCheckBox.Name = "SavePreStackCheckBox"
        Me.SavePreStackCheckBox.Size = New System.Drawing.Size(69, 17)
        Me.SavePreStackCheckBox.TabIndex = 0
        Me.SavePreStackCheckBox.TabStop = True
        Me.SavePreStackCheckBox.Text = "PreStack"
        Me.SavePreStackCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BiasCount)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(207, 246)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(142, 44)
        Me.GroupBox4.TabIndex = 30
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Number of Bias"
        '
        'BiasCount
        '
        Me.BiasCount.Location = New System.Drawing.Point(49, 19)
        Me.BiasCount.Name = "BiasCount"
        Me.BiasCount.Size = New System.Drawing.Size(43, 20)
        Me.BiasCount.TabIndex = 23
        '
        'StatusBox
        '
        Me.StatusBox.Location = New System.Drawing.Point(11, 402)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(338, 55)
        Me.StatusBox.TabIndex = 32
        '
        'FormDarksKnight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(364, 524)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TreeBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BinningsBox)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "FormDarksKnight"
        Me.Text = "Darks Knight V1.4"
        CType(Me.CCDTempBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DarksCountBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherExposureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BinningsBox.ResumeLayout(False)
        Me.BinningsBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TreeBox.ResumeLayout(False)
        Me.TreeBox.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.BiasCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents AbortButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents CheckBox1x1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2x2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3x3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4x4 As System.Windows.Forms.CheckBox
    Friend WithEvents CCDTempBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Check60 As System.Windows.Forms.CheckBox
    Friend WithEvents Check90 As System.Windows.Forms.CheckBox
    Friend WithEvents Check120 As System.Windows.Forms.CheckBox
    Friend WithEvents Check180 As System.Windows.Forms.CheckBox
    Friend WithEvents Check240 As System.Windows.Forms.CheckBox
    Friend WithEvents Check300 As System.Windows.Forms.CheckBox
    Friend WithEvents Check360 As System.Windows.Forms.CheckBox
    Friend WithEvents Check420 As System.Windows.Forms.CheckBox
    Friend WithEvents Check480 As System.Windows.Forms.CheckBox
    Friend WithEvents Check1 As System.Windows.Forms.CheckBox
    Friend WithEvents Check600 As System.Windows.Forms.CheckBox
    Friend WithEvents Check540 As System.Windows.Forms.CheckBox
    Friend WithEvents Check30 As System.Windows.Forms.CheckBox
    Friend WithEvents Check10 As System.Windows.Forms.CheckBox
    Friend WithEvents DarksCountBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckOther As System.Windows.Forms.CheckBox
    Friend WithEvents OtherExposureBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents BinningsBox As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TreeBox As System.Windows.Forms.GroupBox
    Friend WithEvents SaveTSXCheckBox As System.Windows.Forms.RadioButton
    Friend WithEvents SavePreStackCheckBox As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BiasCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents StatusBox As TextBox
    Friend WithEvents OtherDirRadioButton As RadioButton
    Friend WithEvents DestinationFolderDialog As FolderBrowserDialog
End Class
