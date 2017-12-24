using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5778_02_5344_5356
{
    class Game
    {
        private CardStock deck;

        private Player p1, p2;

        public Game()    // ctor
        {             //builds a game by getting players and distributing them cards

            deck = new CardStock();
            string temp;
            Console.WriteLine("enter first player name: ");
            temp = Console.ReadLine();
            p1 = new Player(temp);
            Console.WriteLine("enter second player name: ");
            temp = Console.ReadLine();
            p2 = new Player(temp);


            deck.Shuffle();
            deck.distribute(p1, p2);            
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
        }

        public string whoWin() // check witch player won and returns his name
        {
            if (p1.lose() && p2.lose()) // in case the two players finished their cards during a "war". (probabilty of 1 / 13!)
                return "draw. you both finished your cards\nplay again?";
            if (p1.lose())
                return p1.Name + " is out of cards...\nCongratulations!  " + p2.Name + " is the winner";
            if (p2.lose())
                return p2.Name + " is out of cards...\nCongratulations!  " + p1.Name + " is the winner";
            return null;
        }

        public bool isFinished() // checks if the game is over
        {
            return (whoWin() != null);
        }

        public void turn() // takes a card from each player and checks who takes
        {
            Console.WriteLine("new turn:");

            List<Card> playersCards = new List<Card>();

            playersCards.Add(p1.extractTop());
            playersCards.Add(p2.extractTop());
            //Console.WriteLine('\n');                    // the "extract-top" print the cards. a new line between each pair of cards.

            int beq = playersCards[0].CompareTo(playersCards[1]);
            for (int i = 1; beq == 0; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (p1.lose() || p2.lose())
                        return;

                    playersCards.Add(p1.extractTop());
                    playersCards.Add(p2.extractTop());
                   // Console.WriteLine('\n');            // the "extract-top" print the cards. a new line between each pair of cards.

                }

                beq = playersCards[6 * i].CompareTo(playersCards[6 * i + 1]);
            }
            if (beq > 0)
            {
                Console.WriteLine("{0} takes!",p1.Name );
                p1.addCard(playersCards.ToArray());
            }
            else
            {
                Console.WriteLine("{0} takes!", p2.Name);
                p2.addCard(playersCards.ToArray());
            }

            Console.WriteLine(p1.Name + " have " + p1.pCards.Count + " cards");
            Console.WriteLine(p2.Name + " have " + p2.pCards.Count + " cards");
            Console.WriteLine('\n'); 

        }

        public override string ToString() // prints each player and the amount of is cards
        {
            string temp;
            temp = p1.Name + " has " + p1.pCards.Count + " cards.\t "
                + p2.Name + " has " + p2.pCards.Count + " cards.\t ";
            return temp;
        }

        public void restart() // to restart the game.
        {
            p1.pCards.Clear();
            p2.pCards.Clear();
            deck.sort();
            deck.Shuffle();
            deck.distribute(p1, p2);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

        }

    }
}
