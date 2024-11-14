using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_fr.Entities
{
    public partial class Employee
    {
        public override string ToString()
        {
            return $"{this.EmployeeId} [{this.FirstName} {this.LastName}] {this.Phone} {this.Email}";
        }
    }
}
