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
            Player[] players = new Player[5];
            players[0] = new Player("David");
            players[1] = new Player("Golieth");
            players[2] = new Player("Devil");
            players[3] = new Player("Jonathan");
            players[4] = new Player("Joe");

            CardStock deck = new CardStock();
            deck.Shuffle();
            deck.distribute(players);
 
            foreach (Player p in players)
            {
                Console.WriteLine(p.ToString());
            }



            Console.ReadKey();
        }
    }
}
