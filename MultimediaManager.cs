using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbot
{
    public class MultimediaManager
    {
        public void PlayVoiceGreeting(string fileName)
        {
            try
            {
                // Finds the file in the debug folder where the app runs
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Play(); // Plays the welcome message
                }
                else
                {
                    Console.WriteLine("<< System: Sound file not found at " + path + " >>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }

        public void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************************");
            Console.WriteLine("* SECURE SA CHATBOT SYSTEM              *");
            Console.WriteLine("* STATUS: ACTIVE                        *");
            Console.WriteLine("*****************************************");
            Console.ResetColor();
        }
    }
}