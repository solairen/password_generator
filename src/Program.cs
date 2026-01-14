using System;
using System.Security.Cryptography;
using CommandLine;

namespace PasswordGenerator
{
    class Options
    {
        [Option('l', "length", Required = true, HelpText = "Enter password length.")]
        public int Length { get; set; }

        [Option("special_char", Required = false, HelpText = "Include special characters in the password.", Default = false)]
        public bool IncludeSpecialChar { get; set; }
    }

    class Program
    {
        const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        const string Digits = "0123456789";
        const string SpecialCharacters = "!@#$%^&*";

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options =>
            {
                string availableCharacters = UppercaseLetters + LowercaseLetters + Digits;

                if (options.IncludeSpecialChar)
                {
                    availableCharacters += SpecialCharacters;
                }

                char[] passwordChars = new char[options.Length];
                byte[] randomBytes = new byte[options.Length];
                RandomNumberGenerator.Fill(randomBytes);

                for (int i = 0; i < options.Length; i++)
                {
                    int index = randomBytes[i] % availableCharacters.Length;
                    passwordChars[i] = availableCharacters[index];
                }

                string password = new string(passwordChars);

                Console.WriteLine($"Password length: {options.Length}");
                Console.WriteLine($"Include special characters: {options.IncludeSpecialChar}");
                Console.WriteLine($"Password: {password}");
            });
        }
    }
}
