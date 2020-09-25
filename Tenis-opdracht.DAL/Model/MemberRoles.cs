using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.DAL.Data
{
    public class MemberRoles
    {
        public int Id { get; set; }
        public Roles Role { get; set; }
        public Members Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
