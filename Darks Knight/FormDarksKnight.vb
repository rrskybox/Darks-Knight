#Const TSX_32 = False

Public Class FormDarksKnight

    'This application uses TSX to take a series of dark frames for a dark frame library
    '
    'The RunDarks procedure launches TSX (if not already open), connects to the camera and
    '  sets up the temperature and autosave
    '
    'The private method "ImageDark" takes the dark image, waits for completion while monitoring
    '  for an abort.  If aborted, the frame is aborted and the sequence ends.
    '
    'The dark files are stored in a folder tree.  The root is a folder in the user document folder
    '  called "PreStack", which is used for other TsxToolKit Miniapps.  Within this folder, a folder
    '  "Calibrations" is used (created if doesn't exist). Within this folder will be the darks library
    '  folder named "Darks" (created if doesn't exist).  
    '
    'The darks library is structured by duration (exposure), then binning (1x1, 2x2, etc), then date.
    'This overall structure is created and/or verified upon launch.  The date folder associated with each
    '  selected checkbox is created or verified when that dark is created and stored.
    '
    'The file management functions are broken into three methods.  CalTreeCheck() verifies and/or creates the
    '  base file tree structure.  DarkFilePath() figures out the path to a target directory given the
    '  exposure, binning and date.  DarkFileStore() stores a file given the path and a filename.
    '
    'Author: Rick McAlister 3/1/16
    '
    'Rev 1 -- Reconfigured for publishing as TSXToolkit (5/1/16)
    '
    'Rev 2 -- The camera temperature cool down changed to happen at "Start" rather than at load (5/22/16)
    '
    'Rev 3 -- Added the capability to shoot bias frames at the same temperature
    '
    'Rev 4 -- Found and fixed a number of problems with using an "Other" directory, and fixed the conditional compile for TSX 32 and 64

    Public abortflag As Boolean = False
    Public totalreps As Integer
    Public autosavestate
    Public framestate
    Public delaystate
    Public binningXstate
    Public binningYstate
    Public exposurestate
    Public settempstate
    'Save folder structure pointer
    Public CalDB As Object

    Private Sub DarksKnightForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        'Prep the form title
        Try
            My.Forms.FormDarksKnight.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Catch
            My.Forms.FormDarksKnight.Text = " in Debug"  'probably In debug, no version info available
        End Try
        MyBase.Text = "Darks Knight V " + My.Forms.FormDarksKnight.Text

        'Save the current camera state,
        'Then get the camera cooling and set up the file structure

#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If

        Try
            tsx_cc.Connect()
        Catch ex As Exception
            MsgBox("No Camera Selected in TSX")
        End Try
        'TSX camera simulator throws an exception on AutoSave so handle it
        Try
            autosavestate = tsx_cc.AutoSave()
        Catch ex As Exception
            'Just breeze on by
        End Try
        delaystate = tsx_cc.Delay
        binningXstate = tsx_cc.BinX()
        binningYstate = tsx_cc.BinY()
        exposurestate = tsx_cc.ExposureTime()
        settempstate = tsx_cc.TemperatureSetPoint()
        framestate = tsx_cc.Frame
        tsx_cc = Nothing
        'Get folder path defaults set up, if necessary
        '           ssdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + ScanFolderName;

        If (My.Settings.DestinationDir = "") Then
            My.Settings.DestinationDir = "C:\Users\" & System.Environment.UserName
        End If
        Return
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If
        'TSX camera simulator throws an exception on AutoSave so handle it
        Try
            tsx_cc.AutoSave() = autosavestate
        Catch ex As Exception
            'Just breeze on by
        End Try
        tsx_cc.Delay = delaystate
        tsx_cc.BinX() = binningXstate
        tsx_cc.BinY() = binningYstate
        tsx_cc.ExposureTime() = exposurestate
        tsx_cc.TemperatureSetPoint() = settempstate
        tsx_cc.Frame = framestate
        tsx_cc = Nothing
        Close()
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        'Set abort flag
        abortflag = True
        Return
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        'Takes darks according to each of the exposure and bin selections for the set repetitions
        'Sets the color of the font to green when each selection is completed.
        'For each of the binnings, for each of the times, take the repetition number of darks
        'Start by choose save method and setting temperature, then waiting for it to get close (within 10%)
        '
        'When darks are done, take bias frames, if any
        StartButton.BackColor = Color.LightSalmon
        If SaveTSXCheckBox.Checked Then
            UseAutoSave()
            SaveTSXCheckBox.ForeColor = Color.LightGreen
        ElseIf (SavePreStackCheckBox.Checked) Then
            CalDB = New CalibrationFileManagement(True)
            SavePreStackCheckBox.ForeColor = Color.LightGreen
        Else
            CalDB = New CalibrationFileManagement(False)
            OtherDirRadioButton.ForeColor = Color.LightGreen
        End If

        SetCCDTemperature()

        If CheckBox1x1.Checked Then
            CheckBox1x1.ForeColor = Color.Red
            SetBinning(1, 1)
            RunExposures()
            CheckBox1x1.ForeColor = Color.LightGreen
        End If
        If CheckBox2x2.Checked Then
            CheckBox2x2.ForeColor = Color.Red
            SetBinning(2, 2)
            RunExposures()
            CheckBox2x2.ForeColor = Color.LightGreen
        End If
        If CheckBox3x3.Checked Then
            CheckBox3x3.ForeColor = Color.Red
            SetBinning(3, 3)
            RunExposures()
            CheckBox3x3.ForeColor = Color.LightGreen
        End If
        If CheckBox4x4.Checked Then
            CheckBox4x4.ForeColor = Color.Red
            SetBinning(4, 4)
            RunExposures()
            CheckBox4x4.ForeColor = Color.LightGreen
        End If
        StartButton.BackColor = Color.LightGreen
        Return
    End Sub

    Private Sub SetBinning(binx As Integer, biny As Integer)
        'Method to set TSX CAO binning state
#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If
        tsx_cc.BinX = binx
        tsx_cc.BinY = biny
        tsx_cc = Nothing
        Return
    End Sub

    Private Sub RepeatDark(reps, exposure)
        'This is the repeat loop for a given exposure repetitions
        totalreps = DarksCountBox.Value
        Dim i As Integer
        'Change the form count box color
        DarksCountBox.ForeColor = Color.Red
        'Set the count on the form
        For i = (reps - 1) To 0 Step -1
            ImageDark(exposure)
            If abortflag Then
                Return
            End If
            'Decrement count
            DarksCountBox.Value -= 1
        Next
        DarksCountBox.Value = totalreps
        'Change the form count box color
        DarksCountBox.ForeColor = Color.LightGreen
        Return
    End Sub

    Private Sub ImageDark(exposure As Double)
        'Take a dark image at the given exposure length and binning at the temperature
        '  assumes that binning and xxx have already been set correctly

        'Image and save dark frames
        '   Turn on autosave
        '   Set exposure length
        '   Set for Dark frame type
        '   Set for 0 second delay
        '   Set for no image reduction
        '   Set for asynchronous execution
        '   For the number of repetions:
        '       Start exposure and wait until completed or aborted
        'Upon completion, store the image file in the library 
        '   Clean up mess and return

#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If

        'turn off TSX autosave if using the PreStack file management
        If SavePreStackCheckBox.Checked Then
            tsx_cc.autosaveon = 0
        End If

        tsx_cc.ExposureTime = exposure
        ' tsx_cc.ExposureTime = exposure
        tsx_cc.Frame = TheSky64Lib.ccdsoftImageFrame.cdDark
        tsx_cc.Delay = 0
        tsx_cc.Asynchronous = True
        tsx_cc.ImageReduction = TheSky64Lib.ccdsoftImageReduction.cdNone
        tsx_cc.TakeImage()
        Do While tsx_cc.state = TheSky64Lib.ccdsoftCameraState.cdStateTakePicture
            Application.DoEvents()
            If abortflag Then
                tsx_cc.Abort()
                tsx_cc = Nothing
                Return
            End If
            System.Threading.Thread.Sleep(1000)
        Loop
        'Save the using the PreStack manager if checked,
        '  Otherwise TSX will do what TSX does.
        If Not SaveTSXCheckBox.Checked Then
            CalDB.DarkImageStore()
        End If
        tsx_cc = Nothing
        Return
    End Sub

    Private Sub RepeatBias(reps)
        'This is the repeat loop for a given exposure repetitions
        Const biasexposure = 0.001
        totalreps = BiasCountBox.Value
        Dim i As Integer
        'Change the form count box color
        BiasCountBox.ForeColor = Color.Red
        'Set the count on the form
        For i = (reps - 1) To 0 Step -1
            ImageBias(biasexposure)
            If abortflag Then
                Return
            End If
            'Decrement count
            BiasCountBox.Value -= 1
        Next
        BiasCountBox.Value = totalreps
        'Change the form count box color
        BiasCountBox.ForeColor = Color.LightGreen
        Return
    End Sub

    Private Sub ImageBias(exposure As Double)
        'Take a bias image at the given exposure length and binning at the temperature
        '  assumes that binning and xxx have already been set correctly

        'Image and save bias frames
        '   Turn on autosave, if TSX save chosen
        '   Set exposure length
        '   Set for Bias frame type
        '   Set for 0 second delay
        '   Set for no image reduction
        '   Set for asynchronous execution
        '   For the number of repetions:
        '       Start exposure and wait until completed or aborted
        'Upon completion, store the image file in the library 
        '   Clean up mess and return

#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If

        'turn off TSX autosave if using the PreStack file management
        If SavePreStackCheckBox.Checked Then
            tsx_cc.autosaveon = 0
        End If

        tsx_cc.ExposureTime = exposure
        ' tsx_cc.ExposureTime = exposure
        tsx_cc.Frame = TheSky64Lib.ccdsoftImageFrame.cdBias
        tsx_cc.Delay = 0
        tsx_cc.Asynchronous = True
        tsx_cc.ImageReduction = TheSky64Lib.ccdsoftImageReduction.cdNone
        tsx_cc.TakeImage()
        Do While tsx_cc.state = TheSky64Lib.ccdsoftCameraState.cdStateTakePicture
            Application.DoEvents()
            If abortflag Then
                tsx_cc.Abort()
                tsx_cc = Nothing
                Return
            End If
            System.Threading.Thread.Sleep(1000)
        Loop
        'Save the using the PreStack manager if checked,
        '  Otherwise TSX will do what TSX does.
        If Not SaveTSXCheckBox.Checked Then
            CalDB.BiasImageStore()
        End If
        tsx_cc = Nothing
        Return
    End Sub

    Private Sub SetCCDTemperature()
        'Set new temperature for camera and wait until the ccd gets to within 90% of that value
#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If
        Try
            tsx_cc.Connect()
        Catch ex As Exception
            Return
        End Try
        StatusBox.Text += "Cooling camera to " + CCDTempBox.Value.ToString("0") & vbCrLf
        Show()

        tsx_cc.TemperatureSetPoint = Convert.ToDouble(CCDTempBox.Value)
        tsx_cc.RegulateTemperature = True
        Do While (tsx_cc.TemperatureSetPoint() * 0.9) < tsx_cc.Temperature()
            CCDTempBox.ForeColor = Color.Red
            CCDTempBox.Value = tsx_cc.Temperature()
            System.Threading.Thread.Sleep(1000)
        Loop
        'Wait one minute for the temperature to settle
        'Blink the temperature number will waiting
        StatusBox.Text += "At temperature. Waiting to settle down" & vbCrLf
        Show()
        For i As Integer = 1 To 2
            CCDTempBox.ForeColor = Color.Yellow
            System.Threading.Thread.Sleep(1000)
            CCDTempBox.ForeColor = Color.Green
            System.Threading.Thread.Sleep(1000)
        Next
        CCDTempBox.Value = tsx_cc.TemperatureSetPoint()
        CCDTempBox.ForeColor = Color.LightGreen
        tsx_cc = Nothing
        Return
    End Sub

    Private Sub RunExposures()
        If Check1.Checked Then
            Check1.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 1)
            Check1.ForeColor = Color.LightGreen
        End If
        If Check3.Checked Then
            Check3.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 3)
            Check3.ForeColor = Color.LightGreen
        End If
        If Check10.Checked Then
            Check10.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 10)
            Check10.ForeColor = Color.LightGreen
        End If
        If Check30.Checked Then
            Check30.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 30)
            Check30.ForeColor = Color.LightGreen
        End If
        If Check60.Checked Then
            Check60.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 60)
            Check60.ForeColor = Color.LightGreen
        End If
        If Check90.Checked Then
            Check90.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 90)
            Check90.ForeColor = Color.LightGreen
        End If
        If Check120.Checked Then
            Check120.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 120)
            Check120.ForeColor = Color.LightGreen
        End If
        If Check180.Checked Then
            Check180.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 180)
            Check180.ForeColor = Color.LightGreen
        End If
        If Check240.Checked Then
            Check240.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 240)
            Check240.ForeColor = Color.LightGreen
        End If
        If Check300.Checked Then
            Check300.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 300)
            Check300.ForeColor = Color.LightGreen
        End If
        If Check360.Checked Then
            Check360.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 360)
            Check360.ForeColor = Color.LightGreen
        End If
        If Check480.Checked Then
            Check480.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 480)
            Check480.ForeColor = Color.LightGreen
        End If
        If Check540.Checked Then
            Check540.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 540)
            Check540.ForeColor = Color.LightGreen
        End If
        If Check600.Checked Then
            Check600.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, 600)
            Check600.ForeColor = Color.LightGreen
        End If
        If CheckOther.Checked Then
            CheckOther.ForeColor = Color.Red
            RepeatDark(DarksCountBox.Value, Int(OtherExposureBox.Value))
            CheckOther.ForeColor = Color.LightGreen
        End If
        If BiasCountBox.Value > 0 Then
            RepeatBias(BiasCountBox.Value)
        End If

        Return
    End Sub

    Private Sub UseAutoSave()
#If TSX_32 Then
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftcamera")
#Else
        Dim tsx_cc = CreateObject("TheSky64.ccdsoftcamera")
#End If
        tsx_cc.AutoSaveOn = 1
        Return
    End Sub

    Private Sub DDriveRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OtherDirRadioButton.CheckedChanged

        If (OtherDirRadioButton.Checked) Then
            If (DestinationFolderDialog().ShowDialog() = DialogResult.OK) Then
                My.Settings.DestinationDir = DestinationFolderDialog().SelectedPath
            End If
        End If
        Return
    End Sub

End Class

