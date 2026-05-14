using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbot
{
    public delegate string MoodAdvisor(string message);

    public partial class ChatbotForm : Form
    {
        private ListBox lstChatHistory = null!;
        private TextBox txtUserInput = null!;
        private Button btnSend = null!;
        private string? userName;
        private Dictionary<string, string> infoSafe = new();
        private List<string> randomTips = new();

        public ChatbotForm()
        {
            InitializeComponent();
            CreateUserInterface();
            LoadBotLogic();
        }

        private void CreateUserInterface()
        {
            MultimediaManager media = new MultimediaManager();

            this.Text = "Cybersecurity Awareness Bot";
            this.Size = new Size(500, 650);
            this.BackColor = Color.FromArgb(30, 30, 30);

            Label lblLogo = new Label();
            lblLogo.Text = media.GetAsciiLogo();
            lblLogo.Font = new Font("Courier New", 9, FontStyle.Bold);
            lblLogo.ForeColor = Color.Cyan;
            lblLogo.Location = new Point(20, 10);
            lblLogo.AutoSize = true;
            this.Controls.Add(lblLogo);

            lstChatHistory = new ListBox();
            lstChatHistory.Location = new Point(20, 100);
            lstChatHistory.Size = new Size(440, 320);
            lstChatHistory.BackColor = Color.Black;
            lstChatHistory.ForeColor = Color.LimeGreen;
            this.Controls.Add(lstChatHistory);

            txtUserInput = new TextBox();
            txtUserInput.Location = new Point(20, 440);
            txtUserInput.Size = new Size(330, 30);
            this.Controls.Add(txtUserInput);

            btnSend = new Button();
            btnSend.Text = "SEND";
            btnSend.Location = new Point(360, 438);
            btnSend.Size = new Size(100, 30);
            btnSend.BackColor = Color.FromArgb(64, 64, 64);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Click += new EventHandler(btnSend_Click);
            this.Controls.Add(btnSend);

            this.AcceptButton = btnSend;

            Button btnClear = new Button();
            btnClear.Text = "CLEAR";
            btnClear.Location = new Point(360, 475);
            btnClear.Size = new Size(100, 30);
            btnClear.BackColor = Color.DarkRed;
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Click += (s, e) => { lstChatHistory.Items.Clear(); };
            this.Controls.Add(btnClear);

            Button btnScenario = new Button();
            btnScenario.Text = "SCENARIO";
            btnScenario.Location = new Point(360, 512);
            btnScenario.Size = new Size(100, 30);
            btnScenario.BackColor = Color.DarkSlateBlue;
            btnScenario.ForeColor = Color.White;
            btnScenario.FlatStyle = FlatStyle.Flat;
            btnScenario.Click += (s, e) => {
                lstChatHistory.Items.Add("BOT: [SCENARIO] You see a 'Win a Free iPhone' popup.");
                lstChatHistory.Items.Add("BOT: Do you click it? (Type 'yes' or 'no')");
            };
            this.Controls.Add(btnScenario);

            lstChatHistory.Items.Add("SYSTEM: Connection established.");
            lstChatHistory.Items.Add("BOT: Please enter your Agent Name to begin.");
        }

        private void LoadBotLogic()
        {
            MultimediaManager media = new MultimediaManager();
            media.PlayVoiceGreeting("greeting.m4a.wav");

            // REQ: Recognize specific topics (image_2e0433.png)
            if (!infoSafe.ContainsKey("scam")) infoSafe.Add("scam", "Always check the URL for misspellings before entering data.");
            if (!infoSafe.ContainsKey("privacy")) infoSafe.Add("privacy", "Two-factor authentication (2FA) is your best friend.");
            if (!infoSafe.ContainsKey("phishing")) infoSafe.Add("phishing", "Suspicious emails asking for login details are usually phishing.");
            if (!infoSafe.ContainsKey("password")) infoSafe.Add("password", "Use a mix of uppercase, symbols, and numbers.");
            if (!infoSafe.ContainsKey("malware")) infoSafe.Add("malware", "Keep your antivirus updated to block malicious software.");

            // Scenario Responses
            if (!infoSafe.ContainsKey("yes")) infoSafe.Add("yes", "WRONG. That was a phishing trap! Never trust popups.");
            if (!infoSafe.ContainsKey("no")) infoSafe.Add("no", "CORRECT. Security awareness starts with skepticism.");

            randomTips.Add("Never share your OTP with anyone.");
            randomTips.Add("Change your passwords every 90 days.");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            if (string.IsNullOrEmpty(userName))
            {
                userName = input;
                lstChatHistory.Items.Add($"BOT: Identity confirmed. Welcome, Agent {userName}.");
                txtUserInput.Clear();
                return;
            }

            lstChatHistory.Items.Add($"{userName.ToUpper()}: {input}");
            string lowerInput = input.ToLower();

            MoodAdvisor advisor = new MoodAdvisor(AnalyzeMood);
            string moodResponse = advisor(lowerInput);
            if (!string.IsNullOrEmpty(moodResponse)) lstChatHistory.Items.Add($"SYSTEM: {moodResponse}");

            // NEW RECOGNITION LOGIC: Loops through dictionary to find any matching keyword in the sentence
            bool topicFound = false;
            foreach (var entry in infoSafe)
            {
                if (lowerInput.Contains(entry.Key))
                {
                    lstChatHistory.Items.Add($"BOT: {entry.Value}");
                    topicFound = true;
                    break;
                }
            }

            if (!topicFound)
            {
                if (lowerInput.Contains("tip"))

                {
                    Random rnd = new Random();
                    lstChatHistory.Items.Add($"BOT TIP: {randomTips[rnd.Next(randomTips.Count)]}");
                }
                else
                {
                    lstChatHistory.Items.Add("BOT: I'm not programmed for that. Ask about 'phishing' or 'passwords'.");
                }
            }

            txtUserInput.Clear();
        }

        private string AnalyzeMood(string msg)
        {
            if (msg.Contains("scared") || msg.Contains("hacked") || msg.Contains("worried"))
                return "Detection: High Stress. Stay calm, Agent.";
            return "";
        }
    }
}