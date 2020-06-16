using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruityFramework.Core;

namespace FruityFramework.Reels
{
    public class Reel
    {
        private readonly IList<ReelSegment> _segments;
        public ReelSegment CurrentPosition { get; private set; }
        public ReelSegment StartPosition => _segments?[0];

        public event EventHandler<ReelPositionChangedEventArgs> PositionChanged;


        public Reel(IList<ReelSegment> reelSegments)
        {
            _segments = reelSegments ?? throw new ArgumentNullException(nameof(reelSegments));
            if (_segments.Any(r => r.Reel != null))
            {
                throw new InvalidOperationException("This reel set already belongs to another reel");
            }

            foreach (var rs in reelSegments)
            {
                rs.Reel = this;
            }
            CurrentPosition = StartPosition;
        }

        public ReelSegment this[int index] => _segments[index];

        public ReelSegment GetRandomSegment()
        {
            var r = new Random();
            return this[r.Next(0, _segments.Count - 1)];
        }
        public int IndexOf(ReelSegment reelSegment)
        {
            return _segments.IndexOf(reelSegment);
        }

        public ReelSegment GetSegmentFromOffset(int offset, ReelSegment fromReelPosition = null)
        {
            var currentIndex = IndexOf(fromReelPosition ?? CurrentPosition);
            var desiredIndex = MathHelper.CalculateOffsetPosition(currentIndex, offset, _segments.Count);
            return _segments[desiredIndex];
        }

        public async Task<ReelSpinResult> Spin(ReelSpinOptions options)
        {
            var direction = options.Direction.CheckForRandom();
            var forwardBackOffset = direction == ReelSpinDirection.Forward ? 1 : -1;
            var minPositions = options.MinRotations * _segments.Count;
            var currentIndex = IndexOf(CurrentPosition);
            var desiredIndex = IndexOf(options.Target);

            var postionsMoved = MathHelper.CalculatePositionsMoved(currentIndex, desiredIndex,
                _segments.Count, direction == ReelSpinDirection.Reverse, minPositions);

            var spinDelay = options.Speed.GetSpinSpeedSegmentDelay(postionsMoved, options.SpinDelay);

            for (var idx = 0; idx < postionsMoved; idx++)
            {
                var previous = CurrentPosition;
                CurrentPosition = GetSegmentFromOffset(forwardBackOffset, CurrentPosition);
                OnPositionChanged(previous, CurrentPosition);
                await Task.Delay(spinDelay);
            }

            return new ReelSpinResult
            {
                PositionsMoved = postionsMoved,
                FinalPosition = CurrentPosition,
                Options = options
            };
        }

        protected virtual void OnPositionChanged(ReelSegment previousPosition, ReelSegment currentPosition)
        {
            PositionChanged?.Invoke(this,new ReelPositionChangedEventArgs
            {
                Current = currentPosition,
                Previous = previousPosition
            });
        }

    }
}
