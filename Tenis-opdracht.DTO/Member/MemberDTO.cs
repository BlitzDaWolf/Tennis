using System;
using System.Collections.Generic;
using Tenis_opdracht.DTO.Game;
using Tenis_opdracht.DTO.Gender;
using Tenis_opdracht.DTO.Role;

namespace Tenis_opdracht.DTO.Member
{
    public class MemberDTO
    {
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderDTO Gender { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public List<MemberRoleDTO> Roles { get; set; }
        public List<GameDTO> Games { get; set; }
    }
}
