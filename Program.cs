using System;
using System.Linq;
using System.Security.Cryptography;

namespace game
{
    class Program
    {
        static void Main(string[] items)
        {
            if (items.Length < 3 || items.Length % 2 == 0 || items.Distinct().ToArray().Length != items.Length)
            {
                Console.WriteLine("Wrong parameters. Number of parameters >= 3 and necessarily an odd number.\n" +
                "Example: \"Rock Scissors Paper\" or \"Rock Scissors Paper Lizard Spock\" or \"1 2 3 4 5 6 7 8 9\".");
                return;
            }

            while (true)
            {
                int move_computer = RandomNumberGenerator.GetInt32(items.Length);
                string[] hmac = HMACGenerator.getHMAC(items[move_computer]);

                Console.WriteLine("HMAC: " + hmac[0]);
                printMoves(items);
                string move_user = Console.ReadLine();

                if (move_user == "0") break;
                else if (move_user == "?") Table.print(items);
                else if (int.TryParse(move_user, out _) && Convert.ToInt32(move_user) > 0 && Convert.ToInt32(move_user) <= items.Length)
                {
                    Console.WriteLine("Your move: " + items[Convert.ToInt32(move_user) - 1] +
                    "\nComputer move: " + items[move_computer] +
                    "\n" + Winner.whoWin(Convert.ToInt32(move_user) - 1, move_computer, items.Length) +
                    "\nHMAC key: " + hmac[1] + "\n");
                }
                else Console.WriteLine("");
            }
        }

        static void printMoves(string[] items)
        {
            Console.WriteLine("Available moves: ");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + items[i]);
            }
            Console.Write("0 - exit \n? - help \nEnter your move: ");
        }
    }
}