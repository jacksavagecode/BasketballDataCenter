🏀 Basketball Data Center
📌 Overview
Basketball Data Center is a .NET web application that combines NBA game predictions with a social media aspect. Users can analyze game outcomes, interact with other basketball fans, and personalize their experience.

✨ Features
🔢 NBA Game Prediction Tool
Users select any NBA teams (home & away).
Two algorithms predict:
Each team's points scored.
The home team's win probability (% chance of winning).
Users can set a favourite team, which is stored and displayed every time they log in.
💬 Social Media Integration
Users can create posts, comment, and like content.
Admin functionality for managing social interactions.
🔒 Authentication & User Management
Secure user registration & login.
Users can save preferences and interact with content.
🏗️ Tech Stack
Frontend: Razor Pages / ASP.NET Core MVC
Backend: C#, .NET 8, Entity Framework Core
Database: SQL Server (EF Core for ORM)
Authentication: ASP.NET Identity
Version Control: GitHub
🚀 Getting Started
1️⃣ Clone the Repository
sh
Copy
Edit
git clone https://github.com/jacksavagecode/BasketballDataCenter.git
cd BasketballDataCenter
2️⃣ Setup Database (Manual or EF Core Migrations)
If using migrations:
sh
Copy
Edit
dotnet ef database update
If manually creating tables, ensure they match the models in the project.
3️⃣ Run the Application
sh
Copy
Edit
dotnet run
Visit http://localhost:5000 in your browser.
📂 Project Structure
bash
Copy
Edit
BasketballDataCenter/
│── Controllers/         # Handles requests & logic  
│── Models/              # Database models & entities  
│── ViewModels/          # Data transfer between views & controllers  
│── Views/               # UI Razor views  
│── Data/                # Database context & seed data  
│── Migrations/          # EF Core database migrations  
│── wwwroot/             # Static files (CSS, JS, images)  
│── Program.cs           # App entry point  
│── appsettings.json     # Configuration settings  
🛠️ Future Improvements
Expand prediction algorithms with real-time data.
Add live chat for game discussions.
Implement user dashboards for analytics & stats.
🏀 Contributing
Feel free to fork the repo, submit issues, and contribute!

📄 License
MIT License

