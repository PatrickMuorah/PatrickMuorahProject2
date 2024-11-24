using PatrickMuorahProject2.Model;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace PatrickMuorahProject2
{
    public partial class TextTwistMainForm : Form
    {
        private int score = 0;
        private HashSet<string> validWords = new HashSet<string>();
        private HashSet<string> dictionary;
        private List<Words> validWordEntries = new List<Words>();
        private List<Words> invalidWordEntries = new List<Words>();
        private Timer gameTimer;
        private int remainingTime; // In seconds
        private int gameDuration = 60; // Default to 1 minute


        public TextTwistMainForm()
        {
            InitializeComponent();
            LoadDictionary();
            score_lbl.Text = $"Score: {score}";

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // Timer ticks every second
            gameTimer.Tick += GameTimer_Tick;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                timer_lbl.Text = $"Time: {remainingTime / 60:D2}:{remainingTime % 60:D2}";
            }
            else
            {
                gameTimer.Stop();
                timer_lbl.Text = "Time's up!";
                DisplayRoundResults(); // Show the round results
            }
        }


        private void LoadDictionary()
        {
            string filePath = Path.Combine(Application.StartupPath, "C:\\Users\\Muorah Patrick\\source\\repos\\PatrickMuorahProject2\\PatrickMuorahProject2\\dictionary.json");  // Use StartupPath to get the app's directory

            if (File.Exists(filePath))
            {
                // Read all text from the file
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON manually
                jsonContent = jsonContent.Trim(); // Remove any extra spaces
                if (jsonContent.StartsWith("[") && jsonContent.EndsWith("]"))
                {
                    jsonContent = jsonContent.Substring(1, jsonContent.Length - 2); // Remove square brackets
                    string[] words = jsonContent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Clean up quotes and whitespace from each word
                    dictionary = new HashSet<string>(
                        words.Select(word => word.Trim().Trim('\"').ToLower())
                    );
                }
                else
                {
                    MessageBox.Show("Invalid dictionary format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dictionary = new HashSet<string>();
                }
            }
            else
            {
                MessageBox.Show("Dictionary file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dictionary = new HashSet<string>();
            }


        }


        private void highScore_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            string word = input_textBox.Text.Trim();
            List<char> currentLetters = letters_lbl.Text.Replace(" ", "").ToCharArray().ToList();
            bool isValid = IsValidWord(word, currentLetters);

            var wordEntry = new Words
            {
                Word = word,
                TimeEntered = DateTime.Now
            };

            if (isValid)
            {
                if (!validWords.Contains(word))
                {
                    validWords.Add(word);

                    // Calculate points for the word
                    int wordPoints = CalculatePoints(word);
                    wordEntry.Points = wordPoints;

                    validWordEntries.Add(wordEntry); // Log the word
                    score += wordPoints;

                    feedback_lbl.Text = $"{word} is valid! You earned {wordPoints} points.";
                    score_lbl.Text = $"Score: {score}";
                }
                else
                {
                    feedback_lbl.Text = $"{word} was already submitted.";
                }
            }
            else
            {
                wordEntry.Reason = "Invalid word"; // Add specific reasons as needed
                invalidWordEntries.Add(wordEntry); // Log the invalid word
                feedback_lbl.Text = $"{word} is invalid!";
            }

            input_textBox.Clear();
        }


        private void newGame_btn_Click(object sender, EventArgs e)
        {
            DisplayRandomLetters();

            // Reset and start the timer
            remainingTime = gameDuration;
            timer_lbl.Text = $"Time: {remainingTime / 60:D2}:{remainingTime % 60:D2}";
            gameTimer.Start();

            // Reset other game states
            validWords.Clear();
            validWordEntries.Clear();
            invalidWordEntries.Clear();
            score = 0;
            score_lbl.Text = "Score: 0";
        }

        private void feedback_lbl_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DisplayRandomLetters()
        {
            var letters = GenerateRandomLetters();
            letters_lbl.Text = string.Join(" ", letters);
        }

        // Method to generate random letters
        private List<char> GenerateRandomLetters()
        {
            var random = new Random();
            var letterBag = CreateLetterBag();
            var randomLetters = new List<char>();

            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(letterBag.Count);
                randomLetters.Add(letterBag[index]);
                letterBag.RemoveAt(index); // Remove to avoid duplicates
            }

            return randomLetters;
        }

        // Method to create the letter bag
        private List<char> CreateLetterBag()
        {
            var letterBag = new List<char>();
            AddLetters(letterBag, 'e', 11);
            AddLetters(letterBag, 't', 9);
            AddLetters(letterBag, 'o', 8);
            AddLetters(letterBag, 'a', 6);
            AddLetters(letterBag, 'i', 6);
            AddLetters(letterBag, 'n', 6);
            AddLetters(letterBag, 's', 6);
            AddLetters(letterBag, 'h', 5);
            AddLetters(letterBag, 'r', 5);
            AddLetters(letterBag, 'l', 4);
            AddLetters(letterBag, 'd', 3);
            AddLetters(letterBag, 'u', 3);
            AddLetters(letterBag, 'w', 3);
            AddLetters(letterBag, 'y', 3);
            AddLetters(letterBag, 'b', 2);
            AddLetters(letterBag, 'c', 2);
            AddLetters(letterBag, 'f', 2);
            AddLetters(letterBag, 'g', 2);
            AddLetters(letterBag, 'm', 2);
            AddLetters(letterBag, 'p', 2);
            AddLetters(letterBag, 'v', 2);
            AddLetters(letterBag, 'j', 1);
            AddLetters(letterBag, 'k', 1);
            AddLetters(letterBag, 'q', 1);
            AddLetters(letterBag, 'x', 1);
            AddLetters(letterBag, 'z', 1);

            return letterBag;
        }

        // Helper method to add letters to the bag
        private void AddLetters(List<char> bag, char letter, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bag.Add(letter);
            }
        }

        private bool IsValidWord(string word, List<char> displayedLetters)
        {
            if (dictionary == null)
            {
                feedback_lbl.Text = "Dictionary not loaded.";
                return false;
            }

            word = word.ToLower();

            // Rule 1: Word must be at least three letters long
            if (word.Length < 3)
            {
                feedback_lbl.Text = "Word must be at least 3 letters.";
                return false;
            }

            // Rule 2: Word must use only displayed letters and each letter once
            var letterCount = new Dictionary<char, int>();
            foreach (char letter in displayedLetters)
            {
                if (letterCount.ContainsKey(letter))
                    letterCount[letter]++;
                else
                    letterCount[letter] = 1;
            }

            foreach (char letter in word)
            {
                if (!letterCount.ContainsKey(letter) || letterCount[letter] <= 0)
                {
                    feedback_lbl.Text = "Invalid letters used!";
                    return false;
                }
                letterCount[letter]--;
            }

            // Rule 3: Word must exist in the dictionary
            if (!dictionary.Contains(word))
            {
                feedback_lbl.Text = "Word not found in dictionary!";
                return false;
            }

            feedback_lbl.Text = "Valid word!";
            return true;
        }

        private int CalculatePoints(string word)
        {
            int length = word.Length;
            return length switch
            {
                3 => 90,
                4 => 160,
                5 => 250,
                6 => 360,
                7 => 490,
                _ => 0 // No points for words less than 3 letters
            };
        }

        private void DisplayRoundResults()
        {
            StringBuilder results = new StringBuilder();

            results.AppendLine("Round Results:");
            results.AppendLine("\nValid Words:");
            foreach (var entry in validWordEntries)
            {
                results.AppendLine($"{entry.Word} - {entry.Points} points (Entered at {entry.TimeEntered:T})");
            }

            results.AppendLine("\nInvalid Words:");
            foreach (var entry in invalidWordEntries)
            {
                results.AppendLine($"{entry.Word} - Reason: {entry.Reason} (Entered at {entry.TimeEntered:T})");
            }

            results.AppendLine($"\nTotal Score: {score}");

            MessageBox.Show(results.ToString(), "Round Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void oneMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 60; // 1 minute
            timer_lbl.Text = "Time: 01:00";
        }

        private void twoMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 120; // 2 minutes
            timer_lbl.Text = "Time: 02:00";
        }

        private void threeMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 180; // 3 minutes
            timer_lbl.Text = "Time: 03:00";
        }

        private void twist_btn_Click(object sender, EventArgs e)
        {
            // Get the current letters
            var letters = letters_lbl.Text.Replace(" ", "").ToCharArray().ToList();

            // Shuffle the letters
            var random = new Random();
            for (int i = letters.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }

            // Update the label with shuffled letters
            letters_lbl.Text = string.Join(" ", letters);
        }
    }
}
