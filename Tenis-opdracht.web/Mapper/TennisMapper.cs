using AutoMapper;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.DTO.Game;
using Tenis_opdracht.DTO.Gender;
using Tenis_opdracht.DTO.Member;
using Tenis_opdracht.DTO.Role;

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
                CreateMap<Game, GameDTO>().ReverseMap();
                CreateMap<League, LeagueDTO>().ReverseMap();
                CreateMap<GameResult, GameResultDTO>().ReverseMap();
            }
            // GameResult
            {

            }
            // Gender
            {
                CreateMap<Gender, GenderDTO>().ReverseMap();
            }
            // Member
            {
                CreateMap<Member, MemberDTO>().ReverseMap();
                CreateMap<Member, UpdateMemberDTO>().ReverseMap();
                CreateMap<Member, MemberCreateDTO>().ReverseMap();
            }
            // Role
            {
                CreateMap<Role, RoleDTO>().ReverseMap();
                CreateMap<MemberRole, MemberRoleDTO>().ReverseMap();
            }
        }
    }
}
