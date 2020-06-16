using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FruityFramework.Reels.Tests
{
    public class ReelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Spin_Forward_Once()
        {
            var reel = new Reel(CreateReel());
            var target = reel.CurrentPosition.Next;
            var result = await reel.Spin(new ReelSpinOptions()
            {
                Target = target,
                Direction = ReelSpinDirection.Forward
            });
            Assert.AreEqual(1, result.PositionsMoved);
            Assert.AreEqual(target, result.FinalPosition);
            Assert.AreEqual(target, reel.CurrentPosition);
            Assert.AreEqual("1", reel.CurrentPosition.Symbol.Key);
        }
        [Test]
        public async Task Spin_Back_Once()
        {
            var reel = new Reel(CreateReel());
            var target = reel.CurrentPosition.Previous;
            var result = await reel.Spin(new ReelSpinOptions()
            {
                Target = target,
                Direction = ReelSpinDirection.Reverse
            });
            Assert.AreEqual(1, result.PositionsMoved);
            Assert.AreEqual(target, result.FinalPosition);
            Assert.AreEqual(target, reel.CurrentPosition);
            Assert.AreEqual("19", reel.CurrentPosition.Symbol.Key);
        }

        [Test]
        public async Task Spin_Forward_To_Previous()
        {
            var reel = new Reel(CreateReel());
            var target = reel.CurrentPosition.Previous;
            var result = await reel.Spin(new ReelSpinOptions()
            {
                Target = target,
                Direction = ReelSpinDirection.Forward
            });
            Assert.AreEqual(19, result.PositionsMoved);
            Assert.AreEqual(target, result.FinalPosition);
            Assert.AreEqual(target, reel.CurrentPosition);
            Assert.AreEqual("19", reel.CurrentPosition.Symbol.Key);
        }

        private List<ReelSegment> CreateReel()
        {
            return Enumerable.Range(0, 20)
                .Select(r =>
                {
                    return new ReelSegment()
                    {
                        Symbol = new ReelSymbol()
                        {
                            Key = r.ToString()
                        }
                    };
                }).ToList();
        }
    }
}
