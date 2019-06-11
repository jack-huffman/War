using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Player
    {
        public List<Card> cards = new List<Card>();
        public Card flippedCard = new Card(0, "None");
        string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void DealCards(Player p1, Player p2, Deck deck)
        {
            for(int i = 0; i<deck.cards.Count; i+=2)
            {
                p1.cards.Add(deck.cards[i]);
                deck.cards[i].used = true;
                p2.cards.Add(deck.cards[i + 1]);
                deck.cards[i].used = true;
            }

        }
    }
}
