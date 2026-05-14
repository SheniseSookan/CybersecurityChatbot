using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace CybersecurityChatbot
{
    public partial class ChatbotSentinel : System.Windows.Controls.UserControl
    {
        private MediaPlayer greetingSound = new MediaPlayer();
        private bool hasVerifiedName = false;
        private string userName = "";
        private string favoriteTopic = "";

        private List<string> phishingTips = new List<string>
        {
            "Tip: Always check the sender's email address for slight misspellings.",
            "Tip: Avoid clicking on links that create a false sense of urgency.",
            "Tip: Hover over links to see the actual destination URL before clicking.",
            "Tip: Never provide sensitive information like passwords via email."
        };

        public ChatbotSentinel()
        {
            InitializeComponent();

            try
            {
                greetingSound.Open(new Uri("greeting.m4a.wav", UriKind.RelativeOrAbsolute));
                greetingSound.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio Error: " + ex.Message);
            }

            // Text now matches your Audio greeting
            AddMessage("CYBER BOT", "Welcome to the SecureSA Chatbot. Please verify your name to continue.", true);
        }

        public void AddMessage(string user, string text, bool isBot)
        {
            Border frame = new Border();
            frame.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 100));
            frame.BorderThickness = new Thickness(2);
            frame.CornerRadius = new CornerRadius(15);
            frame.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(40, 255, 0, 100));
            frame.Padding = new Thickness(20);
            frame.Margin = new Thickness(0, 10, 0, 10);
            frame.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            frame.MaxWidth = 700;
            frame.Effect = new DropShadowEffect { BlurRadius = 15, Color = System.Windows.Media.Color.FromRgb(255, 0, 100), ShadowDepth = 0 };

            StackPanel panel = new StackPanel();
            TextBlock header = new TextBlock { Text = user, Foreground = System.Windows.Media.Brushes.Red, FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(0, 0, 0, 10) };
            panel.Children.Add(header);

            TextBlock content = new TextBlock { Text = text, Foreground = System.Windows.Media.Brushes.White, FontSize = 20, TextWrapping = TextWrapping.Wrap };
            panel.Children.Add(content);

            frame.Child = panel;

            if (lstChatHistory != null)
            {
                lstChatHistory.Items.Add(frame);
                lstChatHistory.ScrollIntoView(frame);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserInput != null && !string.IsNullOrWhiteSpace(txtUserInput.Text))
            {
                string input = txtUserInput.Text.Trim();
                string lowerInput = input.ToLower();
                txtUserInput.Clear();

                AddMessage("USER", input, false);

                if (!hasVerifiedName)
                {
                    if (lowerInput == "shenise")
                    {
                        userName = "Shenise";
                        hasVerifiedName = true;
                        AddMessage("CYBER BOT", $"Identity Confirmed: {userName}. What is your favorite security topic?", true);
                    }
                    else
                    {
                        AddMessage("CYBER BOT", "Access Denied. Please verify with authorized username.", true);
                    }
                }
                else if (string.IsNullOrEmpty(favoriteTopic))
                {
                    favoriteTopic = input;
                    AddMessage("CYBER BOT", $"I'll remember that you like {favoriteTopic}. Ask me about 'passwords' or 'tips'.", true);
                }
                else
                {
                    HandleQuery(lowerInput);
                }
            }
        }

        private void HandleQuery(string query)
        {
            if (query.Contains("worried") || query.Contains("scared") || query.Contains("stress"))
            {
                AddMessage("CYBER BOT", "I sense your concern. Security threats are stressful, but I'm here to help you stay protected.", true);
                return;
            }

            if (query.Contains("password"))
            {
                AddMessage("CYBER BOT", "PASSWORD: Use 12+ characters and symbols. Never reuse passwords.", true);
            }
            else if (query.Contains("scam"))
            {
                AddMessage("CYBER BOT", "SCAMS: Be wary of unsolicited messages asking for financial action.", true);
            }
            else if (query.Contains("privacy"))
            {
                AddMessage("CYBER BOT", "PRIVACY: Review your app permissions regularly.", true);
            }
            else if (query.Contains("tip") || query.Contains("phishing"))
            {
                Random rnd = new Random();
                AddMessage("CYBER BOT", phishingTips[rnd.Next(phishingTips.Count)], true);
            }
            else if (query.Contains("topic") || query.Contains("remember"))
            {
                AddMessage("CYBER BOT", $"Yes {userName}, I remember your favorite topic is {favoriteTopic}.", true);
            }
            else
            {
                AddMessage("CYBER BOT", "I don't recognize that. Try asking about 'passwords' or 'tips'.", true);
            }
        }
    }
}