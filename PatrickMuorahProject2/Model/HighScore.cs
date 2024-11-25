using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickMuorahProject2.Model
{
    /// <summary>
    /// Tracks the data for the high scores in the game.
    /// </summary>
    internal class HighScore
    {
        /// <summary>
        /// Gets or sets the name of the player who got the high score.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the high score obtained by thye player.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the time when the game was completed.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="time"></param>
        public HighScore(string name, int score, string time)
        {
            Name = name;
            Score = score;
            Time = time;
        }

        /// <summary>
        /// Formats the high score as a string.
        /// </summary>
        /// <returns>A string that represents the high score.</returns>
        public override string ToString()
        {
            return $"{Name}, {Score}, {Time}";
        }
    }
}
