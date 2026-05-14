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
                // Ensure we are looking in the correct folder for the .wav file
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                if (File.Exists(path))
                {
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.Play(); // Plays the security greeting once
                    }
                }
            }
            catch (Exception)
            {
                // Silent catch ensures the app launches even if the speaker is muted
            }
        }

        public string GetAsciiLogo()
        {
            // Improved 'Cyber' aesthetic for the new WPF UI
            return @"
    _________________________________________
   /                                         \
  |    >> SECURE SA CHATBOT SYSTEM <<         |
  |    STATUS: ENCRYPTED & ACTIVE             |
   \_________________________________________/
            ";
        }
    }
}