using System;                         // Asher Alexander 206195356                            
using System.Collections.Generic;    //      & Zvei Eliezer Nir 316525344
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
            string choice, jumpK = "asher&zvei";

            do
            {

                Console.WriteLine("To absorve each move press ENTER");
                Console.WriteLine("in order to run til the end enter 0.");
                while (!warGame.isFinished())
                {


                    if (jumpK != "0") // stops each turn to watch
                    {
                        Console.WriteLine("Enter 0 to finish...");
                        jumpK = Console.ReadLine();
                    }

                    warGame.turn(); // makes a turn

                }

                // Console.BackgroundColor = ConsoleColor.DarkGreen; // a bit of color
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(warGame.whoWin()); // prints name of winner 
                Console.ResetColor();

                Console.WriteLine("Do you want to play again?\nIf yes Enter 1.");

                choice = Console.ReadLine();
                jumpK = "asher&zvei";
                if (choice == "1")
                    warGame.restart();// restarts for a new game

            } while (choice == "1");// if player entered 1 it will keep playing

            Console.WriteLine("Thanks for playing\n\tHave a nice day!\n");
            Console.ReadKey();
        }

    }
}
/*
enter first player name:
asher
enter second player name:
zvei
asher have 13 cards.
List of cards:
 red King
 black 9
 red 3
 black 2
 black 4
 black 10
 red 5
 red 6
 black 7
 red 4
 black 8
 black Ace
 red 8

zvei have 13 cards.
List of cards:
 red 7
 red Jack
 red Ace
 red Queen
 red 10
 red 2
 black 6
 black Jack
 black 5
 black 3
 black Queen
 black King
 red 9

To absorve each move press ENTER
in order to run til the end enter 0.
Enter 0 to finish...
0
new turn:
asher  red King

zvei  red 7

asher takes!
asher have 14 cards
zvei have 12 cards


new turn:
asher  black 9

zvei  red Jack

zvei takes!
asher have 13 cards
zvei have 13 cards


new turn:
asher  red 3

zvei  red Ace

zvei takes!
asher have 12 cards
zvei have 14 cards


new turn:
asher  black 2

zvei  red Queen

zvei takes!
asher have 11 cards
zvei have 15 cards
.........
new turn:
asher  black 8

zvei  red 8

asher  red 6

zvei  red 3

asher  red Ace

zvei  black 7

zvei is out of cards...
Congratulations!  asher is the winner
Do you want to play again?
If yes Enter 1.

*/
