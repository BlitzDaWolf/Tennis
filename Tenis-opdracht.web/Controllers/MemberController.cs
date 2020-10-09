using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        UnitOfWork unitOfWork;

        public MemberController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Member> index([FromQuery]string includes = "")
        {
            return unitOfWork.MemberRepository.Get(includeProperties: includes);
        }

        [HttpPost("/create")]
        public Member Create(Member member)
        {
            unitOfWork.MemberRepository.Insert(member);
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
