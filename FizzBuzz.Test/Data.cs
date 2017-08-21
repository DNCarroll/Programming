using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Test {
    public static class Data {
        public static int[] MultiplesOfThree() => new int[] { 3, 6, -6 };

        public static int[] NotAllAreMultiplesOfThree() => new int[] { 3, 6, 8 };

        public static int[] Squares() => new int[] { 9, 81, 144 };

        public static int[] NotAllSquares() => new int[] { 9, 81, 34 };

        public static int[] EachIntInArrayHasAThreeDigit() => new int[] { 3, 13, -45423 };

        public static int[] NotAllIntsInArrayHaveAThreeDigit() => new int[] { 3, 13, 4542 };
    }
}
