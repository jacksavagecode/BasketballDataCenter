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
git clone https://github.com/jacksavagecode/BasketballDataCenter.git
cd BasketballDataCenter

2️⃣ Setup Database (Manual or EF Core Migrations)
If using migrations:
dotnet ef database update
If manually creating tables, ensure they match the models in the project.

## Data for Database

The following data is required for the database to predict game outcomes and calculate win probabilities. It contains key performance metrics for each NBA team, such as offensive and defensive performance, home and away records, and overall team performance.

| TeamId | TeamName       | OffensiveHomePPG | OffensiveAwayPPG | DefensiveHomePPG | DefensiveAwayPPG | HomeRecord | AwayRecord | TotalRecord | Streak |
|--------|----------------|------------------|------------------|------------------|------------------|------------|------------|-------------|--------|
| 1      | Milwaukee      | 118.7            | 116.8            | 109.9            | 114.2            | 0.722      | 0.556      | 0.639       | 0.6    |
| 2      | Brooklyn       | 117.7            | 117.7            | 110.1            | 115.9            | 0.778      | 0.556      | 0.667       | 0.6    |
| 3      | Utah           | 117.7            | 115.2            | 105.8            | 111.4            | 0.861      | 0.583      | 0.634       | 0.6    |
| 4      | Portland       | 115.3            | 117.5            | 114              | 115.6            | 0.556      | 0.611      | 0.583       | 0.5    |
| 5      | Washington     | 119.3            | 113.5            | 119.2            | 118.4            | 0.528      | 0.417      | 0.472       | 0.4    |
| 6      | Indiana        | 113.7            | 117.7            | 115.6            | 115.8            | 0.361      | 0.583      | 0.472       | 0.4    |
| 7      | Denver         | 117.5            | 112.5            | 112.1            | 110.7            | 0.694      | 0.611      | 0.653       | 0.6    |
| 8      | New Orleans    | 115.1            | 114.1            | 113.7            | 116.1            | 0.5        | 0.361      | 0.431       | 0.4    |
| 9      | Philadelphia   | 117.3            | 110.5            | 108.7            | 107.6            | 0.806      | 0.556      | 0.681       | 0.6    |
| 10     | Phoenix        | 115.7            | 111.9            | 107              | 109.6            | 0.75       | 0.583      | 0.708       | 0.6    |
| 11     | Sacramento     | 115              | 112.5            | 119.4            | 115.4            | 0.444      | 0.417      | 0.431       | 0.4    |
| 12     | LA Clippers    | 115.1            | 111.9            | 108.1            | 107.4            | 0.722      | 0.583      | 0.653       | 0.6    |
| 13     | Golden State   | 116.3            | 110.7            | 111.3            | 113.8            | 0.694      | 0.389      | 0.542       | 0.5    |
| 14     | Memphis        | 109.9            | 116.6            | 110.7            | 114.7            | 0.5        | 0.556      | 0.528       | 0.5    |
| 15     | Boston         | 114.8            | 110.6            | 111.8            | 111.8            | 0.583      | 0.417      | 0.5         | 0.4    |
| 16     | Atlanta        | 113.8            | 110.7            | 108.3            | 112.9            | 0.694      | 0.444      | 0.569       | 0.5    |
| 17     | Minnesota      | 110.2            | 114.1            | 116.4            | 119              | 0.361      | 0.278      | 0.319       | 0.4    |
| 18     | Dallas         | 109.8            | 113.9            | 110.7            | 109.9            | 0.583      | 0.583      | 0.583       | 0.5    |
| 19     | Toronto        | 111.1            | 111.4            | 109.6            | 113.9            | 0.444      | 0.306      | 0.375       | 0.3    |
| 20     | San Antonio    | 110.3            | 111.5            | 113.6            | 111.7            | 0.389      | 0.528      | 0.458       | 0.4    |
| 21     | Chicago        | 109.4            | 111.9            | 111.1            | 112              | 0.417      | 0.444      | 0.431       | 0.4    |
| 22     | Charlotte      | 108.4            | 110.7            | 108.5            | 115.1            | 0.5        | 0.417      | 0.458       | 0.4    |
| 23     | Houston        | 106.6            | 111              | 115.1            | 118.3            | 0.25       | 0.222      | 0.236       | 0.2    |
| 24     | LA Lakers      | 110.4            | 106.6            | 107.3            | 105.6            | 0.583      | 0.583      | 0.583       | 0.6    |
| 25     | Miami          | 108.2            | 106.8            | 109              | 108.2            | 0.583      | 0.528      | 0.556       | 0.5    |
| 26     | Detroit        | 105.1            | 108.1            | 108.1            | 114              | 0.361      | 0.194      | 0.278       | 0.2    |
| 27     | New York       | 108.4            | 104.3            | 104.8            | 104.6            | 0.694      | 0.444      | 0.569       | 0.5    |
| 28     | Okla City      | 105.9            | 104.1            | 118              | 113.3            | 0.278      | 0.333      | 0.306       | 0.3    |
| 29     | Orlando        | 105.4            | 102.6            | 114.4            | 112.2            | 0.306      | 0.278      | 0.292       | 0.3    |
| 30     | Cleveland      | 107.5            | 100.2            | 114.3            | 110.2            | 0.361      | 0.25       | 0.306       | 0.4    |

### Data Fields Description
- `TeamId`: A unique identifier for each NBA team.
- `TeamName`: The name of the NBA team.
- `OffensiveHomePPG`: Points per game scored by the team at home.
- `OffensiveAwayPPG`: Points per game scored by the team away.
- `DefensiveHomePPG`: Points per game conceded by the team at home.
- `DefensiveAwayPPG`: Points per game conceded by the team away.
- `HomeRecord`: Win percentage for the team at home.
- `AwayRecord`: Win percentage for the team away.
- `TotalRecord`: Overall win percentage for the team.
- `Streak`: The current win streak of the team (as a decimal).

Ensure that your database is structured to store these values, and that the appropriate algorithms are set up to process the data for predictions.

This dataset will provide the foundational data needed to make predictions about game outcomes based on team performance.

3️⃣ Run the Application
dotnet run
Visit http://localhost:5000 in your browser.

📂 Project Structure
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
