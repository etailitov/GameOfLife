using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// interface for the generation life rules
    /// </summary>
    interface LifeRules
    {
        bool IsCellAlive(bool[, ] neigbors);
    }
}
