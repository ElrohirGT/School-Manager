using System;
using System.Data.SqlClient;
using System.IO;

namespace Model
{
    public class DBConnection : IDisposable
    {
        private readonly SqlConnection _conn;
        private bool _disposed = false;

        public DBConnection()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SchoolManagerDB.mdf");
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;MultipleActiveResultSets=True";
            _conn = new SqlConnection(connectionString);
            _conn.Open();
        }

        public void Close() => _conn.Close();

        public int Delete(string tableName, string id)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                string query = $"DELETE FROM [{tableName}] WHERE [Id{tableName}]={id}";
                command.CommandText = query;

                return command.ExecuteNonQuery();
            }
        }

        public int Delete(string tableName, string[] fields, object[] values)
        {
            string query = $"DELETE FROM [{tableName}] WHERE ";
            query = AddSeparatedValues(query, fields.Length, (int i) => $"[{fields[i]}]={values[i]}", 0, " AND ");

            using (SqlCommand command = _conn.CreateCommand())
            {
                command.CommandText = query;
                return command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int GetStudentId(string userName)
            => GetId($"SELECT IdEstudiante FROM Estudiante WHERE IdUsuario = (SELECT IdUsuario FROM Usuario u WHERE u.Nombre='{userName}')");

        public int GetTeacherId(string userName)
            => GetId($"SELECT IdProfesor FROM Profesor WHERE IdUsuario = (SELECT IdUsuario FROM Usuario u WHERE u.Nombre='{userName}')");

        /// <summary>
        /// Inserts a record into the database
        /// </summary>
        /// <param name="table">The table name</param>
        /// <param name="fields">The fields of the table to insert to.</param>
        /// <param name="parameters">The SqlParameters to use.</param>
        /// <returns>The id of the inserted record.</returns>
        public int Insert(string table, string[] fields, SqlParameter[] parameters)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                string query = $"INSERT INTO [{table}] (";
                query = AddSeparatedValues(query, fields.Length, (int i) => $"[{fields[i]}]");
                query += $") OUTPUT INSERTED.[Id{table}] VALUES (";
                query = AddSeparatedValues(query, parameters.Length, (int i) => parameters[i].ParameterName);
                query += ");";

                command.Parameters.AddRange(parameters);
                command.CommandText = query;

                return (int)command.ExecuteScalar();
            }
        }

        public int LogIn(string userName, string password)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                command.CommandText = $"SELECT [IdRol] FROM Usuario WHERE Nombre = '{userName}' AND [Contraseña]='{password}'";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return reader.GetInt32(0);
                return -1;
            }
        }

        public void Open() => _conn.Open();

        public SqlDataReader Query(string query)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                command.CommandText = query;

                return command.ExecuteReader();
            }
        }

        public int Update(string table, string[] fields, SqlParameter[] parameters)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                string query = $"UPDATE [{table}] SET ";
                query = AddSeparatedValues(query, fields.Length, (int i) => $"[{fields[i]}]={parameters[i].ParameterName}", startingIndex: 1);
                query += $" WHERE [Id{table}]={parameters[0].ParameterName}";

                command.Parameters.AddRange(parameters);
                command.CommandText = query;

                return command.ExecuteNonQuery();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _conn.Dispose();

            _disposed = true;
        }

        private static string AddSeparatedValues(string str, int finalCount, Func<int, string> valueToAdd, int startingIndex = 0, string separator = ",")
        {
            for (int i = startingIndex; i < finalCount; i++)
            {
                str += valueToAdd(i);
                if (i != finalCount - 1)
                    str += separator;
            }

            return str;
        }

        private int GetId(string query)
        {
            using (SqlCommand command = _conn.CreateCommand())
            {
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }
    }
}