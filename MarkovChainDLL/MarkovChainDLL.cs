﻿using System;

namespace MarkovChainDLL
{
    public class MarkovChain
    {
        private int transition = 0;
        private int currentState = 0;
        private double diff = 0;
        private bool validated = false;

        // Validating each row for the probabilities to add up to 1 
        private void ValidateProbabilities(int size, double[][] p)
        {
            double total = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    total += p[i][j];
                }
            }
            diff = Math.Abs(total - size);
            if (diff < 0.0000001)
                validated = true;
        }

        // Calculate a random double value
        private double CalculateRandom()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        // Calculate the transtition from one state to another
        private int CalculateTransition(int size, int[][] t, double[][] p, int index)
        {
            double random = CalculateRandom();

            for (int i = 0; i < size; i++)
            {
                random -= p[index][i];
                if (random <= 0)
                    return t[index][i];
            }
            return t[0][0];
        }

        // Calculate the new weather state
        public int CalculateWeatherState(int size, int[][] t, double[][] p)
        {
            if (!validated)
                ValidateProbabilities(size, p);

            transition = CalculateTransition(size, t, p, currentState);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (transition == t[i][j])
                    {
                        currentState = t[i][j];
                        return currentState;
                    }
                }
            }
            return 0;
        }
    }
}
