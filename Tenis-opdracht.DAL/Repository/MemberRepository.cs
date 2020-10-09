using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.DAL.Interface;
using Tenis_opdracht.Data;

namespace Tenis_opdracht.DAL.Repository
{
    public class MemberRepository : GenericRepository<Member>
    {
        public MemberRepository(TenisContext context) : base(context) { }
    }
}
