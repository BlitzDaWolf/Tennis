using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.DTO.Game
{
    public class CreatGameResultDTO
    {
        public int GameId { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
