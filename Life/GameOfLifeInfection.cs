using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// maitain the game of life with the new infection mode
    /// </summary>
    class GameOfLifeInfection : GameOfLife
    {
        protected int _infectAfter;

        public GameOfLifeInfection(int width, int height, int maxGenerations, int infectAfter)
            : base(width, height, maxGenerations)
        {
            _infectAfter = infectAfter;
            if (infectAfter == 0)
                _rules = new InfectionRules();
        }

        public GameOfLifeInfection(int width, int height, int maxGenerations, int infectAfter, bool[,] world)
            : base(width, height, maxGenerations, world)
        {
            _infectAfter = infectAfter;
            if (infectAfter == 0)
                _rules = new InfectionRules();
        }

        /// <summary>
        /// changes the rules to infection rules when the right generation comes
        /// </summary>
        public override string RunStep()
        {
            var res = base.RunStep();
            if (_currentGen == _infectAfter)
                _rules = new InfectionRules();
            return res;
        }
    }
}
