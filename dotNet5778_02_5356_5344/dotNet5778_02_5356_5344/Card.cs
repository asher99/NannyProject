using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    enum E_color { red, black }

    class Card
    {
        private E_color m_color;
        public E_color color
        {
            set
            {
                m_color = value;
            }
        }

        private int m_number;
        public int number
        {
            get
            {
                return m_number;
            }
            set
            {
                if (value > 1 && value < 15)
                    m_number = value;
            }
        }

        public string CardName
        {
            get
            {
                if (m_number < 11)
                {
                    return Convert.ToString(m_number);
                }
                else
                {
                    switch (m_number)
                    {

                        case 11:
                            return "Jack";
                            break;
                        case 12:
                            return "Queen";
                            break;
                        case 13:
                            return "King";
                            break;
                        case 14:
                            return "Ace";
                            break;
                    }
                }

                // To make sure all code path return value
                return "\0";

            }

        }

        // constructor
        public Card()
        {
            number = 2;
            color = E_color.red;
        }
        public Card(int myNum,E_color myColor)
        {
            number = myNum;
            color = myColor;
        }

        public override string ToString()
        {
            return "card: " + m_number + m_color + '\n';
        }

        public int CompareTo(Card card)
        {
            if(this.m_number == card.m_number)
            {
                return 0;
            }
            if (this.m_number > card.m_number)
            {
                return 1;
            }
            return -1;
        }
    }
}
