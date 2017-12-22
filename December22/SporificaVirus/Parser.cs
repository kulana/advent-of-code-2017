using SporificaVirus.States;

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
                GridCell cell;
                if (c.Equals(InfectedPattern))
                {
                    cell = new GridCell(new Position(xPosition, yPosition), new Infected());
                }
                else
                {
                    cell = new GridCell(new Position(xPosition, yPosition));
                }
                grid.Add(cell);
                xPosition++;
            }
        } 
    }
}
