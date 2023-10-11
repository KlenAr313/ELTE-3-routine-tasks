using ELTE.DocuStat.Model;
using static System.Windows.Forms.AxHost;

namespace Statistics
{
    public partial class StatisticsDialog : Form
    {
        private DocumentStatistics? _documentStatistics;
        public StatisticsDialog()
        {
            InitializeComponent();
        }

        private void OpenDialog(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _documentStatistics = new DocumentStatistics(openFileDialog.FileName);
                        _documentStatistics.FileContentReady += UpdateFileContent;
                        _documentStatistics.TextStatisticsReady += UpdateTextStatistics;
                        _documentStatistics.Load();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("File reading is unsuccessful!\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }


        private void UpdateTextStatistics(object? sender, EventArgs e)
        {
            labelCharacters.Text = "Character count: " + _documentStatistics?.CharacterCount;
            labelColemanLieuIndex.Text = "Coleman Lieu Index: " + _documentStatistics?.ColemanLieuIndex;
            labelFleschReadingEase.Text = "Flesch Reading Ease: " + _documentStatistics?.FleschReadingEase;
            labelNonWhitespaceCharacters.Text = "Non-whitespace characters: " + _documentStatistics?.NonWhiteSpaceCharacterCount;
            labelProperNouns.Text = "Proper noun count: " + _documentStatistics?.ProperNounCount;
            labelSentences.Text = "Sentence count: " + _documentStatistics?.SentenceCount;
        }

        private void UpdateFileContent(object? sender, EventArgs e)
        {
            if (_documentStatistics?.FileContent == textBox.Text) return;

            textBox.Text = _documentStatistics?.FileContent;
            listBoxCounter.Items.Clear();
        }

        private void CountWords(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_documentStatistics?.FileContent))
            {
                MessageBox.Show("There's no file here!","Huh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int minLength = Convert.ToInt32(spinBoxMinLength.Value);
            int minOccurrence = Convert.ToInt32(spinBoxMinOccurrence.Value);
            List<string> ignoredWords = textBoxIgnoredWords.Text.Split().Select(i => i.Trim().ToLower()).ToList();

            var pairs = _documentStatistics.DistinctWordCount
                .Where(p => p.Value >= minOccurrence)
                .Where(p => p.Key.Length >= minLength)
                .Where(p => !ignoredWords.Contains(p.Key))
                .OrderByDescending(p => p.Value);

            listBoxCounter.Items.Clear();
            listBoxCounter.BeginUpdate();
            foreach (var pair in pairs )
            {
                listBoxCounter.Items.Add(pair.Key + " - " + pair.Value);
            }
            listBoxCounter.EndUpdate();
        }

    }
}