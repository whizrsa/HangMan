using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace HangMan
{
    public partial class Form1 : Form
    {
        //private List<string> guessWords = new List<string>();
        private List<string> guessWords = new List<string>();
        private string selectedWord;
        private int wrongGuessCount = 0;
        private List<char> correctGuesses = new List<char>();
        private List<char> incorrectGuesses = new List<char>();
        private List<int> scores = new List<int>();

        public Form1()
        {
            InitializeComponent();
            // Set the KeyPreview property to true
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach the KeyDown event to the form
            this.KeyDown += MainForm_KeyDown;

            // Focus on the UserInput text box to capture key events
            UserInput.Focus();

            // Start a new game when the form loads
            StartNewGame();
        }

        private void InitialiseWordList()
        {
            //add words to be guesses to the list
            // I used lists for my personal taste you could choose other data structures or arrays.
            guessWords.Add("Darleen");
            guessWords.Add("Elvis");
            guessWords.Add("Mazda");
            guessWords.Add("Mercy");
        }

        private void StartNewGame()
        {
            InitialiseWordList();

            if (guessWords.Count > 0)
            {
                selectedWord = GetRandomWord();
            }
            else
            {
                MessageBox.Show("No words to guess. Add words to the list.");
                return;
            }

            wrongGuessCount = 0;
            correctGuesses.Clear();
            incorrectGuesses.Clear();
            UpdateDisplayedWord();
            UpdateIncorrectGuessesListBox();
        }
        

        private string GetRandomWord()
        {
            //we need for the words to be ramdom so we use the built in random class
            //provides us withn a random word
            Random random = new Random();
            int index = random.Next(guessWords.Count);
            return guessWords[index].ToUpper();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            char guessedLetter = e.KeyCode.ToString().ToUpper()[0];

            if (char.IsLetter(guessedLetter))
            {
                if (!string.IsNullOrEmpty(selectedWord))
                {
                    if (selectedWord.Contains(guessedLetter))
                    {
                        correctGuesses.Add(guessedLetter);
                        UpdateDisplayedWord();
                    }
                    else
                    {
                        incorrectGuesses.Add(guessedLetter);
                        wrongGuessCount++;
                        UpdateIncorrectGuessesListBox();
                    }

                    CheckWinLoseConditions();
                }
                else
                {
                    MessageBox.Show("No word selected. Start a new game.");
                    StartNewGame();
                }
            }
        }

        private void CheckWinLoseConditions()
        {
            if (wordIsGuessed())
            {
                //Player Won
                //call the updateScoreBoard Function
                UpdateScoreBoard();
                MessageBox.Show("Congrats!! You have WON!!");
                //After player has won they can start a new game
                StartNewGame();

            }
            else if (wrongGuessCount >= 10)
            {
                //Player has lost
                MessageBox.Show("Sadly you have lost!! Try Again");
                //the player will have to start a new game after he/she has lost
                StartNewGame();
            }
        }

        private bool wordIsGuessed()
        {
            foreach (char letter in selectedWord)
            {
                if (!correctGuesses.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateScoreBoard()
        {
            // Calculate the score based on the number of incorrect guesses
            int score = 10 - wrongGuessCount;

            // Add the score to the list
            scores.Add(score);

            // Update the scoreboard list box
            UpdateScoreBoardListBox();
        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void WordwithUnderscoreorAst_Click(object sender, EventArgs e)
        {

        }
        private void UpdateScoreBoardListBox()
        {
            // Your implementation to update the scoreboard list box
            // Clear the existing items in the list box
            ScoreBoard.Items.Clear();

            // Add each score to the list box
            foreach (int score in scores)
            {
                ScoreBoard.Items.Add(score);
            }
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            //Check if the StartNewGame function works well and catch errors
            try
            {

                StartNewGame();
                //clears the UserInput textbox after clicking the StartNewGameButton
                UserInput.Text = string.Empty;

            }catch(Exception ex)
            {

                MessageBox.Show("StartNewGame Method did not work correctly", ex.ToString());

            }
        }

        private void StopGame_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IncorrectGuesses_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (IncorrectGuesses.SelectedItem != null)
            {
                string selectedIncorrectGuess = IncorrectGuesses.SelectedItem.ToString();
                MessageBox.Show($"You selected an incorrect guess: {selectedIncorrectGuess}");
            }
        }

        private void UpdateIncorrectGuessesListBox()
        {
            // Clear the existing items in the list box
            IncorrectGuesses.Items.Clear();

            // Add each incorrect guess to the list box
            foreach (char letter in incorrectGuesses)
            {
                IncorrectGuesses.Items.Add(letter);
            }
        }

        // Add a method to update the displayed word and the associated list box
        private void UpdateDisplayedWord()
        {
            StringBuilder display = new StringBuilder();

            foreach (char letter in selectedWord)
            {
                if (correctGuesses.Contains(letter))
                {
                    display.Append(letter);
                }
                else
                {
                    display.Append("_");
                }
            }

            WordwithUnderscoreorAst.Text = display.ToString();
        }

        private void ScoreBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            //basically if you click on a score in the ScoreBoard listbox a message will pop up
            if (ScoreBoard.SelectedItem != null)
            {
                MessageBox.Show($"You selected a score: {ScoreBoard.SelectedItem}");
            }
        }
    }
}
