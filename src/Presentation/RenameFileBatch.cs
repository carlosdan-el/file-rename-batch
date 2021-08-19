using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using Domain.Entities;
using System.Text.RegularExpressions;

namespace Presentation
{
    class RenameFileBatch
    {
        private static List<string> logs = new List<string>();
        
        private static Settings settings;

        static void Main(string[] args)
        {
            string settingsFile = File.ReadAllText("..\\..\\config\\settings.json");
            settings = JsonSerializer.Deserialize<Settings>(settingsFile);

            try
            {
                foreach(Folder folder in settings.Folders)
                {
                    GetFolders(folder.From, folder.To);
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

        private static void GetFolders(string currentPath, string newPath)
        {
            if(Directory.Exists(currentPath))
            {
                string[] files = Directory.GetFiles(currentPath);
                
                foreach(string data in files)
                {
                    FileInfo file = new FileInfo(data);
                    RenameFile(file, newPath);
                }
            }
        }

        private static void RenameFile(FileInfo file, string newPath)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string hours = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                if(settings.AllowedExtensions.Contains(file.Extension))
                {
                    string extension = file.Extension;
                    string guid = Guid.NewGuid().ToString();
                    string directoryPath = string.IsNullOrEmpty(newPath) ?
                    file.DirectoryName : newPath;
                    string newFileName = GenerateFileName(file);
                    string fullPath = Path.Combine(directoryPath, newFileName);

                    Console.WriteLine(newFileName);
                    
                    
                    string message = $"\"{file.Name}\" renamed to " + 
                    $"\"{newFileName}\" in \"{directoryPath}\"";

                    if(!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    file.MoveTo(fullPath);

                    logs.Add($"{date} {hours} SUCCESS (Message: {message}).");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"success: {message}");
                }
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

        private static string GenerateFileName(FileInfo file)
        {
            string fileName = file.Name;
            string extension = file.Extension;

            if(!settings.KeepFileName)
            {
                string guid = Guid.NewGuid().ToString();
                fileName = guid;
            }

            fileName = fileName.Replace(extension, "");
            fileName = RemoveInvalidCharacters(fileName);
            fileName = ConvertNameTo(fileName);

            return $"{fileName}{extension}";
        }

        private static string RemoveInvalidCharacters(string word)
        {
            return Regex.Replace(word, "([\\s+])|([\\.\\,\\-])", "_");
        }

        private static string ConvertNameTo(string name)
        {
            string format = settings.FileNameFormat.ToLower();

            switch(format)
            {
                case "uppercase":
                    return name.ToUpper();
                default:
                    return name.ToLower();
            }
        }

        private static void GenerateLog(List<string> logs)
        {
            if(!Directory.Exists("../../log"))
            {
                Directory.CreateDirectory("../../log");
            }

            string logFile = $"../../log/{DateTime.Now.ToString("yyyyMMdd")}.log";
            Console.WriteLine(logFile);
            File.AppendAllLines(logFile, logs);
        }

    }
}
