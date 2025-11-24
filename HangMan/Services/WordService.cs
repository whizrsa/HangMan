using HangMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan.Services
{
    public class WordService
    {
        private readonly Dictionary<WordCategory, List<string>> _wordsByCategory;
        private readonly Random _random;

        public WordService()
        {
            _random = new Random();
            _wordsByCategory = new Dictionary<WordCategory, List<string>>
            {
                {
                    WordCategory.Animals,
                    new List<string>
                    {
                        "ELEPHANT", "GIRAFFE", "PENGUIN", "DOLPHIN", "TIGER",
                        "LEOPARD", "CHEETAH", "KANGAROO", "RHINOCEROS", "HIPPOPOTAMUS",
                        "CROCODILE", "BUTTERFLY", "FLAMINGO", "OCTOPUS", "PLATYPUS"
                    }
                },
                {
                    WordCategory.Movies,
                    new List<string>
                    {
                        "INCEPTION", "AVATAR", "TITANIC", "GLADIATOR", "INTERSTELLAR",
                        "CASABLANCA", "GODFATHER", "MATRIX", "JAWS", "ROCKY",
                        "BATMAN", "FROZEN", "MOANA", "BRAVEHEART", "PSYCHO"
                    }
                },
                {
                    WordCategory.Technology,
                    new List<string>
                    {
                        "COMPUTER", "INTERNET", "SOFTWARE", "DATABASE", "ALGORITHM",
                        "PROGRAMMING", "KEYBOARD", "MONITOR", "PROCESSOR", "SMARTPHONE",
                        "ARTIFICIAL", "INTELLIGENCE", "BLUETOOTH", "CYBERSECURITY", "QUANTUM"
                    }
                },
                {
                    WordCategory.Countries,
                    new List<string>
                    {
                        "AUSTRALIA", "BRAZIL", "CANADA", "DENMARK", "EGYPT",
                        "FRANCE", "GERMANY", "INDIA", "JAPAN", "KENYA",
                        "MEXICO", "NORWAY", "PORTUGAL", "SINGAPORE", "THAILAND"
                    }
                },
                {
                    WordCategory.Sports,
                    new List<string>
                    {
                        "FOOTBALL", "BASKETBALL", "TENNIS", "CRICKET", "BASEBALL",
                        "VOLLEYBALL", "SWIMMING", "GYMNASTICS", "HOCKEY", "BOXING",
                        "CYCLING", "WRESTLING", "ARCHERY", "BADMINTON", "SKATEBOARDING"
                    }
                },
                {
                    WordCategory.Food,
                    new List<string>
                    {
                        "PIZZA", "HAMBURGER", "SPAGHETTI", "CHOCOLATE", "SANDWICH",
                        "PANCAKES", "BURRITO", "SUSHI", "LASAGNA", "TACOS",
                        "CROISSANT", "CHEESECAKE", "STRAWBERRY", "AVOCADO", "BROCCOLI"
                    }
                }
            };
        }

        public string GetRandomWord(WordCategory category, Difficulty difficulty)
        {
            var words = _wordsByCategory[category];
            
            // Filter by difficulty based on word length - C# 7.3 compatible
            List<string> filteredWords;
            
            if (difficulty == Difficulty.Easy)
            {
                filteredWords = words.Where(w => w.Length <= 6).ToList();
            }
            else if (difficulty == Difficulty.Medium)
            {
                filteredWords = words.Where(w => w.Length > 6 && w.Length <= 9).ToList();
            }
            else if (difficulty == Difficulty.Hard)
            {
                filteredWords = words.Where(w => w.Length > 9).ToList();
            }
            else
            {
                filteredWords = words;
            }

            // Fallback to all words if no words match the difficulty
            if (filteredWords.Count == 0)
                filteredWords = words;

            int index = _random.Next(filteredWords.Count);
            return filteredWords[index].ToUpper();
        }

        public List<WordCategory> GetAllCategories()
        {
            return Enum.GetValues(typeof(WordCategory)).Cast<WordCategory>().ToList();
        }

        public List<Difficulty> GetAllDifficulties()
        {
            return Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
        }
    }
}
