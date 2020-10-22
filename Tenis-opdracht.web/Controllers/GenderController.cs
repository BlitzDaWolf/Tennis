using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.DTO.Gender;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenderController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<GenderDTO> index()
        {
            var res = unitOfWork.GenderRepository.Get();
            return mapper.Map<List<GenderDTO>>(res);
        }

        [HttpGet("{id}")]
        public GenderDTO GetById(int id)
        {
            return mapper.Map<GenderDTO>(unitOfWork.GenderRepository.GetByID(id));
        }
    }
}
