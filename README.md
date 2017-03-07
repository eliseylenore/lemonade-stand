# _Lemonade Stand_

#### _Lemonade Stand Game, 03/6/2017_

#### By _**Kaz Matthews, Tammy Dang, Elise St Hilaire**_

## Description

_Lemonade Stand is an educational game that inspires young entrepreneurs to take risks and fundraise. The player has a certain time period to turn a profit and meet their goals. Each day presents the player with new circumstances, including weather and the cost to make a pitcher of lemonade. The player must decide how much lemonade to make and at what price. Lemonade stand simulates a day of sales and returns the cups sold and the profit for the day. At the end of the time period, the program returns whether the player met their goals and how they did in comparison with other players._

## Setup/Installation Requirements

_Create database_
In SQLMD:
* _> CREATE DATABASE lemonade_stand;_
* _> GO_
* _> USE lemonade_stand;_
* _> GO_
* _> CREATE TABLE scores (id INT IDENTITY(1,1), score INT);_
* _> GO_
* _> CREATE TABLE players (id INT IDENTITY(1,1), username VARCHAR(255), password VARCHAR(255), money DECIMAL(9,2));_
* _> GO_
* _> CREATE TABLE players_scores (id INT IDENTITY(1,1), player_id INT, score_id INT);_
* _> GO_

## Game Object Specs

**Generate random temperature.**
* Output = \_temperature = random number between 30-100

**Generate random forecast**  
* Output: \_weather = Cloudy;

**Generate price per pitcher between $0.50 - $3.00.**
* Output: \_pricePerPitcher = 2;

**Make cups per pitcher equal to 10**  
* Output: \_cupsPerPitcher = 10;

**Make Game.Play() method**
* Input: Game.Play(pricePerCup, numberOfPitchers);
* Output: cups sold = 25;

**Save score to database**
* Input: Game.Save();
* Output: add saved score = $30.00 to database;

**Save score to database with username**
* Input: Game.Save(username);
* Output: add saved score and username to database;

**Save score to database with username and password**
* Input: user saves Game
* Output: update saved score to database where username and password = player's username and password



## Known Bugs

_Not that I know of._

## Support and contact details

_Please don't contact us._

## Technologies Used

_I used C# with the Nancy framework and Razor. I used SQL to create the database. I also relied on Bootstrap._

### License

*MIT*

Copyright (c) 2017 **_Tammy Dang, Kaz Matthews, Elise St Hilaire_**
