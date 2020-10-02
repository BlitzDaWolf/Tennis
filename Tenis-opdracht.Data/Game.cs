using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.Data
{
    public class Game : IIsDeleted
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
