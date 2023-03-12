using Core.Penguin;
using Core.System;

namespace Company.Money;

public class TravelAgency
{
    public static readonly TravelAgency Agency = new();

    public void Travel(Account account, Planet p1, Planet p2, PlanetarySystem system, SpaceShip ship)
    {
        var distance = Math.Abs(system[p1] - system[p2]);

        if (account.Money < distance * 10 * ship.ShipWeight)
        {
            throw new NotEnoughMoneyException();
        }

        account.Money -= distance * 10 * ship.ShipWeight;
    }
}