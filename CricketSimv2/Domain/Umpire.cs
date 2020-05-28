using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2.Domain
{
    /// <summary>
    /// Umpire class that manages the play
    /// </summary>
    class Umpire
    {
        private int EndOfOver = 6;
        public Umpire()
        {

        }

        /// <summary>
        /// Start Innings
        /// </summary>
        /// <param name="teamBatting">Team object containing the team batting</param>
        /// <param name="teamBowling">Team object containing the team bowling</param>
        /// <param name="scoreKeeper">Scorekeeper object</param>
        public void Start(Team teamBatting, Team teamBowling, Scorekeeper scoreKeeper)
        {
            // TODO Play and innnings
            bool endOfInnings = false;
            var currentBatsman = new Batsman();
            var outcomeFactory = new ConcreteOutcomeFactory();

            do
            {
                Bowler currentBowler = teamBowling.GetNextBowler();
                int ballsBowled = 0;
                do
                {
                    var ball = currentBowler.bowl();
                    IOutcome ballOutcome = currentBatsman.Play(ball, outcomeFactory);
                    if (ballOutcome.IsValidBall()) ballsBowled++;
                    
                    scoreKeeper.UpdateScoreboard(ballOutcome);

                } while (!endOfInnings & ballsBowled != EndOfOver);
                  
            } while (!endOfInnings);

        }

        
    }
}
