using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2.Domain
{
    /// <summary>
    /// Outcome factory to generate Outcome objects
    /// </summary>
    public abstract class OutcomeFactory
    {
        public abstract IOutcome GetOutcome();
    }



    /// <summary>
    /// A 'concrete creator class to generate outcome object' class
    /// </summary>
    public class ConcreteOutcomeFactory : OutcomeFactory
    {
        public override IOutcome GetOutcome()
        {
            IRandomNumberGenerator randomNumberGenerator = new GetRandomNumber();
            return new Outcome(randomNumberGenerator);
        }

    }
}

