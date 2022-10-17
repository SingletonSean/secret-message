using Dapper;
using SecretMessage.WPF.Shared.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.Database
{
    public class SqliteDbInitializer
    {
        private const string CREATE_VIEWED_SECRET_MESSAGES_TABLE_SQL = @"
            CREATE TABLE IF NOT EXISTS ViewedSecretMessages (
                Id TEXT PRIMARY KEY, 
                UserId TEXT,
                Content TEXT,
                DateViewed TEXT
            )";

        private readonly SqliteDbConnectionFactory _sqliteDbConnectionFactory;

        public SqliteDbInitializer(SqliteDbConnectionFactory sqliteDbConnectionFactory)
        {
            _sqliteDbConnectionFactory = sqliteDbConnectionFactory;
        }

        public async Task Initialize()
        {
            using (IDbConnection database = _sqliteDbConnectionFactory.Connect())
            {
                await database.ExecuteAsync(CREATE_VIEWED_SECRET_MESSAGES_TABLE_SQL);
            }
        }
    }
}
