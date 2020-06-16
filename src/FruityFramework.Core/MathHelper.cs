namespace FruityFramework.Core
{
    public class MathHelper
    {
        /// <summary>
        /// Calculates the current position when offset is applied
        /// </summary>
        /// <param name="startPosition">current position</param>
        /// <param name="offset">offset</param>
        /// <param name="elementCount">element count in array</param>
        /// <returns></returns>
        public static int CalculateOffsetPosition(int startPosition, int offset, int elementCount)
        {
            if (offset == 0) return startPosition;
            startPosition %= elementCount;
            startPosition += offset;
            if (startPosition < 0) startPosition += elementCount;
            if (startPosition > elementCount - 1) startPosition -= elementCount;
            return startPosition;

        }

        /// <summary>
        /// Calculates the positions moved to get from one position to another
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="desiredPosition"></param>
        /// <param name="elementCount"></param>
        /// <param name="reverse"></param>
        /// <param name="minPositionsToMove"></param>
        /// <returns></returns>
        public static int CalculatePositionsMoved(int startPosition, int desiredPosition, int elementCount,
            bool reverse = false, int minPositionsToMove = 0)
        {
            if (startPosition == desiredPosition && minPositionsToMove <= elementCount) return elementCount;
            var positionsMoved = 0;
            var currentPosition = startPosition;
            var offset = reverse ? -1 : 1;
            while (currentPosition != desiredPosition || positionsMoved < minPositionsToMove)
            {
                positionsMoved++;
                currentPosition = CalculateOffsetPosition(currentPosition, offset, elementCount);
            }

            return positionsMoved;
        }
    }
}
