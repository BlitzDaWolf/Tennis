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

        public GenderController(UnitOfWork context)
        {
            unitOfWork = context;
        }

        [HttpGet]
        public IEnumerable<Gender> Get()
        {
            return unitOfWork.GenderRepository.Get();
        }
    }
}
