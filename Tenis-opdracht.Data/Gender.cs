namespace Tenis_opdracht.Data
{
    public class Gender : IIsDeleted
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}