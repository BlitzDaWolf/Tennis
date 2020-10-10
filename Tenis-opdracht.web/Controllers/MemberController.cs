using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.Data.Model.DTO.Member;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        UnitOfWork unitOfWork;
        IMapper mapper;

        public MemberController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MemberDTO> index()
        {
            var members = unitOfWork.MemberRepository.Get(includeProperties: "Gender");
            return mapper.Map<IEnumerable<MemberDTO>>(members);
        }

        [HttpPost("/create")]
        public MemberCreateDTO Create(MemberCreateDTO member)
        {
            unitOfWork.MemberRepository.Insert(mapper.Map<Member>(member));
            unitOfWork.Save();
            return member;
        }

        [HttpPut]
        public Member Update(Member member)
        {
            unitOfWork.MemberRepository.Update(member);
            unitOfWork.Save();
            return member;
        }

        [HttpGet("{id}")]
        public Member GetById(int id)
        {
            return unitOfWork.MemberRepository.GetByID(id);
        }
    }
}
