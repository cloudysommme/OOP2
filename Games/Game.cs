using System;

namespace OOP2.Games
{
    abstract class Game
    {
        public string Name { get; }
        public string OpponentName { get; }
        public int GameId { get; set; }
        public bool Outcome { get; }
        public int Rating { get; }
        public int PlayerRatingAfter { get; set; }

        public abstract int RatingPlayed(int rating);
        public static int lastID = 1;

        public Game(string name, string opponentName,int rating, bool outcome)
        {
            OpponentName = opponentName;
            Name = name;
            Rating = RatingPlayed(rating);
            Outcome = outcome;
        }
    }
}
