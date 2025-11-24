using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HangMan.Converters
{
    public class StageVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int currentStage && parameter is string stageStr)
            {
                if (int.TryParse(stageStr, out int requiredStage))
                {
                    return currentStage >= requiredStage ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MuteToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isMuted)
            {
                // Use simple text instead of emojis for better compatibility
                return isMuted ? "[MUTED]" : "[SOUND ON]";
            }
            return "[SOUND ON]";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // C# 7.3 compatible version
            if (value is int stage)
            {
                if (stage <= 3)
                {
                    return "#27AE60"; // Green
                }
                else if (stage <= 6)
                {
                    return "#F39C12"; // Orange
                }
                else
                {
                    return "#E74C3C"; // Red
                }
            }
            return "#27AE60";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
