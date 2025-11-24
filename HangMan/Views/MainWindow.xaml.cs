using HangMan.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace HangMan.Views
{
    public partial class MainWindow : Window
    {
        private GameViewModel ViewModel => DataContext as GameViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (ViewModel != null && ViewModel.IsGameActive)
            {
                string key = e.Key.ToString();
                
                // Handle letter keys
                if (key.Length == 1 || (key.StartsWith("D") && key.Length == 2))
                {
                    // Extract the letter from keys like "D1" -> "1"
                    string letter = key.Length == 1 ? key : key.Substring(1);
                    ViewModel.HandleKeyPress(letter);
                }
            }
        }
    }
}
