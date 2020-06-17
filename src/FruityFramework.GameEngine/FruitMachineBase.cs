using System.Collections.Generic;
using System.Linq;
using FruityFramework.ButtonInput;
using FruityFramework.Reels;

namespace FruityFramework.GameEngine
{
    public abstract class FruitMachineBase
    {

        public int NumberOfReels { get; set; } = 3;
        public ReelSet ReelSet { get; private set; }
        public ButtonSet ButtonSet { get; private set; }
        public virtual void Configure()
        {
            ConfigureReels();
            ConfigureButtons();
        }


        protected void ConfigureButtons()
        {
            var buttons = CreateButtons();
            ButtonSet = new ButtonSet(buttons);
        }

        protected abstract IEnumerable<Button> CreateButtons();

        protected void ConfigureReels()
        {

            var reels = Enumerable.Range(1, NumberOfReels)
                .Select(i => new Reel(CreateReelSegments(i).ToList())).ToList();
            ReelSet = new ReelSet(reels.AsReadOnly());
        }
        protected abstract IEnumerable<ReelSegment> CreateReelSegments(int reelNum);
    }
}
