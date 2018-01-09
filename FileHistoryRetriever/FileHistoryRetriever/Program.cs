using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileHistoryRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            //This tool takes two folders as args - one in the file history repository and another when the File History is to be copied
            // The tool will then copy the latest version of the files in the File History folder to the Copy-To folder.
            string FileHistoryFolder = "";
            string CopyToDriveLetter = "";
            if (args.Length != 2)
            {
                Console.WriteLine("You must enter two paths: FileHistoryPath CopyToPath");
                return;
            }
            else
            {
                FileHistoryFolder = args[0];
                CopyToDriveLetter = args[1];
            }

            var files = Directory.EnumerateFiles(FileHistoryFolder, "*(????_??_??*", SearchOption.AllDirectories);
            //Console.WriteLine(files.Count() + " files to check in this folder");
            // iterate through the files, find duplicates with different time stamps and add to Dictionary
            Dictionary<string, MyFileInfoCollection> fileHistoryFiles = new Dictionary<string, MyFileInfoCollection>();

            foreach (var f in files)
            {
                if (f.Contains(" (") && f.Contains("UTC)"))
                {
                    // get the index of " (" and index of last ")" and remove that substring
                    // appmanifest_10680 (2017_07_09 02_13_12 UTC)
                    var startIndex = f.LastIndexOf(" (20");
                    var endIndex = f.LastIndexOf("C)") + 1;
                    var timestamp = f.Substring(startIndex + 2, endIndex - (startIndex + 2));
                    var newFName = f.Remove(startIndex, endIndex - startIndex + 1);
                    newFName = newFName.Remove(0, 1);
                    newFName = CopyToDriveLetter + newFName;
                    var mfi = new MyFileInfo
                    {
                        FileDate = getDateTime(timestamp),
                        OriginalName = f
                    };
                    if (!fileHistoryFiles.ContainsKey(newFName))
                    {
                        fileHistoryFiles.Add(newFName, new MyFileInfoCollection());
                    }

                    fileHistoryFiles[newFName].MfIs.Add(mfi);
                }
            }

            foreach (var f in fileHistoryFiles.Keys)
            {
                var fromName = fileHistoryFiles[f].GetLatestFileName();

                if (!File.Exists(f))
                {
                    var path = Path.GetDirectoryName(f);
                    Directory.CreateDirectory(path);
                    File.Copy(fromName,f);
                }
                var attributes = File.GetAttributes(f);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    attributes = attributes & ~FileAttributes.ReadOnly;
                    File.SetAttributes(f, attributes);
                }
            }

        }
        private static DateTime getDateTime(string timestamp)
        {
            var pieces = timestamp.Split(' ');
            var da = pieces[0].Split('_');
            var ti = pieces[1].Split('_');
            return new DateTime(int.Parse(da[0]),
                                  int.Parse(da[1]),
                                    int.Parse(da[2]),
                                    int.Parse(ti[0]),
                                    int.Parse(ti[1]),
                                    int.Parse(ti[2]),
                                        DateTimeKind.Utc);
        }

        public class MyFileInfo
        {
            public string OriginalName { get; set; }
            public DateTime FileDate { get; set; }
        }

        public class MyFileInfoCollection 
        {
            public List<MyFileInfo> MfIs { get; }

            public MyFileInfoCollection()
            {
                MfIs = new List<MyFileInfo>();
            }

            public string GetLatestFileName()
            {
                string latest = string.Empty;
                var now = DateTime.UtcNow;
                var min = TimeSpan.MaxValue;
                foreach (var f in MfIs)
                {
                    if (now - f.FileDate >= min) continue;
                    min = now - f.FileDate;
                    latest = f.OriginalName;
                }

                return latest;
            }

        }

            
    }

}

        

      