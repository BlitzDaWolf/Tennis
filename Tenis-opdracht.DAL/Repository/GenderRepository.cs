using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Repository
{
    public class GenderRepository : GenericRepository<Gender>
    {
        public GenderRepository(TenisContext context) : base(context) { }

        public override void Insert(Gender entity)
        {
            throw new Exception("Could not insert a gender");
        }

        public override void Delete(Gender entityToDelete)
        {
            throw new Exception("Could not delete a gender");
        }

        public override List<Gender> FromQuery(string query, params object[] parameters)
        {
            throw new Exception("This function is not avalibel for this type");
        }

        public override void Update(Gender entityToUpdate)
        {
            throw new Exception("Could not update a gender");
        }
    }
}
