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


                    if (jumpK != "0")
                    {
                        Console.WriteLine("Enter 0 to finish...");
                        jumpK = Console.ReadLine();
                    }

                    warGame.turn(); // makes a turn

                }

                Console.BackgroundColor = ConsoleColor.DarkGreen; // a bit of color
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(warGame.whoWin()); // prints name of winner 
                Console.ResetColor();

                Console.WriteLine("Do you want to play again?\nif yes Enter 1.");

                choice = Console.ReadLine();
                jumpK = "asher&zvei";
                warGame.restart();// restarts for a new game
            } while (choice == "1");// if player entered 1 it will keep playing

            Console.WriteLine("Thanks for playing\n\tHave a nice day!\n");
            Console.ReadKey();
        }

    }
}
/*
exp:
 enter first player name:
asher
enter second player name:
zvei
asher have 13 cards.
List of cards:
 red Jack
 red 6
 black 7
 red 9
 black 4
 black Queen
 red 5
 black 5
 black Ace
 red 2
 black Jack
 black 8
 red 10

zvei have 13 cards.
List of cards:
 black 3
 red Queen
 red 7
 red 8
 black 2
 red 3
 black 10
 red King
 black King
 black 9
 red 4
 red Ace
 black 6

To absorve each move press ENTER
in order to run til the end enter 0.
Enter 0 to finish...
0
new turn:
asher  red Jack

zvei  black 3



asher have 14 cards
zvei have 12 cards


new turn:
asher  red 6

zvei  red Queen



asher have 13 cards
zvei have 13 cards


new turn:
asher  black 7

zvei  red 7



asher  red 9

zvei  red 8



asher  black 4

zvei  black 2



asher  black Queen

zvei  red 3



asher have 17 cards
zvei have 9 cards


new turn:
asher  red 5

zvei  black 10



asher have 16 cards
zvei have 10 cards


new turn:
asher  black 5

zvei  red King

.......ext

new turn:
asher  black 9

zvei  black 8



asher have 26 cards
zvei have 0 cards


zvei is out of cards...
Congratulations!  asher is the winner
Do you want to play again?
if yes Enter 1.

*/
