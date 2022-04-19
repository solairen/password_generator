using System;
using System.Linq;
using CommandLine;

namespace password_generator {
    class Options {
        [Option('l', "length", Required = true, HelpText = "Enter password length.")]
        public int _length { get; set; }

        [Option("special_char", Required = false, HelpText = "Special characters in password.", Default = false)]
        public bool _special_char { get; set; }
    }

    class Program {
        const string _chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
        static string _new_char;

        static void Main(string[] args) {
            Random random = new Random();
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                if (o._special_char == true) {
                    _new_char = _chars + "!@#$%^&*";
                }
                else{
                    _new_char = _chars;
                }
                string _randomString = new string(Enumerable.Repeat(_new_char, o._length).Select(s => s[random.Next(s.Length)]).ToArray());
                Console.WriteLine($"Password length: {o._length}");
                Console.WriteLine($"Special characters: {o._special_char}");
                Console.WriteLine($"Password: {_randomString}");
            });
        }
    }
}