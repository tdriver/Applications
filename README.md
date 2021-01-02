# Google Photos JSON Combiner
This .Net 5 tool reads Google photos .json files that get downloaded with your pictures, when you use Google Takeout to download many pictures at once.
Currently it reads the json file, then copies the picture referenced in that file to a new folder and applies the originial creation date to the picture.  It also tracks errors
and moves files with errors to their own folders.

Example: GooglePhotoJsonCombiner "Path To Your Unzipped Google Takeout Folder with Json files"

# PhotoImporter
Moves photos and videos from a specified folder, into separate folders for photos and videos. The photos and videos are each put in dated folders based on the date taken (for photos) or date created (for videos).
Example:
Import photos and videos from: c:\ToImport, Import photos to: c:\MyPhotos, Import videos to: c:\MyVideos

When imported, c:\MyPhotos will have folders named by date using the photos 'taken' date and c:\MyVideos will have folders named by date using the videos 'created by' date. e.g. c:\MyPhotos\2015-10-27\MyPic1.jpg and c:\MyPhotos\2015-10-28\MyPic2.jpg

# Windows 10 File History Retriever
When you need files from Windows 10 File History repository on your backup drive, but The restore function in windows isn't working properly, use this tool to copy specific folders from the File Hisory backup to a folder you specify.  It will find the latest version of a file and copy that, without the annoying timestamps.

# Windows 10 File History Timestamp remover
Did you copy files from Windows 10 File history backup and now have lots of files whose filenames have changed, with the adition of a timestamp in them?  This program will remove the timestamps (deleting duplicate existing files).
