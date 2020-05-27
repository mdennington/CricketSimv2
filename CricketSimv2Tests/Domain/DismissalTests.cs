using Xunit;
using CricketSimv2;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using CricketSimv2.Domain;

namespace CricketSimv2.Tests
{
    public class DismissalTests
    {

        //if (randomNumber <= 30)
        //if (randomNumber > 31 & randomNumber <= 60)
        //if (randomNumber > 60 & randomNumber <= 80)
        //if (randomNumber > 80 & randomNumber <= 90)
        //if (randomNumber > 90 & randomNumber <= 100)

        [Theory]
        [InlineData(30, "Bowled", "", "Ian Botham")]
        [InlineData(60, "Caught", "Clive Lloyd", "Shane Warne")]
        [InlineData(80, "LBW", "", "Brett Lee")]
        [InlineData(90, "Run Out", "", "Stuart Broad")]
        [InlineData(100, "Stumped", "", "Jimmy Anderson")]

        public void DismissalTest(int randomValue, string howOut, string caughtBy, string bowler)
        {
            Mock<IRandomNumberGenerator> mockRand = new Mock<IRandomNumberGenerator>();
            mockRand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(randomValue);
            Mock<Bowler> mockBowler = new Mock<Bowler>();
            mockBowler.Setup(x => x.Name()).Returns(bowler);

            Mock<Team> mockTeam = new Mock<Team>();
            mockTeam.Setup(x => x.GetPlayer(It.IsAny<int>())).Returns(caughtBy);
            mockTeam.Setup(x => x.NumberPlayers()).Returns(11);

            Dismissal dismissal = new Dismissal(mockBowler.Object, mockTeam.Object, mockRand.Object);

            Assert.Equal(howOut, dismissal._howOut);
            Assert.Equal(caughtBy, dismissal._caughtBy);
            Assert.Equal(bowler, dismissal._bowler);
        }


        [Theory]
        [InlineData(30, "b. Ian Botham", "", "Ian Botham")]
        [InlineData(60, "c. Clive Lloyd b. Shane Warne", "Clive Lloyd", "Shane Warne")]
        [InlineData(80, "lbw b. Brett Lee","", "Brett Lee")]
        [InlineData(90, "Run Out", "", "Stuart Broad")]
        [InlineData(100, "st. b. Jimmy Anderson", "", "Jimmy Anderson")]
        public void TestStringConversion(int randomValue, string expectedValue, string caughtBy, string bowler)
        {
            Mock<IRandomNumberGenerator> mockRand = new Mock<IRandomNumberGenerator>();
            mockRand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(randomValue);
            Mock<Bowler> mockBowler = new Mock<Bowler>();
            mockBowler.Setup(x => x.Name()).Returns(bowler);

            Mock<Team> mockTeam = new Mock<Team>();
            mockTeam.Setup(x => x.GetPlayer(It.IsAny<int>())).Returns(caughtBy );
            mockTeam.Setup(x => x.NumberPlayers()).Returns(11);

            Dismissal dismissal = new Dismissal(mockBowler.Object, mockTeam.Object, mockRand.Object);

            Assert.Equal(expectedValue, dismissal.ToString());
        }
    }
}