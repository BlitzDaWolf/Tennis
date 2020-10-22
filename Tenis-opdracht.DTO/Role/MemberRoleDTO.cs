using System;

namespace Tenis_opdracht.DTO.Role
{
    public class MemberRoleDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoleDTO Role { get; set; }
    }
}
