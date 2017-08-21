using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz {
    public interface ISuperFizzBuzz {
        Action<string> OutputHandler { get; set; }
        event EventHandler<string> FizzBuzzOutput;
        void Evaluate(int[] integersToTest, IFizzBuzzTestDefinition[] testDefinitions);
    }
}
