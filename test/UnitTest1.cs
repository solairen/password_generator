using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Test
{
  [TestClass]
  public class PasswordGeneratorTests
  {
    private const string Characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
    private const string SpecialCharacters = "!@#$%^&*";
    private readonly Random random = new Random();

    [TestMethod]
    public void GeneratePassword_Length99_ReturnsPasswordWithLength99()
    {
      int length = 99;
      string password = GeneratePassword(length, includeSpecialChar: false);
      Assert.AreEqual(length, password.Length);
    }

    [TestMethod]
    public void GeneratePassword_Length6WithSpecialChar_ReturnsPasswordWithLength6AndSpecialChar()
    {
      int length = 6;
      string password = GeneratePassword(length, includeSpecialChar: true);
      Assert.AreEqual(length, password.Length);
      Assert.IsTrue(password.Any(c => SpecialCharacters.Contains(c)));
    }

    private string GeneratePassword(int length, bool includeSpecialChar)
    {
      string availableCharacters = Characters;

      if (includeSpecialChar)
      {
        availableCharacters += SpecialCharacters;
      }

      string password = new string(Enumerable.Repeat(availableCharacters, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

      return password;
    }
  }
}
