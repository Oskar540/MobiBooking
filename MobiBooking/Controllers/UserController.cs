﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using MobiBooking.Services;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private IDefaultRepository<User> _repo;

        public UserController(IDefaultRepository<User> repo)
        {
            _repo = repo;
        }

        [Authorize(Roles = "Admin")]
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll().OrderBy(c => c.Name);
        }

        // GET: api/User/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public User GetbyId(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public int PostNewUser([FromBody]User user)
        {
            return _repo.Add(user);
        }

        // PUT: api/User/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public int PutUserById(int id, [FromBody]User user)
        {
            return _repo.Update(user.Id, user);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public int DeleteById(int id)
        {
            return _repo.Delete(id);
        }
    }
}