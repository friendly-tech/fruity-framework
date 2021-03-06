using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruityFramework.Reels
{
    public class ReelSet
    {
        public IReadOnlyList<Reel> Reels { get; }

        public string Name { get; set; } = WellKnownReelSetNames.MainReelSet;
        public event EventHandler<ReelPositionChangedEventArgs> PositionChanged;

        public ReelSet(IReadOnlyList<Reel> reels)
        {
            Reels = reels;
            var num = 1;
            foreach (var reel in reels)
            {
                reel.ReelNumber = num;
                num++;
                reel.PositionChanged += (sender, args) =>
                {
                    PositionChanged?.Invoke(this, args);
                };

            }
        }

        public async Task SpinAll(IReadOnlyList<ReelSpinOptions> reelSpinOptions)
        {
            if (reelSpinOptions.Count != Reels.Count)
            {
                throw new ArgumentException("reelSpinOptions length must be same as reels length");
            }
            var tasks = reelSpinOptions.Select((r, i) => Reels[i].Spin(r));
            await Task.WhenAll(tasks);
        }

        public async Task SpinAll(IEnumerable<ReelSegment> reelSegments)
        {
            var optionsList = reelSegments.Select((r, i) => new ReelSpinOptions
            {
                Direction = ReelSpinDirection.Forward,
                Speed = ReelSpinSpeed.Normal,
                Target = r,
                MinRotations = 0.5, // At least half a reel to spin
                SpinDelay = i * 400
            });
            await SpinAll(optionsList.ToList().AsReadOnly());
        }

        public async Task SpinAll(IEnumerable<int> reelSegments)
        {
            var segments =
                reelSegments.Select((r, i) => Reels[i].GetSegmentFromOffset(r, this.Reels[i].StartPosition));
            await SpinAll(segments.ToList().AsReadOnly());
        }



    }
}
