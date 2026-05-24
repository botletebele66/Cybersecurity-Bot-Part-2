using CybersecurityBotPart2.Models;
using CybersecurityBotPart2.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CybersecurityBotPart2
{
    public partial class MainWindow : Window
    {
        // Create memory, analyzer, and response generator
        private ConversationMemory memory;
        private ResponseGenerator responseGenerator;
        private ObservableCollection<string> chatLog;

        public MainWindow()
        {
            InitializeComponent();

            // Set up the bot's "brain"
            memory = new ConversationMemory();
            responseGenerator = new ResponseGenerator(memory);
            chatLog = new ObservableCollection<string>();
            ChatMessages.ItemsSource = chatLog;

            // Play voice greeting
            try
            {
                System.Media.SoundPlayer player =
                    new System.Media.SoundPlayer("Resources/greeting.wav");
                player.Play();
            }
            catch
            {
                // If WAV file not found, just skip it (don't crash)
            }

            // Welcome message
            AddBotMessage("👋 Hello! I'm the Cybersecurity Awareness Bot. What's your name?");
        }

        // User clicks "Send Message" button
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // When user presses ENTER in text box
        private void UserInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        // Main method: Process user message and get bot response
        private void SendMessage()
        {
            string userMessage = UserInput.Text.Trim();

            // Don't process empty messages
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            // Display user's message
            AddUserMessage(userMessage);
            UserInput.Clear();
            UserInput.Focus();

            // Handle name input (special case)
            if (memory.UserName == "Friend")
            {
                memory.SetUserName(userMessage);
                AddBotMessage($"Nice to meet you, {userMessage}! 😊");
                AddBotMessage("Now, let me help you stay safe online. Ask me about passwords, phishing, privacy, malware, or safe browsing!");
                return;
            }

            // Get bot's response
            string botResponse = responseGenerator.GenerateResponse(userMessage);
            AddBotMessage(botResponse);

            // Auto-scroll to bottom
            var scrollViewer = GetScrollViewer(ChatMessages);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToBottom();
            }
        }

        // Quick buttons for common questions
        private void QuickQuestion_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string topic = button?.Tag?.ToString() ?? "";

            string question = topic switch
            {
                "password" => "Tell me about password safety",
                "phishing" => "Give me a phishing tip",
                "privacy" => "Tell me about privacy",
                "more" => "Tell me another tip",
                _ => "Tell me about cybersecurity"
            };

            UserInput.Text = question;
            SendMessage();
        }

        // Add message to chat display
        private void AddUserMessage(string message)
        {
            chatLog.Add($"👤 You: {message}");
        }

        // Add bot message to chat display
        private void AddBotMessage(string message)
        {
            chatLog.Add($"🤖 Bot: {message}");
        }

        // Helper to find scrollviewer
        private ScrollViewer GetScrollViewer(ItemsControl itemsControl)
        {
            if (VisualTreeHelper.GetChildrenCount(itemsControl) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(itemsControl, 0);
                return (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            }
            return null;
        }
    }
}