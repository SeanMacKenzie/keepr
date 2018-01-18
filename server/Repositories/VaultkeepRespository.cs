using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr.Repositories
{
    public class VaultkeepRepository : DbContext
    {
        public VaultkeepRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<Vaultkeep> GetByVault(int vaultid)
        {
            return _db.Query<Vaultkeep>($"SELECT * FROM vaultkeeps INNER JOIN keeps ON keeps.id = vaultkeeps.keepId WHERE vaultId = {vaultid}");
        }

        public Vaultkeep Add(Vaultkeep vaultkeep)
        {
            int id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
            VALUES (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()", new
            {
                vaultkeep.VaultId,
                vaultkeep.KeepId,
                vaultkeep.UserId
            });
            vaultkeep.Id = id;
            return vaultkeep;
        }

        public Vaultkeep GetOneByIdAndUpdate(int id, Vaultkeep vaultkeep)
        {
            return _db.QueryFirstOrDefault<Vaultkeep>($@"
                UPDATE vaultkeeps SET
                    VaultId = @VaultId,
                    KeepId = @KeepId,
                    UserId = @UserId
                WHERE Id = {id};
                SELECT * FROM vaultkeeps WHERE id ={id};", vaultkeep);
        }

        public string RemoveById(int id)
        {
            var success = _db.Execute($"DELETE FROM vaultkeeps WHERE id = {id}");
            return success > 0 ? "success" : "failed";
        }
    }
}