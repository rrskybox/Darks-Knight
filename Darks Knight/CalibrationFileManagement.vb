#Const TSX_32 = False

Public Class CalibrationFileManagement
    'Class for managing the storage and retrieval (future) calibration files, including darks, flats and bias
    '
    'The dark files are stored in a directory tree.  The root is a directory in the user document directory
    '  called "PreStack", which I've used for other TSX miniapps.  Within this directory, the darks library
    '  directory named "Darks" (created if doesn't exist).  
    '
    'The darks library is structured by duration (exposure), then binning (1x1, 2x2, etc), then date.
    'This overall structure is created and/or verified upon launch.  The date directory associated with each
    '  selected checkbox is created or verified when that dark is created and stored.
    '
    'Individaul FITS filename is composed of a string "Dark"."B"<binning>."E"<exposure in sec>."T"<temperature in degrees celsius>.a sequence number
    'The file management functions are broken into three methods.  a New creation of this class verifies and/or creates the
    '  base file tree structure down to the Darks directory, populating the public variable CalPath with that path.  
    '  DarkFilePath() figures out the path to a target directory given the
    '  exposure, binning and date.  DarkFileStore() stores a file given the path and a filename.

    Const UserPreStackDirectory = "\Documents\PreStack"
    Const DarksDirectory = "\Darks"
    Const BiasDirectory = "\Bias"

    Private SeqNum As Integer
    Private CalPath As String
    Private DarkCalPath As String
    Private BiasCalPath As String
    Private LocalBinPath As String
    Private LocalExpPath As String
    Private LocalDatePath As String
    Private ImageCCDTemp As String

    'Enumeration are here to ease binning
    Public Enum CalBin As Integer
        cb1x1
        cb2x2
        cb3x3
        cb4x4
    End Enum

    Public Sub New(usePreStackDir As Boolean)
        Dim existresult As Boolean
        If (usePreStackDir) Then
            'Set Calibration file path, creating necessary directories, as you go.
            CalPath = "C:\Users\" & System.Environment.UserName & UserPreStackDirectory
        Else
            'Set path for darks directory
            CalPath = My.Settings.DestinationDir
            'Set Calibration file path, creating necessary directories, as you go.
        End If
        'Create the base directory, if none exists
        existresult = My.Computer.FileSystem.DirectoryExists(CalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(CalPath)
        End If

        'Create the darks directory, if none exists
        'Set the Darks base directory
        DarkCalPath = CalPath + DarksDirectory
        existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath)
        End If

        'Create the bias directory, if none exists
        'Set the Bias base directory
        BiasCalPath = CalPath + BiasDirectory
        existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath)
        End If

        'Set date string for file directory
        LocalDatePath = DateTime.Today.ToString("ddMMMyyyy")
        FormDarksKnight.StatusBox.Text += "Created Calibration Directory: " & LocalDatePath + vbCrLf

        'Set the sequence number
        SeqNum = 0
        'All done, ready to go.
        Return
    End Sub

    Public Sub DarkImageStore()
        'Stores the current active TSX image as designated dark file
        'Step A:  attach the active image and generate directory and file name strings from the FITS information
        '  Three strings are needed:  one for exposure, one for the binning, one for temperature
#If TSX_32 Then
        Dim tsxi = CreateObject("TheSkyX.ccdsoftImage")
#Else
        Dim tsxi = CreateObject("TheSky64.ccdsoftImage")
#End If
        Dim attachresult = tsxi.AttachToActiveImager()
        LocalExpPath = Convert.ToString(tsxi.FITSKeyword("EXPTIME"))
        LocalBinPath = Convert.ToString(tsxi.FITSKeyword("XBINNING")) & "X" & Convert.ToString(tsxi.FITSKeyword("YBINNING"))
        ImageCCDTemp = Convert.ToString(tsxi.FITSKeyword("SET-TEMP"))
        'Step B:  make sure the directory tree exists, create it if it doesn't
        Dim existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath & "\" & LocalBinPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath & "\" & LocalBinPath)
        End If
        existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath & "\" & LocalBinPath & "\" & LocalExpPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath & "\" & LocalBinPath & "\" & LocalExpPath)
        End If   'Open TSX object
        existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath & "\" & LocalBinPath & "\" & "\" & LocalExpPath & LocalDatePath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath & "\" & LocalBinPath & "\" & LocalExpPath & "\" & LocalDatePath)
        End If
        'Step
        Dim darkfilename = "Dark." & "B" & LocalBinPath & ".E" & LocalExpPath & ".T" & ImageCCDTemp & "." & Str(SeqNum)
        'Tell TSX what the filepath is going to be
        Dim tsxPath = DarkCalPath & "\" & LocalBinPath & "\" & LocalExpPath & "\" & LocalDatePath & "\" & darkfilename & ".FITS"
        tsxi.path = tsxPath
        FormDarksKnight.StatusBox.AppendText("Writing: " & tsxPath & vbCrLf)
        FormDarksKnight.Show()
        Dim savestatus = tsxi.save()
        'increment sequence number
        SeqNum += 1
        Return
    End Sub

    Public Sub BiasImageStore()
        'Stores the current active TSX image as designated bias file
        'Step A:  attach the active image and generate directory and file name strings from the FITS information
        '  Two strings are needed:  one for one for the binning, one for temperature
#If (TSX_32) Then
        Dim tsxi = CreateObject("TheSkyX.ccdsoftImage")
#Else
        Dim tsxi = CreateObject("TheSky64.ccdsoftImage")
#End If
        Dim attachresult = tsxi.AttachToActiveImager()
        LocalBinPath = Convert.ToString(tsxi.FITSKeyword("XBINNING")) & "X" & Convert.ToString(tsxi.FITSKeyword("YBINNING"))
        ImageCCDTemp = Convert.ToString(tsxi.FITSKeyword("SET-TEMP"))
        'Step B:  make sure the directory tree exists, create it if it doesn't
        Dim existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath & "\" & LocalBinPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath & "\" & LocalBinPath)
        End If
        existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath & "\" & LocalBinPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath & "\" & LocalBinPath)
        End If   'Open TSX object
        existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath & "\" & LocalBinPath & "\" & LocalDatePath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath & "\" & LocalBinPath & "\" & LocalDatePath)
        End If
        'Step
        Dim biasfilename = "Bias." & "B" & LocalBinPath & ".T" & ImageCCDTemp & "." & Str(SeqNum)
        'Tell TSX what the filepath is going to be
        Dim tsxPath = BiasCalPath & "\" & LocalBinPath & "\" & LocalDatePath & "\" & biasfilename & ".FITS"
        tsxi.path = tsxPath
        FormDarksKnight.StatusBox.AppendText("Writing: " & tsxPath & vbCrLf)
        Dim savestatus = tsxi.save()
        'increment sequence number
        SeqNum += 1
        Return
    End Sub

End Class
