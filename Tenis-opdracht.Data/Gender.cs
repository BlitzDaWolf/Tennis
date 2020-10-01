using System;
using System.Collections.Generic;

namespace Tenis_opdracht.Data
{
    public class Gender : IIsDeleted
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
