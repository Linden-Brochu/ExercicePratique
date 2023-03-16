using Company.Money;
using Core.Penguin;
using Core.System;

namespace Simulation;

public class Simulator
{
    public double Simulate(SpaceShipTemplate template)
    {
        Account account = Shop.TheOneAndOnlyShop.StartBusiness();

        PlanetarySystem system = new PlanetarySystem();
        Planet p1 = new Planet();
        Planet p2 = new Planet();
        Planet p3 = new Planet();
        Planet p4 = new Planet();
        Planet p5 = new Planet();
        Planet p6 = new Planet();
        system[p1] = 0.5f;
        system[p2] = 3f;
        system[p3] = 4.2f;
        system[p4] = 4.7f;
        system[p5] = 7.1;
        system[p6] = 10.2;

        SpaceShip s = Shop.TheOneAndOnlyShop.Buy(account, template);

        double initialMoney = account.Money;
        double initialSpace = s.RemainingCargoSpace;
        
        TravelAgency a = TravelAgency.Agency;
        Planet initialPlanet = p1;
        Planet endPlanet = p6;
        a.Travel(account,initialPlanet, endPlanet, system, s);
        
        endPlanet.Scan();
        double lastSpace = 0;

        bool hasRemainingSpace = true;
        bool hasMoneyToNextTravel = true;
        bool isMarginBetter = true;

        int numberOfMining = 0;
        
        while (hasRemainingSpace && hasMoneyToNextTravel && endPlanet.HasResources && isMarginBetter)
        {
            double actualSpace = initialSpace - s.RemainingCargoSpace;
            MiningConsort.Consort.Mine(account, s, endPlanet);
            double finalSpace = initialSpace - s.RemainingCargoSpace;
            lastSpace = finalSpace - actualSpace;

            numberOfMining++;
            
            hasRemainingSpace = s.RemainingCargoSpace - lastSpace > 0;
            hasMoneyToNextTravel =
                a.PriceForTravel(endPlanet, initialPlanet, system, s, lastSpace)
                + MiningConsort.Consort.PriceForMining(s) <=
                account.Money;

            double priceForMining = MiningConsort.Consort.PriceForMining(s);

            double extraCost1 = a.PriceForTravel(initialPlanet, endPlanet, system, s) * 2 +
                                priceForMining * numberOfMining;
            double extraCost2 = a.PriceForTravel(initialPlanet, endPlanet, system, s) +
                                a.PriceForTravel(endPlanet, initialPlanet, system, s, lastSpace) +
                                priceForMining * (numberOfMining + 1);
            isMarginBetter = CalculateMarge(initialSpace, extraCost1) <
                             CalculateMarge(initialSpace + lastSpace, extraCost2);
        }
        a.Travel(account, endPlanet, initialPlanet, system, s);

        double cargo = initialSpace - s.RemainingCargoSpace;
        double moneyBeforeSell = account.Money;

        while (s.RemainingCargoSpace != initialSpace)
        {
            Shop.TheOneAndOnlyShop.SellResource(account, s);
        }

        double moneyAfterSell = account.Money;

        double ratioResourceCost = (moneyAfterSell - moneyBeforeSell) / initialSpace;

        return ratioResourceCost;
    }

    public double CalculateMarge(double cargoSpace, double otherCosts)
    {
        double sale = Shop.TheOneAndOnlyShop.PlanForSell(cargoSpace);

        if (otherCosts == 0)
        {
            otherCosts = 1;
        }

        return sale / otherCosts;
    }
}