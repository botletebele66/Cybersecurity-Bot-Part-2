using System;
using CybersecurityBotPart2.Data;

namespace CybersecurityBotPart2.Services
{
    /// <summary>
    /// Analyzes user's tone and adjusts responses to be empathetic
    /// </summary>
    public class SentimentAnalyzer
    {
        public static string AnalyzeAndAdjust(string userMessage, string botResponse)
        {
            string sentiment = SentimentDefinitions.DetectSentiment(userMessage);

            switch (sentiment)
            {
                case "WORRIED":
                    // Add reassurance to worried users
                    return $"😊 I understand your concern. {botResponse}";

                case "FRUSTRATED":
                    // Show empathy to frustrated users
                    return $"I hear your frustration. Let me help. {botResponse}";

                case "CURIOUS":
                    // Encourage curious users
                    return $"Great question! Here's what you should know: {botResponse}";

                default:
                    return botResponse;
            }
        }
    }
}