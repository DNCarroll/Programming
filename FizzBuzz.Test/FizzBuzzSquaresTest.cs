using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Test {
    
    public class FizzBuzzSquaresTest :SuperFizzBuzzTest {
        [Test]
        public void Evaluate_SquaresArray_True() =>
            this.IsTrue("Circle", Data.Squares(), new FizzBuzzSquares("Circle"));

        [Test]
        public void Evaluate_SquaresArray_False() =>
            this.IsFalse("Cirle", Data.NotAllSquares(), new FizzBuzzSquares("Circle"));

    }
}
