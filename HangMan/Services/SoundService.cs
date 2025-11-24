using System;
using System.IO;
using System.Media;
using System.Windows;

namespace HangMan.Services
{
    public class SoundService
    {
        private SoundPlayer _correctSound;
        private SoundPlayer _incorrectSound;
        private SoundPlayer _winSound;
        private SoundPlayer _loseSound;
        private bool _isMuted;

        public bool IsMuted
        {
            get => _isMuted;
            set => _isMuted = value;
        }

        public SoundService()
        {
            _isMuted = false;
            InitializeSounds();
        }

        private void InitializeSounds()
        {
            try
            {
                // Use system sounds as fallback
                // In a real application, you would load custom sound files
                // For now, we'll use simple beep patterns
            }
            catch (Exception ex)
            {
                // Silently fail if sounds can't be loaded
                System.Diagnostics.Debug.WriteLine($"Sound initialization error: {ex.Message}");
            }
        }

        public void PlayCorrectGuess()
        {
            if (!_isMuted)
            {
                try
                {
                    SystemSounds.Beep.Play();
                }
                catch { }
            }
        }

        public void PlayIncorrectGuess()
        {
            if (!_isMuted)
            {
                try
                {
                    SystemSounds.Hand.Play();
                }
                catch { }
            }
        }

        public void PlayWin()
        {
            if (!_isMuted)
            {
                try
                {
                    SystemSounds.Exclamation.Play();
                }
                catch { }
            }
        }

        public void PlayLose()
        {
            if (!_isMuted)
            {
                try
                {
                    SystemSounds.Asterisk.Play();
                }
                catch { }
            }
        }

        public void ToggleMute()
        {
            _isMuted = !_isMuted;
        }
    }
}
