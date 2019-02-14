using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using RandomPlotGenerator.Properties;

namespace RandomPlotGenerator
{
    public class DataValidator
    {
        public static bool ValidateForm(RandomPlotGeneratorForm form)
        {
            if (!Directory.Exists(form.SaveDirectory))
            {
                MessageBox.Show("The selected output directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (form.StoryCount <= 0)
            {
                MessageBox.Show("We can not generate 0 stories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(form.DataSetDirectory) || !Directory.Exists(form.DataSetDirectory))
            {
                MessageBox.Show("No directory with a valid dataset has been set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool ValidateRequiredFiles(string datasetLocation)
        {
            var files = Directory.EnumerateFiles(datasetLocation, "*.json");
            var requiredFileNames = (StringCollection)Settings.Default["RequiredFileNames"];
            var availableFileNames = files.Select(Path.GetFileName);

            if (files.Count() != 6)
            {
                var missingFile = requiredFileNames.Cast<string>().Where(name => !availableFileNames.Contains(name));
                MessageBox.Show($"Not all of the required files are located in the directory. Missing file/s '{string.Join(",", missingFile)}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var name in requiredFileNames)
            {
                if (availableFileNames.Contains(name))
                    continue;
                MessageBox.Show($"File {name} is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}