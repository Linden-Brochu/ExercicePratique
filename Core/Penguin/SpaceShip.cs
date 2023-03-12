using Core.System;

namespace Core.Penguin;

public partial class SpaceShip
{
    private readonly double _initialCargoSpace;

    public double RemainingCargoSpace => _initialCargoSpace - _resourcesSout.Sum(r => r.SpaceTaken);

    private readonly double _shipWeight;

    public double ShipWeight => _shipWeight + _resourcesSout.Sum(r => r.SpaceTaken * Resource.WeightPerResource);

    private Stack<Resource> _resourcesSout;

    private SpaceShipTemplate _template;

    public SpaceShipTemplate Template => _template;

    public SpaceShip(SpaceShipTemplate template) : this()
    {
        this._template = template;
        switch(template)
        {
            case SpaceShipTemplate.Light:
                _initialCargoSpace = _lightSpaceShip._initialCargoSpace;
                _shipWeight = _lightSpaceShip._shipWeight;
                break;
            case SpaceShipTemplate.Standard:
                _initialCargoSpace = _standardSpaceShip._initialCargoSpace;
                _shipWeight = _standardSpaceShip._shipWeight;
                break;
            case SpaceShipTemplate.Heavy:
                _initialCargoSpace = _heavySpaceShip._initialCargoSpace;
                _shipWeight = _heavySpaceShip._shipWeight;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(template), template, null);
        }
    }

    internal SpaceShip(double initialCargoSpace, double shipWeight, SpaceShipTemplate template) : this()
    {
        _initialCargoSpace = initialCargoSpace;
        _shipWeight = shipWeight;
        _template = template;
    }

    private SpaceShip()
    {
        _resourcesSout = new Stack<Resource>();
    }

    public void Collect(Resource r)
    {
        if (RemainingCargoSpace - r.SpaceTaken < 0)
        {
            throw new SpaceShipSoutException();
        }

        _resourcesSout.Push(r);
    }

    public Resource Take()
    {
        if (!_resourcesSout.Any())
        {
            throw new SpaceShipResourceException();
        }

        return _resourcesSout.Pop();
    }
}