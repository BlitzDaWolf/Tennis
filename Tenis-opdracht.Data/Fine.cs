using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.Data
{
    public class Fine : IIsDeleted
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public Member Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime handOutDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
