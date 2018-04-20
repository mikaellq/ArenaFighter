using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            string oldName = "Mikael";
            do
            {
                Console.Write("Your name please, only Enter if you want to keep previous name: ");
                string myName = Console.ReadLine();
                string myName2 = myName.Trim();
                Character player = new Character();
                if (myName2.Length > 0) {
                    player.SetName(myName2);
                    oldName = myName2;
                }
                else
                {
                    player.SetName(oldName);
                }

                EnemyCharacter opponent = new EnemyCharacter();
                Battle battle = new Battle();
                char pressedKey = '\r';
                do
                {
                    Round round = new Round(player, opponent, battle);

                    if (player.GetSum() > 0 && opponent.GetSum() > 0)
                    {
                        Console.Write(" \t");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Press 'q' to exit!");
                        Console.ResetColor();
                        pressedKey = Console.ReadKey().KeyChar;
                    }
                } while (pressedKey != 'q' && player.GetSum() > 0 && opponent.GetSum() > 0);
                string s;
                if (player.GetSum() < opponent.GetSum()) { s = opponent.GetName(); }
                else { s = player.GetName(); }
                Console.Beep(600, 200);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n -"+s + " won!- ");
                Console.ResetColor();
//                Console.WriteLine("-------------------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Play again? Press Enter in that case!");
                Console.ResetColor();
//                Console.WriteLine("-------------------------------------\n");
            } while (Console.ReadKey().KeyChar == '\r');
        }
    }
}
