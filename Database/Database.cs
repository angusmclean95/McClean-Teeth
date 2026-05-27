using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace McClean_Teeth.Database
{
    public class Database
    {
        private static readonly string _connectionString = "server=localhost;user=root;database=mcclean;password=;";

        public int Execute(string sql, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = BuildCommand(connection, sql, parameters))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task<int> ExecuteAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = BuildCommand(conn, sql, parameters))
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public List<Dictionary<string, object>> Query(string sql, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = BuildCommand(conn, sql, parameters))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return ReadRows(reader);
                    }
                }
            }
        }

        public async Task<List<Dictionary<string, object>>> QueryAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = BuildCommand(conn, sql, parameters))
                {
                    using (MySqlDataReader reader =
                        (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        return await ReadRowsAsync(reader);
                    }
                }
            }
        }

        private MySqlCommand BuildCommand(MySqlConnection conn, string sql, Dictionary<string, object> parameters)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            return cmd;
        }

        private List<Dictionary<string, object>> ReadRows(MySqlDataReader reader)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }

                rows.Add(row);
            }

            return rows;
        }

        private async Task<List<Dictionary<string, object>>> ReadRowsAsync(MySqlDataReader reader)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            while (await reader.ReadAsync())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }

                rows.Add(row);
            }

            return rows;
        }
    }
}
