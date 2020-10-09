using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        UnitOfWork unitOfWork;

        public LeagueController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<League> index([FromQuery] string includes = "")
        {
            return unitOfWork.LeagueRepository.Get(includeProperties: includes);
        }

        [HttpPost("/create")]
        public League Create(League League)
        {
            unitOfWork.LeagueRepository.Insert(League);
            unitOfWork.Save();
            return League;
        }

        [HttpPut]
        public League Update(League League)
        {
            unitOfWork.LeagueRepository.Update(League);
            unitOfWork.Save();
            return League;
        }

        [HttpGet("{id}")]
        public League GetById(int id)
        {
            return unitOfWork.LeagueRepository.GetByID(id);
        }
    }
}
