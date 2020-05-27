using CricketSimv2;
using System;
using Xunit;
using Moq;

namespace CricketSimv2Tests
{
    // Tests 
    // 58% of balls are dot balls
    // 24% of balls are 1s
    // 7% are 2s
    // 2% are hit for six
    // 7% are fours
    // 1% are threes
    // 3% are dismissals
    // assumed no-balls are 3% 
    // assumed wides are 3%
    // assumed leg-byes 3%
    // assumed byes 3%
    // wides, byes leg-byes require second call to GetRandomNumber 
    // TODO: Need to determine percentages out of 100 and then for second numbers
    // TODO: Need to calculate second random number for how out
    // TODO: Need to call third Random number for caught to get fielder number(index)
    public class testOutcome
    {



        /// <summary>
        /// Test Runs Returned
        /// </summary>
        /// <param name="randomNumber">Random Number to return</param>
        /// <param name="expectedRuns">Expected Value in runs</param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(57, 0)]
        [InlineData(58, 1)]
        [InlineData(81, 1)]
        [InlineData(82, 2)]
        [InlineData(88, 2)]
        [InlineData(89, 3)]
        [InlineData(90, 4)]
        [InlineData(96, 4)]
        [InlineData(97, 6)]
        [InlineData(98, 6)]
        public void test_return_runs_returned(int randomNumber, int expectedRuns)
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(randomNumber);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(expectedRuns, testOutcome.runs);
            Assert.False(testOutcome.noBall);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        /// <summary>
        /// Test Dismissal
        /// </summary>
        [Fact]
        public void test_dismissal()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(100);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.True(testOutcome.wicket);
            Assert.Equal(0, testOutcome.runs);
            Assert.False(testOutcome.noBall);


            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void test_no_ball()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(104);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(1, testOutcome.runs);
            Assert.True(testOutcome.noBall);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void test_single_wide()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(108);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(1, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(1, testOutcome.wides);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void test_two_wides()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(109);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(2, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(2, testOutcome.wides);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_three_wides()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(110);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(3, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(3, testOutcome.wides);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_four_wides()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(113);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(4, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(4, testOutcome.wides);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_one_bye()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(118);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(1, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(1, testOutcome.byes);
            Assert.Equal(0, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_two_byes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(120);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(2, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(2, testOutcome.byes);
            Assert.Equal(0, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_three_byes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(121);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(3, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(3, testOutcome.byes);
            Assert.Equal(0, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void test_four_byes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(125);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(4, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(4, testOutcome.byes);
            Assert.Equal(0, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void test_one_legbyes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(127);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(1, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(0, testOutcome.byes);
            Assert.Equal(1, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Fact]
        public void test_two_legbyes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(128);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(2, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(0, testOutcome.byes);
            Assert.Equal(2, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Fact]
        public void test_three_legbyes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(129);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert.False(testOutcome.wicket);
            Assert.Equal(3, testOutcome.runs);
            Assert.False(testOutcome.noBall);
            Assert.Equal(0, testOutcome.wides);
            Assert.Equal(0, testOutcome.byes);
            Assert.Equal(3, testOutcome.legByes);

            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void test_four_legbyes()
        {
            Mock<IRandomNumberGenerator> rand = new Mock<IRandomNumberGenerator>();
            rand.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(133);
            Outcome testOutcome = new Outcome(rand.Object);
            Assert_Score(testOutcome,
                          runs: 4,
                          wicket: false,
                          noBall: false,
                          wides: 0,
                          byes: 0,
                          legByes: 4 );
            rand.Verify(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Assert Helper Function to check score status
        /// </summary>
        void Assert_Score(Outcome actualOutcome, bool wicket, int runs, bool noBall, int wides, int byes, int legByes)
        {
            if (wicket)
            {
                Assert.True(actualOutcome.wicket);
            }
            else
            {
                Assert.False(actualOutcome.wicket);
            }

            Assert.Equal(runs, actualOutcome.runs);
            if (noBall)
            {
                Assert.True(actualOutcome.noBall);
            }
            else
            {
                Assert.False(actualOutcome.noBall);
            }

            Assert.Equal(wides, actualOutcome.wides);
            Assert.Equal(byes, actualOutcome.byes);
            Assert.Equal(legByes, actualOutcome.legByes);
        }


    }

}
