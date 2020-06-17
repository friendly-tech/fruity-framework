using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruityFramework.ButtonInput;
using FruityFramework.Reels;

namespace FruityFramework.GameEngine
{
    public class TestFruity: FruitMachineBase
    {
        public override void Configure()
        {
            base.Configure();
            ButtonSet.InputReceiver = new TestButtonInput(ReelSet);
        }

        protected override IEnumerable<Button> CreateButtons()
        {
            return new List<Button>
            {
                new Button
                {
                    CommandName = WellKnownCommandNames.Cancel
                },
                new Button
                {
                    CommandName = WellKnownCommandNames.Start
                }
            };
        }

        protected override IEnumerable<ReelSegment> CreateReelSegments(int reelNum)
        {
            return Enumerable.Range(0, 20)
                .Select(r => new ReelSegment()
                {
                    Symbol = new ReelSymbol()
                    {
                        Key = r.ToString()
                    }
                });
        }
    }

    public class TestButtonInput : IButtonInputReceiver
    {
        private readonly ReelSet _reelSet;

        public TestButtonInput(ReelSet reelSet)
        {
            _reelSet = reelSet;
        }
        public async Task OnButtonClicked(Button button)
        {
            if (button.CommandName == WellKnownCommandNames.Start)
            {
                var rand = new Random();
                await _reelSet.SpinAll(new []{rand.Next(0, 20), rand.Next(0, 20), rand.Next(0, 20)});
            }
        }
    }
}


