﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using SwapNShopApplication.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SwapNShopApplication.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class MusicianController : Controller
    {
        private SwapNShopDbContext _context;

        public MusicianController(SwapNShopDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<Musician> musicians = from m in _context.Musician
                                             select m;

            return Ok(musicians);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<object> musician = from m in _context.Musician
                                          select new
                                          {
                                              userName = m.userName,
                                              description = m.description,
                                              email = m.email,
                                              rating = m.rating,
                                              city = m.city,
                                              state = m.state,
                                              comments = from cl in _context.CommentList
                                                         join ms in _context.Musician
                                                         on cl.IdMusician equals ms.IdMusician
                                                         join c in _context.Comment
                                                         on cl.IdComment equals c.IdComment
                                                         where cl.IdMusician == id
                                                         select new
                                                         {
                                                             message = c.message,
                                                             date = c.date
                                                         }
                                          };

            return Ok(musician);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}