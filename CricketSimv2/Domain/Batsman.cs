using CricketSimv2.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        public IOutcome Play(Ball ball, OutcomeFactory outcomeFactory)
        {
            var retval = outcomeFactory.GetOutcome();

            return retval;
        }

    }


}
