using System;
using System.Collections.Generic;
using OOP2.Games;

namespace OOP2.Accounts
{
     class GameAccount
    {
        public string UserName { get; set; }
        private int currentRating = 1;
        public int CurrentRating
        {
            get { return currentRating; }
            set
            {
                if (value < 1)
                {
                    currentRating = 1;
                }
                else { currentRating = value; }
            }
        }
        public int GamesCount { get => gameHistory.Count(); }
        public List<GameAccount> Opponents { get; set; } = new List<GameAccount>();
        private List<Game> gameHistory = new();
        public GameAccount(string userName, int initialRating)
        {
            UserName = userName;
            CurrentRating = initialRating;
        }

        public void PlayGame(GameAccount opponent, bool result, int rating, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            }
            else if (this != opponent)
            {
                if (result)
                {
                    gameHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, true));
                    opponent.gameHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, false));
                    WinGame(gameHistory.Last());
                    opponent.LoseGame(opponent.gameHistory.Last());
                }
                else
                {
                    gameHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, false));
                    opponent.gameHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, true));
                    LoseGame(gameHistory.Last());
                    opponent.WinGame(opponent.gameHistory.Last());
                }

                gameHistory.Last().GameId = ++Game.lastID;
                opponent.gameHistory.Last().GameId = Game.lastID;
            }
            else
            {
                if (result)
                {
                    gameHistory.Add(GameFactory.CreateGame("Bot", UserName, "", rating, true));
                    WinGame(gameHistory.Last());
                }
                else
                {
                    gameHistory.Add(GameFactory.CreateGame("Bot", UserName, "", rating, true));
                    LoseGame(gameHistory.Last());
                }
                gameHistory.Last().GameId = ++Game.lastID;
            }
        }


        protected virtual void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating;
            }
        }
        private void WinGame(Game game)
        {
            GameRating(true, game.Rating);
            game.PlayerRatingAfter = CurrentRating;
        }

        private void LoseGame(Game game)
        {
            GameRating(false, game.Rating);
            game.PlayerRatingAfter = CurrentRating;
        }

        public void GetStats()
        {
            Console.WriteLine($"Game history for {UserName}(Rating: {CurrentRating}):");

            Console.WriteLine("│      ID        │   User   │ Opponent │ Rating  │ Result │ Current Rating  │");
            Console.WriteLine("├────────────────┼──────────┼──────────┼─────────┼────────┼─────────────────┤");

            for (int i = 0; i < GamesCount; i++)
            {
                Console.WriteLine($"│ {gameHistory[i].GameId,14} │ {gameHistory[i].Name,-8} │ {gameHistory[i].OpponentName,-8} │ {gameHistory[i].Rating,7} │ {gameHistory[i].Outcome,-6} │ {gameHistory[i].PlayerRatingAfter,15} │");
                Console.WriteLine("├────────────────┼──────────┼──────────┼─────────┼────────┼─────────────────┤");
            }

            Console.WriteLine();
        }




    }
}
