using System;
using System.IO;

namespace Programming.Test {
    public static  class TwoDimimensionalArrayHelper {

        public static int[,] GetTenMillionsRecords() {
            int[,] ret = new int[10000000, 5];
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, "testdata.csv");
            int pos = 0;
            //using (var sr = new StreamReader(inputFile, Encoding.UTF8, true, 65536))
            using (var sr = new StreamReader(path, System.Text.Encoding.Default, true, 65536)) {
                //read 10 strings and kick off thread
                while (sr.Peek() > -1) {
                    var values = sr.ReadLine().Split(',');
                    ret[pos, 0] = int.Parse(values[0]);
                    ret[pos, 1] = int.Parse(values[1]);
                    ret[pos, 2] = int.Parse(values[2]);
                    ret[pos, 3] = int.Parse(values[3]);
                    ret[pos, 4] = int.Parse(values[4]);
                    pos++;
                }
            }
            return ret;
        }
    }
}
