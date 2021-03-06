using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace Repository.Oracle
{
    public class SchemaProvider
    {
        private string ConnectionString = @"Data Source =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCPS)(HOST=testing-oracle-vanessa-main.chj0idpp42cr.eu-west-1.rds.amazonaws.com)(PORT=2484))(CONNECT_DATA=(SERVICE_NAME=ORCL_A)));User Id=DEVVANESSA;Password=mordor";

        private OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public T GetTableInfo<T>(string tableName)
        {
            using (var context = GetConnection())
            {
                try
                {
                    return context.QueryFirst<T>(@"SELECT table_name as Name FROM all_all_tables WHERE table_name = :tableName", new
                    {
                        tableName = tableName
                    });
                }
                catch(Exception e)
                {
                    return default(T);
                }
            }
        }

        public IEnumerable<T> GetColumnsInfo<T>(string tableName)
        {
            using (var context = GetConnection())
            {
                return context.Query<T>(@"SELECT column_name Name, data_type Type FROM all_tab_columns WHERE table_name = :tableName", new
                {
                    tableName = tableName
                });
            }
        }
    }
}
