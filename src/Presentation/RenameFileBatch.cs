using System;
using System.Collections.Generic;
using System.IO;

namespace Presentation
{
    class RenameFileBatch
    {
        private static List<string> logs = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                string places = "C:\\Users\\Carlos\\Downloads";
                List<string> allowedImageExtensions = new List<string>();
                allowedImageExtensions.Add(".svg");
                allowedImageExtensions.Add(".jpeg");
                allowedImageExtensions.Add(".gif");
                allowedImageExtensions.Add(".png");
                allowedImageExtensions.Add(".jpg");

                if(ValidatePath(places))
                {
                    string[] files = Directory.GetFiles(places);

                    foreach(string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        if(allowedImageExtensions.Contains(fileInfo.Extension))
                        {
                            RenameFiles(fileInfo);
                        }
                    }
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                if(true == true)
                {
                    if(logs.Count > 0)
                    {
                        GenerateLog(logs);
                    }
                }
            }
        }

        private static bool ValidatePath(string path)
        {
            return Directory.Exists(path);
        }

        private static void RenameFiles(FileInfo file)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string hours = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                string extension = file.Extension;
                string guid = Guid.NewGuid().ToString();
                string fileDirectory = file.DirectoryName;
                string newfileName = $"{guid}{extension}".ToLower().Replace("-", "_");
                string newFileNamePath = Path.Combine(fileDirectory, newfileName);

                Console.ForegroundColor = ConsoleColor.Green;
                string message = $"\"{file.Name}\" renamed to " + 
                $"\"{newfileName}\" in \"{fileDirectory}\"";

                file.MoveTo(newFileNamePath);

                Console.WriteLine(message);

                logs.Add($"{date} {hours} SUCCESS (Message: {message}).");
                Console.WriteLine($"success: {message}");
            }
            catch(Exception error)
            {
                string message = "A error occured while trying remane" +
                $" the file \"{file.Name}\", see logs.";

                logs.Add($"{date} {hours} ERROR (Message: {error.Message}).");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"error: {message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        private static void GenerateLog(List<string> logs)
        {
            if(!Directory.Exists("./log"))
            {
                Directory.CreateDirectory("./log");
            }

            string logFile = $"./log/{DateTime.Now.ToString("yyyyMMdd")}.log";
            File.AppendAllLines(logFile, logs);
        }

    }
}
