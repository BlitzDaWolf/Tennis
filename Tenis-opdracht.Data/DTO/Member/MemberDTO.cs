using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.Data.Model.DTO.Gender;

namespace Tenis_opdracht.Data.Model.DTO.Member
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
    }
}
