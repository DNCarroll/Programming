using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Programming.Test {
    [TestClass]
    public class DataGeneratorTest {

        //only use this if you want to make the 10,000,000 rows
        [TestMethod]
        public void GenerateSomeData() {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, "testdata.csv");
            using (var sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default)) {

                for (int x = 0; x < 10000000; x++) {
                    var values = DataGenerator.RandomValues(0, 1000, 5);
                    sw.WriteLine(string.Join(",", values));
                }
            }
            Assert.IsTrue(System.IO.File.Exists(path));
        }

    }
}
