using System;
using System.Collections.Generic;

namespace CybersecurityBotPart2.Services
{
    /// <summary>
    /// Remembers information about the user and conversation history
    /// </summary>
    public class ConversationMemory
    {
        public string UserName { get; set; } = "";
        public List<string> UserInterests { get; set; } = new List<string>();
        public List<string> MessageHistory { get; set; } = new List<string>();

        // Remember the last topic discussed
        public string LastTopicDiscussed { get; set; } = "";

        public ConversationMemory()
        {
            UserName = "Friend";
        }

        // Store user's name
        public void SetUserName(string name)
        {
            UserName = name;
            AddToHistory($"User introduced themselves as {name}");
        }

        // Remember what the user is interested in
        public void AddInterest(string topic)
        {
            if (!UserInterests.Contains(topic))
            {
                UserInterests.Add(topic);
                AddToHistory($"User is interested in {topic}");
            }
        }

        // Store conversation
        public void AddToHistory(string message)
        {
            MessageHistory.Add(message);
        }

        // Get personalized greeting
        public string GetPersonalizedGreeting()
        {
            if (UserName != "Friend")
            {
                return $"Hello {UserName}! Welcome back. ";
            }
            return "Hello! ";
        }

        // Check if we know about a user interest and can reference it
        public string GetPersonalizedIntro(string topic)
        {
            if (UserInterests.Contains(topic))
            {
                return $"Since you're interested in {topic}, here's what you should know: ";
            }
            return "";
        }

        // Remember current topic
        public void SetCurrentTopic(string topic)
        {
            LastTopicDiscussed = topic;
        }

        public string GetLastTopic()
        {
            return LastTopicDiscussed;
        }
    }
}