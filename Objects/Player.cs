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

        public Player(string username, string password, int id = 0)
        {
            _id = id;
            _username = username;
            _password = password;
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

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players (username, password) OUTPUT INSERTED.id VALUES (@Username, @Password);", conn);

            cmd.Parameters.Add(new SqlParameter("@Username", this.GetUsername()));
            cmd.Parameters.Add(new SqlParameter("@Password", this.GetPassword()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            Console.WriteLine(this.GetId());

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
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
