Public Class CalibrationFileManagement
    'Class for managing the storage and retrieval (future) calibration files, including darks, flats and bias
    '
    'The dark files are stored in a folder tree.  The root is a folder in the user document folder
    '  called "PreStack", which I've used for other TSX miniapps.  Within this folder, the darks library
    '  folder named "Darks" (created if doesn't exist).  
    '
    'The darks library is structured by duration (exposure), then binning (1x1, 2x2, etc), then date.
    'This overall structure is created and/or verified upon launch.  The date folder associated with each
    '  selected checkbox is created or verified when that dark is created and stored.
    '
    'Individaul FITS filename is composed of a string "Dark"."B"<binning>."E"<exposure in sec>."T"<temperature in degrees celsius>.a sequence number
    'The file management functions are broken into three methods.  a New creation of this class verifies and/or creates the
    '  base file tree structure down to the Darks folder, populating the public variable CalPath with that path.  
    '  DarkFilePath() figures out the path to a target directory given the
    '  exposure, binning and date.  DarkFileStore() stores a file given the path and a filename.

    Const UserDirectory = "\Documents\PreStack"
    Const DarksDirectory = "\Darks"
    Const BiasDirectory = "\Bias"

    Private SeqNum As Integer
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

    Public Sub New(preStackFlag As Boolean)
        Dim existresult As Boolean
        If (preStackFlag) Then
            'Set path for darks directory
            DarkCalPath = "C:\Users\" & System.Environment.UserName
            'Set Calibration file path, creating necessary directories, as you go.
            DarkCalPath = DarkCalPath & UserDirectory
        Else
            'Set path for darks directory
            DarkCalPath = My.Settings.DestinationDir + "\PreStack"
            'Set Calibration file path, creating necessary directories, as you go.
        End If

        'Create the PreStack folder, if none exists
        existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath)
        End If
        'Set the Darks base folder (assuming that flats and bias file structure will be added later
        DarkCalPath = DarkCalPath & DarksDirectory
        'Create the PreStack folder, if none exists
        existresult = My.Computer.FileSystem.DirectoryExists(DarkCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(DarkCalPath)
        End If

        If (preStackFlag) Then
            'Set path for bias directory
            BiasCalPath = "C:\Users\" & System.Environment.UserName
            'Set Calibration file path, creating necessary directories, as you go.
            BiasCalPath = BiasCalPath & UserDirectory
        Else
            BiasCalPath = My.Settings.DestinationDir + "\PreStack"
        End If

        'Create the PreStack folder, if none exists
        existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath)
        End If
        'Set the Bias base folder (assuming that flats and bias file structure will be added later
        BiasCalPath = BiasCalPath & BiasDirectory
        'Create the PreStack folder, if none exists
        existresult = My.Computer.FileSystem.DirectoryExists(BiasCalPath)
        If Not existresult Then
            My.Computer.FileSystem.CreateDirectory(BiasCalPath)
        End If

        'Set date string for file folder
        LocalDatePath = DateTime.Today.ToString("ddMMMyyyy")
        DarksKnightForm.StatusBox.Text += "Created PreStack Directory: ...\Prestack\" & LocalDatePath + vbCrLf

        'Set the sequence number
        SeqNum = 0
        'All done, ready to go.
        Return
    End Sub

    Public Sub DarkImageStore()
        'Stores the current active TSX image as designated dark file
        'Step A:  attach the active image and generate folder and file name strings from the FITS information
        '  Three strings are needed:  one for exposure, one for the binning, one for temperature
        Dim tsxaa = CreateObject("TheSkyX.ccdsoftImage")
        Dim attachresult = tsxaa.AttachToActive()
        LocalExpPath = Convert.ToString(tsxaa.FITSKeyword("EXPTIME"))
        LocalBinPath = Convert.ToString(tsxaa.FITSKeyword("XBINNING")) & "X" & Convert.ToString(tsxaa.FITSKeyword("YBINNING"))
        ImageCCDTemp = Convert.ToString(tsxaa.FITSKeyword("SET-TEMP"))
        'Step B:  make sure the folder tree exists, create it if it doesn't
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
        tsxaa.path = tsxPath
        DarksKnightForm.StatusBox.Text += "Writing: " & tsxPath & vbCrLf
        Dim savestatus = tsxaa.save()
        'increment sequence number
        SeqNum += 1
        Return
    End Sub

    Public Sub BiasImageStore()
        'Stores the current active TSX image as designated bias file
        'Step A:  attach the active image and generate folder and file name strings from the FITS information
        '  Two strings are needed:  one for one for the binning, one for temperature
        Dim tsxaa = CreateObject("TheSkyX.ccdsoftImage")
        Dim attachresult = tsxaa.AttachToActive()
        LocalBinPath = Convert.ToString(tsxaa.FITSKeyword("XBINNING")) & "X" & Convert.ToString(tsxaa.FITSKeyword("YBINNING"))
        ImageCCDTemp = Convert.ToString(tsxaa.FITSKeyword("SET-TEMP"))
        'Step B:  make sure the folder tree exists, create it if it doesn't
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
        tsxaa.path = tsxPath
        DarksKnightForm.StatusBox.Text += "Writing: " & tsxPath & vbCrLf
        Dim savestatus = tsxaa.save()
        'increment sequence number
        SeqNum += 1
        Return
    End Sub

End Class
