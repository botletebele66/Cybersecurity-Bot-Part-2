using System.Collections.Generic;

namespace CybersecurityBotPart2.Data
{
    public static class KeywordDefinitions
    {
        public static Dictionary<string, List<string>> TopicKeywords = new()
        {
            { "PASSWORD", new List<string> { "password", "passwords", "pass", "weak", "strong", "login" } },
            { "PHISHING", new List<string> { "phishing", "phish", "scam", "email", "link", "suspicious", "fake" } },
            { "PRIVACY", new List<string> { "privacy", "private", "personal", "data", "information", "share", "gdpr" } },
            { "MALWARE", new List<string> { "malware", "virus", "software", "download", "infected", "trojan" } },
            { "SAFE BROWSING", new List<string> { "browse", "browsing", "website", "site", "safe", "https" } },
            { "RANSOMWARE", new List<string> { "ransomware", "ransom", "encrypt", "decrypt", "wannacry" } },
            { "FIREWALL", new List<string> { "firewall", "fire wall", "network security", "inbound", "outbound" } },
            { "SCAM", new List<string> { "scam", "fraud", "con", "trick", "fake", "impersonation" } }
        };

        public static string FindTopic(string userMessage)
        {
            string lower = userMessage.ToLower();
            foreach (var topic in TopicKeywords)
                foreach (var keyword in topic.Value)
                    if (lower.Contains(keyword))
                        return topic.Key;
            return "GENERAL";
        }
    }
}