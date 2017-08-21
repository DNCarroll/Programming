using con = System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace FizzBuzz.Console {
    class Program {
        static void Main(string[] args) {
            var input = UserInput();
            while(input != "x") {
                HandleUserInput(input);
                input = UserInput();
            }
        }

        static string UserInput() {
            con.WriteLine();
            con.WriteLine("Enter\r\n\t2 - for classic FizzBuzz\r\n\t3 - for SuperFizzBuzz\r\n\tp - for some primes\r\n\tx - to Exit");
            return con.ReadLine();
        }

        static void HandleUserInput(string input) {
            switch (input) {
                case "2":
                    RunClassic();
                    break;
                case "3":
                    RunSuperFizzBuzz();        
                    break;
                case "p":
                    RunSuperFizzBuzzWithPrimesToo();
                    break;
                default:
                    break;
            }
        }

        static void FizzBuzzOutput(string value) {
            con.WriteLine($"\t{value}");
        }

        static void RunClassic() {
            con.WriteLine();
            con.WriteLine("Output for coding #2");
            int[] arr = Enumerable.Range(1, 100).ToArray();            
            var fizzBuzz = new SuperFizzBuzz(Program.FizzBuzzOutput);
            fizzBuzz.Evaluate(arr, new FizzBuzzMultiples("Fizz", 3), new FizzBuzzMultiples("Buzz", 5));
        }

        static void RunSuperFizzBuzz() {
            con.WriteLine();
            con.WriteLine("Output for coding #3");
            int[] arr = Enumerable.Range(-12, 158).ToArray();
            var fizzBuzz = new SuperFizzBuzz(Program.FizzBuzzOutput);
            Array.Reverse(arr);
            fizzBuzz.Evaluate(arr,
                new FizzBuzzMultiples("Fizz", 3),
                new FizzBuzzMultiples("Buzz", 7),
                new FizzBuzzMultiples("Bazz", 38),
                new FizzBuzzSquares("Circle")
                ); 
        }

        static void RunSuperFizzBuzzWithPrimesToo() {
            con.WriteLine();
            con.WriteLine("Output for coding #3");
            int[] arr = Enumerable.Range(-12, 158).ToArray();
            var fizzBuzz = new SuperFizzBuzz(Program.FizzBuzzOutput);
            Array.Reverse(arr);
            fizzBuzz.Evaluate(arr,
                new FizzBuzzMultiples("Fizz", 3),
                new FizzBuzzMultiples("Buzz", 7),
                new FizzBuzzMultiples("Bazz", 38),
                new FizzBuzzSquares("Circle"),
                new FizzBuzzPrime("Optimus")
                );
        }
    }
}
