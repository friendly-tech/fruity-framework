using FruityFramework.Core;
using NUnit.Framework;

namespace FruityFramework.Core.Tests
{
    public class MathHelperTests
    {
        [Test]
        [TestCase(0, 1, 10, 1)]
        [TestCase(0, -1, 10, 9)]
        [TestCase(0, -2, 3, 1)]
        [TestCase(0, 77, 76, 1)]
        [TestCase(21, 3, 24, 0)]
        [TestCase(21, -3, 24, 18)]
        public void CalculateOffsetPosition(int current, int offset, int count, int expected)
        {
            var result = MathHelper.CalculateOffsetPosition(current, offset, count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(0, 1, 10, false, 0, 1)]
        [TestCase(0, 0, 10, false, 10, 10)]
        [TestCase(0, 9, 10, true, 0, 1)]
        [TestCase(5, 9, 10, true, 0, 6)]
        [TestCase(5, 9, 10, true, 10, 16)]
        public void CalculatePositionsMoved(int startPosition, int desiredPosition, int elementCount,
            bool reverse, int minPositionsToMove, int expected)
        {
            var result = MathHelper.CalculatePositionsMoved(startPosition, desiredPosition, elementCount, reverse, minPositionsToMove);
            Assert.AreEqual(expected, result);
        }
    }
}
