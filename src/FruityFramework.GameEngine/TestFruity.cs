using System;
using System.Collections.Generic;
using System.Linq;
using FruityFramework.ButtonInput;
using FruityFramework.Reels;

namespace FruityFramework.GameEngine
{
    public class TestFruity: FruitMachineBase
    {
        public override void Configure()
        {
            base.Configure();
            ButtonSet.ButtonClicked+= ButtonSetOnButtonClicked;
        }

        private async void ButtonSetOnButtonClicked(object sender, ButtonClickedEventArgs e)
        {
            if (e.Button.CommandName == WellKnownCommandNames.Start)
            {
                var rand = new Random();
                await ReelSet.SpinAll(new []{rand.Next(0, 20), rand.Next(0, 20), rand.Next(0, 20)});
            }
        }

        protected override IEnumerable<Button> CreateButtons()
        {
            return new List<Button>
            {
                Button.Cancel(),
                Button.Start()
            };
        }

        protected override IEnumerable<ReelSegment> CreateReelSegments(int reelNum)
        {
            return Enumerable.Range(0, 20)
                .Select(r => new ReelSegment()
                {
                    Symbol = new ReelSymbol
                    {
                        Key = r.ToString()
                    }
                });
        }
    }


}


