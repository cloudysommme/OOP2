using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Games
{
    class BotGame : Game
    {
       
        public override int RatingPlayed(int rating)
        {
            return rating / 2;
        }

      
        public BotGame(string user, int rating, bool outcome) : base(user, "BOT", rating, outcome)
        {

        }
    }

}
