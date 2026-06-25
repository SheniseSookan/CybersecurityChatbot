/* * ############################################################################
 * CODE ATTRIBUTION
 * ############################################################################
 * TITLE: SECURE SA CYBERSECURITY CHATBOT
 * AUTHOR: Adnan Yusra
 * DATE: 14/05/2026
 * VERSION: SECOND EDITION (OPTIMIZED)
 * * AVAILABLE AT:
 * https://advtechonline.sharepoint.com/:w:/r/sites/TertiaryStudents/_layouts/15/Doc.aspx?sourcedoc=%7B9C23B0F8-6BED-497E-B60C-1D56E59BEDAB%7D&file=PROG6221_MO.docx&action=default&mobileredirect=true
 * ############################################################################
 */

using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace CybersecurityChatbot
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Hosts the WPF ChatbotSentinel user control within a WinForms container.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // FIXED: Added explicit System.Windows.Forms prefix to prevent ambiguous reference conflicts with System.Windows
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("SYSTEM ACCESS REQUIRED.");
            Console.Write("ENTER CODE: ");
            string password = Console.ReadLine() ?? "";

            if (password == "Admin123")
            {
                Form mainContainer = new Form
                {
                    Text = "ShieldBot - Cybersecurity Sentinel",
                    Width = 840, // Expanded slightly to neatly display your 800px XAML framework layout
                    Height = 1050, // Expanded slightly to support your 1000px XAML height and header bounds
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = System.Drawing.Color.Black
                };

                // Initializes the newly optimized cybersecurity user control layer
                var sentinelUI = new ChatbotSentinel();

                ElementHost host = new ElementHost
                {
                    Dock = DockStyle.Fill,
                    Child = sentinelUI
                };

                mainContainer.Controls.Add(host);

                // FIXED: Explicitly qualified Application context execution path to clear compiler flags
                System.Windows.Forms.Application.Run(mainContainer);
            }
        }
    }
}