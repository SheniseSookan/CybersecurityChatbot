/* <!--CODE ATTRIBUTION-->

<!--TITLE: (SECURE SA CYBERSECURITY CHATBOT)-->

<!--AUTHOR: ( Adnan Yusra )-->

<!--DATE: ( 31/03/2026 )-->

<!--VERSION: (FIREST EDITION) -->

<!--AVAILABLE: (https://advtechonline.sharepoint.com/:w:/r/sites/TertiaryStudents/_layouts/15/Doc.aspx?sourcedoc=%7B9C23B0F8-6BED-497E-B60C-1D56E59BEDAB%7D&file=PROG6221_MO.docx&action=default&mobileredirect=true)-->    
*/
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
                    player.Play(); // Triggers the .wav audio greeting for authenticated users
                }
                else
                {
                    // Renders the Secure SA visual branding in the console
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