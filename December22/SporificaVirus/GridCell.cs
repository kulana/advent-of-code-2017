namespace SporificaVirus
{
    public class GridCell
    {
        public bool Infected { get; set; }
        public Position Position { get; private set; }

        public GridCell(Position position)
        {
            Position = position;
        }

        public void Visit(Carrier carrier)
        {
            Infected = !Infected;

        }
    }
}
