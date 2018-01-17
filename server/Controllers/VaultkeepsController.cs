using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultkeepsController : Controller
    {
        private readonly VaultkeepRepository _db;
        public VaultkeepsController(VaultkeepRepository vaultkeeprepo)
        {
            _db = vaultkeeprepo;
        }

        [HttpGet("vault/{vaultid}")]
        public IEnumerable<Vaultkeep> GetByVault(int vaultid)
        {
            return _db.GetByVault(vaultid);
        }

    }
}