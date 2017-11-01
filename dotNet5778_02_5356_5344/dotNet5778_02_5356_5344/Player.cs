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
        Queue<Card> pCards = new Queue<Card>();
         public void addCard(params string [] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                pCards.Enqueue(cards[i]);
            }
        }
        public override string ToString() { }
        public bool lose()
        {
            return pCards.Any();
        }
    }
}
