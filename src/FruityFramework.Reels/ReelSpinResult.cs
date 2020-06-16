namespace FruityFramework.Reels
{
    public class ReelSpinResult
    {
        public ReelSegment FinalPosition { get; set; }
        public int PositionsMoved { get; set; }
        public ReelSpinOptions Options { get; set; }
    }
}
