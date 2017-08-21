using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Test {
    [TestFixture]
    public class FizzBussTestDefinitionBaseClassTest {

        [Test]

        public void Instantiation_Null_Exception() =>
            Assert.Throws<ArgumentNullException>(() => new FizzBuzzMultiples(null, 4));

        [Test]

        public void Instantiation_NullByEmpty_Exception() =>
            Assert.Throws<ArgumentNullException>(() => new FizzBuzzMultiples(null, 4));

    }
}
