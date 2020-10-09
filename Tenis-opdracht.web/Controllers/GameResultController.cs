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
    public class GameResultController : ControllerBase
    {

        UnitOfWork unitOfWork;

        public GameResultController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<GameResult> index([FromQuery] string includes = "")
        {
            return unitOfWork.GameResultRepository.Get(includeProperties: includes);
        }

        [HttpPost("/create")]
        public GameResult Create(GameResult GameResult)
        {
            unitOfWork.GameResultRepository.Insert(GameResult);
            unitOfWork.Save();
            return GameResult;
        }

        [HttpPut]
        public GameResult Update(GameResult GameResult)
        {
            unitOfWork.GameResultRepository.Update(GameResult);
            unitOfWork.Save();
            return GameResult;
        }

        [HttpGet("{id}")]
        public GameResult GetById(int id)
        {
            return unitOfWork.GameResultRepository.GetByID(id);
        }
    }
}
