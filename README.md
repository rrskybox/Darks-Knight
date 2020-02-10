# Darks-Knight
Windows Desktop  App for automation of Darks and Bias frame capture using TheSkyX

Darks Knight Description
Overview: 

Darks Knight applet uses TSX CAO to create a calibration library of dark frames, and, with Rev 1.3, bias frames as well.  The process replicates a function that could be accomplished through the Take Series CAO function, mostly, but simplifies the set up as well as stores the images into a more logical library structure to ease storage and retrieval, if desired.

Requirements:  

Night Shift is a Windows Forms executable, written in Visual Basic.  The application runs as an uncertified, standalone application under Windows 7, 8 and 10.  If the library function is selected, the program creates and maintains a directory structure in the user's Documents directory called "PreStack" which can get large as dark images are added, thus storage requirements depend on usage.  

Installation:  

Download the NightShift_Exe.zip and open.  Read this "ReadMe.txt" file.  Run the "Setup" application.  Upon completion, an application icon will have been added to the start menu under the category "TXTToolkit" with the name "Night Shift".  This application can be pinned to the Start Menu if desired.

Operation: 

Upon launch, the user selects a set of exposures and a set of binnings, as well as the CCD temperature at which all the darks are to be taken.  Multiple exposure times and binning configurations can be selected.  Lastly, the user sets the number of repetitions for each combination.  The applet will then image each combination of exposure time and binning for the required number of darks at that exposure and binning (once the desired CCD temperature is reached).  Put another way, the applet starts with the lowest exposure and binning selected, repeats a dark image at that exposure and binning for the given number of repetitions, then goes to the next exposure selected.  When all selected exposures are exhausted, then the applet goes to the next higher binning and starts over, until all binning selections are exhausted.

Bias frames are taken after all dark frames.  Such frames are essentially dark frames with a minimum exposure length, in this case 0.001 seconds, and at each of the selected binnings.

For monitoring purposes, the exposure and binning of the dark currently being imaged is highlighted in red.  All completed exposures and binnings are highlighted in green. The sequence can be aborted at any time.
   
The user may decide to store the dark images automatically according to TSX settings, or to store them according to a custom directory structure defined specifically for to make inclusion in an image processing application a bit easier.  This structure is labeled “PreStack”.

PreStack Darks Library File Structure:

The dark calibration files are stored in a custom directory tree.  The root is a folder in the user’s “Document” folder called "PreStack", which I’ve used for other TSX applets.  Within this folder will be the darks library directory named "Darks" and a directory named “Bias”.  If PreStack is selected, this directory tree will be created if doesn’t exist upon the first use of the applet.  
    
Within the “Darks” folder, the image library is separated into exposure subfolders (e.g. “60”, “120”, etc), At the next level down are separate binning subfolders (e.g. “1x1”,” 2x2”, etc).  These binning subfolders contain subfolders for the date the dark was taken (e.g. “21Mar2016”).  Within this lowest level are stored the respective dark image FITS files.  The “Bias” subfolders are the same, with the exception that there are no exposure subfolders.  All bias frames are taken with a 0.001 second exposure.  This overall structure is created and/or verified upon launch. 

During each run, dark images that repeat (e.g. same binning, same exposure, same temperature) are distinguished by a sequence number prefix.  However, if Darks Knight is run again on the same date, 
dark images taken with the same binning, same exposure, same temperature may be overwritten as the program does not check for identical sequence numbers.  

Each dark image will be stored with the following filename format:

“Dark.B<binning>.E<time in seconds>.T<temperature>.<sequence number>.FITS”

Each bias image will be stored with the following filename format:

“Dark.B<binning>. T<temperature>.<sequence number>.FITS”

Support:  
This application was written for the public domain and as such is unsupported. The developer wishes you his best and hopes everything works out, but recommends learning Visual Basic (it's really not hard and the tools are free from Microsoft) if you find a problem or want to add features.  The source is supplied as a Visual Studio 2013 project directory.
