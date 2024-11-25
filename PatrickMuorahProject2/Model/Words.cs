using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickMuorahProject2.Model
{
    /// <summary>
    /// This class is used to track valid and invalid words entered by a player.
    /// </summary>
    internal class Words
    {
        /// <summary>
        /// Gets or sets a word entered by the player.
        /// </summary>
        public string? Word { get; set; }

        /// <summary>
        /// Gets or sets the points earned for a word.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets the time when a word was entered by the player.
        /// </summary>
        public DateTime TimeEntered { get; set; }

        /// <summary>
        /// Gets or sets the reason a word was invalid.
        /// </summary>
        public string? Reason { get; set; }

    }
}
