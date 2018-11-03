using System;
using Xunit;

namespace changelib.tests
{
    public class ChangeCalculatorTests
    {
        [Theory(DisplayName = "จ่ายเงินเกินราคา ระบบทอนเงิน")]
        [InlineData(100, 500, 400, 0, 0, 4, 0, 0, 0, 0)]
        public void PayMoreThanPriceThenReturnChange(int price, int amount, int expectedChange, int thousand, int fiveHundred, int hundred, int fifty, int twenty, int five, int one)
        {
            var sut = new ChangeCalculator();
            var result = sut.CalChange(price, amount);
            Assert.Equal(expectedChange, result.ChangeAmount);
            var expected = new[]
             {
                thousand,
                fiveHundred,
                hundred,
                fifty,
                twenty,
                five,
                one
            };
            Assert.Equal(expected, result.ChangeBanks);
        }

        [Theory(DisplayName = "จ่ายเงินพอดีราคา ระบบไม่ทอนเงิน")]
        [InlineData(500, 500)]
        [InlineData(5216, 5216)]
        [InlineData(0, 0)]
        [InlineData(13, 13)]
        public void PayEqualPriceThenNoChange(int price, int amount)
        {
            var sut = new ChangeCalculator();
            var result = sut.CalChange(price, amount);
            Assert.Equal(0, result.ChangeAmount);
            var expected = new[] { 0, 0, 0, 0, 0, 0, 0 };
            Assert.Equal(expected, result.ChangeBanks);
        }

        [Theory]
        [InlineData(100, 500, 400)]
        [InlineData(350, 1000, 650)]
        public void PayMoreThanPriceThenReturnChangeCorrectly(int price, int amount, int expected)
        {
            var sut = new ChangeCalculator();
            var result = sut.GetChange(price, amount);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 1)]
        [InlineData(200, 2)]
        public void GetBank100(int amount, int expected)
        {
            var sut = new ChangeCalculator();
            var result = sut.GetBanks(amount, 100);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1250, 1, 0, 2, 1, 0, 0, 0)]
        [InlineData(2132, 2, 0, 1, 0, 1, 2, 2)]
        public void TestCalBank(int amount, int thousand, int fiveHundred, int hundred, int fifty, int twenty, int five, int one)
        {
            var sut = new ChangeCalculator();
            var result = sut.CalBanks(amount);
            var expected = new[]
            {
                thousand,
                fiveHundred,
                hundred,
                fifty,
                twenty,
                five,
                one
            };
            Assert.Equal(expected, result);
        }
    }
}

// 1000, 500, 100, 50, 20, 5, 1

// Normal cases
//     /จ่ายเงินเกินราคา ระบบทอนเงิน
//     /จ่ายเงินพอดีราคา ระบบไม่ทอนเงิน
// Alternative cases
// Exception cases