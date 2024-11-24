using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickMuorahProject2.Model
{
    internal class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Time { get; set; } // Format: "MM:SS"

        public HighScore(string name, int score, string time)
        {
            Name = name;
            Score = score;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Name}, {Score}, {Time}";
        }
    }
}
