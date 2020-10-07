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
    public class RoleController : ControllerBase
    {

        UnitOfWork unitOfWork;

        public RoleController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Role> index([FromQuery] string includes = "")
        {
            return unitOfWork.RoleRepository.Get(includeProperties: includes);
        }

        [HttpPost("/create")]
        public Role Create(Role Role)
        {
            unitOfWork.RoleRepository.Insert(Role);
            unitOfWork.Save();
            return Role;
        }

        [HttpPut]
        public Role Update(Role Role)
        {
            unitOfWork.RoleRepository.Update(Role);
            unitOfWork.Save();
            return Role;
        }

        [HttpGet("{id}")]
        public Role GetById(int id)
        {
            return unitOfWork.RoleRepository.GetByID(id);
        }
    }
}
