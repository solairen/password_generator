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
    private readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

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

      byte[] randomBytes = new byte[length];
      rng.GetBytes(randomBytes);
      string password = new string(randomBytes.Select(b => availableCharacters[b % availableCharacters.Length]).ToArray());

      return password;
    }
  }
}
