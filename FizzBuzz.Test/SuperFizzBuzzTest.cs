using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz.Test {

    [TestFixture]
    public class SuperFizzBuzzTest {

 
        public void IsTrue(string token, int[] valuesToTest, IFizzBuzzTestDefinition testDefinition) =>
            assert(token, valuesToTest, testDefinition, Assert.IsTrue);

        public void IsFalse(string token, int[] valuesToTest, IFizzBuzzTestDefinition testDefinition)  =>
            assert(token, valuesToTest, testDefinition, Assert.IsFalse);

        private void assert(string token, int[] valuesToTest, IFizzBuzzTestDefinition testDefinition, Action<bool> assertMethod) {
            var result = true;
            var superFizzBuzz = new SuperFizzBuzz(
                (s) => {
                    if (!s.Contains(token)) {
                        result = false;
                    }
                });
            superFizzBuzz.Evaluate(valuesToTest, testDefinition);
            assertMethod(result);
        }

    }
}
