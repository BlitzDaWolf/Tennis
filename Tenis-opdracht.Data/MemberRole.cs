using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.Data
{
    public class MemberRole : IIsDeleted
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
