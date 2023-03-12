using Core.Penguin;
using Core.System;

namespace Company.Money;

public class MiningConsort
{
    public static readonly MiningConsort Consort = new();

    public void Mine(Account account, SpaceShip spaceShip, Planet planet)
    {
        if (account.Money < 10)
        {
            throw new NotEnoughMoneyException();
        }
        
        spaceShip.Collect(planet.Harvest());
    }
}