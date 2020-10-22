using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(TenisContext context) : base(context) { }
    }
}
