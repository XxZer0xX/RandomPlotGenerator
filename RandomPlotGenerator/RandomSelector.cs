using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RandomPlotGenerator.Models;

namespace RandomPlotGenerator
{
    internal class RandomSelector
    {
        private readonly PlotElements _plotElements;
        private Dictionary<string, Dictionary<string, List<string>>> _constructs;

        public RandomSelector(PlotElements plotElements)
        {
            _plotElements = plotElements;

            _constructs = typeof(PlotElements)
                .GetProperties()
                .ToDictionary(
                    propertyInfo => propertyInfo.PropertyType.Name,
                    propertyInfo =>
                    {
                        var propertyValue = propertyInfo.GetValue(_plotElements);
                        return propertyValue.GetType().GetProperties().Where(propInfo => propInfo.PropertyType == typeof(List<string>))
                            .ToDictionary(listInfo => listInfo.Name,
                                listInfo => (List<string>)listInfo.GetValue(propertyValue));
                    });
        }

        public StoryCharacterType SelectRandomStoryCharacterType()
        {
            return (StoryCharacterType)Enum.ToObject(typeof(StoryCharacterType), new Random().Next(0, (int)Enum.GetValues(typeof(StoryCharacterType)).Cast<StoryCharacterType>().Max()));
        }

        public string SelectRandomCharacterDialog(StoryCharacterType characterType)
        {
            return SelectRandom(_plotElements.StoryParts.Character[characterType.ToString()]);
        }

        public string SelectRandomLocation()
        {
            return SelectRandom(_plotElements.StoryParts.Location);
        }

        public string SelectRandomMainPlot()
        {
            return SelectRandom(_plotElements.StoryParts.MainPlot);
        }

        private string SelectRandom(IEnumerable<string> list)
        {
            return list.ElementAt(new Random().Next(0, list.Count() - 1));
        }

        public string SelectRandomConstruct(string template)
        {
            var pieces = template.Split(':');
            var className = pieces[0];
            var property = pieces.Count() == 1 ? "Values" : pieces[1];
            var list = _constructs[className][property];
            return SelectRandom(list);
        }

        public string SelectRandomCharacterAction()
        {
            return SelectRandom(_plotElements.StoryParts.CharacterAction);
        }
    }
}