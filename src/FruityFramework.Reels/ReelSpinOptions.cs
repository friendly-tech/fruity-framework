namespace FruityFramework.Reels
{
    public class ReelSpinOptions
    {
        public ReelSegment Target { get; set; }
        public ReelSpinDirection Direction { get; set; }
        public ReelSpinSpeed Speed { get; set; }
        public double MinRotations { get; set; }
        public int SpinDelay { get; set; }
    }
}
