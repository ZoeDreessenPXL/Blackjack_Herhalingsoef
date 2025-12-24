using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Blackjack.Models
{
    internal class Card
    {
        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                IsVisibleChanged(value);
            }
        }

        public string ImageUrl { get; set; }
        public string BackIamgeUrl { get; set; } = "images/cards/back.png";
        public int[] Value { get; set; }
        public BitmapImage ImageSource { get; set; }

        private void IsVisibleChanged (bool value)
        {
            ImageSource = new BitmapImage(
                new Uri(value ? ImageUrl : BackIamgeUrl,
                UriKind.Relative));
        }
    }
}

