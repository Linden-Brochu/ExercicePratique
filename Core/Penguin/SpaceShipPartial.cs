namespace Core.Penguin;

public partial class SpaceShip
{
    private static readonly SpaceShip _lightSpaceShip = new SpaceShip(1000, 10, SpaceShipTemplate.Light);
    private static readonly SpaceShip _standardSpaceShip = new SpaceShip(4000, 30, SpaceShipTemplate.Standard);
    private static readonly SpaceShip _heavySpaceShip = new SpaceShip(9000, 50, SpaceShipTemplate.Heavy);
}