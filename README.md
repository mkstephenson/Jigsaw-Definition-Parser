Jigsaw-Definition-Parser
========================

A quick and crude tool to extract the names of all the puzzles from the XML files which are used to define the puzzles in Microsoft Jigsaw since I wanted a list of all the puzzles so that I could tick off all the ones I had completed without having to open up the app.

The best way of getting all the puzzle definitions is to go to C:\Users\<username>\AppData\Local\Packages\Microsoft.MicrosoftJigsaw_8wekyb3d8bbwe and search for "Puzzle.xml" (the name of all the puzzle definition files).
Then copy the resulting files to a temporary directory, launch the application and select the files you want to extract the information from.

Application was written in C# and WPF using Visual Studio 2013 Community Edition and I am currently not providing an executable of the application.

(Microsoft Jigsaw is a trademark of Microsoft Corporation, no copyright infringement intended).
