using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class GameResultRepository : GenericRepository<GameResult>
    {
        public GameResultRepository(TenisContext context) : base(context) { }
    }
}
