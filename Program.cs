using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace CybersecurityChatbot
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("SYSTEM ACCESS REQUIRED.");
            Console.Write("ENTER CODE: ");
            string password = Console.ReadLine() ?? "";

            if (password == "Admin123")
            {
                Form mainContainer = new Form
                {
                    Text = "ShieldBot - Cybersecurity Sentinel",
                    Width = 550, // Matches my XAML Width
                    Height = 780, // Extra space for my title bar
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = System.Drawing.Color.Black
                };

                // CRITICAL: It is Pointing to the new Class name
                var sentinelUI = new ChatbotSentinel();
                sentinelUI.InitializeComponent();

                ElementHost host = new ElementHost
                {
                    Dock = DockStyle.Fill,
                    Child = sentinelUI
                };

                mainContainer.Controls.Add(host);
                Application.Run(mainContainer);
                // Task 5: Handling data persistence for my favorite topics
            }


        }
    }
}