using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_fr2.entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }

        public SnapShot SnapShot { get; set; }= new SnapShot();

        public override string ToString()
        {
            return $"[{Id}] {Name} ({UnitPrice})";
        }
    }

}
