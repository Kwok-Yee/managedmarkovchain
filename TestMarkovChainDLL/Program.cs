using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkovChainDLL;

namespace TestMarkovChainDLL
{
    class Program
    {

        static void Main(string[] args)
        {
            int states = 5;

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

            probabilities[0] = sunnyProbs;
            probabilities[1] = rainingProbs;
            probabilities[2] = windyProbs;
            probabilities[3] = stormingProbs;
            probabilities[4] = snowingProbs;

            MarkovChain markovChain = new MarkovChain();

            Console.WriteLine(markovChain.ValidateProbabilities(states, probabilities));

            Console.ReadLine();
        }
    }
}

