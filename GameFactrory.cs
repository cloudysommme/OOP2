using OOP2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
     class GameFactory
    {
        public static Game CreateGame(string gameType, string name, string opponentName, int rating, bool outcome)
        {
            return gameType.ToLower() switch
            {
                "standart" => new StandartGame(name, opponentName, rating, outcome),
                "training" => new TrainingGame(name, opponentName, rating, outcome),
                "bot" => new BotGame(name, rating, outcome),
                _ => throw new ArgumentException("Invalid game type"),
            };
        }
    }
}
