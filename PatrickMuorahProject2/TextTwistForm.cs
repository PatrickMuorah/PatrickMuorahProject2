using PatrickMuorahProject2.Model;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace PatrickMuorahProject2
{
    /// <summary>
    /// Implements a variation of a Text Twist game as a standalone GUI application.
    /// </summary>
    public partial class TextTwistMainForm : Form
    {
        private int score = 0;
        private HashSet<string> validWords = new HashSet<string>();
        private HashSet<string>? dictionary;
        private List<Words> validWordEntries = new List<Words>();
        private List<Words> invalidWordEntries = new List<Words>();
        private Timer gameTimer;
        private int remainingTime; 
        private int gameDuration = 60; 
        private int currentScore;
      


        /// <summary>
        /// Constructor method
        /// </summary>
        public TextTwistMainForm()
        {
            InitializeComponent();
            LoadDictionary();
            score_lbl.Text = $"Score: {score}";

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
        }

        /// <summary>
        /// Checks the current time, updates the remaining seconds, and stops the game when the time runs out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                timer_lbl.Text = "Your Time is Up!";
                DisplayRoundResults();
            }
        }

        /// <summary>
        /// Loads the words from the "dictionary.json" file into a HashSet.
        /// </summary>
        private void LoadDictionary()
        {
            string filePath = Path.Combine(Application.StartupPath, "C:\\Users\\Muorah Patrick\\source\\repos\\PatrickMuorahProject2\\PatrickMuorahProject2\\dictionary.json");

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                jsonContent = jsonContent.Trim();
                if (jsonContent.StartsWith("[") && jsonContent.EndsWith("]"))
                {
                    jsonContent = jsonContent.Substring(1, jsonContent.Length - 2);
                    string[] words = jsonContent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dictionary = new HashSet<string>(
                        words.Select(word => word.Trim().Trim('\"').ToLower())
                    );
                }
                else
                {
                    MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dictionary = new HashSet<string>();
                }
            }
            else
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dictionary = new HashSet<string>();
            }


        }

        /// <summary>
        /// Handles the click event of the submit button when the user enters and submits a word for scoring.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    int wordPoints = CalculatePoints(word);
                    wordEntry.Points = wordPoints;

                    validWordEntries.Add(wordEntry);
                    score += wordPoints;

                    feedback_lbl.Text = $"{word} is a valid word! You earned {wordPoints} points.";
                    score_lbl.Text = $"Score: {score}";
                }
                else
                {
                    feedback_lbl.Text = $"The word {word} was already submitted.";
                }
            }
            else
            {
                wordEntry.Reason = "Invalid word, not found in dictionary";
                invalidWordEntries.Add(wordEntry);
                feedback_lbl.Text = $"The word, {word} is invalid!";
            }

            input_textBox.Clear();
        }

        /// <summary>
        /// Handles the click event of the New Game button, displays a new set of random letters and resets game stats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_btn_Click(object sender, EventArgs e)
        {
            DisplayRandomLetters();

            remainingTime = gameDuration;
            timer_lbl.Text = $"Time: {remainingTime / 60:D2}:{remainingTime % 60:D2}";
            gameTimer.Start();

            validWords.Clear();
            validWordEntries.Clear();
            invalidWordEntries.Clear();
            score = 0;
            score_lbl.Text = "Score: 0";
        }

        /// <summary>
        /// Displays random letters for users to create words from.
        /// </summary>
        private void DisplayRandomLetters()
        {
            var letters = GenerateRandomLetters();
            letters_lbl.Text = string.Join(" ", letters);
        }

        /// <summary>
        /// Displays random letters that'd be displayed to the player.
        /// </summary>
        /// <returns></returns>
        private List<char> GenerateRandomLetters()
        {
            var random = new Random();
            var letterBag = CreateLetterBag();
            var randomLetters = new List<char>();

            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(letterBag.Count);
                randomLetters.Add(letterBag[index]);
                letterBag.RemoveAt(index);
            }
            return randomLetters;
        }

        /// <summary>
        /// This method contains a list of characters, each representing a letter that will be available to the 
        /// player during the game. 
        /// </summary>
        /// <returns>A list of characters with specified frequencies representing a letter bag.</returns>
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

        /// <summary>
        /// Helper method to add letters to the Letter bag.
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="letter"></param>
        /// <param name="count"></param>
        private void AddLetters(List<char> bag, char letter, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bag.Add(letter);
            }
        }

        /// <summary>
        /// Method to check if player entered a valid word.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="displayedLetters"></param>
        /// <returns>True if the word is valid, otherwise false.</returns>
        private bool IsValidWord(string word, List<char> displayedLetters)
        {
            if (dictionary == null)
            {
                feedback_lbl.Text = "Dictionary is null.";
                return false;
            }

            word = word.ToLower();

            if (word.Length < 3)
            {
                feedback_lbl.Text = "The Word must contain 3 or more letters.";
                return false;
            }

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
                    feedback_lbl.Text = "Invalid letters";
                    return false;
                }
                letterCount[letter]--;
            }

            if (!dictionary.Contains(word))
            {
                feedback_lbl.Text = "This Word is not in the dictionary!";
                return false;
            }

            feedback_lbl.Text = "Valid Word!";
            return true;
        }

        /// <summary>
        /// Calculate the points for a valid word based on its length.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>The points awarded for the word based on its length. 
        /// Returns 0 if the word length is not valid</returns>
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
                _ => 0
            };
        }

        /// <summary>
        /// Method to display the results of the current round in a messagebox.
        /// </summary>
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

        /// <summary>
        /// Sets the game timer to 60 seconds, starting the countdown for a round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oneMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 60;
            timer_lbl.Text = "Time: 01:00";
        }

        /// <summary>
        /// Sets the game timer to 120 seconds, starting the countdown for the round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twoMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 120;
            timer_lbl.Text = "Time: 02:00";
        }

        /// <summary>
        /// Sets the game timer to 180 seconds, starting the countdown for the round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void threeMin_btn_Click(object sender, EventArgs e)
        {
            gameDuration = 180;
            timer_lbl.Text = "Time: 03:00";
        }

        /// <summary>
        /// Shuffles the random letters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twist_btn_Click(object sender, EventArgs e)
        {
            var letters = letters_lbl.Text.Replace(" ", "").ToCharArray().ToList();

            var random = new Random();
            for (int i = letters.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }

            letters_lbl.Text = string.Join(" ", letters);
        }

        private List<HighScore> LoadHighScores()
        {
            string filePath = "highscores.txt";
            var highScores = new List<HighScore>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        int score = int.Parse(parts[1]);
                        string time = parts[2];
                        highScores.Add(new HighScore(name, score, time));
                    }
                }
            }
            return highScores;
        }

        private void ResetHighScores()
        {
            string filePath = "C:\\Users\\Muorah Patrick\\source\\repos\\PatrickMuorahProject2\\PatrickMuorahProject2\\highscores.txt";
            File.WriteAllText(filePath, string.Empty); // Clears the file
        }

        private void highScore_btn_Click(object sender, EventArgs e)
        {
            var highScores = LoadHighScores();
            string display = string.Join(Environment.NewLine, highScores.Select(hs => hs.ToString()));
            MessageBox.Show(display == string.Empty ? "No high scores yet!" : display, "High Scores");
        }

        private void resetHighScore_btn_Click(object sender, EventArgs e)
        {
            ResetHighScores();
            MessageBox.Show("High scores have been reset!", "Reset High Scores");
        }

    }
}
