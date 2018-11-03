using System;

namespace changelib
{
    public class ChangeResult
    {
        public int ChangeAmount { get; set; }
        public int[] ChangeBanks { get; set; }
    }
    public class ChangeCalculator
    {
        public ChangeResult CalChange(int price, int amount)
        {
            var changeAmount = GetChange(price, amount);
            var changeBanks = CalBanks(changeAmount);
            return new ChangeResult
            {
                ChangeAmount = changeAmount,
                ChangeBanks = changeBanks
            };
        }

        public int GetChange(int price, int amount)
        {
            return amount - price;
        }

        public int GetBanks(int amount, int baseAmount)
        {
            return amount / baseAmount;
        }

        public int[] CalBanks(int amount)
        {
            var thousand = GetBanks(amount, 1000);
            amount -= 1000 * thousand;
            var fiveHundred = GetBanks(amount, 500);
            amount -= 500 * fiveHundred;
            var hundred = GetBanks(amount, 100);
            amount -= 100 * hundred;
            var fifty = GetBanks(amount, 50);
            amount -= 50 * fifty;
            var twenty = GetBanks(amount, 20);
            amount -= 20 * twenty;
            var five = GetBanks(amount, 5);
            amount -= 5 * five;
            var one = amount;
            return new[]
            {
                thousand,
                fiveHundred,
                hundred,
                fifty,
                twenty,
                five,
                one
            };
        }
    }
}
