/* Project Step 5 - David C. Perez - 08022020
-------------------------------------------------------------------------------------
This database is to serve as the database for my application, I'm Hungry. As more
entities are identified, this database will be adjust.
This is step 5 to my web application project with the below requirements.
-------------------------------------------------------------------------------------
1. create your database,

2. create your tables (including primary keys and relations consistent with your ERD)

3. populate preliminary data for implementation and test.
===================================================================================*/

USE master;
DROP DATABASE IF EXISTS ImHungryDB;
CREATE DATABASE ImHungryDB;
USE ImHungryDB;

DROP TABLE IF EXISTS RegUser;
CREATE TABLE RegUser(
	UserID INT IDENTITY NOT NULL,
	EmailAddress NVARCHAR (80) NOT NULL,
	UserPassword NVARCHAR (80) NULL,
	FirstName NVARCHAR (40) NULL,
	LastName NVARCHAR (40) NULL,
	SearchRadius INT NOT NULL,

	CONSTRAINT PK_RegUser PRIMARY KEY CLUSTERED
	( UserID )
);


DROP TABLE IF EXISTS RestaurantCategories;
CREATE TABLE RestaurantCategories(
	CategoryID INT IDENTITY NOT NULL,
	CategoryName NVARCHAR (40) NOT NULL,

	CONSTRAINT PK_RestaurantCategories PRIMARY KEY CLUSTERED
	( CategoryID )
);

DROP TABLE IF EXISTS PrefCategories;
CREATE TABLE PrefCategories(
	UserID INT NOT NULL,
	CategoryID INT NOT NULL,

	CONSTRAINT PK_PrefCategories PRIMARY KEY CLUSTERED
	(
		UserID,
		CategoryID
	),

	CONSTRAINT FK_PrefCategories_User FOREIGN KEY
	( UserID )
		REFERENCES dbo.RegUser
		( UserID ),

	CONSTRAINT FK_PrefCategories_Categories FOREIGN KEY
	( CategoryID ) 
		REFERENCES dbo.RestaurantCategories
		( CategoryID )
);

DROP TABLE IF EXISTS Restaurants;
CREATE TABLE Restaurants(
	RestID INT IDENTITY NOT NULL,
	CategoryID INT NOT NULL,
	RestName NVARCHAR (80) NULL,
	RestAddress NVARCHAR (60) NULL,
	RestCity NVARCHAR (20) NULL,
	RestZipcode INT NULL,
	RestCountry NVARCHAR (15) NULL,
	RestPhone NVARCHAR (24) NULL,
	
	CONSTRAINT PK_Restaurants PRIMARY KEY CLUSTERED
	( 
		RestID
	),
	
	CONSTRAINT FK_Restaurants_Categories FOREIGN KEY
	( CategoryID ) 
		REFERENCES dbo.RestaurantCategories
		( CategoryID )
);

DROP TABLE IF EXISTS VisitedRestaurant;
CREATE TABLE VisitedRestaurant(
	UserID INT NOT NULL,
	RestID INT NOT NULL,
	UserLiked BIT NOT NULL,

	CONSTRAINT PK_VisitedRestaurant PRIMARY KEY CLUSTERED
	( 
		UserID,
		RestID
	),

	CONSTRAINT FK_VisitedRestaurant_Users FOREIGN KEY
	( UserID )
		REFERENCES dbo.RegUser
		( UserID ),

	CONSTRAINT FK_VisitedRestaurant_Restaurants FOREIGN KEY
	( RestID ) 
		REFERENCES dbo.Restaurants
		( RestID )
);

INSERT RegUser (EmailAddress, FirstName, LastName, SearchRadius)
VALUES
	('david@werehungry.com', 'David', 'Perez', 5),
	('hilda@werehungry.com', 'Hilda', 'Perez', 10),
	('michael@werehungry.com', 'Michael', 'Lewis', 15),
	('travis@werehungry.com', 'Travis', 'Ortiz', 5),
	('brian@werehungry.com', 'Brian', 'Smith', 10),
	('jayme@werehungry.com', 'Jayme', 'Wright', 15);

INSERT RestaurantCategories (CategoryName)
VALUES
	( 'Afghan' ),
	( 'African' ),
	( 'Senegalese' ),
	( 'South African' ),
	( 'American (New)' ),
	( 'American (Traditional)' ),
	( 'Arabian' ),
	( 'Argentine' ),
	( 'Armenian' ),
	( 'Asian Fusion' ),
	( 'Australian' ),
	( 'Austrian' ),
	( 'Bangladeshi' ),
	( 'Barbeque' ),
	( 'Basque' ),
	( 'Belgian' ),
	( 'Brasseries' ),
	( 'Brazilian' ),
	( 'Breakfast & Brunch' ),
	( 'Pancakes' ),
	( 'British' ),
	( 'Buffets' ),
	( 'Bulgarian' ),
	( 'Burgers' ),
	( 'Burmese' ),
	( 'Cafes' ),
	( 'Themed Cafes' ),
	( 'Cafeteria' ),
	( 'Cajun/Creole' ),
	( 'Cambodian' ),
	( 'Caribbean' ),
	( 'Dominican' ),
	( 'Haitian' ),
	( 'Puerto Rican' ),
	( 'Trinidadian' ),
	( 'Catalan' ),
	( 'Cheesesteaks' ),
	( 'Chicken Shop' ),
	( 'Chicken Wings' ),
	( 'Chinese' ),
	( 'Cantonese' ),
	( 'Dim Sum' ),
	( 'Hainan' ),
	( 'Shanghainese' ),
	( 'Szechuan' ),
	( 'Comfort Food' ),
	( 'Creperies' ),
	( 'Cuban' ),
	( 'Czech' ),
	( 'Delis' ),
	( 'Diners' ),
	( 'Dinner Theater' ),
	( 'Eritrean' ),
	( 'Ethiopian' ),
	( 'Fast Food' ),
	( 'Filipino' ),
	( 'Fish & Chips' ),
	( 'Fondue' ),
	( 'Food Court' ),
	( 'Food Stands' ),
	( 'French' ),
	( 'Mauritius' ),
	( 'Reunion' ),
	( 'Game Meat' ),
	( 'Gastropubs' ),
	( 'Georgian' ),
	( 'German' ),
	( 'Gluten-Free' ),
	( 'Greek' ),
	( 'Guamanian' ),
	( 'Halal' ),
	( 'Hawaiian' ),
	( 'Himalayan/Nepalese' ),
	( 'Honduran' ),
	( 'Hong Kong Style Cafe' ),
	( 'Hot Dogs' ),
	( 'Hot Pot' ),
	( 'Hungarian' ),
	( 'Iberian' ),
	( 'Indian' ),
	( 'Indonesian' ),
	( 'Irish' ),
	( 'Italian' ),
	( 'Calabrian' ),
	( 'Sardinian' ),
	( 'Sicilian' ),
	( 'Tuscan' ),
	( 'Japanese' ),
	( 'Conveyor Belt Sushi' ),
	( 'Izakaya' ),
	( 'Japanese Curry' ),
	( 'Ramen' ),
	( 'Teppanyaki' ),
	( 'Kebab' ),
	( 'Korean' ),
	( 'Kosher' ),
	( 'Laotian' ),
	( 'Latin American' ),
	( 'Colombian' ),
	( 'Salvadoran' ),
	( 'Venezuelan' ),
	( 'Live/Raw Food' ),
	( 'Malaysian' ),
	( 'Mediterranean' ),
	( 'Falafel' ),
	( 'Mexican' ),
	( 'Tacos' ),
	( 'Middle Eastern' ),
	( 'Egyptian' ),
	( 'Lebanese' ),
	( 'Modern European' ),
	( 'Mongolian' ),
	( 'Moroccan' ),
	( 'New Mexican Cuisine' ),
	( 'Nicaraguan' ),
	( 'Noodles' ),
	( 'Pakistani' ),
	( 'Pan Asia' ),
	( 'Persian/Iranian' ),
	( 'Peruvian' ),
	( 'Pizza' ),
	( 'Polish' ),
	( 'Polynesian' ),
	( 'Pop-Up Restaurants' ),
	( 'Portuguese' ),
	( 'Poutineries' ),
	( 'Russian' ),
	( 'Salad' ),
	( 'Sandwiches' ),
	( 'Scandinavian' ),
	( 'Scottish' ),
	( 'Seafood' ),
	( 'Singaporean' ),
	( 'Slovakian' ),
	( 'Somali' ),
	( 'Soul Food' ),
	( 'Soup' ),
	( 'Southern' ),
	( 'Spanish' ),
	( 'Sri Lankan' ),
	( 'Steakhouses' ),
	( 'Supper Clubs' ),
	( 'Sushi Bars' ),
	( 'Syrian' ),
	( 'Taiwanese' ),
	( 'Tapas Bars' ),
	( 'Tapas/Small Plates' ),
	( 'Tex-Mex' ),
	( 'Thai' ),
	( 'Turkish' ),
	( 'Ukrainian' ),
	( 'Uzbek' ),
	( 'Vegan' ),
	( 'Vegetarian' ),
	( 'Vietnamese' ),
	( 'Waffles' ),
	( 'Wraps' );

INSERT PrefCategories (UserID, CategoryID)
VALUES
	(1, 21),
	(1, 46),
	(1, 98),
	(1, 16),
	(1, 120),
	(2, 63),
	(2, 45),
	(2, 61),
	(2, 91),
	(2, 13),
	(2, 53),
	(3, 121),
	(3, 21),
	(3, 2),
	(3, 34),
	(3, 64),
	(3, 6),
	(4, 104),
	(4, 12),
	(4, 46),
	(4, 43),
	(4, 67),
	(4, 44),
	(5, 42),
	(5, 5),
	(5, 75),
	(5, 74),
	(5, 77),
	(5, 63),
	(6, 11),
	(6, 61),
	(6, 32),
	(6, 49),
	(6, 20),
	(6, 46);

INSERT Restaurants (CategoryID, RestName, RestAddress, RestCity, RestZipcode, RestCountry, RestPhone)
VALUES
(8, 'The Goat & Vine', '41923 2nd St, Ste 103', 'Temecula', '92590', 'USA', '(951) 695-5600'),
(41, 'Small Barn', '28535 Old Town Front St', 'Temecula', '92590', 'USA', '(951) 225-2820'),
(34, '1909', '28656 Old Town Front St', 'Temecula', '92590', 'USA', '(951) 252-1909'),
(13, 'PUBlic House', '41971 Main St', 'Temecula', '92590', 'USA', '(951) 491-1772'),
(11, 'Gourmet Italia', '27499 Ynez Rd', 'Temecula', '92591', 'USA', '(951) 676-9194');


SELECT *
FROM RegUser

SELECT *
FROM RestaurantCategories

SELECT *
FROM PrefCategories

SELECT *
FROM Restaurants
