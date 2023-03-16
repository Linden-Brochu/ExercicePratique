using Core.Penguin;
using Core.System;

namespace Company.Money;

public class TravelAgency
{
    public static readonly TravelAgency Agency = new();

    public const double CostPerAu = 5/100d;
    
    public void Travel(Account account, Planet p1, Planet p2, PlanetarySystem system, SpaceShip ship)
    {
        var distance = Math.Abs(system[p1] - system[p2]);

        if (account.Money < distance * CostPerAu * ship.ShipWeight)
        {
            throw new NotEnoughMoneyException();
        }

        account.Money -= distance * CostPerAu * ship.ShipWeight;
    }

    public double PriceForTravel(Planet p1, Planet p2, PlanetarySystem system, SpaceShip ship, double extraSpace = 0d)
    {
        var distance = Math.Abs(system[p1] - system[p2]);

        return distance * CostPerAu * (ship.ShipWeight + Resource.WeightPerResource * extraSpace);
    }
    
}