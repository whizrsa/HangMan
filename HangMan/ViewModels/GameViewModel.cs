using HangMan.Models;
using HangMan.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HangMan.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly WordService _wordService;
        private readonly SoundService _soundService;
        private readonly HighScoreService _highScoreService;
        private readonly GameState _gameState;

        private string _displayedWord;
        private string _incorrectGuessesDisplay;
        private int _hangmanStage;
        private bool _isGameActive;
        private bool _showStartScreen;
        private bool _showGameOverScreen;
        private string _gameOverMessage;
        private WordCategory _selectedCategory;
        private Difficulty _selectedDifficulty;
        private int _currentScore;
        private bool _isMuted;

        public ObservableCollection<WordCategory> Categories { get; }
        public ObservableCollection<Difficulty> Difficulties { get; }
        public ObservableCollection<HighScore> HighScores { get; }

        public ICommand StartGameCommand { get; }
        public ICommand GuessLetterCommand { get; }
        public ICommand RestartGameCommand { get; }
        public ICommand ExitGameCommand { get; }
        public ICommand ToggleSoundCommand { get; }

        public GameViewModel()
        {
            _wordService = new WordService();
            _soundService = new SoundService();
            _highScoreService = new HighScoreService();
            _gameState = new GameState();

            Categories = new ObservableCollection<WordCategory>(_wordService.GetAllCategories());
            Difficulties = new ObservableCollection<Difficulty>(_wordService.GetAllDifficulties());
            HighScores = new ObservableCollection<HighScore>(_highScoreService.GetTopScores());

            _selectedCategory = WordCategory.Animals;
            _selectedDifficulty = Difficulty.Easy;
            _showStartScreen = true;
            _isGameActive = false;

            StartGameCommand = new RelayCommand(_ => StartGame());
            GuessLetterCommand = new RelayCommand(letter => GuessLetter((string)letter), _ => _isGameActive);
            RestartGameCommand = new RelayCommand(_ => ResetToStartScreen());
            ExitGameCommand = new RelayCommand(_ => Application.Current.Shutdown());
            ToggleSoundCommand = new RelayCommand(_ => ToggleSound());

            LoadHighScores();
        }

        #region Properties

        public string DisplayedWord
        {
            get => _displayedWord;
            set => SetProperty(ref _displayedWord, value);
        }

        public string IncorrectGuessesDisplay
        {
            get => _incorrectGuessesDisplay;
            set => SetProperty(ref _incorrectGuessesDisplay, value);
        }

        public int HangmanStage
        {
            get => _hangmanStage;
            set => SetProperty(ref _hangmanStage, value);
        }

        public bool IsGameActive
        {
            get => _isGameActive;
            set => SetProperty(ref _isGameActive, value);
        }

        public bool ShowStartScreen
        {
            get => _showStartScreen;
            set => SetProperty(ref _showStartScreen, value);
        }

        public bool ShowGameOverScreen
        {
            get => _showGameOverScreen;
            set => SetProperty(ref _showGameOverScreen, value);
        }

        public string GameOverMessage
        {
            get => _gameOverMessage;
            set => SetProperty(ref _gameOverMessage, value);
        }

        public WordCategory SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public Difficulty SelectedDifficulty
        {
            get => _selectedDifficulty;
            set => SetProperty(ref _selectedDifficulty, value);
        }

        public int CurrentScore
        {
            get => _currentScore;
            set => SetProperty(ref _currentScore, value);
        }

        public bool IsMuted
        {
            get => _isMuted;
            set => SetProperty(ref _isMuted, value);
        }

        #endregion

        private void StartGame()
        {
            _gameState.Reset();
            _gameState.Category = SelectedCategory;
            _gameState.Difficulty = SelectedDifficulty;
            _gameState.SelectedWord = _wordService.GetRandomWord(SelectedCategory, SelectedDifficulty);

            ShowStartScreen = false;
            ShowGameOverScreen = false;
            IsGameActive = true;
            HangmanStage = 0;
            CurrentScore = 0;

            UpdateDisplayedWord();
            UpdateIncorrectGuesses();
        }

        private void GuessLetter(string letter)
        {
            if (string.IsNullOrEmpty(letter) || _gameState.IsGameOver)
                return;

            char guessedChar = char.ToUpper(letter[0]);

            // Check if already guessed
            if (_gameState.CorrectGuesses.Contains(guessedChar) || 
                _gameState.IncorrectGuesses.Contains(guessedChar))
                return;

            if (_gameState.SelectedWord.Contains(guessedChar))
            {
                _gameState.CorrectGuesses.Add(guessedChar);
                _soundService.PlayCorrectGuess();
                UpdateDisplayedWord();

                if (IsWordGuessed())
                {
                    WinGame();
                }
            }
            else
            {
                _gameState.IncorrectGuesses.Add(guessedChar);
                _gameState.WrongGuessCount++;
                HangmanStage = _gameState.WrongGuessCount;
                _soundService.PlayIncorrectGuess();
                UpdateIncorrectGuesses();

                if (_gameState.WrongGuessCount >= _gameState.MaxWrongGuesses)
                {
                    LoseGame();
                }
            }
        }

        private bool IsWordGuessed()
        {
            return _gameState.SelectedWord.All(c => _gameState.CorrectGuesses.Contains(c));
        }

        private void WinGame()
        {
            _gameState.IsGameOver = true;
            _gameState.HasWon = true;
            IsGameActive = false;

            // Calculate score
            int baseScore = 100;
            int difficultyBonus = (int)_selectedDifficulty * 50;
            int mistakePenalty = _gameState.WrongGuessCount * 10;
            CurrentScore = Math.Max(0, baseScore + difficultyBonus - mistakePenalty);
            _gameState.Score = CurrentScore;

            _soundService.PlayWin();
            GameOverMessage = $"Congratulations! You Won!\n\nWord: {_gameState.SelectedWord}\nScore: {CurrentScore} points";

            // Check for high score
            if (_highScoreService.IsHighScore(CurrentScore))
            {
                var highScore = new HighScore
                {
                    PlayerName = "Player",
                    Score = CurrentScore,
                    Difficulty = SelectedDifficulty,
                    Category = SelectedCategory
                };
                _highScoreService.AddHighScore(highScore);
                LoadHighScores();
            }

            ShowGameOverScreen = true;
        }

        private void LoseGame()
        {
            _gameState.IsGameOver = true;
            _gameState.HasWon = false;
            IsGameActive = false;

            _soundService.PlayLose();
            GameOverMessage = $"Game Over!\n\nThe word was: {_gameState.SelectedWord}\nBetter luck next time!";
            ShowGameOverScreen = true;
        }

        private void UpdateDisplayedWord()
        {
            StringBuilder display = new StringBuilder();

            foreach (char letter in _gameState.SelectedWord)
            {
                if (_gameState.CorrectGuesses.Contains(letter))
                {
                    display.Append(letter);
                    display.Append(" ");
                }
                else
                {
                    display.Append("_ ");
                }
            }

            DisplayedWord = display.ToString().TrimEnd();
        }

        private void UpdateIncorrectGuesses()
        {
            if (_gameState.IncorrectGuesses.Count == 0)
            {
                IncorrectGuessesDisplay = "None";
            }
            else
            {
                IncorrectGuessesDisplay = string.Join(", ", _gameState.IncorrectGuesses);
            }
        }

        private void ResetToStartScreen()
        {
            ShowGameOverScreen = false;
            ShowStartScreen = true;
            IsGameActive = false;
        }

        private void LoadHighScores()
        {
            HighScores.Clear();
            foreach (var score in _highScoreService.GetTopScores())
            {
                HighScores.Add(score);
            }
        }

        private void ToggleSound()
        {
            _soundService.ToggleMute();
            IsMuted = _soundService.IsMuted;
        }

        public void HandleKeyPress(string key)
        {
            if (!IsGameActive || string.IsNullOrEmpty(key))
                return;

            if (key.Length == 1 && char.IsLetter(key[0]))
            {
                GuessLetter(key);
            }
        }
    }
}
