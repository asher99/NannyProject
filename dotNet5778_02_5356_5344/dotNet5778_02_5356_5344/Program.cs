using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{

    class Program
    {
        static void Main(string[] args)
        {
            Game warGame = new Game();
            string choice;
            do
            {
                
                while (!warGame.isFinished())
                {
                    warGame.turn();
                }
                Console.WriteLine(warGame.whoWin());

                
                Console.WriteLine("Do you want to play again?\nif yes Enter 1.");
         
                choice = Console.ReadLine();
                
                warGame.restart();
            } while (choice == "1");

            Console.WriteLine("Thanks for playing\n\tHave a nice day!\n");
            Console.ReadKey();
        }
        
    }
}
