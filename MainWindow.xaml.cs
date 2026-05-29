<<<<<<< HEAD
﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CybersecurityBotPart2.Services;

namespace CybersecurityBotPart2
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ConversationMemory memory;
        private ResponseGenerator responseGenerator;
        private bool isDarkTheme = false;

        private ObservableCollection<DisplayMessage> messages;
        public ObservableCollection<DisplayMessage> Messages
        {
            get => messages;
            set { messages = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
=======
﻿using CybersecurityBotPart2.Models;
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
>>>>>>> baacc9c79572cc426c659dffd416d8f0b1a595ee

        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
            DataContext = this;
            Messages = new ObservableCollection<DisplayMessage>();

            memory = new ConversationMemory();
            responseGenerator = new ResponseGenerator(memory);

            // Play the greeting sound using the specified absolute file path
            PlayGreetingSound();

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => StatusTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        private void PlayGreetingSound()
        {
            // The exact path to your audio file
            string filePath = @"C:\Users\botsh\OneDrive\Pictures\Cybersecurity-Bot-Part-2\Resources\Greeting AI .wav";

            try
            {
                if (File.Exists(filePath))
                {
                    var player = new System.Media.SoundPlayer(filePath);
                    // Play on a background thread so the UI remains responsive
                    Task.Run(() => player.PlaySync());
                }
                else
                {
                    Debug.WriteLine($"Greeting sound file not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error playing greeting sound: {ex.Message}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddBotMessage("👋 Hello! I'm Cybrog, your Cybersecurity Awareness Bot. What's your name?");
        }

        private async void SendMessage()
        {
            string userMessage = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage)) return;

=======

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
>>>>>>> baacc9c79572cc426c659dffd416d8f0b1a595ee
            AddUserMessage(userMessage);
            UserInput.Clear();
            UserInput.Focus();

<<<<<<< HEAD
            if (memory.UserName == "Friend" && !string.IsNullOrWhiteSpace(userMessage))
            {
                memory.SetUserName(userMessage);
                AddBotMessage($"Nice to meet you, {userMessage}! 😊");
                AddBotMessage("Now, let me help you stay safe online. Ask me about passwords, phishing, ransomware, firewalls, privacy, scams, malware, or safe browsing!");
                UpdateMemoryUI();
                return;
            }

            ShowTypingIndicator(true);
            await Task.Delay(500);

            string botResponse = responseGenerator.GenerateResponse(userMessage);
            AddBotMessage(botResponse);
            ShowTypingIndicator(false);
            UpdateMemoryUI();
            ScrollToBottom();
        }

        private void AddUserMessage(string text)
        {
            Messages.Add(new DisplayMessage
            {
                Text = text,
                Alignment = HorizontalAlignment.Right,
                BackgroundColor = new SolidColorBrush(Color.FromRgb(220, 248, 198))
            });
        }

        private void AddBotMessage(string text)
        {
            Messages.Add(new DisplayMessage
            {
                Text = text,
                Alignment = HorizontalAlignment.Left,
                BackgroundColor = new SolidColorBrush(Color.FromRgb(228, 230, 235))
            });
        }

        private void UpdateMemoryUI()
        {
            if (memory.UserName != "Friend")
            {
                GreetingLabel.Text = $"Hello {memory.UserName}! 👋";
                GreetingLabel.Visibility = Visibility.Visible;
            }
            if (memory.LastTopicDiscussed != "")
            {
                MemoryLabel.Text = $"Last topic: {memory.LastTopicDiscussed}";
                MemoryLabel.Visibility = Visibility.Visible;
            }
        }

        private void ScrollToBottom()
        {
            ChatScrollViewer?.ScrollToBottom();
        }

        private void ShowTypingIndicator(bool show)
        {
            TypingIndicator.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            if (show) _ = AnimateDots();
        }

        private async Task AnimateDots()
        {
            for (int i = 0; i < 3; i++)
            {
                if (TypingIndicator.Visibility != Visibility.Visible) break;
                DotsAnimation.Text = new string('.', i + 1);
                await Task.Delay(400);
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) => SendMessage();
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) SendMessage();
        }

        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string topic)
            {
                string question = topic switch
                {
                    "password" => "Tell me about password safety",
                    "phishing" => "What is phishing and how to avoid it?",
                    "ransomware" => "Explain ransomware and how to protect myself",
                    "firewall" => "What does a firewall do?",
                    "privacy" => "Give me privacy tips",
                    "scam" => "How to recognize online scams?",
                    "malware" => "Tell me about malware protection",
                    _ => "Tell me about cybersecurity"
                };
                UserInput.Text = question;
                SendMessage();
            }
        }

        private void SubmitName_Click(object sender, RoutedEventArgs e)
        {
            string name = UserNameTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(name))
            {
                memory.SetUserName(name);
                AddBotMessage($"Thanks, {name}! Now I can personalize your security tips. 😊");
                UpdateMemoryUI();
                UserNameTextBox.Clear();
            }
        }

        private void CopyMessage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem item && item.Parent is ContextMenu menu &&
                menu.PlacementTarget is Border border && border.DataContext is DisplayMessage message)
            {
                Clipboard.SetText(message.Text);
            }
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            var newCardBg = isDarkTheme ? new SolidColorBrush(Color.FromRgb(45, 45, 45)) : new SolidColorBrush(Color.FromRgb(245, 230, 211));
            var newStatusBg = isDarkTheme ? new SolidColorBrush(Color.FromRgb(20, 20, 20)) : new SolidColorBrush(Color.FromRgb(43, 43, 43));

            var mainGrid = (Grid)this.Content;
            var topBar = (Border)mainGrid.Children[0];
            var middleGrid = (Grid)mainGrid.Children[1];
            var leftBorder = (Border)middleGrid.Children[0];
            var rightBorder = (Border)middleGrid.Children[1];
            var statusBar = (Border)mainGrid.Children[2];

            topBar.Background = newCardBg;
            leftBorder.Background = newCardBg;
            rightBorder.Background = newCardBg;
            statusBar.Background = newStatusBg;

            ThemeToggle.Content = isDarkTheme ? "🌙" : "☀️";
=======
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
>>>>>>> baacc9c79572cc426c659dffd416d8f0b1a595ee
        }
    }

    public class DisplayMessage
    {
        public string Text { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public Brush BackgroundColor { get; set; }
    }
}