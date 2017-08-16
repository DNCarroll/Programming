using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Programming.Test {
    [TestClass]
    public class TwoDimensionalArrayEvaluatorTest {

        [TestMethod]
        public void SixBySixWithTwoSubRegions() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid1(), 170);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 2);
        }

        [TestMethod]
        public void SixBySixWithThreeSubRegions() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid1(), 200);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 3);
        }

        [TestMethod]
        public void SixBySixWithThreeSubRegionsValues() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid1(), 200);
            var passed =false;
            if (arrayEvaluator.SubRegions.Count == 3) {
                var s1 = arrayEvaluator.SubRegions[0].Signals;
                var s2 = arrayEvaluator.SubRegions[1].Signals;
                var s3 = arrayEvaluator.SubRegions[2].Signals;
                passed = passesSignalTest(s1, new Signal<int>[] { new Signal<int>(1, 1, 210) }) &&
                    passesSignalTest(s2, new Signal<int>[] {
                        new Signal<int>(3, 2, 250),
                        new Signal<int>(3, 3, 250),
                        new Signal<int>(4, 1, 230),
                        new Signal<int>(4, 2, 245),
                        new Signal<int>(5, 1, 220)

                    }) &&
                    passesSignalTest(s3, new Signal<int>[] {
                        new Signal<int>(5, 4, 250),
                        new Signal<int>(5, 5, 250),
                    });
            }
            Assert.IsTrue(passed);
        }

        [TestMethod]
        public void SixBySixWithThreeSubRegionsCenterOfMass() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid1(), 200);
            Assert.IsTrue(
                arrayEvaluator.SubRegions.Count ==3 &&
                arrayEvaluator.SubRegions[0].CenterOfMass.X ==1 &&
                arrayEvaluator.SubRegions[0].CenterOfMass.Y==1 &&
                arrayEvaluator.SubRegions[1].CenterOfMass.X >3 && arrayEvaluator.SubRegions[1].CenterOfMass.X <4 &&
                arrayEvaluator.SubRegions[1].CenterOfMass.Y > 1 && arrayEvaluator.SubRegions[1].CenterOfMass.Y < 2 &&
                arrayEvaluator.SubRegions[2].CenterOfMass.X == 5 &&
                arrayEvaluator.SubRegions[2].CenterOfMass.Y >4 && arrayEvaluator.SubRegions[2].CenterOfMass.Y < 5
                );
        }

        bool passesSignalTest(List<Signal<int>> signals,
            Signal<int>[] expectedSignals) {
            var passed = true;
            if (signals.Count == expectedSignals.Length) {
                foreach (var signal in expectedSignals) {
                    if (signals.FirstOrDefault(s => s.X == signal.X && s.Y == signal.Y && signal.Value == s.Value) == null) {
                        passed = false;
                        break;
                    }
                }
            }
            else {
                passed = false;
            }
            return passed;
        }

        [TestMethod]
        public void SixBySixWithFourSubRegions() {

            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid2(), 200);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 4);

        }

        [TestMethod]
        public void TenMillionByFiveWith3487610Regions() {
            var grid = TwoDimimensionalArrayHelper.GetTenMillionsRecords();
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(grid, 650);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 3487610);
        }

        [TestMethod]
        public void Read10MilFile() {
            var grid = TwoDimimensionalArrayHelper.GetTenMillionsRecords();
            Assert.IsTrue(grid.Length > 0);
        }

    }    
}
