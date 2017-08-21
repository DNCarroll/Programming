using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz {

    public abstract class FizzBuzzTestDefinitionBaseClass : IFizzBuzzTestDefinition {

        public string Token { get; set; }

        public FizzBuzzTestDefinitionBaseClass(string token) {
            this.Token = !string.IsNullOrEmpty(token)? token : throw new ArgumentNullException("token cannot be null or empty");
        }

        public abstract bool IsMatch(int valueToTest);
    }

    public class FizzBuzzTestByFunc : FizzBuzzTestDefinitionBaseClass {

        public FizzBuzzTestByFunc(string token, Func<int, bool> isMatch) : base(token) {
            this._isMatch = isMatch;
        }
        private Func<int, bool> _isMatch;

        public override bool IsMatch(int valueToTest) => this._isMatch(valueToTest);
    }

    public class FizzBuzzMultiples : FizzBuzzTestDefinitionBaseClass {
        private int MultipleCheckValue { get; set; }
        public FizzBuzzMultiples(string token, int value) : base(token) {
            this.Token = token;
            this.MultipleCheckValue = value;
        }

        public override bool IsMatch(int valueToTest) {
            var remainder = valueToTest % this.MultipleCheckValue;
            return remainder == 0;
        }
    }

    public class FizzBuzzSquares : FizzBuzzTestDefinitionBaseClass {
        public FizzBuzzSquares(string token) : base(token) {
            this.Token = token;
        }

        public override bool IsMatch(int valueToTest) {
            if(valueToTest < 0) {
                return false;
            }
            var sqrRoot = Math.Sqrt(valueToTest);
            var decimalPart = sqrRoot - Math.Floor(sqrRoot);
            return decimalPart == 0;
        }
    }

    public class FizzBuzzContains : FizzBuzzTestDefinitionBaseClass {

        string digitToLookFor;

        public FizzBuzzContains(string token, int digitToLookFor) : base(token) {
            this.digitToLookFor = digitToLookFor.ToString();
        }
        public override bool IsMatch(int valueToTest) => valueToTest.ToString().Contains(this.digitToLookFor);

    }

    public class FizzBuzzPrime : FizzBuzzTestDefinitionBaseClass {

        public FizzBuzzPrime(string token) : base(token) { }

        public override bool IsMatch(int valueToTest) {            
            if (valueToTest <= 1) { return false; }
            if (valueToTest == 2) { return true; }

            var boundary = (int)Math.Floor(Math.Sqrt(valueToTest));

            for (int i = 2; i <= boundary; ++i) {
                if (valueToTest % i == 0) {
                    return false;
                }
            }
            return true;
        }
    }


}
