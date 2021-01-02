using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GooglePhotoJsonCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            // can we start?
            if (args.Length != 1 || !Directory.Exists(args[0]))
            {
                Console.WriteLine("Supply the name of the folder where Google Photo JSON files and pictures to convert are located.");
                return;
            }

            // updated pics are copied to the "updated" folder
            // pics with date errors go to the "DateErrors" folder
            // files with exceptions thrown go to the ExceptionErrors folder
            
            const string updatedDirectory = "Updated";
            const string noDateErrorDirectory = "DateErrors";
            const string exceptionErrorDirectory = "ExceptionErrors";

            // error logs
            var noPictureErrorLog = new StringBuilder(); 
            var noDateErrorLog = new StringBuilder(); 
            var exceptionErrorLog = new StringBuilder();

            // file paths for error logs
            var noPictureErrorLogPath = Path.Combine(args[0], "NoPictureErrors.txt");
            var noDateErrorLogPath = Path.Combine(args[0], noDateErrorDirectory, "NoDateErrors.txt");
            var exceptionErrorLogPath = Path.Combine(args[0], exceptionErrorDirectory, "ExceptionErrors.txt");

           // make the updated directory, if it doesn't exist
            var updatedFolder = Path.Combine(args[0], updatedDirectory);
            if (!Directory.Exists(updatedFolder))
            {
                Directory.CreateDirectory(updatedFolder);
            }
            // make the error no date directory, if it doesn't exist
            var errorNoDateFolder = Path.Combine(args[0], noDateErrorDirectory);
            if (!Directory.Exists(errorNoDateFolder))
            {
                Directory.CreateDirectory(errorNoDateFolder);
            }
            // make the error exception directory, if it doesn't exist
            var errorExceptionFolder = Path.Combine(args[0], exceptionErrorDirectory);
            if (!Directory.Exists(errorExceptionFolder))
            {
                Directory.CreateDirectory(errorExceptionFolder);
            }

            var jsonFiles = Directory.EnumerateFiles(args[0], "*.json").ToArray();
            Console.WriteLine($"Converting {jsonFiles.Length} files...");
            var errorCounter = 0;
            var progressCounter = 0;
            var totalFiles = jsonFiles.Length;
            foreach (var filename in jsonFiles)
            {
                var fileData = JsonSerializer.Deserialize<GooglePhotoJson>(File.ReadAllText(filename));
                
                //Find the corresponding picture
                if (fileData?.title == null || !File.Exists(Path.Combine(args[0], fileData.title)))
                {
                    //Console.WriteLine(filename + " does not have a corresponding picture");
                    noPictureErrorLog.AppendLine(filename + " does not have a corresponding picture");
                    DrawTextProgressBar("Errors: " + ++errorCounter, progressCounter++, totalFiles);
                    continue;
                }
                var originalPicPath = Path.Combine(args[0], fileData.title);
                try
                {
                    Image theImage = new Bitmap(originalPicPath);
                    var propItems = theImage.PropertyItems;
                    theImage.Dispose();
                    var encoding = Encoding.UTF8;
                    string originalDateString;

                    var dateTakenProperty1 = propItems.FirstOrDefault(a => a.Id.ToString("x") == "9004");
                    if (dateTakenProperty1?.Value == null)
                    {
                        var dateTakenProperty2 = propItems.FirstOrDefault(a => a.Id.ToString("x") == "9003");
                        if (dateTakenProperty2?.Value == null)
                        {
                            // Console.WriteLine(filename + " does not have a date property");
                            noDateErrorLog.AppendLine(filename + " does not have a date property");
                            
                            //copy this file to the DateErrors folder
                            var noDateFile = Path.Combine(errorNoDateFolder, fileData.title);
                            try{
                                File.Copy(originalPicPath,noDateFile);
                            }
                            catch (IOException)
                            {
                                // file already copied
                            }
                            DrawTextProgressBar("Errors: " + ++errorCounter, progressCounter++, totalFiles);
                            continue;
                        }
                        originalDateString = encoding.GetString(dateTakenProperty2.Value);
                    }
                    else
                    {
                        originalDateString = encoding.GetString(dateTakenProperty1.Value);
                    }
                    
                    originalDateString = originalDateString.Remove(originalDateString.Length - 1);
                
                    var originalDate = DateTime.ParseExact(originalDateString, "yyyy:MM:dd HH:mm:ss", null);

                    var newPath = Path.Combine(args[0], updatedFolder,fileData.title);

                    try{
                        File.Copy(originalPicPath,newPath);
                        File.SetCreationTime(newPath,originalDate);
                        //File.Move(originalPicPath,newPath);
                    }
                    catch (IOException)
                    {
                        // file already copied
                    }
                }
                catch(Exception e)
                {
                    exceptionErrorLog.AppendLine("Could not convert " + filename + " Exception: " + e.Message);
                    errorCounter++;
                    // copy this file to the exception error folder
                    var exceptionFile = Path.Combine(errorExceptionFolder, fileData.title);
                    try
                    {
                        File.Copy(originalPicPath,exceptionFile);
                    }
                    catch (IOException)
                    {
                        // file already copied
                    }
                }

                DrawTextProgressBar("Errors: " + errorCounter, progressCounter++, totalFiles);
            }

            if(noDateErrorLog.Length > 0)
                File.WriteAllText(noDateErrorLogPath,noDateErrorLog.ToString());
            if(noPictureErrorLog.Length > 0)
                File.WriteAllText(noPictureErrorLogPath,noPictureErrorLog.ToString());
            if(exceptionErrorLog.Length > 0)
                File.WriteAllText(exceptionErrorLogPath,exceptionErrorLog.ToString());
        }

        public static void DrawTextProgressBar(string stepDescription, int progress, int total)
        {
            int totalChunks = 30;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = totalChunks + 1;
            Console.Write("]"); //end
            Console.CursorLeft = 1;

            double pctComplete = Convert.ToDouble(progress) / total;
            int numChunksComplete = Convert.ToInt16(totalChunks * pctComplete);

            //draw completed chunks
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("".PadRight(numChunksComplete));

            //draw incomplete chunks
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("".PadRight(totalChunks - numChunksComplete));

            //draw totals
            Console.CursorLeft = totalChunks + 5;
            Console.BackgroundColor = ConsoleColor.Black;

            string output = progress.ToString() + " of " + total.ToString();
            Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
        }
    }
}
