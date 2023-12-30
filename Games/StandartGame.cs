using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Games
{
    class StandartGame : Game
    {
        public override int RatingPlayed(int rating)
        {
            return rating;
        }

        public StandartGame(string user, string opponent, int rating, bool outcome) : base(user, opponent, rating, outcome)
        {

        }
    }
}
