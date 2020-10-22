using System;
using System.Collections.Generic;
using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.Data.Model
{
    public class Game : IIsDeleted
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<GameResult> Results { get; set; }
    }
}
