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
    public class KeepsController : Controller
    {
        private readonly KeepRepository _db;
        public KeepsController(KeepRepository keeprepo)
        {
            _db = keeprepo;
        }

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _db.GetAll();
        }

        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return _db.GetById(id);
        }

        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            return _db.Add(keep);
        }

        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return _db.GetOneByIdAndUpdate(id, keep);
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