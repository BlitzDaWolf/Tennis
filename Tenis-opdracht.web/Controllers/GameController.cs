using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        UnitOfWork unitOfWork;

        public GameController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Game> index([FromQuery] string includes = "")
        {
            return unitOfWork.GameRepository.Get(includeProperties: includes);
        }

        [HttpPost("/create")]
        public Game Create(Game Game)
        {
            unitOfWork.GameRepository.Insert(Game);
            unitOfWork.Save();
            return Game;
        }

        [HttpPut]
        public Game Update(Game Game)
        {
            unitOfWork.GameRepository.Update(Game);
            unitOfWork.Save();
            return Game;
        }

        [HttpGet("{id}")]
        public Game GetById(int id)
        {
            return unitOfWork.GameRepository.GetByID(id);
        }
    }
}
