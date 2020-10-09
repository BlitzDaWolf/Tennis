using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class MemberRepository : GenericRepository<Member>
    {
        public MemberRepository(TenisContext context) : base(context) { }
    }
}
