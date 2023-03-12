namespace Core.Penguin;

public partial class SpaceShip
{
    private static readonly SpaceShip _lightSpaceShip = new SpaceShip(1000, 10);
    private static readonly SpaceShip _standardSpaceShip = new SpaceShip(4000, 30);
    private static readonly SpaceShip _heavySpaceShip = new SpaceShip(9000, 50);
}