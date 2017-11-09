using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    class CardStock
    {
        private List<Card> Cards; 

        public CardStock() // ctor
        {
            this.Cards = new List<Card>();
            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.red });

            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.black });
        }

        public void addCard(Card a) // adds a card to stack
        {
            this.Cards.Add(a);
        }

        public void removeCard(Card a) // removes card from stack
        {
            Cards.Remove(a);
            return;
        }

        public void sort() // sorts the deck
        {
            this.Cards.Sort();
        }

        public void Shuffle()  // mixes a deck of cards 
        {
            Random r = new Random();

            Card temp = new Card();
            int j = r.Next(0, 26);
            for (int i = 0; i < 26; i++)
            {
                temp = Cards[i];
                Cards[i] = Cards[j];    //s w a p
                Cards[j] = temp;
                j = r.Next(0, 26); // gets a new random index to swap

            }
        }

        public override string ToString() // prints the deck
        {
            string temp = null;
            foreach (Card a in Cards)
            {
                temp += a.ToString();
            }
            return temp;
        }

        public Card this[string index] // indexer: searches for a card in a stack
        {                              // by its name. exm: card2= deck["Jack"];
            get
            {
                foreach (Card a in Cards)
                {
                    if (a.CardName == index)
                        return a;
                }
                return null;
            }
        }

        public void distribute(params Player[] players) // gives each player a card from the deck
        {                                               // until the deck is empty
            int stockIndex = 0;
            while (stockIndex < 26)
            {
                foreach (Player p in players)
                {
                    if (stockIndex < 26)
                    {
                        p.addCard(Cards[stockIndex]);
                    }
                    stockIndex++;
                }
            }
        }

        public IEnumerator GetEnumerator() // IEnumerator
        {
            return Cards.GetEnumerator();
        }

    }

}

