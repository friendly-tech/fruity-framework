using FruityFramework.Core;

namespace FruityFramework.Reels
{
    public static class Extensions
    {
        public static int GetSpinSpeedSegmentDelay(this ReelSpinSpeed speed, int numSegments, int additionalDelay = 0)
        {
            if (numSegments == 0)
            {
                // Cannot have divide by zero
                numSegments = 20;
            }
            var useSpeed = speed.CheckForRandom();
            switch (useSpeed)
            {
                case ReelSpinSpeed.Fast: return (600 + additionalDelay) / numSegments;
                case ReelSpinSpeed.Normal: return (900 + additionalDelay) / numSegments;
                case ReelSpinSpeed.Slow: return (1400 + additionalDelay) / numSegments;
            }

            return 900 / numSegments;
        }
    }
}
