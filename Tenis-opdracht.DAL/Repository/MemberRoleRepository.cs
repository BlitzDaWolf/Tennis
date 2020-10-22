using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class MemberRoleRepository : GenericRepository<MemberRole>
    {
        public MemberRoleRepository(TenisContext context) : base(context) { }
    }
}
