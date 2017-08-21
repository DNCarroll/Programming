using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz {
    public interface IFizzBuzzTestDefinition {
        string Token { get; set; }
        bool IsMatch(int valueToTest);
    }
}
