namespace SporificaVirus
{
    public class Parser
    {
        private const char InfectedPattern = '#';

        public void Parse(Grid grid, int yPosition, string line)
        {
            int xPosition = 0;
            foreach (var c in line)
            {
                var cell = new GridCell(new Position(xPosition, yPosition));
                cell.Infected = (c.Equals(InfectedPattern));
                grid.Add(cell);
                xPosition++;
            }
        } 
    }
}
