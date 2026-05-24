using System;
using System.Collections.Generic;

namespace CybersecurityBotPart2.Data
{
    public static class KeywordDefinitions
    {
        // List of cybersecurity topics and keywords that trigger them
        public static Dictionary<string, List<string>> TopicKeywords =
            new Dictionary<string, List<string>>()
        {
            {
                "PASSWORD",
                new List<string> { "password", "passwords", "pass", "weak", "strong" }
            },
            {
                "PHISHING",
                new List<string> { "phishing", "phish", "scam", "email", "link", "suspicious" }
            },
            {
                "PRIVACY",
                new List<string> { "privacy", "private", "personal", "data", "information", "share" }
            },
            {
                "MALWARE",
                new List<string> { "malware", "virus", "software", "download", "infected" }
            },
            {
                "SAFE BROWSING",
                new List<string> { "browse", "browsing", "website", "site", "safe" }
            }
        };

        // Get the topic name from keywords
        public static string FindTopic(string userMessage)
        {
            string lowerMessage = userMessage.ToLower();

            foreach (var topic in TopicKeywords)
            {
                foreach (var keyword in topic.Value)
                {
                    if (lowerMessage.Contains(keyword))
                    {
                        return topic.Key;
                    }
                }
            }

            return "GENERAL"; // Default if no keywords found
        }
    }
}
