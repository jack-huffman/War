using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace War
{
    class Card
    {
        public BitmapImage cardBitmap;
        public int cardValue;
        public int cardWidth = 90;
        public string suit;
        public Boolean used = false;
        public Card(int cardValue, string suit)
        {
            this.cardValue = cardValue;
            this.suit = suit;

            cardBitmap = LoadBitmap(FindImage(), cardWidth);
        }

        public int CardValue //between 1 and 13
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public BitmapImage LoadBitmap(String assetsRelativePath, double decodeWidth)
        {
            BitmapImage theBitmap = new BitmapImage();
            theBitmap.BeginInit();
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"assets\cards");
            String path = System.IO.Path.Combine(basePath, assetsRelativePath);
            theBitmap.UriSource = new Uri(path, UriKind.Absolute);
            theBitmap.DecodePixelWidth = (int)decodeWidth;
            theBitmap.EndInit();

            return theBitmap;
        }

        private string FindImage()
        {
            if(cardValue < 1 || cardValue > 13)
            {
                return "back.png";
            }

            if(cardValue == 1)
            {
                if (suit == "Hearts")
                    return "2_of_hearts.png";
                if (suit == "Diamonds")
                    return "2_of_diamonds.png";
                if (suit == "Spades")
                    return "2_of_spades.png";
                if (suit == "Clubs")
                    return "2_of_clubs.png";
            }
            if (cardValue == 2)
            {
                if (suit == "Hearts")
                    return "3_of_hearts.png";
                if (suit == "Diamonds")
                    return "3_of_diamonds.png";
                if (suit == "Spades")
                    return "3_of_spades.png";
                if (suit == "Clubs")
                    return "3_of_clubs.png";
            }
            if (cardValue == 3)
            {
                if (suit == "Hearts")
                    return "4_of_hearts.png";
                if (suit == "Diamonds")
                    return "4_of_diamonds.png";
                if (suit == "Spades")
                    return "4_of_spades.png";
                if (suit == "Clubs")
                    return "4_of_clubs.png";
            }
            if (cardValue == 4)
            {
                if (suit == "Hearts")
                    return "5_of_hearts.png";
                if (suit == "Diamonds")
                    return "5_of_diamonds.png";
                if (suit == "Spades")
                    return "5_of_spades.png";
                if (suit == "Clubs")
                    return "5_of_clubs.png";
            }
            if (cardValue == 5)
            {
                if (suit == "Hearts")
                    return "6_of_hearts.png";
                if (suit == "Diamonds")
                    return "6_of_diamonds.png";
                if (suit == "Spades")
                    return "6_of_spades.png";
                if (suit == "Clubs")
                    return "6_of_clubs.png";
            }
            if (cardValue == 6)
            {
                if (suit == "Hearts")
                    return "7_of_hearts.png";
                if (suit == "Diamonds")
                    return "7_of_diamonds.png";
                if (suit == "Spades")
                    return "7_of_spades.png";
                if (suit == "Clubs")
                    return "7_of_clubs.png";
            }
            if (cardValue == 7)
            {
                if (suit == "Hearts")
                    return "8_of_hearts.png";
                if (suit == "Diamonds")
                    return "8_of_diamonds.png";
                if (suit == "Spades")
                    return "8_of_spades.png";
                if (suit == "Clubs")
                    return "8_of_clubs.png";
            }
            if (cardValue == 8)
            {
                if (suit == "Hearts")
                    return "9_of_hearts.png";
                if (suit == "Diamonds")
                    return "9_of_diamonds.png";
                if (suit == "Spades")
                    return "9_of_spades.png";
                if (suit == "Clubs")
                    return "9_of_clubs.png";
            }
            if (cardValue == 9)
            {
                if (suit == "Hearts")
                    return "10_of_hearts.png";
                if (suit == "Diamonds")
                    return "10_of_diamonds.png";
                if (suit == "Spades")
                    return "10_of_spades.png";
                if (suit == "Clubs")
                    return "10_of_clubs.png";
            }
            if (cardValue == 10)
            {
                if (suit == "Hearts")
                    return "jack_of_hearts.png";
                if (suit == "Diamonds")
                    return "jack_of_diamonds.png";
                if (suit == "Spades")
                    return "jack_of_spades.png";
                if (suit == "Clubs")
                    return "jack_of_clubs.png";
            }
            if (cardValue == 11)
            {
                if (suit == "Hearts")
                    return "queen_of_hearts.png";
                if (suit == "Diamonds")
                    return "queen_of_diamonds.png";
                if (suit == "Spades")
                    return "queen_of_spades.png";
                if (suit == "Clubs")
                    return "queen_of_clubs.png";
            }
            if (cardValue == 12)
            {
                if (suit == "Hearts")
                    return "king_of_hearts.png";
                if (suit == "Diamonds")
                    return "king_of_diamonds.png";
                if (suit == "Spades")
                    return "king_of_spades.png";
                if (suit == "Clubs")
                    return "king_of_clubs.png";
            }
            if (cardValue == 13)
            {
                if (suit == "Hearts")
                    return "ace_of_hearts.png";
                if (suit == "Diamonds")
                    return "ace_of_diamonds.png";
                if (suit == "Spades")
                    return "ace_of_spades.png";
                if (suit == "Clubs")
                    return "ace_of_clubs.png";
            }
            return null;
        }
    }
}
