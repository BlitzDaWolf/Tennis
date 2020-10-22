﻿using System;
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
    public class LeagueController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LeagueController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LeagueDTO> index()
        {
            return mapper.Map<IEnumerable<LeagueDTO>>(unitOfWork.LeagueRepository.Get());
        }

        [HttpPost("/create")]
        public League Create(League League)
        {
            unitOfWork.LeagueRepository.Insert(League);
            unitOfWork.Save();
            return League;
        }

        [HttpGet("{id}")]
        public LeagueDTO GetById(int id)
        {
            return mapper.Map<LeagueDTO>(unitOfWork.LeagueRepository.GetByID(id));
        }
    }
}
