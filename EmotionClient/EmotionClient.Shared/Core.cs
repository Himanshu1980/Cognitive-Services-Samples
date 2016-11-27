﻿using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionClient.Shared
{
    public class Core
    {
        private static async Task<Emotion[]> GetHappiness(Stream stream)
        {
            string emotionKey = "[insert-emotion-service-key]";
            EmotionServiceClient emotionClient = new EmotionServiceClient(emotionKey);
            var emotionResults = await emotionClient.RecognizeAsync(stream);
            if (emotionResults == null || emotionResults.Count() == 0)
            {
                throw new Exception("Can't detect face");
            }
            return emotionResults;
        }
        public static async Task<float> GetAverageHappinessScore(Stream stream)
        {
            Emotion[] emotionResults = await GetHappiness(stream);
            float score = 0;
            foreach (var emotionResult in emotionResults)
            {
                score = score + emotionResult.Scores.Happiness;
            }
            return score / emotionResults.Count();
        }

        public static string GetHappinessMessage(float score)
        {
            score = score * 100;
            double result = Math.Round(score, 2);
            if (score >= 50)
                return result + " % :-)";
            else
                return result + "% :-(";
        }
    }
}
