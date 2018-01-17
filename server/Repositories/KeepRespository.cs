using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr.Repositories
{
    public class KeepRepository : DbContext
    {
        public KeepRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>($"SELECT * FROM keeps");
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = {id}");
        }

        public IEnumerable<Keep> GetByUser(int userid)
        {
            return _db.Query<Keep>($"SELECT * FROM keeps WHERE userid = {userid}");
        }

        public Keep Add(Keep keep)
        {
            
            int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (Name, Description, Image, Shares, UserId)
            VALUES (@Name, @Description, @Image, @Shares, @UserId);
            SELECT LAST_INSERT_ID()", new
            {
                keep.Name,
                keep.Description,
                keep.Image,
                keep.Shares,
                keep.Views,
                keep.UserId
            });
            keep.Id = id;
            return keep;
        }

        public Keep GetOneByIdAndUpdate(int id, Keep keep)
        {
            return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE keeps SET
                    Name = @Name,
                    Description = @Description,
                    Image = @Image,
                    Shares = @Shares,
                    Views = @Views,
                    UserId = @UserId
                WHERE Id = {id};
                SELECT * FROM keeps WHERE id = {id};", keep);
        }

        public string RemoveById(int id)
        {
            var success = _db.Execute($"DELETE FROM keeps WHERE id = {id}");
            return success > 0 ? "success" : "failed";
        }
    }
}