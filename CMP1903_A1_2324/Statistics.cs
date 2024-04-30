using System;

namespace CMP1903_A1_2324{ 
    internal static class Statistics{
        private static int _sevensOutHighScore = 0;
        private static int _sevensOutPlayCount = 0;
        private static int _threeOrMorePlayCount = 0;
        public static void SevensOutUpdateHighScore(int score)
        {
            if (score > _sevensOutHighScore)
            {
                _sevensOutHighScore = score;
            }
        }
        public static void SevensOutIncrementPlayCount()
        {
            _sevensOutPlayCount++;
        }
        public static void ThreeOrMoreIncrementPlayCount()
        {
            _threeOrMorePlayCount++;
        }
        public static void DisplayStatistics()
        {
            Console.WriteLine($"===Statistics===" +
                $"\n==Sevens Out==" +
                $"\nHighscore by human player: {_sevensOutHighScore}" +
                $"\nPlay count: {_sevensOutPlayCount}" +
                $"\n==Three Or More==" +
                $"\nPlay count: {_threeOrMorePlayCount}");
        }
    }
}
