# Secure SA Cybersecurity Chatbot System

A robust C# application designed to serve as an advanced, secure entry point for cybersecurity diagnostics, user training, and threat intelligence management.

---

## Features

* **Secure Authentication & Biometrics**: Restricted entry system requiring a master passcode alongside an optimized biometric authentication payload parser.
* **SQLite Database Engine**: A locally managed relational database architecture configured to log diagnostic terminal interactions, user queries, and system security alerts.
* **Multimedia Integration**: Automated voice greeting functionality utilizing the `System.Media` library to provide a professional user experience.
* **Custom Security UI**: Detailed custom ASCII system branding, granular color-coded system status alerts, and polished interface boundary layouts.

---

## Code Attribution

The following external libraries, snippets, and tools were utilized in the development of this project:
* **System.Media Namespace**: Used for implementing the automated voice greeting functionality. Provided by the .NET Framework / Microsoft.
* **SQLite Database Provider**: Utilized for structural data persistence and relational log mapping.
* **ASCII Flow / Text-to-ASCII Tools**: Used to generate the "SECURE SA CHATBOT SYSTEM" branding logo for the terminal interface.
* **GitHub Actions (.NET Core CI)**: Automated build and testing workflow configured using the official GitHub Actions marketplace template for Windows-based .NET environments.
* **Microsoft Documentation**: Reference materials were consulted for the implementation of the `Console.ForegroundColor`, `Console.Beep`, and `SoundPlayer` logic.

---

## Requirements

* .NET 8.0 SDK (or later)
* SQLite Connection Libraries (`Microsoft.Data.Sqlite`)
* Audio file: `greeting.m4a.wav` (configured to **'Copy Always'** in output directory properties)

---

## How to Run

1. Open the solution file (`CybersecurityChatbot.sln`) in Visual Studio.
2. Ensure dependencies for SQLite and .NET desktop/console environments are fully restored.
3. Press **F5** to build, compile, and run the system.
4. Enter your system passcode to initialize the database engine and access the terminal interface.

---

## Video Demonstration

You can watch the full walkthrough, build execution, and code architectural demonstration of the Secure SA Chatbot here:
* [▶️ Watch the Demonstration Video on YouTube](https://youtu.be/77DaycPcTS4)

---

## References (Harvard Style)

* Liberty, J. and MacDonald, B. (2009). *Learning C# 3.0*. Sebastopol: O'Reilly Media, Inc.
* Microsoft (2024). *C# documentation*. [online] Available at: https://learn.microsoft.com/en-us/dotnet/csharp/ (Accessed: 31 March 2026).
* Microsoft (2024). *System.Media Namespace*. [online] Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media (Accessed: 31 March 2026).
