using System.Collections.Generic;

namespace HangMan.Models
{
    public class GameState
    {
        public string SelectedWord { get; set; }
        public List<char> CorrectGuesses { get; set; }
        public List<char> IncorrectGuesses { get; set; }
        public int WrongGuessCount { get; set; }
        public int MaxWrongGuesses { get; set; }
        public WordCategory Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsGameOver { get; set; }
        public bool HasWon { get; set; }
        public int Score { get; set; }

        public GameState()
        {
            CorrectGuesses = new List<char>();
            IncorrectGuesses = new List<char>();
            MaxWrongGuesses = 10;
            WrongGuessCount = 0;
            IsGameOver = false;
            HasWon = false;
        }

        public void Reset()
        {
            CorrectGuesses.Clear();
            IncorrectGuesses.Clear();
            WrongGuessCount = 0;
            IsGameOver = false;
            HasWon = false;
            Score = 0;
            SelectedWord = null;
        }
    }
}
