﻿using System;
using Tenis_opdracht.Data.Model.Interface;
using System.Collections.Generic;

namespace Tenis_opdracht.Data.Model
{
    public class Member : IIsDeleted
    {
        public int Id { get; set; }
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Fine> Fines { get; set; }
        public virtual List<MemberRole> Roles { get; set; }
        public virtual List<Game> Games { get; set; }

        public string FullName => $"{LastName} {FirstName}";
        public string FullAddress => $"{Address} {Number} {Addition} | {City} {Zipcode}";
    }
}
