using CricketSimv2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2
{
    /// <summary>
    /// Bowler Value Object Class to instantiate a bowler
    /// </summary>
    public class Bowler
    {
        string _name = "";

        public Bowler()
        {

        }
        public Bowler(string name)
        {
            _name = name;        
        }

        /// <summary>
        /// Bowl a ball (creates a ball object)
        /// </summary>
        public Ball bowl()
        {
            return new Ball();
        }

        public virtual string Name()
        {
            return _name;
        }
    }
}
