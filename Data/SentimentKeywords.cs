using System;
using System.Collections.Generic;

namespace CybersecurityBotPart2.Data
{
    public static class SentimentDefinitions
    {
        // Words that mean the user is worried/scared
        public static List<string> WorriedKeywords = new List<string>
        {
            "worried", "scared", "afraid", "anxious", "nervous",
            "concern", "concerned", "help", "problem", "trouble",
            "lost", "confused", "unsure", "victim", "hacked"
        };

        // Words that mean the user is curious/interested
        public static List<string> CuriousKeywords = new List<string>
        {
            "why", "how", "explain", "tell me", "teach", "learn",
            "interested", "curious", "understand", "know more"
        };

        // Words that mean the user is frustrated/angry
        public static List<string> FrustratedKeywords = new List<string>
        {
            "frustrated", "angry", "annoyed", "mad", "hate",
            "stupid", "useless", "why me", "unfair", "bad"
        };

        // Detect sentiment from user message
        public static string DetectSentiment(string userMessage)
        {
            string lower = userMessage.ToLower();

            // Check worried first (most important to handle gently)
            foreach (var word in WorriedKeywords)
            {
                if (lower.Contains(word))
                    return "WORRIED";
            }

            // Check frustrated
            foreach (var word in FrustratedKeywords)
            {
                if (lower.Contains(word))
                    return "FRUSTRATED";
            }

            // Check curious
            foreach (var word in CuriousKeywords)
            {
                if (lower.Contains(word))
                    return "CURIOUS";
            }

            return "NEUTRAL";
        }
    }
}