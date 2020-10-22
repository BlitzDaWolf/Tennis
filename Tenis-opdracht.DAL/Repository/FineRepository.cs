using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class FineRepository : GenericRepository<Fine>
    {
        public FineRepository(TenisContext context) : base(context) { }
    }
}
