﻿using System.Data.SqlClient;

namespace Swim.Infrastructure
{
    public class DatabaseConnection
    {
        private readonly string connectionString = @"Server=LAPTOP-16N38ULV\SQLEXPRESS;Database=MPP
            ;Integrated Security=true;TrustServerCertificate=true";

        private SqlConnection? connection;

        DatabaseConnection() { }
        private static readonly object _lock = new();  
        private static DatabaseConnection? instance = null;
        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new DatabaseConnection();
                        }
                        return instance;
                    }
            }
        }


        public void Open()
        {
            if (connection == null)
                return;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public SqlConnection? Get()
        {
            return connection;
        }
    }
}