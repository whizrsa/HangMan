using System;

namespace HangMan.Models
{
    public class HighScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public WordCategory Category { get; set; }

        public HighScore()
        {
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{PlayerName} - {Score} pts ({Difficulty}) - {Date:MM/dd/yyyy}";
        }
    }
}
