using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Accounts
{
    class PremiumAccount : GameAccount
    {
        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating * 2;
            }
            else
            {
                CurrentRating -= rating/2;
            }
        }

        public PremiumAccount(string userName, int initialRating = 300) : base(userName, initialRating)
        {

        }
    }
}
