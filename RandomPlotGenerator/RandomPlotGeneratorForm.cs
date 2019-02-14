using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomPlotGenerator.Properties;

namespace RandomPlotGenerator
{
    public partial class RandomPlotGeneratorForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        internal string DataSetDirectory = Settings.Default.LastDataSetLocation;
        internal ExecutionState ExecutionState = ExecutionState.None;
        internal PlotGenerator PlotGenerator;
        internal string SaveDirectory = Settings.Default.LastSaveLocation;
        internal int StoryCount;
        internal StoryType StoryType = StoryType.Simple;

        public RandomPlotGeneratorForm()
        {
            InitializeComponent();
            DataSetDirectoryTextBox.Text = DataSetDirectory;
            SaveDirectoryTextBox.Text = SaveDirectory;
            StoryCountInput.Text = $"{Settings.Default.LastCountGenerated}";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            switch (ExecutionState)
            {
                case ExecutionState.Generating:
                    ExecutionState = ExecutionState.Paused;
                    StartPauseButton.Text = "Start";
                    break;
                case ExecutionState.None:
                    ConfigureUIElementsForExecution();
                    StartExecution();
                    break;
                case ExecutionState.Paused:
                    ConfigureUIElementsForExecution();
                    break;
            }
        }

        private void CancelCloseButton_Click(object sender, EventArgs e)
        {
            switch (ExecutionState)
            {
                case ExecutionState.None:
                    Close();
                    break;
                case ExecutionState.Generating:
                case ExecutionState.Paused:
                    CancelCurrentProcess();
                    break;
            }
        }

        private void StoryCountInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StoryCountInput.Text))
            {
                StoryCountInput.Text = $"{0}";
                return;
            }

            if (int.TryParse(StoryCountInput.Text, out var storyCount))
            {
                StoryCount = storyCount;
                return;
            }

            StoryCountInput.Text = StoryCount.ToString();
        }

        private void ProgressIndicator_ProgressChanged(object sender, int e)
        {
            ProgressBar.Value = e;
        }

        private void Output_btn_Click(object sender, EventArgs e)
        {
            var result = DirectorySelectorDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(DirectorySelectorDialog.SelectedPath))
            {
                SaveDirectoryTextBox.Text = SaveDirectory = DirectorySelectorDialog.SelectedPath;
                DirectorySelectorDialog.SelectedPath = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(SaveDirectory))
                SaveDirectoryTextBox.Text = "No Directory Selected";
        }

        private void StoryPartDirectorySelectionButton_Click(object sender, EventArgs e)
        {
            var result = DirectorySelectorDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(DirectorySelectorDialog.SelectedPath))
            {
                DataSetDirectoryTextBox.Text = DataSetDirectory = DirectorySelectorDialog.SelectedPath;
                DirectorySelectorDialog.SelectedPath = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(SaveDirectory))
                DataSetDirectoryTextBox.Text = "No Directory Selected";
        }

        private void SaveDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveDirectory = SaveDirectoryTextBox.Text;
        }

        private void StoryPartsDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            DataSetDirectory = DataSetDirectoryTextBox.Text;
        }

        private void UncommonCheckBox_Click(object sender, EventArgs e)
        {
            StoryType = StoryType.Uncommon;
            AdjustCheckBoxes();
        }

        private void TwistCheckBox_Click(object sender, EventArgs e)
        {
            StoryType = StoryType.Twisted;
            AdjustCheckBoxes();
        }

        private void SimpleCheckBox_Click(object sender, EventArgs e)
        {
            StoryType = StoryType.Simple;
            AdjustCheckBoxes();
        }

        private void AdjustCheckBoxes()
        {
            switch (StoryType)
            {
                case StoryType.Uncommon:
                    UncommonCheckBox.Checked = !(TwistCheckBox.Checked = SimpleCheckBox.Checked = false);
                    break;
                case StoryType.Twisted:
                    TwistCheckBox.Checked = !(UncommonCheckBox.Checked = SimpleCheckBox.Checked = false);
                    break;
                case StoryType.Simple:
                    SimpleCheckBox.Checked = !(TwistCheckBox.Checked = UncommonCheckBox.Checked = false);
                    break;
            }
        }

        private void ConfigureUIElementsForExecution()
        {
            ExecutionState = ExecutionState.Generating;
            StartPauseButton.Text = "Pause";
            ProgressBar.ResetForeColor();
        }

        private void CancelCurrentProcess()
        {
            _cancellationTokenSource?.Cancel();
            StartPauseButton.Text = "Start";
        }

        private void StartExecution()
        {
            if (!DataValidator.ValidateForm(this))
                return;

            if (!DataValidator.ValidateRequiredFiles(DataSetDirectory))
                return;

            SaveSettings();

            var progressIndicator = new Progress<int>();
            progressIndicator.ProgressChanged += ProgressIndicator_ProgressChanged;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.Token.Register(() =>
            {
                ProgressBar.Value = 0;
                _cancellationTokenSource.Dispose();
            });

            Task.Run(() => GeneratePlotsAsync(progressIndicator), _cancellationTokenSource.Token);
        }

        private void SaveSettings()
        {
            Settings.Default.LastDataSetLocation = DataSetDirectory;
            Settings.Default.LastSaveLocation = SaveDirectory;
            Settings.Default.LastCountGenerated = StoryCount;
            Settings.Default.Save();
        }

        private async Task GeneratePlotsAsync(IProgress<int> progress)
        {
            PlotGenerator = new PlotGenerator(DataSetDirectory);
            var writer = new FileWriter(SaveDirectory);

            for (var i = 1; i <= StoryCount; i++)
            {
#if DEBUG
                Thread.Sleep(1000);
#endif
                if (ExecutionState == ExecutionState.Generating)
                {
                    var plot = await PlotGenerator.GenreratePlot().ConfigureAwait(true);
                    await writer.WritePlotToFile(plot, $"{i}.txt");
                }
                else
                {
                    while (ExecutionState == ExecutionState.Paused)
                        ;
                }

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    return;
                }

                progress.Report(i * 100 / StoryCount);
            }

            ExecutionState = ExecutionState.None;
            StartPauseButton.Text = "Start";
        }
    }
}