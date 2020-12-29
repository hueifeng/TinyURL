using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using TinyURL.Core.Abstracts;
using TinyURL.Core.Entities;

namespace TinyURL.SqlServer
{
    public class SqlServerStorageProcessor : IDataStorageProcessor
    {
        private readonly string _strConnection;

        public SqlServerStorageProcessor(string strConnection)
        {
            this._strConnection = strConnection;
        }

        public async Task<string> GetUrlByCode(string code)
        {
            string sql =
                $@"select Url
            from UrlDictionary
            where code collate Chinese_PRC_CS_AS = '{code}'";
            using (DbConnection dbConnection = new SqlConnection(_strConnection))
            {
                var rw = await dbConnection.ExecuteScalarAsync<string>(sql);
                return rw;
            }
        }

        public async Task<int> Insert(UrlDictionary urlDictionary)
        {
            string sql = @"INSERT INTO UrlDictionary
                    ([Code]
                ,[Url]
            ,[InsertAt],HashVal)
            VALUES
                (@Code,
                @Url,
                @InsertAt,@HashVal)
            SELECT CAST(SCOPE_IDENTITY() as int)";
            using (DbConnection dbConnection = new SqlConnection(_strConnection))
            {
                var rw = await dbConnection.QuerySingleOrDefaultAsync<int>(sql, urlDictionary);
                return rw;
            }
        }

        public async Task<bool> UpdateCodeById(int id, string code)
        {
            string sql = @"UPDATE UrlDictionary
                           SET [Code] = @Code
                           WHERE id=@id";
            using (DbConnection dbConnection = new SqlConnection(_strConnection))
            {
                var rw = await dbConnection.ExecuteAsync(sql, new { code, id });
                return rw > 0;
            }

        }

        public async Task<bool> IsUnique(string code)
        {
            string sql = @"select count(1) from UrlDictionary where code collate Chinese_PRC_CS_AS=@code";
            using (DbConnection dbConnection = new SqlConnection(_strConnection))
            {
                var rw = await dbConnection.ExecuteScalarAsync<int>(sql, new { code });
                return rw <= 0;
            }
        }

        public async Task<string> GetCodeByHashVal(string hashVal)
        {
            string sql = @"select top 1 code from UrlDictionary 
                        where hashVal=@hashVal and Code is not null ";
            using (DbConnection dbConnection = new SqlConnection(_strConnection))
            {
                var rw = await dbConnection.ExecuteScalarAsync<string>(sql, new { hashVal });
                return rw;
            }

        }
    }
}
