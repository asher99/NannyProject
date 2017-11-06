using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    class CardStock
    {
        public List<Card> Cards;

        public CardStock()
        {
            this.Cards = new List<Card>();
            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.red });

            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.black });
        }
        public void addCard(Card a)
        {
            this.Cards.Add(a);
        }
        public void removeCard(Card a)
        {
            Card removedCard = a;
            Cards.Remove(a);

            return;
        }
        public void Shuffle()
        {
            Random r = new Random();

            Card temp = new Card();
            int j = r.Next(0, 26);
            for (int i = 0; i < 26; i++)
            {
                temp = Cards[i];
                Cards[i] = Cards[j];    //s w a p
                Cards[j] = temp;
                j = r.Next(0, 26);

            }


        }

        public override string ToString()
        {
            string temp = null;
            foreach (Card a in Cards)
            {
                temp += a.ToString();
            }
            return temp;
        }

        public Card this[string index]
        {
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

        public void distribute(params Player[] players)
        {
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

    }

}

