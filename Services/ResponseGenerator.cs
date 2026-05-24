using System;
using CybersecurityBotPart2.Data;
using CybersecurityBotPart2.Services;

namespace CybersecurityBotPart2.Services
{
    /// <summary>
    /// Creates the chatbot's response to user messages
    /// </summary>
    public class ResponseGenerator
    {
        private ConversationMemory memory;

        public ResponseGenerator(ConversationMemory userMemory)
        {
            memory = userMemory;
        }

        // Main method: takes user message and returns bot response
        public string GenerateResponse(string userMessage)
        {
            // Handle empty input
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type something so I can help!";
            }

            // Check if asking for user's name
            if (IsAskingForName(userMessage))
            {
                return "I didn't catch your name! What's your name?";
            }

            // Identify the topic
            string topic = KeywordEngine.IdentifyTopic(userMessage);

            // Remember what topic we're discussing
            memory.SetCurrentTopic(topic);

            // If topic is PASSWORD, PHISHING, etc., remember it as interest
            if (topic != "GENERAL")
            {
                memory.AddInterest(topic);
            }

            // Check if user is asking for more of same topic
            if (KeywordEngine.IsRequestingContinuation(userMessage) &&
                memory.GetLastTopic() != "")
            {
                topic = memory.GetLastTopic();
            }

            // Get response
            string baseResponse = ResponseLibrary.GetResponse(topic);

            // Personalize with user's interests
            string personalized = memory.GetPersonalizedIntro(topic) + baseResponse;

            // Adjust for sentiment
            string finalResponse = SentimentAnalyzer.AnalyzeAndAdjust(userMessage, personalized);

            return finalResponse;
        }

        private bool IsAskingForName(string message)
        {
            string lower = message.ToLower();
            return lower.Contains("name") && lower.Contains("your");
        }
    }
}