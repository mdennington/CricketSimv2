using CricketSimv2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2
{


    /// <summary>
    /// Dismissal Value Object capturing how a batsman was dismissed
    /// </summary>
    public class Dismissal
    {
        private string[] dismissals =
        {
            "Bowled",
            "Caught",
            "LBW",
            "Run Out",
            "Stumped"
        };

        public string _howOut { get; private set; }
        public string _bowler { get; private set; }
        public string _caughtBy { get; private set; }

        public Dismissal(Bowler bowler, Team team, IRandomNumberGenerator rand)
        {
            _bowler = bowler.Name();
            _caughtBy = "";

            var randomNumber = rand.GetRandomNumber(0, 100);
            if (randomNumber <= 30)
            {
                _howOut = dismissals[0];
            }
            if (randomNumber > 31 & randomNumber <= 60)
            {
                _caughtBy = team.GetPlayer(rand.GetRandomNumber(0, team.NumberPlayers()));
                _howOut = dismissals[1];
            }
            if (randomNumber > 60 & randomNumber <= 80)
            {
                _howOut = dismissals[2];
            }
            if (randomNumber > 80 & randomNumber <= 90)
            {
                _howOut = dismissals[3];
            }
            if (randomNumber > 90 & randomNumber <= 100)
            {
                _howOut = dismissals[4];
            }

        }

        public override string ToString()
        {
            if (_howOut == "Caught")
            {
                return ($"c. {_caughtBy} b. {_bowler}");
            }
            if (_howOut == "Bowled")
            {
                return ($"b. {_bowler}");
            }
            if (_howOut == "LBW")
            {
                return ($"lbw b. {_bowler}");
            }
            if (_howOut == "Run Out")
            {
                return ("Run Out");
            }
            if (_howOut == "Stumped")
            {
                return ($"st. b. {_bowler}");
            }

            return ("");
           
        }
    }
}
 