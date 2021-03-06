using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr.Repositories
{
    public class VaultRepository : DbContext
    {
        public VaultRepository(IDbConnection db) : base(db)
        {
        }

       

        public Vault GetById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = {id}");
        }

        public IEnumerable<Vault> GetByUser(int userid)
        {
            return _db.Query<Vault>($"SELECT * FROM vaults WHERE userid = {userid}");
        }

        public Vault Add(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (Name, Description, UserId)
            VALUES (@Name, @Description, @UserId); 
            SELECT LAST_INSERT_ID()", new
            {
                vault.Name,
                vault.Description,
                vault.UserId
            });
            vault.Id = id;
            return vault;
        }

        public Vault GetOneByIdAndUpdate(int id, Vault vault)
        {
            return _db.QueryFirstOrDefault<Vault>($@"
                UPDATE vaults SET
                    Name= @Name,
                    Description = @Description,
                    UserId = @UserId
                WHERE Id = {id};
                SELECT * FROM vaults WHERE id = {id};", vault);
        }

        public string RemoveById(int id)
        {
            var success = _db.Execute($"DELETE FROM vaults WHERE id = {id}");
            return success > 0 ? "success" : "failed";
        }
    }
}