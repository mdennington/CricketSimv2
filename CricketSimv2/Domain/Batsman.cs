using CricketSimv2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2
{
    /// <summary>
    /// Batsman Value Object to instantiate a batsman
    /// </summary>
    public class Batsman
    {
        public Batsman()
        {


        }

        /// <summary>
        /// Play method which take ball as input and generates outcome object
        /// </summary>
        /// <param name="ball"></param>
        /// <returns></returns>
        public Outcome Play(Ball ball)
        {
            // TODO use outcome and ball interface
            return null;
        }

        internal Outcome play(object ball)
        {
            throw new NotImplementedException();
        }
    }


}
