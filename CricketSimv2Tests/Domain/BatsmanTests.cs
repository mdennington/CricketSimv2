using Xunit;
using CricketSimv2;
using System;
using System.Collections.Generic;
using System.Text;
using CricketSimv2.Domain;
using Moq;

namespace CricketSimv2
{
    public class BatsmanTests
    {
        [Fact()]
        public void test_instantiation()
        {
            var batsman = new Batsman();
            Mock<Outcome> expectedOutcome = new Mock<Outcome>();

            Mock<OutcomeFactory> outcomeFactory = new Mock<OutcomeFactory>();
            outcomeFactory.Setup(x=>x.GetOutcome()).Returns(expectedOutcome.Object);
            var outcome = batsman.Play(new Ball(), outcomeFactory.Object);

            Assert.Equal(expectedOutcome.Object, outcome);

        }


    }
}