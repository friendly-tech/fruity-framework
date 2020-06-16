using FruityFramework.Core;

namespace FruityFramework.Reels
{
    public static class Extensions
    {
        public static int GetSpinSpeedSegmentDelay(this ReelSpinSpeed speed, int numSegments)
        {
            if (numSegments == 0)
            {
                // Cannot have divide by zero
                numSegments = 20;
            }
            var useSpeed = speed.CheckForRandom();
            switch (useSpeed)
            {
                case ReelSpinSpeed.Fast: return 600 / numSegments;
                case ReelSpinSpeed.Normal: return 900 / numSegments;
                case ReelSpinSpeed.Slow: return 1400 / numSegments;
            }

            return 900 / numSegments;
        }
    }
}
