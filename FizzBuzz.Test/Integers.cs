using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Test {
    
    [TestFixture]
    public class IntegersTest {

        [Test]
        public void ProcessValuesForFizzBuzzTupleMethod_AllMultiplesValues_True() {
            var result = Data.MultiplesOfThree().ProcessValuesForFizzBuzz(
                "Fizz",
                ("Fizz", (v) => v % 3 == 0)
            );
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessValuesForFizzBuzzTupleMethod_NotAllMultiplesValues_False() {
            var result = false;
            Data.NotAllAreMultiplesOfThree().ProcessValuesForFizzBuzz(
                (s) => {
                    if (!s.Contains("Fizz")) {
                        result = false;
                    }
                },
                ("Fizz", (v) => v % 3 == 0)
            );
            Assert.IsFalse(result);
        }
    }
}
