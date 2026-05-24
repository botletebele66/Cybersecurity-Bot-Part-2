using System;

namespace CybersecurityBotPart2.Models
{
    /// <summary>
    /// Represents one message in the chat
    /// </summary>
    public class ChatMessage
    {
        public string Sender { get; set; }  // "User" or "Bot"
        public string Content { get; set; }  // The actual message text
        public DateTime Timestamp { get; set; }

        public ChatMessage(string sender, string content)
        {
            Sender = sender;
            Content = content;
            Timestamp = DateTime.Now;
        }

        // For display in the chat box
        public override string ToString()
        {
            return $"[{Sender}]: {Content}";
        }
    }
}