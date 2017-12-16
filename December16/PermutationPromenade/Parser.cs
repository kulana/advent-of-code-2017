using System;

namespace PermutationPromenade
{
    class Parser
    {
        /// <summary>
        /// Split input string into an expression and a condition
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>

        public static DanceMove Parse(string move)
        {
            char moveType = move[0];
            var data = move.Substring(1);
            var values = data.Split('/');
            switch (moveType)
            {
                case 's':
                    return new Spin(int.Parse(values[0]));

                case 'x':
                    return new Exchange(int.Parse(values[0]), int.Parse(values[1]));

                case 'p':
                    return new Partner(Convert.ToChar(values[0]), Convert.ToChar(values[1]));

                default:
                    throw new ArgumentException($"Unable to determine move type for {move}");
            }
        }

    }
}
