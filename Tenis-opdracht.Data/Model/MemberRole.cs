using System;
using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.Data.Model
{
    public class MemberRole : IIsDeleted
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
