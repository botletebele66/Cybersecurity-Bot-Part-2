using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotPart2.Data
{
    public static class ResponseLibrary
    {
        // IMPORTANT: Multiple responses for same topic (for random selection)
        private static Dictionary<string, List<string>> Responses =
            new Dictionary<string, List<string>>()
        {
            {
                "PASSWORD",
                new List<string>
                {
                    "🔐 Password Safety Tip: Use strong passwords with uppercase, lowercase, numbers, and symbols. Never reuse passwords!",
                    "🔒 Remember: Make each password unique for each website. A strong password is 12+ characters long.",
                    "⚠️ Avoid using your name or birthday in passwords. Hackers know these personal details!",
                    "💡 Pro tip: Use a password manager like Bitwarden to store passwords securely."
                }
            },
            {
                "PHISHING",
                new List<string>
                {
                    "🎣 Phishing Alert: Never click links from unknown emails. Check the sender's email address carefully!",
                    "⚠️ If an email asks for passwords or bank details, it's probably phishing. Legitimate companies never ask this!",
                    "🔍 Before clicking a link, hover over it to see the real URL. Scammers hide malicious links!",
                    "✅ When in doubt, go directly to the official website instead of clicking email links."
                }
            },
            {
                "PRIVACY",
                new List<string>
                {
                    "🔒 Privacy Tip: Limit what you share on social media. Once posted, it's there forever!",
                    "👁️ Check your privacy settings on Facebook, Instagram, and other platforms regularly.",
                    "⚡ Don't accept friend requests from people you don't know. Scammers create fake profiles!",
                    "📱 Be careful about location sharing. Turn off GPS when you don't need it."
                }
            },
            {
                "MALWARE",
                new List<string>
                {
                    "🦠 Malware Warning: Never download files from untrusted websites or suspicious emails!",
                    "🛡️ Keep your antivirus software updated. Run regular scans on your computer.",
                    "⚠️ Be cautious of 'free' software downloads. They often contain hidden malware!",
                    "🔐 Use Windows Defender or another reputable antivirus. It's your first line of defense."
                }
            },
            {
                "SAFE BROWSING",
                new List<string>
                {
                    "🌐 Check for HTTPS in the URL before entering sensitive information. The 'S' means secure!",
                    "🔒 Avoid public WiFi for banking or shopping. Use a VPN if you must.",
                    "⚡ Look for the lock icon 🔒 in your browser. No lock = not secure!",
                    "🚨 If a website looks wrong or asks for passwords, trust your instinct and leave!"
                }
            },
            {
                "GENERAL",
                new List<string>
                {
                    "I'm here to help with cybersecurity! Ask me about passwords, phishing, privacy, malware, or safe browsing.",
                    "Feel free to ask me about any cybersecurity topic. I want to help you stay safe online!",
                    "What cybersecurity concern do you have today? I'm here to help!"
                }
            }
        };

        // Get a random response for a topic
        public static string GetResponse(string topic)
        {
            topic = topic.ToUpper();

            if (Responses.ContainsKey(topic))
            {
                Random random = new Random();
                List<string> topicResponses = Responses[topic];
                int randomIndex = random.Next(topicResponses.Count);
                return topicResponses[randomIndex];
            }

            return "I'm not sure about that. Can you ask about passwords, phishing, privacy, malware, or safe browsing?";
        }
    }
}