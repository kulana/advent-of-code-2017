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
                var cell = new GridCell(new Position(xPosition, yPosition));
                if (c.Equals(InfectedPattern))
                {
                    cell.State = new Infected();
                }
                else
                {
                    cell.State = new Clean();
                }
                grid.Add(cell);
                xPosition++;
            }
        } 
    }
}
