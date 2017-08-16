using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Programming.Test {
    [TestClass]
    public class TwoDimensionalArrayEvaluatorTest {

        [TestMethod]
        public void SixBySixWithTwoSubRegions() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid(), 170);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 2);
        }

        [TestMethod]
        public void SixBySixWithThreeSubRegions() {
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(DataGenerator.TestGrid(), 200);
            Assert.IsTrue(arrayEvaluator.SubRegions.Count == 3);
        }

        [TestMethod]
        public void SixBySixWithFourSubRegions() {
            int[,] grid = new int[6, 6];
            grid[0, 0] = 0;
            grid[0, 1] = 115;
            grid[0, 2] = 5;
            grid[0, 3] = 15;
            grid[0, 4] = 0;
            grid[0, 5] = 5;

            grid[1, 0] = 80;
            grid[1, 1] = 210;
            grid[1, 2] = 0;
            grid[1, 3] = 5;
            grid[1, 4] = 205;
            grid[1, 5] = 0;

            grid[2, 0] = 45;
            grid[2, 1] = 60;
            grid[2, 2] = 145;
            grid[2, 3] = 175;
            grid[2, 4] = 95;
            grid[2, 5] = 25;

            grid[3, 0] = 95;
            grid[3, 1] = 5;
            grid[3, 2] = 250;
            grid[3, 3] = 250;
            grid[3, 4] = 115;
            grid[3, 5] = 5;

            grid[4, 0] = 170;
            grid[4, 1] = 230;
            grid[4, 2] = 245;
            grid[4, 3] = 185;
            grid[4, 4] = 165;
            grid[4, 5] = 145;

            grid[5, 0] = 145;
            grid[5, 1] = 220;
            grid[5, 2] = 140;
            grid[5, 3] = 160;
            grid[5, 4] = 250;
            grid[5, 5] = 250;
            Programming.TwoDimensionalArrayEvaluator arrayEvaluator = new Programming.TwoDimensionalArrayEvaluator(grid, 200);
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
