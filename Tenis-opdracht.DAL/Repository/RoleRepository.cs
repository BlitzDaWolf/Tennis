using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(TenisContext context) : base(context) { }

        public override void Insert(Role entity)
        {
            throw new Exception("Could not insert a role");
        }

        public override void Delete(Role entityToDelete)
        {
            throw new Exception("Could not delete a role");
        }

        public override List<Role> FromQuery(string query, params object[] parameters)
        {
            throw new Exception("This function is not avalibel for this type");
        }

        public override void Update(Role entityToUpdate)
        {
            throw new Exception("Could not update a Role");
        }
    }
}
