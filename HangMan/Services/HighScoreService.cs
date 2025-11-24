using HangMan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HangMan.Services
{
    public class HighScoreService
    {
        private readonly string _filePath;
        private List<HighScore> _highScores;

        public HighScoreService()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string gameFolder = Path.Combine(appDataPath, "HangmanGame");
            
            if (!Directory.Exists(gameFolder))
                Directory.CreateDirectory(gameFolder);

            _filePath = Path.Combine(gameFolder, "highscores.xml");
            LoadHighScores();
        }

        private void LoadHighScores()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                    using (FileStream fs = new FileStream(_filePath, FileMode.Open))
                    {
                        _highScores = (List<HighScore>)serializer.Deserialize(fs);
                    }
                }
                else
                {
                    _highScores = new List<HighScore>();
                }
            }
            catch
            {
                _highScores = new List<HighScore>();
            }
        }

        private void SaveHighScores()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                using (FileStream fs = new FileStream(_filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, _highScores);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving high scores: {ex.Message}");
            }
        }

        public void AddHighScore(HighScore score)
        {
            _highScores.Add(score);
            _highScores = _highScores.OrderByDescending(s => s.Score).Take(10).ToList();
            SaveHighScores();
        }

        public List<HighScore> GetTopScores(int count = 10)
        {
            return _highScores.OrderByDescending(s => s.Score).Take(count).ToList();
        }

        public bool IsHighScore(int score)
        {
            if (_highScores.Count < 10)
                return true;
            
            return score > _highScores.Min(s => s.Score);
        }
    }
}
