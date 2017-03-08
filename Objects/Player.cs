using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Player
    {
        private int _id;
        private string _username;
        private string _password;
        private decimal _money;
        private int _count;

        public Player(string username, string password, int id = 0)
        {
            _id = id;
            _username = username;
            _password = password;
            _money = 20m;
            _count = 0;
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
                bool passwordEquality = this.GetPassword() == newPlayer.GetPassword();
                bool moneyEquality = this.GetMoney() == newPlayer.GetMoney();
                return (idEquality && usernameEquality && passwordEquality);
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
        public string GetPassword()
        {
            return _password;
        }

        public decimal GetMoney()
        {
            return _money;
        }

        public int GetCount()
        {
          return _count;
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
            _count +=1; 
            return newGame;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players (username, password, money) OUTPUT INSERTED.id VALUES (@Username, @Password, @Money);", conn);

            cmd.Parameters.Add(new SqlParameter("@Username", this.GetUsername()));
            cmd.Parameters.Add(new SqlParameter("@Password", this.GetPassword()));
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

            _count = 0;

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
            string password = null;
            decimal money = 0m;

            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                username = rdr.GetString(1);
                password = rdr.GetString(2);
                money = rdr.GetDecimal(3);
            }

            Player foundPlayer = new Player(username, password, id);
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

        public static Player Search(string playerUsername, string playerPassword)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE username = @Username AND password = @Password;", conn);
            cmd.Parameters.Add(new SqlParameter("@Username", playerUsername));
            cmd.Parameters.Add(new SqlParameter("@Password", playerPassword));

            SqlDataReader rdr = cmd.ExecuteReader();

            int id = 0;
            string username = null;
            string password = null;
            decimal money = 0m;

            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                username = rdr.GetString(1);
                password = rdr.GetString(2);
                money = rdr.GetDecimal(3);
            }

            Player searchedPlayer = new Player(username, password, id);
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
                string password = rdr.GetString(2);
                Player newPlayer = new Player(username, password, playerId);
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
