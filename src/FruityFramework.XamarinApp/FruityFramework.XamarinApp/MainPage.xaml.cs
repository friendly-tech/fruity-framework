using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruityFramework.ButtonInput;
using FruityFramework.GameEngine;
using FruityFramework.Reels;
using Xamarin.Forms;

namespace FruityFramework.XamarinApp
{
    public partial class MainPage : ContentPage
    {

        private readonly TestFruity Fruity = new TestFruity();
        public MainPage()
        {
            InitializeComponent();
            Fruity.Configure();
            Fruity.ReelSet.PositionChanged += ReelSetOnPositionChanged;
        }

        private void ReelSetOnPositionChanged(object sender, ReelPositionChangedEventArgs e)
        {
            if (e.Reel.ReelNumber ==1)
            {
                LabelMain1.Text = e.Current.Symbol.Key;
                LabelAbove1.Text = e.Current.Next.Symbol.Key;
                LabelBelow1.Text = e.Current.Previous.Symbol.Key;
            } else if (e.Reel.ReelNumber ==2)
            {
                LabelMain2.Text = e.Current.Symbol.Key;
                LabelAbove2.Text = e.Current.Next.Symbol.Key;
                LabelBelow2.Text = e.Current.Previous.Symbol.Key;
            } else if (e.Reel.ReelNumber ==3)
            {
                LabelMain3.Text = e.Current.Symbol.Key;
                LabelAbove3.Text = e.Current.Next.Symbol.Key;
                LabelBelow3.Text = e.Current.Previous.Symbol.Key;
            }
        }


        private void Spin_OnClicked(object sender, EventArgs e)
        {
            Fruity.ButtonSet.ClickButton(WellKnownCommandNames.Start);
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

        }
    }
}
