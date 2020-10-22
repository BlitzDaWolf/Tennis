using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.DTO.Game;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GameResultController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public StatusCodeResult createResult(CreatGameResultDTO result)
        {
            unitOfWork.GameResultRepository.Insert(mapper.Map<GameResult>(result));
            unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public UpdateGameResultDTO Update(UpdateGameResultDTO GameResult)
        {
            unitOfWork.GameResultRepository.Update(mapper.Map<GameResult>(GameResult));
            unitOfWork.Save();
            return GameResult;
        }
    }
}
