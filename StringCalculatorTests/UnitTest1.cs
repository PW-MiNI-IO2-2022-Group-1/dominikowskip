using System;
using Xunit;

namespace StringCalculatorTests;

public class UnitTest1
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        int res = TDD_IO2.StringCalculator.Calculate("");
        Assert.Equal(0, res);
    }

    [Theory]
    [InlineData("5", 5)]
    [InlineData("25", 25)]
    [InlineData("0", 0)]
    [InlineData("300", 300)]
    public void SingleNumberReturnsValue(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("5, 10, 20", 35)]
    public void CommaSeparatedNumbersReturnSum(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("5\n10", 15)]
    public void NewLineSeparatedNumbersReturnSum(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("5\n10, 30", 45)]
    public void ThreeSeparatedNumbersReturnSum(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("-5")]
    [InlineData("-7,12")]
    [InlineData("12\n-7")]
    public void NegativeNumbersThrowAnException(string s)
    {
        _ = Assert.Throws<ArgumentException>(() => TDD_IO2.StringCalculator.Calculate(s));
    }

    [Theory]
    [InlineData("2048", 0)]
    [InlineData("1024, 40", 40)]
    [InlineData("10\n1000", 1010)]
    public void NumbersGreaterThan1000ShouldBeIgnored(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("//#\n1000#30", 1030)]
    [InlineData("//a\n1,2a3", 6)]
    [InlineData("//1\n21314", 9)]
    public void ExtraSeparatorIsSupported(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }

    [Theory]
    [InlineData("//[Tymoteusz]\n1000Tymoteusz30", 1030)]
    [InlineData("//[#]\n1,2#3", 6)]
    [InlineData("//[13]\n21314", 16)]
    public void MultiCharSeparatorIsSupported(string s, int expected)
    {
        int res = TDD_IO2.StringCalculator.Calculate(s);
        Assert.Equal(res, expected);
    }
}
