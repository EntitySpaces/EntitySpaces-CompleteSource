@ECHO OFF
time /t >BuildLog.txt

ECHO *** Building EntitySpaces Help ***
ECHO -------------------------------------- >>BuildLog.txt
ECHO *** User Manual ***
ECHO *** User Manual *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\StudioUserManual\StudioUserManual.d2h" "NetHelp" >>BuildLog.txt

ECHO -------------------------------------- >>BuildLog.txt
ECHO *** Getting Started ***
ECHO *** Getting Started *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\StudioGettingStarted\StudioGettingStarted.d2h" "NetHelp" >>BuildLog.txt

ECHO -------------------------------------- >>BuildLog.txt
ECHO *** Release Notes ***
ECHO *** Release Notes *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\StudioReleaseNotes\StudioReleaseNotes.d2h" "NetHelp" >>BuildLog.txt

ECHO -------------------------------------- >>BuildLog.txt
ECHO *** EntitySpaces API ***
ECHO *** EntitySpaces API *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\EntitySpacesAPI\EntitySpacesAPI.d2h" "NetHelp" >>BuildLog.txt

ECHO -------------------------------------- >>BuildLog.txt
ECHO *** Profiler ***
ECHO *** Profiler *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\ProfilerHelp\ProfilerHelp.d2h" "NetHelp" >>BuildLog.txt

ECHO -------------------------------------- >>BuildLog.txt
ECHO *** About EntitySpaces ***
ECHO *** About EntitySpaces *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\AboutEntitySpaces\AboutEntitySpaces.d2h" "NetHelp" >>BuildLog.txt

REM This is the hub project, so build it last.
ECHO -------------------------------------- >>BuildLog.txt
ECHO *** Studio Help ***
ECHO *** Studio Help *** >>BuildLog.txt
ECHO -------------------------------------- >>BuildLog.txt
"C:\Program Files (x86)\ComponentOne\DocToHelp\C1D2HBatch.exe" -build ".\StudioHelp\StudioHelp.d2h" "NetHelp" >>BuildLog.txt

time /t >>BuildLog.txt
PAUSE
