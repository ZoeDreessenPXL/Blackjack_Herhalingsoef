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
        public List<Card> Cards { get; set; }
        public int Credits { get; set; }
        public StackPanel CardStack { get; }

        public Player(string name, StackPanel cardStack)
        {
            Name = name;
            Credits = 500;
            CardStack = cardStack;
        }
    }
}