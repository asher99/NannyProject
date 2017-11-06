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
        Queue<Card> pCards;
        public void addCard(params Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                pCards.Enqueue(cards[i]);
            }
        }
        public override string ToString()
        {
            string temp = Name + " have " + pCards.Count() + " cards.\nList of cards:\n";

            foreach (Card c in pCards)
            {
                temp += c.ToString();
            }
            return temp;
        }


        public bool lose()
        {
            return pCards.Any();
        }

        public Card extractTop()
        { 
            return pCards.Dequeue();
        }

        public Player(string userName)
        {
            Name = userName;
            pCards = new Queue<Card>();
        }
    }

}
