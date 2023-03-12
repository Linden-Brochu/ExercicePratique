using Core.Penguin;
using Core.System;

namespace Company.Money;

public class Shop
{
    private static readonly Dictionary<SpaceShipTemplate, double> prices = new()
    {
        [SpaceShipTemplate.Light] = 1000,
        [SpaceShipTemplate.Standard] = 2000,
        [SpaceShipTemplate.Heavy] = 3000,
    };

    public static readonly Shop TheOneAndOnlyShop = new();

    public SpaceShip Buy(Account account, SpaceShipTemplate template)
    {
        var price = prices[template];
        if (account.Money < price)
        {
            throw new NotEnoughMoneyException();
        }

        account.Money -= price;
        return new SpaceShip(template);
    }

    public void SellResource(Account account, SpaceShip spaceShip)
    {
        account.Money += spaceShip.Take().SpaceTaken * 50;
    }

    public Account StartBusiness()
    {
        return new Account()
        {
            Money = 10000
        };
    }
}