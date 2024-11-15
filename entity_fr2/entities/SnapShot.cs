using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_fr2.entities
{
    /*
     * this class may used by the app
     * to take a snapshot of the current state
     * use for debug & test but we don't want to add to data base
     */
    [NotMapped]
    public class SnapShot
    {
        public DateTime dateTime => DateTime.UtcNow;
        public string version => Guid.NewGuid().ToString().Substring(0, 8);
    }
}
