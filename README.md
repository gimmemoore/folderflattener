Folder Flattener
===============

Straith to the basics, this tools flatens a directory hierachy and puts it into a single folder.

## Purpuse ##
The main purpose of this tool was to be able to give an extract of all documents from a hierarchy of folders. Instead of digging into each folder, the documents are all copied at a single location.

## Usage ##
The following command will flatten the whole hierarchy into a sub folder called Flatten

	FolderFlattener -r "Path to root folder"

You can set the destination folder yourselves by doing

	FolderFlattener -r "Path to root folder" -d "C:\FlattendLocation"

>Note that the -d flag can be used with rooted or unrooted path

In all cases, add the **-v** switch to make it verbose, for exemple :

	FolderFlattener -r "Path to root folder" -v

## Hints ##
I do like the great [StExBar Tool](http://stefanstools.sourceforge.net/StExBar.html "StExBar Tool"), which adds plugin friendly command to Windows Explorer. With it, you can just add a new option that points to **FolderFlattener** and there you have it, just a click away!