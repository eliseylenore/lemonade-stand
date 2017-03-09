using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LemonadeStand
{
    public class PlayerTest : IDisposable
    {
        public PlayerTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=lemonade_stand_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_PlayersEmptyAtFirst()
        {
            //Arrange, Act
            int result = Player.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Save_PlayerIntToDatabase_AssignsIdToPlayerReturned()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Player savedPlayer = Player.GetAll()[0];
            // Console.WriteLine(Player.GetAll().Count);

            int expected = testPlayer.GetId();
            int result = savedPlayer.GetId();
            Assert.Equal(testPlayer, savedPlayer);
        }

        [Fact]
        public void Find_FindPlayerById_ReturnsPlayer()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Player foundPlayer = Player.Find(testPlayer.GetId());
            Assert.Equal(testPlayer.GetId(), foundPlayer.GetId());
        }

        [Fact]
        public void Find_FindPlayerByIdReturnsCount_ReturnsCorrectCount()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame1 = testPlayer.AddGame();
            playerGame1.Play(0.6m, 5, testPlayer);
            Game playerGame2 = testPlayer.AddGame();
            playerGame2.Play(0.6m, 5, testPlayer);
            Game playerGame3 = testPlayer.AddGame();
            playerGame3.Play(0.6m, 5, testPlayer);

            Player foundPlayer = Player.Find(testPlayer.GetId());
            Assert.Equal(testPlayer.GetCount(), foundPlayer.GetCount());
        }

        [Fact]
        public void Search_SearchPlayerByUsernameAndPassword_SearchedPlayer()
        {
            Player testPlayer1 = new Player("coolgurl123", "password123");
            testPlayer1.Save();
            Player testPlayer2 = new Player("coolboi123", "password321");
            testPlayer2.Save();

            Player searchedPlayer = Player.Search("coolboi123", "password321");

            Assert.Equal(testPlayer2, searchedPlayer);
        }

        [Fact]
        public void AddGame_Player_AddGameToPlayer()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame = testPlayer.AddGame();

            Player gamePlayer = playerGame.GetPlayer();

            Assert.Equal(gamePlayer, testPlayer);
        }

        [Fact]
        public void SetMoney_Player_SetsMoneyEqualToNewValue()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            testPlayer.SetMoney(19.99m);

            decimal newMoney = testPlayer.GetMoney();

            Assert.Equal(19.99m, newMoney);
        }

        [Fact]
        public void SaveScore_SavesScoreInDatabase_GetScores()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame = testPlayer.AddGame();
            playerGame.Play(0.6m, 5, testPlayer);
            //ExpectedScores needs to be declared and captured before SaveScore method because SaveScore method resets player's money to 20m
            List<decimal> ExpectedScores = new List<decimal>{testPlayer.GetMoney()};

            testPlayer.SaveScore();

            List<decimal> ActualScores = testPlayer.GetScores();

            Assert.Equal(ExpectedScores, ActualScores);
        }

        [Fact]
        public void GetAverageScores_Player_PlayersAverageScore()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame1 = testPlayer.AddGame();
            playerGame1.Play(0.6m, 5, testPlayer);
            decimal game1Score = testPlayer.GetMoney();
            testPlayer.SaveScore();

            Game playerGame2 = testPlayer.AddGame();
            playerGame2.Play(0.6m, 5, testPlayer);
            decimal game2Score = testPlayer.GetMoney();
            testPlayer.SaveScore();

            Game playerGame3 = testPlayer.AddGame();
            playerGame3.Play(0.6m, 5, testPlayer);
            decimal game3Score = testPlayer.GetMoney();
            testPlayer.SaveScore();

            decimal expected = (game3Score + game2Score + game1Score) / 3m;

            Dictionary<string, object> actual = testPlayer.GetAverageScore();
            Assert.Equal(expected, actual["averageScoreDecimal"]);
        }

        [Fact]
        public void AddGame_WhenPlayerPlaysThreeTimes_ReturnCount3()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame1 = testPlayer.AddGame();

            Game playerGame2 = testPlayer.AddGame();

            Game playerGame3 = testPlayer.AddGame();

            Assert.Equal(3, testPlayer.GetCount());
        }

        [Fact]
        public void SaveScore_WhenPlayerPlaysEightTimes_ReturnZero()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            while(testPlayer.GetCount() < 8)
            {
                Game playerGame = testPlayer.AddGame();
            }
            testPlayer.SaveScore();

            Assert.Equal(0, testPlayer.GetCount());
        }

        [Fact]
        public void SaveScore_PlayerMoneyResetTo20_20()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            while(testPlayer.GetCount() < 8)
            {
                Game playerGame = testPlayer.AddGame();
            }
            testPlayer.SaveScore();

            Assert.Equal(20m, testPlayer.GetMoney());
        }


        public void Dispose()
        {
            Player.DeleteAll();
            Game.ClearAll();
        }

    }
}
