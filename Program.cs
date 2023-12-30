using System;
using OOP2.Accounts;

class Program
{
    static void Main()
    {
        StandartAccount Bobik_Standart = new StandartAccount("Bobik", 200);
        StandartAccount Lyolik_Standart = new StandartAccount("Lyolik", 100);
        WinStreakAccount Kebab_Streak = new WinStreakAccount("Kebab", 300);
        PremiumAccount Nazik_Plus = new PremiumAccount("Nazik", 100);


        Bobik_Standart.PlayGame(Lyolik_Standart, false, 20, "standart");
        Bobik_Standart.PlayGame(Nazik_Plus, true, 50, "training");
        Bobik_Standart.PlayGame(Kebab_Streak, true, 30, "standart");

        Lyolik_Standart.PlayGame(Lyolik_Standart, true, 70, "");
        Lyolik_Standart.PlayGame(Nazik_Plus, false, 23, "standart");

        Kebab_Streak.PlayGame(Lyolik_Standart, true, 15, "standart");
        Kebab_Streak.PlayGame(Bobik_Standart, false, 20, "training");
        Kebab_Streak.PlayGame(Nazik_Plus, true, 20, "standart");

        Nazik_Plus.PlayGame(Kebab_Streak, false, 80, "standart");
        Nazik_Plus.PlayGame(Bobik_Standart, true, 80, "standart");

        Bobik_Standart.GetStats();
        Lyolik_Standart.GetStats();
        Kebab_Streak.GetStats();
        Nazik_Plus.GetStats();
    }
}
