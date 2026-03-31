using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize our helper class
            MultimediaManager media = new MultimediaManager();

            // --- STEP 1: SECURITY LOGIN ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=========================================");
            Console.WriteLine("       SECURE SA ACCESS TERMINAL         ");
            Console.WriteLine("=========================================");
            Console.ResetColor();

            Console.Write("\nPLEASE ENTER ACCESS CODE: ");
            string password = Console.ReadLine();

            // --- STEP 2: VERIFICATION LOGIC ---
            if (password == "Admin123")
            {
                // SUCCESS PATH
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">> IDENTITY VERIFIED. WELCOME AGENT.\n");
                Console.ResetColor();

                // RUN MULTIMEDIA
                media.PlayVoiceGreeting("greeting.m4a.wav");
                media.DisplayAsciiLogo();

                Console.WriteLine("\n[SYSTEM] Chatbot initialized and listening...");
            }
            else
            {
                // FAILURE PATH
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] ACCESS DENIED: UNAUTHORIZED USER DETECTED.");
                Console.WriteLine("[!] ALARM TRIGGERED.");
                Console.ResetColor();
            }

            // --- STEP 3: SESSION END ---
            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine("Press any key to close the secure session...");
            Console.ReadKey();
        }
    }
}