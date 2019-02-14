using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RandomPlotGenerator.Models;

namespace RandomPlotGenerator
{
    public class PlotGenerator
    {
        private readonly string _directoryPath;
        private PlotElements _plotElements;
        private readonly RandomSelector _randomSelector;

        public PlotGenerator(string directoryPath)
        {
            _directoryPath = directoryPath;
            Load();
            _randomSelector = new RandomSelector(_plotElements);
        }

        private void Load()
        {
            try
            {
                _plotElements = DataSerializer.DeserializeFileData(_directoryPath);
            }
            catch (Exception e)
            {
                throw new Exception("An Error occured while loading data from files. Please review the files to make sure the data is in proper JSON format.", e);
            }
        }

        public async Task<string> GenreratePlot()
        {
            var characterType = _randomSelector.SelectRandomStoryCharacterType();
            var story = GenerateFormattedStory(characterType);
            //Todo
            return await InsertLanguageConstructs(story).ConfigureAwait(true);
        }

        private async Task<string> InsertLanguageConstructs(string story)
        {
            try
            {
                var builder = new StringBuilder();
                int pivot = 0;
                int? start = null;
                int? end = null;
                var t = 0;
                for (int i = 0; i < story.Length; i++)
                {
                    t = i;
                    if (story[i] == '[')
                        start = i;
                    if (story[i] == ']')
                        end = i;

                    if (start.HasValue && end.HasValue)
                    {
                        var template = story.Substring(start.Value + 1, end.Value - start.Value - 1);
                        var construct = _randomSelector.SelectRandomConstruct(template);
                        var storyPart = story.Substring(pivot, start.Value - pivot);
                        builder.Append($"{storyPart}{construct}");
                        pivot = end.Value + 1;
                        start = end = null;
                        continue;
                    }

                    if (i == story.Length - 1)
                    {
                        var storyPart = story.Substring(pivot, story.Length - pivot);
                        builder.Append(storyPart);
                    }
                }

                return builder.ToString();
            }
            catch (Exception e)
            {
                return $"{e.Message}{Environment.NewLine}{e.StackTrace}";
            }
            
        }

        private string GenerateFormattedStory(StoryCharacterType characterType)
        {
            var opener = _plotElements.StoryParts.Constants.Opener;
            var characterDialog = _randomSelector.SelectRandomCharacterDialog(characterType);
            var locationPrefix = _plotElements.StoryParts.Constants.StoryBegins;
            var location = _randomSelector.SelectRandomLocation();
            var mainPlot = _randomSelector.SelectRandomMainPlot();
            var itsAbout = _plotElements.StoryParts.Constants.ItsAbout;
            var yourCharacterDialog = _plotElements.StoryParts.Constants.YourCharacter;
            var yourCharacterAction = _randomSelector.SelectRandomCharacterAction();
            return $"{opener} {characterDialog}.{Environment.NewLine}{locationPrefix} {location}.{Environment.NewLine}{mainPlot}.{Environment.NewLine}{itsAbout}.{Environment.NewLine}{yourCharacterDialog} {yourCharacterAction}.";
        }
    }
}