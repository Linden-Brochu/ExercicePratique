using Core.Penguin;
using Simulation;

Dictionary<SpaceShipTemplate, double> costPerClass = new Dictionary<SpaceShipTemplate, double>();

Parallel.ForEach(Enum.GetValues<SpaceShipTemplate>(), value =>
{
    var sim = new Simulator();
    var cost = sim.Simulate(value);

    lock (costPerClass)
    {
        costPerClass[value] = cost;
    }
});

Console.ReadLine();