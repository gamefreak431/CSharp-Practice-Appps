using System;
using System.Threading.Tasks.Dataflow;

namespace DnD_INT_Order_Tracker
{
    class DnDCharacter
    {
        private string name;
        private int roll = 0;
        private string charType;

        public string CharType
        {
            get { return charType; }
            set { charType = value; }
        }

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

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("D&D INT Order Tracker is Running");
            Console.WriteLine("How many players in the party?");
            int partySize = Convert.ToInt32(Console.ReadLine());
            DnDCharacter[] partyMembers = new DnDCharacter[partySize];
            int[] rollList = new int[partySize];

            for (int x = 0; x < partySize; x++) 
            {
                int playerNumber = x + 1;
                partyMembers[x] = new DnDCharacter();
                partyMembers[x].CharType = "Player";
                Console.WriteLine("Player " + playerNumber + " name?");
                partyMembers[x].Name = Console.ReadLine();
                Console.WriteLine("What is " + partyMembers[x].Name + "'s" + " Initiative roll?");
                partyMembers[x].Roll = Convert.ToInt32(Console.ReadLine());
                rollList.SetValue(partyMembers[x].Roll, x);
            }

            Array.Sort(rollList);
            Array.Reverse(rollList);

            Console.WriteLine("");

            foreach (int number in rollList) 
            {
                for (int x = 0; x < partySize; x++) 
                {
                    if (number == partyMembers[x].Roll)
                    {
                        Console.WriteLine(partyMembers[x].Name + " - " + partyMembers[x].Roll);
                    }
                }
            }
        }
    }
}
