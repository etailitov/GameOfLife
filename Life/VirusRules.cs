using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// regular rules for the game of life
    /// </summary>
    class VirusRules : LifeRules
    {
        public bool IsCellAlive(bool[,] neigbors)
        {
            int count = 0;
            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                    count += ((i != j || i != 1) && neigbors[i, j]) ? 1 : 0;
            if (neigbors[1, 1])
            {
                return count == 2 || count == 3;
            }
            else
            {
                return count == 3;
            }
        }
    }
}
