using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis_opdracht.Data;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.web.Mapper
{
    public class TennisMapper : Profile
    {
        public TennisMapper()
        {
            CreateMap<Member, Member>().ReverseMap();
        }
    }
}
