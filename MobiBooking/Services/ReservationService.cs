using AutoMapper;
using MobiBooking.DTO;
using MobiBooking.Exceptions;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System.Collections.Generic;

namespace MobiBooking.Services
{
    public class ReservationService : IDefaultRepository<ReservationDto>
    {
        private readonly IDefaultRepository<Reservation> _repo;
        private readonly IMapper _mapper;

        public ReservationService(IDefaultRepository<Reservation> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            return _mapper.Map<IEnumerable<ReservationDto>>(_repo.GetAll());
        }

        public ReservationDto Get(int id)
        {
            return _mapper.Map<ReservationDto>(_repo.Get(id));
        }

        public int Add(ReservationDto b)
        {
            return _repo.Add(_mapper.Map<Reservation>(b));
        }

        public int Update(int id, ReservationDto b)
        {
            return _repo.Update(id, _mapper.Map<Reservation>(b));
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}