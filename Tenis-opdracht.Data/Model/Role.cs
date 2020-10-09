using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.Data.Model
{
    public class Role : IIsDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
