using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2
{
    /// <summary>
    /// Ball outcome class to instantiate a ball outcome value object
    /// </summary>
    public class Outcome
    {
        public bool wicket { get; private set; }
        public int runs { get; private set; }

        public bool noBall { get; private set; }

        public int wides { get; private set; }

        public int byes { get; private set; }

        public int legByes { get; private set; }


        // TODO Create Random Number Generator and Interface in Common Folder
        // TODO 
        public Outcome(IRandomNumberGenerator rand)
        {
            var result = rand.GetRandomNumber(0, 133);

            if (result >0 & result < 58)
            {
                this.runs = 0;
            }

            if (result >= 58 & result <= 81)
            {
                this.runs = 1;
            }

            if (result >= 82 & result <=88)
            {
                this.runs = 2;
            }

            if (result == 89)
            {
                this.runs = 3;
            }

            if (result >= 90 & result <= 96)
            {
                this.runs = 4;
            }

            if (result >= 97 & result <= 98)
            {
                this.runs = 6;
            }

            if (result >= 99 & result <= 100)
            {
                this.runs = 0;
                this.wicket = true;
            }

            if (result > 100 & result <= 104)
            {
                this.runs = 1;
                this.noBall = true;
                this.wicket = false;
            }

            if (result > 104 & result <= 108)
            {
                this.runs = 1;
                this.wides = 1;
                this.wicket = false;
            }

            if (result == 109)
            {
                this.runs = 2;
                this.wides = 2;
                this.wicket = false;
            }

            if (result == 110)
            {
                this.runs = 3;
                this.wides = 3;
                this.wicket = false;
            }

            if (result > 110 & result <= 113)
            {
                this.runs = 4;
                this.wides = 4;
                this.wicket = false;
            }

            if (result > 113 & result <= 118)
            {
                this.runs = 1;
                this.byes = 1;
                this.wicket = false;
            }

            if (result == 120)
            {
                this.runs = 2;
                this.byes = 2;
                this.wicket = false;
            }

            if (result == 121)
            {
                this.runs = 3;
                this.byes = 3;
                this.wicket = false;
            }

            if (result > 121 & result <= 125)
            {
                this.runs = 4;
                this.byes = 4;
                this.wicket = false;
            }

            if (result > 125 & result <= 127)
            {
                this.runs = 1;
                this.legByes = 1;
                this.wicket = false;
            }

            if (result == 128)
            {
                this.runs = 2;
                this.legByes = 2;
                this.wicket = false;
            }

            if (result == 129)
            {
                this.runs = 3;
                this.legByes = 3;
                this.wicket = false;
            }

            if (result > 129 & result <= 133)
            {
                this.runs = 4;
                this.legByes = 4;
                this.wicket = false;
            }



            // Takes Event and creates outcome and returns
            // TODO Map events in Cricket and probability 
            // 58% of balls are dot balls
            // 24% of balls are 1s
            // 7% are 2s
            // 2% are hit for six
            // 7% are fours
            // 1% are threes
            // 3% are dismissals
        }

        internal int IsValidBall()
        {
            throw new NotImplementedException();
        }
    }
}
