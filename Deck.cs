using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace War
{
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public Card flippedCard = new Card(0, "None");
        public Deck()
        {
            

        }

        public void NewDeck()
        {
            if(cards.Count != 0)
            {
                cards.Clear();
            }

            for (int suitVal = 1; suitVal < 5; suitVal++)
            {
                for (int cardVal = 1; cardVal < 14; cardVal++)
                {
                    if (suitVal == 1)
                    {
                        cards.Add(new Card(cardVal, "Spades"));
                    }
                    else if (suitVal == 2)
                    {
                        cards.Add(new Card(cardVal, "Hearts"));
                    }
                    else if (suitVal == 3)
                    {
                        cards.Add(new Card(cardVal, "Clubs"));
                    }
                    else if (suitVal == 4)
                    {
                        cards.Add(new Card(cardVal, "Diamonds"));
                    }
                }
            }
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = cards.Count; i > 1; i--)
            {
                int pos = rnd.Next(i);
                var x = cards[i - 1];
                cards[i - 1] = cards[pos];
                cards[pos] = x;
            }
        }
    }
}
