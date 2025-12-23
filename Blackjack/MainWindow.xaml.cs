using Blackjack.Models;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player _player;
        Player _bank;
        Random _random = new Random();
        List<Card> _cards;

        public MainWindow()
        {
            InitializeComponent();

            _player = new Player("Player", playerStack);
            _bank = new Player("Bank", bankStack);
        }

        private void StartNewGame()
        {
            RefreshUI();
            StartNextRound();
        }

        private void StartNextRound()
        {
            _cards = _deck.ToList<Card>();
            DealCardTo(_player, true);
            DealCardTo(_player, false);
            DealCardTo(_bank, true);
            DealCardTo(_bank, false);
        }

        private void RefreshUI()
        {
            playerStack.Children.Clear();
            bankStack.Children.Clear();
            creditsTextBlock.Text = _player.Credits.ToString();
        }

        private void DealCardTo(Player player, bool show)
        {
            int rand = _random.Next(0, _cards.Count);
            player.Cards.Add(_cards[rand]);
            AddImageToStackPanel(player.CardStack, _cards[rand], show);
            _cards.RemoveAt(rand);
            remainingCardsTextBlock.Text = _cards.Count.ToString();
        }

        private void CountValueFromStack(Player player)
        {
            int points = 0;
            foreach (Card card in player.Cards)
            {
                points += card.Value[0];
            }
            player.Points = points;
        }

        /// <summary>
        /// Adds an image control to a panel which displays the given card
        /// </summary>
        /// <param name="panel">The control to which the image must be added</param>
        /// <param name="card">The card that should be displayed in the image</param>
        /// <param name="isVisible">A boolean that indicates if the card should be open or not</param>
        private void AddImageToStackPanel(StackPanel panel, Card card, bool isVisible)
        {
            card.IsVisible = isVisible;

            //Maak een nieuwe Image control
            Image image = new Image();
            image.Width = 120;
            image.Height = 170;
            image.Stretch = Stretch.Uniform;
            image.Margin = new Thickness(5, 0, 5, 0);
            //Bewaar het volledige Card-object in de Tag-property van de Image control
            image.Tag = card;
            // Zou dit liever in Card doen maar dan overschrijf je de originele en je weet niet
            // welke je moet terugzetten
            if (isVisible)
            {
                image.Source = new BitmapImage(new Uri(card.ImageUrl, UriKind.Relative));
            }
            else
            {
                image.Source = new BitmapImage(new Uri("images/cards/back.png", UriKind.Relative));
            }

            //Voeg de Image control toe aan het StackPanel
            panel.Children.Add(image);
        }

        private Card[] _deck = new Card[]
        {
            // CLUBS
            new Card { ImageUrl="/images/cards/clubs_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="/images/cards/clubs_2.png", Value=new[] {2}},
            new Card { ImageUrl="/images/cards/clubs_3.png", Value=new[] {3}},
            new Card { ImageUrl="/images/cards/clubs_4.png", Value=new[] {4}},
            new Card { ImageUrl="/images/cards/clubs_5.png", Value=new[] {5}},
            new Card { ImageUrl="/images/cards/clubs_6.png", Value=new[] {6}},
            new Card { ImageUrl="/images/cards/clubs_7.png", Value=new[] {7}},
            new Card { ImageUrl="/images/cards/clubs_8.png", Value=new[] {8}},
            new Card { ImageUrl="/images/cards/clubs_9.png", Value=new[] {9}},
            new Card { ImageUrl="/images/cards/clubs_10.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/clubs_J.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/clubs_Q.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/clubs_K.png", Value=new[] {10}},

            // DIAMONDS
            new Card { ImageUrl="/images/cards/diamonds_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="/images/cards/diamonds_2.png", Value=new[] {2}},
            new Card { ImageUrl="/images/cards/diamonds_3.png", Value=new[] {3}},
            new Card { ImageUrl="/images/cards/diamonds_4.png", Value=new[] {4}},
            new Card { ImageUrl="/images/cards/diamonds_5.png", Value=new[] {5}},
            new Card { ImageUrl="/images/cards/diamonds_6.png", Value=new[] {6}},
            new Card { ImageUrl="/images/cards/diamonds_7.png", Value=new[] {7}},
            new Card { ImageUrl="/images/cards/diamonds_8.png", Value=new[] {8}},
            new Card { ImageUrl="/images/cards/diamonds_9.png", Value=new[] {9}},
            new Card { ImageUrl="/images/cards/diamonds_10.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/diamonds_J.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/diamonds_Q.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/diamonds_K.png", Value=new[] {10}},

            // HEARTS
            new Card { ImageUrl="/images/cards/hearts_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="/images/cards/hearts_2.png", Value=new[] {2}},
            new Card { ImageUrl="/images/cards/hearts_3.png", Value=new[] {3}},
            new Card { ImageUrl="/images/cards/hearts_4.png", Value=new[] {4}},
            new Card { ImageUrl="/images/cards/hearts_5.png", Value=new[] {5}},
            new Card { ImageUrl="/images/cards/hearts_6.png", Value=new[] {6}},
            new Card { ImageUrl="/images/cards/hearts_7.png", Value=new[] {7}},
            new Card { ImageUrl="/images/cards/hearts_8.png", Value=new[] {8}},
            new Card { ImageUrl="/images/cards/hearts_9.png", Value=new[] {9}},
            new Card { ImageUrl="/images/cards/hearts_10.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/hearts_J.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/hearts_Q.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/hearts_K.png", Value=new[] {10}},

            // SPADES
            new Card { ImageUrl="/images/cards/spades_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="/images/cards/spades_2.png", Value=new[] {2}},
            new Card { ImageUrl="/images/cards/spades_3.png", Value=new[] {3}},
            new Card { ImageUrl="/images/cards/spades_4.png", Value=new[] {4}},
            new Card { ImageUrl="/images/cards/spades_5.png", Value=new[] {5}},
            new Card { ImageUrl="/images/cards/spades_6.png", Value=new[] {6}},
            new Card { ImageUrl="/images/cards/spades_7.png", Value=new[] {7}},
            new Card { ImageUrl="/images/cards/spades_8.png", Value=new[] {8}},
            new Card { ImageUrl="/images/cards/spades_9.png", Value=new[] {9}},
            new Card { ImageUrl="/images/cards/spades_10.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/spades_J.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/spades_Q.png", Value=new[] {10}},
            new Card { ImageUrl="/images/cards/spades_K.png", Value=new[] {10}},
        };

        public static object Mainwindow { get; private set; }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void betPlacedButton_Click(object sender, RoutedEventArgs e)
        {
            // Number moet bijgehouden worden voor het einde van het spel
            if (int.TryParse(ceditsInputTextBox.Text, out int number) 
                && number < _player.Credits)
            {
                _player.Credits -= number;
                // Zorg dat de kaart getoont wordt
                _player.Cards[1].IsVisible = true;

                creditsTextBlock.Text = _player.Credits.ToString();
                playerBetPanel.Visibility = Visibility.Hidden;
                cardButton.Visibility = Visibility.Visible;
                stopButton.Visibility = Visibility.Visible;
            }
        }
    }
}