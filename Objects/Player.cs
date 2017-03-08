using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Player
    {
        private int _id;
        private string _username;
        private decimal _money;

        public Player(string username, int id = 0)
        {
            _id = id;
            _username = username;
            _money = 20m;
        }

        public override bool Equals(System.Object otherPlayer)
        {
            if(!(otherPlayer is Player))
            {
                return false;
            }
            else
            {
                Player newPlayer = (Player) otherPlayer;
                bool idEquality = this.GetId() == newPlayer.GetId();
                bool usernameEquality = this.GetUsername() == newPlayer.GetUsername();
                bool moneyEquality = this.GetMoney() == newPlayer.GetMoney();
                return (idEquality && usernameEquality);
            }
        }


        public int GetId()
        {
            return _id;
        }
        public string GetUsername()
        {
            return _username;
        }
        public decimal GetMoney()
        {
            return _money;
        }

        public void SetMoney(decimal money)
        {
            _money = money;
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE players SET money=@Money WHERE id = @PlayerId;", conn);

            cmd.Parameters.Add(new SqlParameter("@PlayerId", this.GetId()));
            cmd.Parameters.Add(new SqlParameter("@Money", money));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public Game AddGame()
        {
            Game newGame = new Game(this._id);
            return newGame;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players (username, money) OUTPUT INSERTED.id VALUES (@Username, @Money);", conn);

            cmd.Parameters.Add(new SqlParameter("@Username", this.GetUsername()));










            //TODO: change value of @Password to hashed code

            cmd.Parameters.Add(new SqlParameter("@Money", this.GetMoney()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void SaveScore()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players_scores (player_id, score) VALUES (@PlayerId, @Score);", conn);

            cmd.Parameters.Add(new SqlParameter("@Score", this._money));
            cmd.Parameters.Add(new SqlParameter("@PlayerId", this.GetId()));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public List<decimal> GetScores()
        {
            List<decimal> AllScores= new List<decimal> {};
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT score FROM players_scores WHERE player_id = @PlayerId;", conn);
            cmd.Parameters.Add(new SqlParameter("@PlayerId", this._id));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                decimal score = rdr.GetDecimal(0);
                AllScores.Add(score);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if (conn != null)
            {
                conn.Close();
            }

            return AllScores;
        }

        public static Player Find(int playerId)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE id = @PlayerId;", conn);
            cmd.Parameters.Add(new SqlParameter("@PlayerId", playerId.ToString()));

            SqlDataReader rdr = cmd.ExecuteReader();

            int id = 0;
            string username = null;
            decimal money = 0m;

            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                username = rdr.GetString(1);
                money = rdr.GetDecimal(3);
            }

            Player foundPlayer = new Player(username, id);
            foundPlayer._money = money;
            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return foundPlayer;
        }

        public static Player Search(string playerUsername)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();







            //Reset @Password to be equal to hashed password
            SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE username = @Username;", conn);
            cmd.Parameters.Add(new SqlParameter("@Username", playerUsername));

            SqlDataReader rdr = cmd.ExecuteReader();

            int id = 0;
            string username = null;
            decimal money = 0m;

            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                username = rdr.GetString(1);
                money = rdr.GetDecimal(3);
            }

            Player searchedPlayer = new Player(username, id);
            searchedPlayer._money = money;
            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return searchedPlayer;
        }

        public static List<Player> GetAll()
        {
            List<Player> allPlayers = new List<Player>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM players", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int playerId = rdr.GetInt32(0);
                string username = rdr.GetString(1);
                Player newPlayer = new Player(username, playerId);
                allPlayers.Add(newPlayer);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allPlayers;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM players;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
