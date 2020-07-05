using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Shadowrun_INT_Tracker
{
    class Runner 
    {
        private string name;
        private int roll = 0;
        private bool isListed = false;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public int Roll 
        {
            get { return roll; }
            set { roll = value; }
        }

        public bool IsListed 
        {
            get { return isListed; }
            set { isListed = value; }
        }
    }

    class ShadowINT
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shadowrun INT Tracker is running!");
            Combat();
        }

        static void Combat()
        {
            Console.WriteLine("How many players and NPCs are in combat?");
            int partySize = Convert.ToInt32(Console.ReadLine());
            Runner[] players = new Runner[partySize];
            int[] diceRolls = new int[partySize];

            for (int x = 0; x < partySize; x++)
            {
                int playernum = x + 1;
                Console.WriteLine("What is Player " + playernum + "'s" + " name?");
                players[x] = new Runner();
                players[x].Name = Console.ReadLine();
                Console.WriteLine("What was " + players[x].Name + "'s" + " initiative roll?");
                players[x].Roll = Convert.ToInt32(Console.ReadLine());
                diceRolls[x] = players[x].Roll;
            }

            InitiativePass();

            void InitiativePass()
            {
                Console.WriteLine();
                Array.Sort(diceRolls);
                Array.Reverse(diceRolls);

                foreach (int roll in diceRolls)
                {
                    for (int x = 0; x < partySize; x++)
                    {
                        if (players[x].Roll == roll && !(players[x].IsListed))
                        {
                            Console.WriteLine(players[x].Name + ": " + players[x].Roll);
                            players[x].IsListed = true;
                        }
                    }
                }

                for (int x = 0; x < partySize; x++) 
                {
                    players[x].IsListed = false;
                    players[x].Roll -= 10;
                    diceRolls[x] -= 10;

                    if (players[x].Roll < 0)
                    {
                        players[x].Roll = 0;
                    }

                    if (diceRolls[x] < 0)
                    {
                        diceRolls[x] = 0;
                    }
                }

                Console.WriteLine();

                int passCheck = diceRolls.Sum();
                if (!(passCheck == 0))
                {
                    Console.WriteLine("Type Y and press Enter to start next initiative pass");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        InitiativePass();
                    }
                }
            }

            Console.WriteLine("Start another round of combat y/n?");
            string resetloop = Console.ReadLine().ToLower();
            if (resetloop == "y")
            {
                Combat();
            }
        }
    }
}
