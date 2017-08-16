using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Programming.Test {
    [TestClass]
    public class TwoDimensionalArrayEvaluatorThreadedTest {
        [TestMethod]
        public void SixBySixWithTwoSubRegions() {
            Programming.TwoDimensionalArrayEvaluatorThreaded arrayEvaluator = new Programming.TwoDimensionalArrayEvaluatorThreaded(DataGenerator.TestGrid1(), 170);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 2);
        }

        [TestMethod]
        public void SixBySixWithThreeSubRegions() {
            Programming.TwoDimensionalArrayEvaluatorThreaded arrayEvaluator = new Programming.TwoDimensionalArrayEvaluatorThreaded(DataGenerator.TestGrid1(), 200);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 3);
        }

        [TestMethod]
        public void SixBySixWithFourSubRegions() {

            Programming.TwoDimensionalArrayEvaluatorThreaded arrayEvaluator = new Programming.TwoDimensionalArrayEvaluatorThreaded(DataGenerator.TestGrid2(), 200);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 4);

        }
    }
}
