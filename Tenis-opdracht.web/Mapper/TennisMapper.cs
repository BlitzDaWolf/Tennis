using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis_opdracht.Data;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.Data.Model.DTO;
using Tenis_opdracht.Data.Model.DTO.Gender;
using Tenis_opdracht.Data.Model.DTO.Member;

namespace Tenis_opdracht.web.Mapper
{
    public class TennisMapper : Profile
    {
        public TennisMapper()
        {
            // Fine
            {

            }
            // Game
            {

            }
            // GameResult
            {

            }
            // Gender
            {
                CreateMap<Gender, GenderDTO>().ReverseMap();
            }
            // League
            // Member
            {
                CreateMap<Member, MemberDTO>().ReverseMap();
                CreateMap<Member, MemberCreateDTO>().ReverseMap();
            }
            // MemberRole
            {

            }
            // Role
            {

            }
        }
    }
}
