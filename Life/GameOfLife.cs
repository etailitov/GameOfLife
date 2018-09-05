using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// maitain the game of life
    /// </summary>
    class GameOfLife
    {
        protected int _maxGenerations;
        protected World _world;
        protected LifeRules _rules;
        protected int _currentGen;

        public GameOfLife(int width, int height, int maxGenerations)
        {
            _world = new World(width, height);
            _rules = new VirusRules();
            _maxGenerations = maxGenerations;
            _currentGen = 0;
        }
        
        public GameOfLife(int width, int height, int maxGenerations, bool[,] world) : this(width, height, maxGenerations)
        {
            _world.SetWorld(world);
        }

        /// <summary>
        /// run all the generations for the game of life
        /// </summary>
        /// <param name="Print">how do you want to print every generation</param>
        /// <param name="sleepMili">how many mili seconds to sleep between generations</param>
        /// <returns>the final string</returns>
        public virtual string RunAll(Action<string> Print = null, int sleepMili = 200)
        {
            // if no function was given create an empty one
            if (Print == null)
                Print = (s) => { };

            Print(_world.ToString());

            while (++_currentGen <= _maxGenerations)
            {
                System.Threading.Thread.Sleep(sleepMili);
                Print(RunStep());
            }

            return _world.ToString();
        }

        /// <summary>
        /// calculate a single generation
        /// </summary>
        /// <param name="generation">which generation is it calculating</param>
        /// <returns>the new generation</returns>
        public virtual string RunStep()
        {
            _world.NextGeneration(_rules);
            return _world.ToString();
        }

        public override string ToString()
        {
            return _world.ToString();
        }
    }
}
