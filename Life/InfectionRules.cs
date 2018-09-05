using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// infection rules for the game of life
    /// </summary>
    class InfectionRules : LifeRules
    {
        public bool IsCellAlive(bool[,] neigbors)
        {
            if (neigbors[1, 1])
            {
                return neigbors[1, 0] || neigbors[0, 1] || neigbors[1, 2] || neigbors[2, 1];
            }
            else
            {
                int count = 0;
                for (int i = 0; i <= 2; i++)
                    for (int j = 0; j <= 2; j++)
                        if (neigbors[i, j])
                            count++;
                return count == 1;
            }
        }
    }
}
