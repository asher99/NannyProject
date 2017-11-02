using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    class CardStock
    {
        private List<Card> Cards;

        public CardStock()
        {
            this.Cards = new List<Card>();
            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.red });

            for (int i = 0; i < 13; i++)
                Cards.Add(new Card() { number = i + 2, color = E_color.black });
        }
        public void Shuffle()
        {
            Random r = new Random();

            Card iter = new Card();
            int j = r.Next(0, 26);
            for (int i = 0; i < 26 ; iter = Cards[i], i++ )
            {
                Cards[i] = Cards[j];    //s w a p
                Cards[j] = iter;
                j = r.Next(0, 26);
            }
        }

        public override string ToString()
        {
            string temp = null;
            foreach(Card a in Cards)
            {
                temp += a.ToString();
            }
            return temp;
        }
       


    }
    public void distribute(params Player[] players)
    {
        CardStock newDeck = new CardStock();
        foreach (Player p in players)
        {
            for (int i = 0; i < newDeck; i++)
            {
                ;
            }
        }
    }
}
