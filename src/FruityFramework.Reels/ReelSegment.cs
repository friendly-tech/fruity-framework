namespace FruityFramework.Reels
{
    /// <summary>
    /// A segment on a reel, can contain both a main symbol and an overlay
    /// </summary>
    public class ReelSegment
    {
        internal Reel Reel { get; set; }
        public ReelSymbol Symbol { get; set; }
        public ReelSymbol Overlay { get; set; }

        public ReelSegment Previous => Reel.GetSegmentFromOffset(-1, this);
        public ReelSegment Next => Reel.GetSegmentFromOffset(1, this);

    }
}
