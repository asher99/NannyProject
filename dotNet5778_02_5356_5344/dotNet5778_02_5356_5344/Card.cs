using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_5344_5356
{
    enum E_color { red, black }

    class Card : IComparable 
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
        public int number // private
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
                string temp;               
                switch (m_number)
                    {
                        case 11:
                           temp= "Jack";
                           break;
                        case 12:
                        temp = "Queen";
                            break;
                        case 13:
                        temp = "King";
                            break;
                        case 14:
                        temp = "Ace";
                            break;
                        default:
                        temp = "\0";
                            break;
                    }
                return temp;
            }

        }

        // constructors
        public Card()
        {
            number = 2;
            color = E_color.red;
        }
        public Card(int myNum, E_color myColor)
        {
            number = myNum;
            color = myColor;
        }

        public override string ToString() // to string
        {
            return "card: " + m_color +" "+ CardName + '\n';
           /* return ("************" + '\n' + "|" +
         " " + CardName + "        |" + '\n'
            + "|          |" + '\n'
             + "|  " + m_color + "  |" + '\n' +
              "|          |" + '\n'
                + "|        " + CardName + " " +
           "|" + '\n' + "************" + '\n');*/
        }

        public int CompareTo(object obj)
        {
            return number.CompareTo(((Card) obj).number);
        }



    }
}
