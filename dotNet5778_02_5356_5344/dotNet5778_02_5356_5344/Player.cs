using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    class Player
    {
        public string Name;

        public Queue<Card> pCards;

        public Player(string userName) // ctor
        {
            Name = userName;
            pCards = new Queue<Card>();
        }

        public void addCard(params Card[] cards) // adds card to stack
        {
            for (int i = 0; i < cards.Length; i++)
            {
                pCards.Enqueue(cards[i]);
            }
        }

        public override string ToString() // prints a player and his cards
        {
            string temp = Name + " have " + pCards.Count() + " cards.\nList of cards:\n";

            foreach (Card c in pCards)
            {
                temp += c.ToString();
            }
            return temp;
        }

        public bool lose() // check if the player run out of cards
        {
            return !pCards.Any();
        }

        public Card extractTop() // takes out the top card, print its value and returns it
        {
            Card removedCard = pCards.Dequeue();
            Console.WriteLine(Name + ' ' + removedCard.ToString());
            return removedCard;
        }

       
    }

}
