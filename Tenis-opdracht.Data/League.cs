using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.Data
{
    public class League : IIsDeleted
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
