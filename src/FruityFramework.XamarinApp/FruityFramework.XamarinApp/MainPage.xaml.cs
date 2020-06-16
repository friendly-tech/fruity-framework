using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruityFramework.Reels;
using Xamarin.Forms;

namespace FruityFramework.XamarinApp
{
    public partial class MainPage : ContentPage
    {
        private Reel _reel1;
        private Reel _reel2;
        private Reel _reel3;
        private ReelSet _reels;

        public MainPage()
        {
            InitializeComponent();


        }

        private void ReelOnPositionChanged(object sender, ReelPositionChangedEventArgs e)
        {
            if (sender == _reel1)
            {
                LabelMain1.Text = e.Current.Symbol.Key;
                LabelAbove1.Text = e.Current.Next.Symbol.Key;
                LabelBelow1.Text = e.Current.Previous.Symbol.Key;
            } else if (sender == _reel2)
            {
                LabelMain2.Text = e.Current.Symbol.Key;
                LabelAbove2.Text = e.Current.Next.Symbol.Key;
                LabelBelow2.Text = e.Current.Previous.Symbol.Key;
            } else if (sender == _reel3)
            {
                LabelMain3.Text = e.Current.Symbol.Key;
                LabelAbove3.Text = e.Current.Next.Symbol.Key;
                LabelBelow3.Text = e.Current.Previous.Symbol.Key;
            }
        }

        private async void Spin_OnClicked(object sender, EventArgs e)
        {
            var rand = new Random();

            await _reels.SpinAll(new []{rand.Next(0, 20), rand.Next(0, 20), rand.Next(0, 20)});
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var positions1 = Enumerable.Range(0, 20)
                .Select(i => new ReelSegment()
                {
                    Symbol = new ReelSymbol
                    {
                        Key = i.ToString()
                    }
                }).ToList();
            var positions2 = Enumerable.Range(0, 20)
                .Select(i => new ReelSegment()
                {
                    Symbol = new ReelSymbol
                    {
                        Key = i.ToString()
                    }
                }).ToList();
            var positions3 = Enumerable.Range(0, 20)
                .Select(i => new ReelSegment()
                {
                    Symbol = new ReelSymbol
                    {
                        Key = i.ToString()
                    }
                }).ToList();

            _reel1 = new Reel(positions1);
            _reel2 = new Reel(positions2);
            _reel3 = new Reel(positions3);
            _reels = new ReelSet(new List<Reel>
            {
                _reel1,
                _reel2,
                _reel3
            });
            _reel1.PositionChanged+= ReelOnPositionChanged;
            _reel2.PositionChanged+= ReelOnPositionChanged;
            _reel3.PositionChanged+= ReelOnPositionChanged;

            ReelOnPositionChanged(_reel1, new ReelPositionChangedEventArgs()
            {
                Current = _reel1.StartPosition
            });
            ReelOnPositionChanged(_reel2, new ReelPositionChangedEventArgs()
            {
                Current = _reel2.StartPosition
            });
            ReelOnPositionChanged(_reel3, new ReelPositionChangedEventArgs()
            {
                Current = _reel3.StartPosition
            });
        }
    }
}
