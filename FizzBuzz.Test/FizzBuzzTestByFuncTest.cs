using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz;

namespace FizzBuzz.Test {

    public class FizzBuzzTestByFuncTest : SuperFizzBuzzTest {

        [Test]
        public void Evaluate_ArrayWithNumberThree_True() =>
            this.IsTrue("Contains", Data.EachIntInArrayHasAThreeDigit(), new FizzBuzzTestByFunc("Contains", (v) => {
                var vs = v.ToString();
                return vs.Contains("3");
            }));

        [Test]
        public void Evaluate_ArrayWithNumberThree_False() =>
            this.IsFalse("Contains", Data.NotAllIntsInArrayHaveAThreeDigit(), new FizzBuzzTestByFunc("Contains", (v) => {
                var vs = v.ToString();
                return vs.Contains("3");
            }));

        [Test]
        public void Evaluate_MultiplesArray_True() =>
            this.IsTrue("Fizz", Data.MultiplesOfThree(), new FizzBuzzTestByFunc("Fizz", (v) => { return v % 3 == 0; }));

        [Test]
        public void Evaluate_MultiplesArray_False() =>
            this.IsFalse("Fizz", Data.NotAllAreMultiplesOfThree(), new FizzBuzzTestByFunc("Fizz", (v) => { return v % 3 == 0; }));

        [Test]
        public void Evaluate_SquaresArray_True() =>
            this.IsTrue("Circle", Data.Squares(), new FizzBuzzTestByFunc("Circle", (v) => {
                if (v < 0) {
                    return false;
                }
                var squareRoot = Math.Sqrt(v);
                return squareRoot - Math.Floor(squareRoot) == 0;
            }));

        [Test]
        public void Evaluate_SquaresArray_False() =>
            this.IsFalse("Circle", Data.NotAllSquares(), new FizzBuzzTestByFunc("Circle", (v) => {
                if (v < 0) {
                    return false;
                }
                var squareRoot = Math.Sqrt(v);
                return squareRoot - Math.Floor(squareRoot) == 0;
            }));


    }
}
