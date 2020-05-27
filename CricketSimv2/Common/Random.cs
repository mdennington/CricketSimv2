using System;
using System.Collections.Generic;
using System.Text;

namespace CricketSimv2
{
    public interface IRandomNumberGenerator
    {
        int GetRandomNumber(int minNumber, int maxNumber);
    }

    /// <summary>
    /// Random Number Generator Singleton
    /// </summary>
    public class SingleRandom : Random
    {
        static SingleRandom _instance;
        public static SingleRandom Instance
        {
            get
            {
                if (_instance == null) _instance = new SingleRandom();
                return _instance;
            }
        }

        private SingleRandom() { }
    }

    /// <summary>
    /// Return random number between min and max value
    /// </summary>
    public class GetRandomNumber : IRandomNumberGenerator
    {
        int IRandomNumberGenerator.GetRandomNumber(int minNumber, int maxNumber)
        {
            SingleRandom rand = SingleRandom.Instance;
            int ReturnVal = rand.Next(minNumber, maxNumber);
            return ReturnVal;
        }
    }
}
