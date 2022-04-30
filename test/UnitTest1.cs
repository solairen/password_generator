using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace test;

[TestClass]
public class UnitTest1
{
    int _lenght;
    string _char = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
    string _randomString = String.Empty;

    string _char_with_special = String.Empty;
    string _special_char = "!@#$%^&*";
    Random _random = new Random();
    
    [TestMethod]
    public void Test1()
    {
        _lenght = 99;
        _randomString = new string(Enumerable.Repeat(_char, _lenght).Select(s => s[_random.Next(s.Length)]).ToArray());
        Assert.AreEqual(99, _randomString.Length);
    }

    [TestMethod]
    public void Test2()
    {
        _lenght = 6;
        _char_with_special = _char + _special_char;
        _randomString = new string(Enumerable.Repeat(_char_with_special, _lenght).Select(s => s[_random.Next(s.Length)]).ToArray());
        Assert.AreEqual(6, _randomString.Length);
    }
}
