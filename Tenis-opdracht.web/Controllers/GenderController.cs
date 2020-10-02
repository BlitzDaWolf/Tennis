using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public GenderController(TenisContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<Gender> Get()
        {
            /*unitOfWork.GenderRepository.Insert(new Gender { Name = "Male" });
            unitOfWork.GenderRepository.Insert(new Gender { Name = "Female" });
            unitOfWork.Save();*/
            return unitOfWork.GenderRepository.Get();
        }
        /*[HttpGet("{id}")]
        public Gender Get(byte id)
        {
            return unitOfWork.GenderRepository.GetByID(id);
        }*/

        [HttpGet("delete")]
        public int delete()
        {
            unitOfWork.GenderRepository.Delete(unitOfWork.GenderRepository.GetByID((byte)1));
            unitOfWork.Save();
            return 0;
        }
    }
}
