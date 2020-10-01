using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis_opdracht.BAL;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data;

namespace Tenis_opdracht.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ValuesController(TenisContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public ActionResult<object> Index()
        {
            var games = unitOfWork.MemberRepository.Get(includeProperties: "*").ToList();
            return (games);
        }
    }
}
