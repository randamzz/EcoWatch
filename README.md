
Eco-Watch Tangier

Description:
Eco-Watch Tangier is a web application developed using ASP.NET MVC aimed at combating drought by providing users with essential functionalities to monitor drought conditions, share weather-related information through a blog, connect with other users, receive advice, and notifications.

Functionalities:

1. Drought Status Map:
   - Users can view the status of drought in different regions through an interactive map.

2. Blog:
   - A platform for users to share tips and information related to weather conditions and drought.

3. User Connectivity:
   - Users can create accounts and log in to access personalized features.

4. Advice Page:
   - Dedicated section providing users with advice and recommendations related to combating drought.

5. Notifications:
   - Users receive notifications regarding updates, alerts, or personalized messages.

Database Initialization:

To populate the Cities table in the database, execute the following SQL commands:

INSERT INTO Cities (Name,Lat,Lon) VALUES ('Rabat', 34.020882, -6.841650);
INSERT INTO Cities (Name,Lat,Lon) VALUES ('Casablanca', 33.5731, -7.5898);
INSERT INTO Cities (Name,Lat,Lon) VALUES ('Marrakech', 31.6295, -7.9811);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Oujda', 34.6774, -1.9296);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Fes', 34.0181, -5.0078);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Zagora', 30.3302, -5.8386);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Dakhla', 23.6848, -15.9579);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Laayoune', 27.1537, -13.2033);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Tanger-Medina', 35.7595, -5.8330);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Medina De Rabat', 34.0209, -6.8411);
INSERT INTO Cities (Name, Lat, Lon) VALUES ('Agadir', 30.4220, -9.5595);

## Packages NuGet Utilisés

Voici la liste des packages NuGet utilisés dans ce projet :

- Microsoft.AspNetCore.Mvc
- Microsoft.AspNetCore.Identity
- Microsoft.EntityFrameworkCore
-
Newtonsoft.Json;


Additional Setup:

- Make sure to create a user account for accessing the application.
- Run update-database command to apply migrations and update the database schema.
- Install required NuGet packages for the project.

Authors:

-Nada Ahassad
-Randa El Maazouza
-Mousaab Laachir
-SaifEddin Bouchouikar

GitHub Repository:

Lien github
