\ES_D2H_Templates contains the custom templates. It contains a README.txt file that explains where they should be copied. They should be copied before opening and building the D2H projects below.

\EntitySpacesHelp is a special D2H hub project that merges the output from the working child projects. The NetHelp target of each child project needs to be built before you build the NetHelp target for the hub project. BuildEntitySpacesNetHelp.bat is a batch file that rebuilds each child project before rebuilding the hub. To run it, right-click, and "Run as administrator". BuildLog.txt will contain the build ouput for each project. Only the \NetHelp folder under \EntitySpacesHelp needs to be deployed.

The documentation work is done within one of the child projects (listed below). You can build and view them as you work. \EntitySpacesAPI is a special D2H Sandcastle integrated project. It can take 5 minutes to build, mainly because Sandcastle itself takes so long to build.

\StudioGettingStarted
\StudioUserManual
\EntitySpacesAPI
\StudioReleaseNotes
\ProfilerHelp
\AboutEntitySpaces

The files/folders below the individual D2H project folders above that have been committed are:

[ProjectName].d2h (the file that you open in D2H that contains the D2H project settings)
\Documents (contains the imported Word documents)
\Media (usually empty for Word documents, but may contain images, video, etc.)
\XMLDocuments (for Sandcastle integrated projects)

As you build individual D2H projects, additional output folders are created below each project folder. They should be set to SVN ignore like \bin and \obj folders for VS (\NetHelp, \HTMLHelp, \Temp, etc.).
