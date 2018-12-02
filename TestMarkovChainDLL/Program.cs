using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MarkovChainDLL;

namespace TestMarkovChainDLL
{
    class Program
    {

        static void Main(string[] args)
        {
            int states = 5;
            int currentState = 0;

            int[][] transitions = new int[states][];
            double[][] probabilities = new double[states][];

            int[] sunnyTrans = new int[] { 0, 1, 2, 3, 4 };
            int[] rainingTrans = new int[] { 1, 0, 2, 3, 4 };
            int[] windyTrans = new int[] { 2, 0, 1, 3, 4 };
            int[] stormingTrans = new int[] { 3, 0, 1, 2, 4 };
            int[] snowingTrans = new int[] { 4, 0, 1, 2, 3 };

            double[] sunnyProbs = new double[] { 0.5, 0.2, 0.2, 0.1, 0 };
            double[] rainingProbs = new double[] { 0.3, 0.3, 0.1, 0.1, 0.2 };
            double[] windyProbs = new double[] { 0.3, 0.3, 0.1, 0.1, 0.2 };
            double[] stormingProbs = new double[] { 0.4, 0.1, 0.3, 0.2, 0 };
            double[] snowingProbs = new double[] { 0.5, 0, 0.2, 0.2, 0.1 };

            transitions[0] = sunnyTrans;
            transitions[1] = rainingTrans;
            transitions[2] = windyTrans;
            transitions[3] = stormingTrans;
            transitions[4] = snowingTrans;

            probabilities[0] = sunnyProbs;
            probabilities[1] = rainingProbs;
            probabilities[2] = windyProbs;
            probabilities[3] = stormingProbs;
            probabilities[4] = snowingProbs;

            MarkovChain markovChain = new MarkovChain();

            while (true)
            {
                Thread.Sleep(700);
                currentState = markovChain.CalculateWeatherState(states, transitions, probabilities);
                switch (currentState)
                {
                    case 0:
                        Console.WriteLine("SUNNY");
                        break;
                    case 1:
                        Console.WriteLine("RAINING");
                        break;
                    case 2:
                        Console.WriteLine("WINDY");
                        break;
                    case 3:
                        Console.WriteLine("STORMING");
                        break;
                    case 4:
                        Console.WriteLine("SNOWING");
                        break;
                }
            }
        }
    }
}

