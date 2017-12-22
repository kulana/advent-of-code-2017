namespace SporificaVirus
{
    public interface IDirectionStrategy
    {
        Direction NewDirection(GridCell cell, Direction currentDirection);
    }
}
