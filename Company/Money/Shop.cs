using Core.Penguin;
using Core.System;

namespace Company.Money;

public class Shop
{
    public static readonly Dictionary<SpaceShipTemplate, double> Prices = new()
    {
        [SpaceShipTemplate.Light] = PriceForLight,
        [SpaceShipTemplate.Standard] = PriceForStandard,
        [SpaceShipTemplate.Heavy] = PriceForHeavy
    };

    public const double StartingMoney = 200000d;
    
    public const double PriceForLight = 1000d;
    public const double PriceForStandard = 2000d;
    public const double PriceForHeavy = 3000d;

    public const double PricePerResource = 50d;
    
    public static readonly Shop TheOneAndOnlyShop = new();

    public SpaceShip Buy(Account account, SpaceShipTemplate template)
    {
        var price = Prices[template];
        if (account.Money < price)
        {
            throw new NotEnoughMoneyException();
        }

        account.Money -= price;
        return new SpaceShip(template);
    }

    public void SellResource(Account account, SpaceShip spaceShip)
    {
        account.Money += spaceShip.Take().SpaceTaken * PricePerResource;
    }

    public double PlanForSell(double space)
    {
        return space * PricePerResource;
    }

    public Account StartBusiness()
    {
        return new Account
        {
            Money = StartingMoney
        };
    }
}