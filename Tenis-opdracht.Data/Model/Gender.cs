using System.Collections;
using System.Collections.Generic;
using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.Data.Model
{
    public class Gender : IIsDeleted
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}