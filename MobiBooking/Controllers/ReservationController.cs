﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.DTO;
using MobiBooking.Models.Repository;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IDefaultRepository<ReservationDto> _repo;

        public ReservationController(IDefaultRepository<ReservationDto> repo)
        {
            _repo = repo;
        }

        // GET: api/Reservation
        [HttpGet]
        public IEnumerable<ReservationDto> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public ReservationDto Get(int id)
        {
            return _repo.Get(id);
        }
        
        // POST: api/Reservation
        [HttpPost]
        public int Post([FromBody]ReservationDto item)
        {
            return _repo.Add(item);
        }
        
        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]ReservationDto item)
        {
            return _repo.Update(id, item);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
