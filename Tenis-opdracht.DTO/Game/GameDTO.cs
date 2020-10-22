﻿using System;
using System.Collections.Generic;
using Tenis_opdracht.DTO.Member;

namespace Tenis_opdracht.DTO.Game
{
    public class GameDTO
    {
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public MemberDTO Member { get; set; }
        public int LeagueId { get; set; }
        public LeagueDTO League { get; set; }
        public DateTime Date { get; set; }
        public List<GameResultDTO> Results { get; set; }
    }
}
