using System;
using System.IO;
using System.Threading.Tasks;

namespace RandomPlotGenerator
{
    public class FileWriter
    {
        private readonly string _directoryPath;
        private readonly string outputDirectory;

        public FileWriter(string directoryPath)
        {
            _directoryPath = directoryPath;
            Directory.CreateDirectory(
                outputDirectory = Path.Combine(_directoryPath, DateTime.Now.ToString("yyyy-dd-M HH-mm-ss")));
        }

        public async Task WritePlotToFile(string plot, string fileName)
        {
            var path = Path.Combine(outputDirectory, $"{fileName}");
            File.WriteAllText(path, plot);
        }
    }
}