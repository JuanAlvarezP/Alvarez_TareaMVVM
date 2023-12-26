using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alvarez_AppApuntes.Models
{
    internal class Note
    {
        public string Filename_Alvarez { get; set; }
        public string Texto_Alvarez { get; set; }
        public DateTime Fecha_Alvarez { get; set; }

        public Note()
        {
            Filename_Alvarez = $"{Path.GetRandomFileName()}.notes.txt";
            Fecha_Alvarez = DateTime.Now;
            Texto_Alvarez = "";
        }

        public void Save() =>
    File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename_Alvarez), Texto_Alvarez);

        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename_Alvarez));

        public static Note Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);

            return
                new()
                {
                    Filename_Alvarez = Path.GetFileName(filename),
                    Texto_Alvarez = File.ReadAllText(filename),
                    Fecha_Alvarez = File.GetLastWriteTime(filename)
                };
        }

        public static IEnumerable<Note> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")

                    // Each file name is used to load a note
                    .Select(filename => Note.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(note => note.Fecha_Alvarez);
        }

        
    }

    
}
