using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RandomPlotGenerator.Models;

namespace RandomPlotGenerator
{
    public class DataSerializer
    {
        public static PlotElements DeserializeFileData(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.json").ToDictionary(Path.GetFileNameWithoutExtension, File.ReadAllText);

            var elements = new PlotElements
            {
                Adjective = JsonConvert.DeserializeObject<Adjective>(files[nameof(Adjective)]),
                Adverb = JsonConvert.DeserializeObject<Adverb>(files[nameof(Adverb)]),
                Age = JsonConvert.DeserializeObject<Age>(files[nameof(Age)]),
                Noun = JsonConvert.DeserializeObject<Noun>(files[nameof(Noun)]),
                StoryParts = JsonConvert.DeserializeObject<StoryParts>(files[nameof(StoryParts)]),
                Verb = JsonConvert.DeserializeObject<Verb>(files[nameof(Verb)])
            };
            return elements;
        }
    }
}