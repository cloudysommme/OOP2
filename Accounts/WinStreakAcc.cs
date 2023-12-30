using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Accounts
{
    class WinStreakAccount : GameAccount
    {
        private int winStreak = 1;

        public WinStreakAccount(string userName, int initialRating = 100) : base(userName, initialRating)
        {
        }

        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating + (winStreak++)*10;
            }
            else
            {
                CurrentRating -= rating;
                winStreak = 0;
            }
        }
    }
}
