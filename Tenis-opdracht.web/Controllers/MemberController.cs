using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.DTO.Member;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MemberController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MemberDTO> index()
        {
            IEnumerable<Member> members = unitOfWork.MemberRepository.Get(includeProperties: "Gender,Roles.Role,Games.League,Games.Results");
            return mapper.Map<IEnumerable<MemberDTO>>(members);
        }

        [HttpPost("create")]
        public MemberCreateDTO Create(MemberCreateDTO member)
        {
            unitOfWork.MemberRepository.Insert(mapper.Map<Member>(member));
            unitOfWork.Save();
            return member;
        }

        [HttpPut]
        public UpdateMemberDTO Update(UpdateMemberDTO member)
        {
            unitOfWork.MemberRepository.Update(mapper.Map<Member>(member));
            unitOfWork.Save();
            return member;
        }

        [HttpGet("{id}")]
        public MemberDTO GetById(int id)
        {
            return mapper.Map<MemberDTO>(unitOfWork.MemberRepository.GetByID(id));
        }
    }
}
