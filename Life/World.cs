using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// contain the bool map for the game of life.
    /// </summary>
    class World
    {
        private bool[,] _cells;
        private int _width, _height;
        
        public World(int width,int height)
        {
            _cells = new bool[width+2,height+2];
            _width = width;
            _height = width;
            for (int h = 0; h < _height+2; h++)
                for (int w = 0; w < _width+2; w++)
                    _cells[h,w] = false;
        }

        public bool SetWorld(bool[,] newWorld)
        {
            if (newWorld.Length != _height * _width)
                return false;
            for (int h = 0; h < _height; h++)
                for (int w = 0; w < _width; w++)
                {
                    this[h, w] = newWorld[h, w];
                }
            return true;
        }

        /// <summary>
        /// access for the world map while converting the index to ignore the border
        /// </summary>
        /// <returns>if the cell is alive</returns>
        public bool this[int h, int w]
        {
            get
            {
                return _cells[h + 1, w + 1];
            }
            private set
            {
                _cells[h + 1, w + 1] = value;
            }
        }

        /// <summary>
        /// calculate the new generation using the given rules
        /// </summary>
        /// <param name="rules">what rules to use for the calculation</param>
        public void NextGeneration(LifeRules rules)
        {
            bool[,] nextGen = new bool[_width, _height];
            for (int h = 0; h < _height; h++)
                for (int w = 0; w < _width; w++)
                {
                    bool[,] neigbors = { { this[h - 1, w - 1], this[h, w - 1], this[h+1,w-1] },
                                         { this[h - 1, w ],    this[h, w ],    this[h+1,w]   },
                                         { this[h - 1, w + 1], this[h, w + 1], this[h+1,w+1] }};
                    nextGen[h,w] = rules.IsCellAlive(neigbors);
                }
            SetWorld(nextGen);
        }

        public override string ToString()
        {
            string print = "";
            for (int h = 0; h < _height; h++)
                for (int w = 0; w < _width; w++)
                {
                    print += (this[h, w]) ? "1" : "0";
                }
            return print;
        }
    }
}
