using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotPart2.Services
{
    public class ResponseGenerator
    {
        private readonly ConversationMemory memory;
        private readonly Dictionary<string, string> keywordResponses;

        public ResponseGenerator(ConversationMemory memory)
        {
            this.memory = memory;
            keywordResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"password", "Use strong, unique passwords and a password manager. Avoid reusing passwords."},
                {"phishing", "Phishing emails try to trick you into giving away personal data. Never click suspicious links."},
                {"ransomware", "Ransomware locks your files until you pay. Keep backups and avoid unknown downloads."},
                {"firewall", "A firewall monitors network traffic and blocks unauthorised access."},
                {"privacy", "Limit what you share online, use privacy settings, and consider a VPN."},
                {"scam", "Online scams include fake shops, lottery wins, and romance scams. Be sceptical of too-good-to-be-true offers."},
                {"malware", "Install antivirus software, keep it updated, and don't download from untrusted sources."}
            };
        }

        public string GenerateResponse(string userMessage)
        {
            memory.AddToHistory($"User: {userMessage}");

            // Check for keyword matches
            foreach (var kvp in keywordResponses)
            {
                if (userMessage.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
                {
                    memory.SetCurrentTopic(kvp.Key);
                    string intro = memory.GetPersonalizedIntro(kvp.Key);
                    return intro + kvp.Value;
                }
            }

            // Fallback response
            return "I'm not sure about that. You can ask me about passwords, phishing, ransomware, and more!";
        }
    }
}