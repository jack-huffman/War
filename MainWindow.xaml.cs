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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        Player opponent;
        Deck pile = new Deck();
        public MainWindow()
        {
            InitializeComponent();
            
            Deck deck = new Deck();
            deck.NewDeck();
            //cardPile.Source = deck.flippedCard.cardBitmap;
            player = new Player("Jack");
            opponent = new Player("Opponent");
            deck.Shuffle();
            player.DealCards(player, opponent, deck);

            opponentImage.Source = opponent.flippedCard.cardBitmap;
            playerImage.Source = player.flippedCard.cardBitmap;
        }


        private void Flip_Btn(object sender, RoutedEventArgs e)
        {
            playerFlipped.Source = player.cards[0].cardBitmap;
            opponentFlipped.Source = opponent.cards[0].cardBitmap;
            CalculateScores(player, opponent);
        }

        private void CalculateScores(Player p1, Player p2)
        {
            if(p1.cards[0].cardValue > p2.cards[0].cardValue) // p1 wins
            {

                string message = "Player wins the hand!";
                string caption = "Outcome";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(message, caption, button);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        PlayerCardHigher();
                        break;
                    default:
                        break;
                }
            }
            
            else if(p1.cards[0].cardValue < p2.cards[0].cardValue) // p2 wins
            {

                string message = "Opponent wins the hand!";
                string caption = "Outcome";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(message, caption, button);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        PlayerCardLower();
                        break;
                    default:
                        break;
                }
            }

            else if(p1.cards[0].cardValue == p2.cards[0].cardValue) // players tie
            {
                string message = "Cards are the same value! Flipping five more cards upside down...";
                string caption = "Cards Tied";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(message, caption, button);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        CardsTie();
                        break;
                    default:
                        break;
                }
            }

            UpdateScores();
        }

        public void PlayerCardHigher()
        {
            //Put both player's cards in the pile
            pile.cards.Add(opponent.cards[0]);
            pile.cards.Add(player.cards[0]);
            opponent.cards.RemoveAt(0);
            player.cards.RemoveAt(0);

            //Give pile to player
            for (int i=0; i < pile.cards.Count; i++)
            {
                player.cards.Add(pile.cards[i]);
            }

            //Update pileSize textbox
            pileSize.Text = Convert.ToString((Convert.ToInt32(pileSize.Text) + pile.cards.Count));

            pile.cards.Clear();
        }

        public void PlayerCardLower()
        {
            //Put both player's cards in the pile
            pile.cards.Add(opponent.cards[0]);
            pile.cards.Add(player.cards[0]);
            opponent.cards.RemoveAt(0);
            player.cards.RemoveAt(0);

            //Give cards to opponent
            for (int i = 0; i < pile.cards.Count; i++)
            {
                opponent.cards.Add(pile.cards[i]);
            }

            //Update pileSize textbox
            pileSize.Text = Convert.ToString((Convert.ToInt32(pileSize.Text) + pile.cards.Count));

            pile.cards.Clear();
        }

        public void CardsTie()
        {

            //Move 6 cards from player to pile (Normally 3, used 6 to make game easier to win)
            for(int i=0; i<6; i++)
            {
                if (player.cards.Count != 1) // Leave max one card available
                {
                    pile.cards.Add(player.cards[0]);
                    player.cards.RemoveAt(0);
                }
            }

            //Move 6 cards from opponent to pile (Normally 3, used 6 to make game easier to win)
            for(int i=0; i<6; i++)
            {
                if (opponent.cards.Count != 1) // Leave max one card available
                {
                    pile.cards.Add(opponent.cards[0]);
                    opponent.cards.RemoveAt(0);
                }
            }

            //Update pileSize textbox
            pileSize.Text = Convert.ToString((Convert.ToInt32(pileSize.Text) + pile.cards.Count));

            //Display third cards for comparison
            playerFlipped.Source = player.cards[0].cardBitmap;
            opponentFlipped.Source = opponent.cards[0].cardBitmap;

            //Update Scores
            UpdateScores();

            //Compare cards
            CalculateScores(player, opponent);



        }

        private void UpdateScores()
        {
            string message;
            string caption;
            MessageBoxButton button;
            playerScore.Text = Convert.ToString(player.cards.Count);
            opponentScore.Text = Convert.ToString(opponent.cards.Count);
            pileSize.Text = Convert.ToString(pile.cards.Count);

            if (player.cards.Count == 0)
            {
                playerImage.Source = null;
                message = "You lose! Maybe next time...";
                caption = "Game Over";
                button = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(message, caption, button);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        Close();
                        break;
                    default:
                        break;
                }
            }

            if (opponent.cards.Count == 0)
            {
                opponentImage.Source = null;
                message = "You win!";
                caption = "Congratulations!";
                button = MessageBoxButton.OK;
                MessageBoxResult result = MessageBox.Show(message, caption, button);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        Close();
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
