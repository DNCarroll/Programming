using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz.Test {
    public class FizzBuzzContainsTest :SuperFizzBuzzTest {

        [Test]
        public void Evaluate_ArraysWithNumberThree_True() =>
            this.IsTrue("Contains", Data.EachIntInArrayHasAThreeDigit(), new FizzBuzzContains("Contains", 3));

        [Test]
        public void Evaluate_ArraysWithNumberThree_False() =>
            this.IsFalse("Contains", Data.NotAllIntsInArrayHaveAThreeDigit(), new FizzBuzzContains("Contains", 3));
    }
}
