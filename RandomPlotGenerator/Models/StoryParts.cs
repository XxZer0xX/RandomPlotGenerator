using System.Collections.Generic;

namespace RandomPlotGenerator.Models
{
    public class StoryParts
    {
        public Constants Constants { get; set; }
        public Dictionary<string, List<string>> Character { get; set; }
        public List<string> Location { get; set; }
        public List<string> MainPlot { get; set; }
        public List<string> CharacterAction { get; set; }
    }
}