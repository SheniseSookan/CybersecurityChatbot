using System;
using System.Collections.Generic;
using System.IO;                 // Added for path verification
using System.Media;              // Added for stable SoundPlayer audio engine
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Data.Sqlite; // Switched from MySQL to SQLite

namespace CybersecurityChatbot
{
    public partial class ChatbotSentinel : System.Windows.Controls.UserControl
    {
        private bool hasVerifiedName = false;

        // This saves the database as a simple file in your project folder—no passwords needed!
        private string connectionString = "Data Source=ChatbotTasks.db;";

        // TASK 4: Activity Log Tracking List
        private List<string> activityLog = new List<string>();

        // TASK 2: Quiz Engine State Variables
        private bool isQuizActive = false;
        private int currentQuestionIndex = 0;
        private int quizScore = 0;

        private struct QuizQuestion
        {
            public string QuestionText;
            public string[] Options;
            public string CorrectAnswer;
            public string Explanation;
        }

        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

        public ChatbotSentinel()
        {
            InitializeComponent();
            InitializeQuizQuestions();
            LogActivity("System Initialized", "Chatbot UI loaded with SQLite engine.");

            AddMessage("EventEase System", "Welcome to EventEase. Please verify your name to continue.", true);

            // Execute the voice initialization protocol on app bootup
            PlayVoiceGreeting();
        }

        /// <summary>
        /// Locates and executes the voice greeting file tracking safety contexts dynamically.
        /// </summary>
        private void PlayVoiceGreeting()
        {
            try
            {
                // Combines the base execution path folder with your exact file extension signature
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.m4a.wav");

                // Check if the file is physically inside the bin/Debug folder structure
                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.Load(); // Pre-caches audio memory blocks to reduce processing latency
                        player.Play(); // Plays asynchronously on a safe background thread layout
                    }
                }
                else
                {
                    // Fallback debugger logs to track path properties inside Visual Studio
                    System.Diagnostics.Debug.WriteLine("=== VOICE DIAGNOSTICS ALIGNMENT ERROR ===");
                    System.Diagnostics.Debug.WriteLine("Audio asset file 'greeting.m4a.wav' was not detected at: " + audioPath);
                }
            }
            catch (Exception ex)
            {
                // Graceful error trap to protect application runtime frameworks if hardware defaults fail
                System.Diagnostics.Debug.WriteLine("Sound hardware device execution failure: " + ex.Message);
            }
        }

        private void InitializeQuizQuestions()
        {
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "1. What is the primary indicator of a Phishing email defense failure?",
                Options = new string[] { "a) Urgent language requesting verification", "b) The email uses a formal header logo", "c) The email comes from an internal address" },
                CorrectAnswer = "a",
                Explanation = "Phishing attempts heavily rely on urgent language to bypass logical review."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "2. True or False: Public Key Infrastructure (PKI) utilizes asymmetric encryption to establish trust channels.",
                Options = new string[] { "t) True", "f) False" },
                CorrectAnswer = "t",
                Explanation = "PKI uses a public key for encryption and a private key for decryption."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "3. Which biometric mechanism is least vulnerable to credential spoofing?",
                Options = new string[] { "a) High-resolution 2D facial scanning", "b) Deep-tissue finger vein pattern mapping", "c) Standard capacitive fingerprint arrays" },
                CorrectAnswer = "b",
                Explanation = "Finger vein patterns require active blood flow reflection, making them highly secure."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "4. True or False: DNS Poisoning involves intercepting a communication channel live to actively alter ongoing web data streams.",
                Options = new string[] { "t) True", "f) False" },
                CorrectAnswer = "f",
                Explanation = "DNS Poisoning manipulates static cache records. Intercepting live sessions is DNS Hijacking."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "5. When managing Third-Party Security Risks, what provides the strongest contractual assurance matrix?",
                Options = new string[] { "a) A verbal agreement with the provider", "b) Mandatory comprehensive SOC 2 type compliance audits", "c) An updated corporate policy document sheet" },
                CorrectAnswer = "b",
                Explanation = "SOC 2 Type audits provide an independent assessment verifying operational control structures."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "6. True or False: Multi-Factor Authentication (MFA) is completely invulnerable to interception via modern proxy tools.",
                Options = new string[] { "t) True", "f) False" },
                CorrectAnswer = "f",
                Explanation = "Man-in-the-Middle (AiTM) proxy setups can intercept standard tokens even after MFA is input."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "7. What is the safest response when handling an unidentified external thumb drive?",
                Options = new string[] { "a) Connect it to an air-gapped forensic sandbox", "b) Plug it into your main work computer terminal", "c) Format the memory storage block immediately on your machine" },
                CorrectAnswer = "a",
                Explanation = "An isolated sandbox ensures malicious firmware cannot interact with network node segments."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "8. True or False: Using a complex passphrase made of four random dictionary words is stronger than a short word with symbols.",
                Options = new string[] { "t) True", "f) False" },
                CorrectAnswer = "t",
                Explanation = "Longer character strings radically increase absolute cryptographic entropy bounds."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "9. What security principle focuses on limiting account visibility purely to tracking specific job execution boundaries?",
                Options = new string[] { "a) High-Availability Redundancy Mode", "b) The Principle of Least Privilege (PoLP)", "c) Symmetric Encryption Segmentation Mapping" },
                CorrectAnswer = "b",
                Explanation = "PoLP limits execution permissions to the minimal structural thresholds needed."
            });
            quizQuestions.Add(new QuizQuestion
            {
                QuestionText = "10. True or False: HTTPS guarantees that a hosted web domain is fundamentally safe, secure, and entirely free of malicious code scripts.",
                Options = new string[] { "t) True", "f) False" },
                CorrectAnswer = "f",
                Explanation = "HTTPS only establishes an encrypted transport channel. Attackers can deploy certificates on phishing sites."
            });
        }

        private void LogActivity(string actionType, string detail)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            activityLog.Add($"[{timestamp}] {actionType} -> {detail}");
            if (activityLog.Count > 10) activityLog.RemoveAt(0);
        }

        public void AddMessage(string user, string text, bool isBot)
        {
            System.Windows.Controls.Border box = new System.Windows.Controls.Border();
            box.CornerRadius = new System.Windows.CornerRadius(8);
            box.Padding = new System.Windows.Thickness(12);
            box.MaxWidth = 500;
            box.BorderThickness = new System.Windows.Thickness(2);

            if (isBot)
            {
                box.Margin = new System.Windows.Thickness(0, 5, 60, 5);
                box.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                box.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(20, 0, 15));
                box.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 110, 199));
            }
            else
            {
                box.Margin = new System.Windows.Thickness(60, 5, 0, 5);
                box.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                box.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 15, 0));
                box.BorderBrush = System.Windows.Media.Brushes.Orange;
            }

            System.Windows.Controls.StackPanel stack = new System.Windows.Controls.StackPanel();

            System.Windows.Controls.TextBlock nameLabel = new System.Windows.Controls.TextBlock();
            nameLabel.Text = user.ToUpper();
            nameLabel.FontSize = 12;
            nameLabel.FontWeight = System.Windows.FontWeights.ExtraBold;
            nameLabel.FontFamily = new System.Windows.Media.FontFamily("Lucida Handwriting");
            nameLabel.Foreground = isBot ? System.Windows.Media.Brushes.OrangeRed : System.Windows.Media.Brushes.SpringGreen;
            stack.Children.Add(nameLabel);

            System.Windows.Controls.TextBlock messageLabel = new System.Windows.Controls.TextBlock();
            messageLabel.Text = text;
            messageLabel.Foreground = System.Windows.Media.Brushes.White;
            messageLabel.TextWrapping = System.Windows.TextWrapping.Wrap;
            messageLabel.FontSize = 13;
            messageLabel.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            stack.Children.Add(messageLabel);

            box.Child = stack;

            lstChatHistory.Items.Add(box);
            lstChatHistory.ScrollIntoView(box);
        }

        private void btnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserInput.Text))
            {
                string msg = txtUserInput.Text;
                AddMessage("Student_Node", msg, false);
                txtUserInput.Clear();

                if (!hasVerifiedName)
                {
                    AddMessage("EventEase System", "Identity Confirmed: " + msg + ". Name verified. Accessing security modules...\n\n[TASK ASSISTANT ENABLED]\nCommands:\n- add task [Title] | [Desc] | [Reminder]\n- show tasks\n- complete task [ID]\n- delete task [ID]\n\n[CYBERSECURITY QUIZ SYSTEM]\n- start quiz\n- view activity log", true);
                    hasVerifiedName = true;
                    LogActivity("User Auth", $"Verified profile identity as: '{msg}'");
                    return;
                }

                if (isQuizActive)
                {
                    HandleQuizInput(msg.ToLower().Trim());
                    return;
                }

                string lowerMsg = msg.ToLower().Trim();

                if (lowerMsg.StartsWith("add task ") || lowerMsg.Contains("remind me to") || lowerMsg.Contains("new task"))
                {
                    string standardizedInput = msg;
                    if (!lowerMsg.StartsWith("add task "))
                    {
                        standardizedInput = "add task " + msg.Replace("remind me to", "").Replace("new task", "").Trim();
                    }
                    HandleAddTask(standardizedInput);
                }
                else if (lowerMsg == "show tasks" || lowerMsg == "view tasks" || lowerMsg.Contains("what are my tasks"))
                {
                    HandleShowTasks();
                }
                else if (lowerMsg.StartsWith("complete task "))
                {
                    HandleUpdateTask(msg, "complete");
                }
                else if (lowerMsg.StartsWith("delete task "))
                {
                    HandleUpdateTask(msg, "delete");
                }
                else if (lowerMsg == "start quiz" || lowerMsg.Contains("play quiz"))
                {
                    StartQuizSession();
                }
                else if (lowerMsg == "view activity log" || lowerMsg == "show activity log")
                {
                    HandleShowActivityLog();
                }
                else if (lowerMsg.Contains("security") || lowerMsg.Contains("biometric"))
                {
                    AddMessage("EventEase System", "Scanning biometric nodes for assignment data...", true);
                    LogActivity("Info Scan", "Triggered coursework scan.");
                }
                else
                {
                    AddMessage("EventEase System", "Inquiry received. Command structure unknown.", true);
                }
            }
        }

        private void StartQuizSession()
        {
            isQuizActive = true;
            currentQuestionIndex = 0;
            quizScore = 0;
            AddMessage("EventEase Matrix Game", "🛡️ CYBERSECURITY CHALLENGE ACTIVATED 🛡️\nRespond with the option letter.\nInitializing Question 1...", true);
            LogActivity("Quiz Mode", "Started quiz.");
            PresentQuizQuestion();
        }

        private void PresentQuizQuestion()
        {
            if (currentQuestionIndex < quizQuestions.Count)
            {
                QuizQuestion q = quizQuestions[currentQuestionIndex];
                string questionDisplay = q.QuestionText + "\n\nOptions:\n";
                foreach (string option in q.Options)
                {
                    questionDisplay += option + "\n";
                }
                AddMessage("ShieldBot Evaluator", questionDisplay, true);
            }
            else
            {
                EndQuizSession();
            }
        }

        private void HandleQuizInput(string input)
        {
            QuizQuestion currentQuestion = quizQuestions[currentQuestionIndex];

            if (input == currentQuestion.CorrectAnswer)
            {
                quizScore++;
                AddMessage("ShieldBot Evaluator", "🟢 CORRECT!\n\n" + currentQuestion.Explanation, true);
                LogActivity("Quiz Progress", $"Q{currentQuestionIndex + 1}: Correct.");
            }
            else
            {
                AddMessage("ShieldBot Evaluator", $"🔴 INCORRECT.\nExpected Option: '{currentQuestion.CorrectAnswer.ToUpper()}'\n\n" + currentQuestion.Explanation, true);
                LogActivity("Quiz Progress", $"Q{currentQuestionIndex + 1}: Incorrect.");
            }

            currentQuestionIndex++;

            if (currentQuestionIndex < quizQuestions.Count)
            {
                PresentQuizQuestion();
            }
            else
            {
                EndQuizSession();
            }
        }

        private void EndQuizSession()
        {
            isQuizActive = false;
            string feedbackHeading = $"🏁 CHALLENGE COMPLETE!\nYour Metric Score: {quizScore} / {quizQuestions.Count}\n\n";
            string technicalVerdict = quizScore >= 8 ? "🏆 Admin certified!" : "🚨 Protocols failed. Retraining recommended.";

            AddMessage("ShieldBot Evaluator", feedbackHeading + technicalVerdict, true);
            LogActivity("Quiz Complete", $"Score: {quizScore}/{quizQuestions.Count}");
        }

        private void HandleShowActivityLog()
        {
            string output = "📊 SYSTEM UTILITY ACTIVITY LOG:\n";
            for (int i = 0; i < activityLog.Count; i++)
            {
                output += $"\n{i + 1}. {activityLog[i]}";
            }
            AddMessage("EventEase System", output, true);
        }

        // --- TASK 1 DATABASE OPERATION HANDLERS (SQLITE ENGINE) ---
        private void HandleAddTask(string rawInput)
        {
            try
            {
                string[] parts = rawInput.Substring(9).Split('|');
                string title = parts[0].Trim();
                string desc = parts.Length > 1 ? parts[1].Trim() : "No description provided.";
                string reminder = parts.Length > 2 ? parts[2].Trim() : "No reminder set.";

                using (SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();

                    // Automatically builds your table inside the local file instantly
                    using (SqliteCommand setupCmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Tasks (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Description TEXT, Reminder TEXT, IsCompleted INTEGER);", conn))
                    {
                        setupCmd.ExecuteNonQuery();
                    }

                    string query = "INSERT INTO Tasks (Title, Description, Reminder, IsCompleted) VALUES (@t, @d, @r, 0)";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", title);
                        cmd.Parameters.AddWithValue("@d", desc);
                        cmd.Parameters.AddWithValue("@r", reminder);
                        cmd.ExecuteNonQuery();
                    }
                }
                AddMessage("EventEase System", $"🛡️ TASK LOGGED TO SQLITE:\nTitle: {title}\nDesc: {desc}\nTimeframe: {reminder}", true);
                LogActivity("DB Insert", $"Successfully logged task: '{title}'");
            }
            catch (Exception ex)
            {
                AddMessage("EventEase System", "❌ SQLite Error: " + ex.Message, true);
            }
        }

        private void HandleShowTasks()
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();

                    // Safety creation check
                    using (SqliteCommand setupCmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Tasks (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Description TEXT, Reminder TEXT, IsCompleted INTEGER);", conn))
                    {
                        setupCmd.ExecuteNonQuery();
                    }

                    string query = "SELECT Id, Title, Description, Reminder, IsCompleted FROM Tasks";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    using (SqliteDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.HasRows)
                        {
                            AddMessage("EventEase System", "🗄️ Task matrix is empty.", true);
                            return;
                        }

                        string output = "📋 CURRENT SECURITY TASKS:\n";
                        while (r.Read())
                        {
                            bool isComp = r.GetInt32(4) == 1;
                            string status = isComp ? "✅ [COMPLETED]" : "⚠️ [PENDING]";
                            output += $"\n[ID: {r.GetInt32(0)}] {r.GetString(1)} - {status}\n   Info: {r.GetString(2)}\n   Remind: {r.GetString(3)}\n-------------------";
                        }
                        AddMessage("EventEase System", output, true);
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage("EventEase System", "❌ SQLite Error: " + ex.Message, true);
            }
        }

        private void HandleUpdateTask(string rawInput, string action)
        {
            try
            {
                string idText = rawInput.Replace("complete task ", "").Replace("delete task ", "").Trim();
                if (!int.TryParse(idText, out int taskId))
                {
                    AddMessage("EventEase System", "❌ Invalid Task ID format.", true);
                    return;
                }

                using (SqliteConnection conn = new SqliteConnection(connectionString))
                {
                    conn.Open();

                    string query = action == "complete" ? "UPDATE Tasks SET IsCompleted = 1 WHERE Id = @id" : "DELETE FROM Tasks WHERE Id = @id";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            AddMessage("EventEase System", $"{(action == "complete" ? "✅" : "🗑️")} Task [ID: {taskId}] synchronized in database file.", true);
                            LogActivity(action == "complete" ? "DB Update" : "DB Delete", $"Modified task element ID {taskId}.");
                        }
                        else
                        {
                            AddMessage("EventEase System", $"⚠️ No active entry found matching ID: {taskId}", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage("EventEase System", "❌ SQLite Error: " + ex.Message, true);
            }
        }
    }
}