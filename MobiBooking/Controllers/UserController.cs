﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using Microsoft.AspNetCore.Authentication;
using MobiBooking.Models.DataManager;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll().OrderBy(c => c.name);
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello get";
        //}

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _repo.GetByID(id);
        }
        

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _repo.Add(user);
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            _repo.Update(user.Id, user);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteByID(id);
        }

    }
}
