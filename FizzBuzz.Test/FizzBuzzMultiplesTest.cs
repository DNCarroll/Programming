using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Test {
    
    public class FizzBuzzMultiplesTest : SuperFizzBuzzTest {

        [Test]
        public void Evaluate_MultiplesArray_True() =>
            this.IsTrue("Fizz", Data.MultiplesOfThree(), new FizzBuzzMultiples("Fizz", 3));            

        [Test]
        public void Evaluate_MultiplesArray_False() => 
            this.IsFalse("Fizz", Data.NotAllAreMultiplesOfThree(), new FizzBuzzMultiples("Fizz", 3));
        
    }
}
