using Core.Penguin;
using Core.System;

namespace Company.Money;

public class MiningConsort
{
    public static readonly MiningConsort Consort = new();

    public const double CostForLightShip = 10;
    public const double CostForStandardShip = 8;
    public const double CostForHeavyShip = 5;
    
    public void Mine(Account account, SpaceShip spaceShip, Planet planet)
    {
        double cost;

        switch (spaceShip.Template)
        {
            case SpaceShipTemplate.Light:
                cost = CostForLightShip;
                break;
            case SpaceShipTemplate.Standard:
                cost = CostForStandardShip;
                break;
            case SpaceShipTemplate.Heavy:
                cost = CostForHeavyShip;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        if (account.Money < cost)
        {
            throw new NotEnoughMoneyException();
        }

        account.Money -= cost;
        spaceShip.Collect(planet.Harvest());
    }
}