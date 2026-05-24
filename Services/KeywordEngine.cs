using System;
using CybersecurityBotPart2.Data;

namespace CybersecurityBotPart2.Services
{
    /// <summary>
    /// Recognizes cybersecurity topics in user messages
    /// </summary>
    public class KeywordEngine
    {
        public static string IdentifyTopic(string userMessage)
        {
            return KeywordDefinitions.FindTopic(userMessage);
        }

        // Check if user is asking to continue last topic
        public static bool IsRequestingContinuation(string userMessage)
        {
            string lower = userMessage.ToLower();

            return lower.Contains("more") ||
                   lower.Contains("another") ||
                   lower.Contains("explain") ||
                   lower.Contains("tell me more") ||
                   lower.Contains("again") ||
                   lower.Contains("continue");
        }
    }
}