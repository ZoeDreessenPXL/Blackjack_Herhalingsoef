using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Blackjack.Models
{
    internal class Player
    {
        public string Name { get; }
        public int Credits { get; set; }
        public StackPanel CardStack { get; }
        public TextBlock PointTextBlock { get; set; }
        public int Points { get; set; }

        public Player(string name, StackPanel cardStack, TextBlock pointTextBlock)
        {
            Name = name;
            Credits = 500;
            Points = 0;
            CardStack = cardStack;
            PointTextBlock = pointTextBlock;
        }
    }
}