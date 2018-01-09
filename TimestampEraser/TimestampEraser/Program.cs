using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TimestampEraser
{
    class Program
    {
        static void Main(string[] args)
        {
            // The tool searches through user specified folders for files that have the File History timestamp in their name
            // if it finds a file like that, it will remove the timestamp and save a copy of that file if it doesn't already exist there.

            // get the folder from args
            // enumerate all files in folder and all sub folders
            // for each file, does the file name contain the timestamp string?
            // if so, does the file without the timestamp string already exist?
            // if so, delete the timestamp file
            // else
            //rename the timestamp file to the original name
            string folder = "";
            if(args.Count() == 0)
            {
                folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                folder = args[0];
            }

            var files = Directory.EnumerateFiles(folder, "*(????_??_??*", SearchOption.AllDirectories);
            Console.WriteLine(files.Count() +" files to check in this folder");
            foreach (var f in files)
            {
                if (f.Contains(" (") && f.Contains("UTC)"))
                {
                    // get the index of " (" and index of last ")" and remove that substring
                    var startIndex = f.IndexOf(" (20");
                    var endIndex = f.LastIndexOf("C)");
                    var newFName = f.Remove(startIndex, endIndex - startIndex + 2);
                    var attributes = File.GetAttributes(f);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributes = attributes & ~FileAttributes.ReadOnly;
                        File.SetAttributes(f, attributes);
                    }
                    if (File.Exists(newFName))
                    {
                        //var attributes = File.GetAttributes(f);
                        //if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        //{
                        //    attributes = attributes & ~FileAttributes.ReadOnly;
                        //    File.SetAttributes(f, attributes);
                        //}
                        File.Delete(f);
                        //File.Move(f, "_" + newFName);
                    }
                    else
                    {
                        File.Move(f,newFName);
                    }
                }
            }
        }
    }
}
