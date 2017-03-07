using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

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
            Console.WriteLine(foundPlayer.GetId());
            Assert.Equal(testPlayer.GetId(), foundPlayer.GetId());
        }

        public void Dispose()
        {
            Player.DeleteAll();
        }

    }
}
