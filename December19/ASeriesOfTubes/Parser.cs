using System;

namespace ASeriesOfTubes
{
    class Parser
    {
        private readonly LinkedNodes _nodes;

        public Parser(LinkedNodes nodes)
        {
            _nodes = nodes;
        }

        public void Parse(int lineNumber, string line)
        {
            // process charcter per character
            // if character is not empty, then create a node using the coordinate
            int x = 1;
            foreach (var c in line)
            {
                if (c != ' ' && c != '\n')
                {
                    Node node = null;
                    switch (c)
                    {
                        case '|':
                            node = new VerticalNode(x, lineNumber);
                            break;
                        case '-':
                            node = new HorizontalNode(x, lineNumber);
                            break;

                        case '+':
                            node = new PlusNode(x, lineNumber);
                            break;

                        default:
                            node = new LetterNode(x, lineNumber, c);
                            break;
                    }
                    _nodes.AddNode(node);
                }
                x++;
            }
        }
    }
}
