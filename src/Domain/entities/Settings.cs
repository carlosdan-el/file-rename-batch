using System.Collections.Generic;

namespace Domain.Entities
{
    public class Settings
    {
        public List<Folder> Folders { get; set; }

        public bool KeepFileName { get; set; }

        public string FileNameFormat { get; set; }

        public bool EnableRecursiveMode { get; set; }

        public List<string> AllowedExtensions { get; set; }
    }
}