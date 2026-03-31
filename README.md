## Code Attribution

The following external libraries, snippets, and tools were utilized in the development of this project:

* **System.Media Namespace:** Used for implementing the automated voice greeting functionality. Provided by the .NET Framework / Microsoft.
* **ASCII Flow / Text-to-ASCII Tools:** Used to generate the "SECURE SA CHATBOT SYSTEM" branding logo for the console interface.
* **GitHub Actions (.NET Core CI):** Automated build workflow configured using the official GitHub Actions marketplace template for Windows-based .NET environments.
* **Microsoft Documentation:** Reference materials were consulted for the implementation of the `Console.ForegroundColor` and `Console.Beep` / `SoundPlayer` logic.

# Secure SA Cybersecurity Chatbot
A C# Console Application designed to provide a secure entry point for cybersecurity information.

## Features
- **Secure Authentication:** Restricted access requiring the "Admin123" passcode.
- **Multimedia Integration:** Automated voice greeting using the System.Media library.
- **Custom UI:** Detailed ASCII branding and color-coded system status alerts.

## Requirements
- .NET 8.0 SDK
- Audio file: `greeting.m4a.wav` (set to 'Copy Always' in properties)

## How to Run
1. Open the solution in Visual Studio 2022.
2. Press F5 to build and run.
3. Enter the passcode Admin123 to access the terminal.

## Video Demonstration

You can watch the full walkthrough and code demonstration of the Secure SA Chatbot here:

[▶️ Watch the Demonstration Video on YouTube](YOUTUBE LINK : https://youtu.be/77DaycPcTS4 )

## References (Harvard Style)

Microsoft (2024). *C# documentation*. [online] Available at: https://learn.microsoft.com/en-us/dotnet/csharp/ (Accessed: 31 March 2026).

Microsoft (2024). *System.Media Namespace*. [online] Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media (Accessed: 31 March 2026).

Liberty, J. and MacDonald, B. (2009). *Learning C# 3.0*. Sebastopol: O'Reilly Media, Inc.
