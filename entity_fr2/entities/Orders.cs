using System;

namespace entity_fr2.entities
{
    public class Orders
    { 
        public int Id { get; set; }
        DateTime OrderDate { get; set; }
        public string? CustomerEmail { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {OrderDate} ({CustomerEmail})";
        }
    }

}
