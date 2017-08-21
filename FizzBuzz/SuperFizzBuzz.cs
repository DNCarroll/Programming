using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz {

    public class SuperFizzBuzz : ISuperFizzBuzz {
        
        public Action<string> OutputHandler { get; set; }

        public event EventHandler<string> FizzBuzzOutput;

        public SuperFizzBuzz() { }
        public SuperFizzBuzz(Action<string> outputHandler) {
            this.OutputHandler = outputHandler;
        }

        public void Evaluate(int[] valuesToTest, params IFizzBuzzTestDefinition[] testDefinitions) {
            foreach (int value in valuesToTest) {
                var output = GetOutput(testDefinitions, value);
                this.FizzBuzzOutput?.Invoke(this, output);
                this.OutputHandler?.Invoke(output);
            }
        }

        private string GetOutput(IFizzBuzzTestDefinition[] testDefinitions, int value) {
            string token = null;
            foreach (var definition in testDefinitions) {
                if (definition.IsMatch(value)) {
                    token += definition.Token;
                }
            }
            return $"{token ?? value.ToString()}";
        }

    }

    public static class Extensions {

        public static void ProcessValuesForFizzBuzz(this int[] valuesToTest,
                                                    Action<string> output,
                                                    params (string token, Func<int, bool> isMatch)[] patternDefinitions) {

            foreach (var value in valuesToTest) {
                string token = null;
                foreach (var definition in patternDefinitions) {
                    if (definition.isMatch(value)) {
                        token += definition.token;
                    }
                    output($"{token??value.ToString()}");
                }
            }
        }

        public static bool ProcessValuesForFizzBuzz(this int[] valuesToTest,
                                            string token,
                                            params (string token, Func<int, bool> isMatch)[] patternDefinitions) {
            var result = true;
            valuesToTest.ProcessValuesForFizzBuzz(
                (s) => {
                    if (!s.Contains(token)) {
                        result = false;
                    }
                },
                patternDefinitions
            );
            return result;
        }
    }

}
