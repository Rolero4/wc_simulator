﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using MySql.Data.MySqlClient;
    using WC_Simulator.DAL;
    using WC_Simulator.DAL.Entities;
    class RepositoryUsers
    {
        #region QUERIES
        private const string ALL_USER = "SELECT * FROM `user`";
        private const string ADD_USER = "INSERT INTO `user`(`id_user`, `login`, `password`," +
            " `creation_date`, `last_log_date`, `security_question`, `security_answer`) VALUES ";
        private const string DELETE_USER = "DELETE FROM `user` WHERE id_user = ";
        //private const string UPDATE_USER = "UPDATE `user` SET xx WHERE id_user = ";
        #endregion

        #region CRUD
        public static List<User> LoadUser()
        {
            List<User> user = new List<User>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USER, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    user.Add(new User(reader));
                connection.Close();
            }
            return user;
        }

        public static bool AddUser(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`login`, `password`, `creation_date`, `last_log_date`, `security_question`, `security_answer`) VALUES (@login, @password, @creation_date, @last_log_date, @security_question, @security_answer)", connection);
                connection.Open();
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Login;
                command.Parameters.Add("@password", MySqlDbType.Blob).Value = user.Password;
                command.Parameters.Add("@creation_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@last_log_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@security_question", MySqlDbType.VarChar).Value = user.Security_question;
                command.Parameters.Add("@security_answer", MySqlDbType.Blob).Value = user.Security_answer;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                user.Id_user = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateUser(User user, uint idUser)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("UPDATE User SET password=@password, last_log_date=@last_log_date WHERE id_user=@id_user", connection);
                connection.Open();
                command.Parameters.Add("@id_user", MySqlDbType.UInt64).Value = user.Id_user;
                command.Parameters.Add("@password", MySqlDbType.Blob).Value = user.Password;
                command.Parameters.Add("@last_log_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                user.Id_user = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteUser(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_USER} {user.Id_user}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
