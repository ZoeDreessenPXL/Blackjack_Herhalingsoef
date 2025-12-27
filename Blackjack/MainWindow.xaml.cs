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
        int _stake;

        public MainWindow()
        {
            InitializeComponent();
        }

        // TODO
        // Stop button van results paneel wat moet die doen?
        // Kan mijn code schoner?
        private void StartNewGame()
        {
            _player = new Player("Player", playerStack, playerPointsTextBlock);
            _bank = new Player("Bank", bankStack, bankPointsTextBlock);
            StartNextRound();
        }

        /// <summary>
        /// Set up a new round
        /// </summary>
        private void StartNextRound()
        {
            RefreshUI();
            _cards = _deck.ToList<Card>();
            DealCardTo(_player, true);
            DealCardTo(_player, false);
            DealCardTo(_bank, true);
            DealCardTo(_bank, false);
            playerBetPanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Resets the UI of the game
        /// </summary>
        private void RefreshUI()
        {
            playerStack.Children.Clear();
            bankStack.Children.Clear();
            creditsTextBlock.Text = _player.Credits.ToString();
        }

        /// <summary>
        /// Deals a card to a player
        /// </summary>
        /// <param name="player">The player to which the card should be dealt</param>
        /// <param name="show">A boolean that's passed through</param>
        private void DealCardTo(Player player, bool show)
        {
            int rand = _random.Next(0, _cards.Count);
            AddImageToStackPanel(player.CardStack, _cards[rand], show);
            _cards.RemoveAt(rand);
            remainingCardsTextBlock.Text = _cards.Count.ToString();
            CountValueFromStack(player);
            CountVisiblePoints(player);
        }

        /// <summary>
        /// Counts the amount of points a player has
        /// </summary>
        /// <param name="player">The player for which the points need to be counted</param>
        private void CountValueFromStack(Player player)
        {
            int points = 0;
            int aceAmount = 0;
            foreach (Image image in player.CardStack.Children)
            {
                Card card = (Card)image.Tag;
                points += card.Value[0];
                if (card.Value.Length == 2)
                {
                    aceAmount++;
                }
            }
            player.Points = CountAce(points, aceAmount);
        }

        private int CountAce (int points, int aceAmount)
        {
            for (int i = 0; i < aceAmount; i++)
            {
                if (points + 10 <= 21)
                {
                    points += 10;
                }
            }
            return points;
        }

        /// <summary>
        /// Count the value of the open cards
        /// </summary>
        /// <param name="player">The player you need to count it for</param>
        private void CountVisiblePoints(Player player)
        {
            int points = 0;
            int aceAmount = 0;
            foreach (Image image in  player.CardStack.Children)
            {
                Card card = (Card)image.Tag;
                if (card.IsVisible)
                {
                    points += card.Value[0];
                    if (card.Value.Length == 2)
                    {
                        aceAmount++;
                    }
                }
            }
            player.PointTextBlock.Text = CountAce(points, aceAmount).ToString();
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
            image.Source = card.ImageSource;

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

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        /// <summary>
        /// Starts the play when the bet is placed correctly
        /// </summary>
        private void betPlacedButton_Click(object sender, RoutedEventArgs e)
        {
            // Number moet bijgehouden worden voor het einde van het spel
            if (int.TryParse(ceditsInputTextBox.Text, out _stake) 
                && _stake < _player.Credits)
            {
                _player.Credits = _player.Credits - _stake;

                TurnCardOver(_player);

                creditsTextBlock.Text = _player.Credits.ToString();
                playerBetPanel.Visibility = Visibility.Hidden;
                cardButton.Visibility = Visibility.Visible;
                stopButton.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Show the card initianally turned over for the player
        /// </summary>
        /// <param name="player">The player it that it needs to be turned over for</param>
        private void TurnCardOver (Player player)
        {
            Image image = (Image)player.CardStack.Children[1];
            Card card = (Card)image.Tag;
            card.IsVisible = true;
            image.Source = card.ImageSource;
            CountVisiblePoints(player);
        }

        /// <summary>
        /// Deals new card to the player if total is less than 21 points
        /// </summary>
        private void cardButton_Click(object sender, RoutedEventArgs e)
        {
            int cardAmount = _player.CardStack.Children.Count;
            if (_player.Points < 21 && cardAmount < 7)
            {
                DealCardTo(_player, true);
            }
        }

        /// <summary>
        /// Gives turn to the bank, then shows the results
        /// </summary>
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            BankPlay();
            cardButton.Visibility = Visibility.Hidden;
            stopButton.Visibility = Visibility.Hidden;
            ShowResult();
        }

        /// <summary>
        /// Executes the bank's play
        /// </summary>
        private void BankPlay()
        {
            TurnCardOver(_bank);
            while (_bank.Points <= 16)
            {
                DealCardTo(_bank, true);
            }
        }

        /// <summary>
        /// Determines the result
        /// </summary>
        private void ShowResult()
        {
            int cardAmount = _player.CardStack.Children.Count;
            resultGrid.Visibility = Visibility.Visible;

            if ((_bank.Points > 21 && _player.Points > 21) || _bank.Points == _player.Points)
            {
                resultGrid.Background = new SolidColorBrush(Colors.Gray) { Opacity = 0.5 };
                resultTextBlock.Text = "It's a draw...";
                _player.Credits += _stake;
            }
            else if ((cardAmount == 7 && _player.Points <= 21) || _bank.Points > 21 
                || (_bank.Points < _player.Points && _player.Points <= 21))
            {
                resultGrid.Background = new SolidColorBrush(Colors.Green) { Opacity = 0.5 };
                resultTextBlock.Text = "You won!";
                _player.Credits += (_stake * 2);
            }
            else
            {
                resultGrid.Background = new SolidColorBrush(Colors.Red) { Opacity = 0.5 };
                resultTextBlock.Text = "You lost!";
            }
        }

        private void stopGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newRoundButton_Click(object sender, RoutedEventArgs e)
        {
            StartNextRound();
            resultGrid.Visibility = Visibility.Hidden;
        }
    }
}