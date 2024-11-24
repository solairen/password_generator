using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Test
{
  [TestClass]
  public class PasswordGeneratorTests
  {
    private const string Characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
    private const string SpecialCharacters = "!@#$%^&*";
    private readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

    [DataTestMethod]
    [DataRow(99, false)]
    [DataRow(6, true)]
    public void GeneratePassword_Test(int length, bool includeSpecialChar)
    {
      string password = GeneratePassword(length, includeSpecialChar);
      Assert.AreEqual(length, password.Length);
    }

    private string GeneratePassword(int length, bool includeSpecialChar)
    {
      string availableCharacters = Characters;

      if (includeSpecialChar)
      {
        availableCharacters += SpecialCharacters;
      }

      byte[] randomBytes = new byte[length];
      rng.GetBytes(randomBytes);
      string password = new string(randomBytes.Select(b => availableCharacters[b % availableCharacters.Length]).ToArray());

      return password;
    }
  }
}
