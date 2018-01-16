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
    public class VaultsController : Controller
    {
        private readonly VaultRepository _db;
        public VaultsController(VaultRepository vaultrepo)
        {
            _db = vaultrepo;
        }

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return _db.GetAll();
        }

        [HttpGet("{id}")]
        public Vault Get(int id)
        {
            return _db.GetById(id);
        }

        [HttpPost]
        public Vault Post([FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return _db.Add(vault);
            }
            return null;
        }

        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return _db.GetOneByIdAndUpdate(id, vault);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _db.RemoveById(id);
        }
    }
}