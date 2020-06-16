using System;

namespace FruityFramework.Reels
{
    public class ReelPositionChangedEventArgs: EventArgs
    {
        public ReelSegment Previous { get; set; }
        public ReelSegment Current { get; set; }


    }
}
